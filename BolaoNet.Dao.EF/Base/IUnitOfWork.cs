using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Base
{
    /// <summary>
    /// Interface que trabalha com o objeto de conexão com a base de dados.
    /// </summary>
    public interface IUnitOfWork
    {
        /// <summary>
        /// Método que atualiza os dados na base de dados.
        /// </summary>
        /// <returns>Quantidade de registros atualizados.</returns>
        int Save();
    }
}
