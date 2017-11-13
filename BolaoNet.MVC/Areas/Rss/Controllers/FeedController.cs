using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web.Http;
using System.Web.Mvc;
using System.Xml.Linq;

namespace BolaoNet.MVC.Areas.Rss
{
    public class FeedController : Controller //ApiController
    {
        #region Comments
        //// GET: api/Feed
        //public IEnumerable<string> Get()
        //{
        //    return new string[] { "value1", "value2" };
        //}

        //// GET: api/Feed/5
        //public string Get(int id)
        //{
        //    return "value";
        //}

        //// POST: api/Feed
        //public void Post([FromBody]string value)
        //{
        //}

        //// PUT: api/Feed/5
        //public void Put(int id, [FromBody]string value)
        //{
        //}

        //// DELETE: api/Feed/5
        //public void Delete(int id)
        //{
        //}
        #endregion
         
        public ActionResult RssIndex()
        {
            return new BolaoNet.Feed.Rss.FeedManager(
                "BolaoNet", "Feed de notícias do BolãoNET", "http://thorisbolaonet.somee.com", "Feed", "RssIndex")                
                .GetRssFeed(this.ControllerContext, 1);
        }
        public ActionResult AtomIndex()
        {
            return new BolaoNet.Feed.Rss.FeedManager(
                "BolaoNet", "Feed de notícias do BolãoNET", "http://thorisbolaonet.somee.com", "Feed", "RssIndex")
                .GetAtomFeed(this.ControllerContext, 1);


        }

        public ActionResult Index()
        {
            string strPathAndQuery = HttpContext.Request.Url.PathAndQuery;
            string strUrl = HttpContext.Request.Url.AbsoluteUri.Replace(strPathAndQuery, "/");

            string feedUrl = strUrl + "/" + "rss/feed/rssindex";


            XDocument feedXml = XDocument.Load(feedUrl);
            var feeds = from feed in feedXml.Descendants("item")
                        select new Feed.Rss.EntryFeedItem
                        {
                            Title = feed.Element("title").Value,
                            DateAdded = DateTime.Parse(feed.Element("pubDate").Value),
                            Description = Regex.Match(feed.Element("description").Value, @"^.{1,180}\b(?<!\s)").Value

                        };


            List<Feed.Rss.EntryFeedItem> list = feeds.ToList();

            return View(list);
        }


        //public static IEnumerable<Feed.Rss.EntryFeedItem> GetRssFeed()
        //{
        //    string url = Request.Url.AbsoluteUri.ToString().ToLower();

        //    XDocument feedXml = XDocument.Load(_blogURL);
        //    var feeds = from feed in feedXml.Descendants("item")
        //                select new Feed.Rss.EntryFeedItem
        //                {
        //                    Title = feed.Element("title").Value,
        //                    Link = feed.Element("link").Value,
        //                    Description = Regex.Match(feed.Element("description").Value, @"^.{1,180}\b(?<!\s)").Value
        //                };
        //    return feeds;
        //}
    }
}
