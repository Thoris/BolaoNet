using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Base
{
    /// <summary>
    /// Interface genérica que possui informações básicas no gerenciamento das entidades.
    /// </summary>
    /// <typeparam name="T">Tipo de entidade a ser manipulada.</typeparam>
    public interface IGenericService<T>
    {
        /// <summary>
        /// Método que carrega os detalhes de um registro a partir dos dados chave.
        /// </summary>
        /// <param name="entity">Entidade que possui informações básicas do registro a ser carregado.</param>
        /// <returns>Registro encontrado, ou null caso não encontre.</returns>
        T Load(T entity);
        /// <summary>
        /// Método que insere um registro na entidade.
        /// </summary>
        /// <param name="entity">Dados do registro a ser inserido.</param>
        /// <returns>Identificador do registro inserido, ou quantidade de registros afetados.</returns>
        long Insert(T entity);
        /// <summary>
        /// Método que apaga um registro da entidade.
        /// </summary>
        /// <param name="entity">Dados do registro a ser excluído.</param>
        /// <returns>true se conseguiu excluir o registro, senão, falso.</returns>
        bool Delete(T entity);
        /// <summary>
        /// Método que atualiza dados do registro na entidade.
        /// </summary>
        /// <param name="entity">Registro com os dados a ser atualizado na base de dados.</param>
        /// <returns>
        /// true se conseguiu atualizar os dados do registro, senão, false.
        /// </returns>
        bool Update(T entity);
        /// <summary>
        /// Método que retorna a lista de registro de uma entidade.
        /// </summary>
        /// <param name="where">Condição a ser pesquisada.</param>
        /// <returns>Lista de registros de uma entidades, senão, nulo.</returns>
        ICollection<T> GetList(Expression<Func<T, bool>> where);
        /// <summary>
        /// Método que retorna todos os registros de uma entidade.
        /// </summary>
        /// <returns>Lista de registros de uma entidade, senão, nulo</returns>
        ICollection<T> GetAll();
        /// <summary>
        /// Método que retorna a quantidade de registros de uma entidade.
        /// </summary>
        /// <returns>Quantidade de registros de uma entidade.</returns>
        long Count();
        /// <summary>
        /// Método que retorna a quantidade de registro de uma entidade específica.
        /// </summary>
        /// <param name="where">Condição para pesquisa dos registros.</param>
        /// <returns>Quantidade de registros encontrados.</returns>
        long Count(Expression<Func<T, bool>> where);

    }
}
