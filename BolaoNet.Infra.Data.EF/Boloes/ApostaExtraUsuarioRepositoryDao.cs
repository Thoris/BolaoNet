using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class ApostaExtraUsuarioRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.ApostaExtraUsuario>, 
        Domain.Interfaces.Repositories.Boloes.IApostaExtraUsuarioDao
    {
        
        #region Constructors/Destructors

        public ApostaExtraUsuarioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IApostaExtraUsuarioDao members
      
        public IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO> GetApostasUser(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            //return base.GetList ( x => 
            //    string.Compare (x.NomeBolao, bolao.Nome, true) == 0 && 
            //    string.Compare (x.UserName, user.UserName, true) == 0).ToList<Domain.Entities.Boloes.ApostaExtraUsuario>();


            var q =
                from j in base.DataContext.ApostasExtras


                join u in base.DataContext.ApostasExtrasUsuarios
                        on new { c1 = j.NomeBolao, c2 = j.Posicao, c3 = user.UserName }
                    equals new { c1 = u.NomeBolao, c2 = u.Posicao, c3 = u.UserName }
                into ju
                from p in ju.DefaultIfEmpty()
                where string.Compare(j.NomeBolao, bolao.Nome, true) == 0
                orderby j.Posicao
                select new Domain.Entities.ValueObjects.ApostaExtraUsuarioVO()
                {
                    NomeBolao = j.NomeBolao,
                    Posicao = j.Posicao,
                    Titulo = j.Titulo,
                    TotalPontos = j.TotalPontos,
                    IsValido = j.IsValido,
                    DataValidacao = j.DataValidacao,
                    ValidadoBy = j.ValidadoBy,
                    NomeTimeValidado = j.NomeTimeValidado,

                    UserName = p.UserName,
                    DataAposta = p.DataAposta,
                    NomeTime = p.NomeTime,
                    IsApostaValida = p.IsApostaValida,
                    Automatico = p.Automatico,
                };


            return q.ToList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO>();
        }

        #endregion


    }
}
