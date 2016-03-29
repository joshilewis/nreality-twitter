namespace Web.Models
{
    public class SearchResult
    {
        public ulong Id { get; private set; }
        public string Content { get; private set; }

        public SearchResult(ulong id, string content)
        {
            Id = id;
            Content = content;
        }
    }
}