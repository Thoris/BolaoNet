using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoMembroGrupoRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoMembroGrupo>,
        Domain.Interfaces.Repositories.Boloes.IBolaoMembroGrupoDao
    {
        
        #region Constructors/Destructors

        public BolaoMembroGrupoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IBolaoMembroGrupoDao members

        public IList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO> LoadClassificacao(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            var q =
                from bmg in base.DataContext.BoloesMembrosGrupos

                join u in base.DataContext.Usuarios
                  on bmg.UserNameSelecionado equals u.UserName

                join bmc in base.DataContext.BoloesMembrosClassificacao
                        on new { c1 = bmg.UserNameSelecionado, c2 = bmg.NomeBolao }
                    equals new { c1 = bmc.UserName, c2 = bmc.NomeBolao }
                into gbmc

                from p in gbmc.DefaultIfEmpty()

                where (string.Compare(bmg.NomeBolao, bolao.Nome, true) == 0) &&
                  string.Compare(bmg.UserName, user.UserName, true) == 0

                select new Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO()
                {
                    UserName = bmg.UserNameSelecionado, 
                    FullName = u.FullName, 
                    LastPosicao = p.LastPosicao,
                    Posicao = p.Posicao, 
                    PosicaoGeral = p.Posicao,
                    TotalPontos = p.TotalPontos
                };

            return q.ToList<Domain.Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO>();
        }

        #endregion
    }
}
