using System.Collections.Generic;

namespace Web.Models
{
    public class SearchViewModel
    {
        public List<SearchResult> SearchResults { get; private set; }

        public SearchViewModel(List<SearchResult> results)
        {
            SearchResults = results;
        }
    }
}