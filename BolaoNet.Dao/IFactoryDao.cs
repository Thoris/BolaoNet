using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao
{
    /// <summary>
    /// Interface usada para definir a fabrica de objetos de acesso à banco de dados.
    /// </summary>
    public interface IFactoryDao
    {
        Boloes.IApostaExtraDao CreateApostaExtraDao();
        Boloes.IApostaExtraUsuarioDao CreateApostaExtraUsuarioDao();
        Boloes.IApostaPontosDao CreateApostaPontosDao();
        Boloes.IApostasRestantesUserDao CreateApostasRestantesDao();
        Boloes.IBolaoDao CreateBolaoDao();
        Boloes.IBolaoCampeonatoClassificacaoUsuarioDao CreateBolaoCampeonatoClassificacaoUsuarioDao();
        Boloes.IBolaoCriterioPontosDao CreateBolaoCriterioPontosDao();
        Boloes.IBolaoCriterioPontosTimesDao CreateBolaoCriterioPontosTimesDao();
        Boloes.IBolaoMembroDao CreateBolaoMembroDao();
        Boloes.IBolaoMembroClassificacaoDao CreateBolaoMembroClassificacaoDao();
        Boloes.IBolaoMembroGrupoDao CreateBolaoMembroGrupoDao();
        Boloes.IBolaoMembroGrupoPontoDao CreateBolaoMembroGrupoPontoDao();
        Boloes.IBolaoPontoRodadaDao CreateBolaoPontoRodadaDao();
        Boloes.IBolaoPontoRodadaUsuarioDao CreateBolaoPontoRodadaUsuarioDao();
        Boloes.IBolaoPontuacaoDao CreateBolaoPontuacaoDao();
        Boloes.IBolaoPremioDao CreateBolaoPremioDao();
        Boloes.IBolaoRegraDao CreateBolaoRegraDao();
        Boloes.IBolaoRequestDao CreateBolaoRequestDao();
        Boloes.IBolaoRequestStatusDao CreateBolaoRequestStatusDao();
        Boloes.ICriterioDao CreateCriterioDao();
        Boloes.IJogoUsuarioDao CreateJogoUsuarioDao();
        Boloes.IMensagemDao CreateMensagemDao();
        Boloes.IPagamentoDao CreatePagamentoDao();
        //Boloes.IPontuacaoDao CreatePontuacaoDao();

        Campeonatos.ICampeonatoDao CreateCampeonatoDao();
        Campeonatos.ICampeonatoClassificacaoDao CreateCampeonatoClassificacaoDao();
        Campeonatos.ICampeonatoFaseDao CreateCampeonatoFaseDao();
        Campeonatos.ICampeonatoGrupoDao CreateCampeonatoGrupoDao();
        Campeonatos.ICampeonatoGrupoTimeDao CreateCampeonatoGrupoTimeDao();
        Campeonatos.ICampeonatoHistoricoDao CreateCampeonatoHistoricoDao();
        Campeonatos.ICampeonatoPosicaoDao CreateCampeonatoPosicaoDao();
        Campeonatos.ICampeonatoRecordDao CreateCampeonatoRecordDao();
        Campeonatos.ICampeonatoTimeDao CreateCampeonatoTimeDao();
        Campeonatos.IFaseDao CreateFaseDao();
        Campeonatos.IGrupoDao CreateGrupoDao();
        Campeonatos.IHistoricoDao CreateHistoricoDao();
        Campeonatos.IJogoDao CreateJogoDao();
        Campeonatos.IPontuacaoDao CreateCampeonatoPontuacaoDao();

        DadosBasicos.ICriterioFixoDao CreateCriterioFixoDao();
        DadosBasicos.IEstadioDao CreateEstadioDao();
        DadosBasicos.IPagamentoTipoDao CreatePagamentoTipoDao();
        DadosBasicos.ITimeDao CreateTimeDao();

        Users.IRoleDao CreateRoleDao();
        Users.IUserDao CreateUserDao();
        Users.IUserInRoleDao CreateUserInRoleDao();
    }
}
