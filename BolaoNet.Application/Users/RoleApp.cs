using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Users
{
    public class RoleApp :
        Base.GenericApp<Domain.Entities.Users.Role>,
        Application.Interfaces.Users.IRoleApp
    {
        #region Properties

        private Domain.Interfaces.Services.Users.IRoleService Service
        {
            get { return (Domain.Interfaces.Services.Users.IRoleService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="RoleApp" />.
        /// </summary>
        public RoleApp(Domain.Interfaces.Services.Users.IRoleService service)
            : base (service)
        {

        }

        #endregion
    }
}
