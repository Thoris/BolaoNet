using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Facade
{
    public class BolaoFacadeBO : Interfaces.Facade.IBolaoFacadeBO
    {
        #region Variables

        private Interfaces.Boloes.IBolaoBO _bolaoBO;

        #endregion

        #region Constructors/Destructors

        public BolaoFacadeBO(Interfaces.IFactoryBO factoryBO)
        {
            _bolaoBO = factoryBO.CreateBolaoBO();
        }

        #endregion

        public IList<Entities.Boloes.JogoUsuario> InsertJogoUsuario(Entities.Boloes.JogoUsuario jogo)
        {
            throw new NotImplementedException();
        }
    }
}
