using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoPosicaoService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoPosicao>,
        Interfaces.Services.Campeonatos.ICampeonatoPosicaoService
    {
        #region Constructors/Destructors

        public CampeonatoPosicaoService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoPosicaoDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoPosicao>)dao)
        {

        }

        #endregion
    }
}
