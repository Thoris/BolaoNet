using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class MensagemRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.Mensagem>, 
        Domain.Interfaces.Repositories.Boloes.IMensagemDao
    {        
        #region Constructors/Destructors

        public MensagemRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IMensagemDao members

        public IList<Domain.Entities.Boloes.Mensagem> GetMensagensUsuario(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return GetList(x => string.Compare(x.NomeBolao, bolao.Nome, true) == 0
                && string.Compare (x.ToUser, user.UserName, true) == 0)
                .OrderByDescending(x => x.CreationDate).ToList();
        }

        #endregion
    }
}
