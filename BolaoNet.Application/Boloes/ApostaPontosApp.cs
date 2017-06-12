using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class ApostaPontosApp :
        Base.GenericApp<Domain.Entities.Boloes.ApostaPontos>,
        Application.Interfaces.Boloes.IApostaPontosApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IApostaPontosService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IApostaPontosService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostaPontosApp" />.
        /// </summary>
        public ApostaPontosApp(Domain.Interfaces.Services.Boloes.IApostaPontosService service)
            : base (service)
        {

        }

        #endregion    
    }
}
