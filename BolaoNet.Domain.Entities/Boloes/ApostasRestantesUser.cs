using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public class ApostasRestantesUser 
    {       
        #region Properties
        
        public int ApostasRestantes {get;set;}
        public decimal PagamentoRestante {get;set;}
        public bool IsPago
        {
            get
            {
                if (this.PagamentoRestante > 0)
                    return false;
                else
                    return true;
            }
        }

        #endregion

        #region Constructors/Destructors

        public ApostasRestantesUser()
        {

        }

        #endregion
    }
}
