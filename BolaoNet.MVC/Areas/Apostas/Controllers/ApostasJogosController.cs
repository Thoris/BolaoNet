using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Apostas.Controllers
{
    public class ApostasJogosController : BaseApostasAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private Application.Interfaces.Reports.IBolaoMembroApostasReportApp _bolaoMembroApostasReportApp;

        #endregion

        #region Constructors/Destructors

        public ApostasJogosController(
                Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
                Application.Interfaces.Boloes.IBolaoApp bolaoApp,
                Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp,
                Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
                Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
                Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
                Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
                Application.Interfaces.Reports.IBolaoMembroApostasReportApp bolaoMembroApostasReportApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _jogoUsuarioApp = jogoUsuarioApp;
            _bolaoMembroApostasReportApp = bolaoMembroApostasReportApp;
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
        private Domain.Entities.ValueObjects.FilterJogosVO GetFilter(ViewModels.Apostas.FilterJogosViewModel filter)
        {
            Domain.Entities.ValueObjects.FilterJogosVO res = new Domain.Entities.ValueObjects.FilterJogosVO();

            #region Verificação do Filtro
            Domain.Entities.ValueObjects.FilterJogosVO filterVO = new Domain.Entities.ValueObjects.FilterJogosVO();

            switch ((ViewModels.Apostas.FilterJogosViewModel.FilterJogoType)filter.FilterSelected)
            {
                case ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Este_mes:
                    
                    res.DataInicial = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
                    DateTime finalA = DateTime.Now.AddMonths(1);
                    res.DataFinal = new DateTime(finalA.Year, finalA.Month, 1).AddDays(-1);

                    break;
                case ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Fase:

                    res.NomeFase = filter.NomeFase;

                    break;
                case ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Grupo:

                    res.NomeGrupo = filter.NomeGrupo;

                    break;
                case ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Ontem_Hoje_Amanha:

                    res.DataInicial = DateTime.Now.AddDays(-1);
                    res.DataFinal = DateTime.Now.AddDays(1);

                    break;
                case ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Periodo:

                    res.DataInicial = filter.DataInicial;
                    res.DataFinal = filter.DataFinal;

                    break;
                case ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Proximo_mes:

                    DateTime inicial = DateTime.Now.AddMonths(1);
                    res.DataInicial = new DateTime(inicial.Year, inicial.Month, 1);
                    DateTime finalB = inicial.AddMonths(1);
                    res.DataFinal = new DateTime(finalB.Year, finalB.Month, 1).AddDays(-1);

                    break;
                case ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Proximos_7_dias:

                    res.DataInicial = DateTime.Now;
                    res.DataFinal = DateTime.Now.AddDays(7);

                    break;
                case ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Rodada:

                    res.Rodada = filter.Rodada;

                    break;
                case ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Time:

                    res.NomeTime = filter.NomeTime;

                    break;
                case ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Ultimo_Mes:
                    
                    DateTime inicialC = DateTime.Now.AddMonths(-1);
                    res.DataInicial = new DateTime(inicialC.Year, inicialC.Month, 1);
                    DateTime finalC = inicialC.AddMonths(1);
                    res.DataFinal = new DateTime(finalC.Year, finalC.Month, 1).AddDays(-1);


                    break;
                case ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Ultimos_7_dias:

                    res.DataInicial = DateTime.Now;
                    res.DataFinal = DateTime.Now.AddDays(-7);

                    break;

            }
            #endregion


            return res;

        }
        private IList<Domain.Entities.ValueObjects.JogoUsuarioVO> Bind(Domain.Entities.ValueObjects.FilterJogosVO filter)
        {
            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list =
               _jogoUsuarioApp.GetJogosUser(
               base.SelectedBolao,
               base.UserLogged,
               filter);

            return list;
        }
        private bool GetDefaultFilterJogos(out MVC.ViewModels.Apostas.ApostasJogosListViewModel model, out IList<Domain.Entities.ValueObjects.JogoUsuarioVO> jogos)
        {
            jogos = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();
            model = new ViewModels.Apostas.ApostasJogosListViewModel();

            model.Filtros.FilterSelected = (int)ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Fase;
            model.Filtros.NomeFase = Domain.Entities.Campeonatos.CampeonatoFase.FaseClassificatoria;

            //Se não há as fases definidas
            if (!IsCampeonatoContainsFases())
                return false;

            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list =
                Bind(new Domain.Entities.ValueObjects.FilterJogosVO());


            #region Verificando se as fases foram preenchidas com sucesso

            if (!IsFasePreenchidaJogos(list, model.Filtros.NomeFase, out jogos))
            {
                return true;
            }
            
            model.Filtros.NomeFase = Domain.Entities.Campeonatos.CampeonatoFase.FaseOitavasFinal;
            if (!IsFasePreenchidaJogos(list, model.Filtros.NomeFase, out jogos))
            {                
                return true;
            }

            model.Filtros.NomeFase = Domain.Entities.Campeonatos.CampeonatoFase.FaseQuartasFinal;
            if (!IsFasePreenchidaJogos(list, model.Filtros.NomeFase, out jogos))
            {
                return true;
            }


            model.Filtros.NomeFase = Domain.Entities.Campeonatos.CampeonatoFase.FaseSemiFinal;
            if (!IsFasePreenchidaJogos(list, model.Filtros.NomeFase, out jogos))
            {
                return true;
            }

            model.Filtros.NomeFase = Domain.Entities.Campeonatos.CampeonatoFase.FaseFinal;
            if (!IsFasePreenchidaJogos(list, model.Filtros.NomeFase, out jogos))
            {
                return true;
            }


            #endregion

            model.Filtros.NomeFase = Domain.Entities.Campeonatos.CampeonatoFase.FaseClassificatoria;

            return false;
            
        }
        private bool IsFasePreenchidaJogos(IList<Domain.Entities.ValueObjects.JogoUsuarioVO> data, string nomeFase, out IList<Domain.Entities.ValueObjects.JogoUsuarioVO> jogos)
        {
            jogos = new List<Domain.Entities.ValueObjects.JogoUsuarioVO>();
            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list =
                (from p in data
                 where string.Compare(p.NomeFase, nomeFase, true) == 0 &&
                     (p.ApostaTime1 == null || p.ApostaTime2 == null)
                 select p).ToList();

            if (list == null || list.Count == 0)
                return true;
            else
            {
                jogos = list;
                return false;
            }
        }
        private bool IsCampeonatoContainsFases()
        {
            if (base.CampeonatoData.NomeFases == null)
                return false;

            if (!IsCampeonatoContainsFase(Domain.Entities.Campeonatos.CampeonatoFase.FaseClassificatoria))
                return false;
            if (!IsCampeonatoContainsFase(Domain.Entities.Campeonatos.CampeonatoFase.FaseOitavasFinal))
                return false;
            if (!IsCampeonatoContainsFase(Domain.Entities.Campeonatos.CampeonatoFase.FaseQuartasFinal))
                return false;
            if (!IsCampeonatoContainsFase(Domain.Entities.Campeonatos.CampeonatoFase.FaseSemiFinal))
                return false;
            if (!IsCampeonatoContainsFase(Domain.Entities.Campeonatos.CampeonatoFase.FaseFinal))
                return false;

            return true;
        }
        private bool IsCampeonatoContainsFase(string nomeFase)
        {
            for (int c=0; c < base.CampeonatoData.NomeFases.Count; c++)
            {
                if (string.Compare (base.CampeonatoData.NomeFases[c], nomeFase, true) == 0)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion

        #region Actions

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Filtrar(ViewModels.Apostas.ApostasJogosListViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View("Jogos", model);
            }

            SetFilterViewBags();

            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list =
                Bind(GetFilter (model.Filtros));


            IList<ViewModels.Apostas.ApostaJogoEntryViewModel> data =
                Mapper.Map<IList<Domain.Entities.ValueObjects.JogoUsuarioVO>,
                IList<ViewModels.Apostas.ApostaJogoEntryViewModel>>
                (list);


            model.Apostas = data;

            return View("Jogos", model);
        }

        [HttpGet]
        public ActionResult Jogos(ViewModels.Apostas.ApostasJogosListViewModel model)
        {
            SetFilterViewBags();
            
            model = new ViewModels.Apostas.ApostasJogosListViewModel();
            
            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> list = null;

            //Se deve mudar o filtro padrão inicial para retorno dos jogos
            if (!GetDefaultFilterJogos(out model, out list))
            {
                model.Filtros.FilterSelected = (int)ViewModels.Apostas.FilterJogosViewModel.FilterJogoType.Rodada;
                model.Filtros.Rodada = 1;

                list = Bind(new Domain.Entities.ValueObjects.FilterJogosVO() { Rodada = 1 });
            }


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


                int? ganhador = null;
                if ((int)list[c].SalvarApostaTime1 == (int)list[c].SalvarApostaTime2)
                    ganhador = list[c].SalvarGanhador;

                bool res =_jogoUsuarioApp.ProcessAposta(
                    base.SelectedBolao,
                    base.UserLogged, 
                    jogo, 
                    0,
                    (int)list[c].SalvarApostaTime1,
                    (int)list[c].SalvarApostaTime2,
                    null,
                    null,
                    ganhador);
            }


            if (list.Count > 0)
            {
                base.ShowMessage("Apostas inseridas com sucesso.");
            }

            return RedirectToAction("Jogos", "ApostasJogos", model);
        }

        public ActionResult DownloadApostas()
        {
            //new Helpers.Downloader().DownloadRelatorio();

            //MemoryStream stream = new MemoryStream();
            //StreamWriter writer = new StreamWriter(stream);

            //writer.WriteLine("teste 1");
            //writer.WriteLine("teste 1");
            //writer.WriteLine("teste 1");
            //writer.WriteLine("teste 1");
            //writer.WriteLine("teste 1");
            //writer.WriteLine("teste 1");
            //writer.WriteLine("teste 1");

            //writer.Flush();
            //stream.Seek(0, SeekOrigin.Begin);

            Domain.Entities.ValueObjects.Reports.BolaoMembroApostasVO data =
                _bolaoMembroApostasReportApp.GetData(base.SelectedBolao, base.UserLogged);

            Stream streamReport = _bolaoMembroApostasReportApp.Generate(
                "gif",
                Server.MapPath("~/Content/img/database/profiles"),
                Server.MapPath("~/Content/img/database/times"), data);


            return base.DownloadStream(streamReport, "text/plain", base.UserLogged.UserName + ".pdf");
            //return base.DownloadStream(stream, "text/plain", "file.txt");
        }

        #endregion
    }
}