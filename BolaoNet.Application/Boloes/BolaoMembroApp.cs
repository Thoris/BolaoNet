using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoMembroApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoMembro>,
        Application.Interfaces.Boloes.IBolaoMembroApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoMembroService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoMembroService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoMembroApp" />.
        /// </summary>
        public BolaoMembroApp(Domain.Interfaces.Services.Boloes.IBolaoMembroService service)
            : base (service)
        {

        }

        #endregion

        #region IBolaoMembroService members

        public IList<Domain.Entities.Boloes.BolaoMembro> GetListUsersInBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetListUsersInBolao(bolao);
        }
        public IList<Domain.Entities.Boloes.BolaoMembro> GetListBolaoInUsers(Domain.Entities.Users.User user)
        {
            return Service.GetListBolaoInUsers(user);
        }

        #endregion


    }
}
