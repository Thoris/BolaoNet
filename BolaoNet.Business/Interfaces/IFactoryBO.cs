using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Interfaces
{
    public interface IFactoryBO
    {
        Boloes.IApostaExtraBO CreateApostaExtraBO();
        Boloes.IApostaExtraUsuarioBO CreateApostaExtraUsuarioBO();
        Boloes.IApostaPontosBO CreateApostaPontosBO();
        Boloes.IApostasRestantesBO CreateApostasRestantesBO();
        Boloes.IBolaoBO CreateBolaoBO();
        Boloes.IBolaoCampeonatoClassificacaoUsuarioBO CreateBolaoCampeonatoClassificacaoUsuarioBO();
        Boloes.IBolaoCriterioPontosBO CreateBolaoCriterioPontosBO();
        Boloes.IBolaoCriterioPontosTimesBO CreateBolaoCriterioPontosTimesBO();
        Boloes.IBolaoMembroBO CreateBolaoMembroBO();
        Boloes.IBolaoMembroClassificacaoBO CreateBolaoMembroClassificacaoBO();
        Boloes.IBolaoMembroGrupoBO CreateBolaoMembroGrupoBO();
        Boloes.IBolaoMembroGrupoPontoBO CreateBolaoMembroGrupoPontoBO();
        Boloes.IBolaoPontoRodadaBO CreateBolaoPontoRodadaBO();
        Boloes.IBolaoPontoRodadaUsuarioBO CreateBolaoPontoRodadaUsuarioBO();
        Boloes.IBolaoPontuacaoBO CreateBolaoPontuacaoBO();
        Boloes.IBolaoPremioBO CreateBolaoPremioBO();
        Boloes.IBolaoRegraBO CreateBolaoRegraBO();
        Boloes.IBolaoRequestBO CreateBolaoRequestBO();
        Boloes.IBolaoRequestStatusBO CreateBolaoRequestStatusBO();
        Boloes.ICriterioBO CreateCriterioBO();
        Boloes.IJogoUsuarioBO CreateJogoUsuarioBO();
        Boloes.IMensagemBO CreateMensagemBO();
        Boloes.IPagamentoBO CreatePagamentoBO();
        Boloes.IPontuacaoBO CreatePontuacaoBO();

        Campeonatos.ICampeonatoBO CreateCampeonatoBO();
        Campeonatos.ICampeonatoClassificacaoBO CreateCampeonatoClassificacaoBO();
        Campeonatos.ICampeonatoFaseBO CreateCampeonatoFaseBO();
        Campeonatos.ICampeonatoGrupoBO CreateCampeonatoGrupoBO();
        Campeonatos.ICampeonatoGrupoTimeBO CreateCampeonatoGrupoTimeBO();
        Campeonatos.ICampeonatoHistoricoBO CreateCampeonatoHistoricoBO();
        Campeonatos.ICampeonatoPosicaoBO CreateCampeonatoPosicaoBO();
        Campeonatos.ICampeonatoRecordBO CreateCampeonatoRecordBO();
        Campeonatos.ICampeonatoTimeBO CreateCampeonatoTimeBO();
        Campeonatos.IFaseBO CreateFaseBO();
        Campeonatos.IGrupoBO CreateGrupoBO();
        Campeonatos.IHistoricoBO CreateHistoricoBO();
        Campeonatos.IJogoBO CreateJogoBO();
        Campeonatos.IPontuacaoBO CreateCampeonatoPontuacaoBO();

        DadosBasicos.ICriterioFixoBO CreateCriterioFixoBO();
        DadosBasicos.IEstadioBO CreateEstadioBO();
        DadosBasicos.IPagamentoTipoBO CreatePagamentoTipoBO();
        DadosBasicos.ITimeBO CreateTimeBO();

        Users.IRoleBO CreateRoleBO();
        Users.IUserBO CreateUserBO();
        Users.IUserInRoleBO CreateUserInRoleBO();

        Interfaces.Facade.IBolaoFacadeBO CreateBolaoFacadeBO();
        Interfaces.Facade.ICampeonatoFacadeBO CreateCampeonatoFacadeBO();
        Interfaces.Facade.IInitializationFacadeBO CreateInitializationFacadeBO();
        Interfaces.Facade.IUserFacadeBO CreateUserFacadeBO();

    }
}
