using AutoMapper;
using BolaoNet.MVC.ViewModels.Bolao;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class BolaoComparacaoApostasController : BaseBolaoAreaController
    {
        
        #region Variables

        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;
        private Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp; 

        #endregion


        #region Constructors/Destructors
        public BolaoComparacaoApostasController(
            Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp bolaoMembroClassificacaoApp,
            Application.Interfaces.Campeonatos.IJogoApp jogoApp,
            Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.Boloes.IBolaoCriterioPontosApp bolaoCriterioPontosApp,
            Application.Interfaces.Boloes.IBolaoCriterioPontosTimesApp bolaoCriterioPontosTimesApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoUsuarioApp = jogoUsuarioApp;
            _jogoApp = jogoApp;
            _bolaoMembroClassificacaoApp = bolaoMembroClassificacaoApp; 
        }

        #endregion

        #region Methods

        private void SetFilterViewBags()
        {
            ViewBag.Rodadas = new SelectList(base.CampeonatoData.Rodadas);
            ViewBag.Fases = new SelectList(base.CampeonatoData.NomeFases);
            ViewBag.Grupos = new SelectList(base.CampeonatoData.NomeGrupos);
            ViewBag.Times = new SelectList(base.CampeonatoData.NomeTimes);


            IList<Domain.Entities.Boloes.BolaoMembro> membros = _bolaoMembroApp.GetListUsersInBolao(base.SelectedBolao);
            ViewBag.Membros = new SelectList(membros, "UserName", "UserName", base.UserLogged.UserName);


        }
        private Domain.Entities.ValueObjects.FilterJogosVO GetFilter(ViewModels.Bolao.FilterJogosViewModel filter)
        {
            Domain.Entities.ValueObjects.FilterJogosVO res = new Domain.Entities.ValueObjects.FilterJogosVO();

            #region Verificação do Filtro
            Domain.Entities.ValueObjects.FilterJogosVO filterVO = new Domain.Entities.ValueObjects.FilterJogosVO();

            switch ((ViewModels.Bolao.FilterJogosViewModel.FilterJogoType)filter.FilterSelected)
            {
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Este_mes:

                    res.DataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime finalA = DateTime.Now.AddMonths(1);
                    res.DataFinal = new DateTime(finalA.Year, finalA.Month, 1).AddDays(-1);

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Fase:

                    res.NomeFase = filter.NomeFase;

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Grupo:

                    res.NomeGrupo = filter.NomeGrupo;

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Ontem_Hoje_Amanha:

                    res.DataInicial = DateTime.Now.AddDays(-1);
                    res.DataFinal = DateTime.Now.AddDays(1);

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Periodo:

                    res.DataInicial = filter.DataInicial;
                    res.DataFinal = filter.DataFinal;

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Proximo_mes:

                    DateTime inicial = DateTime.Now.AddMonths(1);
                    res.DataInicial = new DateTime(inicial.Year, inicial.Month, 1);
                    DateTime finalB = inicial.AddMonths(1);
                    res.DataFinal = new DateTime(finalB.Year, finalB.Month, 1).AddDays(-1);

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Proximos_7_dias:

                    res.DataInicial = DateTime.Now;
                    res.DataFinal = DateTime.Now.AddDays(7);

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Rodada:

                    res.Rodada = filter.Rodada;

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Time:

                    res.NomeTime = filter.NomeTime;

                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Ultimo_Mes:

                    DateTime inicialC = DateTime.Now.AddMonths(-1);
                    res.DataInicial = new DateTime(inicialC.Year, inicialC.Month, 1);
                    DateTime finalC = inicialC.AddMonths(1);
                    res.DataFinal = new DateTime(finalC.Year, finalC.Month, 1).AddDays(-1);


                    break;
                case ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Ultimos_7_dias:

                    res.DataInicial = DateTime.Now;
                    res.DataFinal = DateTime.Now.AddDays(-7);

                    break;

            }
            #endregion


            return res;

        }
        private IList<BolaoComparacaoApostaJogoViewModel> Bind(Domain.Entities.ValueObjects.FilterJogosVO filter, string userName1, string userName2)
        {
            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list1 =
               _jogoUsuarioApp.GetJogosUser(
               base.SelectedBolao,
               new Domain.Entities.Users.User(userName1),
               filter);

            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list2 =
               _jogoUsuarioApp.GetJogosUser(
               base.SelectedBolao,
               new Domain.Entities.Users.User(userName2),
               filter);


            IList<ViewModels.Bolao.BolaoComparacaoApostaJogoViewModel> data =
                Mapper.Map<IList<Domain.Entities.ValueObjects.JogoUsuarioVO>,
                IList<ViewModels.Bolao.BolaoComparacaoApostaJogoViewModel>>
                (list1);

            for (int c = 0; c < data.Count;c++ )
            {
                if (list2.Count > c && list2[c].JogoId == list1[c].JogoId)
                {
                    data[c].GolsTime1Usuario2 = list2[c].ApostaTime1;
                    data[c].GolsTime2Usuario2 = list2[c].ApostaTime2;
                    data[c].PontosUsuario2 = list2[c].Pontos;

                }
            }

            return data;
        } 

        #endregion

        #region Actions

        public ActionResult Index(ViewModels.Bolao.BolaoComparacaoApostasViewModel model)
        {
            SetFilterViewBags();

            model = new ViewModels.Bolao.BolaoComparacaoApostasViewModel();

            IList<BolaoComparacaoApostaJogoViewModel> list = Bind(
                new Domain.Entities.ValueObjects.FilterJogosVO()
                {
                    DataInicial = DateTime.Now.AddDays(-1),
                    DataFinal = DateTime.Now.AddDays(1),
                },
                base.UserLogged.UserName,
                base.UserLogged.UserName);

             

            model.Filtros.FilterSelected = (int)ViewModels.Bolao.FilterJogosViewModel.FilterJogoType.Ontem_Hoje_Amanha;
            //model.Filtros.Rodada = 1;
            model.Apostas = list;
            model.UserNameComparacao = base.UserLogged.UserName;

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filtrar(ViewModels.Bolao.BolaoComparacaoApostasViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Index", model);
            }

            SetFilterViewBags();

            IList<BolaoComparacaoApostaJogoViewModel> list =
                Bind(GetFilter(model.Filtros), model.UserNameBase, model.UserNameComparacao);

             

            //model.UserNameComparacao = model.Filtros.UserName;
            model.Apostas = list;

            return View("Index", model);
        }

        #endregion
    }
}