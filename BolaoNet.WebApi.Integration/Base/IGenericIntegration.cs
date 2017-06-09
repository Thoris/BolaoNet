using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.WebApi.Integration.Base
{
    /// <summary>
    /// Interface que possui as funcionalidades básicas de gerenciamento da entidade.
    /// </summary>
    /// <typeparam name="T">Entidade a ser gerenciada.</typeparam>
    public interface IGenericIntegration<T> : Domain.Interfaces.Services.Base.IGenericService<T> where T : class
    {

    }
}
