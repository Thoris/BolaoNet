using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoPremioApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoPremio>,
        Application.Interfaces.Boloes.IBolaoPremioApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoPremioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoPremioService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoPremioApp" />.
        /// </summary>
        public BolaoPremioApp(Domain.Interfaces.Services.Boloes.IBolaoPremioService service)
            : base (service)
        {

        }

        #endregion

        #region IBolaoPremioApp members
        
        public IList<Domain.Entities.Boloes.BolaoPremio> GetPremiosBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetPremiosBolao(bolao);
        }

        #endregion
    }
}
