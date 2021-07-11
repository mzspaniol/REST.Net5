using Rest.net5.Controllers.Model;
using Rest.net5.Model.Base;
using System.Collections.Generic;

namespace Rest.net5.Repository.Implementations
{
    public interface IRepository<T> where T: BaseEntity
    {
        T Create(T item);
        T FindByID(long id);
        List<T> FindAll();
        T Update(T item);
        void Delete(long id);
        bool Exists(long id);

    }
}

