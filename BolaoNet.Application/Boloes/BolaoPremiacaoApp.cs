using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoPremiacaoApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoPremiacao>,
        Application.Interfaces.Boloes.IBolaoPremiacaoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoPremiacaoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoPremiacaoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoCriterioPontosApp" />.
        /// </summary>
        public BolaoPremiacaoApp(Domain.Interfaces.Services.Boloes.IBolaoPremiacaoService service)
            : base (service)
        {

        }

        #endregion    
    
        #region IBolaoPremiacaoService members

        public IList<Domain.Entities.Boloes.BolaoPremiacao> LoadPremiacaoBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.LoadPremiacaoBolao(bolao);
        }
         
        #endregion

    }
}
