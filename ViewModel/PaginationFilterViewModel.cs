namespace PokemonDeckWinRateAPI.ViewModel
{
    public class PaginationFilterViewModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public PaginationFilterViewModel()
        {
            this.PageNumber = 1;
            this.PageSize = 10;
        }
        public PaginationFilterViewModel(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber < 1 ? 1 : pageNumber;
            this.PageSize = pageSize > 10 ? 10 : pageSize;
        }
    }
}