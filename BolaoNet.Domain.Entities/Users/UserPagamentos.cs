using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Users
{
    public class UserPagamentos : Base.AuditModel
    {
        #region Properties

        public decimal Devendo
        {
            get
            {
                decimal saldo = this.Total - this.Valor;

                if (saldo < 0)
                    saldo = 0;

                return saldo;
            }
        }
        public Campeonatos.Campeonato Campeonato { get; set; }
        public decimal Valor { get; set; }
        public Boloes.Bolao Bolao { get; set; }
        public decimal Total { get; set; }
        public DateTime DataInicio { get; set; }

        #endregion
        
        #region Constructors/Destructors

        public UserPagamentos()
        {

        }

        #endregion
    }
}
