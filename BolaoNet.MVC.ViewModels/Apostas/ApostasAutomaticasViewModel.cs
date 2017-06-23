using System;
using System.Collections.Generic;
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

        // public TipoApostaEnum TipoAposta { get; set; }
        public int TipoAposta { get; set; }

        //Periodo
        public DateTime ? DataInicial { get; set; }
        public DateTime ? DataFinal { get; set; }

        //Rodada
        public int ? Rodada { get; set; }
        
        public bool ValoresFixos { get; set; }

        public int? ApostaTimeCasa { get; set; }
        public int? ApostaTimeFora { get; set; }

        public int? ValorInicial { get; set; }
        public int? ValorFinal { get; set; }

        public SubstituicaoApostaEnum SubstituicaoAposta { get; set; }
        public ApostasAutomaticasEnum ApostasAutomaticas { get; set; }

        #endregion
    }
}
