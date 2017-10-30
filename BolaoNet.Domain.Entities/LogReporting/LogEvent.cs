using BolaoNet.Domain.Entities.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.LogReporting
{
    public class LogEvent : BaseEntity
    { 

        #region Properties

        [Key]
        public int Id { get; set; }
        public string Identity { get; set; }
        public DateTime Date { get; set; }
        public string Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }         
        public string Message { get; set; }
        public string Exception { get; set; }
        
        #endregion
    }
}
