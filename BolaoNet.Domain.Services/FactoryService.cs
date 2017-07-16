using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services
{
    /// <summary>
    /// Classe que trabalha com a fabrica do objetos de regra de negócio.
    /// </summary>
    public class FactoryService : Interfaces.Services.IFactoryService
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
        private Interfaces.Repositories.IFactoryDao _factoryDao;
        /// <summary>
        /// Variável que possui o tipo de conexão para gerenciamento da base de dados.
        /// </summary>
        private DaoType _daoType;
        /// <summary>
        /// Nome do usuário que está manipulando os dados.
        /// </summary>
        private string _userName;
        private ILogging _logging;
             
        #endregion

        #region Constructors/Destructors
        
        /// <summary>
        /// Inicializa nova instância da classe <see cref="FactoryService" />.
        /// </summary>
        public FactoryService(ILogging logging)
        {
            _daoType = DaoType.EntityFramework;
            _factoryDao = GetFactoryDao();
            _logging = logging;
        }
        public FactoryService(string userName, ILogging logging)
        {
            _userName = userName;
            _daoType = DaoType.EntityFramework;

            _factoryDao = GetFactoryDao();
            _logging = logging;
        }
        /// <summary>
        /// Inicializa nova instância da classe <see cref="FactoryService" />.
        /// </summary>
        /// <param name="factoryDao">Fábrica de conexão de dados.</param>
        public FactoryService(Interfaces.Repositories.IFactoryDao factoryDao, ILogging logging)
        {
            _factoryDao = factoryDao; 
            _logging = logging;
        }
        public FactoryService(string userName, Interfaces.Repositories.IFactoryDao factoryDao, ILogging logging)
        {
            _userName = userName;
            _factoryDao = factoryDao;
            _logging = logging;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que retorna o tipo de conexão que deve ser realizado para acesso à base de dados.
        /// </summary>
        /// <returns>Tipo de acesso à dados configurado. Caso não encontre, utiliza-se o padrão EntityFramework</returns>
        private DaoType GetDaoType()
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
        private Interfaces.Repositories.IFactoryDao GetFactoryDao()
        {
            //Se o objeto de conexão ainda não foi criado
            if (_factoryDao == null)
            {
                //Buscando qual tipo de conexão com a base de dados deve utilizar
                _daoType = GetDaoType();

                switch (_daoType)
                {
                    case DaoType.EntityFramework:

                        //_factoryDao = new Domain.EF.FactoryDaoEF();
                        _factoryDao = new Infra.Data.EF.FactoryDaoEF();

                        break;

                    case DaoType.ListCollection:

                        //_factoryDao = new Interfaces.Repositories.Collection.FactoryCollection();

                        break;

                }

            }//endif factoryDao == null

            return _factoryDao;
        }

        #endregion
        
        #region IFactoryService members

        public Interfaces.Services.Boloes.IApostaExtraService CreateApostaExtraService()
        {
            return new Boloes.ApostaExtraService(_userName, GetFactoryDao().CreateApostaExtraDao(), _logging);
        }

        public Interfaces.Services.Boloes.IApostaExtraUsuarioService CreateApostaExtraUsuarioService()
        {
            return new Boloes.ApostaExtraUsuarioService(_userName, GetFactoryDao().CreateApostaExtraUsuarioDao(), _logging);
        }

        public Interfaces.Services.Boloes.IApostaPontosService CreateApostaPontosService()
        {
            return new Boloes.ApostaPontosService(_userName, GetFactoryDao().CreateApostaPontosDao(), _logging);
        }

        public Interfaces.Services.Boloes.IApostasRestantesService CreateApostasRestantesService()
        {
            //return new Boloes.ApostasRestantesUserService(_userName, GetFactoryDao().CreateApostasRestantesDao());
            return null;
        }

        public Interfaces.Services.Boloes.IBolaoService CreateBolaoService()
        {
            return new Boloes.BolaoService(_userName, GetFactoryDao().CreateBolaoDao(), _logging);
        }

        public Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService CreateBolaoCampeonatoClassificacaoUsuarioService()
        {
            return new Boloes.BolaoCampeonatoClassificacaoUsuarioService(_userName, GetFactoryDao().CreateBolaoCampeonatoClassificacaoUsuarioDao(), _logging);
        }

        public Interfaces.Services.Boloes.IBolaoCriterioPontosService CreateBolaoCriterioPontosService()
        {
            return new Boloes.BolaoCriterioPontosService(_userName, GetFactoryDao().CreateBolaoCriterioPontosDao(), _logging);
        }

        public Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService CreateBolaoCriterioPontosTimesService()
        {
            return new Boloes.BolaoCriterioPontosTimesService(_userName, GetFactoryDao().CreateBolaoCriterioPontosTimesDao(), _logging);
        }

        public Interfaces.Services.Boloes.IBolaoMembroService CreateBolaoMembroService()
        {
            return new Boloes.BolaoMembroService(_userName, GetFactoryDao().CreateBolaoMembroDao(), _logging);
        }

        public Interfaces.Services.Boloes.IBolaoMembroClassificacaoService CreateBolaoMembroClassificacaoService()
        {
            return new Boloes.BolaoMembroClassificacaoService(_userName, GetFactoryDao().CreateBolaoMembroClassificacaoDao(), _logging);
        }

        public Interfaces.Services.Boloes.IBolaoMembroGrupoService CreateBolaoMembroGrupoService()
        {
            return new Boloes.BolaoMembroGrupoService(_userName, GetFactoryDao().CreateBolaoMembroGrupoDao(), _logging);
        }


        public Interfaces.Services.Boloes.IBolaoPontoRodadaService CreateBolaoPontoRodadaService()
        {
            return new Boloes.BolaoPontoRodadaService(_userName, GetFactoryDao().CreateBolaoPontoRodadaDao(), _logging);
        }

        public Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService CreateBolaoPontoRodadaUsuarioService()
        {
            return new Boloes.BolaoPontoRodadaUsuarioService(_userName, GetFactoryDao().CreateBolaoPontoRodadaUsuarioDao(), _logging);
        }

        public Interfaces.Services.Boloes.IBolaoPontuacaoService CreateBolaoPontuacaoService()
        {
            return new Boloes.BolaoPontuacaoService(_userName, GetFactoryDao().CreateBolaoPontuacaoDao(), _logging);
        }

        public Interfaces.Services.Boloes.IBolaoPremioService CreateBolaoPremioService()
        {
            return new Boloes.BolaoPremioService(_userName, GetFactoryDao().CreateBolaoPremioDao(), _logging);
        }

        public Interfaces.Services.Boloes.IBolaoRegraService CreateBolaoRegraService()
        {
            return new Boloes.BolaoRegraService(_userName, GetFactoryDao().CreateBolaoRegraDao(), _logging);
        }

        public Interfaces.Services.Boloes.IBolaoRequestService CreateBolaoRequestService()
        {
            return new Boloes.BolaoRequestService(_userName, GetFactoryDao().CreateBolaoRequestDao(), _logging);
        }

        public Interfaces.Services.Boloes.IBolaoRequestStatusService CreateBolaoRequestStatusService()
        {
            return new Boloes.BolaoRequestStatusService(_userName, GetFactoryDao().CreateBolaoRequestStatusDao(), _logging);
        }

        public Interfaces.Services.Boloes.ICriterioService CreateCriterioService()
        {
            return new Boloes.CriterioService(_userName, GetFactoryDao().CreateCriterioDao(), _logging);
        }

        public Interfaces.Services.Boloes.IJogoUsuarioService CreateJogoUsuarioService()
        {
            return new Boloes.JogoUsuarioService(_userName, GetFactoryDao().CreateJogoUsuarioDao(), _logging);
        }

        public Interfaces.Services.Boloes.IMensagemService CreateMensagemService()
        {
            return new Boloes.MensagemService(_userName, GetFactoryDao().CreateMensagemDao(), _logging);
        }

        public Interfaces.Services.Boloes.IPagamentoService CreatePagamentoService()
        {
            return new Boloes.PagamentoService(_userName, GetFactoryDao().CreatePagamentoDao(), _logging);
        }

        public Interfaces.Services.Boloes.IPontuacaoService CreatePontuacaoService()
        {
            //return new Boloes.PontuacaoService(_userName, GetFactoryDao().CreateBolaoPontuacaoDao());
            return null;
        }

        public Interfaces.Services.Campeonatos.ICampeonatoService CreateCampeonatoService()
        {
            return new Campeonatos.CampeonatoService(_userName, GetFactoryDao().CreateCampeonatoDao(), _logging);
        }

        public Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService CreateCampeonatoClassificacaoService()
        {
            return new Campeonatos.CampeonatoClassificacaoService(_userName, GetFactoryDao().CreateCampeonatoClassificacaoDao(), _logging);
        }

        public Interfaces.Services.Campeonatos.ICampeonatoFaseService CreateCampeonatoFaseService()
        {
            return new Campeonatos.CampeonatoFaseService(_userName, GetFactoryDao().CreateCampeonatoFaseDao(), _logging);
        }

        public Interfaces.Services.Campeonatos.ICampeonatoGrupoService CreateCampeonatoGrupoService()
        {
            return new Campeonatos.CampeonatoGrupoService(_userName, GetFactoryDao().CreateCampeonatoGrupoDao(), _logging);
        }

        public Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService CreateCampeonatoGrupoTimeService()
        {
            return new Campeonatos.CampeonatoGrupoTimeService(_userName, GetFactoryDao().CreateCampeonatoGrupoTimeDao(), _logging);
        }

        public Interfaces.Services.Campeonatos.ICampeonatoHistoricoService CreateCampeonatoHistoricoService()
        {
            return new Campeonatos.CampeonatoHistoricoService(_userName, GetFactoryDao().CreateCampeonatoHistoricoDao(), _logging);
        }

        public Interfaces.Services.Campeonatos.ICampeonatoPosicaoService CreateCampeonatoPosicaoService()
        {
            return new Campeonatos.CampeonatoPosicaoService(_userName, GetFactoryDao().CreateCampeonatoPosicaoDao(), _logging);
        }

        public Interfaces.Services.Campeonatos.ICampeonatoRecordService CreateCampeonatoRecordService()
        {
            return new Campeonatos.CampeonatoRecordService(_userName, GetFactoryDao().CreateCampeonatoRecordDao(), _logging);
        }

        public Interfaces.Services.Campeonatos.ICampeonatoTimeService CreateCampeonatoTimeService()
        {
            return new Campeonatos.CampeonatoTimeService(_userName, GetFactoryDao().CreateCampeonatoTimeDao(), _logging);
        }

        public Interfaces.Services.Campeonatos.IHistoricoService CreateHistoricoService()
        {
            return new Campeonatos.HistoricoService(_userName, GetFactoryDao().CreateHistoricoDao(), _logging);
        }

        public Interfaces.Services.Campeonatos.IJogoService CreateJogoService()
        {
            return new Campeonatos.JogoService(_userName, GetFactoryDao().CreateJogoDao(), _logging);
        }

        public Interfaces.Services.DadosBasicos.ICriterioFixoService CreateCriterioFixoService()
        {
            return new DadosBasicos.CriterioFixoService(_userName, GetFactoryDao().CreateCriterioFixoDao(), _logging);
        }

        public Interfaces.Services.DadosBasicos.IEstadioService CreateEstadioService()
        {
            return new DadosBasicos.EstadioService(_userName, GetFactoryDao().CreateEstadioDao(), _logging);
        }

        public Interfaces.Services.DadosBasicos.IPagamentoTipoService CreatePagamentoTipoService()
        {
            return new DadosBasicos.PagamentoTipoService(_userName, GetFactoryDao().CreatePagamentoTipoDao(), _logging);
        }

        public Interfaces.Services.DadosBasicos.ITimeService CreateTimeService()
        {
            return new DadosBasicos.TimeService(_userName, GetFactoryDao().CreateTimeDao(), _logging);
        }

        public Interfaces.Services.Users.IRoleService CreateRoleService()
        {
            return new Users.RoleService(_userName, GetFactoryDao().CreateRoleDao(), _logging);
        }

        public Interfaces.Services.Users.IUserService CreateUserService()
        {
            return new Users.UserService(_userName, GetFactoryDao().CreateUserDao(), _logging);
        }

        public Interfaces.Services.Users.IUserInRoleService CreateUserInRoleService()
        {
            return new Users.UserInRoleService(_userName, GetFactoryDao().CreateUserInRoleDao(), _logging);
        }

        public Interfaces.Services.Campeonatos.IPontuacaoService CreateCampeonatoPontuacaoService()
        {
            return new Campeonatos.PontuacaoService(_userName, GetFactoryDao().CreateCampeonatoPontuacaoDao(), _logging);
        }

        public Interfaces.Services.Facade.IBolaoFacadeService CreateBolaoFacadeService()
        {
            return new Facade.BolaoFacadeService(this);           
        }

        public Interfaces.Services.Facade.ICampeonatoFacadeService CreateCampeonatoFacadeService()
        {
            return new Facade.CampeonatoFacadeService(_userName, this);
        }

        public Interfaces.Services.Facade.IInitializationFacadeService CreateInitializationFacadeService()
        {
            return null;
            //return new Facade.InitializationFacadeService(this);
        }

        public Interfaces.Services.Facade.IUserFacadeService CreateUserFacadeService()
        {
            //return new Facade.UserFacadeService(_userName, this);
            return null;
        }

        #endregion

    }
}
