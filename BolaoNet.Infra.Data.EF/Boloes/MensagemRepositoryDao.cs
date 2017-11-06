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
        public int GetTotalMensagensNaoLidas(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return GetList(x => string.Compare(x.NomeBolao, bolao.Nome, true) == 0
                && string.Compare(x.ToUser, user.UserName, true) == 0
                && x.TotalRead == 0).Count;
        }

        public void SetMensagensLidas(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            
            base.DataContext.Mensagens
                .Where(p => p.TotalRead == 0 && 
                    string.Compare(p.ToUser, user.UserName, true) == 0 && 
                    string.Compare(p.NomeBolao, bolao.Nome, true) == 0)
                .ToList()
                .ForEach(x => x.TotalRead = 1);

            base.DataContext.SaveChanges();
        }
        #endregion
    }
}
