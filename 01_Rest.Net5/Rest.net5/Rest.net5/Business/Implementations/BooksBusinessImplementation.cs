using Rest.net5.Controllers.Model;
using System.Collections.Generic;
using Rest.net5.Model.Context;
using Rest.net5.Data.VO;
using Rest.net5.Repository.Implementations;
using System.Linq;
using System;
using Rest.net5.Data.Converter.Implementation;

namespace Rest.net5.Business.Implementations
{
    public class BooksBusinessImplementation : IBooksBusiness
    {
        private readonly IRepository<Books> _repository;          
        private readonly BooksConverter _converter;
        public BooksBusinessImplementation(IRepository<Books> repository)
        {
            _repository = repository;
            _converter = new BooksConverter();
        }

        public BooksVO Create(BooksVO books)
        {
            var booksEntity = _converter.Parse(books);
            booksEntity = _repository.Create(booksEntity);
            return _converter.Parse(booksEntity);
        }

        public void Delete(long id)
        {
            _repository.Delete(id);
        }

        public List<BooksVO> FindAll()
        {
            return _converter.Parse(_repository.FindAll());
        }

        public BooksVO FindByID(long id)
        {
            return _converter.Parse(_repository.FindByID(id));
        }

        public BooksVO Update(BooksVO books)
        {
            var booksEntity = _converter.Parse(books);
            booksEntity = _repository.Update(booksEntity);
            return _converter.Parse(booksEntity);
        }

    }
}
