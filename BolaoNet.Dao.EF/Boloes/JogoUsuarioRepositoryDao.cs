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
            int res = base.Update(jogoUsuario);
            if (res > 0)
                return true;
            else
                return false;
        }

        public bool CalculeTime(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.DadosBasicos.Time time, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo)
        {

            string command = "exec sp_JogosUsuarios_Calcule_Time " +
                "@CurrentLogin " +
                ", @CurrentDateTime" +
                ", @NomeCampeonato" +
                ", @NomeBolao" +
                ", @UserName" +
                ", @NomeTime" +
                ", @NomeFase" +
                ", @NomeGrupo" +
                ", @ErrorNumber out" +
                ", @ErrorDescription out";

            var errorNumber = new SqlParameter
            {
                ParameterName = "@ErrorNumber",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var errorDescription = new SqlParameter
            {
                ParameterName = "@ErrorDescription",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 255,
                Direction = System.Data.ParameterDirection.Output
            };

            IList<int> res = base.DataContext.Database.SqlQuery<int>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("NomeCampeonato", fase.NomeCampeonato),
                                                        new SqlParameter("NomeBolao", bolao.Nome),
                                                        new SqlParameter("UserName", user.UserName),
                                                        new SqlParameter("NomeTime", time.Nome),
                                                        new SqlParameter("NomeFase", fase.Nome),
                                                        new SqlParameter("NomeGrupo", grupo.Nome),
                                                        errorNumber,
                                                        errorDescription
                                                    ).ToList ();

            int error = 0;
            try
            {
                error = (int)errorNumber.Value;
            }
            catch
            {

            }

            if (res == null || res.Count == 0)
                return false;

            int terminouJogosGrupos = res[0];

            if (terminouJogosGrupos > 0)
                return true;
            else
                return false;
        }

        public bool CalculeDependencia(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2)
        {
            string command = "exec sp_JogosUsuarios_Calcule_Dependencia " +
                "@CurrentLogin " +
                ", @CurrentDateTime" +                
                ", @NomeCampeonato" +
                ", @IDJogo" +
                ", @NomeBolao" +
                ", @UserName" +
                ", @NomeFase" +
                ", @NomeGrupo" +
                ", @NomeTime1" +
                ", @NomeTime2" +
                ", @ApostaTime1" +
                ", @ApostaTime2" +
                ", @Ganhador" +                               
                ", @ErrorNumber out" +
                ", @ErrorDescription out";

            var errorNumber = new SqlParameter
            {
                ParameterName = "@ErrorNumber",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var errorDescription = new SqlParameter
            {
                ParameterName = "@ErrorDescription",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 255,
                Direction = System.Data.ParameterDirection.Output
            };

            int ganhador = 0;
            if (apostaTime1 == apostaTime2)
            {
                if (penaltis1 != null && penaltis2 != null)
                {
                    if ((int)penaltis1 > (int)penaltis2)
                        ganhador = 0;
                    else if ((int)penaltis1 < (int)penaltis2)
                        ganhador = 1;
                }
            }
            else if (apostaTime1 > apostaTime2)
            {
                ganhador = 0;
            }
            else if (apostaTime1 < apostaTime2)
            {
                ganhador = 1;
            }


            IList<object> res = base.DataContext.Database.SqlQuery<object>(command,
                                                            new SqlParameter("CurrentLogin", currentUserName),
                                                            new SqlParameter("CurrentDateTime", currentDateTime),                                                                      
                                                            new SqlParameter("NomeCampeonato", fase.NomeCampeonato),
                                                            new SqlParameter("IDJogo", jogo.JogoId),
                                                            new SqlParameter("NomeBolao", bolao.Nome),
                                                            new SqlParameter("UserName", user.UserName),
                                                            new SqlParameter("NomeFase", fase.Nome),
                                                            new SqlParameter("NomeGrupo", grupo.Nome),
                                                            new SqlParameter("NomeTime1", jogo.NomeTime1),
                                                            new SqlParameter("NomeTime2", jogo.NomeTime2),
                                                            new SqlParameter("ApostaTime1", apostaTime1),
                                                            new SqlParameter("ApostaTime2", apostaTime2),
                                                            new SqlParameter("Ganhador", ganhador),
                                                            errorNumber,
                                                            errorDescription
                                                        ).ToList();

            int error = 0;
            try
            {
                error = (int)errorNumber.Value;
            }
            catch
            {

            }

            if (error == 0)
                return true;
            else
                return false;
        }

        public bool CalculeFinal(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2)
        {
            string command = "exec sp_JogosUsuarios_Calcule_Final " +
               "@CurrentLogin " +
               ", @CurrentDateTime" +                
               ", @NomeCampeonato" +
               ", @IDJogo" +
               ", @NomeBolao" +
               ", @UserName" +
               ", @NomeFase" +
               ", @NomeGrupo" +
               ", @NomeTime1" +
               ", @NomeTime2" +
               ", @ApostaTime1" +
               ", @ApostaTime2" +
               ", @Ganhador" +
               ", @ErrorNumber out" +
               ", @ErrorDescription out";

            var errorNumber = new SqlParameter
            {
                ParameterName = "@ErrorNumber",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var errorDescription = new SqlParameter
            {
                ParameterName = "@ErrorDescription",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 255,
                Direction = System.Data.ParameterDirection.Output
            };

            int ganhador = 0;
            if (apostaTime1 == apostaTime2)
            {
                if (penaltis1 != null && penaltis2 != null)
                {
                    if ((int)penaltis1 > (int)penaltis2)
                        ganhador = 0;
                    else if ((int)penaltis1 < (int)penaltis2)
                        ganhador = 1;
                }
            }
            else if (apostaTime1 > apostaTime2)
            {
                ganhador = 0;
            }
            else if (apostaTime1 < apostaTime2)
            {
                ganhador = 1;
            }


            IList<object> res = base.DataContext.Database.SqlQuery<object>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),                                                                      
                                                        new SqlParameter("NomeCampeonato", fase.NomeCampeonato),
                                                        new SqlParameter("IDJogo", jogo.JogoId),
                                                        new SqlParameter("NomeBolao", bolao.Nome),
                                                        new SqlParameter("UserName", user.UserName),
                                                        new SqlParameter("NomeFase", fase.Nome),
                                                        new SqlParameter("NomeGrupo", grupo.Nome),
                                                        new SqlParameter("NomeTime1", jogo.NomeTime1),
                                                        new SqlParameter("NomeTime2", jogo.NomeTime2),
                                                        new SqlParameter("ApostaTime1", apostaTime1),
                                                        new SqlParameter("ApostaTime2", apostaTime2),
                                                        new SqlParameter("Ganhador", ganhador),
                                                        errorNumber,
                                                        errorDescription
                                                    ).ToList();

            int error = 0;
            try
            {
                error = (int)errorNumber.Value;
            }
            catch
            {

            }

            if (error == 0)
                return true;
            else
                return false;
        }

        public bool CalculeGrupo(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Campeonato campeonato, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo)
        {
            string command = "exec sp_JogosUsuarios_Calcule_Grupo " +
                            " @CurrentLogin " +
                            ", @CurrentDateTime" +
                            ", @NomeCampeonato" +
                            ", @NomeBolao" +
                            ", @UserName" +
                            ", @NomeFase" +
                            ", @NomeGrupo" +
                            ", @ErrorNumber out" +
                            ", @ErrorDescription out";

            var errorNumber = new SqlParameter
            {
                ParameterName = "@ErrorNumber",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var errorDescription = new SqlParameter
            {
                ParameterName = "@ErrorDescription",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 255,
                Direction = System.Data.ParameterDirection.Output
            };

            base.DataContext.Database.SqlQuery<object>(command,
                                                    new SqlParameter("CurrentLogin", currentUserName),
                                                    new SqlParameter("CurrentDateTime", currentDateTime),
                                                    new SqlParameter("NomeCampeonato", fase.NomeCampeonato),
                                                    new SqlParameter("NomeBolao", bolao.Nome),
                                                    new SqlParameter("UserName", user.UserName),
                                                    new SqlParameter("NomeFase", fase.Nome),
                                                    new SqlParameter("NomeGrupo", grupo.Nome),
                                                    errorNumber,
                                                    errorDescription
                                                ).ToList();

            int error = 0;
            try
            {
                error = (int)errorNumber.Value;
            }
            catch
            {

            }

            if (error == 0)
                return true;
            else
                return false;
        }

        public bool ProcessAposta(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user, Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        {
            string command = "exec sp_JogosUsuarios_ProcessAposta " +
              "@CurrentLogin " +
              ", @CurrentDateTime" +
              ", @NomeCampeonato" +
              ", @IDJogo" +
              ", @NomeBolao" +
              ", @UserName" +
              ", @Automatico" +
              ", @ApostaTime1" +
              ", @ApostaTime2" +
              ", @Penaltis1" +
              ", @Penaltis2" + 
              ", @Ganhador" +
              ", @ErrorNumber out" +
              ", @ErrorDescription out";

            var errorNumber = new SqlParameter
            {
                ParameterName = "@ErrorNumber",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var errorDescription = new SqlParameter
            {
                ParameterName = "@ErrorDescription",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 255,
                Direction = System.Data.ParameterDirection.Output
            };

            if (ganhador == null)
            {
                if (apostaTime1 == apostaTime2)
                {
                    if (penaltis1 != null && penaltis2 != null)
                    {
                        if ((int)penaltis1 > (int)penaltis2)
                            ganhador = 0;
                        else if ((int)penaltis1 < (int)penaltis2)
                            ganhador = 1;
                    }
                }
                else if (apostaTime1 > apostaTime2)
                {
                    ganhador = 0;
                }
                else if (apostaTime1 < apostaTime2)
                {
                    ganhador = 1;
                }
            }


            IList<object> res = base.DataContext.Database.SqlQuery<object>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("NomeCampeonato", jogo.NomeCampeonato),
                                                        new SqlParameter("IDJogo", jogo.JogoId),
                                                        new SqlParameter("NomeBolao", bolao.Nome),
                                                        new SqlParameter("UserName", user.UserName),
                                                        new SqlParameter("Automatico", automatico),
                                                        new SqlParameter("ApostaTime1", apostaTime1),
                                                        new SqlParameter("ApostaTime2", apostaTime2),
                                                        new SqlParameter("Penaltis1", penaltis1),
                                                        new SqlParameter("Penaltis2", penaltis2),
                                                        new SqlParameter("Ganhador", ganhador),
                                                        errorNumber,
                                                        errorDescription
                                                    ).ToList();

            int error = 0;
            try
            {
                error = (int)errorNumber.Value;
            }
            catch
            {

            }

            if (error == 0)
                return true;
            else
                return false;
        }

        public Entities.Interfaces.IPontosJogosUsuarioEntity CalculePontos(string currentUserName, DateTime currentDateTime, int gols1, int gols2, int aposta1, int aposta2, int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2, int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro, int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, bool isMultiploTime, int multiploTime, Entities.Interfaces.IPontosJogosUsuarioEntity pontosEntity)
        {
            string command = "exec sp_JogosUsuarios_CalculaPontos " +
                          "  @CurrentLogin " +
                          ", @CurrentDateTime" +
                          ", @Gols1" +
                          ", @Gols2" +
                          ", @Aposta1" +
                          ", @Aposta2" +
                          ", @PontosEmpate" +
                          ", @PontosVitoria" +
                          ", @PontosGanhador" +
                          ", @PontosPerdedor" +
                          ", @PontosTime1" +
                          ", @PontosTime2" +
                          ", @PontosVDE" +
                          ", @PontosErro" +
                          ", @PontosGanhadorFora" +
                          ", @PontosGanhadorDentro" +
                          ", @PontosPerdedorFora" +
                          ", @PontosPerdedorDentro" +
                          ", @PontosEmpateGols" +
                          ", @PontosGolsTime1" +
                          ", @PontosGolsTime2" +
                          ", @PontosCheio" +
                          ", @IsMultiploTime" +
                          ", @MultiploTime" +

                          ", @PontosTime1Total OUT" +
                          ", @PontosTime2Total OUT" +
                          ", @PontosTotal OUT" +
                          ", @CountEmpate OUT" +
                          ", @CountVitoria OUT" +
                          ", @CountGanhador OUT" +
                          ", @CountPerdedor OUT" +
                          ", @CountTime1 OUT" +
                          ", @CountTime2 OUT" +
                          ", @CountVDE OUT" +
                          ", @CountErro OUT" +
                          ", @CountGanhadorFora OUT" +
                          ", @CountGanhadorDentro OUT" +
                          ", @CountPerdedorFora OUT" +
                          ", @CountPerdedorDentro OUT" +
                          ", @CountEmpateGols OUT" +
                          ", @CountGolsTime1 OUT" +
                          ", @CountGolsTime2 OUT" +
                          ", @CountCheio OUT" +
                          
                          ", @ErrorNumber out" +
                          ", @ErrorDescription out";

            #region Preparação de parâmetros de retorno

            var pontosTime1Total = new SqlParameter
            {
                ParameterName = "@PontosTime1Total",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var pontosTime2Total = new SqlParameter
            {
                ParameterName = "@PontosTime2Total",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var pontosTotal = new SqlParameter
            {
                ParameterName = "@PontosTotal",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countEmpate = new SqlParameter
            {
                ParameterName = "@CountEmpate",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countVitoria = new SqlParameter
            {
                ParameterName = "@CountVitoria",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countGanhador = new SqlParameter
            {
                ParameterName = "@CountGanhador",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countPerdedor = new SqlParameter
            {
                ParameterName = "@CountPerdedor",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countTime1 = new SqlParameter
            {
                ParameterName = "@countTime1",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countTime2 = new SqlParameter
            {
                ParameterName = "@CountTime2",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countVDE = new SqlParameter
            {
                ParameterName = "@CountVDE",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countErro = new SqlParameter
            {
                ParameterName = "@CountErro",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countGanhadorFora = new SqlParameter
            {
                ParameterName = "@countGanhadorFora",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countGanhadorDentro = new SqlParameter
            {
                ParameterName = "@CountGanhadorDentro",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countPerdedorFora = new SqlParameter
            {
                ParameterName = "@CountPerdedorFora",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countPerdedorDentro = new SqlParameter
            {
                ParameterName = "@CountPerdedorDentro",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countEmpateGols = new SqlParameter
            {
                ParameterName = "@CountEmpateGols",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countGolsTime1 = new SqlParameter
            {
                ParameterName = "@CountGolsTime1",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countGolsTime2 = new SqlParameter
            {
                ParameterName = "@CountGolsTime2",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };
            var countCheio = new SqlParameter
            {
                ParameterName = "@CountCheio",
                SqlDbType = System.Data.SqlDbType.Bit,
                Size = 1,
                Direction = System.Data.ParameterDirection.Output
            };

            var errorNumber = new SqlParameter
            {
                ParameterName = "@ErrorNumber",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var errorDescription = new SqlParameter
            {
                ParameterName = "@ErrorDescription",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 255,
                Direction = System.Data.ParameterDirection.Output
            };
            #endregion


            IList<object> res = base.DataContext.Database.SqlQuery<object>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("Gols1", gols1),
                                                        new SqlParameter("Gols2", gols2),
                                                        new SqlParameter("Aposta1", aposta1),
                                                        new SqlParameter("Aposta2", aposta2),
                                                        new SqlParameter("PontosEmpate", pontosEmpate),
                                                        new SqlParameter("PontosVitoria", pontosVitoria),
                                                        new SqlParameter("PontosGanhador", pontosGanhador),
                                                        new SqlParameter("PontosPerdedor", pontosPerdedor),
                                                        new SqlParameter("PontosTime1", pontosTime1),
                                                        new SqlParameter("PontosTime2", pontosTime2),
                                                        new SqlParameter("PontosVDE", pontosVDE),
                                                        new SqlParameter("PontosErro", pontosErro),
                                                        new SqlParameter("PontosGanhadorFora", pontosGanhadorFora),
                                                        new SqlParameter("PontosGanhadorDentro", pontosGanhadorDentro),
                                                        new SqlParameter("PontosPerdedorFora", pontosPerdedorFora),
                                                        new SqlParameter("PontosPerdedorDentro", pontosPerdedorDentro),
                                                        new SqlParameter("PontosEmpateGols", pontosEmpateGols),
                                                        new SqlParameter("PontosGolsTime1", pontosGolsTime1),
                                                        new SqlParameter("PontosGolsTime2", pontosGolsTime2),
                                                        new SqlParameter("PontosCheio", pontosCheio),
                                                        new SqlParameter("IsMultiploTime", isMultiploTime),
                                                        new SqlParameter("MultiploTime", multiploTime),
                                                        pontosTime1Total,
                                                        pontosTime2Total ,
                                                        pontosTotal ,
                                                        countEmpate ,
                                                        countVitoria,
                                                        countGanhador,
                                                        countPerdedor,
                                                        countTime1,
                                                        countTime2,
                                                        countVDE,
                                                        countErro,
                                                        countGanhadorFora,
                                                        countGanhadorDentro,
                                                        countPerdedorFora,
                                                        countPerdedorDentro,
                                                        countEmpateGols,
                                                        countGolsTime1,
                                                        countGolsTime2,
                                                        countCheio,
                                                        errorNumber,
                                                        errorDescription
                                                    ).ToList();

            int error = 0;
            try
            {
                error = (int)errorNumber.Value;
            }
            catch
            {

            }


            return pontosEntity;

        }

        public bool Validacao(string currentUserName, DateTime currentDateTime, Entities.Campeonatos.Jogo jogo, Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo, int rodada, Entities.DadosBasicos.Time time1, Entities.DadosBasicos.Time time2, int gols1, int gols2, int? penaltis1, int? penaltis2, Entities.Users.User validadoBy)
        {
            string command = "exec sp_JogosUsuariosValidacao " +
                           "  @CurrentLogin " +
                           ", @CurrentDateTime" +
                           ", @IdJogo" +
                           ", @NomeCampeonato" +
                           ", @NomeGrupo" +
                           ", @NomeFase" +
                           ", @Rodada" +
                           ", @NomeTime1" +
                           ", @Gols1" +
                           ", @Penaltis1" +
                           ", @NomeTime2" +
                           ", @Gols2" +
                           ", @Penaltis2" +
                           ", @ValidadoBy" +
                           ", @ErrorNumber out" +
                           ", @ErrorDescription out";

            var errorNumber = new SqlParameter
            {
                ParameterName = "@ErrorNumber",
                SqlDbType = System.Data.SqlDbType.Int,
                Size = 3,
                Direction = System.Data.ParameterDirection.Output
            };
            var errorDescription = new SqlParameter
            {
                ParameterName = "@ErrorDescription",
                SqlDbType = System.Data.SqlDbType.VarChar,
                Size = 255,
                Direction = System.Data.ParameterDirection.Output
            };

            base.DataContext.Database.SqlQuery<object>(command,
                                                    new SqlParameter("CurrentLogin", currentUserName),
                                                    new SqlParameter("CurrentDateTime", currentDateTime),
                                                    new SqlParameter("IDJogo", jogo.JogoId),                                                    
                                                    new SqlParameter("NomeCampeonato", fase.NomeCampeonato),
                                                    new SqlParameter("NomeGrupo", grupo.Nome),
                                                    new SqlParameter("NomeFase", fase.Nome),
                                                    new SqlParameter("Rodada", rodada),
                                                    new SqlParameter("NomeTime1", time1.Nome),
                                                    new SqlParameter("Gols1", gols1),
                                                    new SqlParameter("Penaltis1", penaltis1),
                                                    new SqlParameter("NomeTime2", time2.Nome),
                                                    new SqlParameter("Gols2", gols2),
                                                    new SqlParameter("Penaltis2", penaltis2),
                                                    new SqlParameter("ValidadoBy", validadoBy.UserName),                                                    
                                                    errorNumber,
                                                    errorDescription
                                                ).ToList();

            int error = 0;
            try
            {
                error = (int)errorNumber.Value;
            }
            catch
            {

            }

            if (error == 0)
                return true;
            else
                return false;
        }
 

        #endregion
    }
}
