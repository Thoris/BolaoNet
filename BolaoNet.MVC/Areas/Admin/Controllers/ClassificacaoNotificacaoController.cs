using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Admin.Controllers
{
    public class ClassificacaoNotificacaoController : BaseAdminAreaController
    {

        #region Variables

        private Application.Interfaces.Notification.INotificationApp _notificationApp;
        private Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp;
        private Application.Interfaces.Boloes.IBolaoPremioApp _bolaoPremioApp;
        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;

        #endregion

        #region Constructors/Destructors

        public ClassificacaoNotificacaoController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp bolaoMembroClassificacaoApp,
            Application.Interfaces.Boloes.IBolaoPremioApp bolaoPremioApp,
            Application.Interfaces.Campeonatos.IJogoApp jogoApp,
            Application.Interfaces.Notification.INotificationApp notificationApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _notificationApp = notificationApp;
            _bolaoMembroClassificacaoApp = bolaoMembroClassificacaoApp;
            _bolaoPremioApp = bolaoPremioApp;
            _jogoApp = jogoApp;
        }

        #endregion

        #region Methods

        public ViewModels.Admin.AdminBolaoClassificacaoViewModel GetData()
        {            
            IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> list =
                _bolaoMembroClassificacaoApp.LoadClassificacao(base.SelectedBolao, null);

            ViewModels.Admin.AdminBolaoClassificacaoViewModel model = new ViewModels.Admin.AdminBolaoClassificacaoViewModel();
            model.Classificacao = Mapper.Map<IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO>, IList<ViewModels.Admin.AdminClassificacaoViewModel>>
                (list);

            IList<Domain.Entities.Boloes.BolaoPremio> premios = _bolaoPremioApp.GetPremiosBolao(base.SelectedBolao);
            model.Premios = Mapper.Map<IList<Domain.Entities.Boloes.BolaoPremio>, IList<ViewModels.Admin.AdminPremioViewModel>>(premios);

            for (int c = 0; c < model.Premios.Count; c++)
            {
                for (int i = 0; i < model.Classificacao.Count; i++)
                {
                    if (model.Premios[c].Posicao < model.Classificacao[i].Posicao)
                        break;

                    if (model.Premios[c].Posicao == model.Classificacao[i].Posicao)
                    {
                        model.Classificacao[i].BackColorName = model.Premios[c].BackColorName;
                        model.Classificacao[i].ForeColorName = model.Premios[c].ForeColorName;
                    }
                }
            }
            Domain.Entities.Campeonatos.Jogo jogo = _jogoApp.GetLastValidJogo(SelectedCampeonato);

            if (jogo != null)
            {
                Domain.Entities.ValueObjects.FilterJogosVO filter = new Domain.Entities.ValueObjects.FilterJogosVO();
                filter.DataInicial = new DateTime(jogo.DataJogo.Year, jogo.DataJogo.Month, jogo.DataJogo.Day, 0, 0, 0);
                filter.DataFinal = new DateTime(jogo.DataJogo.Year, jogo.DataJogo.Month, jogo.DataJogo.Day, 23, 59, 59);
                var jogos = _jogoApp.GetJogos(base.SelectedCampeonato, filter);
                model.Jogos = Mapper.Map<IList<Domain.Entities.Campeonatos.Jogo>, IList<ViewModels.Admin.AdminJogoViewModel>>(jogos);
            }

            IList<Domain.Entities.Users.User> users = _bolaoMembroApp.GetUsersToNotificate(SelectedBolao);
             
            model.Mails = Mapper.Map<IList<Domain.Entities.Users.User>, IList<ViewModels.Admin.AdminUserMailViewModel>>(users);

            return model;
        }


        #endregion

        #region Actions

        public ActionResult Index()
        {
            var model = GetData();

            return View(model);
        }

        public ActionResult Enviar()
        {
            ViewModels.Admin.AdminBolaoClassificacaoViewModel model = null;
            try
            {
                model = GetData();

                IList<string> emails = new List<string>();

                for (int c = 0; c < model.Mails.Count; c++)
                {
                    emails.Add(model.Mails[c].Email);
                }

                if (emails.Count == 0)
                {
                    base.ShowMessage("Não há usuários cadastrados para receber notificação.");
                }
                else
                {
                    var classificacao = Mapper.Map<IList<ViewModels.Admin.AdminClassificacaoViewModel>, IList<Domain.Entities.ValueObjects.Notification.ClassificacaoObject>>(model.Classificacao);
                    var premios = Mapper.Map<IList<ViewModels.Admin.AdminPremioViewModel>, IList<Domain.Entities.ValueObjects.Notification.PremioObject>>(model.Premios);
                    var jogos = Mapper.Map<IList<ViewModels.Admin.AdminJogoViewModel>, IList<Domain.Entities.ValueObjects.Notification.JogoObject>>(model.Jogos);
                    _notificationApp.NotifyClassificacao(emails, classificacao, premios, jogos);

                    base.ShowMessage("E-mail de classificação enviado com sucesso.");
                }
            }
            catch (Exception ex)
            {
                base.ShowErrorMessage(ex.Message);
            }
            return RedirectToAction("Index");
        }

        #endregion

    }
}