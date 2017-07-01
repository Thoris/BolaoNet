using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Boloes
{
    public class PagamentoService :
        Base.BaseGenericService<Entities.Boloes.Pagamento>,
        Interfaces.Services.Boloes.IPagamentoService
    {
        #region Properties

        private Interfaces.Repositories.Boloes.IPagamentoDao Dao
        {
            get { return (Interfaces.Repositories.Boloes.IPagamentoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public PagamentoService(string userName, Interfaces.Repositories.Boloes.IPagamentoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Boloes.Pagamento>)dao, logging)
        {

        }

        #endregion

        #region IPagamentoService members

        public IList<Entities.Boloes.Pagamento> GetPagamentosBolao(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            return Dao.GetPagamentosBolao(base.CurrentUserName, DateTime.Now, bolao);
        }

        public IList<Entities.Boloes.Pagamento> GetPagamentosBolaoSoma(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");

            IList<Entities.Boloes.Pagamento> res = this.GetPagamentosBolao(bolao);

            string userName = "";

            for (int c=0; c < res.Count; c++)
            {
                if (string.Compare(res[c].UserName, userName, true) == 0)
                {
                    res[c - 1].Valor += res[c].Valor;
                    res[c - 1].Descricao += "\n" + res[c].Descricao;
                    res.RemoveAt(c);
                    c--;
                }
            }

            return res;
        }

        #endregion
    }
}
