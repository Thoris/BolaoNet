using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Facade.Campeonatos
{
    public class CopaMundo2018FacadeApp : Interfaces.Facade.Campeonatos.ICopaMundo2018FacadeApp
    {
        #region Variables

        private Domain.Interfaces.Services.Facade.Campeonatos.ICopaMundo2018FacadeService _service;

        #endregion


        #region Properties

        public bool IsContainsResults { get { return _service.IsContainsResults; } }

        #endregion

        #region Constructors/Destructors

        public CopaMundo2018FacadeApp(Domain.Interfaces.Services.Facade.Campeonatos.ICopaMundo2018FacadeService service)
        {
            _service = service;
        }

        #endregion

        #region ICopaMundo2018FacadeApp members

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
