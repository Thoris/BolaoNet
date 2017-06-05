using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public class BolaoPontuacao : DadosBasicos.HighLightItem
    {
        #region Properties

        [Key, Column(Order=0)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Entities.Boloes.Bolao Bolao {get;set;}

        [Key, Column(Order=1)]
        public int Pontos { get; set; }

        #endregion
        
        #region Constructors/Destructors

        public BolaoPontuacao()
        {

        }
        public BolaoPontuacao(string nomeBolao, int pontos)
        {
            this.NomeBolao = nomeBolao;
            this.Pontos = pontos;
        }

        #endregion
    }
}
