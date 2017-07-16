using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.Tests.IoC.Modules
{
    public class ControllerNinjectModule : NinjectModule
    {
        #region Methods

        public override void Load()
        {
            //Bind<MVC.Controllers.AccountController>().To<MVC.Controllers.AccountController
            //Bind<Application.Interfaces.Notification.INotificationApp>().To<Application.Notification.NotificationApp>();



        }

        #endregion
    }
}
