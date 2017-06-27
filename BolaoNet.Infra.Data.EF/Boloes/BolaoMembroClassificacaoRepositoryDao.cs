using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class BolaoMembroClassificacaoRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.BolaoMembroClassificacao>, 
        Domain.Interfaces.Repositories.Boloes.IBolaoMembroClassificacaoDao
    {
        
        #region Constructors/Destructors

        public BolaoMembroClassificacaoRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IBolaoMembroClassificacaoDao members

        public IList<Domain.Entities.ValueObjects.BolaoClassificacaoVO> LoadClassificacao(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, int? rodada)
        {
            var q =
                from bm in base.DataContext.BoloesMembros

                join u in base.DataContext.Usuarios
                  on bm.UserName equals u.UserName

                join c in base.DataContext.BoloesMembrosClassificacao
                  on new { c1 = bm.UserName, c2 = bm.NomeBolao }
                  equals new { c1 = c.UserName, c2 = c.NomeBolao }

                where string.Compare(bm.NomeBolao, bolao.Nome, true) == 0
                orderby c.Posicao, c.LastPosicao, c.TotalPontos

                select new Domain.Entities.ValueObjects.BolaoClassificacaoVO()
                {
                    NomeBolao = c.NomeBolao,
                    UserName = c.UserName,

                    FullName = u.FullName,

                    Posicao = c.Posicao,
                    LastPosicao = c.LastPosicao,

                    TotalApostaExtra = c.TotalApostaExtra,
                    TotalPontos = c.TotalPontos,
                    TotalEmpate = c.TotalEmpate,
                    TotalVitoria = c.TotalVitoria,
                    TotalDerrota = c.TotalDerrota,
                    TotalGolsGanhador = c.TotalGolsGanhador,
                    TotalGolsPerdedor = c.TotalGolsPerdedor,
                    TotalResultTime1 = c.TotalResultTime1,
                    TotalResultTime2 = c.TotalResultTime2,
                    TotalVDE = c.TotalVDE,
                    TotalErro = c.TotalErro,
                    TotalGolsGanhadorFora = c.TotalGolsGanhadorFora,
                    TotalGolsGanhadorDentro = c.TotalGolsGanhadorDentro,
                    TotalPerdedorFora = c.TotalPerdedorFora,
                    TotalPerdedorDentro = c.TotalPerdedorDentro,
                    TotalGolsEmpate = c.TotalGolsEmpate,
                    TotalGolsTime1 = c.TotalGolsTime1,
                    TotalGolsTime2 = c.TotalGolsTime2,
                    TotalPlacarCheio = c.TotalPlacarCheio,

                };


            return q.ToList<Domain.Entities.ValueObjects.BolaoClassificacaoVO>();
        }

        #endregion
    }
}
