using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class PontuacaoApp :
        Base.GenericApp<Domain.Entities.Campeonatos.Pontuacao>,
        Domain.Interfaces.Services.Campeonatos.IPontuacaoService
    {
        #region Properties

        private Domain.Interfaces.Services.Campeonatos.IPontuacaoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.IPontuacaoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="PontuacaoApp" />.
        /// </summary>
        public PontuacaoApp(Domain.Interfaces.Services.Campeonatos.IPontuacaoService service)
            : base (service)
        {

        }

        #endregion
    }
}
