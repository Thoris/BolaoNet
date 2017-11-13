using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Feed.Rss
{
    public class FeedRepository
    {
        #region Variables

        private Application.Interfaces.Feed.IRssApp _rssApp;

        #endregion

        #region Constructors/Destructors

        public FeedRepository (Application.Interfaces.Feed.IRssApp rssApp)
        {
            _rssApp = rssApp;
        }

        #endregion

        #region Methods

        public List<EntryFeedItem> GetList(int maxFeeds)
        {
            List<Domain.Entities.Feed.RssEntry> list = _rssApp.GetFeedList(maxFeeds);

            List<EntryFeedItem> res = new List<EntryFeedItem>();

            for (int c=0; c < list.Count; c++)
            {
                res.Add(new EntryFeedItem()
                    {
                        CreatedBy = list[c].CreatedBy,
                        DateAdded = list[c].DateAdded,
                        Description = list[c].Description,
                        Id = list[c].Id,
                        Title = list[c].Title
                    });
            }

            return res;
        }
        public void AddEntry(EntryFeedItem entry)
        {
            Domain.Entities.Feed.RssEntry newEntry = new Domain.Entities.Feed.RssEntry()
            {
                CreatedBy = entry.CreatedBy,
                DateAdded = entry.DateAdded,
                Description = entry.Description,
                Id = entry.Id,
                Title = entry.Title
            };

            _rssApp.Insert(newEntry);
        }

        #endregion
    }
}
