using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoPremio : DadosBasicos.HighLightItem
    {
        #region Properties

        [Key,Column(Order=0)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Entities.Boloes.Bolao Bolao {get;set; }

        [Key, Column(Order=1)]
        public int Posicao { get; set; }

        #endregion

        #region Constructors/Destructors

        public BolaoPremio()
        {

        }
        public BolaoPremio(string nomeBolao, int posicao)
        {
            this.NomeBolao = nomeBolao;
            this.Posicao = posicao;
        }

        #endregion
    }
}
