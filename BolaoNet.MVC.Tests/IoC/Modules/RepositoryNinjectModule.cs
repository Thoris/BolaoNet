using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.Tests.IoC.Modules
{
    public class RepositoryNinjectModule : NinjectModule
    {
        #region Methods

        public override void Load()
        {
            Bind<Infra.Data.EF.Base.IUnitOfWork>().To<Infra.Data.EF.UnitOfWork>();


            Bind(typeof(Domain.Interfaces.Repositories.Base.IGenericDao<>)).To(typeof(Infra.Data.EF.Base.BaseRepositoryDao<>));


            

            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoHistoricoDao>().To<Infra.Data.EF.Boloes.BolaoHistoricoRepositoryDao>();
            

            Bind<Domain.Interfaces.Repositories.Boloes.IApostaExtraDao>().To<Infra.Data.EF.Boloes.ApostaExtraRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IApostaExtraUsuarioDao>().To<Infra.Data.EF.Boloes.ApostaExtraUsuarioRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IApostaPontosDao>().To<Infra.Data.EF.Boloes.ApostaPontosRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IApostasRestantesUserDao>().To<Infra.Data.EF.Boloes.ApostasRestantesUserRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoDao>().To<Infra.Data.EF.Boloes.BolaoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoCampeonatoClassificacaoUsuarioDao>().To<Infra.Data.EF.Boloes.BolaoCampeonatoClassificacaoUsuarioRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoCriterioPontosDao>().To<Infra.Data.EF.Boloes.BolaoCriterioPontosRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoCriterioPontosTimesDao>().To<Infra.Data.EF.Boloes.BolaoCriterioPontosTimesRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoMembroDao>().To<Infra.Data.EF.Boloes.BolaoMembroRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoMembroClassificacaoDao>().To<Infra.Data.EF.Boloes.BolaoMembroClassificacaoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoMembroGrupoDao>().To<Infra.Data.EF.Boloes.BolaoMembroGrupoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoPontoRodadaDao>().To<Infra.Data.EF.Boloes.BolaoPontoRodadaRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoPontoRodadaUsuarioDao>().To<Infra.Data.EF.Boloes.BolaoPontoRodadaUsuarioRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoPontuacaoDao>().To<Infra.Data.EF.Boloes.BolaoPontuacaoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoPremioDao>().To<Infra.Data.EF.Boloes.BolaoPremioRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoRegraDao>().To<Infra.Data.EF.Boloes.BolaoRegraRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoRequestDao>().To<Infra.Data.EF.Boloes.BolaoRequestRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IBolaoRequestStatusDao>().To<Infra.Data.EF.Boloes.BolaoRequestStatusRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.ICriterioDao>().To<Infra.Data.EF.Boloes.CriterioRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IJogoUsuarioDao>().To<Infra.Data.EF.Boloes.JogoUsuarioRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IMensagemDao>().To<Infra.Data.EF.Boloes.MensagemRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IPagamentoDao>().To<Infra.Data.EF.Boloes.PagamentoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Boloes.IPontuacaoDao>().To<Infra.Data.EF.Boloes.PontuacaoRepositoryDao>();

            Bind<Domain.Interfaces.Repositories.Campeonatos.ICampeonatoDao>().To<Infra.Data.EF.Campeonatos.CampeonatoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Campeonatos.ICampeonatoClassificacaoDao>().To<Infra.Data.EF.Campeonatos.CampeonatoClassificacaoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Campeonatos.ICampeonatoFaseDao>().To<Infra.Data.EF.Campeonatos.CampeonatoFaseRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Campeonatos.ICampeonatoGrupoDao>().To<Infra.Data.EF.Campeonatos.CampeonatoGrupoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Campeonatos.ICampeonatoGrupoTimeDao>().To<Infra.Data.EF.Campeonatos.CampeonatoGrupoTimeRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Campeonatos.ICampeonatoHistoricoDao>().To<Infra.Data.EF.Campeonatos.CampeonatoHistoricoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Campeonatos.ICampeonatoPosicaoDao>().To<Infra.Data.EF.Campeonatos.CampeonatoPosicaoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Campeonatos.ICampeonatoRecordDao>().To<Infra.Data.EF.Campeonatos.CampeonatoRecordRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Campeonatos.ICampeonatoTimeDao>().To<Infra.Data.EF.Campeonatos.CampeonatoTimeRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Campeonatos.IHistoricoDao>().To<Infra.Data.EF.Campeonatos.HistoricoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Campeonatos.IJogoDao>().To<Infra.Data.EF.Campeonatos.JogoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Campeonatos.IPontuacaoDao>().To<Infra.Data.EF.Campeonatos.PontuacaoRepositoryDao>();

            Bind<Domain.Interfaces.Repositories.DadosBasicos.ICriterioFixoDao>().To<Infra.Data.EF.DadosBasicos.CriterioFixoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.DadosBasicos.IEstadioDao>().To<Infra.Data.EF.DadosBasicos.EstadioRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.DadosBasicos.IPagamentoTipoDao>().To<Infra.Data.EF.DadosBasicos.PagamentoTipoRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.DadosBasicos.ITimeDao>().To<Infra.Data.EF.DadosBasicos.TimeRepositoryDao>();

            Bind<Domain.Interfaces.Repositories.Users.IRoleDao>().To<Infra.Data.EF.Users.RoleRepositoryDao>();
            Bind<Domain.Interfaces.Repositories.Users.IUserDao>().To<Infra.Data.EF.Users.UserRespositoryDao>();
            Bind<Domain.Interfaces.Repositories.Users.IUserInRoleDao>().To<Infra.Data.EF.Users.UserInRoleRepositoryDao>();
        }

        #endregion
    }
}
