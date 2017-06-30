using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class ApostaExtraUsuarioApp :
        Base.GenericApp<Domain.Entities.Boloes.ApostaExtraUsuario>,
        Application.Interfaces.Boloes.IApostaExtraUsuarioApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostaExtraUsuarioApp" />.
        /// </summary>
        public ApostaExtraUsuarioApp(Domain.Interfaces.Services.Boloes.IApostaExtraUsuarioService service)
            : base (service)
        {

        }

        #endregion

        #region IApostaExtraUsuarioService members

        public IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO> GetApostasUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetApostasUser(bolao, user);
        }
        public IList<Domain.Entities.Boloes.ApostaExtraUsuario> GetApostasBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetApostasBolao(bolao);
        }

        public IList<IList<Domain.Entities.Boloes.ApostaExtraUsuario>> GetApostasBolaoAgrupado(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetApostasBolaoAgrupado(bolao);
        }
        #endregion



    }
}
