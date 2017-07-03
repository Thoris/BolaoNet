using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoApp :
        Base.GenericApp<Domain.Entities.Boloes.Bolao>,
        Application.Interfaces.Boloes.IBolaoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoApp" />.
        /// </summary>
        public BolaoApp(Domain.Interfaces.Services.Boloes.IBolaoService service)
            : base (service)
        {

        }

        #endregion    
    
        #region IBolaoService members

        public bool Iniciar(Domain.Entities.Users.User iniciadoBy, Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.Iniciar(iniciadoBy, bolao);
        }

        public bool Aguardar(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.Aguardar(bolao);
        }
        public IList<Domain.Entities.Boloes.Bolao> GetBoloesDisponiveis()
        {
            return Service.GetBoloesDisponiveis();
        }

        public IList<Domain.Entities.ValueObjects.UserBoloesVO> GetBoloesUsuario(Domain.Entities.Users.User user)
        {
            return Service.GetBoloesUsuario(user);
        }

        public IList<Domain.Entities.ValueObjects.UserSaldoBolaoVO> GetBoloesSaldoUsuario(Domain.Entities.Users.User user)
        {
            return Service.GetBoloesSaldoUsuario(user);
        }

        #endregion

    }
}
