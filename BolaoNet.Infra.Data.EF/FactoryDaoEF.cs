using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF
{
    ///// <summary>
    ///// Classe que trabalha com a fábrica de criação de objetos para acesso à dados.
    ///// </summary>
    //public class FactoryDaoEF : Domain.Interfaces.Repositories.IFactoryDao
    //{
    //    #region Variables

    //    /// <summary>
    //    /// Variável que gerencia o banco de dados através do padrão de projeto UnitOfWork.
    //    /// </summary>
    //    private static IUnitOfWork _unitOfWork;

    //    #endregion

    //    #region Constructors/Destructors

    //    /// <summary>
    //    /// Inicializa nova instância da classe <see cref="FactoryDaoEF"/>.
    //    /// </summary>
    //    public FactoryDaoEF()
    //    {

    //    }

    //    #endregion

    //    #region Methods

    //    /// <summary>
    //    /// Método que cria o objeto de conexão unit of work.
    //    /// </summary>
    //    /// <returns>Objeto de conexão no padrão unit of work.</returns>
    //    public IUnitOfWork CreateUnitOfWork()
    //    {
    //        //Se ainda não foi criado o objeto de conexão.
    //        if (FactoryDaoEF._unitOfWork == null)
    //        {
    //            FactoryDaoEF._unitOfWork = new UnitOfWork();
    //        }

    //        return FactoryDaoEF._unitOfWork;
    //    }


    //    #endregion

    //    #region IFactoryDao members
        
    //    public Dao.Boloes.IApostaExtraDao CreateApostaExtraDao()
    //    {            
    //        return new Dao.EF.Boloes.ApostaExtraRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IApostaExtraUsuarioDao CreateApostaExtraUsuarioDao()
    //    {
    //        return new Dao.EF.Boloes.ApostaExtraUsuarioRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IApostaPontosDao CreateApostaPontosDao()
    //    {
    //        return new Dao.EF.Boloes.ApostaPontosRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IApostasRestantesUserDao CreateApostasRestantesDao()
    //    {
    //        return new Dao.EF.Boloes.ApostasRestantesUserRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoDao CreateBolaoDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoCampeonatoClassificacaoUsuarioDao CreateBolaoCampeonatoClassificacaoUsuarioDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoCampeonatoClassificacaoUsuarioRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoCriterioPontosDao CreateBolaoCriterioPontosDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoCriterioPontosRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoCriterioPontosTimesDao CreateBolaoCriterioPontosTimesDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoCriterioPontosTimesRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoMembroDao CreateBolaoMembroDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoMembroRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoMembroClassificacaoDao CreateBolaoMembroClassificacaoDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoMembroClassificacaoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoMembroGrupoDao CreateBolaoMembroGrupoDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoMembroGrupoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoPontoRodadaDao CreateBolaoPontoRodadaDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoPontoRodadaRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoPontoRodadaUsuarioDao CreateBolaoPontoRodadaUsuarioDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoPontoRodadaUsuarioRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoPontuacaoDao CreateBolaoPontuacaoDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoPontuacaoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoPremioDao CreateBolaoPremioDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoPremioRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoRegraDao CreateBolaoRegraDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoRegraRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoRequestDao CreateBolaoRequestDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoRequestRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IBolaoRequestStatusDao CreateBolaoRequestStatusDao()
    //    {
    //        return new Dao.EF.Boloes.BolaoRequestStatusRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.ICriterioDao CreateCriterioDao()
    //    {
    //        return new Dao.EF.Boloes.CriterioRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IJogoUsuarioDao CreateJogoUsuarioDao()
    //    {
    //        return new Dao.EF.Boloes.JogoUsuarioRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IMensagemDao CreateMensagemDao()
    //    {
    //        return new Dao.EF.Boloes.MensagemRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IPagamentoDao CreatePagamentoDao()
    //    {
    //        return new Dao.EF.Boloes.PagamentoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Boloes.IPontuacaoDao CreatePontuacaoDao()
    //    {
    //        return new Dao.EF.Boloes.PontuacaoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Campeonatos.ICampeonatoClassificacaoDao CreateCampeonatoClassificacaoDao()
    //    {
    //        return new Dao.EF.Campeonatos.CampeonatoClassificacaoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Campeonatos.ICampeonatoFaseDao CreateCampeonatoFaseDao()
    //    {
    //        return new Dao.EF.Campeonatos.CampeonatoFaseRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Campeonatos.ICampeonatoGrupoDao CreateCampeonatoGrupoDao()
    //    {
    //        return new Dao.EF.Campeonatos.CampeonatoGrupoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Campeonatos.ICampeonatoGrupoTimeDao CreateCampeonatoGrupoTimeDao()
    //    {
    //        return new Dao.EF.Campeonatos.CampeonatoGrupoTimeRepositoryDao(CreateUnitOfWork());            
    //    }

    //    public Dao.Campeonatos.ICampeonatoHistoricoDao CreateCampeonatoHistoricoDao()
    //    {
    //        return new Dao.EF.Campeonatos.CampeonatoHistoricoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Campeonatos.ICampeonatoPosicaoDao CreateCampeonatoPosicaoDao()
    //    {
    //        return new Dao.EF.Campeonatos.CampeonatoPosicaoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Campeonatos.ICampeonatoRecordDao CreateCampeonatoRecordDao()
    //    {
    //        return new Dao.EF.Campeonatos.CampeonatoRecordRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Campeonatos.ICampeonatoTimeDao CreateCampeonatoTimeDao()
    //    {
    //        return new Dao.EF.Campeonatos.CampeonatoTimeRepositoryDao(CreateUnitOfWork());
    //    }
             
    //    public Dao.Campeonatos.IHistoricoDao CreateHistoricoDao()
    //    {
    //        return new Dao.EF.Campeonatos.HistoricoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Campeonatos.IJogoDao CreateJogoDao()
    //    {
    //        return new Dao.EF.Campeonatos.JogoRepositoryDao(CreateUnitOfWork());
    //    }


    //    public Dao.DadosBasicos.ICriterioFixoDao CreateCriterioFixoDao()
    //    {
    //        return new Dao.EF.DadosBasicos.CriterioFixoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.DadosBasicos.IEstadioDao CreateEstadioDao()
    //    {
    //        return new Dao.EF.DadosBasicos.EstadioRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.DadosBasicos.IPagamentoTipoDao CreatePagamentoTipoDao()
    //    {
    //        return new Dao.EF.DadosBasicos.PagamentoTipoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.DadosBasicos.ITimeDao CreateTimeDao()
    //    {
    //        return new Dao.EF.DadosBasicos.TimeRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Users.IRoleDao CreateRoleDao()
    //    {
    //        return new Dao.EF.Users.RoleRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Users.IUserDao CreateUserDao()
    //    {
    //        return new Dao.EF.Users.UserRespositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Users.IUserInRoleDao CreateUserInRoleDao()
    //    {
    //        return new Dao.EF.Users.UserInRoleRepositoryDao(CreateUnitOfWork());
    //    }


    //    public Dao.Campeonatos.ICampeonatoDao CreateCampeonatoDao()
    //    {
    //        return new Dao.EF.Campeonatos.CampeonatoRepositoryDao(CreateUnitOfWork());
    //    }

    //    public Dao.Campeonatos.IPontuacaoDao CreateCampeonatoPontuacaoDao()
    //    {
    //        return new Dao.EF.Campeonatos.PontuacaoRepositoryDao(CreateUnitOfWork());
    //    }

    //    #endregion

    //}
}
