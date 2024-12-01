using PassportWebApplication.Models;

namespace PassportWebApplication.Repository.IRepository
{
    public interface IJWTTokenService 
    {
        Task<string> GenerateToken(PassportUser user);
    }
}
