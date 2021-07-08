using AutoMapper;
using BolaoNet.MVC.Controllers;
using BolaoNet.MVC.Security;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Admin.Controllers
{
    [AuthorizeRoles(PermissionLevel.Administrador)]
    public class UserController : AuthorizationController
    {
        #region Variables

        private Application.Interfaces.Users.IUserApp _userApp;
        private Application.Interfaces.Users.IUserInRoleApp _userInRoleApp;
        private Application.Interfaces.Users.IRoleApp _roleApp;

        #endregion


        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="UserController"/>.
        /// </summary>
        /// <param name="userApp">Objeto de gerenciamento de usuário.</param>
        /// <param name="userInRoleApp">Objeto de gerenciamento de roles dos usuários.</param>
        /// <param name="roleApp">Objeto de gerencia de Roles.</param>
        public UserController(
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
            IList<Domain.Entities.Users.User> list =
                _userApp.GetAll().ToList();

            IList<BolaoNet.MVC.ViewModels.Admin.UserProfileViewModel> model =
                Mapper.Map<
                IList<Domain.Entities.Users.User>,
                IList<MVC.ViewModels.Admin.UserProfileViewModel>>
                (list);

            return View(model);
        }
        
        /// <summary>
        /// Método que exclui um usuário da base de dados.
        /// </summary>
        /// <param name="model">Modelo de dados.</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Delete(ViewModels.Admin.UserProfileViewModel model)
        {
            //if (!ModelState.IsValid)
            //{
            //    return RedirectToAction("Index");
            //}

            string userNameFix = Helpers.StringHelper.EncodeString(model.UserName);

            Domain.Entities.Users.User entity = new Domain.Entities.Users.User(userNameFix);

            Domain.Entities.Users.User entityLoaded = _userApp.Load(entity);

            _userApp.Delete(entityLoaded);

            base.ShowMessage("Usuário excluído com sucesso.");

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Ação que carrega a página para editar um usuário.
        /// </summary>
        /// <param name="userName">Usuário a ser editado.</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Edit(string userName)
        {
            string userNameFix = Helpers.StringHelper.EncodeString(userName);

            Domain.Entities.Users.User entry =
                new Domain.Entities.Users.User(userNameFix);

            Domain.Entities.Users.User entryLoaded = _userApp.Load(entry);

            ViewModels.Admin.UserProfileViewModel model =
               Mapper.Map<Domain.Entities.Users.User,
               ViewModels.Admin.UserProfileViewModel>
               (entryLoaded);

            return View(model);
        }

        /// <summary>
        /// Ação que efetiva a alteração do item na base de dados.
        /// </summary>
        /// <param name="model">Modelo de dados.</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ViewModels.Admin.UserProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Edit", model);
            }

            Domain.Entities.Users.User entity =
                Mapper.Map<ViewModels.Admin.UserProfileViewModel,
                Domain.Entities.Users.User>(model);

            Domain.Entities.Users.User entityLoaded = _userApp.Load(entity);

            entityLoaded.BirthDate = model.BirthDate;
            entityLoaded.CellPhone = model.CellPhone;
            entityLoaded.City = model.City;
            entityLoaded.Country = model.Country;
            entityLoaded.Email = model.Email;
            entityLoaded.FullName = model.FullName;
            entityLoaded.Male = model.Male;
            entityLoaded.PhoneNumber = model.PhoneNumber;
            entityLoaded.PostalCode = model.PostalCode;
            entityLoaded.State = model.State;
            entityLoaded.Street = model.Street;
            entityLoaded.StreetNumber = model.StreetNumber;

            _userApp.Update(entityLoaded);

            base.ShowMessage("Usuário editado com sucesso.");

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Ação que carrga a página com detalhes do usuário.
        /// </summary>
        /// <param name="modelEntry">Modelo de dados.</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult Details(ViewModels.Admin.UserProfileViewModel modelEntry)
        {

            string userNameFix = (modelEntry.UserName);

            Domain.Entities.Users.User entity = new Domain.Entities.Users.User(userNameFix);

            Domain.Entities.Users.User entityLoaded = _userApp.Load(entity);

            ViewModels.Admin.UserProfileViewModel model =
              Mapper.Map<
              Domain.Entities.Users.User,
              ViewModels.Admin.UserProfileViewModel>
              (entityLoaded);

            IList<Domain.Entities.Users.Role> usersInRole = _userInRoleApp.GetRolesInUser(entityLoaded);

            model.Roles =
                  Mapper.Map<
                  IList<Domain.Entities.Users.Role>,
                  IList<ViewModels.Admin.RoleViewModel>>
                  (usersInRole);

            IList<Domain.Entities.Users.Role> roles = _roleApp.GetAll().ToList();

            for (int c = 0; c < usersInRole.Count; c++)
            {
                for (int i = 0; i < roles.Count; i++)
                {
                    if (string.Compare(usersInRole[c].RoleName, roles[i].RoleName, true) == 0)
                    {
                        roles.RemoveAt(i);
                        break;
                    }
                }
            }

            model.AvailableRoles =
                  Mapper.Map<IList<Domain.Entities.Users.Role>,
                  IList<ViewModels.Admin.RoleViewModel>>(roles);


            return View(model);
        }

        /// <summary>
        /// Ação que carrega a página para alteração da senha do usuário.
        /// </summary>
        /// <param name="userName">Usuário a ser modificado.</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult ChangePassword(string userName)
        {
            string userNameFix = Helpers.StringHelper.EncodeString(userName);

            ViewModels.Admin.UserChangePasswordViewModel model =
                new ViewModels.Admin.UserChangePasswordViewModel();
            model.UserName = userNameFix;

            return View(model);
        }

        /// <summary>
        /// Ação que efetiva a alteração da senha do usuário.
        /// </summary>
        /// <param name="model">Modelo de dados.</param>
        /// <returns>View</returns>
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ViewModels.Admin.UserChangePasswordViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("ChangePassword", model);
            }

            if (string.Compare(model.NewPassword, model.ConfirmPassword) != 0)
            {
                ModelState.AddModelError("", "Confirmação de senha inválida.");
                return View("ChangePassword", model);
            }

            Domain.Entities.Users.User entryToLoad = new Domain.Entities.Users.User(model.UserName);

            Domain.Entities.Users.User userLoaded = _userApp.Load(entryToLoad);


            userLoaded.Password = model.NewPassword;

            bool updated = _userApp.Update(userLoaded);

            if (updated)
                base.ShowMessage("Senha alterada.");
            else
                base.ShowErrorMessage("Erro ao alterar a senha");

            return RedirectToAction("Index");
        }

        /// <summary>
        /// Ação que adiciona uma role a um usuário.
        /// </summary>
        /// <param name="model">Modelo de dados.</param>
        /// <returns></returns>
        [HttpPost]
        public ActionResult AddUser(ViewModels.Admin.UserProfileViewModel model)
        {
            Domain.Entities.Users.UserInRole entry =
                new Domain.Entities.Users.UserInRole(
                    (model.UserName),
                    (model.SelectedRoleName));

            _userInRoleApp.Insert(entry);

            return RedirectToAction("Details", new { userName = entry.UserName });
        }

        /// <summary>
        /// Ação que remove uma role de um usuário.
        /// </summary>
        /// <param name="model">Modelo de dados.</param>
        /// <returns>View</returns>
        [HttpGet]
        public ActionResult RemoveUser(ViewModels.Admin.UserProfileViewModel model)
        {
            Domain.Entities.Users.UserInRole entry =
                new Domain.Entities.Users.UserInRole(
                    (model.UserName),
                    (model.SelectedRoleName));

            Domain.Entities.Users.UserInRole entryLoaded = _userInRoleApp.Load(entry);

            _userInRoleApp.Delete(entryLoaded);

            return RedirectToAction("Details", new { userName = entry.UserName });
        }

        #endregion
    }
}