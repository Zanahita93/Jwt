using JwtTokenGenerationAPI.Models;

namespace JwtTokenGenerationAPI.Repository
{
    public interface IJwtService
    {
        string Generate(User user);

        Task<IEnumerable<User>> GetAllUsers();

        Task<User> GetByUserAndPass(string username, string password);

        Task<string> AddUser(UserDto user);
    }
}
