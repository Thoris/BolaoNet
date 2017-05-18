using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business
{
    /// <summary>
    /// Classe que trabalha com a fabrica do objetos de regra de negócio.
    /// </summary>
    public class FactoryBO : Interfaces.IFactoryBO
    {
        #region Enumerations

        /// <summary>
        /// Enumeração que possui as possibilidades de conexão com base de dados.
        /// </summary>
        private enum DaoType
        {
            /// <summary>
            /// Conexão por entity framework.
            /// </summary>
            EntityFramework = 0,
            /// <summary>
            /// Lista de dados por coleção.
            /// </summary>
            ListCollection,

        }

        #endregion

        #region Variables

        /// <summary>
        /// Variável que armazena a fábrica de conexão com banco de dados.
        /// </summary>
        private static Dao.IFactoryDao _factoryDao;
        /// <summary>
        /// Variável que possui o tipo de conexão para gerenciamento da base de dados.
        /// </summary>
        private static DaoType _daoType;
        /// <summary>
        /// Nome do usuário que está manipulando os dados.
        /// </summary>
        private string _userName;

        #endregion

        #region Constructors/Destructors
        
        /// <summary>
        /// Inicializa nova instância da classe <see cref="FactoryBO" />.
        /// </summary>
        public FactoryBO()
        {
            _daoType = DaoType.EntityFramework;
        }
        /// <summary>
        /// Inicializa nova instância da classe <see cref="FactoryBO" />.
        /// </summary>
        /// <param name="factoryDao">Fábrica de conexão de dados.</param>
        public FactoryBO(Dao.IFactoryDao factoryDao)
        {
            _factoryDao = factoryDao;
        }
        public FactoryBO(string userName, Dao.IFactoryDao factoryDao)
        {
            _userName = userName;
            _factoryDao = factoryDao;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que retorna o tipo de conexão que deve ser realizado para acesso à base de dados.
        /// </summary>
        /// <returns>Tipo de acesso à dados configurado. Caso não encontre, utiliza-se o padrão EntityFramework</returns>
        private static DaoType GetDaoType()
        {
            //Buscando a configuração do tipo de acesso à dados
            string daoType = System.Configuration.ConfigurationManager.AppSettings["FactoryDaoType"];

            //Se existe informação configurada para o tipo de acesso
            if (!string.IsNullOrEmpty(daoType))
            {
                //Verificando qual tipo corresponde ao configurado
                string[] daoTypes = Enum.GetNames(typeof(DaoType));

                //Buscando qual tipo se encaixa
                for (int c = 0; c < daoTypes.Length; c++)
                {
                    //Se encontrou a descrição do tipo de conexão
                    if (string.Compare(daoType, daoTypes[c], true) == 0)
                    {
                        return (DaoType)c;
                    }
                    //Se encontrou o índice do tipo de conexão
                    else if (string.Compare(daoType, c.ToString(), true) == 0)
                    {
                        return (DaoType)c;
                    }//endif

                }//end for c

            }//endif tipo de conexão à dados

            return DaoType.EntityFramework;
        }
        /// <summary>
        /// Método que retorna o objeto de fábrica de objetos para acesso à banco de dados.
        /// </summary>
        /// <returns>Objeto que possui a fábrica de objetos de conexão com o banco de dados.</returns>
        private static Dao.IFactoryDao GetFactoryDao()
        {
            //Se o objeto de conexão ainda não foi criado
            if (_factoryDao == null)
            {
                //Buscando qual tipo de conexão com a base de dados deve utilizar
                _daoType = GetDaoType();

                switch (_daoType)
                {
                    case DaoType.EntityFramework:

                        _factoryDao = new Dao.EF.FactoryDaoEF();

                        break;

                    case DaoType.ListCollection:

                        _factoryDao = new Dao.Collection.FactoryCollection();

                        break;

                }

            }//endif factoryDao == null

            return _factoryDao;
        }

        #endregion
        
        #region IFactoryBO members

        public Interfaces.Boloes.IApostaExtraBO CreateApostaExtraBO()
        {
            return new Boloes.ApostaExtraBO(_userName, GetFactoryDao().CreateApostaExtraDao());
        }

        public Interfaces.Boloes.IApostaExtraUsuarioBO CreateApostaExtraUsuarioBO()
        {
            return new Boloes.ApostaExtraUsuarioBO(_userName, GetFactoryDao().CreateApostaExtraUsuarioDao());
        }

        public Interfaces.Boloes.IApostaPontosBO CreateApostaPontosBO()
        {
            return new Boloes.ApostaPontosBO(_userName, GetFactoryDao().CreateApostaPontosDao());
        }

        public Interfaces.Boloes.IApostasRestantesBO CreateApostasRestantesBO()
        {
            return new Boloes.ApostasRestantesUserBO(_userName, GetFactoryDao().CreateApostasRestantesDao());
        }

        public Interfaces.Boloes.IBolaoBO CreateBolaoBO()
        {
            return new Boloes.BolaoBO(_userName, GetFactoryDao().CreateBolaoDao());
        }

        public Interfaces.Boloes.IBolaoCampeonatoClassificacaoUsuarioBO CreateBolaoCampeonatoClassificacaoUsuarioBO()
        {
            return new Boloes.BolaoCampeonatoClassificacaoUsuarioBO(_userName, GetFactoryDao().CreateBolaoCampeonatoClassificacaoUsuarioDao());
        }

        public Interfaces.Boloes.IBolaoCriterioPontosBO CreateBolaoCriterioPontosBO()
        {
            return new Boloes.BolaoCriterioPontosBO(_userName, GetFactoryDao().CreateBolaoCriterioPontosDao());
        }

        public Interfaces.Boloes.IBolaoCriterioPontosTimesBO CreateBolaoCriterioPontosTimesBO()
        {
            return new Boloes.BolaoCriterioPontosTimesBO(_userName, GetFactoryDao().CreateBolaoCriterioPontosTimesDao());
        }

        public Interfaces.Boloes.IBolaoMembroBO CreateBolaoMembroBO()
        {
            return new Boloes.BolaoMembroBO(_userName, GetFactoryDao().CreateBolaoMembroDao());
        }

        public Interfaces.Boloes.IBolaoMembroClassificacaoBO CreateBolaoMembroClassificacaoBO()
        {
            return new Boloes.BolaoMembroClassificacaoBO(_userName, GetFactoryDao().CreateBolaoMembroClassificacaoDao());
        }

        public Interfaces.Boloes.IBolaoMembroGrupoBO CreateBolaoMembroGrupoBO()
        {
            return new Boloes.BolaoMembroGrupoBO(_userName, GetFactoryDao().CreateBolaoMembroGrupoDao());
        }


        public Interfaces.Boloes.IBolaoPontoRodadaBO CreateBolaoPontoRodadaBO()
        {
            return new Boloes.BolaoPontoRodadaBO(_userName, GetFactoryDao().CreateBolaoPontoRodadaDao());
        }

        public Interfaces.Boloes.IBolaoPontoRodadaUsuarioBO CreateBolaoPontoRodadaUsuarioBO()
        {
            return new Boloes.BolaoPontoRodadaUsuarioBO(_userName, GetFactoryDao().CreateBolaoPontoRodadaUsuarioDao());
        }

        public Interfaces.Boloes.IBolaoPontuacaoBO CreateBolaoPontuacaoBO()
        {
            return new Boloes.BolaoPontuacaoBO(_userName, GetFactoryDao().CreateBolaoPontuacaoDao());
        }

        public Interfaces.Boloes.IBolaoPremioBO CreateBolaoPremioBO()
        {
            return new Boloes.BolaoPremioBO(_userName, GetFactoryDao().CreateBolaoPremioDao());
        }

        public Interfaces.Boloes.IBolaoRegraBO CreateBolaoRegraBO()
        {
            return new Boloes.BolaoRegraBO(_userName, GetFactoryDao().CreateBolaoRegraDao());
        }

        public Interfaces.Boloes.IBolaoRequestBO CreateBolaoRequestBO()
        {
            return new Boloes.BolaoRequestBO(_userName, GetFactoryDao().CreateBolaoRequestDao());
        }

        public Interfaces.Boloes.IBolaoRequestStatusBO CreateBolaoRequestStatusBO()
        {
            return new Boloes.BolaoRequestStatusBO(_userName, GetFactoryDao().CreateBolaoRequestStatusDao());
        }

        public Interfaces.Boloes.ICriterioBO CreateCriterioBO()
        {
            return new Boloes.CriterioBO(_userName, GetFactoryDao().CreateCriterioDao());
        }

        public Interfaces.Boloes.IJogoUsuarioBO CreateJogoUsuarioBO()
        {
            return new Boloes.JogoUsuarioBO(_userName, GetFactoryDao().CreateJogoUsuarioDao());
        }

        public Interfaces.Boloes.IMensagemBO CreateMensagemBO()
        {
            return new Boloes.MensagemBO(_userName, GetFactoryDao().CreateMensagemDao());
        }

        public Interfaces.Boloes.IPagamentoBO CreatePagamentoBO()
        {
            return new Boloes.PagamentoBO(_userName, GetFactoryDao().CreatePagamentoDao());
        }

        public Interfaces.Boloes.IPontuacaoBO CreatePontuacaoBO()
        {
            //return new Boloes.PontuacaoBO(_userName, GetFactoryDao().CreateBolaoPontuacaoDao());
            return null;
        }

        public Interfaces.Campeonatos.ICampeonatoBO CreateCampeonatoBO()
        {
            return new Campeonatos.CampeonatoBO(_userName, GetFactoryDao().CreateCampeonatoDao());
        }

        public Interfaces.Campeonatos.ICampeonatoClassificacaoBO CreateCampeonatoClassificacaoBO()
        {
            return new Campeonatos.CampeonatoClassificacaoBO(_userName, GetFactoryDao().CreateCampeonatoClassificacaoDao());
        }

        public Interfaces.Campeonatos.ICampeonatoFaseBO CreateCampeonatoFaseBO()
        {
            return new Campeonatos.CampeonatoFaseBO(_userName, GetFactoryDao().CreateCampeonatoFaseDao());
        }

        public Interfaces.Campeonatos.ICampeonatoGrupoBO CreateCampeonatoGrupoBO()
        {
            return new Campeonatos.CampeonatoGrupoBO(_userName, GetFactoryDao().CreateCampeonatoGrupoDao());
        }

        public Interfaces.Campeonatos.ICampeonatoGrupoTimeBO CreateCampeonatoGrupoTimeBO()
        {
            return new Campeonatos.CampeonatoGrupoTimeBO(_userName, GetFactoryDao().CreateCampeonatoGrupoTimeDao());
        }

        public Interfaces.Campeonatos.ICampeonatoHistoricoBO CreateCampeonatoHistoricoBO()
        {
            return new Campeonatos.CampeonatoHistoricoBO(_userName, GetFactoryDao().CreateCampeonatoHistoricoDao());
        }

        public Interfaces.Campeonatos.ICampeonatoPosicaoBO CreateCampeonatoPosicaoBO()
        {
            return new Campeonatos.CampeonatoPosicaoBO(_userName, GetFactoryDao().CreateCampeonatoPosicaoDao());
        }

        public Interfaces.Campeonatos.ICampeonatoRecordBO CreateCampeonatoRecordBO()
        {
            return new Campeonatos.CampeonatoRecordBO(_userName, GetFactoryDao().CreateCampeonatoRecordDao());
        }

        public Interfaces.Campeonatos.ICampeonatoTimeBO CreateCampeonatoTimeBO()
        {
            return new Campeonatos.CampeonatoTimeBO(_userName, GetFactoryDao().CreateCampeonatoTimeDao());
        }

        public Interfaces.Campeonatos.IHistoricoBO CreateHistoricoBO()
        {
            return new Campeonatos.HistoricoBO(_userName, GetFactoryDao().CreateHistoricoDao());
        }

        public Interfaces.Campeonatos.IJogoBO CreateJogoBO()
        {
            return new Campeonatos.JogoBO(_userName, GetFactoryDao().CreateJogoDao());
        }

        public Interfaces.DadosBasicos.ICriterioFixoBO CreateCriterioFixoBO()
        {
            return new DadosBasicos.CriterioFixoBO(_userName, GetFactoryDao().CreateCriterioFixoDao());
        }

        public Interfaces.DadosBasicos.IEstadioBO CreateEstadioBO()
        {
            return new DadosBasicos.EstadioBO(_userName, GetFactoryDao().CreateEstadioDao());
        }

        public Interfaces.DadosBasicos.IPagamentoTipoBO CreatePagamentoTipoBO()
        {
            return new DadosBasicos.PagamentoTipoBO(_userName, GetFactoryDao().CreatePagamentoTipoDao());
        }

        public Interfaces.DadosBasicos.ITimeBO CreateTimeBO()
        {
            return new DadosBasicos.TimeBO(_userName, GetFactoryDao().CreateTimeDao());
        }

        public Interfaces.Users.IRoleBO CreateRoleBO()
        {
            return new Users.RoleBO(_userName, GetFactoryDao().CreateRoleDao());
        }

        public Interfaces.Users.IUserBO CreateUserBO()
        {
            return new Users.UserBO(_userName, GetFactoryDao().CreateUserDao());
        }

        public Interfaces.Users.IUserInRoleBO CreateUserInRoleBO()
        {
            return new Users.UserInRoleBO(_userName, GetFactoryDao().CreateUserInRoleDao());
        }

        public Interfaces.Campeonatos.IPontuacaoBO CreateCampeonatoPontuacaoBO()
        {
            return new Campeonatos.PontuacaoBO(_userName, GetFactoryDao().CreateCampeonatoPontuacaoDao());
        }

        public Interfaces.Facade.IBolaoFacadeBO CreateBolaoFacadeBO()
        {
            return new Facade.BolaoFacadeBO(this);           
        }

        public Interfaces.Facade.ICampeonatoFacadeBO CreateCampeonatoFacadeBO()
        {
            return new Facade.CampeonatoFacadeBO(_userName, this);
        }

        public Interfaces.Facade.IInitializationFacadeBO CreateInitializationFacadeBO()
        {
            return new Facade.InitializationFacadeBO(this);
        }

        public Interfaces.Facade.IUserFacadeBO CreateUserFacadeBO()
        {
            return new Facade.UserFacadeBO(this);
        }

        #endregion



    }
}
