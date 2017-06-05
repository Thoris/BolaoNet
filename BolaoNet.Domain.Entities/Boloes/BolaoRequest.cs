using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public class BolaoRequest : Base.AuditModel
    {
        #region Enumeration

        public enum Status
        {
            Participar = 1,
            Retirar = 2,
            Aprovado = 3,
            Rejeitado = 4,
            Removido = 5,
            Mantido = 6,
            Convidado = 7,
        }

        #endregion

        #region Properties

        public string Descricao { get; set; }
        public DateTime AnsweredDate { get; set; }
        public string AnsweredBy { get; set; }
        //public Status StatusRequestID { get; set; }

        public int StatusRequestID { get; set; }
        [ForeignKey("StatusRequestID")]
        public virtual BolaoRequestStatus BolaoRequestStatus { get; set; }

        public string Owner { get; set; }
        public DateTime RequestedDate { get; set; }
        public string RequestedBy { get; set; }

        
        [Key, Column(Order=1)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao { get; set; }

        [Key, Column(Order = 2)]
        public int RequestID { get; set; }


        #endregion

        #region Constructors/Destructors

        public BolaoRequest(int requestID, string nomeBolao)
        {
            this.RequestID = requestID;
            this.NomeBolao = nomeBolao;
        }
        public BolaoRequest()
        {

        }

        #endregion
    }
}
