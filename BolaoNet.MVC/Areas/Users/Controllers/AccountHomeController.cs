using AutoMapper;
using BolaoNet.MVC.Helpers;
using BolaoNet.MVC.Security;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Users.Controllers
{
    [AuthorizeRoles]
    public class AccountHomeController : BaseUserAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoApp _bolaoApp;
        private Application.Interfaces.Boloes.IBolaoMembroGrupoApp _bolaoMembroGrupoApp;
        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private Application.Interfaces.Users.IUserApp _userApp;

        #endregion

        #region Constructors/Destructors

        public AccountHomeController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Users.IUserApp userApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp, 
            Application.Interfaces.Boloes.IBolaoMembroGrupoApp bolaoMembroGrupoApp,
            Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp
            )
            : base(bolaoApp, bolaoMembroApp)
        {
            _bolaoApp = bolaoApp;
            _bolaoMembroGrupoApp = bolaoMembroGrupoApp;
            _jogoUsuarioApp = jogoUsuarioApp;
            _userApp = userApp;
        }

        #endregion

        #region Methods

        private string LoadFile(string file)
        {
            if (!System.IO.File.Exists(file))
                return "";


            StreamReader reader = new StreamReader(file);

            string fileString = reader.ReadToEnd();

            fileString = fileString.Replace("\n", "<br/>");

            reader.Close();

            return fileString;

        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Index ()
        {
            int totalProximoJogo = 5;
            int totalPontosObtidos = 5;


            ViewModels.Users.PaginaPrincipalModelView model = new ViewModels.Users.PaginaPrincipalModelView();


            IList<Domain.Entities.ValueObjects.UserBoloesVO> listBoloes = _bolaoApp.GetBoloesUsuario(base.UserLogged);

            model.Posicoes =
                Mapper.Map<
                IList<Domain.Entities.ValueObjects.UserBoloesVO>, 
                IList<ViewModels.Users.PaginaPrincipal.PaginaPrincipalBolaoPosicoesViewModel>
                >(listBoloes);


            IList<Domain.Entities.ValueObjects.UserSaldoBolaoVO> listSaldo = _bolaoApp.GetBoloesSaldoUsuario(base.UserLogged);


            for (int c = 0; c < listSaldo.Count; c++)
            {
                if (listSaldo[c].TaxaParticipacao == listSaldo[c].Valor)
                {
                    listSaldo.RemoveAt(c);
                    c--;
                }
                else
                {
                    listSaldo[c].Valor = listSaldo[c].Valor - listSaldo[c].TaxaParticipacao; 
                }
            }

            model.Saldo =
                Mapper.Map<
                IList<Domain.Entities.ValueObjects.UserSaldoBolaoVO>,
                IList<ViewModels.Users.PaginaPrincipal.PaginaPrincipalBolaoSaldoDevedorViewModel>
                >(listSaldo);

            


                if (base.SelectedBolao != null && !string.IsNullOrEmpty(base.SelectedBolao.Nome))
                {
                    IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO> listClassificacao =
                        _bolaoMembroGrupoApp.LoadClassificacao(base.SelectedBolao, base.UserLogged);

                    listClassificacao = listClassificacao.OrderByDescending(x => x.TotalPontos).ToList();


                    model.ComparacaoMembros =
                        Mapper.Map<
                        IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO>,
                        IList<ViewModels.Users.PaginaPrincipal.PaginaPrincipalGrupoComparacaoModelView>
                        >(listClassificacao);

                    for (int c = 0; c < model.ComparacaoMembros.Count; c++)
                    {
                        if (c == 0)
                            model.ComparacaoMembros[c].PosicaoIndividual = 1;
                        else
                        {
                            if (model.ComparacaoMembros[c].TotalPontos ==
                                model.ComparacaoMembros[c - 1].TotalPontos)
                            {
                                model.ComparacaoMembros[c].PosicaoIndividual = model.ComparacaoMembros[c - 1].PosicaoIndividual;
                            }
                            else
                            {
                                model.ComparacaoMembros[c].PosicaoIndividual = c + 1;
                            }
                        }

                    }
                }
                else
                {
                    model.ComparacaoMembros = new List<ViewModels.Users.PaginaPrincipal.PaginaPrincipalGrupoComparacaoModelView>();
                }


            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> proximos = 
                _jogoUsuarioApp.LoadProximosJogosUsuario(base.UserLogged, totalProximoJogo);

            model.ProximasApostas = Mapper.Map<
                    IList<Domain.Entities.ValueObjects.JogoUsuarioVO>,
                    IList<ViewModels.Users.PaginaPrincipal.PaginaPrincipalProximaApostaViewModel>
                    >(proximos);



            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> obtidos =
                _jogoUsuarioApp.LoadPontosObtidos(base.UserLogged, totalPontosObtidos);

            model.PontosObtidos = Mapper.Map<
                    IList<Domain.Entities.ValueObjects.JogoUsuarioVO>,
                    IList<ViewModels.Users.PaginaPrincipal.PaginaPrincipalPontosObtidosViewModel>
                    >(obtidos);

            
            return View(model);
        }

        [HttpGet]
        public new ActionResult Profile()
        {

            Domain.Entities.Users.User userLoaded = _userApp.Load(base.UserLogged);

            ViewModels.Users.UserProfileViewModel model =
                Mapper.Map<Domain.Entities.Users.User, ViewModels.Users.UserProfileViewModel>(userLoaded);

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public new ActionResult Profile(ViewModels.Users.UserProfileViewModel model)
        {
            Domain.Entities.Users.User userLoaded = _userApp.Load(base.UserLogged);

            if (!ModelState.IsValid)
            {
                model = Mapper.Map<Domain.Entities.Users.User, ViewModels.Users.UserProfileViewModel>(userLoaded);

                return View("Profile", model);
            }


            userLoaded.FullName = model.FullName;
            userLoaded.Male = model.Male;
            userLoaded.BirthDate = model.BirthDate;
            userLoaded.PhoneNumber = model.PhoneNumber;
            userLoaded.CellPhone = model.CellPhone;
            userLoaded.PostalCode = model.PostalCode;
            userLoaded.Country = model.Country;
            userLoaded.State = model.State;
            userLoaded.Street = model.Street;
            userLoaded.StreetNumber = model.StreetNumber;
            userLoaded.ReceiveEmails = model.ReceiveEmails;

            _userApp.Update(userLoaded);



            base.ShowMessage("Dados do perfil inseridos com sucesso.");

            return RedirectToAction("Index");
        }

        public ActionResult ConfigurarGrupoComparacao()
        {
            return RedirectToAction("Index", "BolaoClassificacaoGrupoGerenciamento");
        }

        #region Comments
        //public ActionResult ChangeProfileImage()
        //{
        //    return View();
        //}

        //[HttpPost]
        //public virtual ActionResult CropImage(
        //    string imagePath,
        //    int? cropPointX,
        //    int? cropPointY,
        //    int? imageCropWidth,
        //    int? imageCropHeight)
        //{
        //    if (string.IsNullOrEmpty(imagePath)
        //        || !cropPointX.HasValue
        //        || !cropPointY.HasValue
        //        || !imageCropWidth.HasValue
        //        || !imageCropHeight.HasValue)
        //    {
        //        return new HttpStatusCodeResult((int)HttpStatusCode.BadRequest);
        //    }

        //    byte[] imageBytes = System.IO.File.ReadAllBytes(Server.MapPath(imagePath));
        //    byte[] croppedImage = ImageHelper.CropImage(imageBytes, cropPointX.Value, cropPointY.Value, imageCropWidth.Value, imageCropHeight.Value);

        //    //string tempFolderName = Server.MapPath("~/" + ConfigurationManager.AppSettings["Image.TempFolderName"]);

        //    string tempFolderName = Server.MapPath("~/" + "Temp");
            
            
        //    string fileName = Path.GetFileName(imagePath);

        //    try
        //    {
        //        FileHelper.SaveFile(croppedImage, Path.Combine(tempFolderName, fileName));
        //    }
        //    catch (Exception ex)
        //    {
        //        //Log an error     
        //        return new HttpStatusCodeResult((int)HttpStatusCode.InternalServerError);
        //    }

        //    //string photoPath = string.Concat("/", ConfigurationManager.AppSettings["Image.TempFolderName"], "/", fileName);
        //    string photoPath = string.Concat("/", "Temp", "/", fileName);
        //    return Json(new { photoPath = photoPath }, JsonRequestBehavior.AllowGet);
        //}
        #endregion

        [HttpGet]
        public ActionResult ChangePassword()
        {
            ViewModels.Users.UserChangePasswordViewModel model = new ViewModels.Users.UserChangePasswordViewModel();
            model.UserName = base.UserLogged.UserName;


            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePassword(ViewModels.Users.UserChangePasswordViewModel model)
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

            Domain.Entities.Users.User userLoaded = _userApp.Load(base.UserLogged);

            if (string.Compare (model.NewPassword, userLoaded.Password, true) != 0)
            {
                ModelState.AddModelError("", "Senha inválida.");
                return View("ChangePassword", model);
            }

            userLoaded.Password = model.NewPassword;

            bool updated =_userApp.Update(userLoaded);

            if (updated)
                base.ShowMessage("Senha alterada.");
            else
                base.ShowErrorMessage("Erro ao alterar a senha");

            return RedirectToAction("Index");
        }

        public ActionResult Logoff()
        {
             return base.Logout();            
        }

        public ActionResult ReleaseNotes()
        {
            string file = Server.MapPath(@"~\ReleaseNotes.txt");

            string notes = LoadFile(file);

            ViewModels.Users.ReleaseNotesViewModel model = new ViewModels.Users.ReleaseNotesViewModel();
            model.Data = notes;

            return View(model);
        }

        #endregion
    }
}