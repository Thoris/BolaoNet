﻿using BolaoNet.MVC.Controllers;
using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Areas.Regras.Controllers
{
    [AuthorizeRoles(PermissionLevel.Administrador , PermissionLevel.Apostador , PermissionLevel.VisitanteBolao)]        
    public class BaseBolaoRegrasAreaController: BaseBolaoController
    {
        #region Constructors/Destructors

        public BaseBolaoRegrasAreaController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            
        }

        #endregion
    
    }
}