using Microsoft.EntityFrameworkCore;
using PokemonDeckWinRateAPI.Models;
using PokemonDeckWinRateAPI.Models.Context;
using PokemonDeckWinRateAPI.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PokemonDeckWinRateAPI.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PokemonDeckWinRateContext _context;

        public UserRepository(PokemonDeckWinRateContext context)
        {
            _context = context;
        }

        public async Task<User> GetUserByUsernameAsync(string username)
        {
            var user = await _context.Users
                .Where(u => u.Username == username)
                .FirstOrDefaultAsync();

            return user;
        }

        public async Task<User> InsertUserAsync(User user)
        {
            var userToInsert = await _context.Users.AddAsync(user);
            await _context.SaveChangesAsync();

            var insertedUser = await _context.Users
                .Where(u => u.Id == userToInsert.Entity.Id)
                .FirstOrDefaultAsync();

            return insertedUser;
        }
    }
}