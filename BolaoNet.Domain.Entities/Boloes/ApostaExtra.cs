﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public class ApostaExtra : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 1)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao { get; set; }


        [Key, Column(Order = 2)]
        public int Posicao { get; set; }
        


        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int ? TotalPontos { get; set; }
        public bool ? IsValido { get; set; }
        public DateTime ? DataValidacao { get; set; }
        public string ValidadoBy { get; set; }

        public string NomeTimeValidado { get; set; }
        [ForeignKey("NomeTimeValidado")]
        public virtual DadosBasicos.Time TimeValidado { get; set; }

        #endregion

        #region Constructors/Destructors

        public ApostaExtra()
        {

        }
        public ApostaExtra(string nomeBolao, int posicao)
        {
            this.NomeBolao = nomeBolao;
            this.Posicao = posicao;
        }


        #endregion
    }
}
