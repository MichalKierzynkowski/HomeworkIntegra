using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace FirstExerciseWebMinimalApi.Person
{
    public class PersonService : IPersonService
    {
        public PersonService()
        {
           
           
            var person = new Person
            {
                
                Name = "Jan",BirthDate =new DateTime(1998,1,3)  ,City="Pila",HouseNumber = 2,PostalCode = 64920,Street = "Kosciuszki",Surname="Testowy"
            };
            _persons.Add(person.Id,person);

        }

        private readonly Dictionary<Guid, Person> _persons = new Dictionary<Guid, Person>();

        public Person GetById(Guid id)
        {
            return _persons.GetValueOrDefault(id);
        }

        public List<Person> GetAll()
        {
            return _persons.Values.ToList();
        }

        public void Create(Person person)
        {
            if (person==null)
            {
                return;
            }

            _persons.Add(person.Id,person);

        }

      

        
    }
}
