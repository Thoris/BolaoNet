using BolaoNet.MVC.Controllers;
using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BolaoNet.MVC.Areas.Pontuacao.Controllers
{
    [AuthorizeRoles(PermissionLevel.Administrador , PermissionLevel.GerenciadorPontuacao)]        
    public class BasePontosAreaController : BaseBolaoController
    {
        #region Constructors/Destructors

        public BasePontosAreaController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base
            (
                bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, 
                campeonatoGrupoApp, campeonatoTimeApp
            )
        {

        }

        #endregion

    }
}