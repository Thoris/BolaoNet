using BolaoNet.Domain.Entities.Base.Common.Interfaces.Validation;
using BolaoNet.Domain.Entities.Base.Common.Validation;
using BolaoNet.Domain.Interfaces.Services.Base;
using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Base
{
    /// <summary>
    /// Classe Business Object genérica que possui métodos utilizados para gerenciamento das entidades.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class BaseGenericService<T> : BaseAuditService<T>, IDisposable, IGenericService<T> where T : class
    {
        #region Variables

        /// <summary>
        /// Variável que armazena o objeto que acessa a base de dados.
        /// </summary>
        private Interfaces.Repositories.Base.IGenericDao<T> _dao;
        /// <summary>
        /// Variável que possui o login do usuário que está manipulando os dados.
        /// </summary>
        private string _currentUserName;
        /// <summary>
        /// Variável que possui o serviço de log.
        /// </summary>
        protected ILogging _logging;

        private readonly ValidationResult _validationResult;

        #endregion

        #region Properties
        /// <summary>
        /// Propriedade que retorna o login do usuário que está manipulando os dados.
        /// </summary>
        protected string CurrentUserName
        {
            get { return _currentUserName; }
        }
        /// <summary>
        /// Propriedade que retorna o objeto de conexão com o banco de dados.
        /// </summary>
        protected Interfaces.Repositories.Base.IGenericDao<T> BaseDao
        {
            get { return _dao; }
        }
        /// <summary>
        /// Propriedade que retorna o objeto de armazenamento de log.
        /// </summary>
        protected ILogging Logging
        {
            get { return _logging; }
        }

        protected ValidationResult ValidationResult
        {
            get { return _validationResult; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Construtor que inicializa a classe.
        /// </summary>
        /// <param name="currentUserName">Usuário que está fazendo a execução.</param>
        /// <param name="dao">Objeto de acesso à dados</param>
        public BaseGenericService(string currentUserName, Interfaces.Repositories.Base.IGenericDao<T> dao, ILogging logging)
        {
            if (dao == null)
                throw new ArgumentException("dao");

            _dao = dao;
            _currentUserName = currentUserName;
            _logging = logging;

            _validationResult = new ValidationResult();
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
                    _logging.Debug(this, GetStringTypeNameID(entity) + GetMessageTotalTime("Not loaded."));
                else
                    _logging.Debug(this, GetStringTypeNameID(entity) + GetMessageTotalTime("loaded."));
            }

            return result;

        }
        /// <summary>
        /// Método que insere um atributo na base de dados
        /// </summary>
        /// <param name="entity">Entidade a ser inserida</param>
        /// <returns>Identificador do registo, ou quantidade de registros afetados quando o tipo é diferente de numérico.</returns>
        public long Insert(T entity)
        //public ValidationResult Insert(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            if (!ValidationResult.IsValid)
            {
                return -1;
                //return ValidationResult;
            }


            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid())
            {
                return -1;
                //return selfValidationEntity.ValidationResult;
            }

            if (IsSaveLog)
            {
                _logging.Debug(this, GetTypeName(entity) + ": Inserting ...");
                CheckStart();
            }

            if (typeof(T).IsSubclassOf(typeof(Entities.Base.AuditModel)) ||
                typeof(T) == typeof(Entities.Base.AuditModel))
            {
                Entities.Base.AuditModel baseModel = entity as Entities.Base.AuditModel;
                baseModel.CreatedBy = _currentUserName;
                baseModel.CreatedDate = DateTime.Now;
                baseModel.ModifiedBy = _currentUserName;
                baseModel.ModifiedDate = DateTime.Now;
                //baseModel.StatusRegistro = (int)Entities.Enum.RowType.Nennhum;
            }

            long result = _dao.Insert(entity);

            if (IsSaveLog)
            {
                if (result >= 1)
                    _logging.Info(this, GetStringTypeNameID(entity) + GetMessageTotalTime("Inserted."));
                else
                    _logging.Warn(this, GetStringTypeNameID(entity) + ": " + GetMessageTotalTime("Entity insert result: " + result));
            }

            //return result >= 1 ? true : false;
            return result;


            //return _validationResult;

        }
        /// <summary>
        /// Método que exclui uma entidade da base de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser excluída.</param>
        /// <returns>Se conseguiu excluir mais de 1 item, returna true, senão, false</returns>
        public bool Delete(T entity)
        //public ValidationResult Delete(T entity)
        {

            if (!ValidationResult.IsValid)
            {
                return false;
                //return ValidationResult;
            }

            if (entity == null)
                throw new ArgumentException("entity");

            if (IsSaveLog)
            {
                _logging.Debug(this, GetStringTypeNameID(entity) + "Deleting entity...");
                CheckStart();
            }

            int result = _dao.Delete(entity);

            if (IsSaveLog)
            {
                if (result >= 1)
                    _logging.Info(this, GetStringTypeNameID(entity) + GetMessageTotalTime("Deleted."));
                else
                    _logging.Warn(this, GetStringTypeNameID(entity) + GetMessageTotalTime("Entity delete result: " + result));
            }

            return result >= 1 ? true : false;

            //return _validationResult;

        }
        /// <summary>
        /// Método que atualiza uma entidade na base de dados.
        /// </summary>
        /// <param name="oldEntity">Entidade a ser atualizada.</param>
        /// <param name="entity">Dados da nova entidade.</param>
        /// <returns>true se conseguiu atualizar pelo menos um registro, senão, false.</returns>
        public bool Update(T entity)
        //public ValidationResult Update(T entity)
        {
            if (entity == null)
                throw new ArgumentException("entity");

            if (!ValidationResult.IsValid)
            {
                return false;
                //return ValidationResult;
            }
            var selfValidationEntity = entity as ISelfValidation;
            if (selfValidationEntity != null && !selfValidationEntity.IsValid())
            {
                return false;
                //return selfValidationEntity.ValidationResult;
            }

            if (IsSaveLog)
            {
                _logging.Debug(this, GetStringTypeNameID(entity) + "Updating entity...");
                CheckStart();

            }


            if (typeof(T).IsSubclassOf(typeof(Entities.Base.AuditModel)) ||
                typeof(T) == typeof(Entities.Base.AuditModel))
            {
                Entities.Base.AuditModel baseModel = entity as Entities.Base.AuditModel;
                baseModel.ModifiedBy = this.CurrentUserName;
                baseModel.ModifiedDate = DateTime.Now;
            }
            int result = _dao.Update(entity);

            if (IsSaveLog)
            {
                if (result >= 1)
                    _logging.Info(this, GetStringTypeNameID(entity) + GetMessageTotalTime("Updated."));
                else
                    _logging.Warn(this, GetStringTypeNameID(entity) + GetMessageTotalTime("Entity updated result: " + result));
            }


            return result >= 1 ? true : false;


            //return _validationResult;

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
                    _logging.Debug(this, "List" + ": " + GetMessageTotalTime("List of items: 0 |" + where.Body + "|"));
                else
                    _logging.Debug(this, result.GetType() + ": " + GetMessageTotalTime("List of items:" + result.Count.ToString() + " |" + where.Body + "|"));
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
                    _logging.Debug(this, "List" + ": " + GetMessageTotalTime("Total of items: 0"));
                else
                    _logging.Debug(this, result.GetType() + ": " + GetMessageTotalTime("Total of items:" + result.Count.ToString()));
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
