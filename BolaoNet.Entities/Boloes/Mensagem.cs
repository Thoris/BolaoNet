using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class Mensagem : Base.AuditModel
    {
        #region Properties

        public string FromFullName {get;set;}
        public long AnsweredMessageID {get;set;}
        public int TotalRead{get;set;}
        public long MessageID{get;set;}
        public Entities.Boloes.Bolao Bolao{get;set;}
        public string FromUser{get;set;}
        public string ToUser{get;set;}
        public bool Private{get;set;}
        public DateTime CreationDate {get;set;}
        public string Title{get;set;}
        public string Message{get;set;}

        #endregion
    }
}
