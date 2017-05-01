using BolaoNet.LogManager;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Base
{
    /// <summary>
    /// Classe Business Object genérica que possui métodos utilizados para gerenciamento das entidades.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseGenericBusinessBO<T> : BaseAuditBO<T>, IDisposable, IGenericBusiness<T> where T : class
    {
        #region Variables

        /// <summary>
        /// Variável que armazena o objeto que acessa a base de dados.
        /// </summary>
        private Dao.Base.IGenericDao<T> _dao;
        /// <summary>
        /// Variável que possui o login do usuário que está manipulando os dados.
        /// </summary>
        private string _currentUserName;

        #endregion

        #region Properties
        /// <summary>
        /// Propriedade que retorna o login do usuário que está manipulando os dados.
        /// </summary>
        protected string CurrentUserName
        {
            get { return _currentUserName; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Construtor que inicializa a classe.
        /// </summary>
        /// <param name="currentUserName">Usuário que está fazendo a execução.</param>
        /// <param name="dao">Objeto de acesso à dados</param>
        public BaseGenericBusinessBO(string currentUserName, Dao.Base.IGenericDao<T> dao)
        {
            if (dao == null)
                throw new ArgumentException("dao");

            _dao = dao;
            _currentUserName = currentUserName;
        }

        #endregion

        #region IDisposable members

        /// <summary>
        /// Método que destroi o objeto.
        /// </summary>
        public void Dispose()
        {
            ((IDisposable)_dao).Dispose();
        }

        #endregion

        #region IGenericBusiness members

        /// <summary>
        /// Método que busca uma entidade na base de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser carregada.</param>
        /// <returns>Entidade carregada com todos os atributos preenchidos, caso não encontre, retora nulo.</returns>
        public T Load(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            if (IsSaveLog)
                CheckStart();

            T result = _dao.Load(entity);

            if (IsSaveLog)
            {
                if (result == null)
                    LogTool.Debug(this, GetStringTypeNameID(entity) + GetMessageTotalTime("Not loaded."));
                else
                    LogTool.Debug(this, GetStringTypeNameID(entity) + GetMessageTotalTime("loaded."));
            }

            return result;

        }
        /// <summary>
        /// Método que insere um atributo na base de dados
        /// </summary>
        /// <param name="entity">Entidade a ser inserida</param>
        /// <returns>Identificador do registo, ou quantidade de registros afetados quando o tipo é diferente de numérico.</returns>
        public long Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            if (IsSaveLog)
            {
                LogTool.Debug(this, GetTypeName(entity) + ": Inserting ...");
                CheckStart();
            }

            if (typeof(T).IsSubclassOf(typeof(Entities.Base.AuditModel)) ||
                typeof(T) == typeof(Entities.Base.AuditModel))
            {
                Entities.Base.AuditModel baseModel = entity as Entities.Base.AuditModel;
                baseModel.CriadoPor = _currentUserName;
                baseModel.DataCriacao = DateTime.Now;
                baseModel.ModificadoPor = _currentUserName;
                baseModel.DataModificacao = DateTime.Now;
                //baseModel.StatusRegistro = (int)Entities.Enum.RowType.Nennhum;
            }

            long result = _dao.Insert(entity);

            if (IsSaveLog)
            {
                if (result >= 1)
                    LogTool.Info(this, GetStringTypeNameID(entity) + GetMessageTotalTime("Inserted."));
                else
                    LogTool.Warn(this, GetStringTypeNameID(entity) + ": " + GetMessageTotalTime("Entity insert result: " + result));
            }

            //return result >= 1 ? true : false;
            return result;

        }
        /// <summary>
        /// Método que exclui uma entidade da base de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser excluída.</param>
        /// <returns>Se conseguiu excluir mais de 1 item, returna true, senão, false</returns>
        public bool Delete(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            if (IsSaveLog)
            {
                LogTool.Debug(this, GetStringTypeNameID(entity) + "Deleting entity...");
                CheckStart();
            }

            int result = _dao.Delete(entity);

            if (IsSaveLog)
            {
                if (result >= 1)
                    LogTool.Info(this, GetStringTypeNameID(entity) + GetMessageTotalTime("Deleted."));
                else
                    LogTool.Warn(this, GetStringTypeNameID(entity) + GetMessageTotalTime("Entity delete result: " + result));
            }

            return result >= 1 ? true : false;

            //return true;

        }
        /// <summary>
        /// Método que atualiza uma entidade na base de dados.
        /// </summary>
        /// <param name="oldEntity">Entidade a ser atualizada.</param>
        /// <param name="entity">Dados da nova entidade.</param>
        /// <returns>true se conseguiu atualizar pelo menos um registro, senão, false.</returns>
        public bool Update(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            if (IsSaveLog)
            {
                LogTool.Debug(this, GetStringTypeNameID(entity) + "Updating entity...");
                CheckStart();

            }


            if (typeof(T).IsSubclassOf(typeof(Entities.Base.AuditModel)) ||
                typeof(T) == typeof(Entities.Base.AuditModel))
            {
                Entities.Base.AuditModel baseModel = entity as Entities.Base.AuditModel;
                baseModel.ModificadoPor = this.CurrentUserName;
                baseModel.DataModificacao = DateTime.Now;
            }
            int result = _dao.Update(entity);

            if (IsSaveLog)
            {
                if (result >= 1)
                    LogTool.Info(this, GetStringTypeNameID(entity) + GetMessageTotalTime("Updated."));
                else
                    LogTool.Warn(this, GetStringTypeNameID(entity) + GetMessageTotalTime("Entity updated result: " + result));
            }


            return result >= 1 ? true : false;

        }
        /// <summary>
        /// Método que retorna a quantidade de retistros na entidade.
        /// </summary>
        /// <returns>Quantidade de registros.</returns>
        public long Count()
        {
            long result = _dao.Count();

            return result;
        }
        /// <summary>
        /// Método que retorna a lista de registros baseado em uma condição especificada.
        /// </summary>
        /// <param name="where">Condição para retornar os registros</param>
        /// <returns>Coleção de itens encontrados.</returns>
        public ICollection<T> GetList(Expression<Func<T, bool>> where)
        {
            if (IsSaveLog)
                CheckStart();

            ICollection<T> result = _dao.GetList(where);

            if (IsSaveLog)
            {
                if (result == null)
                    LogTool.Debug(this, "List" + ": " + GetMessageTotalTime("List of items: 0 |" + where.Body + "|"));
                else
                    LogTool.Debug(this, result.GetType() + ": " + GetMessageTotalTime("List of items:" + result.Count.ToString() + " |" + where.Body + "|"));
            }


            return result;
        }
        /// <summary>
        /// Método que retorna todos os registros da base de dados.
        /// </summary>
        /// <returns>Coleção de itens da base de dados.</returns>
        public ICollection<T> GetAll()
        {
            if (IsSaveLog)
                CheckStart();

            ICollection<T> result = _dao.GetAll();

            if (IsSaveLog)
            {
                if (result == null)
                    LogTool.Debug(this, "List" + ": " + GetMessageTotalTime("Total of items: 0"));
                else
                    LogTool.Debug(this, result.GetType() + ": " + GetMessageTotalTime("Total of items:" + result.Count.ToString()));
            }

            return result;
        }
        /// <summary>
        /// Método que retorna a quantidade de registro de uma entidade específica.
        /// </summary>
        /// <param name="where">Condição para pesquisa dos registros.</param>
        /// <returns>Quantidade de registros encontrados.</returns>
        public long Count(Expression<Func<T, bool>> where)
        {
            long result = _dao.Count(where);

            return result;
        }

        #endregion
    }
}
