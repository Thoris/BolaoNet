﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class CampeonatoTime : Base.AuditModel
    {
        #region Properties

        
        [ForeignKey("NomeTime")]
        public virtual DadosBasicos.Time Time { get; set; }
        [Key, Column(Order = 0)]
        public string NomeTime { get; set; }

        [ForeignKey("NomeCampeonato")]
        public virtual Campeonato Campeonato { get; set; }
        [Key, Column(Order = 1)]
        public string NomeCampeonato { get; set; }

        #endregion
    }
}