using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class BolaoService :
        Base.BaseGenericService<Entities.Boloes.Bolao>,
        Interfaces.Services.Boloes.IBolaoService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IBolaoDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IBolaoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public BolaoService(string userName, Interfaces.Repositories.Boloes.IBolaoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.Bolao>)dao, logging)
        {

        }

        #endregion

        #region IBolaoBO members

        public bool Iniciar(Entities.Users.User iniciadoBy, Entities.Boloes.Bolao bolao)
        {
            if (iniciadoBy == null)
                throw new ArgumentException("iniciadoBy");
            if (string.IsNullOrEmpty(iniciadoBy.UserName))
                throw new ArgumentException("iniciadoBy.UserName");
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.Iniciar(base.CurrentUserName, DateTime.Now, iniciadoBy, bolao);
        }

        public bool Aguardar(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.Aguardar(base.CurrentUserName, DateTime.Now,  bolao);
        }
        public IList<Entities.Boloes.Bolao> GetBoloesDisponiveis()
        {
            return Dao.GetBoloesDisponiveis(base.CurrentUserName, DateTime.Now);
        }
        public IList<Entities.ValueObjects.UserBoloesVO> GetBoloesUsuario(Entities.Users.User user)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");

            return Dao.GetBoloesUsuario(base.CurrentUserName, DateTime.Now, user);
        }
        public IList<Entities.ValueObjects.UserSaldoBolaoVO> GetBoloesSaldoUsuario(Entities.Users.User user)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");

            return Dao.GetBoloesSaldoUsuario(base.CurrentUserName, DateTime.Now, user);
        }

        #endregion






    }
}
