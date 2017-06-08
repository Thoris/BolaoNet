using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoPontoRodadaService :
        Base.BaseGenericService<Entities.Boloes.BolaoPontoRodada>,
        Interfaces.Services.Boloes.IBolaoPontoRodadaService
    {
        #region Constructors/Destructors

        public BolaoPontoRodadaService(string userName, Interfaces.Repositories.Boloes.IBolaoPontoRodadaDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoPontoRodada>)dao)
        {

        }

        #endregion
    }
}
