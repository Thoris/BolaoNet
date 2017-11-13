using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Mapping.Feed
{
    public class RssConfiguration :
        Base.BaseConfiguration<BolaoNet.Domain.Entities.Feed.RssEntry>
    {

        #region Constructors/Destructors

        public RssConfiguration()
        {
            ToTable("Rss");

            //Property(c => c.Descricao)
            //    .HasMaxLength(255);

        }

        #endregion
    }
}
