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
        public ActionResult Index()
        {
            return View();
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

            var results = new List<SearchResult>();
            srch.Statuses.ForEach(entry => results.Add(new SearchResult(entry.StatusID, entry.Text,
                entry.User.Name, entry.User.ProfileImageUrl)));

            return View(new SearchViewModel(results));
        }
    }
}