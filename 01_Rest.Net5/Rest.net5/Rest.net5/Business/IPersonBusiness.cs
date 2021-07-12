using Rest.net5.Data.VO;
using System.Collections.Generic;

namespace Rest.net5.Business.Implementations
{
    public interface IPersonBusiness
    {
        PersonVO Create(PersonVO person);
        PersonVO FindByID(long id);
        List<PersonVO> FindAll();
        PersonVO Update(PersonVO person);
        void Delete(long id);
    }
}
