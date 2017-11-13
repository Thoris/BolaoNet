using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Feed
{
    public class RssIntegration :
        Base.GenericIntegration<Domain.Entities.Feed.RssEntry>,
        Domain.Interfaces.Services.Feed.IRssService
    {
        #region Constants

        /// <summary>
        /// Nome do módulo usado para realizar a requisição.
        /// </summary>
        private const string ModuleName = "Rss";

        #endregion

        #region Constructors/Destructors

        public RssIntegration(string url, string token)
            : base(url, ModuleName, token)
        {

        }

        #endregion

        #region IRssService

        public List<Domain.Entities.Feed.RssEntry> GetFeedList(int maxFeeds)
        {
            return null;

        } 
        #endregion
    }
}
