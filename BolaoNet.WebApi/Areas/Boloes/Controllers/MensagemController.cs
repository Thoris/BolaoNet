﻿using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class MensagemController:
        GenericApiController<Domain.Entities.Boloes.Mensagem>, 
        Domain.Interfaces.Services.Boloes.IMensagemService
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IMensagemService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IMensagemService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public MensagemController()
        //    : base(new Domain.Services.FactoryService(null).CreateMensagemService())
        //{

        //}
        public MensagemController(Domain.Interfaces.Services.Boloes.IMensagemService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion

        #region IMensagemService members

        [HttpPost]
        public IList<Domain.Entities.Boloes.Mensagem> GetMensagensUsuario(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetMensagensUsuario(bolao, user);
        }

        #endregion
    }
}