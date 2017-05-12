using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.TestsVS.IntegrationTests
{
    public class CampeonatoIntegrationTests
    {
        #region Variables

        //private Business.Interfaces.Campeonatos.ICampeonatoBO _campeonatoBO;
        

        #endregion

        #region Constructors/Destructors

        public CampeonatoIntegrationTests()
        {

        }

        #endregion

        #region Methods

        public void CreateCampeonatoCopa2014()
        {
            Entities.Campeonatos.Campeonato campeonato = new Entities.Campeonatos.Campeonato()
            {
                Nome = "Copa do Mundo 2014"
            };
        }

        #endregion
    }
}
