using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Mensagens.Controllers
{
    public class GerenciamentoController : BaseMensagensAreaController
    {       
        #region Constructors/Destructors

        public GerenciamentoController(
            Application.Interfaces.Boloes.IMensagemApp mensagemApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp            
            )
            : base 
            (
                mensagemApp, bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp
            )
        {
            
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            _mensagemApp.SetMensagensLidas(base.SelectedBolao, base.UserLogged);

            IList<Domain.Entities.Boloes.Mensagem> list =
               _mensagemApp.GetMensagensUsuario(base.SelectedBolao, base.UserLogged);


            IList<ViewModels.Mensagens.MensagemViewModel> model =
                Mapper.Map<
                IList<Domain.Entities.Boloes.Mensagem>,
                IList<ViewModels.Mensagens.MensagemViewModel>>
                (list);

            Session["MensagemPendente"] = null;

            return View(model);

            
        }
        [HttpGet]
        public ActionResult Create()
        {
            IList<Domain.Entities.Boloes.BolaoMembro> membros =
                _bolaoMembroApp.GetListUsersInBolao(base.SelectedBolao);

            ViewBag.Membros = membros;

            ViewModels.Mensagens.MensagemViewModel model = new ViewModels.Mensagens.MensagemViewModel();

            model.NomeBolao = base.SelectedNomeBolao;
            model.FromUser = base.UserLogged.UserName;

            return View(model);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ViewModels.Mensagens.MensagemViewModel model)
        {
            bool invalid = false;
            Domain.Entities.Boloes.Mensagem entity = null;

            if (!ModelState.IsValid)
            {
                invalid = true;
            }
            else
            {

                entity =
                    Mapper.Map<ViewModels.Mensagens.MensagemViewModel,
                    Domain.Entities.Boloes.Mensagem>(model);

                //if (_mensagemApp.Load(entity) != null)
                //{
                //    ModelState.AddModelError("", "Pagamento do usuário já existe.");
                //    invalid = true;
                //}
            }


            if (invalid)
            {

                IList<Domain.Entities.Boloes.BolaoMembro> membros =
               _bolaoMembroApp.GetListUsersInBolao(base.SelectedBolao);

                ViewBag.Membros = membros;

                return View("Create", model);
            }


            entity.CreationDate = DateTime.Now;
            entity.FromUser = base.UserLogged.UserName;
                

            _mensagemApp.Insert(entity);


            base.ShowMessage("Mensagem enviada com sucesso.");


            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(string nomeBolao, int messageID)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }

            Domain.Entities.Boloes.Mensagem entity =
                new Domain.Entities.Boloes.Mensagem(nomeBolao, messageID);
 


            Domain.Entities.Boloes.Mensagem mensagemLoaded = _mensagemApp.Load(entity);


            _mensagemApp.Delete(mensagemLoaded);


            base.ShowMessage("Mensagem excluída com sucesso.");

            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult View(string nomeBolao, int messageID)
        {
            return View();
        }

        #endregion
    }
}