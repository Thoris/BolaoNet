using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Controllers
{
    /// <summary>
    /// Classe genérica que possui as implementações de gerenciamento das entidades.
    /// </summary>
    /// <typeparam name="T">Entidade a ser gerenciada.</typeparam>
    public class GenericApiController<T> : AuthorizationController where T : class
    {
        #region Variables

        /// <summary>
        /// Variável que possui o objeto de gerenciamento da entidade.
        /// </summary>
        private Business.Base.IGenericBusiness<T> _bo;

        #endregion

        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto de acesso à dados para gerencimento da entidade.
        /// </summary>
        protected Business.Base.IGenericBusiness<T> BaseBo
        {
            get { return _bo; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="GenericApiController{T}"/> .
        /// </summary>
        /// <param name="dao">Objeto de regras de negócio.</param>
        public GenericApiController(Business.Base.IGenericBusiness<T> bo)
        {
            _bo = bo;
        }

        #endregion

        #region Methods

        /// <summary>
        /// Método que busca e carrega os atributos da entidade.
        /// </summary>
        /// <param name="entity">Entidade a ser carregada.</param>
        /// <returns>Entidade encontrada, ou nulo caso não encontre.</returns>
        [HttpPost]
        public T Load(T entity)
        {
            return _bo.Load(entity);
        }
        /// <summary>
        /// Método que insere uma entidade na base de dados.
        /// </summary>
        /// <param name="entity">Dados da entidade a ser inserida.</param>
        /// <returns>Identificador do registro inserido, ou a quantidade de registros afetados no caso de identificador diferente de numérico.</returns>
        [HttpPost]
        public long Insert(T entity)
        {
            long res = _bo.Insert(entity);

            Entities.Base.BaseEntity baseEntity = entity as Entities.Base.BaseEntity;

            string identityName = baseEntity.GetIdentifyName();

            if (string.IsNullOrEmpty(identityName))
                return res;

            object resIdentity = baseEntity.GetIdentityValue();

            return (long)resIdentity;

        }
        /// <summary>
        /// Método que apaga uma entidade da base de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser excluída.</param>
        /// <returns>True se o registro foi excluído com sucesso.</returns>
        [HttpPost]
        public bool Delete(T entity)
        {
            return _bo.Delete(entity);
        }
        /// <summary>
        /// Método que atualiza os dados da entidade.
        /// </summary>
        /// <param name="oldEntity">Entidade antiga a ser atualizada.</param>
        /// <param name="entity">Dados da entidade que devem ser aplicadas à base de dados.</param>
        /// <returns>True se o registro foi alterado com sucesso.</returns>
        [HttpPost]
        public bool Update(T entity)
        {
            return _bo.Update(entity);
        }
        /// <summary>
        /// Método que carrega uma lista de entidades baseado na condição especificada.
        /// </summary>
        /// <param name="where">String que possui a condição a ser pesquisada.</param>
        /// <returns>Lista de entidades encontradas.</returns>
        [HttpGet]
        public ICollection<T> GetList(string where)
        {
            return _bo.GetAll();
        }
        /// <summary>
        /// Método que carrega todos as entidades armazenadas na base de dados.
        /// </summary>
        /// <returns>Lista de entidades encontradas.</returns>
        [HttpGet]
        public ICollection<T> GetAll()
        {
            return _bo.GetAll();
        }
        /// <summary>
        /// Método que retorna a quantidade de registros existentes na base de dados referênte à entidade.
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public long Count()
        {
            return _bo.Count();
        }

        #endregion
    }
}