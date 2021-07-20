using Rest.net5.Controllers.Model;
using Rest.net5.Repository.Implementations;
using System.Collections.Generic;

namespace Rest.net5.Repository.Generic
{
    public interface IPersonRepository : IRepository<Person> 
    { 
        Person Disable(long id);

        List<Person> FindByName(string firstName, string secondName);
    }
}
