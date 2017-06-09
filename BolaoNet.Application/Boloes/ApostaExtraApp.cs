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

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="ApostaExtraApp" />.
        /// </summary>
        public ApostaExtraApp(Domain.Interfaces.Services.Boloes.IApostaExtraService service)
            : base (Base.IGenericApp<Domain.Entities.Boloes.ApostaExtra> service)
        {

        }

        #endregion

        public IList<Domain.Entities.Boloes.ApostaExtra> GetApostasBolao(Domain.Entities.Boloes.Bolao bolao)
        {
            throw new NotImplementedException();
        }

        public bool InsertResult(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.DadosBasicos.Time time, int posicao, Domain.Entities.Users.User validadoBy)
        {
            throw new NotImplementedException();
        }
    }
}
