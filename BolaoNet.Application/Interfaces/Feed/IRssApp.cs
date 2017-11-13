using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Interfaces.Feed
{
    public interface IRssApp
        : Domain.Interfaces.Services.Feed.IRssService,
        Base.IGenericApp<Domain.Entities.Feed.RssEntry>
    {
    }
}
