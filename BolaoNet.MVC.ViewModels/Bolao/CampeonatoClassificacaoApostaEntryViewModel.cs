using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class CampeonatoClassificacaoApostaEntryViewModel : Domain.Entities.Campeonatos.CampeonatoClassificacao
    {
        #region Constants

        private const string FormatIcon = "/Content/img/database/times/{0}.gif";

        #endregion

        #region Properties

        public string ImageTime 
        { 
            get
            {
                return string.Format(FormatIcon, this.NomeTime);
            }
        }
        public new int? Saldo
        {
            get 
            {
                if (base.TotalGolsContra == null || base.TotalGolsPro == null)
                    return 0;
                else
                    return base.TotalGolsPro - base.TotalGolsContra;
            }
            set
            {
                base.Saldo = value;
            }
        }
        public new int ? Jogos
        {
            get
            {
                int total = 0;
                if (base.TotalVitorias != null)
                    total += (int)base.TotalVitorias;
                if (base.TotalDerrotas != null)
                    total += (int)base.TotalDerrotas;
                if (base.TotalEmpates != null)
                    total += (int)base.TotalEmpates;

                return total;

            }
            set
            {
                base.Jogos = value;
            }
        }
        public new double Aproveitamento
        {
            get
            {
                if (Jogos == 0)
                    return 0;
                else
                {
                    int totalPontos = (int)this.Jogos * 3;

                    double result = ((double)TotalPontos / (double)totalPontos) * (double)100;

                    return result;
                }

            }
        }
        public System.Drawing.Color? BackColor { get; set; }
        public System.Drawing.Color? ForeColor { get; set; }

        #endregion
    }
}
