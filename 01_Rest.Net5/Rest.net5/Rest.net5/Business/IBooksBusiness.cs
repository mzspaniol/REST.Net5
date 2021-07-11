using Rest.net5.Controllers.Model;
using System.Collections.Generic;

namespace Rest.net5.Business.Implementations
{
    public interface IBooksBusiness
    {
        Books Create(Books books);
        Books FindByID(long id);
        List<Books> FindAll();
        Books Update(Books books);
        void Delete(long id);
    }
}
