using Rest.net5.Data.VO;

namespace Rest.net5.Business
{
    public interface ILoginBusiness
    {
        TokenVO ValidateCredentials(UserVO user);
    }
}
