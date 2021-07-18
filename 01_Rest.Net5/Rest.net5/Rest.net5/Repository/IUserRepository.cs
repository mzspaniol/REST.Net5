using Rest.net5.Data.VO;
using Rest.net5.Model;

namespace Rest.net5.Repository
{
    public interface IUserRepository
    {
        User ValidateCredentials(UserVO user);
        User ValidateCredentials(string username);

        bool RevokeToken(string username);
        User RefreshUserInfo(User user);


    }
}
