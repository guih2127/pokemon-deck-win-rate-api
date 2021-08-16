using PokemonDeckWinRateAPI.Repositories.Interfaces;
using PokemonDeckWinRateAPI.ViewModel;

namespace PokemonDeckWinRateAPI.Repositories
{
    public class BaseRepository : IBaseRepository
    {
        public string AddPaginationToDapperQuery(string query)
        {
            return query + " OFFSET @Offset ROWS FETCH NEXT @Next ROWS ONLY ";
        }
    }
}
