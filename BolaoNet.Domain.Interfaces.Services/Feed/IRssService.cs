using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Feed
{
    public interface IRssService
        : Base.IGenericService<Entities.Feed.RssEntry>
    {
        List<Entities.Feed.RssEntry> GetFeedList(int maxFeeds);
    }
}
