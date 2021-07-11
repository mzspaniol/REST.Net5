using Rest.net5.Controllers.Model;
using System.Collections.Generic;
using Rest.net5.Model.Context;
using Rest.net5.Repository.Implementations;
using System.Linq;
using System;

namespace Rest.net5.Business.Implementations
{
    public class PersonBusinessImplementation : IPersonBusiness
    {


        private readonly IRepository<Person> _repository;

        public PersonBusinessImplementation(IRepository<Person> repository)
        {
            _repository = repository;
        }

        public Person Create(Person person)
        {
            return _repository.Create(person);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Person> FindAll()
        {
            return _repository.FindAll();
        }

        public Person FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Person Update(Person person)
        {
            return _repository.Update(person);
        }

    }
}
