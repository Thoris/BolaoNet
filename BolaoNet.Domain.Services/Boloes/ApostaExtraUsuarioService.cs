using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class ApostaExtraUsuarioService :
        Base.BaseGenericService<Entities.Boloes.ApostaExtraUsuario>,
        Interfaces.Services.Boloes.IApostaExtraUsuarioService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IApostaExtraUsuarioDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IApostaExtraUsuarioDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraUsuarioService(string userName, Interfaces.Repositories.Boloes.IApostaExtraUsuarioDao dao)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.ApostaExtraUsuario>)dao)
        {

        }

        #endregion

        #region IApostaExtraUsuariosBO members

        public IList<Entities.Boloes.ApostaExtraUsuario> GetApostasUser(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");


            return Dao.GetApostasUser(this.CurrentUserName, bolao, user);
        }

        #endregion
    }
}
