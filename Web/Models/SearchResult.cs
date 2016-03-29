namespace Web.Models
{
    public class SearchResult
    {
        public ulong Id { get; private set; }
        public string Content { get; private set; }
        public string Nickname { get; private set; }
        public string ProfileImageUri { get; private set; }

        public SearchResult(ulong id, string content, string nickname, string profileImageUri)
        {
            Id = id;
            Content = content;
            Nickname = nickname;
            ProfileImageUri = profileImageUri;
        }
    }
}