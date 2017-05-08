using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class ApostaExtraUsuarioRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.ApostaExtraUsuario>, Dao.Boloes.IApostaExtraUsuarioDao
    {
        
        #region Constructors/Destructors

        public ApostaExtraUsuarioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IApostaExtraUsuarioDao members

        public IList<Entities.Boloes.ApostaExtraUsuario> SelectByUser(string currentUserName, Entities.Boloes.Bolao bolao, string userName, string condition)
        {
            throw new NotImplementedException();
        }

        public IList<Entities.Boloes.ApostaExtraUsuario> SelectByPosicao(string currentUserName, Entities.Boloes.Bolao bolao, int posicao, string condition)
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
