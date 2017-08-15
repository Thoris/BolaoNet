using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.CrossCutting.IoC.Modules
{
    //https://stackoverflow.com/questions/14315312/ninject-bind-same-interface-to-two-implementations


    public class WebApiIntegrationNinjectModule : NinjectModule
    {
        #region Methods

        public override void Load()
        {
            string url = "http://localhost:9586/";

            //Bind<Domain.Interfaces.Services.Logging.ILogging>().To<Infra.CrossCutting.Logging.Logger>();

            Bind(typeof(Domain.Interfaces.Services.Base.IGenericService<>)).To(typeof(WebApi.Integration.Base.GenericIntegration<>))
                .WhenInjectedExactlyInto(typeof(Application.Base.GenericApp<>))
                .WithConstructorArgument("url", url);

            Bind<Domain.Interfaces.Services.Testes.ITesteService>().To<WebApi.Integration.Tests.TestesIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Testes.TestesApp))
                .WithConstructorArgument("url", url);

            Bind<Domain.Interfaces.Services.Boloes.IApostaExtraService>().To<WebApi.Integration.Boloes.ApostaExtraIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.ApostaExtraApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService>().To<WebApi.Integration.Boloes.ApostaExtraUsuarioIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.ApostaExtraUsuarioApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IApostaPontosService>().To<WebApi.Integration.Boloes.ApostaPontosIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.ApostaPontosApp))
                .WithConstructorArgument("url", url);
            //Bind<Domain.Interfaces.Services.Boloes.IApostasRestantesUserService>().To<WebApi.Integration.Boloes.ApostasRestantesUserService>();
            Bind<Domain.Interfaces.Services.Boloes.IBolaoService>().To<WebApi.Integration.Boloes.BolaoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService>().To<WebApi.Integration.Boloes.BolaoCampeonatoClassificacaoUsuarioIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoCampeonatoClassificacaoUsuarioApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService>().To<WebApi.Integration.Boloes.BolaoCriterioPontosIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoCriterioPontosApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService>().To<WebApi.Integration.Boloes.BolaoCriterioPontosTimesIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoCriterioPontosTimesApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoMembroService>().To<WebApi.Integration.Boloes.BolaoMembroIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoMembroApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService>().To<WebApi.Integration.Boloes.BolaoMembroClassificacaoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoMembroClassificacaoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService>().To<WebApi.Integration.Boloes.BolaoMembroGrupoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoMembroGrupoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService>().To<WebApi.Integration.Boloes.BolaoPontoRodadaIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoPontoRodadaApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService>().To<WebApi.Integration.Boloes.BolaoPontoRodadaUsuarioIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoPontoRodadaUsuarioApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService>().To<WebApi.Integration.Boloes.BolaoPontuacaoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoPontuacaoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoPremioService>().To<WebApi.Integration.Boloes.BolaoPremioIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoPremioApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoRegraService>().To<WebApi.Integration.Boloes.BolaoRegraIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoRegraApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoRequestService>().To<WebApi.Integration.Boloes.BolaoRequestIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoRequestApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService>().To<WebApi.Integration.Boloes.BolaoRequestStatusIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.BolaoRequestStatusApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.ICriterioService>().To<WebApi.Integration.Boloes.CriterioIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.CriterioApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IJogoUsuarioService>().To<WebApi.Integration.Boloes.JogoUsuarioIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.JogoUsuarioApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IMensagemService>().To<WebApi.Integration.Boloes.MensagemIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.MensagemApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IPagamentoService>().To<WebApi.Integration.Boloes.PagamentoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.PagamentoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Boloes.IPontuacaoService>().To<WebApi.Integration.Boloes.PontuacaoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Boloes.PontuacaoApp))
                .WithConstructorArgument("url", url);

            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoService>().To<WebApi.Integration.Campeonatos.CampeonatoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Campeonatos.CampeonatoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService>().To<WebApi.Integration.Campeonatos.CampeonatoClassificacaoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Campeonatos.CampeonatoClassificacaoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService>().To<WebApi.Integration.Campeonatos.CampeonatoFaseIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Campeonatos.CampeonatoFaseApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService>().To<WebApi.Integration.Campeonatos.CampeonatoGrupoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Campeonatos.CampeonatoGrupoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService>().To<WebApi.Integration.Campeonatos.CampeonatoGrupoTimeIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Campeonatos.CampeonatoGrupoTimeApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService>().To<WebApi.Integration.Campeonatos.CampeonatoHistoricoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Campeonatos.CampeonatoHistoricoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService>().To<WebApi.Integration.Campeonatos.CampeonatoPosicaoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Campeonatos.CampeonatoPosicaoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService>().To<WebApi.Integration.Campeonatos.CampeonatoRecordIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Campeonatos.CampeonatoRecordApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService>().To<WebApi.Integration.Campeonatos.CampeonatoTimeIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Campeonatos.CampeonatoTimeApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Campeonatos.IHistoricoService>().To<WebApi.Integration.Campeonatos.HistoricoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Campeonatos.HistoricoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Campeonatos.IJogoService>().To<WebApi.Integration.Campeonatos.JogoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Campeonatos.JogoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Campeonatos.IPontuacaoService>().To<WebApi.Integration.Campeonatos.PontuacaoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Campeonatos.PontuacaoApp))
                .WithConstructorArgument("url", url);

            Bind<Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService>().To<WebApi.Integration.DadosBasicos.CriterioFixoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.DadosBasicos.CriterioFixoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.DadosBasicos.IEstadioService>().To<WebApi.Integration.DadosBasicos.EstadioIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.DadosBasicos.EstadioApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService>().To<WebApi.Integration.DadosBasicos.PagamentoTipoIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.DadosBasicos.PagamentoTipoApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.DadosBasicos.ITimeService>().To<WebApi.Integration.DadosBasicos.TimeIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.DadosBasicos.TimeApp))
                .WithConstructorArgument("url", url);

            Bind<Domain.Interfaces.Services.Users.IUserService>().To<WebApi.Integration.Users.UserIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Users.UserApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Users.IRoleService>().To<WebApi.Integration.Users.RoleIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Users.RoleApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Users.IUserInRoleService>().To<WebApi.Integration.Users.UserInRoleIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Users.UserInRoleApp))
                .WithConstructorArgument("url", url);


            Bind<Domain.Interfaces.Services.Facade.IUserFacadeService>().To<WebApi.Integration.Facade.UserFacadeIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Facade.UserFacadeApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Facade.Campeonatos.IStructureCopaMundoFacadeService>().To<WebApi.Integration.Facade.Campeonatos.StructureCopaMundoFacadeIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Facade.Campeonatos.StructureCopaMundoFacadeApp))
                .WithConstructorArgument("url", url);
            Bind<Domain.Interfaces.Services.Facade.Campeonatos.ICopaMundo2014FacadeService>().To<WebApi.Integration.Facade.Campeonatos.CopaMundo2014FacadeIntegration>()
                .WhenInjectedExactlyInto(typeof(Application.Facade.Campeonatos.CopaMundo2014FacadeApp))
                .WithConstructorArgument("url", url);

        }

        #endregion
    }
}
