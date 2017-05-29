using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration
{
    public class RestFullFactoryIntegration : Business.Interfaces.IFactoryBO
    {
        #region Variables

        private string _userName;
        private string _url;

        #endregion

        #region Constructors/Destructors

        public RestFullFactoryIntegration(string userName, string url)
        {
            _userName = userName;
            _url = url;
        }

        #endregion

        #region IFactoryBO members

        public Business.Interfaces.Boloes.IApostaExtraBO CreateApostaExtraBO()
        {
            return new Boloes.ApostaExtraIntegration(_url);
        }

        public Business.Interfaces.Boloes.IApostaExtraUsuarioBO CreateApostaExtraUsuarioBO()
        {
            return new Boloes.ApostaExtraUsuarioIntegration(_url);
        }

        public Business.Interfaces.Boloes.IApostaPontosBO CreateApostaPontosBO()
        {
            return new Boloes.ApostaPontosIntegration(_url);
        }

        public Business.Interfaces.Boloes.IApostasRestantesBO CreateApostasRestantesBO()
        {
            return new Boloes.ApostasRestantesIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoBO CreateBolaoBO()
        {
            return new Boloes.BolaoIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioBO CreateBolaoCampeonatoClassificacaoUsuarioBO()
        {
            return new Boloes.BolaoCampeonatoClassificacaoUsuarioIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoCriterioPontosBO CreateBolaoCriterioPontosBO()
        {
            return new Boloes.BolaoCriterioPontosIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoCriterioPontosTimesBO CreateBolaoCriterioPontosTimesBO()
        {
            return new Boloes.BolaoCriterioPontosTimesIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoMembroBO CreateBolaoMembroBO()
        {
            return new Boloes.BolaoMembroIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoMembroClassificacaoBO CreateBolaoMembroClassificacaoBO()
        {
            return new Boloes.BolaoMembroClassificacaoIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoMembroGrupoBO CreateBolaoMembroGrupoBO()
        {
            return new Boloes.BolaoMembroGrupoIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoPontoRodadaBO CreateBolaoPontoRodadaBO()
        {
            return new Boloes.BolaoPontoRodadaIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoPontoRodadaUsuarioBO CreateBolaoPontoRodadaUsuarioBO()
        {
            return new Boloes.BolaoPontoRodadaUsuarioIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoPontuacaoBO CreateBolaoPontuacaoBO()
        {
            return new Boloes.BolaoPontuacaoIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoPremioBO CreateBolaoPremioBO()
        {
            return new Boloes.BolaoPremioIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoRegraBO CreateBolaoRegraBO()
        {
            return new Boloes.BolaoRegraIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoRequestBO CreateBolaoRequestBO()
        {
            return new Boloes.BolaoRequestIntegration(_url);
        }

        public Business.Interfaces.Boloes.IBolaoRequestStatusBO CreateBolaoRequestStatusBO()
        {
            return new Boloes.BolaoRequestStatusIntegration(_url);
        }

        public Business.Interfaces.Boloes.ICriterioBO CreateCriterioBO()
        {
            return new Boloes.CriterioIntegration(_url);
        }

        public Business.Interfaces.Boloes.IJogoUsuarioBO CreateJogoUsuarioBO()
        {
            return new Boloes.JogoUsuarioIntegration(_url);
        }

        public Business.Interfaces.Boloes.IMensagemBO CreateMensagemBO()
        {
            return new Boloes.MensagemIntegration(_url);
        }

        public Business.Interfaces.Boloes.IPagamentoBO CreatePagamentoBO()
        {
            return new Boloes.PagamentoIntegration(_url);
        }

        public Business.Interfaces.Boloes.IPontuacaoBO CreatePontuacaoBO()
        {
            return new Boloes.PontuacaoIntegration(_url);
        }

        public Business.Interfaces.Campeonatos.ICampeonatoBO CreateCampeonatoBO()
        {
            return new Campeonatos.CampeonatoIntegration(_url);
        }

        public Business.Interfaces.Campeonatos.ICampeonatoClassificacaoBO CreateCampeonatoClassificacaoBO()
        {
            return new Campeonatos.CampeonatoClassificacaoIntegration(_url);
        }

        public Business.Interfaces.Campeonatos.ICampeonatoFaseBO CreateCampeonatoFaseBO()
        {
            return new Campeonatos.CampeonatoFaseIntegration(_url);
        }

        public Business.Interfaces.Campeonatos.ICampeonatoGrupoBO CreateCampeonatoGrupoBO()
        {
            return new Campeonatos.CampeonatoGrupoIntegration(_url);
        }

        public Business.Interfaces.Campeonatos.ICampeonatoGrupoTimeBO CreateCampeonatoGrupoTimeBO()
        {
            return new Campeonatos.CampeonatoGrupoTimeIntegration(_url);
        }

        public Business.Interfaces.Campeonatos.ICampeonatoHistoricoBO CreateCampeonatoHistoricoBO()
        {
            return new Campeonatos.CampeonatoHistoricoIntegration(_url);
        }

        public Business.Interfaces.Campeonatos.ICampeonatoPosicaoBO CreateCampeonatoPosicaoBO()
        {
            return new Campeonatos.CampeonatoPosicaoIntegration(_url);
        }

        public Business.Interfaces.Campeonatos.ICampeonatoRecordBO CreateCampeonatoRecordBO()
        {
            return new Campeonatos.CampeonatoRecordIntegration(_url);
        }

        public Business.Interfaces.Campeonatos.ICampeonatoTimeBO CreateCampeonatoTimeBO()
        {
            return new Campeonatos.CampeonatoTimeIntegration(_url);
        }

        public Business.Interfaces.Campeonatos.IHistoricoBO CreateHistoricoBO()
        {
            return new Campeonatos.HistoricoIntegration(_url);
        }

        public Business.Interfaces.Campeonatos.IJogoBO CreateJogoBO()
        {
            return new Campeonatos.JogoIntegration(_url);
        }

        public Business.Interfaces.Campeonatos.IPontuacaoBO CreateCampeonatoPontuacaoBO()
        {
            return new Campeonatos.PontuacaoIntegration(_url);
        }

        public Business.Interfaces.DadosBasicos.ICriterioFixoBO CreateCriterioFixoBO()
        {
            return new DadosBasicos.CriterioFixoIntegration(_url);
        }

        public Business.Interfaces.DadosBasicos.IEstadioBO CreateEstadioBO()
        {
            return new DadosBasicos.EstadioIntegration(_url);
        }

        public Business.Interfaces.DadosBasicos.IPagamentoTipoBO CreatePagamentoTipoBO()
        {
            return new DadosBasicos.PagamentoTipoIntegration(_url);
        }

        public Business.Interfaces.DadosBasicos.ITimeBO CreateTimeBO()
        {
            return new DadosBasicos.TimeIntegration(_url);
        }

        public Business.Interfaces.Users.IRoleBO CreateRoleBO()
        {
            return new Users.RoleIntegration(_url);
        }

        public Business.Interfaces.Users.IUserBO CreateUserBO()
        {
            return new Users.UserIntegration(_url);
        }

        public Business.Interfaces.Users.IUserInRoleBO CreateUserInRoleBO()
        {
            return new Users.UserInRoleIntegration(_url);
        }

        public Business.Interfaces.Facade.IBolaoFacadeBO CreateBolaoFacadeBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Facade.ICampeonatoFacadeBO CreateCampeonatoFacadeBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Facade.IInitializationFacadeBO CreateInitializationFacadeBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Facade.IUserFacadeBO CreateUserFacadeBO()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
