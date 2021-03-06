﻿using BolaoNet.Services.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.Services.Areas.Boloes.Controllers
{
    public class BolaoPontuacaoController:
        GenericApiController<Domain.Entities.Boloes.BolaoPontuacao>,
        Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService 
    {
        #region Properties

        /// <summary>
        /// Propriedade que retorna o objeto que possui regras de negócio do gerenciamento da entidade.
        /// </summary>
        private Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService)base.BaseBo; }
        }

        #endregion

        #region Constructors/Destructors

        //public BolaoPontuacaoController()
        //    : base(new Domain.Services.FactoryService(null).CreateBolaoPontuacaoService())
        //{

        //}
        public BolaoPontuacaoController(Domain.Interfaces.Services.Boloes.IBolaoPontuacaoService service)
            : base(service)
        {

        }

        #endregion

        #region Methods


        #endregion
    }
}