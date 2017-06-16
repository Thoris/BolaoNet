using BolaoNet.Services.Controllers;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.WebApi.Areas.Facade.Controllers
{
    public class CopaMundo2014FacadeController : AuthorizationController,
        Domain.Interfaces.Services.Facade.Campeonatos.ICopaMundo2014FacadeService
    {
        #region Variables

        private Domain.Interfaces.Services.Facade.Campeonatos.ICopaMundo2014FacadeService _service;

        #endregion

        #region Constructors/Destructors

        public CopaMundo2014FacadeController(Domain.Interfaces.Services.Facade.Campeonatos.ICopaMundo2014FacadeService service)
        {
            _service = service;
        }

        #endregion

        #region ICopaMundo2014FacadeService members

        [HttpPost]
        public Domain.Entities.Campeonatos.Campeonato CreateCampeonato(int id, ArrayList data)
        {
            string nomeCampeonato = data[0].ToString();
            bool isClube = bool.Parse (data[1].ToString());

            return this.CreateCampeonato(nomeCampeonato, isClube);
        }

        [HttpPost]
        public Domain.Entities.Campeonatos.Campeonato CreateCampeonato(string nomeCampeonato, bool isClube)
        {
            return _service.CreateCampeonato(nomeCampeonato, isClube);
        }

        [HttpPost]
        public bool InsertResults(Domain.Entities.Users.User validatedBy)
        {
            return _service.InsertResults(validatedBy);
        }

        #endregion
    }
}