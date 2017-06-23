using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]        
        public DateTime ? DataInicial { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]        
        public DateTime ? DataFinal { get; set; }
        
        #endregion
       
    }
}
