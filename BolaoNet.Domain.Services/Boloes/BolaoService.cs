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


            if (IsSaveLog)
                CheckStart();

            bool res = Dao.Iniciar(base.CurrentUserName, DateTime.Now, iniciadoBy, bolao);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Início do bolão [" + bolao.Nome + "] por [" + iniciadoBy.UserName + "] res: " + res));
            }

            return res;
        }

        public bool Aguardar(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");


            if (IsSaveLog)
                CheckStart();

            bool res = Dao.Aguardar(base.CurrentUserName, DateTime.Now,  bolao);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Aguardando o bolão [" + bolao.Nome + "] res: " + res));
            }

            return res;
        }
        public IList<Entities.Boloes.Bolao> GetBoloesDisponiveis()
        {

            if (IsSaveLog)
                CheckStart();

            IList<Entities.Boloes.Bolao> res = Dao.GetBoloesDisponiveis(base.CurrentUserName, DateTime.Now);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Verificando os bolões disponíveis. total: " + res.Count));
            }

            return res;
        }
        public IList<Entities.ValueObjects.UserBoloesVO> GetBoloesUsuario(Entities.Users.User user)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");


            if (IsSaveLog)
                CheckStart();

            IList<Entities.ValueObjects.UserBoloesVO> res = Dao.GetBoloesUsuario(base.CurrentUserName, DateTime.Now, user);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Carregamento de bolões do usuário [" + user.UserName + "] total: " + res.Count));
            }

            return res;
        }
        public IList<Entities.ValueObjects.UserSaldoBolaoVO> GetBoloesSaldoUsuario(Entities.Users.User user)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");


            if (IsSaveLog)
                CheckStart();

            IList<Entities.ValueObjects.UserSaldoBolaoVO> res =
                Dao.GetBoloesSaldoUsuario(base.CurrentUserName, DateTime.Now, user);


            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Buscando saldo de pagamento do usuário [" + user.UserName + "] total: " + res.Count));
            }

            return res;
        }
        public bool IsIniciado(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");


            if (IsSaveLog)
                CheckStart();

            bool res = Dao.IsIniciado(base.CurrentUserName, DateTime.Now, bolao);



            if (IsSaveLog)
            {
                _logging.Debug(this, GetMessageTotalTime("Verificação se o bolão [" + bolao.Nome + "] está iniciado. res: " + res));
            }

            return res;
        }

        #endregion


    }
}
