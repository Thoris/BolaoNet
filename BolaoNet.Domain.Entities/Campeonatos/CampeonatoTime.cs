﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Campeonatos
{
    public class CampeonatoTime : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 1)]
        public string NomeCampeonato { get; set; }
        [ForeignKey("NomeCampeonato")]
        public virtual Campeonato Campeonato { get; set; }
        
        
        [Key, Column(Order = 2)]
        public string NomeTime { get; set; }
        [ForeignKey("NomeTime")]
        public virtual DadosBasicos.Time Time { get; set; }
        


        #endregion

        #region Constructors/Destructors

        public CampeonatoTime()
        {

        }
        public CampeonatoTime(string nomeTime, string nomeCampeonato)
        {
            this.NomeTime = nomeTime;
            this.NomeCampeonato = nomeCampeonato;
        }

        #endregion

    }
}
