using PokemonDeckWinRateAPI.ViewModel;

namespace PokemonDeckWinRateAPI.Repositories.Interfaces
{
    public interface IBaseRepository
    {
        public string AddPaginationToDapperQuery(string query);
    }
}
