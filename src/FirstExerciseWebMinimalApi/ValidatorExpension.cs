using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;

namespace FirstExerciseWebMinimalApi
{
    public static  class ValidatorExpension
    {
        public static RouteHandlerBuilder WithValidator<T>(this RouteHandlerBuilder builder) where T : class
        {
            builder.Add(EndpointBuilder =>
                {
                    var originalDelete = EndpointBuilder.RequestDelegate;
                    EndpointBuilder.RequestDelegate = async HttpContext =>
                    {
                        var validator = HttpContext.RequestServices.GetRequiredService<IValidator<T>>();
                        HttpContext.Request.EnableBuffering();
                        var body = await HttpContext.Request.ReadFromJsonAsync<T>();
                        if (body == null)
                        {
                            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await HttpContext.Response.WriteAsync("Could not map body to request model");
                            return;

                        }

                        var validationResult = validator.Validate(body);
                        if (!validationResult.IsValid)
                        {
                            HttpContext.Response.StatusCode = StatusCodes.Status400BadRequest;
                            await HttpContext.Response.WriteAsJsonAsync(validationResult.Errors);
                            return;
                        }

                        HttpContext.Request.Body.Position = 0;
                        await originalDelete(HttpContext);
                    };
                }
                
                
                );
            return builder;


        }
    }
}
