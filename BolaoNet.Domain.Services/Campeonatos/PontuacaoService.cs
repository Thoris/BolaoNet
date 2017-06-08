using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class PontuacaoService :
        Base.BaseGenericService<Entities.Campeonatos.Pontuacao>,
        Interfaces.Services.Campeonatos.IPontuacaoService
    {
        #region Constructors/Destructors

        public PontuacaoService(string userName, Interfaces.Repositories.Campeonatos.IPontuacaoDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.Pontuacao>)dao)
        {

        }

        #endregion
    }
}
