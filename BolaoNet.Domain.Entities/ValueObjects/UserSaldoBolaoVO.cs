using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects
{
    public class UserSaldoBolaoVO
    {
        #region Properties

        public string NomeBolao { get; set; }
        public string UserName { get; set; }
        public DateTime ? DataInicio { get; set; }
        public decimal Valor { get; set; }
        public decimal TaxaParticipacao { get; set; }
        
        #endregion
    }
}
