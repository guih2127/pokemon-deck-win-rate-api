using System;
using System.Collections.Generic;

namespace PokemonDeckWinRateAPI.ViewModel
{
    public class PagedListViewModel<T>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public int TotalRecords { get; set; }
        public double TotalPages { get; set; }
        public IEnumerable<T> Data { get; set; }

        public PagedListViewModel(IEnumerable<T> data, int pageNumber, int pageSize, int totalRecords)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            Data = data;
            TotalRecords = totalRecords;
            TotalPages = Math.Round((double)((double)totalRecords / (double)pageSize), MidpointRounding.ToPositiveInfinity);
        }
    }
}