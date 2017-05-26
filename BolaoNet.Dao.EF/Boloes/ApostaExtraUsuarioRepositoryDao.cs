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
      
        public IList<Entities.Boloes.ApostaExtraUsuario> GetApostasUser(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            return base.GetList ( x => 
                string.Compare (x.NomeBolao, bolao.Nome, true) == 0 && 
                string.Compare (x.UserName, user.UserName, true) == 0).ToList<Entities.Boloes.ApostaExtraUsuario>();
        }

        #endregion


    }
}
