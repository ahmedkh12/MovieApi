using Microsoft.AspNetCore.Identity;

namespace MovieApi.Repositers
{
    public interface ITokenRepositery
    {
        string CreatedJWTToken(IdentityUser user);
    }
}
