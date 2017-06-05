using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public class Mensagem : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 1)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public Entities.Boloes.Bolao Bolao { get; set; }

        [Key, Column(Order = 2)]
        public long MessageID { get; set; }

        public string FromFullName { get; set; }
        public long AnsweredMessageID { get; set; }
        public int TotalRead { get; set; }                
        public string FromUser { get; set; }
        public string ToUser { get; set; }
        public bool Private { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }

        #endregion

        #region Constructors/Destructors

        public Mensagem()
        {

        }
        public Mensagem (string nomeBolao, int messageID)
        {
            this.NomeBolao = nomeBolao;
            this.MessageID = messageID;

        }

        #endregion
    }
}
