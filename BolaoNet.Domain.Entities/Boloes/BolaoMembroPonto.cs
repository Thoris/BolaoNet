﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public class BolaoMembroPonto : Entities.Boloes.Pontuacao
    {
        #region Properties

        [Key, Column(Order = 1)]
        public string NomeCampeonato { get; set; }

        [Key, Column(Order = 2)]
        public string NomeFase { get; set; }
        
        [Key, Column(Order = 3)]
        public string NomeGrupo { get; set; }

        [Key, Column(Order = 4)]
        public string NomeBolao { get; set; }
        
        
        [Key, Column(Order = 5)]
        public string UserName { get; set; }
                      
        [Key, Column(Order = 6)]
        public int Rodada { get; set; }


        public int? Posicao { get; set; }
        public int? LastPosicao { get; set; }
        public bool IsMultiploTime { get; set; }

        [ForeignKey("NomeBolao, UserName")]
        public virtual BolaoMembro BolaoMembro { get; set; }

        [ForeignKey("NomeCampeonato, NomeGrupo")]
        public virtual Campeonatos.CampeonatoGrupo CampeonatoGrupo {get; set;}

        [ForeignKey("NomeCampeonato, NomeFase")]
        public virtual Campeonatos.CampeonatoFase CampeonatoFase { get; set; }

        #endregion

        #region Constructors/Destructors

        public BolaoMembroPonto(string userName, string nomeBolao, string nomeCampeonato, string nomeFase, string nomeGrupo, int rodada)
        {
            this.UserName = userName;
            this.NomeBolao = nomeBolao;
            this.NomeCampeonato = nomeCampeonato;
            this.NomeFase = nomeFase;
            this.NomeGrupo = nomeGrupo;
            this.Rodada = rodada;
        }
        public BolaoMembroPonto()
        {

        }

        #endregion
    }
}
