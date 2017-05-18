using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration.Base
{
    public class FactoryRestIntegration : Business.Interfaces.IFactoryBO
    {
        #region Variables

        /// <summary>
        /// Variável que armazena a url usada para requisições via REST.
        /// </summary>
        private static string _url;

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="FactoryRestIntegration" />.
        /// </summary>
        public FactoryRestIntegration()
        {

        }
        /// <summary>
        /// Inicializa nova instância da classe <see cref="FactoryRestIntegration" />.
        /// </summary>
        /// <param name="url">Url de conexão.</param>
        public FactoryRestIntegration(string url)
        {
            _url = url;
        }

        #endregion

        #region Methods


        /// <summary>
        /// Método que carrega a url para realização das chamadas de integração.
        /// </summary>
        /// <returns>Url configurada.</returns>
        protected static string GetUrl()
        {
            //Se não existe url carregada
            if (string.IsNullOrEmpty(_url))
            {
                string url = System.Configuration.ConfigurationManager.AppSettings["UrlIntegration"];

                if (!string.IsNullOrEmpty(url))
                {
                    _url = System.Configuration.ConfigurationManager.AppSettings["UrlIntegration"];
                }
                else
                {
                    _url = "http://localhost:1230/";
                }
            }//endif url null

            return _url;

        }

        #endregion

        #region IFactoryBO members

        //public Business.Interfaces.IJogadorBO CreateJogador()
        //{
        //    return new JogadorIntegration(GetUrl());
        //}

        //public Business.Interfaces.IModalidadeBO CreateModalidade()
        //{
        //    return new ModalidadeIntegration(GetUrl());
        //}


        public Business.Interfaces.Boloes.IApostaExtraBO CreateApostaExtraBO()
        {
            throw new Exception();
        }

        public Business.Interfaces.Boloes.IApostaExtraUsuarioBO CreateApostaExtraUsuarioBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IApostaPontosBO CreateApostaPontosBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IApostasRestantesBO CreateApostasRestantesBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoBO CreateBolaoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioBO CreateBolaoCampeonatoClassificacaoUsuarioBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoCriterioPontosBO CreateBolaoCriterioPontosBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoCriterioPontosTimesBO CreateBolaoCriterioPontosTimesBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoMembroBO CreateBolaoMembroBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoMembroClassificacaoBO CreateBolaoMembroClassificacaoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoMembroGrupoBO CreateBolaoMembroGrupoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoPontoRodadaBO CreateBolaoPontoRodadaBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoPontoRodadaUsuarioBO CreateBolaoPontoRodadaUsuarioBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoPontuacaoBO CreateBolaoPontuacaoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoPremioBO CreateBolaoPremioBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoRegraBO CreateBolaoRegraBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoRequestBO CreateBolaoRequestBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IBolaoRequestStatusBO CreateBolaoRequestStatusBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.ICriterioBO CreateCriterioBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IJogoUsuarioBO CreateJogoUsuarioBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IMensagemBO CreateMensagemBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IPagamentoBO CreatePagamentoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Boloes.IPontuacaoBO CreatePontuacaoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoBO CreateCampeonatoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoClassificacaoBO CreateCampeonatoClassificacaoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoFaseBO CreateCampeonatoFaseBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoGrupoBO CreateCampeonatoGrupoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoGrupoTimeBO CreateCampeonatoGrupoTimeBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoHistoricoBO CreateCampeonatoHistoricoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoPosicaoBO CreateCampeonatoPosicaoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoRecordBO CreateCampeonatoRecordBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoTimeBO CreateCampeonatoTimeBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.IFaseBO CreateFaseBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.IGrupoBO CreateGrupoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.IHistoricoBO CreateHistoricoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.IJogoBO CreateJogoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Campeonatos.IPontuacaoBO CreateCampeonatoPontuacaoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.DadosBasicos.ICriterioFixoBO CreateCriterioFixoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.DadosBasicos.IEstadioBO CreateEstadioBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.DadosBasicos.IPagamentoTipoBO CreatePagamentoTipoBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.DadosBasicos.ITimeBO CreateTimeBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Users.IRoleBO CreateRoleBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Users.IUserBO CreateUserBO()
        {
            throw new NotImplementedException();
        }

        public Business.Interfaces.Users.IUserInRoleBO CreateUserInRoleBO()
        {
            throw new NotImplementedException();
        }

        #endregion


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
    }
}
