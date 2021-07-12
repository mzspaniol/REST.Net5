using Rest.net5.Data.VO;
using System.Collections.Generic;

namespace Rest.net5.Business.Implementations
{
    public interface IBooksBusiness
    {
        BooksVO Create(BooksVO books);
        BooksVO FindByID(long id);
        List<BooksVO> FindAll();
        BooksVO Update(BooksVO books);
        void Delete(long id);
    }
}
