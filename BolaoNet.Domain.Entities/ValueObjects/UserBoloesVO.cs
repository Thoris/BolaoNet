using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects
{
    public class UserBoloesVO
    {
        #region Properties

        public string NomeBolao { get; set; }
        public string NomeCampeonato { get; set; }
        public int Membros { get; set; }
        public int Position { get; set; }
        public int ApostasRestantes { get; set; }

        #endregion
    }
}
