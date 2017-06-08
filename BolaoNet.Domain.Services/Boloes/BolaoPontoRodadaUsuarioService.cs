using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoPontoRodadaUsuarioService :
        Base.BaseGenericService<Entities.Boloes.BolaoPontoRodadaUsuario>,
        Interfaces.Services.Boloes.IBolaoPontoRodadaUsuarioService
    {
        #region Constructors/Destructors

        public BolaoPontoRodadaUsuarioService(string userName, Interfaces.Repositories.Boloes.IBolaoPontoRodadaUsuarioDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoPontoRodadaUsuario>)dao)
        {

        }

        #endregion
    }
}
