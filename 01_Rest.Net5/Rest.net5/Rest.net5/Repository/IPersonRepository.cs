using Rest.net5.Controllers.Model;
using System.Collections.Generic;

namespace Rest.net5.Repository.Implementations
{
    public interface IPersonRepository
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
        bool Exists(long id);

    }
}

