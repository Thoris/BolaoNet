using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Apostas
{
    public class FilterJogosViewModel
    {
        #region Enum 

        public enum FilterJogoType
        {
            Ontem_Hoje_Amanha,
            Ultimos_7_dias,
            Proximos_7_dias,
            Ultimo_Mes,
            Proximo_mes,
            Este_mes,
            Periodo,
            Rodada,
            Time,
            Fase,
            Grupo,            
        }

        #endregion

        #region Properties

        public int FilterSelected { get; set; }
        public string NomeGrupo { get; set; }
        public string NomeFase { get; set; }
        public string NomeTime { get; set; }
        public int ? Rodada { get; set; }

        public IList<int> Rodadas { get; set; }
        public IList<string> NomeTimes { get; set; }
        public IList<string> NomeFases { get; set; }
        public IList<string> NomeGrupos { get; set; }


        #endregion
       
    }
}
