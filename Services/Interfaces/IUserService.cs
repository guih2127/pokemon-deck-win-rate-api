using PokemonDeckWinRateAPI.Models;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> InsertUserAsync(User user);
        string GenerateToken(User user);
    }
}