using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class ApostaExtraUsuarioRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.ApostaExtraUsuario>, Domain.Interfaces.Repositories.Boloes.IApostaExtraUsuarioDao
    {
        
        #region Constructors/Destructors

        public ApostaExtraUsuarioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IApostaExtraUsuarioDao members
      
        public IList<Domain.Entities.Boloes.ApostaExtraUsuario> GetApostasUser(string currentUserName, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return base.GetList ( x => 
                string.Compare (x.NomeBolao, bolao.Nome, true) == 0 && 
                string.Compare (x.UserName, user.UserName, true) == 0).ToList<Domain.Entities.Boloes.ApostaExtraUsuario>();
        }

        #endregion


    }
}
