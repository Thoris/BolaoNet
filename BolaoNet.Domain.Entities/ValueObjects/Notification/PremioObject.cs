using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects.Notification
{
    public class PremioObject
    {
        #region Properties

        public string Titulo { get; set; }
        public string ForeColorName { get; set; }
        public string BackColorName { get; set; }
        public int Posicao { get; set; }

        #endregion
    }
}
