//#define DEBUG_LIST

using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class IndiceEstatisticoController : BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp;
        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private Application.Interfaces.Boloes.IBolaoMembroGrupoApp _bolaoMembroGrupoApp;

        #endregion

        #region Properties

        public IList<List<Domain.Entities.ValueObjects.StatClassificacaoVO>> Data
        {
            get
            {
                if (Session["StatClassificacaoData"] == null)
                    return null;
                return (IList < List < Domain.Entities.ValueObjects.StatClassificacaoVO >> )Session["StatClassificacaoData"];
            }
            set
            {
                Session["StatClassificacaoData"] = value;
            }
        }
        public IList<ViewModels.Bolao.IndiceEstatisticoSelecionadoViewModel> Selecionado
        {
            get
            {
                if (Session["IndiceEstatisticoSelecionado"] == null)
                {
                    Session["IndiceEstatisticoSelecionado"] = new List<ViewModels.Bolao.IndiceEstatisticoSelecionadoViewModel>();
                    ((IList<ViewModels.Bolao.IndiceEstatisticoSelecionadoViewModel>)Session["IndiceEstatisticoSelecionado"]).Add(new ViewModels.Bolao.IndiceEstatisticoSelecionadoViewModel() { UserName = base.UserLogged.UserName }); 
                }
                return (IList<ViewModels.Bolao.IndiceEstatisticoSelecionadoViewModel>)Session["IndiceEstatisticoSelecionado"];
            }
            set
            {
                Session["IndiceEstatisticoSelecionado"] = value;
            }
        }

        #endregion

        #region Constructors/Destructors


        public IndiceEstatisticoController(
            Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp bolaoMembroClassificacaoApp,
            Application.Interfaces.Boloes.IBolaoMembroGrupoApp bolaoMembroGrupoApp,
            Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.Reports.IBolaoMembroApostasReportApp bolaoMembroApostasReportApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _bolaoMembroClassificacaoApp = bolaoMembroClassificacaoApp;
            _jogoUsuarioApp = jogoUsuarioApp;
            _bolaoMembroGrupoApp = bolaoMembroGrupoApp;
        }

        #endregion

        #region Methdods

        private int [] GetPosicao (IList<List<Domain.Entities.ValueObjects.StatClassificacaoVO>> list, string userName)
        {
            int[] res = new int[list.Count];

            for (int c=0; c < list.Count; c++)
            {
                for (int l = 0; l < list[c].Count; l++)
                {
                    if (string.Compare (list[c][l].UserName, userName, true) == 0)
                    {
                        res[c] = list[c][l].Posicao;
                        break;
                    }
                }
            }
            return res;
        }

        #endregion

        #region Actions

        public ActionResult Index()
        {
            IList<List<Domain.Entities.ValueObjects.StatClassificacaoVO>> rodadas = this.Data;

            if (rodadas == null)
            {
                rodadas = _jogoUsuarioApp.LoadIndiceEstatistica(base.SelectedBolao);
            }

            this.Data = rodadas;

            ViewModels.Bolao.IndiceEstatisticoViewModel model = new ViewModels.Bolao.IndiceEstatisticoViewModel();

            //IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO> listClassificacao =
            //       _bolaoMembroGrupoApp.LoadClassificacao(base.SelectedBolao, base.UserLogged);

            //model.Selecionado =
            //    Mapper.Map<
            //    IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO>,
            //    IList<ViewModels.Bolao.IndiceEstatisticoSelecionadoViewModel>
            //    >(listClassificacao);

            model.Selecionado = this.Selecionado;

            IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> list =
               _bolaoMembroClassificacaoApp.LoadClassificacao(base.SelectedBolao, null);


#if DEBUG_LIST

            System.IO.StreamWriter writer = new System.IO.StreamWriter(@"C:\temp\list.txt");
            for (int c = 0; c < rodadas[0].Count; c++ )
            {
                writer.WriteLine();
                writer.Write(rodadas[0][c].UserName);
                for (int i = 0; i < rodadas.Count; i++)
                {
                    writer.Write("|" + rodadas[i][c].Pontos + "," + rodadas[i][c].Posicao);
                }
            }
            writer.Close();

#endif


            model.Classificacao =
                Mapper.Map<
                IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO>,
                IList<ViewModels.Bolao.ClassificacaoViewModel>>
                (list);


            if (model.Selecionado != null)
            {
                for (int c = 0; c < model.Selecionado.Count; c++)
                {
                    //int[] posicao = GetPosicao(rodadas, model.Selecionado[c].UserName);
                    //model.Selecionado[c].Posicoes = posicao;

                    for (int i = 0; i < model.Classificacao.Count; i++)
                    {
                        if (string.Compare(model.Selecionado[c].UserName, model.Classificacao[i].UserName, true) == 0)
                        {
                            model.Selecionado[c].FullName = model.Classificacao[i].FullName;
                            model.Classificacao.RemoveAt(i);
                            break;
                        }
                    }
                }
            }

            ViewModels.Chart.SerieValueModelView [] series = new ViewModels.Chart.SerieValueModelView[this.Selecionado.Count];

            for (int c = 0; c < this.Selecionado.Count; c++)
            {
                int[] posicao = GetPosicao(this.Data, this.Selecionado[c].UserName);

                ViewModels.Chart.SerieValueModelView serie = new ViewModels.Chart.SerieValueModelView();
                serie.area = false;
                serie.key = this.Selecionado[c].UserName;
                serie.strokeWidth = 4;
                serie.values = new List<ViewModels.Chart.EntryXyValueModelView>();

                for (int i = 0; i < posicao.Length; i++)
                {
                    serie.values.Add(new ViewModels.Chart.EntryXyValueModelView() { x = (i + 1), y = posicao[i] * -1 });
                }

                series[c] = serie;

            }
            model.Series = series;

            return View(model);



            //

            //return View();
        }

        public ActionResult Add(string userName)
        {
            if (!string.IsNullOrEmpty(userName))
            {
                byte[] bytes = Encoding.GetEncoding(1252).GetBytes(userName);
                string userNameFix = Encoding.UTF8.GetString(bytes);


                this.Selecionado.Add(new ViewModels.Bolao.IndiceEstatisticoSelecionadoViewModel() { UserName = userNameFix });
            }

            return RedirectToAction("Index");
        }
        
        public ActionResult Remove(string userName)
        {

            if (!string.IsNullOrEmpty(userName))
            {
                byte[] bytes = Encoding.GetEncoding(1252).GetBytes(userName);
                string userNameFix = Encoding.UTF8.GetString(bytes);


                for (int c=0; c < this.Selecionado.Count; c++)
                {
                    if (string.Compare(this.Selecionado[c].UserName, userNameFix, true) == 0)
                    {
                        this.Selecionado.RemoveAt(c);
                        break;
                    }
                }
            }

            return RedirectToAction("Index");
        }

        public ActionResult GetDataChart()
        {
            List<ViewModels.Chart.SerieValueModelView> series = new List<ViewModels.Chart.SerieValueModelView>();

            for (int c = 0; c < this.Selecionado.Count; c++ )
            {
                int[] posicao = GetPosicao(this.Data, this.Selecionado[c].UserName);

                ViewModels.Chart.SerieValueModelView serie = new ViewModels.Chart.SerieValueModelView();
                serie.area = true;
                serie.key = this.Selecionado[c].UserName;
                serie.strokeWidth = 4;
                serie.values = new List<ViewModels.Chart.EntryXyValueModelView>();

                for (int i =0 ; i < posicao.Length; i++)
                {
                    serie.values.Add(new ViewModels.Chart.EntryXyValueModelView() { x = (i + 1), y = posicao[i] });
                }

                series.Add(serie);
                 
            }

            JsonResult result = Json(series, JsonRequestBehavior.AllowGet);
            return result;
        }

        #endregion
    }
}