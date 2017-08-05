using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Admin.Controllers
{
    public class BolaoIniciarPararController: BaseAdminAreaController
    {
        #region Constants

        private const string FolderApostas = "~/Content/img/database/apostas/";
        private const string FileApostasInicial = "ApostasIniciais";
        private const string FileApostasFinal = "ApostasFinais";
        private const string ExtensionFileApostas = ".pdf";
        private const string CompressedFile = ".zip";

        #endregion

        #region Variables

        private Application.Interfaces.Reports.IBolaoMembroApostasReportApp _bolaoMembroApostasReportApp;
        private Application.Interfaces.Reports.IBolaoApostasInicioReportApp _bolaoApostasInicioReportApp;
        private Application.Interfaces.Reports.IBolaoApostasFimReportApp _bolaoApostasFimReportApp;
        private Application.Interfaces.Notification.INotificationApp _notificationApp;

        #endregion

        #region Constructors/Destructors

        public BolaoIniciarPararController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.Reports.IBolaoMembroApostasReportApp bolaoMembroApostasReportApp,
            Application.Interfaces.Reports.IBolaoApostasInicioReportApp bolaoApostasInicioReportApp,
            Application.Interfaces.Reports.IBolaoApostasFimReportApp bolaoApostasFimReportApp,
            Application.Interfaces.Notification.INotificationApp notificationApp
            )
            : base (bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _bolaoMembroApostasReportApp = bolaoMembroApostasReportApp;
            _bolaoApostasInicioReportApp = bolaoApostasInicioReportApp;
            _bolaoApostasFimReportApp = bolaoApostasFimReportApp;
            _notificationApp = notificationApp;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {

            Domain.Entities.Boloes.Bolao bolaoLoaded = _bolaoApp.Load(base.SelectedBolao);


            ViewModels.Admin.BolaoIniciarPararViewModel model =
                 Mapper.Map<Domain.Entities.Boloes.Bolao, ViewModels.Admin.BolaoIniciarPararViewModel>(bolaoLoaded);



            model.StatusMembros = new List<ViewModels.Admin.BolaoIniciarStatusMembroViewModel>();


            IList<Domain.Entities.ValueObjects.UserMembroStatusVO> listMembros =
                _bolaoMembroApp.GetUserStatus(base.SelectedBolao);


            IList<ViewModels.Admin.BolaoIniciarStatusMembroViewModel> membrosModel =
                 Mapper.Map<
                 IList<Domain.Entities.ValueObjects.UserMembroStatusVO>,
                 IList<ViewModels.Admin.BolaoIniciarStatusMembroViewModel>>
                 (listMembros);


            for (int c = 0; c < membrosModel.Count; c++)
            {
                if (membrosModel[c].Pago != 0)
                {
                    membrosModel[c].FaltaPagamento = true;
                }

                if (membrosModel[c].Restantes > 0)
                {
                    membrosModel[c].ApostasRestantes = true;
                }
            }

            model.StatusMembros = membrosModel;


            string fileToCheck = Server.MapPath(System.IO.Path.Combine(FolderApostas, FileApostasInicial + ExtensionFileApostas));
            if (System.IO.File.Exists(fileToCheck))
                model.FileApostasInicial = new FileInfo(fileToCheck);

            fileToCheck = Server.MapPath(System.IO.Path.Combine(FolderApostas, FileApostasFinal + ExtensionFileApostas));
            if (System.IO.File.Exists(fileToCheck))
                model.FileApostasFinal = new FileInfo(fileToCheck);

            fileToCheck = Server.MapPath(System.IO.Path.Combine(FolderApostas, FileApostasInicial + CompressedFile));
            if (System.IO.File.Exists(fileToCheck))
                model.FileApostasInicialZip = new FileInfo(fileToCheck);

            fileToCheck = Server.MapPath(System.IO.Path.Combine(FolderApostas, FileApostasFinal + CompressedFile));
            if (System.IO.File.Exists(fileToCheck))
                model.FileApostasFinalZip = new FileInfo(fileToCheck);



            return View(model);
        }        
        public ActionResult Iniciar()
        {
            bool res = _bolaoApp.Iniciar(base.UserLogged, base.SelectedBolao);

            base.IsBolaoIniciado = true;


            base.ShowMessage("Bolão iniciado com sucesso.");

            return RedirectToAction("Index");
        }
        public ActionResult Aguardar()
        {

            bool res = _bolaoApp.Aguardar(base.SelectedBolao);

            base.IsBolaoIniciado = false;


            base.ShowMessage("Bolão alterado com status de aguardando.");

            return RedirectToAction("Index");
        }
        public ActionResult RemoverMembro(ViewModels.Admin.BolaoIniciarStatusMembroViewModel model)
        {
            if (string.IsNullOrEmpty(model.UserName))
            {
                _bolaoMembroApp.RemoverMembroBolao(base.SelectedBolao, new Domain.Entities.Boloes.BolaoMembro(base.SelectedNomeBolao, model.UserName));
            }
            return RedirectToAction("Index");
        }
        public ActionResult DownloadApostas(string userName)
        {
            Domain.Entities.ValueObjects.Reports.BolaoMembroApostasVO data =
                _bolaoMembroApostasReportApp.GetData(base.SelectedBolao, new Domain.Entities.Users.User(userName));

            Stream streamReport = _bolaoMembroApostasReportApp.Generate(
                "gif",
                Server.MapPath("~/Content/img/database/profiles"),
                Server.MapPath("~/Content/img/database/times"), data);


            return base.DownloadStream(streamReport, "text/plain", userName + ".pdf");
        }
        public ActionResult GerarApostas()
        {

            Domain.Entities.ValueObjects.Reports.BolaoIniciarVO data =
                _bolaoApostasInicioReportApp.GetData(base.SelectedBolao);


            string fileToCheck = Server.MapPath(System.IO.Path.Combine(FolderApostas, FileApostasInicial + ExtensionFileApostas));
            if (System.IO.File.Exists(fileToCheck))
                System.IO.File.Delete(fileToCheck);

            string fileToCheckZip = Server.MapPath(System.IO.Path.Combine(FolderApostas, FileApostasInicial + CompressedFile));
            if (System.IO.File.Exists(fileToCheckZip))
                System.IO.File.Delete(fileToCheckZip);

            Stream streamReport = _bolaoApostasInicioReportApp.Generate(
                            fileToCheck,
                            fileToCheckZip,
                           "gif",
                           Server.MapPath("~/Content/img/database/profiles"),
                           Server.MapPath("~/Content/img/database/times"), data);

            base.ShowMessage("Arquivo de apostas iniciais gerado com sucesso.");

            return RedirectToAction("Index");
        }
        public ActionResult GerarFinal()
        {
            Domain.Entities.ValueObjects.Reports.BolaoFinalVO data =
               _bolaoApostasFimReportApp.GetData(base.SelectedBolao);


            string fileToCheck = Server.MapPath(System.IO.Path.Combine(FolderApostas, FileApostasFinal + ExtensionFileApostas));
            if (System.IO.File.Exists(fileToCheck))
                System.IO.File.Delete(fileToCheck);

            string fileToCheckZip = Server.MapPath(System.IO.Path.Combine(FolderApostas, FileApostasFinal + CompressedFile));
            if (System.IO.File.Exists(fileToCheckZip))
                System.IO.File.Delete(fileToCheckZip);

            Stream streamReport = _bolaoApostasFimReportApp.Generate(
                            fileToCheck,
                            fileToCheckZip,
                           "gif",
                           Server.MapPath("~/Content/img/database/profiles"),
                           Server.MapPath("~/Content/img/database/times"), data);



            base.ShowMessage("Arquivo de apostas finais gerado com sucesso.");

            return RedirectToAction("Index");
        }
        public ActionResult DownloadFile(string fileName)
        {
            string folder = Server.MapPath(System.IO.Path.Combine(FolderApostas, fileName));

            StreamReader reader = new StreamReader(folder);
            return base.DownloadStream(reader.BaseStream, "text/plain", fileName);
        }
        public ActionResult EnviarApostasRestantes()
        {

            Domain.Entities.Boloes.Bolao bolaoLoaded = _bolaoApp.Load(base.SelectedBolao);

            IList<Domain.Entities.ValueObjects.UserMembroStatusVO> listMembros =
                _bolaoMembroApp.GetUserStatus(base.SelectedBolao);

            IList<Domain.Entities.Users.User> sendList = new List<Domain.Entities.Users.User>();

            for (int c = 0; c < listMembros.Count; c++)
            {
                if (listMembros[c].Restantes != 0)
                {
                    sendList.Add(new Domain.Entities.Users.User(listMembros[c].UserName)
                    {
                        Email = listMembros[c].Email,
                        FullName = listMembros[c].FullName
                    });
                }
            }



            for (int c = 0; c < sendList.Count; c++)
            {
                _notificationApp.NotifyApostasRestantes(sendList[c]);
            }

            if (sendList.Count > 0)
            {
                base.ShowMessage("Apostas enviadas com sucesso.");
            }
            else
            {
                base.ShowErrorMessage("Não há pendência de apostas dos usuários.");
            }

            return RedirectToAction("Index");


        }
        public ActionResult EnviarNaoPago()
        {
            Domain.Entities.Boloes.Bolao bolaoLoaded = _bolaoApp.Load(base.SelectedBolao);

            IList<Domain.Entities.ValueObjects.UserMembroStatusVO> listMembros =
                _bolaoMembroApp.GetUserStatus(base.SelectedBolao);

            IList<Domain.Entities.Users.User> sendList = new List<Domain.Entities.Users.User>();

            for (int c = 0; c < listMembros.Count; c++)
            {
                if (listMembros[c].Pago != 0)
                {
                    sendList.Add( new Domain.Entities.Users.User (listMembros[c].UserName)
                        {
                            Email = listMembros[c].Email,
                            FullName = listMembros[c].FullName
                        });
                }
            }



            for (int c = 0; c < sendList.Count; c++ )
            {
                _notificationApp.NotityPagamentoRestante(sendList[c]);
            }

            if (sendList.Count > 0)
            {
                base.ShowMessage("Notificações de pendência da pagamentos enviadas com sucesso.");
            }
            else
            {
                base.ShowErrorMessage("Não há pendência de pagamentos dos usuários.");
            }

            return RedirectToAction("Index");
        }
        public ActionResult EnviarInicial()
        {
            IList<Domain.Entities.ValueObjects.UserMembroStatusVO> listMembros =
                _bolaoMembroApp.GetUserStatus(base.SelectedBolao);

            IList<string> emails = new List<string>();

            for (int c = 0; c < listMembros.Count;c ++ )
            {
                emails.Add(listMembros[c].Email);
            }

            string fileToCheckZip = Server.MapPath(System.IO.Path.Combine(FolderApostas, FileApostasInicial + CompressedFile));
            
            _notificationApp.NotifyApostasIniciaisBolao(emails,fileToCheckZip) ;

            base.ShowMessage("Apostas iniciais enviadas com sucesso.");

            return RedirectToAction("Index");
        }
        public ActionResult EnviarFinal()
        {
            IList<Domain.Entities.ValueObjects.UserMembroStatusVO> listMembros =
             _bolaoMembroApp.GetUserStatus(base.SelectedBolao);

            IList<string> emails = new List<string>();

            for (int c = 0; c < listMembros.Count; c++)
            {
                emails.Add(listMembros[c].Email);
            }

            string fileToCheckZip = Server.MapPath(System.IO.Path.Combine(FolderApostas, FileApostasFinal + CompressedFile));

            _notificationApp.NotifyApostasFinaisBolao(emails, fileToCheckZip);


            base.ShowMessage("Apostas finais enviadas com sucesso.");

            return RedirectToAction("Index");

             
        }

        #endregion
    }
}