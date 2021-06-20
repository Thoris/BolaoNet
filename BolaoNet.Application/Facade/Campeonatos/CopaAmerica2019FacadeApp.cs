using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Facade.Campeonatos
{
    public class CopaAmerica2019FacadeApp : Interfaces.Facade.Campeonatos.ICopaAmerica2019FacadeApp
    {
        #region Variables

        private Domain.Interfaces.Services.Facade.Campeonatos.ICopaAmerica2019FacadeService _service;

        #endregion

        #region Properties

        public bool IsContainsResults 
        {
            get { return _service.IsContainsResults ; } 
        } 

        #endregion

        #region Constructors/Destructors

        public CopaAmerica2019FacadeApp(Domain.Interfaces.Services.Facade.Campeonatos.ICopaAmerica2019FacadeService service)
        {
            _service = service;
        }

        #endregion

        #region ICopaAmerica2019FacadeApp members

        public Domain.Entities.Campeonatos.Campeonato CreateCampeonato(string nomeCampeonato, bool isClube)
        {
            return _service.CreateCampeonato(nomeCampeonato, isClube);
        }

        public bool InsertResults(string nomeCampeonato, Domain.Entities.Users.User validatedBy)
        {
            return _service.InsertResults(nomeCampeonato, validatedBy);
        }

        #endregion
    }
}
