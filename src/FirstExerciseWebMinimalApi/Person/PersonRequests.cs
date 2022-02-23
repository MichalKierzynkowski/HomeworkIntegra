using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstExerciseWebMinimalApi.Person
{
    public static  class PersonRequests
    {
        public static WebApplication RegisterEndPoints(this WebApplication app)
        {
            app.MapGet("/persons", PersonRequests.GetAll);

            app.MapGet("/persons/{id}", PersonRequests.GetById);
            app.MapPost("/person/{person}", PersonRequests.Create).WithValidator<Person>();
            
            return app;
        }

        public static IResult GetAll(IPersonService service)
        {
            var products = service.GetAll();
            return Results.Ok(products);
        }

        public static IResult GetById(IPersonService service,Guid id)
        {
            var product = service.GetById(id);
            if (product == null)
            {
                return Results.NotFound();
            }
            return Results.Ok(product);
        }

        public static IResult Create(IPersonService service, Person person)
        {
            service.Create(person);
            return Results.Created($"/Person/{person.Id}", person);
        }

       

       
    }
}
