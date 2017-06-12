using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.CrossCutting.IoC.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        #region Methods

        public override void Load()
        {
            //Bind<IGenreAppService>().To<GenreAppService>();
            //Bind<IArtistAppService>().To<ArtistAppService>();
            //Bind<IAlbumAppService>().To<AlbumAppService>();
            //Bind<ICartAppService>().To<CartAppService>();
            //Bind<IOrderAppService>().To<OrderAppService>();
            //Bind<IOrderDetailAppService>().To<OrderDetailAppService>();
        }

        #endregion
    }
}
