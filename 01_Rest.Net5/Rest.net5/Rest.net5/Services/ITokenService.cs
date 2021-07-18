using System.Collections.Generic;
using System.Security.Claims;

namespace Rest.net5.Services
{
    public interface ITokenService
    {
        string GenerateAcessToken(IEnumerable<Claim> claims);
        string GenerateRefreshToken();

        ClaimsPrincipal GetClaimsPrincipalFromExpiredToken(string token);
    }
}
