using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FirstExerciseWebMinimalApi.Person
{
    public class Person
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateOnly BirthDate { get; set; }
        public string Street { get; set; }
        public string City { get; set; }
        public int HouseNumber { get; set; }
        public int PostalCode { get; set; }
    }
}
