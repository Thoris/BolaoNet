using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
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
        public Status StatusRequestID { get; set; }
        public string Owner { get; set; }
        public DateTime RequestedDate { get; set; }
        public string RequestedBy { get; set; }
        public int RequestID { get; set; }
        public Bolao Bolao { get; set; }

        #endregion
    }
}
