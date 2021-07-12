using Rest.net5.Controllers.Model;
using Rest.net5.Data.Converter.Contract;
using Rest.net5.Data.VO;
using System.Collections.Generic;
using System.Linq;

namespace Rest.net5.Data.Converter.Implementation
{
    public class BooksConverter : IParser<BooksVO, Books>, IParser<Books, BooksVO>
    {
        public Books Parse(BooksVO origin)
        {
            if (origin == null) return null;
            return new Books
            {
                Id = origin.Id,
                Author = origin.Author,
                Launch_date = origin.Launch_date,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<Books> Parse(List<BooksVO> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }

        public BooksVO Parse(Books origin)
        {
            if (origin == null) return null;
            return new BooksVO
            {
                Id = origin.Id,
                Author = origin.Author,
                Launch_date = origin.Launch_date,
                Price = origin.Price,
                Title = origin.Title
            };
        }

        public List<BooksVO> Parse(List<Books> origin)
        {
            if (origin == null) return null;
            return origin.Select(item => Parse(item)).ToList();
        }
    }
}
