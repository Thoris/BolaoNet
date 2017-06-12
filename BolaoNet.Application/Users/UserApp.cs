using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Users
{
    public class UserApp :
        Base.GenericApp<Domain.Entities.Users.User>,
        Application.Interfaces.Users.IUserApp
    {
        #region Properties

        private Domain.Interfaces.Services.Users.IUserService Service
        {
            get { return (Domain.Interfaces.Services.Users.IUserService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="UserApp" />.
        /// </summary>
        public UserApp(Domain.Interfaces.Services.Users.IUserService service)
            : base (service)
        {

        }

        #endregion
    }
}
