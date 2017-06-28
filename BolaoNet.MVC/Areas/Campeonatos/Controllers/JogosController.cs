using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Campeonatos.Controllers
{
    public class JogosController : BaseCampeonatoAreaController
    {
        #region Variables

        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;

        #endregion

        #region Constructors/Destructors

        public JogosController(
            Application.Interfaces.Campeonatos.IJogoApp jogoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp
            )
            : base (campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoApp = jogoApp;
        }

        #endregion

        #region Methods

        private void SetFilterViewBags()
        {
            ViewBag.Rodadas = new SelectList(base.CampeonatoData.Rodadas);
            ViewBag.Fases = new SelectList(base.CampeonatoData.NomeFases);
            ViewBag.Grupos = new SelectList(base.CampeonatoData.NomeGrupos);
            ViewBag.Times = new SelectList(base.CampeonatoData.NomeTimes);
        }
        private Domain.Entities.ValueObjects.FilterJogosVO GetFilter(ViewModels.Campeonatos.FilterJogosViewModel filter)
        {
            Domain.Entities.ValueObjects.FilterJogosVO res = new Domain.Entities.ValueObjects.FilterJogosVO();

            #region Verificação do Filtro
            Domain.Entities.ValueObjects.FilterJogosVO filterVO = new Domain.Entities.ValueObjects.FilterJogosVO();

            switch ((ViewModels.Campeonatos.FilterJogosViewModel.FilterJogoType)filter.FilterSelected)
            {
                case ViewModels.Campeonatos.FilterJogosViewModel.FilterJogoType.Este_mes:

                    res.DataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime finalA = DateTime.Now.AddMonths(1);
                    res.DataFinal = new DateTime(finalA.Year, finalA.Month, 1).AddDays(-1);

                    break;
                case ViewModels.Campeonatos.FilterJogosViewModel.FilterJogoType.Fase:

                    res.NomeFase = filter.NomeFase;

                    break;
                case ViewModels.Campeonatos.FilterJogosViewModel.FilterJogoType.Grupo:

                    res.NomeGrupo = filter.NomeGrupo;

                    break;
                case ViewModels.Campeonatos.FilterJogosViewModel.FilterJogoType.Ontem_Hoje_Amanha:

                    res.DataInicial = DateTime.Now.AddDays(-1);
                    res.DataFinal = DateTime.Now.AddDays(1);

                    break;
                case ViewModels.Campeonatos.FilterJogosViewModel.FilterJogoType.Periodo:

                    res.DataInicial = filter.DataInicial;
                    res.DataFinal = filter.DataFinal;

                    break;
                case ViewModels.Campeonatos.FilterJogosViewModel.FilterJogoType.Proximo_mes:

                    DateTime inicial = DateTime.Now.AddMonths(1);
                    res.DataInicial = new DateTime(inicial.Year, inicial.Month, 1);
                    DateTime finalB = inicial.AddMonths(1);
                    res.DataFinal = new DateTime(finalB.Year, finalB.Month, 1).AddDays(-1);

                    break;
                case ViewModels.Campeonatos.FilterJogosViewModel.FilterJogoType.Proximos_7_dias:

                    res.DataInicial = DateTime.Now;
                    res.DataFinal = DateTime.Now.AddDays(7);

                    break;
                case ViewModels.Campeonatos.FilterJogosViewModel.FilterJogoType.Rodada:

                    res.Rodada = filter.Rodada;

                    break;
                case ViewModels.Campeonatos.FilterJogosViewModel.FilterJogoType.Time:

                    res.NomeTime = filter.NomeTime;

                    break;
                case ViewModels.Campeonatos.FilterJogosViewModel.FilterJogoType.Ultimo_Mes:

                    DateTime inicialC = DateTime.Now.AddMonths(-1);
                    res.DataInicial = new DateTime(inicialC.Year, inicialC.Month, 1);
                    DateTime finalC = inicialC.AddMonths(1);
                    res.DataFinal = new DateTime(finalC.Year, finalC.Month, 1).AddDays(-1);


                    break;
                case ViewModels.Campeonatos.FilterJogosViewModel.FilterJogoType.Ultimos_7_dias:

                    res.DataInicial = DateTime.Now;
                    res.DataFinal = DateTime.Now.AddDays(-7);

                    break;

            }
            #endregion


            return res;

        }
        private IList<Domain.Entities.Campeonatos.Jogo> Bind(Domain.Entities.ValueObjects.FilterJogosVO filter)
        {
            IList<Domain.Entities.Campeonatos.Jogo> list =
               _jogoApp.GetJogos(
               base.SelectedCampeonato,
               filter);

            return list;
        }
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            LoadCampeonatoData();
            base.OnActionExecuting(filterContext);


        }

        #endregion

        #region Actions


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filtrar(ViewModels.Campeonatos.CampeonatoJogosListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Jogos", model);
            }

            SetFilterViewBags();

            IList<Domain.Entities.Campeonatos.Jogo> list =
                Bind(GetFilter(model.Filtros));


            IList<ViewModels.Campeonatos.CampeonatoJogoEntryViewModel> data =
                Mapper.Map<IList<Domain.Entities.Campeonatos.Jogo>,
                IList<ViewModels.Campeonatos.CampeonatoJogoEntryViewModel>>
                (list);


            model.Jogos = data;

            return View("Jogos", model);
        }

        [HttpGet]
        public ActionResult Index(ViewModels.Campeonatos.CampeonatoJogosListViewModel model)
        {
            SetFilterViewBags();

            model = new ViewModels.Campeonatos.CampeonatoJogosListViewModel();

            IList<Domain.Entities.Campeonatos.Jogo> list = Bind(new Domain.Entities.ValueObjects.FilterJogosVO());
            

            IList<ViewModels.Campeonatos.CampeonatoJogoEntryViewModel> data =
                Mapper.Map<IList<Domain.Entities.Campeonatos.Jogo>,
                IList<ViewModels.Campeonatos.CampeonatoJogoEntryViewModel>>
                (list);


            model.Jogos = data;

            return View(model);
        }

        #endregion
    }
}