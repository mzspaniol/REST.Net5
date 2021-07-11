using Rest.net5.Controllers.Model;
using System.Collections.Generic;

namespace Rest.net5.Business.Implementations
{
    public interface IPersonBusiness
    {
        Person Create(Person person);
        Person FindByID(long id);
        List<Person> FindAll();
        Person Update(Person person);
        void Delete(long id);
    }
}
