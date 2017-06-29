﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class ApostasJogoViewModel 
    {
        #region Constants

        private const string FormatIcon = "/Content/img/database/times/{0}.gif";

        #endregion

        #region Properties

        public string ImageTime1
        {
            get
            {
                return string.Format(FormatIcon, this.NomeTime1);
            }
        }
        public string ImageTime2
        {
            get
            {
                return string.Format(FormatIcon, this.NomeTime2);
            }
        }
        public string NomeCampeonato { get; set; }
        

        public int JogoId { get; set; }



        public string NomeTime1 { get; set; }
        

        public string DescricaoTime1 { get; set; }
        public int GolsTime1 { get; set; }
        public int? PenaltisTime1 { get; set; }

        public string NomeTime2 { get; set; }
        
        public string DescricaoTime2 { get; set; }
        public int GolsTime2 { get; set; }
        public int? PenaltisTime2 { get; set; }

        public string NomeEstadio { get; set; }
        
        public DateTime DataJogo { get; set; }
        
        public int Rodada { get; set; }
        public bool PartidaValida { get; set; }
        public DateTime? DataValidacao { get; set; }


        public string NomeFase { get; set; }
        
        public string NomeGrupo { get; set; }
        public bool IsValido { get; set; }
        public string ValidadoBy { get; set; }
        public string Titulo { get; set; }

        public int PendenteIdTime1 { get; set; }
        public int PendenteIdTime2 { get; set; }
        public bool PendenteTime1Ganhador { get; set; }
        public bool PendenteTime2Ganhador { get; set; }
        public string PendenteTime1NomeGrupo { get; set; }
        public string PendenteTime2NomeGrupo { get; set; }
        public int PendenteTime1PosGrupo { get; set; }
        public int PendenteTime2PosGrupo { get; set; }

        public bool? IsDesempate { get; set; }


        public IList<ApostaJogoUsuarioPontosViewModel> Apostas { get; set; }

        #endregion
    }
}