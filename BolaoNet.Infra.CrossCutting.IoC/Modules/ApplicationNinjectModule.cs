using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.CrossCutting.IoC.Modules
{
    public class ApplicationNinjectModule : NinjectModule
    {
        #region Methods

        public override void Load()
        {

            Bind<Application.Interfaces.Facade.IInitializationFacadeApp>().To<Application.Facade.InitializationFacadeApp>();

            Bind<Application.Interfaces.Testes.ITestesApp>().To<Application.Testes.TestesApp>();


            Bind<Application.Interfaces.Notification.INotificationApp>().To<Application.Notification.NotificationApp>();

            Bind<Application.Interfaces.Boloes.IApostaExtraApp>().To<Application.Boloes.ApostaExtraApp>();
            Bind<Application.Interfaces.Boloes.IApostaExtraUsuarioApp>().To<Application.Boloes.ApostaExtraUsuarioApp>();
            Bind<Application.Interfaces.Boloes.IApostaPontosApp>().To<Application.Boloes.ApostaPontosApp>();
            Bind<Application.Interfaces.Boloes.IApostasRestantesApp>().To<Application.Boloes.ApostasRestantesApp>();
            Bind<Application.Interfaces.Boloes.IBolaoApp>().To<Application.Boloes.BolaoApp>();
            Bind<Application.Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioApp>().To<Application.Boloes.BolaoCampeonatoClassificacaoUsuarioApp>();
            Bind<Application.Interfaces.Boloes.IBolaoCriterioPontosApp>().To<Application.Boloes.BolaoCriterioPontosApp>();
            Bind<Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp>().To<Application.Boloes.BolaoCriterioPontosTimesApp>();
            Bind<Application.Interfaces.Boloes.IBolaoMembroApp>().To<Application.Boloes.BolaoMembroApp>();
            Bind<Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp>().To<Application.Boloes.BolaoMembroClassificacaoApp>();
            Bind<Application.Interfaces.Boloes.IBolaoMembroGrupoApp>().To<Application.Boloes.BolaoMembroGrupoApp>();
            Bind<Application.Interfaces.Boloes.IBolaoPontoRodadaApp>().To<Application.Boloes.BolaoPontoRodadaApp>();
            Bind<Application.Interfaces.Boloes.IBolaoPontoRodadaUsuarioApp>().To<Application.Boloes.BolaoPontoRodadaUsuarioApp>();
            Bind<Application.Interfaces.Boloes.IBolaoPontuacaoApp>().To<Application.Boloes.BolaoPontuacaoApp>();
            Bind<Application.Interfaces.Boloes.IBolaoPremioApp>().To<Application.Boloes.BolaoPremioApp>();
            Bind<Application.Interfaces.Boloes.IBolaoRegraApp>().To<Application.Boloes.BolaoRegraApp>();
            Bind<Application.Interfaces.Boloes.IBolaoRequestApp>().To<Application.Boloes.BolaoRequestApp>();
            Bind<Application.Interfaces.Boloes.IBolaoRequestStatusApp>().To<Application.Boloes.BolaoRequestStatusApp>();
            Bind<Application.Interfaces.Boloes.ICriterioApp>().To<Application.Boloes.CriterioApp>();
            Bind<Application.Interfaces.Boloes.IJogoUsuarioApp>().To<Application.Boloes.JogoUsuarioApp>();
            Bind<Application.Interfaces.Boloes.IMensagemApp>().To<Application.Boloes.MensagemApp>();
            Bind<Application.Interfaces.Boloes.IPagamentoApp>().To<Application.Boloes.PagamentoApp>();
            Bind<Application.Interfaces.Boloes.IPontuacaoApp>().To<Application.Boloes.PontuacaoApp>();

            Bind<Application.Interfaces.Campeonatos.ICampeonatoApp>().To<Application.Campeonatos.CampeonatoApp>();
            Bind<Application.Interfaces.Campeonatos.ICampeonatoClassificacaoApp>().To<Application.Campeonatos.CampeonatoClassificacaoApp>();
            Bind<Application.Interfaces.Campeonatos.ICampeonatoFaseApp>().To<Application.Campeonatos.CampeonatoFaseApp>();
            Bind<Application.Interfaces.Campeonatos.ICampeonatoGrupoApp>().To<Application.Campeonatos.CampeonatoGrupoApp>();
            Bind<Application.Interfaces.Campeonatos.ICampeonatoGrupoTimeApp>().To<Application.Campeonatos.CampeonatoGrupoTimeApp>();
            Bind<Application.Interfaces.Campeonatos.ICampeonatoHistoricoApp>().To<Application.Campeonatos.CampeonatoHistoricoApp>();
            Bind<Application.Interfaces.Campeonatos.ICampeonatoPosicaoApp>().To<Application.Campeonatos.CampeonatoPosicaoApp>();
            Bind<Application.Interfaces.Campeonatos.ICampeonatoRecordApp>().To<Application.Campeonatos.CampeonatoRecordApp>();
            Bind<Application.Interfaces.Campeonatos.ICampeonatoTimeApp>().To<Application.Campeonatos.CampeonatoTimeApp>();
            Bind<Application.Interfaces.Campeonatos.IHistoricoApp>().To<Application.Campeonatos.HistoricoApp>();
            Bind<Application.Interfaces.Campeonatos.IJogoApp>().To<Application.Campeonatos.JogoApp>();
            Bind<Application.Interfaces.Campeonatos.IPontuacaoApp>().To<Application.Campeonatos.PontuacaoApp>();

            Bind<Application.Interfaces.DadosBasicos.ICriterioFixoApp>().To<Application.DadosBasicos.CriterioFixoApp>();
            Bind<Application.Interfaces.DadosBasicos.IEstadioApp>().To<Application.DadosBasicos.EstadioApp>();
            Bind<Application.Interfaces.DadosBasicos.IPagamentoTipoApp>().To<Application.DadosBasicos.PagamentoTipoApp>();
            Bind<Application.Interfaces.DadosBasicos.ITimeApp>().To<Application.DadosBasicos.TimeApp>();

            Bind<Application.Interfaces.Users.IRoleApp>().To<Application.Users.RoleApp>();
            Bind<Application.Interfaces.Users.IUserApp>().To<Application.Users.UserApp>();
            Bind<Application.Interfaces.Users.IUserInRoleApp>().To<Application.Users.UserInRoleApp>();


            Bind<Application.Interfaces.Facade.IUserFacadeApp>().To<Application.Facade.UserFacadeApp>();
            Bind<Application.Interfaces.Facade.Campeonatos.ICopaMundo2014FacadeApp>().To<Application.Facade.Campeonatos.CopaMundo2014FacadeApp>();
            Bind<Application.Interfaces.Facade.Campeonatos.IStructureCopaMundoFacadeApp>().To<Application.Facade.Campeonatos.StructureCopaMundoFacadeApp>();


            Bind<Application.Interfaces.Reports.IBolaoMembroApostasReportApp>().To<Application.Reports.BolaoMembroApostasReportApp>();
            Bind<Application.Interfaces.Reports.IBolaoApostasInicioReportApp>().To<Application.Reports.BolaoApostasInicioReportApp>();
            Bind<Application.Interfaces.Reports.IBolaoApostasFimReportApp>().To<Application.Reports.BolaoApostasFimReportApp>();

            
        }

        #endregion
    }
}
