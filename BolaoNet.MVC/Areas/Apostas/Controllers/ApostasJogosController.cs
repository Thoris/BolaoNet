using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Apostas.Controllers
{
    public class ApostasJogosController : BaseApostasController
    {
        #region Variables

        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;

        #endregion

        #region Constructors/Destructors

        public ApostasJogosController(Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp)
        {
            _jogoUsuarioApp = jogoUsuarioApp;
        }

        #endregion

        #region Actions

        [HttpGet]
        public ActionResult Jogos(MVC.ViewModels.Apostas.ApostasJogosListViewModel model)
        {
            if (model == null)
                model = new ViewModels.Apostas.ApostasJogosListViewModel();

            //MVC.ViewModels.Apostas.ApostasJogosListViewModel vo = new ViewModels.Apostas.ApostasJogosListViewModel();

            #region Emulate Data
            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = true,
            //    DataAposta = DateTime.Now,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Classificatória",
            //    GolsTime1 = 2,
            //    GolsTime2 = 2,
            //    Grupo = "A",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 1,
            //    Rodada = 1,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});
            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataAposta = DateTime.Now,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Classificatória",
            //    GolsTime1 = 1,
            //    GolsTime2 = 1,
            //    Grupo = "A",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 2,
            //    Rodada = 1,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});
            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataAposta = DateTime.Now,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Classificatória",
            //    GolsTime1 = 1,
            //    GolsTime2 = 2,
            //    Grupo = "B",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = true,
            //    JogoId = 3,
            //    Rodada = 1,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});
            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataAposta = DateTime.Now,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Classificatória",
            //    GolsTime1 = 2,
            //    GolsTime2 = 1,
            //    Grupo = "B",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = true,
            //    JogoId = 4,
            //    Rodada = 1,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});
            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Classificatória",
            //    GolsTime1 = null,
            //    GolsTime2 = null,
            //    Grupo = "C",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 3,
            //    Rodada = 1,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});
            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Classificatória",
            //    GolsTime1 = null,
            //    GolsTime2 = null,
            //    Grupo = "C",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 4,
            //    Rodada = 1,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});


            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Oitavas de Final",
            //    GolsTime1 = null,
            //    GolsTime2 = null,
            //    Grupo = " ",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 4,
            //    Rodada = 2,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});
            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Oitavas de Final",
            //    GolsTime1 = null,
            //    GolsTime2 = null,
            //    Grupo = " ",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 4,
            //    Rodada = 2,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});
            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Oitavas de Final",
            //    GolsTime1 = null,
            //    GolsTime2 = null,
            //    Grupo = " ",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 4,
            //    Rodada = 2,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});
            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Oitavas de Final",
            //    GolsTime1 = null,
            //    GolsTime2 = null,
            //    Grupo = " ",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 4,
            //    Rodada = 2,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});


            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Quartas de Final",
            //    GolsTime1 = null,
            //    GolsTime2 = null,
            //    Grupo = " ",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 4,
            //    Rodada = 3,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});
            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Quartas de Final",
            //    GolsTime1 = null,
            //    GolsTime2 = null,
            //    Grupo = " ",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 4,
            //    Rodada = 3,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});


            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Semi Final",
            //    GolsTime1 = null,
            //    GolsTime2 = null,
            //    Grupo = " ",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 4,
            //    Rodada = 4,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});
            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Semi Final",
            //    GolsTime1 = null,
            //    GolsTime2 = null,
            //    Grupo = " ",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 4,
            //    Rodada = 4,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});



            //vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Final",
            //    GolsTime1 = null,
            //    GolsTime2 = null,
            //    Grupo = " ",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 4,
            //    Rodada = 5,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //}); vo.Apostas.Add(new ViewModels.Apostas.ApostaJogoEntryViewModel()
            //{
            //    Automatico = null,
            //    DataJogo = DateTime.Now,
            //    Estadio = "São Paulo",
            //    Fase = "Final",
            //    GolsTime1 = null,
            //    GolsTime2 = null,
            //    Grupo = " ",
            //    ImageTime1 = "/Content/img/database/times/Argentina.gif",
            //    ImageTime2 = "/Content/img/database/times/Argentina.gif",
            //    IsLocked = false,
            //    JogoId = 4,
            //    Rodada = 5,
            //    Time1 = "Argentina",
            //    Time2 = "Argentina",
            //});

            #endregion


            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list =
                _jogoUsuarioApp.GetJogosUser(
                new Domain.Entities.Boloes.Bolao("Copa do Mundo 2014")
                {
                    NomeCampeonato = "Copa do Mundo 2014"
                },
                new Domain.Entities.Users.User("123"), 
                null,
                null,
                2,
                null,
                null,
                null);


            IList<ViewModels.Apostas.ApostaJogoEntryViewModel> data =
                Mapper.Map<IList<Domain.Entities.ValueObjects.JogoUsuarioVO>,
                IList<ViewModels.Apostas.ApostaJogoEntryViewModel>>(list);

            model.Apostas = data;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveJogos(MVC.ViewModels.Apostas.ApostasJogosListViewModel model)
        {

            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> data =
                Mapper.Map<IList<ViewModels.Apostas.ApostaJogoEntryViewModel>,
                IList<Domain.Entities.ValueObjects.JogoUsuarioVO>>(model.Apostas);

            return View();
        }

        

        #endregion
    }
}