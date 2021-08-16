namespace PokemonDeckWinRateAPI.ViewModel
{
    public class PaginationFilterViewModel
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int Offset { get; set; }
        public int Next { get; set; }

        public PaginationFilterViewModel()
        {
            PageNumber = 1;
            PageSize = 10;
        }

        public PaginationFilterViewModel(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber < 1 ? 1 : pageNumber;
            PageSize = pageSize > 10 ? 10 : pageSize;

            Next = pageSize;
            Offset = (PageNumber - 1) * Next;
        }
    }
}