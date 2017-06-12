using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class PontuacaoApp :
        Base.GenericApp<Domain.Entities.Boloes.Pontuacao>,
        Application.Interfaces.Boloes.IPontuacaoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IPontuacaoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IPontuacaoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="PontuacaoApp" />.
        /// </summary>
        public PontuacaoApp(Domain.Interfaces.Services.Boloes.IPontuacaoService service)
            : base (service)
        {

        }

        #endregion
    }
}
