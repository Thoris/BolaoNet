using AutoMapper;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BolaoNet.MVC.Areas.Boloes.Controllers
{
    public class PercentualChancesController : BaseBolaoAreaController
    {
        #region Variables

        private Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp _bolaoMembroClassificacaoApp;
        private Application.Interfaces.Boloes.IBolaoPremioApp _bolaoPremioApp;

        #endregion

        #region Constructors/Destructors


        public PercentualChancesController(
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Boloes.IBolaoMembroClassificacaoApp bolaoMembroClassificacaoApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Campeonatos.ICampeonatoFaseApp campeonatoFaseApp,
            Application.Interfaces.Campeonatos.ICampeonatoGrupoApp campeonatoGrupoApp,
            Application.Interfaces.Campeonatos.ICampeonatoTimeApp campeonatoTimeApp,
            Application.Interfaces.Boloes.IBolaoPremioApp bolaoPremioApp
            )
            : base(bolaoMembroApp, bolaoApp, campeonatoApp, campeonatoFaseApp, campeonatoGrupoApp, campeonatoTimeApp)
        {
            _bolaoMembroClassificacaoApp = bolaoMembroClassificacaoApp;
            _bolaoPremioApp = bolaoPremioApp;
        }

        #endregion

        #region Methods

        public IList<ViewModels.Bolao.PercentualChanceViewModel> ReadFile(string file)
        {
            IList<ViewModels.Bolao.PercentualChanceViewModel> res = new List<ViewModels.Bolao.PercentualChanceViewModel>();

            if (!System.IO.File.Exists(file))
                return res;

            StreamReader reader = new StreamReader(file);

            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();

                if (string.IsNullOrEmpty(line))
                    continue;

                string[] split = line.Split(new char[] { '|' },  StringSplitOptions.RemoveEmptyEntries);

                ViewModels.Bolao.PercentualChanceViewModel entry = new ViewModels.Bolao.PercentualChanceViewModel();

                entry.UserName = split[0];
                entry.Percentual = new List<double>();

                for (int i = 1; i < split.Length; i++)
                {
                    double percentual = double.Parse(split[i].Replace("%", "").Trim());
                    entry.Percentual.Add(percentual);
                }

                res.Add(entry);
            }

            reader.Close();

            return res;
        }

        #endregion

        #region Actions

        public ActionResult Index(int ? id)
        {
            IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> list =
             _bolaoMembroClassificacaoApp.LoadClassificacao(base.SelectedBolao, null);


            string file = System.IO.Path.Combine(Server.MapPath("~/App_Data"), id.ToString() + "\\percentual.txt");


            IList<ViewModels.Bolao.PercentualChanceViewModel> res = ReadFile(file);

            for (int c=0; c < list.Count; c++)
            {
                for (int i = 0; i < res.Count; i++)
                {
                    if (string.Compare (list[c].UserName, res[i].UserName, true) == 0)
                    {
                        res[i].Posicao = list[c].Posicao ?? 0;
                        res[i].Pontos = list[c].TotalPontos ?? 0;
                        res[i].FullName = list[c].FullName;
                        break;
                    }
                }
            }

            res = res.OrderBy(x => x.Posicao).ToList();
            return View(res);
        }

        #endregion
    }
}