using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.CrossCutting.IoC.Modules
{
    public class ServiceNinjectModule : NinjectModule
    {
        #region Methods

        public override void Load()
        {
            string userName = "";

            Bind<Domain.Interfaces.Services.Logging.ILogging>().To<Infra.CrossCutting.Logging.Logger>();

            Bind(typeof(Domain.Interfaces.Services.Base.IGenericService<>)).To(typeof(Domain.Services.Base.BaseGenericService<>)).WithConstructorArgument("userName", userName);


            Bind<Domain.Interfaces.Services.Facade.IInitializationFacadeService>().To<Domain.Services.Facade.InitializationFacadeService>().WithConstructorArgument("userName", userName);

            Bind<Domain.Interfaces.Services.Testes.ITesteService>().To<Domain.Services.Testes.TestesService>().WithConstructorArgument("userName", userName);

            Bind<Domain.Interfaces.Services.Boloes.IBolaoHistoricoService>().To<Domain.Services.Boloes.BolaoHistoricoService>().WithConstructorArgument("userName", userName);
            

            Bind<Domain.Interfaces.Services.Boloes.IApostaExtraService>().To<Domain.Services.Boloes.ApostaExtraService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService>().To<Domain.Services.Boloes.ApostaExtraUsuarioService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IApostaPontosService>().To<Domain.Services.Boloes.ApostaPontosService>().WithConstructorArgument("userName", userName);
            //Bind<Domain.Interfaces.Services.Boloes.IApostasRestantesUserService>().To<Domain.Services.Boloes.ApostasRestantesUserService>();
            Bind<Domain.Interfaces.Services.Boloes.IBolaoService>().To<Domain.Services.Boloes.BolaoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService>().To<Domain.Services.Boloes.BolaoCampeonatoClassificacaoUsuarioService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosService>().To<Domain.Services.Boloes.BolaoCriterioPontosService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService>().To<Domain.Services.Boloes.BolaoCriterioPontosTimesService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoMembroService>().To<Domain.Services.Boloes.BolaoMembroService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoMembroClassificacaoService>().To<Domain.Services.Boloes.BolaoMembroClassificacaoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService>().To<Domain.Services.Boloes.BolaoMembroGrupoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaService>().To<Domain.Services.Boloes.BolaoPontoRodadaService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService>().To<Domain.Services.Boloes.BolaoPontoRodadaUsuarioService>();
            Bind<Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService>().To<Domain.Services.Boloes.BolaoPontuacaoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoPremioService>().To<Domain.Services.Boloes.BolaoPremioService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoRegraService>().To<Domain.Services.Boloes.BolaoRegraService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoRequestService>().To<Domain.Services.Boloes.BolaoRequestService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IBolaoRequestStatusService>().To<Domain.Services.Boloes.BolaoRequestStatusService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.ICriterioService>().To<Domain.Services.Boloes.CriterioService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IJogoUsuarioService>().To<Domain.Services.Boloes.JogoUsuarioService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IMensagemService>().To<Domain.Services.Boloes.MensagemService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IPagamentoService>().To<Domain.Services.Boloes.PagamentoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Boloes.IPontuacaoService>().To<Domain.Services.Boloes.PontuacaoService>().WithConstructorArgument("userName", userName);

            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoService>().To<Domain.Services.Campeonatos.CampeonatoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService>().To<Domain.Services.Campeonatos.CampeonatoClassificacaoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoFaseService>().To<Domain.Services.Campeonatos.CampeonatoFaseService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoService>().To<Domain.Services.Campeonatos.CampeonatoGrupoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService>().To<Domain.Services.Campeonatos.CampeonatoGrupoTimeService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoHistoricoService>().To<Domain.Services.Campeonatos.CampeonatoHistoricoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoPosicaoService>().To<Domain.Services.Campeonatos.CampeonatoPosicaoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoRecordService>().To<Domain.Services.Campeonatos.CampeonatoRecordService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Campeonatos.ICampeonatoTimeService>().To<Domain.Services.Campeonatos.CampeonatoTimeService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Campeonatos.IHistoricoService>().To<Domain.Services.Campeonatos.HistoricoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Campeonatos.IJogoService>().To<Domain.Services.Campeonatos.JogoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Campeonatos.IPontuacaoService>().To<Domain.Services.Campeonatos.PontuacaoService>().WithConstructorArgument("userName", userName);

            Bind<Domain.Interfaces.Services.DadosBasicos.ICriterioFixoService>().To<Domain.Services.DadosBasicos.CriterioFixoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.DadosBasicos.IEstadioService>().To<Domain.Services.DadosBasicos.EstadioService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.DadosBasicos.IPagamentoTipoService>().To<Domain.Services.DadosBasicos.PagamentoTipoService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.DadosBasicos.ITimeService>().To<Domain.Services.DadosBasicos.TimeService>().WithConstructorArgument("userName", userName);

            Bind<Domain.Interfaces.Services.Users.IUserService>().To<Domain.Services.Users.UserService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Users.IRoleService>().To<Domain.Services.Users.RoleService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Users.IUserInRoleService>().To<Domain.Services.Users.UserInRoleService>().WithConstructorArgument("userName", userName);


            Bind<Domain.Interfaces.Services.Facade.IUserFacadeService>().To<Domain.Services.Facade.UserFacadeService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Facade.Campeonatos.IStructureCopaMundoFacadeService>().To<Domain.Services.Facade.Campeonatos.StructureCopaMundoFacadeService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Facade.Campeonatos.ICopaMundo2014FacadeService>().To<Domain.Services.Facade.Campeonatos.CopaMundo2014FacadeService>().WithConstructorArgument("userName", userName);

            Bind<Domain.Interfaces.Services.Reports.IBolaoMembroApostasReportService>().To<Domain.Services.Reports.BolaoMembroApostasReportService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Reports.IBolaoApostasInicioReportService>().To<Domain.Services.Reports.BolaoApostasInicioReportService>().WithConstructorArgument("userName", userName);
            Bind<Domain.Interfaces.Services.Reports.IBolaoApostasFimReportService>().To<Domain.Services.Reports.BolaoApostasFimReportService>().WithConstructorArgument("userName", userName);

        }

        #endregion
    }
}
