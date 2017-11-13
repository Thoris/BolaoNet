using Ninject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace BolaoNet.Feed.Rss
{
    public class FeedManager
    {
        

        #region Variables

        private FeedRepository _repository;
        private static string _title;
        private static string _description;
        private static string _url;
        private static string _controller;
        private static string _action;

        #endregion

        #region Constructors/Destructors

        public FeedManager(string title, string description, string url, string controller, string action)
        {
            Ninject.StandardKernel kernel = (StandardKernel)new Infra.CrossCutting.IoC.IoC().Kernel;

            Application.Interfaces.Feed.IRssApp rssApp = kernel.Get<Application.Interfaces.Feed.IRssApp>();

            _repository = new FeedRepository(rssApp);

            _title = title;
            _description = description;
            _url = url;
            _controller = controller;
            _action = action;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Returns an RSS Feed
        /// </summary>
        /// <param name="id">Accepts an int id.</param>
        /// <returns></returns>
        public RssActionResult GetRssFeed(ControllerContext ctx, int maxFeed)
        {
            SyndicationFeedItemMapper<EntryFeedItem> mapper = SetUpFeedMapper();

            SyndicationFeedOptions options = SetUpFeedOptions();

            IList<EntryFeedItem> feedItems = _repository.GetList(maxFeed);  

            SyndicationFeedHelper<EntryFeedItem> feedHelper = SetUpFeedHelper(ctx, mapper, options, feedItems);

            return new RssActionResult(feedHelper.GetFeed());
        }

        /// <summary>
        /// Returns an Atom feed.
        /// </summary>
        /// <param name="id">Accepts an int id.</param>
        /// <returns></returns>
        public AtomActionResult GetAtomFeed(ControllerContext ctx, int maxFeed)
        {
            SyndicationFeedItemMapper<EntryFeedItem> mapper = SetUpFeedMapper();

            SyndicationFeedOptions options = SetUpFeedOptions();

            IList<EntryFeedItem> feedItems = _repository.GetList(maxFeed); 

            SyndicationFeedHelper<EntryFeedItem> feedHelper = SetUpFeedHelper(ctx, mapper, options, feedItems);

            return new AtomActionResult(feedHelper.GetFeed());

        }

        private SyndicationFeedHelper<EntryFeedItem> SetUpFeedHelper(ControllerContext ctx, SyndicationFeedItemMapper<EntryFeedItem> mapper,
            SyndicationFeedOptions options, IList<EntryFeedItem> feedItems)
        {
            SyndicationFeedHelper<EntryFeedItem> feedHelper = new SyndicationFeedHelper<EntryFeedItem>
                (
                    ctx,
                    feedItems,
                    mapper,
                    options
                );
            return feedHelper;
        }

        private static SyndicationFeedOptions SetUpFeedOptions()
        {
            SyndicationFeedOptions options = new SyndicationFeedOptions
                (
                    _title,
                    _description,
                    _url
                );
            return options;
        }

        private static SyndicationFeedItemMapper<EntryFeedItem> SetUpFeedMapper()
        {
            SyndicationFeedItemMapper<EntryFeedItem> mapper = new SyndicationFeedItemMapper<EntryFeedItem>
                (
                    f => f.Title,
                    f => f.Description,
                    _controller,
                    _action,
                    f => f.Id.ToString(),
                    f => f.DateAdded
                );
            return mapper;
        }

        #endregion
    }
}
