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
        private Interfaces.Boloes.IJogoUsuarioBO _jogoUsuarioBO;

        #endregion

        #region Constructors/Destructors

        public BolaoFacadeBO(Interfaces.IFactoryBO factoryBO)
        {
            _bolaoBO = factoryBO.CreateBolaoBO();
            _jogoUsuarioBO = factoryBO.CreateJogoUsuarioBO();
        }

        #endregion

        public IList<Entities.Boloes.JogoUsuario> InsertJogoUsuario(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.Jogo jogo, int time1, int time2, int ? penaltis1, int ? penaltis2)
        {
            IList<Entities.Boloes.JogoUsuario> list = new List<Entities.Boloes.JogoUsuario>();

            bool res = _jogoUsuarioBO.InsertAposta(user, bolao, jogo, time1, time2, penaltis1, penaltis2);

            return list;
        }
    }
}
