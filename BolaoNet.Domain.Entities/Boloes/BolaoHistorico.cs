using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public class BolaoHistorico : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 1)]
        public string NomeBolao { get; set; }

        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao { get; set; }

        [Key, Column(Order = 2)]
        public int Ano { get; set; }

        [Key, Column(Order = 3)]
        public int Posicao { get; set; }
        public string UserName { get; set; }
        public int Pontos { get; set; }
        public int TotalEmpates { get; set; }
        public int TotalVDE { get; set; }
        public int TotalGolsTime1 { get; set; }
        public int TotalGolsTime2 { get; set; }
        public int TotalCheio { get; set; }
        public int TotalExtras { get; set; }
        

        #endregion

        #region Constructors/Destructors

        public BolaoHistorico()
        {

        }
        public BolaoHistorico(string nomeBolao, int ano, int posicao)
        {
            this.NomeBolao = nomeBolao;
            this.Ano = ano;
            this.Posicao = posicao;
        }

        #endregion
    }
}
