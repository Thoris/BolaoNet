using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF.Boloes
{
    public class JogoUsuarioRepositoryDao :
        Base.BaseRepositoryDao<Entities.Boloes.JogoUsuario>, Dao.Boloes.IJogoUsuarioDao
    {
        
        #region Constructors/Destructors

        public JogoUsuarioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region IJogoUsuarioDao members

        //public bool AddAposta(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        //{
        //    Entities.Boloes.JogoUsuario jogoUsuario = new Entities.Boloes.JogoUsuario(user.UserName, bolao.Nome, jogo.NomeCampeonato, jogo.JogoId)
        //    {
        //        ApostaTime1 = apostaTime1, 
        //        ApostaTime2 = apostaTime2,
        //        ApostaPenaltis1 = penaltis1,
        //        ApostaPenaltis2 = penaltis2,
        //        CreatedBy = currentUserName, 
        //        CreatedDate = DateTime.Now,
        //        ModifiedBy = currentUserName, 
        //        ModifiedDate = DateTime.Now,
        //        Automatico = automatico,
        //        DataAposta = DateTime.Now,                 
        //    };

        //    long res = base.Insert(jogoUsuario);

        //    if (res > 0)
        //        return true;
        //    else
        //        return false;
        //}

        //public bool UpdateAposta(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        //{
        //    throw new NotImplementedException();
        //}


        public bool AddAposta(string currentUserName, Entities.Boloes.JogoUsuario jogoUsuario)
        {
            long res = base.Insert(jogoUsuario);

            if (res > 0)
                return true;
            else
                return false;
        }

        public bool UpdateAposta(string currentUserName, Entities.Boloes.JogoUsuario jogoUsuario)
        {
            throw new NotImplementedException();
        }

        public bool CalculeTime(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.DadosBasicos.Time time, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo)
        {

    //        //dados = base.DataContext.Database.SqlQuery<DataGrandezaResultado>("dbo.sp_REL_ValorMedioQuinzeMinutosCanal @pontoId, @canalId, @dataInicialDados, @dataFinalDados, @Periodicidade",
    //        dados = base.DataContext.Database.SqlQuery("sp_JogosUsuarios_Calcule_Time @pontoId, @canalId, @dataInicialDados, @dataFinalDados, @Periodicidade",
    //                                                                  new SqlParameter("pontoId", pontoId),
    //                                                                  new SqlParameter("canalId", canal),
    //                                                                  new SqlParameter("dataInicialDados", periodoBase),
    //                                                                  new SqlParameter("dataFinalDados", periodoFinal),
    //                                                                  new SqlParameter("Periodicidade", per)
    //                                                              ).ToList();


    //@CurrentLogin						varchar(25),
    //@NomeCampeonato						varchar(50),
    //@IDJogo								bigint,
    //@NomeBolao							varchar(30),	
    //@UserName							varchar(25),			
    //@NomeTime							varchar(30),
    //@NomeFase							varchar(30),
    //@NomeGrupo							varchar(30),
    //@ErrorNumber						int OUTPUT,
    //@ErrorDescription					varchar(4000) OUTPUT

            throw new NotImplementedException();
        }

        public bool CalculeDependencia(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo)
        {
            throw new NotImplementedException();
        }

        public bool CalculeFinal(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo)
        {
            throw new NotImplementedException();
        }

        public bool CalculeGrupo(string currentUserName, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Campeonato campeonato, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo)
        {
            throw new NotImplementedException();
        }

        #endregion

    }
}
