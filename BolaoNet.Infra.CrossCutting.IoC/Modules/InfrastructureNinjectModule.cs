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
            //Bind<Domain.Interfaces.Services.Notification.INotificationService>().To<Infra.Notification.Mail.Mock.MailNotificationMock>();


            Bind<Domain.Interfaces.Services.Reports.FormatReport.IBolaoMembroApostasFormatReportService>().To<Infra.Reports.Pdf.PdfBolaoMembroApostasReport>();
            Bind<Domain.Interfaces.Services.Reports.FormatReport.IBolaoApostasInicioFormatReportService>().To<Infra.Reports.Pdf.PdfBolaoApostasInicioReport>();
            Bind<Domain.Interfaces.Services.Reports.FormatReport.IBolaoApostasFimFormatReportService>().To<Infra.Reports.Pdf.PdfBolaoApostasFimReport>();
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
