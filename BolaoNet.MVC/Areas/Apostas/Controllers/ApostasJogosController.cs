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
        public ActionResult Jogos()
        {
            ViewModels.Apostas.ApostasJogosListViewModel model= new ViewModels.Apostas.ApostasJogosListViewModel();

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

            ViewModels.Apostas.FilterJogosViewModel filterViewModel = new ViewModels.Apostas.FilterJogosViewModel();

            Domain.Entities.ValueObjects.FilterJogosVO filterVO = new Domain.Entities.ValueObjects.FilterJogosVO();


            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list =
                _jogoUsuarioApp.GetJogosUser(
                new Domain.Entities.Boloes.Bolao("Copa do Mundo 2014")
                {
                    NomeCampeonato = "Copa do Mundo 2014"
                },
                new Domain.Entities.Users.User("thoris"),
                filterVO);


            IList<ViewModels.Apostas.ApostaJogoEntryViewModel> data =
                Mapper.Map<IList<Domain.Entities.ValueObjects.JogoUsuarioVO>,
                IList<ViewModels.Apostas.ApostaJogoEntryViewModel>>
                (list);


            model.Apostas = data;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult SaveJogos(MVC.ViewModels.Apostas.ApostasJogosListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Jogos", model);
            }


            IList<ViewModels.Apostas.ApostaJogoEntryViewModel> list = (from p in model.Apostas
                                                                       where p.IsChanged == true
                                                                       select p).ToList();


            for (int c = 0; c < list.Count; c++ )
            {

                Domain.Entities.Campeonatos.Jogo jogo =
                    Mapper.Map<ViewModels.Apostas.ApostaJogoEntryViewModel, Domain.Entities.Campeonatos.Jogo>
                    (list[c]);


                bool res =_jogoUsuarioApp.ProcessAposta(
                    new Domain.Entities.Boloes.Bolao("Copa do Mundo 2014"),
                    new Domain.Entities.Users.User("thoris"), 
                    jogo, 
                    0,
                    (int)list[c].SalvarApostaTime1,
                    (int)list[c].SalvarApostaTime2,
                    null,
                    null,
                    null);
            }


            return View();
        }



        #endregion
    }
}