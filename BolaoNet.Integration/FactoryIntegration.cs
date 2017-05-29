using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Integration
{
    public class FactoryIntegration : Business.Interfaces.IFactoryBO
    {
        #region Variables


        private IntegrationType _integrationType;
        private Business.Interfaces.IFactoryBO _factoryBO;


        #endregion

        #region Constructors/Destructors

        public FactoryIntegration(string userName, string url)
        {
            _integrationType = GetDaoType();
            _factoryBO = GetFactoryIntegration(userName, url);
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que retorna o tipo de conexão que deve ser realizado para acesso à base de dados.
        /// </summary>
        /// <returns>Tipo de acesso à dados configurado. Caso não encontre, utiliza-se o padrão EntityFramework</returns>
        private IntegrationType GetDaoType()
        {
            //Buscando a configuração do tipo de acesso à dados
            string daoType = System.Configuration.ConfigurationManager.AppSettings["FactoryIntegrationType"];

            //Se existe informação configurada para o tipo de acesso
            if (!string.IsNullOrEmpty(daoType))
            {
                //Verificando qual tipo corresponde ao configurado
                string[] daoTypes = Enum.GetNames(typeof(IntegrationType));

                //Buscando qual tipo se encaixa
                for (int c = 0; c < daoTypes.Length; c++)
                {
                    //Se encontrou a descrição do tipo de conexão
                    if (string.Compare(daoType, daoTypes[c], true) == 0)
                    {
                        return (IntegrationType)c;
                    }
                    //Se encontrou o índice do tipo de conexão
                    else if (string.Compare(daoType, c.ToString(), true) == 0)
                    {
                        return (IntegrationType)c;
                    }//endif

                }//end for c

            }//endif tipo de conexão à dados

            return IntegrationType.Directly;
        }
        /// <summary>
        /// Método que retorna o objeto de fábrica de objetos para acesso à banco de dados.
        /// </summary>
        /// <returns>Objeto que possui a fábrica de objetos de conexão com o banco de dados.</returns>
        private Business.Interfaces.IFactoryBO GetFactoryIntegration(string userName, string url)
        {
            //Se o objeto de conexão ainda não foi criado
            if (_factoryBO == null)
            {
                //Buscando qual tipo de conexão com a base de dados deve utilizar
                _integrationType = GetDaoType();

                switch (_integrationType)
                {
                    case IntegrationType.Directly:

                        _factoryBO = new Business.FactoryBO(userName);

                        break;

                    case IntegrationType.RestFull:

                        _factoryBO = new RestFullFactoryIntegration(userName, url); 

                        break;

                }

            }//endif factoryDao == null

            return _factoryBO;
        }

        #endregion

        #region IFactoryBO members

        public Business.Interfaces.Boloes.IApostaExtraBO CreateApostaExtraBO()
        {
            return _factoryBO.CreateApostaExtraBO();
        }

        public Business.Interfaces.Boloes.IApostaExtraUsuarioBO CreateApostaExtraUsuarioBO()
        {
            return _factoryBO.CreateApostaExtraUsuarioBO();
        }

        public Business.Interfaces.Boloes.IApostaPontosBO CreateApostaPontosBO()
        {
            return _factoryBO.CreateApostaPontosBO();
        }

        public Business.Interfaces.Boloes.IApostasRestantesBO CreateApostasRestantesBO()
        {
            return _factoryBO.CreateApostasRestantesBO();
        }

        public Business.Interfaces.Boloes.IBolaoBO CreateBolaoBO()
        {
            return _factoryBO.CreateBolaoBO();
        }

        public Business.Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioBO CreateBolaoCampeonatoClassificacaoUsuarioBO()
        {
            return _factoryBO.CreateBolaoCampeonatoClassificacaoUsuarioBO();
        }

        public Business.Interfaces.Boloes.IBolaoCriterioPontosBO CreateBolaoCriterioPontosBO()
        {
            return _factoryBO.CreateBolaoCriterioPontosBO();
        }

        public Business.Interfaces.Boloes.IBolaoCriterioPontosTimesBO CreateBolaoCriterioPontosTimesBO()
        {
            return _factoryBO.CreateBolaoCriterioPontosTimesBO();
        }

        public Business.Interfaces.Boloes.IBolaoMembroBO CreateBolaoMembroBO()
        {
            return _factoryBO.CreateBolaoMembroBO();
        }

        public Business.Interfaces.Boloes.IBolaoMembroClassificacaoBO CreateBolaoMembroClassificacaoBO()
        {
            return _factoryBO.CreateBolaoMembroClassificacaoBO();
        }

        public Business.Interfaces.Boloes.IBolaoMembroGrupoBO CreateBolaoMembroGrupoBO()
        {
            return _factoryBO.CreateBolaoMembroGrupoBO();
        }

        public Business.Interfaces.Boloes.IBolaoPontoRodadaBO CreateBolaoPontoRodadaBO()
        {
            return _factoryBO.CreateBolaoPontoRodadaBO();
        }

        public Business.Interfaces.Boloes.IBolaoPontoRodadaUsuarioBO CreateBolaoPontoRodadaUsuarioBO()
        {
            return _factoryBO.CreateBolaoPontoRodadaUsuarioBO();
        }

        public Business.Interfaces.Boloes.IBolaoPontuacaoBO CreateBolaoPontuacaoBO()
        {
            return _factoryBO.CreateBolaoPontuacaoBO();
        }

        public Business.Interfaces.Boloes.IBolaoPremioBO CreateBolaoPremioBO()
        {
            return _factoryBO.CreateBolaoPremioBO();
        }

        public Business.Interfaces.Boloes.IBolaoRegraBO CreateBolaoRegraBO()
        {
            return _factoryBO.CreateBolaoRegraBO();
        }

        public Business.Interfaces.Boloes.IBolaoRequestBO CreateBolaoRequestBO()
        {
            return _factoryBO.CreateBolaoRequestBO();
        }

        public Business.Interfaces.Boloes.IBolaoRequestStatusBO CreateBolaoRequestStatusBO()
        {
            return _factoryBO.CreateBolaoRequestStatusBO();
        }

        public Business.Interfaces.Boloes.ICriterioBO CreateCriterioBO()
        {
            return _factoryBO.CreateCriterioBO();
        }

        public Business.Interfaces.Boloes.IJogoUsuarioBO CreateJogoUsuarioBO()
        {
            return _factoryBO.CreateJogoUsuarioBO();
        }

        public Business.Interfaces.Boloes.IMensagemBO CreateMensagemBO()
        {
            return _factoryBO.CreateMensagemBO();
        }

        public Business.Interfaces.Boloes.IPagamentoBO CreatePagamentoBO()
        {
            return _factoryBO.CreatePagamentoBO();
        }

        public Business.Interfaces.Boloes.IPontuacaoBO CreatePontuacaoBO()
        {
            return _factoryBO.CreatePontuacaoBO();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoBO CreateCampeonatoBO()
        {
            return _factoryBO.CreateCampeonatoBO();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoClassificacaoBO CreateCampeonatoClassificacaoBO()
        {
            return _factoryBO.CreateCampeonatoClassificacaoBO();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoFaseBO CreateCampeonatoFaseBO()
        {
            return _factoryBO.CreateCampeonatoFaseBO();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoGrupoBO CreateCampeonatoGrupoBO()
        {
            return _factoryBO.CreateCampeonatoGrupoBO();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoGrupoTimeBO CreateCampeonatoGrupoTimeBO()
        {
            return _factoryBO.CreateCampeonatoGrupoTimeBO();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoHistoricoBO CreateCampeonatoHistoricoBO()
        {
            return _factoryBO.CreateCampeonatoHistoricoBO();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoPosicaoBO CreateCampeonatoPosicaoBO()
        {
            return _factoryBO.CreateCampeonatoPosicaoBO();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoRecordBO CreateCampeonatoRecordBO()
        {
            return _factoryBO.CreateCampeonatoRecordBO();
        }

        public Business.Interfaces.Campeonatos.ICampeonatoTimeBO CreateCampeonatoTimeBO()
        {
            return _factoryBO.CreateCampeonatoTimeBO();
        }

        public Business.Interfaces.Campeonatos.IHistoricoBO CreateHistoricoBO()
        {
            return _factoryBO.CreateHistoricoBO();
        }

        public Business.Interfaces.Campeonatos.IJogoBO CreateJogoBO()
        {
            return _factoryBO.CreateJogoBO();
        }

        public Business.Interfaces.Campeonatos.IPontuacaoBO CreateCampeonatoPontuacaoBO()
        {
            return _factoryBO.CreateCampeonatoPontuacaoBO();
        }

        public Business.Interfaces.DadosBasicos.ICriterioFixoBO CreateCriterioFixoBO()
        {
            return _factoryBO.CreateCriterioFixoBO();
        }

        public Business.Interfaces.DadosBasicos.IEstadioBO CreateEstadioBO()
        {
            return _factoryBO.CreateEstadioBO();
        }

        public Business.Interfaces.DadosBasicos.IPagamentoTipoBO CreatePagamentoTipoBO()
        {
            return _factoryBO.CreatePagamentoTipoBO();
        }

        public Business.Interfaces.DadosBasicos.ITimeBO CreateTimeBO()
        {
            return _factoryBO.CreateTimeBO();
        }

        public Business.Interfaces.Users.IRoleBO CreateRoleBO()
        {
            return _factoryBO.CreateRoleBO();
        }

        public Business.Interfaces.Users.IUserBO CreateUserBO()
        {
            return _factoryBO.CreateUserBO();
        }

        public Business.Interfaces.Users.IUserInRoleBO CreateUserInRoleBO()
        {
            return _factoryBO.CreateUserInRoleBO();
        }

        public Business.Interfaces.Facade.IBolaoFacadeBO CreateBolaoFacadeBO()
        {
            return _factoryBO.CreateBolaoFacadeBO();
        }

        public Business.Interfaces.Facade.ICampeonatoFacadeBO CreateCampeonatoFacadeBO()
        {
            return _factoryBO.CreateCampeonatoFacadeBO();
        }

        public Business.Interfaces.Facade.IInitializationFacadeBO CreateInitializationFacadeBO()
        {
            return _factoryBO.CreateInitializationFacadeBO();
        }

        public Business.Interfaces.Facade.IUserFacadeBO CreateUserFacadeBO()
        {
            return _factoryBO.CreateUserFacadeBO();
        }

        #endregion
    }
}
