using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoMembroPontoApp:
        Base.GenericApp<Domain.Entities.Boloes.BolaoMembroPonto>,
        Application.Interfaces.Boloes.IBolaoMembroPontoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoMembroPontoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoMembroPontoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="IBolaoMembroPontoService" />.
        /// </summary>
        public BolaoMembroPontoApp(Domain.Interfaces.Services.Boloes.IBolaoMembroPontoService service)
            : base (service)
        {

        }

        #endregion

        #region IBolaoMembroPontoService members

        public IList<Domain.Entities.Boloes.BolaoMembroPonto> GetHistoricoClassificacao(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetHistoricoClassificacao(bolao, user);
        }
        

        #endregion


    }
}
