using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoCampeonatoClassificacaoUsuarioService :
        Base.BaseGenericService<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
        Interfaces.Services.Boloes.IBolaoCampeonatoClassificacaoUsuarioService
    {
        #region Constructors/Destructors

        public BolaoCampeonatoClassificacaoUsuarioService(string userName, Interfaces.Repositories.Boloes.IBolaoCampeonatoClassificacaoUsuarioDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>)dao)
        {

        }

        #endregion
    }
}
