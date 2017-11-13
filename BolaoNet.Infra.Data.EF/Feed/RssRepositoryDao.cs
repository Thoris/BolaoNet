using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Feed
{
    public class RssRepositoryDao: 
        Base.BaseRepositoryDao<Domain.Entities.Feed.RssEntry>,
        Domain.Interfaces.Repositories.Feed.IRssDao
    {
        
        #region Constructors/Destructors

        public RssRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IRssDao

        public List<Domain.Entities.Feed.RssEntry> GetFeedList(string currentUserName, DateTime currentDateTime, int maxFeeds)
        {
            return base.GetAll().ToList();
        }

        #endregion
    }
}
