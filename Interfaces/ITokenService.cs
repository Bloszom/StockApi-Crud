using morningclassonapi.Model;

namespace morningclassonapi.Interfaces
{
    public interface ITokenService
    {
        string CreateToken(AppUser user);


    }
}
