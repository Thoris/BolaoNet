using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class BolaoMembroGrupoApp :
        Base.GenericApp<Domain.Entities.Boloes.BolaoMembroGrupo>,
        Application.Interfaces.Boloes.IBolaoMembroGrupoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="BolaoMembroGrupoApp" />.
        /// </summary>
        public BolaoMembroGrupoApp(Domain.Interfaces.Services.Boloes.IBolaoMembroGrupoService service)
            : base (service)
        {

        }

        #endregion

        #region IBolaoMembroGrupoApp members

        public IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO> LoadClassificacao(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.LoadClassificacao(bolao, user);
        }

        #endregion
    }
}
