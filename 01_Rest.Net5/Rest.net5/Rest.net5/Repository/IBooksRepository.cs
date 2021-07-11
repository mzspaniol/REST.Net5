using Rest.net5.Controllers.Model;
using System.Collections.Generic;

namespace Rest.net5.Repository.Implementations
{
    public interface IBooksRepository
    {
        Books Create(Books books);
        Books FindByID(long id);
        List<Books> FindAll();
        Books Update(Books Books);
        void Delete(long id);
        bool Exists(long id);

    }
}

