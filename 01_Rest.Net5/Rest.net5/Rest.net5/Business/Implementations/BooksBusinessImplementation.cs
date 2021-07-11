using Rest.net5.Controllers.Model;
using System.Collections.Generic;
using Rest.net5.Model.Context;
using Rest.net5.Repository.Implementations;
using System.Linq;
using System;

namespace Rest.net5.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {


        private readonly IRepository<Books> _repository;

        public BooksBusinessImplementation(IRepository<Books> repository)
        {
            _repository = repository;
        }

        public Books Create(Books books)
        {
            return _repository.Create(books);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<Books> FindAll()
        {
            return _repository.FindAll();
        }

        public Books FindByID(long id)
        {
            return _repository.FindByID(id);
        }

        public Books Update(Books books)
        {
            return _repository.Update(books);
        }

    }
}
