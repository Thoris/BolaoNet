using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Boloes
{
    public class JogoUsuarioRepositoryDao :
        Base.BaseRepositoryDao<Domain.Entities.Boloes.JogoUsuario>,
        Domain.Interfaces.Repositories.Boloes.IJogoUsuarioDao
    {
        
        #region Constructors/Destructors

        public JogoUsuarioRepositoryDao(Base.IUnitOfWork unitOfWork)
            : base(unitOfWork)
        {

        }

        #endregion

        #region Methods

        public Domain.Entities.ValueObjects.JogoUsuarioVO Convert(Domain.Entities.Campeonatos.Jogo j, Domain.Entities.Boloes.JogoUsuario u)
        {
            return new Domain.Entities.ValueObjects.JogoUsuarioVO()
                {
                    NomeCampeonato = j.NomeCampeonato,
                    JogoId = j.JogoId,
                    NomeTime1 = j.NomeTime1,
                    GolsTime1 = j.GolsTime1,
                    PenaltisTime1 = j.PenaltisTime1,
                    NomeTime2 = j.NomeTime2,
                    GolsTime2 = j.GolsTime2,
                    PenaltisTime2 = j.PenaltisTime2,
                    NomeEstadio = j.NomeEstadio,
                    DataJogo = j.DataJogo,
                    Rodada = j.Rodada,
                    PartidaValida = j.PartidaValida,
                    DataValidacao = j.DataValidacao,
                    NomeFase = j.NomeFase,
                    NomeGrupo = j.NomeGrupo,
                    IsValido = j.IsValido,
                    ValidadoBy = j.ValidadoBy,

                    UserName = u.UserName,

                    DataAposta = u.DataAposta,

                    Automatico = u.Automatico,

                    ApostaTime1 = u.ApostaTime1,
                    ApostaTime2 = u.ApostaTime2,
                    ApostaPenaltis1 = u.ApostaPenaltis1,
                    ApostaPenaltis2 = u.ApostaPenaltis2,

                    Valido = u.Valido,

                    NomeTimeResult1 = u.NomeTimeResult1,
                    NomeTimeResult2 = u.NomeTimeResult2,

                    Pontos = u.Pontos,

                    IsEmpate = u.IsEmpate,
                    IsDerrota = u.IsDerrota,
                    IsVitoria = u.IsVitoria,
                    IsGolsGanhador = u.IsGolsGanhador,
                    IsGolsPerdedor = u.IsGolsPerdedor,
                    IsResultTime1 = u.IsResultTime1,
                    IsResultTime2 = u.IsResultTime2,
                    IsVDE = u.IsVDE,
                    IsErro = u.IsErro,
                    IsGolsGanhadorFora = u.IsGolsGanhadorFora,
                    IsGolsGanhadorDentro = u.IsGolsGanhadorDentro,
                    IsGolsPerdedorFora = u.IsGolsPerdedorFora,
                    IsGolsPerdedorDentro = u.IsGolsPerdedorDentro,
                    IsGolsEmpate = u.IsGolsEmpate,
                    IsGolsTime1 = u.IsGolsTime1,
                    IsGolsTime2 = u.IsGolsTime2,
                    IsPlacarCheio = u.IsPlacarCheio,
                    IsMultiploTime = u.IsMultiploTime,
                    MultiploTime = u.MultiploTime,

                    Ganhador = u.Ganhador,
                };
        }

        #endregion

        #region IJogoUsuarioDao members

        //public bool AddAposta(string currentUserName, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        //{
        //    Domain.Entities.Boloes.JogoUsuario jogoUsuario = new Domain.Entities.Boloes.JogoUsuario(user.UserName, bolao.Nome, jogo.NomeCampeonato, jogo.JogoId)
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

        //public bool UpdateAposta(string currentUserName, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        //{
        //    throw new NotImplementedException();
        //}


        public bool AddAposta(string currentUserName, Domain.Entities.Boloes.JogoUsuario jogoUsuario)
        {
            long res = base.Insert(jogoUsuario);

            if (res > 0)
                return true;
            else
                return false;
        }
        public bool UpdateAposta(string currentUserName, Domain.Entities.Boloes.JogoUsuario jogoUsuario)
        {
            int res = base.Update(jogoUsuario);
            if (res > 0)
                return true;
            else
                return false;
        }
        public bool CalculeTime(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.DadosBasicos.Time time, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo)
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
        public bool CalculeDependencia(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.Campeonatos.Jogo jogo, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2)
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
        public bool CalculeFinal(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.Campeonatos.Jogo jogo, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2)
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
        public bool CalculeGrupo(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo)
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
        public bool ProcessAposta(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
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
                    ganhador = 2;
                    //if (penaltis1 != null && penaltis2 != null)
                    //{
                    //    if ((int)penaltis1 > (int)penaltis2)
                    //        ganhador = 0;
                    //    else if ((int)penaltis1 < (int)penaltis2)
                    //        ganhador = 1;
                    //}
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
                                                        new SqlParameter("Penaltis1", penaltis1 ?? SqlInt32.Null),
                                                        new SqlParameter("Penaltis2", penaltis2 ?? SqlInt32.Null),
                                                        new SqlParameter("Ganhador", ganhador ?? SqlInt32.Null),
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
        public Domain.Entities.Boloes.JogoUsuario CalculePontos(string currentUserName, DateTime currentDateTime, int gols1, int gols2, int aposta1, int aposta2, int pontosEmpate, int pontosVitoria, int pontosDerrota, int pontosGanhador, int pontosPerdedor, int pontosTime1, int pontosTime2, int pontosVDE, int pontosErro, int pontosGanhadorFora, int pontosGanhadorDentro, int pontosPerdedorFora, int pontosPerdedorDentro, int pontosEmpateGols, int pontosGolsTime1, int pontosGolsTime2, int pontosCheio, bool isMultiploTime, int multiploTime, Domain.Entities.Boloes.JogoUsuario pontosEntity)
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
        public bool Validacao(string currentUserName, DateTime currentDateTime, Domain.Entities.Campeonatos.Jogo jogo, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, int rodada, Domain.Entities.DadosBasicos.Time time1, Domain.Entities.DadosBasicos.Time time2, int gols1, int gols2, int? penaltis1, int? penaltis2, Domain.Entities.Users.User validadoBy)
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
        public IList<Domain.Entities.Boloes.JogoUsuario> GetJogosByUser(string currentUserName, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return base.GetList(x =>
                string.Compare(x.NomeBolao, bolao.Nome, true) == 0 &&
                string.Compare(x.UserName, user.UserName, true) == 0).ToList<Domain.Entities.Boloes.JogoUsuario>();
        }        
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> GetJogosUser(string currentUserName, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.ValueObjects.FilterJogosVO filter)
        {            
            DateTime dataInicioFilter = new DateTime(1900, 1, 1);
            DateTime dataFimFilter = DateTime.MaxValue;
            int rodadaFilter = 0;

            if (filter.DataInicial != null)
                dataInicioFilter = (DateTime)filter.DataInicial;

            if (filter.DataFinal != null)
                dataFimFilter = (DateTime)filter.DataFinal;

            if (filter.Rodada != null)
                rodadaFilter = (int)filter.Rodada;


            var q =
                from j in base.DataContext.Jogos

                join f in base.DataContext.CampeonatosFases
                  on new { c1 = j.NomeCampeonato, c2 = j.NomeFase }
                  equals new { c1 = f.NomeCampeonato, c2 = f.Nome }

                join u in base.DataContext.JogosUsuarios
                        on new { c1 = j.NomeCampeonato, c2 = j.JogoId, c3 = user.UserName, c4 = bolao.Nome }
                    equals new { c1 = u.NomeCampeonato, c2 = u.JogoId, c3 = u.UserName, c4 = u.NomeBolao }
                into ju
                from p in ju.DefaultIfEmpty()
                where string.Compare(j.NomeCampeonato, bolao.NomeCampeonato, true) == 0 &&
                (DateTime.Compare(j.DataJogo, dataInicioFilter) >= 0 || filter.DataInicial == null) &&
                (DateTime.Compare(j.DataJogo, dataFimFilter) <= 0 || filter.DataFinal == null) &&
                (j.Rodada == rodadaFilter || filter.Rodada == null) &&
                (string.Compare(j.NomeTime1, filter.NomeTime, true) == 0 || string.Compare(j.NomeTime2, filter.NomeTime, true) == 0 || filter.NomeTime == null) &&
                (string.Compare(j.NomeGrupo, filter.NomeGrupo, true) == 0 || filter.NomeGrupo == null) &&
                (string.Compare(j.NomeFase, filter.NomeFase, true) == 0 || filter.NomeFase == null)
                orderby f.Ordem, j.NomeGrupo, j.Rodada
                select new Domain.Entities.ValueObjects.JogoUsuarioVO()
                {
                    NomeCampeonato = j.NomeCampeonato,
                    JogoId = j.JogoId,
                    NomeTime1 = j.NomeTime1,
                    GolsTime1 = j.GolsTime1,
                    PenaltisTime1 = j.PenaltisTime1,
                    NomeTime2 = j.NomeTime2,
                    GolsTime2 = j.GolsTime2,
                    PenaltisTime2 = j.PenaltisTime2,
                    NomeEstadio = j.NomeEstadio,
                    DataJogo = j.DataJogo,
                    Rodada = j.Rodada,
                    PartidaValida = j.PartidaValida,
                    DataValidacao = j.DataValidacao,
                    NomeFase = j.NomeFase,
                    NomeGrupo = j.NomeGrupo,
                    IsValido = j.IsValido,
                    ValidadoBy = j.ValidadoBy,

                    UserName = p.UserName,

                    DataAposta = p.DataAposta,

                    Automatico = p.Automatico,

                    ApostaTime1 = p.ApostaTime1,
                    ApostaTime2 = p.ApostaTime2,
                    ApostaPenaltis1 = p.ApostaPenaltis1,
                    ApostaPenaltis2 = p.ApostaPenaltis2,

                    Valido = p.Valido,

                    NomeTimeResult1 = p.NomeTimeResult1,
                    NomeTimeResult2 = p.NomeTimeResult2,

                    Pontos = p.Pontos,

                    IsEmpate = p.IsEmpate,
                    IsDerrota = p.IsDerrota,
                    IsVitoria = p.IsVitoria,
                    IsGolsGanhador = p.IsGolsGanhador,
                    IsGolsPerdedor = p.IsGolsPerdedor,
                    IsResultTime1 = p.IsResultTime1,
                    IsResultTime2 = p.IsResultTime2,
                    IsVDE = p.IsVDE,
                    IsErro = p.IsErro,
                    IsGolsGanhadorFora = p.IsGolsGanhadorFora,
                    IsGolsGanhadorDentro = p.IsGolsGanhadorDentro,
                    IsGolsPerdedorFora = p.IsGolsPerdedorFora,
                    IsGolsPerdedorDentro = p.IsGolsPerdedorDentro,
                    IsGolsEmpate = p.IsGolsEmpate,
                    IsGolsTime1 = p.IsGolsTime1,
                    IsGolsTime2 = p.IsGolsTime2,
                    IsPlacarCheio = p.IsPlacarCheio,
                    IsMultiploTime = p.IsMultiploTime,
                    MultiploTime = p.MultiploTime,

                    Ganhador = p.Ganhador,


                };

            //#endregion

            //var q =
            //  from j in base.DataContext.Jogos

            //  join f in base.DataContext.CampeonatosFases
            //    on new { c1 = j.NomeCampeonato, c2 = j.NomeFase }
            //    equals new { c1 = f.NomeCampeonato, c2 = f.Nome }

            //  join u in base.DataContext.JogosUsuarios
            //          on new { c1 = j.NomeCampeonato, c2 = j.JogoId, c3 = user.UserName, c4 = bolao.Nome }
            //      equals new { c1 = u.NomeCampeonato, c2 = u.JogoId, c3 = u.UserName, c4 = u.NomeBolao }
            //  into ju
            //  from p in ju.DefaultIfEmpty()
            //  where string.Compare(j.NomeCampeonato, bolao.NomeCampeonato, true) == 0 &&
            //  (DateTime.Compare(j.DataJogo, dataInicioFilter) >= 0 || filter.DataInicial == null) &&
            //  (DateTime.Compare(j.DataJogo, dataFimFilter) <= 0 || filter.DataFinal == null) &&
            //  (j.Rodada == rodadaFilter || filter.Rodada == null) &&
            //  (string.Compare(j.NomeTime1, filter.NomeTime, true) == 0 || string.Compare(j.NomeTime2, filter.NomeTime, true) == 0 || filter.NomeTime == null) &&
            //  (string.Compare(j.NomeGrupo, filter.NomeGrupo, true) == 0 || filter.NomeGrupo == null) &&
            //  (string.Compare(j.NomeFase, filter.NomeFase, true) == 0 || filter.NomeFase == null)
            //  orderby f.Ordem, j.NomeGrupo, j.Rodada
            //  select Convert(j, p);

            return q.ToList<Domain.Entities.ValueObjects.JogoUsuarioVO>();
        }
        public void InsertApostasAutomaticas(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.ValueObjects.ApostasAutomaticasFilterVO filter)
        {

            string command = "exec sp_JogosUsuarios_CalculaPontos " +
                          "  @CurrentLogin " +
                          ", @CurrentDateTime" +
                          ", @NomeBolao" +
                          ", @TipoAutomatico" +
                          ", @TipoAposta" +
                          ", @Rodada" +
                          ", @DataInicial" +
                          ", @DataFinal" +
                          ", @NomeTime" +
                          ", @UserName" +
                          ", @GolsTime1" +
                          ", @GolsTime2" +
                          ", @RandomInicial" +
                          ", @RandomFinal" +
                          ", @Randomizado" +

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
                                                        new SqlParameter("NomeBolao", bolao.Nome),
                                                        new SqlParameter("TipoAutomatico", filter.TipoAutomatico),
                                                        new SqlParameter("TipoAposta", filter.TipoAposta),
                                                        new SqlParameter("Rodada", filter.Rodada ?? SqlInt32.Null),
                                                        new SqlParameter("DataInicial", filter.DataInicial ?? SqlDateTime.Null),
                                                        new SqlParameter("DataFinal", filter.DataFinal ?? SqlDateTime.Null),
                                                        new SqlParameter("NomeTime", filter.NomeTime),
                                                        new SqlParameter("UserName", user.UserName),
                                                        new SqlParameter("GolsTime1", filter.ApostaTimeCasa ?? SqlInt32.Null),
                                                        new SqlParameter("GolsTime2", filter.ApostaTimeFora ?? SqlInt32.Null),
                                                        new SqlParameter("RandomInicial", filter.ValorInicial ?? SqlInt32.Null),
                                                        new SqlParameter("RandomFinal", filter.ValorFinal ?? SqlInt32.Null),
                                                        new SqlParameter("Randomizado", !filter.ValoresFixos),
                                                        errorNumber,
                                                        errorDescription
                                                    );

            int error = 0;
            try
            {
                error = (int)errorNumber.Value;
            }
            catch
            {

            }
             
        }        
        public IList<Domain.Entities.Boloes.JogoUsuario> GetApostasJogo(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.Jogo jogo)
        {
            return GetList(x => string.Compare(x.NomeBolao, bolao.Nome, true) == 0 &&
                jogo.JogoId == x.JogoId).ToList();
        }
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadAcertosDificeis(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao, int totalMaximoAcertos)
        {
            //var q =
            //    from j in base.DataContext.Jogos

            //    join f in base.DataContext.CampeonatosFases
            //      on new { c1 = j.NomeCampeonato, c2 = j.NomeFase }
            //      equals new { c1 = f.NomeCampeonato, c2 = f.Nome }

            //    join u in base.DataContext.JogosUsuarios
            //            on new { c1 = j.NomeCampeonato, c2 = j.JogoId, c3 = bolao.Nome }
            //        equals new { c1 = u.NomeCampeonato, c2 = u.JogoId, c3 = u.NomeBolao }
            //    into ju
            //    from p in ju.DefaultIfEmpty()
            //    where string.Compare(j.NomeCampeonato, bolao.NomeCampeonato, true) == 0
            //    orderby f.Ordem, j.NomeGrupo, j.Rodada
            //    select new Domain.Entities.ValueObjects.JogoUsuarioVO()
            //    {
            //        NomeCampeonato = j.NomeCampeonato,
            //        JogoId = j.JogoId,
            //        NomeTime1 = j.NomeTime1,
            //        GolsTime1 = j.GolsTime1,
            //        PenaltisTime1 = j.PenaltisTime1,
            //        NomeTime2 = j.NomeTime2,
            //        GolsTime2 = j.GolsTime2,
            //        PenaltisTime2 = j.PenaltisTime2,
            //        NomeEstadio = j.NomeEstadio,
            //        DataJogo = j.DataJogo,
            //        Rodada = j.Rodada,
            //        PartidaValida = j.PartidaValida,
            //        DataValidacao = j.DataValidacao,
            //        NomeFase = j.NomeFase,
            //        NomeGrupo = j.NomeGrupo,
            //        IsValido = j.IsValido,
            //        ValidadoBy = j.ValidadoBy,

            //        UserName = p.UserName,

            //        DataAposta = p.DataAposta,

            //        Automatico = p.Automatico,

            //        ApostaTime1 = p.ApostaTime1,
            //        ApostaTime2 = p.ApostaTime2,
            //        ApostaPenaltis1 = p.ApostaPenaltis1,
            //        ApostaPenaltis2 = p.ApostaPenaltis2,

            //        Valido = p.Valido,

            //        NomeTimeResult1 = p.NomeTimeResult1,
            //        NomeTimeResult2 = p.NomeTimeResult2,

            //        Pontos = p.Pontos,

            //        IsEmpate = p.IsEmpate,
            //        IsDerrota = p.IsDerrota,
            //        IsVitoria = p.IsVitoria,
            //        IsGolsGanhador = p.IsGolsGanhador,
            //        IsGolsPerdedor = p.IsGolsPerdedor,
            //        IsResultTime1 = p.IsResultTime1,
            //        IsResultTime2 = p.IsResultTime2,
            //        IsVDE = p.IsVDE,
            //        IsErro = p.IsErro,
            //        IsGolsGanhadorFora = p.IsGolsGanhadorFora,
            //        IsGolsGanhadorDentro = p.IsGolsGanhadorDentro,
            //        IsGolsPerdedorFora = p.IsGolsPerdedorFora,
            //        IsGolsPerdedorDentro = p.IsGolsPerdedorDentro,
            //        IsGolsEmpate = p.IsGolsEmpate,
            //        IsGolsTime1 = p.IsGolsTime1,
            //        IsGolsTime2 = p.IsGolsTime2,
            //        IsPlacarCheio = p.IsPlacarCheio,
            //        IsMultiploTime = p.IsMultiploTime,
            //        MultiploTime = p.MultiploTime,

            //        Ganhador = p.Ganhador,


            //    };



            //return q.ToList<Domain.Entities.ValueObjects.JogoUsuarioVO>();



            string command = "exec sp_JogosUsuarios_Load_Acertos_Dificeis " +
                  "  @CurrentLogin " +
                  ", @CurrentDateTime" +
                  ", @NomeBolao" +
                  ", @TotalAcertos" +
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

            IList<Domain.Entities.ValueObjects.JogoUsuarioVO> res =
                base.DataContext.Database.SqlQuery<Domain.Entities.ValueObjects.JogoUsuarioVO>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("NomeBolao", bolao.Nome),
                                                        new SqlParameter("TotalAcertos", totalMaximoAcertos),
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
            return res;

        }
        public IList<Domain.Entities.Campeonatos.Jogo> LoadSemAcertos(string currentUserName, DateTime currentDateTime, Domain.Entities.Boloes.Bolao bolao)
        {
            //return base.DataContext.Jogos.ToList ();


            string command = "exec sp_JogosUsuarios_Load_Sem_Acertos " +
                 "  @CurrentLogin " +
                 ", @CurrentDateTime" +
                 ", @NomeBolao" +
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

            IList<Domain.Entities.Campeonatos.Jogo> res =
                base.DataContext.Database.SqlQuery<Domain.Entities.Campeonatos.Jogo>(command,
                                                        new SqlParameter("CurrentLogin", currentUserName),
                                                        new SqlParameter("CurrentDateTime", currentDateTime),
                                                        new SqlParameter("NomeBolao", bolao.Nome),
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
            return res;

        }
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadPontosObtidos(string currentUserName, DateTime currentDateTime, Domain.Entities.Users.User user, int totalRetorno)
        {
            //#region Comments
            //SELECT TOP 4 *
            //   FROM JogosUsuarios u
            //  INNER JOIN Jogos j
            //     ON u.NomeCampeonato	= j.NomeCampeonato
            //    AND u.IdJogo			= j.IdJogo
            //  WHERE u.UserName		= @UserName
            //    AND j.IsValido		= 1
            //  ORDER BY j.DataJogo DESC

            var q =
               (from j in base.DataContext.Jogos


                join u in base.DataContext.JogosUsuarios
                        on new { c1 = j.NomeCampeonato, c2 = j.JogoId }
                    equals new { c1 = u.NomeCampeonato, c2 = u.JogoId }

                where string.Compare(u.UserName, user.UserName, true) == 0 &&
                 j.IsValido == true
                orderby j.DataJogo descending
                select new Domain.Entities.ValueObjects.JogoUsuarioVO()
                {
                    NomeCampeonato = j.NomeCampeonato,
                    JogoId = j.JogoId,
                    NomeTime1 = j.NomeTime1,
                    GolsTime1 = j.GolsTime1,
                    PenaltisTime1 = j.PenaltisTime1,
                    NomeTime2 = j.NomeTime2,
                    GolsTime2 = j.GolsTime2,
                    PenaltisTime2 = j.PenaltisTime2,
                    NomeEstadio = j.NomeEstadio,
                    DataJogo = j.DataJogo,
                    Rodada = j.Rodada,
                    PartidaValida = j.PartidaValida,
                    DataValidacao = j.DataValidacao,
                    NomeFase = j.NomeFase,
                    NomeGrupo = j.NomeGrupo,
                    IsValido = j.IsValido,
                    ValidadoBy = j.ValidadoBy,

                    UserName = u.UserName,

                    DataAposta = u.DataAposta,

                    Automatico = u.Automatico,

                    ApostaTime1 = u.ApostaTime1,
                    ApostaTime2 = u.ApostaTime2,
                    ApostaPenaltis1 = u.ApostaPenaltis1,
                    ApostaPenaltis2 = u.ApostaPenaltis2,

                    Valido = u.Valido,

                    NomeTimeResult1 = u.NomeTimeResult1,
                    NomeTimeResult2 = u.NomeTimeResult2,

                    Pontos = u.Pontos,

                    IsEmpate = u.IsEmpate,
                    IsDerrota = u.IsDerrota,
                    IsVitoria = u.IsVitoria,
                    IsGolsGanhador = u.IsGolsGanhador,
                    IsGolsPerdedor = u.IsGolsPerdedor,
                    IsResultTime1 = u.IsResultTime1,
                    IsResultTime2 = u.IsResultTime2,
                    IsVDE = u.IsVDE,
                    IsErro = u.IsErro,
                    IsGolsGanhadorFora = u.IsGolsGanhadorFora,
                    IsGolsGanhadorDentro = u.IsGolsGanhadorDentro,
                    IsGolsPerdedorFora = u.IsGolsPerdedorFora,
                    IsGolsPerdedorDentro = u.IsGolsPerdedorDentro,
                    IsGolsEmpate = u.IsGolsEmpate,
                    IsGolsTime1 = u.IsGolsTime1,
                    IsGolsTime2 = u.IsGolsTime2,
                    IsPlacarCheio = u.IsPlacarCheio,
                    IsMultiploTime = u.IsMultiploTime,
                    MultiploTime = u.MultiploTime,

                    Ganhador = u.Ganhador,
                }).Take(totalRetorno);
           // #endregion


           // var q =
           //(from j in base.DataContext.Jogos


           // join u in base.DataContext.JogosUsuarios
           //         on new { c1 = j.NomeCampeonato, c2 = j.JogoId }
           //     equals new { c1 = u.NomeCampeonato, c2 = u.JogoId }

           // where string.Compare(u.UserName, user.UserName, true) == 0 &&
           //  j.IsValido == true
           // orderby j.DataJogo descending
           // select Convert(j, u)).Take(totalRetorno);

            return q.ToList();
        }
        public IList<Domain.Entities.ValueObjects.JogoUsuarioVO> LoadProximosJogosUsuario(string currentUserName, DateTime currentDateTime, Domain.Entities.Users.User user, int totalRetorno)
        {
            //#region Comments
            //SELECT TOP 3 *
    // FROM JogosUsuarios u
    //INNER JOIN Jogos j
    //   ON u.NomeCampeonato	= j.NomeCampeonato
    //  AND u.IdJogo			= j.IdJogo
    //WHERE u.UserName		= @UserName
    //  AND j.IsValido		= 0
    //ORDER BY j.DataJogo


            var q =
               (from j in base.DataContext.Jogos


                join u in base.DataContext.JogosUsuarios
                        on new { c1 = j.NomeCampeonato, c2 = j.JogoId }
                    equals new { c1 = u.NomeCampeonato, c2 = u.JogoId }

                where string.Compare(u.UserName, user.UserName, true) == 0 &&
                 j.IsValido == false
                orderby j.DataJogo descending
                select new Domain.Entities.ValueObjects.JogoUsuarioVO()
                {
                    NomeCampeonato = j.NomeCampeonato,
                    JogoId = j.JogoId,
                    NomeTime1 = j.NomeTime1,
                    GolsTime1 = j.GolsTime1,
                    PenaltisTime1 = j.PenaltisTime1,
                    NomeTime2 = j.NomeTime2,
                    GolsTime2 = j.GolsTime2,
                    PenaltisTime2 = j.PenaltisTime2,
                    NomeEstadio = j.NomeEstadio,
                    DataJogo = j.DataJogo,
                    Rodada = j.Rodada,
                    PartidaValida = j.PartidaValida,
                    DataValidacao = j.DataValidacao,
                    NomeFase = j.NomeFase,
                    NomeGrupo = j.NomeGrupo,
                    IsValido = j.IsValido,
                    ValidadoBy = j.ValidadoBy,

                    UserName = u.UserName,

                    DataAposta = u.DataAposta,

                    Automatico = u.Automatico,

                    ApostaTime1 = u.ApostaTime1,
                    ApostaTime2 = u.ApostaTime2,
                    ApostaPenaltis1 = u.ApostaPenaltis1,
                    ApostaPenaltis2 = u.ApostaPenaltis2,

                    Valido = u.Valido,

                    NomeTimeResult1 = u.NomeTimeResult1,
                    NomeTimeResult2 = u.NomeTimeResult2,

                    Pontos = u.Pontos,

                    IsEmpate = u.IsEmpate,
                    IsDerrota = u.IsDerrota,
                    IsVitoria = u.IsVitoria,
                    IsGolsGanhador = u.IsGolsGanhador,
                    IsGolsPerdedor = u.IsGolsPerdedor,
                    IsResultTime1 = u.IsResultTime1,
                    IsResultTime2 = u.IsResultTime2,
                    IsVDE = u.IsVDE,
                    IsErro = u.IsErro,
                    IsGolsGanhadorFora = u.IsGolsGanhadorFora,
                    IsGolsGanhadorDentro = u.IsGolsGanhadorDentro,
                    IsGolsPerdedorFora = u.IsGolsPerdedorFora,
                    IsGolsPerdedorDentro = u.IsGolsPerdedorDentro,
                    IsGolsEmpate = u.IsGolsEmpate,
                    IsGolsTime1 = u.IsGolsTime1,
                    IsGolsTime2 = u.IsGolsTime2,
                    IsPlacarCheio = u.IsPlacarCheio,
                    IsMultiploTime = u.IsMultiploTime,
                    MultiploTime = u.MultiploTime,

                    Ganhador = u.Ganhador,
                }).Take(totalRetorno);
            //#endregion


            //var q =
            //   (from j in base.DataContext.Jogos


            //    join u in base.DataContext.JogosUsuarios
            //            on new { c1 = j.NomeCampeonato, c2 = j.JogoId }
            //        equals new { c1 = u.NomeCampeonato, c2 = u.JogoId }

            //    where string.Compare(u.UserName, user.UserName, true) == 0 &&
            //     j.IsValido == false
            //    orderby j.DataJogo descending
            //    select Convert(j, u)).Take(totalRetorno);

            return q.ToList();
        }

        #endregion
    }
}
