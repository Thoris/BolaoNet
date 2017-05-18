using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoCriterioPontos : Base.AuditModel
    {
        #region Enumerations
        public enum CriteriosID
        {
            Undefined = 0,
            Empate = 1,
            Vitoria = 2,
            Derrota = 3,
            Ganhador = 4,
            Perdedor = 5,
            Time1 = 6,
            Time2 = 7,
            VitoriaDerrotaEmpate = 8,
            Erro = 9,
            GanhadorFora = 10,
            GanhadorDentro = 11,
            PerdedorFora = 12,
            PerdedorDentro = 13,
            EmpateGols = 14,
            GolsTime1 = 15,
            GolsTime2 = 16,
            Cheio = 17,
        }
        #endregion

        #region Properties

        [Key, Column(Order=0)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao { get; set; }

        [Key, Column(Order=1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public CriteriosID CriterioID { get; set; }

        public int ? Pontos { get; set; }
        public string Descricao { get; set; }

        //public string NomeTime { get; set; }
        //[ForeignKey("NomeTime")]
        //public virtual Entities.DadosBasicos.Time Time { get; set; }

        //public int ? MultiploTime { get; set; }
        
        #endregion

        #region Constructors/Destructors

        public BolaoCriterioPontos()
        {

        }
        public BolaoCriterioPontos(string nomeBolao, CriteriosID criterioID)
        {
            this.NomeBolao = nomeBolao;
            this.CriterioID = criterioID;
        }

        #endregion
    }
}
