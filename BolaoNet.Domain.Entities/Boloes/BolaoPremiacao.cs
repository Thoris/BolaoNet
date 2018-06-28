using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public class BolaoPremiacao : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 1)]
        public string NomeBolao { get; set; }

        [ForeignKey("NomeBolao")]
        public virtual Entities.Boloes.Bolao Bolao { get; set; }

        [Key, Column(Order = 2)]
        public int Posicao { get; set; }

        public double Percentual { get; set; }
        
        public double Valor { get; set; }

        #endregion

        #region Constructors/Destructors

        public BolaoPremiacao()
        {

        }
        public BolaoPremiacao(string nomeBolao, int posicao)
        { 
            this.NomeBolao = nomeBolao;
            this.Posicao = posicao;
        }

        #endregion
    }
}
