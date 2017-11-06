using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class MensagemApp :
        Base.GenericApp<Domain.Entities.Boloes.Mensagem>,
        Application.Interfaces.Boloes.IMensagemApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IMensagemService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IMensagemService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="MensagemApp" />.
        /// </summary>
        public MensagemApp(Domain.Interfaces.Services.Boloes.IMensagemService service)
            : base (service)
        {

        }

        #endregion

        #region IMensagemApp members

        public IList<Domain.Entities.Boloes.Mensagem> GetMensagensUsuario(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetMensagensUsuario(bolao, user);
        }
        public int GetTotalMensagensNaoLidas(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetTotalMensagensNaoLidas(bolao, user);
        }

        public void SetMensagensLidas(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            Service.SetMensagensLidas(bolao, user);
        }

        #endregion


    }
}
