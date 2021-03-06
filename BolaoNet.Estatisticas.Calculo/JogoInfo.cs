﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    [Serializable]
    public class JogoInfo
    {
        #region Properties

        public int JogoId { get; set; }
        public string NomeTime1 { get; set; }
        public string NomeTime2 { get; set; }
        public int GolsTime1 { get; set; }
        public int GolsTime2 { get; set; }
        public List<ApostaJogoUsuario> Apostas { get; set; }
        public List<JogoPossibilidade> Possibilidades { get; set; }
        public bool IsValid { get; set; }
        public int PendenteIdTime1 { get; set; }
        public int PendenteIdTime2 { get; set; }
        public bool PendenteTime1Ganhador { get; set; }
        public bool PendenteTime2Ganhador { get; set; }
        public DateTime DataJogo { get; set; }

        #endregion

        #region Constructors/Destructors

        public JogoInfo()
        {
            this.Apostas = new List<ApostaJogoUsuario>();
        }
        public JogoInfo(Domain.Entities.Campeonatos.Jogo jogo)
        {
            this.JogoId = jogo.JogoId;
            this.NomeTime1 = jogo.NomeTime1;
            this.NomeTime2 = jogo.NomeTime2;
            this.GolsTime1 = jogo.GolsTime1;
            this.GolsTime2 = jogo.GolsTime2;
            this.IsValid = jogo.IsValido;
            this.Apostas = new List<ApostaJogoUsuario>();

            this.PendenteIdTime1 = jogo.PendenteIdTime1;
            this.PendenteIdTime2 = jogo.PendenteIdTime2;
            this.PendenteTime1Ganhador = jogo.PendenteTime1Ganhador;
            this.PendenteTime2Ganhador = jogo.PendenteTime2Ganhador;

            this.DataJogo = jogo.DataJogo;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            string res = this.JogoId + " - ";
            res += "[";

            if (!string.IsNullOrEmpty(this.NomeTime1))
                res += this.NomeTime1 ;

            res += "] " + this.GolsTime1 + " x " + this.GolsTime2 + " [";

            if (!string.IsNullOrEmpty(this.NomeTime2))
                res += this.NomeTime2;

            res += "] . Apostas: ";

            if (this.Apostas != null)
                res += this.Apostas.Count;
            else
                res += "null";

            res += " . Possibilidades: ";

            if (this.Possibilidades != null)
                res += this.Possibilidades.Count;
            else
                res += "null";


            return res;
        }
        public JogoInfo Clone()
        {
            JogoInfo info = new JogoInfo();
            info.JogoId = this.JogoId;
            info.NomeTime1 = this.NomeTime1 ;
            info.NomeTime2 = this.NomeTime2;
            info.GolsTime1 = this.GolsTime1;
            info.GolsTime2 = this.GolsTime2;
            info.Apostas = this.Apostas.ToList ();
            info.Possibilidades = this.Possibilidades.ToList();
            info.IsValid = this.IsValid;
            info.PendenteIdTime1 = this.PendenteIdTime1;
            info.PendenteIdTime2 = this.PendenteIdTime2;
            info.PendenteTime1Ganhador = this.PendenteTime1Ganhador;
            info.PendenteTime2Ganhador = this.PendenteTime2Ganhador;
            info.DataJogo = this.DataJogo;

            return info;
        }

        #endregion
    }
}
