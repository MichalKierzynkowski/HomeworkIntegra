using Xunit;
using FirstExercise;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.ObjectModel;
using FirstExerciseWebMinimalApi;
using FirstExerciseWebMinimalApi.Person;
using FluentValidation.TestHelper;

namespace Tests.WebApiTests
{
    public class Tests
    {
        private PersonValidator _personValidator;

        public Tests()
        {
            _personValidator = new PersonValidator();
        }
        [Fact]
        public void ShouldHaveErrorWhenPropertiesAreNull()
        {
            var model = new Person
            {
                Name = "",Surname="test",BirthDate = DateTime.Now,City = "test",HouseNumber = 25,PostalCode = 12345,Street = "Test"

            };
            var result = _personValidator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.Name);

        }
        [Fact]
        public void ShouldHaveErorWhenPostalCodeDontHave5Digits()
        {
            var model = new Person
            {
                Name = "test",
                Surname = "test",
                BirthDate = DateTime.Now,
                City = "test",
                HouseNumber = 25,
                PostalCode = 1,
                Street = "Test"

            };
            var result = _personValidator.TestValidate(model);
            result.ShouldHaveValidationErrorFor(x => x.PostalCode);
        }
        [Fact]
        public void ShouldNotHaveErrorWhenPostalCodeContainsDigits()
        {
            var model = new Person
            {
                Name = "test",
                Surname = "test",
                BirthDate = DateTime.Now,
                City = "test",
                HouseNumber = 25123,
                PostalCode = 12345,
                Street = "Test"

            };
            var result = _personValidator.TestValidate(model);
            result.ShouldNotHaveValidationErrorFor(x => x.PostalCode);
        }

    }
}
