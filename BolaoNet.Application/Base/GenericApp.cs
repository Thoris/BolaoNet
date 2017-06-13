using BolaoNet.Application.Interfaces.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Base
{
    /// <summary>
    /// Classe que trabalha com funcionalidades genéricas para gerenciamento das entidades de integração.
    /// </summary>
    public abstract class GenericApp<T> : IGenericApp<T> where T : class
    {
        #region Variables

        protected Domain.Interfaces.Services.Base.IGenericService<T> _service;

        #endregion

        #region Constructors/Destructors

        public GenericApp(Domain.Interfaces.Services.Base.IGenericService<T> service)
        {
            _service = service;
        }

        #endregion
       
        #region IGenericApp members

        /// <summary>
        /// Método que carrega um registro a partir de dados básicos da entidade.
        /// </summary>
        /// <param name="entity">Entidade que será utilizada para carregar os dados.</param>
        /// <returns>Item encontrado, ou null caso não encontre.</returns>
        public T Load(T entity)
        {
            return _service.Load(entity);
        }
        /// <summary>
        /// Método que insere um registro na base de dados.
        /// </summary>
        /// <param name="entity">Entidade com os dados a serem inseridos.</param>
        /// <returns>Identificador do registro, ou quantidade de registro afetados.</returns>
        public long Insert(T entity)
        {
            return _service.Insert(entity);
        }
        /// <summary>
        /// Método que exclui um registro da base de dados.
        /// </summary>
        /// <param name="entity">Entidade a ser pesquisada para ser excluída.</param>
        /// <returns>True se conseguiu excluir o registro.</returns>
        public bool Delete(T id)
        {
            return _service.Delete(id);
        }
        /// <summary>
        /// Método que atualiza um registro na base de dados.
        /// </summary>
        /// <param name="oldEntity">Registro atual que deve ser pesquisado na base de dados.</param>
        /// <param name="entity">Dados do registro a ser atualizado na base de dados.</param>
        /// <returns>True se conseguiu atualizar o registro.</returns>
        public bool Update(T entity)
        {
            return _service.Update(entity);
        }
        /// <summary>
        /// Método que retorna a lista de registros de entidades a partir de uma condição.
        /// </summary>
        /// <param name="where">Condição a ser usada na pesquisa.</param>
        /// <returns>Lista de entidades encontradas.</returns>
        public ICollection<T> GetList(Expression<Func<T, bool>> where)
        {
            return _service.GetList(where);
        }
        /// <summary>
        /// Método que retorna lista de registros de uma entidade em específico.
        /// </summary>
        /// <returns>Lista de registros encontrados.</returns>
        public ICollection<T> GetAll()
        {
            return _service.GetAll();
        }
        /// <summary>
        /// Método que retorna a quantidade de registros da entidade.
        /// </summary>
        /// <returns>Quantidade de registros encontrados.</returns>
        public long Count()
        {
            return _service.Count();
        }
        public long Count(Expression<Func<T, bool>> where)
        {
            return _service.Count(where);
        }

        #endregion
    }
}
