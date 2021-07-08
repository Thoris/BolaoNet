using AutoMapper;
using BolaoNet.MVC.Controllers;
using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Admin.Controllers
{
    /// <summary>
    /// Controler que gerencia roles.
    /// </summary>
    [AuthorizeRoles(PermissionLevel.Administrador)]
    public class RoleController : AuthorizationController
    {
        #region Variables

        private Application.Interfaces.Users.IUserApp _userApp;
        private Application.Interfaces.Users.IUserInRoleApp _userInRoleApp;
        private Application.Interfaces.Users.IRoleApp _roleApp;

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="RoleController"/>.
        /// </summary>
        /// <param name="userApp">Gerenciamento de usuário.</param>
        /// <param name="userInRoleApp">Gerenciamento de Role por usuário.</param>
        /// <param name="roleApp">Gerenciamento de role.</param>
        public RoleController(
            Application.Interfaces.Users.IUserApp userApp,
            Application.Interfaces.Users.IUserInRoleApp userInRoleApp,
            Application.Interfaces.Users.IRoleApp roleApp
            )
        {
            _userApp = userApp;
            _userInRoleApp = userInRoleApp;
            _roleApp = roleApp;
        }

        #endregion


        #region Actions

        /// <summary>
        /// Ação que carrega a página principal.
        /// </summary>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Index()
        {
            IList<Domain.Entities.Users.Role> list = _roleApp.GetAll().ToList();

            IList<MVC.ViewModels.Admin.RoleViewModel> model =
                Mapper.Map<
                IList<Domain.Entities.Users.Role>,
                IList<MVC.ViewModels.Admin.RoleViewModel>>
                (list);

            return View(model);
        }
         
        /// <summary>
        /// Ação que exclui um determinado item.
        /// </summary>
        /// <param name="modelEntry">Modelo de dados.</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Delete(MVC.ViewModels.Admin.RoleViewModel modelEntry)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            string fixName = MVC.Helpers.StringHelper.EncodeString(modelEntry.RoleName);

            Domain.Entities.Users.Role entity = new Domain.Entities.Users.Role(fixName);

            Domain.Entities.Users.Role entityLoaded = _roleApp.Load(entity);

            _roleApp.Delete(entityLoaded);

            base.ShowMessage("Grupo de usuário excluído com sucesso.");

            return RedirectToAction("Index");
        }
         
        /// <summary>
        /// Ação que carrega a página de visualização de detalhes de uma role.
        /// </summary>
        /// <param name="modelEntry">Modelo de dados.</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Details(MVC.ViewModels.Admin.RoleViewModel modelEntry)
        {
            //string roleName = modelEntry.RoleName;
            //string fixName = Helpers.StringHelper.EncodeString(roleName);

            string fixName = modelEntry.RoleName;

            Domain.Entities.Users.Role entity = new Domain.Entities.Users.Role(fixName);

            Domain.Entities.Users.Role entityLoaded = _roleApp.Load(entity);

            MVC.ViewModels.Admin.RoleViewModel model =
              Mapper.Map<
              Domain.Entities.Users.Role,
              MVC.ViewModels.Admin.RoleViewModel>
              (entityLoaded);

            IList<Domain.Entities.Users.User> usersInRole = _userInRoleApp.GetUsersInRole(entityLoaded);

            model.Users =
                  Mapper.Map<
                  IList<Domain.Entities.Users.User>,
                  IList<MVC.ViewModels.Admin.UserProfileViewModel>>
                  (usersInRole);

            IList<Domain.Entities.Users.User> users = _userApp.GetAll().ToList();

            for (int c = 0; c < usersInRole.Count; c++)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (string.Compare(usersInRole[c].UserName, users[i].UserName, true) == 0)
                    {
                        users.RemoveAt(i);
                        break;
                    }
                }
            }

            model.AvailableUsers =
                  Mapper.Map<
                  IList<Domain.Entities.Users.User>,
                  IList<MVC.ViewModels.Admin.UserProfileViewModel>>
                  (users);

            return View(model);
        }

        /// <summary>
        /// Ação que adiciona um novo usuário a role carregada.
        /// </summary>
        /// <param name="model">Modelo de dados.</param>
        /// <returns>View</returns>
        [HttpPost]
        public ActionResult AddUser(MVC.ViewModels.Admin.RoleViewModel model)
        {
            Domain.Entities.Users.UserInRole entry =
                new Domain.Entities.Users.UserInRole(
                    (model.SelectedUserName),
                    (model.RoleName));

            _userInRoleApp.Insert(entry);

            return RedirectToAction("Details", new { roleName = entry.RoleName });
        }

        /// <summary>
        /// Ação que remove um usuário da lista de uma role.
        /// </summary>
        /// <param name="model">Modelo de dados.</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult RemoveUser(MVC.ViewModels.Admin.RoleViewModel model)
        {
            Domain.Entities.Users.UserInRole entry =
                new Domain.Entities.Users.UserInRole(
                    (model.SelectedUserName),
                    (model.RoleName));

            Domain.Entities.Users.UserInRole entryLoaded = _userInRoleApp.Load(entry);

            _userInRoleApp.Delete(entryLoaded);

            return RedirectToAction("Details", new { roleName = entry.RoleName });
        }

        #endregion
    }
}