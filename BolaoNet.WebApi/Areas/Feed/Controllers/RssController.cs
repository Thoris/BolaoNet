using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BolaoNet.WebApi.Areas.Feed.Controllers
{
    public class RssController :
        GenericApiController<Domain.Entities.Feed.RssEntry>,
        Domain.Interfaces.Services.Feed.IRssService
    {
        #region Properties
         
        private Domain.Interfaces.Services.Feed.IRssService Service
        {
            get { return (Domain.Interfaces.Services.Feed.IRssService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        public RssController(Domain.Interfaces.Services.Feed.IRssService service)
            : base(service)
        {

        }

        #endregion

        #region IRssService members

        public List<Domain.Entities.Feed.RssEntry> GetFeedList(int maxFeeds)
        {
            return Service.GetFeedList(maxFeeds);
        }

        #endregion
    }
}
