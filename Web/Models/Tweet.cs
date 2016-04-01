namespace Web.Models
{
    public class Tweet
    {
        public ulong Id { get; set; }
        public string Content { get; set; }
        public string Nickname { get; set; }
        public string ProfileImageUri { get; set; }

        public Tweet(ulong id, string content, string nickname, string profileImageUri)
        {
            Id = id;
            Content = content;
            Nickname = nickname;
            ProfileImageUri = profileImageUri;
        }

        public Tweet()
        {
        }

        // override object.Equals
        public override bool Equals(object obj)
        {
            if (obj == null || GetType() != obj.GetType())
            {
                return false;
            }

            Tweet other = (Tweet) obj;
            return Id.Equals(other.Id);
        }

        // override object.GetHashCode
        public override int GetHashCode()
        {
            // TODO: write your implementation of GetHashCode() here
            throw new System.NotImplementedException();
            return base.GetHashCode();
        }
    }
}