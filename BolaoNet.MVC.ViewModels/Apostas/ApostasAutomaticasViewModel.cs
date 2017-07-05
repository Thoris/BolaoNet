using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Apostas
{
    public class ApostasAutomaticasViewModel
    {
        #region Enumerations

        public enum TipoApostaEnum : int
        {
            TodosJogos = 0,
            DurantePeriodo = 1,
            Rodada = 2,
        }
        public enum SubstituicaoApostaEnum : int
        {
            Todas = 0,
            JogosNaoApostados = 1,
            JogosJaApostados = 2,
        }
        public enum ApostasAutomaticasEnum : int
        {
            Todas = 0,
            Automaticas = 1,
            Manuais = 2,
        }

        #endregion


        #region Properties

        
        [DisplayName("Tipo de Aposta")]
        public int TipoAposta { get; set; }

        //Periodo
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
        [DisplayName("Data Inicial")]
        public DateTime? DataInicial { get; set; }

        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]  
        [DisplayName("Data Final")]
        public DateTime? DataFinal { get; set; }

        //Rodada
        [DisplayName("Rodada")]        
        public int ? Rodada { get; set; }

        [DisplayName("Tipo aposta de gols")]        
        public bool ValoresFixos { get; set; }

        [Range(0, 10)]
        [DisplayName("Gols de time 1")]        
        public int? ApostaTimeCasa { get; set; }

        [Range(0, 10)]
        [DisplayName("Gols de time 2")]
        public int? ApostaTimeFora { get; set; }
    
        [Range(0, 10)]
        [DisplayName("Valor Inicial")]
        public int? ValorInicial { get; set; }

        [Range(0, 10)]
        [DisplayName("Valor Final")]
        public int? ValorFinal { get; set; }
        
        [DisplayName("Substituição de apostas")]                
        public SubstituicaoApostaEnum SubstituicaoAposta { get; set; }

        [DisplayName("Tipos de apostas a serem substituídas")]
        public ApostasAutomaticasEnum? ApostasAutomaticas { get; set; }

        #endregion
    }
}
