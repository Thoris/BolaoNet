using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Feed
{
    public interface IRssDao : Base.IGenericDao<Entities.Feed.RssEntry>
    {
        List<Entities.Feed.RssEntry> GetFeedList(string currentUserName, DateTime currentDateTime, int maxFeeds);
    }
}
