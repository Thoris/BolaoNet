using BolaoNet.Infra.Data.EF.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF
{
    /// <summary>
    /// Classe que trabalha com a fábrica de criação de objetos para acesso à dados.
    /// </summary>
    public class FactoryDaoEF : Domain.Interfaces.Repositories.IFactoryDao
    {
        #region Variables

        /// <summary>
        /// Variável que gerencia o banco de dados através do padrão de projeto UnitOfWork.
        /// </summary>
        private static IUnitOfWork _unitOfWork;

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="FactoryDaoEF"/>.
        /// </summary>
        public FactoryDaoEF()
        {

        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que cria o objeto de conexão unit of work.
        /// </summary>
        /// <returns>Objeto de conexão no padrão unit of work.</returns>
        public IUnitOfWork CreateUnitOfWork()
        {
            //Se ainda não foi criado o objeto de conexão.
            if (FactoryDaoEF._unitOfWork == null)
            {
                FactoryDaoEF._unitOfWork = new UnitOfWork();
            }

            return FactoryDaoEF._unitOfWork;
        }


        #endregion

        #region IFactoryDao members
        
        public Domain.Interfaces.Repositories.Boloes.IApostaExtraDao CreateApostaExtraDao()
        {            
            return new EF.Boloes.ApostaExtraRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IApostaExtraUsuarioDao CreateApostaExtraUsuarioDao()
        {
            return new EF.Boloes.ApostaExtraUsuarioRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IApostaPontosDao CreateApostaPontosDao()
        {
            return new EF.Boloes.ApostaPontosRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IApostasRestantesUserDao CreateApostasRestantesDao()
        {
            return new EF.Boloes.ApostasRestantesUserRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoDao CreateBolaoDao()
        {
            return new EF.Boloes.BolaoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoCampeonatoClassificacaoUsuarioDao CreateBolaoCampeonatoClassificacaoUsuarioDao()
        {
            return new EF.Boloes.BolaoCampeonatoClassificacaoUsuarioRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoCriterioPontosDao CreateBolaoCriterioPontosDao()
        {
            return new EF.Boloes.BolaoCriterioPontosRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoCriterioPontosTimesDao CreateBolaoCriterioPontosTimesDao()
        {
            return new EF.Boloes.BolaoCriterioPontosTimesRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoMembroDao CreateBolaoMembroDao()
        {
            return new EF.Boloes.BolaoMembroRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoMembroClassificacaoDao CreateBolaoMembroClassificacaoDao()
        {
            return new EF.Boloes.BolaoMembroClassificacaoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoMembroGrupoDao CreateBolaoMembroGrupoDao()
        {
            return new EF.Boloes.BolaoMembroGrupoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoPontoRodadaDao CreateBolaoPontoRodadaDao()
        {
            return new EF.Boloes.BolaoPontoRodadaRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoPontoRodadaUsuarioDao CreateBolaoPontoRodadaUsuarioDao()
        {
            return new EF.Boloes.BolaoPontoRodadaUsuarioRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoPontuacaoDao CreateBolaoPontuacaoDao()
        {
            return new EF.Boloes.BolaoPontuacaoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoPremioDao CreateBolaoPremioDao()
        {
            return new EF.Boloes.BolaoPremioRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoRegraDao CreateBolaoRegraDao()
        {
            return new EF.Boloes.BolaoRegraRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoRequestDao CreateBolaoRequestDao()
        {
            return new EF.Boloes.BolaoRequestRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IBolaoRequestStatusDao CreateBolaoRequestStatusDao()
        {
            return new EF.Boloes.BolaoRequestStatusRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.ICriterioDao CreateCriterioDao()
        {
            return new EF.Boloes.CriterioRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IJogoUsuarioDao CreateJogoUsuarioDao()
        {
            return new EF.Boloes.JogoUsuarioRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IMensagemDao CreateMensagemDao()
        {
            return new EF.Boloes.MensagemRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IPagamentoDao CreatePagamentoDao()
        {
            return new EF.Boloes.PagamentoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Boloes.IPontuacaoDao CreatePontuacaoDao()
        {
            return new EF.Boloes.PontuacaoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Campeonatos.ICampeonatoClassificacaoDao CreateCampeonatoClassificacaoDao()
        {
            return new EF.Campeonatos.CampeonatoClassificacaoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Campeonatos.ICampeonatoFaseDao CreateCampeonatoFaseDao()
        {
            return new EF.Campeonatos.CampeonatoFaseRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Campeonatos.ICampeonatoGrupoDao CreateCampeonatoGrupoDao()
        {
            return new EF.Campeonatos.CampeonatoGrupoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Campeonatos.ICampeonatoGrupoTimeDao CreateCampeonatoGrupoTimeDao()
        {
            return new EF.Campeonatos.CampeonatoGrupoTimeRepositoryDao(CreateUnitOfWork());            
        }

        public Domain.Interfaces.Repositories.Campeonatos.ICampeonatoHistoricoDao CreateCampeonatoHistoricoDao()
        {
            return new EF.Campeonatos.CampeonatoHistoricoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Campeonatos.ICampeonatoPosicaoDao CreateCampeonatoPosicaoDao()
        {
            return new EF.Campeonatos.CampeonatoPosicaoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Campeonatos.ICampeonatoRecordDao CreateCampeonatoRecordDao()
        {
            return new EF.Campeonatos.CampeonatoRecordRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Campeonatos.ICampeonatoTimeDao CreateCampeonatoTimeDao()
        {
            return new EF.Campeonatos.CampeonatoTimeRepositoryDao(CreateUnitOfWork());
        }
             
        public Domain.Interfaces.Repositories.Campeonatos.IHistoricoDao CreateHistoricoDao()
        {
            return new EF.Campeonatos.HistoricoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Campeonatos.IJogoDao CreateJogoDao()
        {
            return new EF.Campeonatos.JogoRepositoryDao(CreateUnitOfWork());
        }


        public Domain.Interfaces.Repositories.DadosBasicos.ICriterioFixoDao CreateCriterioFixoDao()
        {
            return new EF.DadosBasicos.CriterioFixoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.DadosBasicos.IEstadioDao CreateEstadioDao()
        {
            return new EF.DadosBasicos.EstadioRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.DadosBasicos.IPagamentoTipoDao CreatePagamentoTipoDao()
        {
            return new EF.DadosBasicos.PagamentoTipoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.DadosBasicos.ITimeDao CreateTimeDao()
        {
            return new EF.DadosBasicos.TimeRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Users.IRoleDao CreateRoleDao()
        {
            return new EF.Users.RoleRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Users.IUserDao CreateUserDao()
        {
            return new EF.Users.UserRespositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Users.IUserInRoleDao CreateUserInRoleDao()
        {
            return new EF.Users.UserInRoleRepositoryDao(CreateUnitOfWork());
        }


        public Domain.Interfaces.Repositories.Campeonatos.ICampeonatoDao CreateCampeonatoDao()
        {
            return new EF.Campeonatos.CampeonatoRepositoryDao(CreateUnitOfWork());
        }

        public Domain.Interfaces.Repositories.Campeonatos.IPontuacaoDao CreateCampeonatoPontuacaoDao()
        {
            return new EF.Campeonatos.PontuacaoRepositoryDao(CreateUnitOfWork());
        }

        #endregion

    }
}
