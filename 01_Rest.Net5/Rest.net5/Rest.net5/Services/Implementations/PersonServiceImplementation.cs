using Rest.net5.Controllers.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Rest.net5.Services.Implementations
{
    public class PersonServiceImplementation : IPersonService
    {

    
        private volatile int count;

        public Person Create(Person person)
        {
            return person;
        }

        public void Delete(long id)
        {
            
        }

        public List<Person> FindAll()
        {
            List<Person> Persons = new List<Person> ();
            for (int i = 0;  i < 8; i++)
            {
                Person person = MockPerson(i);
                Persons.Add(person);
            }
            return Persons;
        }

        private Person MockPerson(int i)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "NamePerson" + i,
                LastName = "LastNamePerson" + i,
                Address = "Adress" + i,
                Gender = "Masculino" + i
            };
        }

        private long IncrementAndGet()
        {

            return Interlocked.Increment(ref count);
        }

        public Person FindByID(long id)
        {
            return new Person
            {
                Id = IncrementAndGet(),
                FirstName = "Matheus",
                LastName = "Spaniol",
                Address = "pernambuco",
                Gender = "Masculino"
            };
        }

        public Person Update(Person person)
        {
            return person;
        }
    }
}
