using BolaoNet.Domain.Interfaces.Services.Logging;
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

        public ApostaExtraUsuarioService(string userName, Interfaces.Repositories.Boloes.IApostaExtraUsuarioDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.ApostaExtraUsuario>)dao, logging)
        {

        }

        #endregion

        #region IApostaExtraUsuariosBO members

        public IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO> GetApostasUser(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");


            return Dao.GetApostasUser(this.CurrentUserName, DateTime.Now, bolao, user);
        }
        public IList<Entities.Boloes.ApostaExtraUsuario> GetApostasBolao(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.GetApostasBolao(this.CurrentUserName, DateTime.Now, bolao);
        }

        public IList<IList<Entities.Boloes.ApostaExtraUsuario>> GetApostasBolaoAgrupado(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");


            IList<Entities.Boloes.ApostaExtraUsuario> list = GetApostasBolao(bolao);

            IList<IList<Entities.Boloes.ApostaExtraUsuario>> res = new List<IList<Entities.Boloes.ApostaExtraUsuario>>();

            string currentUserName = "";

            for (int c = 0; c < list.Count; c++ )
            {
                if (string.Compare (list[c].UserName, currentUserName, true) == 0)
                {
                    res[res.Count - 1].Add(list[c]);
                }
                else
                {
                    res.Add (new List<Entities.Boloes.ApostaExtraUsuario>());
                    res[res.Count - 1].Add(list[c]);
                    currentUserName = list[c].UserName;
                }
            }


            return res;
        }

        #endregion
    }
}
