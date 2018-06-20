using BolaoNet.Domain.Entities.Boloes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Estatisticas.Calculo
{
    [Serializable]
    public class CriterioPontosTimes
    {
        #region Properties

        public string NomeTime { get; set; }
        public int MultiploTime { get; set; }

        #endregion

        #region Constructors/Destructors

        public CriterioPontosTimes()
        {

        }

        public CriterioPontosTimes(BolaoCriterioPontosTimes entity)
        {
            this.NomeTime = entity.NomeTime;
            this.MultiploTime = entity.MultiploTime;
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            if (string.IsNullOrEmpty(this.NomeTime))
                return MultiploTime.ToString();
            else
                return this.NomeTime + ". Pontos: " + this.MultiploTime;
   
        }

        #endregion
    }
}
