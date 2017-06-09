using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class ApostaExtraApp :
        Base.GenericApp<Domain.Entities.Boloes.ApostaExtra>, 
        Domain.Interfaces.Services.Boloes.IApostaExtraService
    {

        #region Properties

        private Domain.Interfaces.Services.Boloes.IApostaExtraService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IApostaExtraService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostaExtraApp" />.
        /// </summary>
        public ApostaExtraApp(Domain.Interfaces.Services.Boloes.IApostaExtraService service)
            : base(service)
        {

        }

        #endregion

        #region IApostaExtraService members

        public IList<Domain.Entities.Boloes.ApostaExtra> GetApostasBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            return Service.GetApostasBolao(bolao);
        }

        public bool InsertResult(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.DadosBasicos.Time time, int posicao, Domain.Entities.Users.User validadoBy)
        {
            return Service.InsertResult(bolao, time, posicao, validadoBy);
        }

        #endregion
    }
}
