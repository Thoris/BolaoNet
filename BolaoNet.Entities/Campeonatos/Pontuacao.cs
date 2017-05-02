using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class Pontuacao : Base.AuditModel
    {
        #region Properties

        public int TotalVitorias { get; set; }
        public int TotalDerrotas { get; set; }
        public int TotalEmpates { get; set; }
        public int TotalGolsContra { get; set; }
        public int TotalGolsPro { get; set; }
        public int TotalPontos { get; set; }
        public int Jogos { get; set; }
        public int Saldo { get; set; }
        public double Aproveitamento
        {
            get
            {
                if (Jogos == 0)
                    return 0;
                else
                {
                    int totalPontos = Jogos * 3;

                    double result = ((double)TotalPontos / (double)totalPontos) * (double)100;

                    return (int)result;
                }

            }
        }

        #endregion

        #region Constructors/Destructors

        public Pontuacao()
        {

        }

        #endregion
    }
}
