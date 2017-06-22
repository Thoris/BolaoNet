using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.CrossCutting.IoC.Modules
{
    public class InfrastructureNinjectModule : NinjectModule
    {
        #region Methods

        public override void Load()
        {
            string userName = "";


            Bind<Domain.Interfaces.Services.Notification.INotificationService>().To<Infra.Notification.Mail.MailNotification>().WithConstructorArgument("userName", userName);
            

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
