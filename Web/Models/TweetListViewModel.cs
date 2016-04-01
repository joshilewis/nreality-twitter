using System.Collections.Generic;

namespace Web.Models
{
    public class TweetListViewModel
    {
        public List<Tweet> Tweets { get; private set; }

        public TweetListViewModel(List<Tweet> tweets)
        {
            Tweets = tweets;
        }
    }
}