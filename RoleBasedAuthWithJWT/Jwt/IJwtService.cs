using RoleBasedAuthWithJWT.Models;

namespace RoleBasedAuthWithJWT.Jwt
{
    public interface IJwtService
    {
        string GenerateJwtToken(User user,List<string>roles);
    }
}
