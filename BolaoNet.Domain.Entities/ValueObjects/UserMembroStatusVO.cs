using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects
{
    public class UserMembroStatusVO
    {
        #region Properties

        public string NomeBolao { get; set; }
        public string UserName { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public int Restantes { get; set; }
        public decimal Pago { get; set; }

        #endregion
    }
}
