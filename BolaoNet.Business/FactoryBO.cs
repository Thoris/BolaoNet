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

        //public Interfaces.IJogadorBO CreateJogador()
        //{
        //    return new JogadorBO("", GetFactoryDao().CreateJogadorDao());
        //}

        //public Interfaces.IModalidadeBO CreateModalidade()
        //{
        //    return new ModalidadeBO("", GetFactoryDao().CreateModalidadeDao());
        //}
    }
}
