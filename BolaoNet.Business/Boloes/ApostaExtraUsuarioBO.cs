using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Boloes
{
    public class ApostaExtraUsuarioBO :
        Base.BaseGenericBusinessBO<Entities.Boloes.ApostaExtraUsuario>,
        Interfaces.Boloes.IApostaExtraUsuarioBO
    {
        #region Properties

        private Dao.Boloes.IApostaExtraUsuarioDao Dao
        {
            get { return (Dao.Boloes.IApostaExtraUsuarioDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public ApostaExtraUsuarioBO(string userName, Dao.Boloes.IApostaExtraUsuarioDao dao)
            : base(userName, (Dao.Base.IGenericDao<Entities.Boloes.ApostaExtraUsuario>)dao)
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
