using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.LogReporting
{ 
    public class LogEvent
    { 

        #region Properties

        public string Id { get; set; }
        public string Identity { get; set; }
        public DateTime Date { get; set; }
        public int Thread { get; set; }
        public string Level { get; set; }
        public string Logger { get; set; }         
        public string Message { get; set; }
        public string Exception { get; set; }
        
        #endregion
    }
}
