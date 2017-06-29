using BolaoNet.Domain.Interfaces.Services.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Campeonatos
{
    public class CampeonatoClassificacaoService :
        Base.BaseGenericService<Entities.Campeonatos.CampeonatoClassificacao>,
        Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService
    {
        #region Properties

        private Interfaces.Repositories.Campeonatos.ICampeonatoClassificacaoDao Dao
        {
            get { return (Interfaces.Repositories.Campeonatos.ICampeonatoClassificacaoDao)base.BaseDao; }
        }

        #endregion

        #region Constructors/Destructors

        public CampeonatoClassificacaoService(string userName, Interfaces.Repositories.Campeonatos.ICampeonatoClassificacaoDao dao, ILogging logging)
            : base(userName, (Interfaces.Repositories.Base.IGenericDao<Entities.Campeonatos.CampeonatoClassificacao>)dao, logging)
        {

        }

        #endregion

        #region ICampeonatoClassificacaoService members

        public IList<Entities.Campeonatos.CampeonatoClassificacao> LoadClassificacao(Entities.Campeonatos.Campeonato campeonato, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo, int rodada)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");
            if (fase == null)
                throw new ArgumentException("fase");
            if (string.IsNullOrEmpty(fase.Nome))
                throw new ArgumentException("fase.Nome");
            if (grupo == null)
                throw new ArgumentException("grupo");
            if (string.IsNullOrEmpty(grupo.Nome))
                throw new ArgumentException("grupo.Nome");


            return Dao.LoadClassificacao(base.CurrentUserName, DateTime.Now, campeonato, fase, grupo, rodada);
        }

        #endregion
    }
}
