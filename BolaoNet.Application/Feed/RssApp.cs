using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Feed
{
    public class RssApp :
        Base.GenericApp<Domain.Entities.Feed.RssEntry>,
        Application.Interfaces.Feed.IRssApp
    {
        #region Properties

        private Domain.Interfaces.Services.Feed.IRssService Service
        {
            get { return (Domain.Interfaces.Services.Feed.IRssService)base._service; }
        }

        #endregion

        #region Constructors/Destructors


        public RssApp(Domain.Interfaces.Services.Feed.IRssService service)
            : base (service)
        {

        }

        #endregion

        #region IRssApp members

        public List<Domain.Entities.Feed.RssEntry> GetFeedList(int maxFeeds)
        {
            return Service.GetFeedList(maxFeeds);
        }

        #endregion
    }
}
