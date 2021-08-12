using PokemonDeckWinRateAPI.Models;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<User> GetUserByUsernameAsync(string username);
        Task<User> InsertUserAsync(User user);
    }
}
