using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using LinqToTwitter;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        private static readonly List<Tweet> SavedTweets = new List<Tweet>();

        public ActionResult Index()
        {
            return View(new TweetListViewModel(SavedTweets));
        }

        public ActionResult Search(string searchTerm)
        {
            var consumerKey = ConfigurationManager.AppSettings["consumerKey"];
            var consumerSecret = ConfigurationManager.AppSettings["consumerSecret"];

            var auth = new ApplicationOnlyAuthorizer
            {
                CredentialStore = new InMemoryCredentialStore
                {
                    ConsumerKey = consumerKey,
                    ConsumerSecret = consumerSecret
                }
            };

            auth.AuthorizeAsync().Wait();

            var twitterCtx = new TwitterContext(auth);

            var srch =
                (twitterCtx.Search.Where(search => search.Type == SearchType.Search &&
                                                   search.Query == searchTerm))
                    .SingleOrDefault();

            var results = new List<Tweet>();
            srch.Statuses.ForEach(entry => results.Add(new Tweet(entry.StatusID, entry.Text,
                entry.User.Name, entry.User.ProfileImageUrl)));

            return View(new TweetListViewModel(results));
        }

        public ActionResult Save(Tweet tweetToSave)
        {
            if (!SavedTweets.Contains(tweetToSave)) SavedTweets.Add(tweetToSave);
            return RedirectToAction("Index");
        }

        public ActionResult Remove(Tweet tweet)
        {
            if (SavedTweets.Contains(tweet)) SavedTweets.Remove(tweet);
            return RedirectToAction("Index");
        }
    }
}