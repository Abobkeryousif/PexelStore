using Microsoft.AspNetCore.Identity;

namespace PexelStore.Repository
{
    public interface ITokenRepository
    {
        string CreateToken(IdentityUser user, List<string> Roles);
    }
}
