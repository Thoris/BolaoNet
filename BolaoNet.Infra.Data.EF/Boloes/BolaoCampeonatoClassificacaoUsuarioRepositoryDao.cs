using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoCampeonatoClassificacaoUsuarioRepositoryDao : 
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>,
        Domain.Interfaces.Repositories.Boloes.IBolaoCampeonatoClassificacaoUsuarioDao
    {
        
        #region Constructors/Destructors

        public BolaoCampeonatoClassificacaoUsuarioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IBolaoCampeonatoClassificacaoUsuarioDao members

        public IList<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> LoadClassificacao(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, Domain.Entities.Users.User user)
        {

            var q =
                from c in base.DataContext.BoloesCampeonatosClassificacaoUsuarios

                join b in base.DataContext.Boloes
                  on new { c1 = c.NomeCampeonato }
                  equals new { c1 = b.NomeCampeonato }

                where string.Compare(c.NomeBolao, bolao.Nome, true) == 0 &&
                      string.Compare(c.NomeFase, fase.Nome, true) == 0 &&
                      string.Compare(c.NomeGrupo, grupo.Nome, true) == 0 &&
                      string.Compare(c.UserName, user.UserName, true) == 0
                orderby c.TotalPontos descending, c.TotalVitorias descending, (c.TotalGolsPro - c.TotalGolsContra) descending, c.TotalGolsPro descending, c.TotalVitorias descending
                select c;


            return q.ToList();

        }

        #endregion
    }
}
