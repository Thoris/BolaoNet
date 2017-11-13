using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Feed
{
    public class RssService
     : Base.BaseGenericService<Entities.Feed.RssEntry>,
       Interfaces.Services.Feed.IRssService
    {
        #region Properties

        private Interfaces.Repositories.Feed.IRssDao Dao
        {
            get { return (Interfaces.Repositories.Feed.IRssDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public RssService(string userName, Interfaces.Repositories.LogReporting.ILogReportingDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Feed.RssEntry>)dao, logging)
        {

        }

        #endregion

        #region IRssService members
                
        public List<Entities.Feed.RssEntry> GetFeedList(int maxFeeds)
        {
            return Dao.GetFeedList(base.CurrentUserName, DateTime.Now, maxFeeds);   
        }

        #endregion
    }
}
