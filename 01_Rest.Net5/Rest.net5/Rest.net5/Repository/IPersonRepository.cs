using Rest.net5.Controllers.Model;
using Rest.net5.Repository.Implementations;

namespace Rest.net5.Repository.Generic
{
    public interface IPersonRepository : IPersonRepository<Person> 
    { 
        Person Disable(long id);
    }
}
