using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF.Initializers
{
    public class SqlDataContextInitializer : CreateDatabaseIfNotExists<UnitOfWork>// DropCreateDatabaseAlways<UnitOfWork>
    {
        #region Constants

        public const string ScriptsFolder = "..\\..\\..\\BolaoNet.Database.SqlServer\\build";
        public const string StoredProcedureFile = "*Create_Store*.sql";
        
        #endregion

        #region Constructors/Destructors

        public SqlDataContextInitializer()
        {

        }

        #endregion

        #region Methods

        protected override void Seed(UnitOfWork context)
        {
            InsertDadosBasicos(context);


            string [] files = GetStoredProcedureFiles();

            for (int c = 0; c < files.Length; c++ )
            {
                string script = ReadFile(files[c]);

                if (string.IsNullOrEmpty(script))
                    continue;

                int total = context.Database.ExecuteSqlCommand(script);
            }

            context.Save();

            base.Seed(context);
        }


        public string [] GetStoredProcedureFiles()
        {
            string baseFolder = System.Configuration.ConfigurationManager.AppSettings["BaseFolderProcedures"];

            string[] files = System.IO.Directory.GetFiles(baseFolder, StoredProcedureFile);

            return files;
        }

        public string ReadFile(string file)
        {

            string res = "";

            StreamReader reader = new StreamReader(file);
            bool started = false;
            while (reader.Peek() >= 0)
            {
                string line = reader.ReadLine();

                if (!started)
                {
                    if (line.Trim().ToUpper().StartsWith("CREATE"))
                    {
                        started = true;
                        res += line + "\r\n";
                    }
                }
                else
                {
                    if (string.Compare(line.Trim(), "GO", true) == 0)
                        break;

                    res += line + "\r\n";
                }

            }

            reader.Close();

            return res;
        }

        public void InsertDadosBasicos(UnitOfWork context)
        {
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 1, Descricao = "Empate" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 2, Descricao = "Vitória" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 3, Descricao = "Derrota" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 4, Descricao = "Ganhador" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 5, Descricao = "Perdedor" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 6, Descricao = "Time 1" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 7, Descricao = "Time 2" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 8, Descricao = "Vitória/Empate/Derrota" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 9, Descricao = "Erro" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 10, Descricao = "Ganhador Fora" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 11, Descricao = "Ganhador Dentro" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 12, Descricao = "Perdedor Fora" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 13, Descricao = "Perdedor Dentro" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 14, Descricao = "Empate Gols" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 15, Descricao = "Gols Time 1" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 16, Descricao = "Gols Time 2" });
            context.CriteriosFixos.Add(new Domain.Entities.DadosBasicos.CriterioFixo() { CriterioId = 17, Descricao = "Cheio" });

            context.PagamentosTipo.Add(new Domain.Entities.DadosBasicos.PagamentoTipo() { TipoPagamento = 1, Descricao = "Dinheiro" });
            context.PagamentosTipo.Add(new Domain.Entities.DadosBasicos.PagamentoTipo() { TipoPagamento = 2, Descricao = "Cheque" });
            context.PagamentosTipo.Add(new Domain.Entities.DadosBasicos.PagamentoTipo() { TipoPagamento = 3, Descricao = "Depósito" });
            context.PagamentosTipo.Add(new Domain.Entities.DadosBasicos.PagamentoTipo() { TipoPagamento = 4, Descricao = "Outro" });

            context.Roles.Add(new Domain.Entities.Users.Role("Administrador"));
            context.Roles.Add(new Domain.Entities.Users.Role("Apostador"));
            context.Roles.Add(new Domain.Entities.Users.Role("Convidado"));
            context.Roles.Add(new Domain.Entities.Users.Role("Gerenciador de Avisos"));
            context.Roles.Add(new Domain.Entities.Users.Role("Gerenciador de Bolão"));
            context.Roles.Add(new Domain.Entities.Users.Role("Gerenciador de Campeonatos"));
            context.Roles.Add(new Domain.Entities.Users.Role("Gerenciador de Critérios"));
            context.Roles.Add(new Domain.Entities.Users.Role("Gerenciador de Dados Básicos"));
            context.Roles.Add(new Domain.Entities.Users.Role("Gerenciador de Enquetes"));
            context.Roles.Add(new Domain.Entities.Users.Role("Gerenciador de Mensagens"));
            context.Roles.Add(new Domain.Entities.Users.Role("Gerenciador de Pagamentos"));
            context.Roles.Add(new Domain.Entities.Users.Role("Gerenciador de Pontuação"));
            context.Roles.Add(new Domain.Entities.Users.Role("Gerenciador de Publicidade"));
            context.Roles.Add(new Domain.Entities.Users.Role("Gerenciador de Resultados"));
            context.Roles.Add(new Domain.Entities.Users.Role("Visitante de Bolão"));
            context.Roles.Add(new Domain.Entities.Users.Role("Visitante de Campeonato"));

            context.BoloesRequestsStatus.Add(new Domain.Entities.Boloes.BolaoRequestStatus(1) { Descricao = "Participar" });
            context.BoloesRequestsStatus.Add(new Domain.Entities.Boloes.BolaoRequestStatus(2) { Descricao = "Retirar" });
            context.BoloesRequestsStatus.Add(new Domain.Entities.Boloes.BolaoRequestStatus(3) { Descricao = "Aprovado" });
            context.BoloesRequestsStatus.Add(new Domain.Entities.Boloes.BolaoRequestStatus(4) { Descricao = "Rejeitado" });
            context.BoloesRequestsStatus.Add(new Domain.Entities.Boloes.BolaoRequestStatus(5) { Descricao = "Removido" });
            context.BoloesRequestsStatus.Add(new Domain.Entities.Boloes.BolaoRequestStatus(6) { Descricao = "Mantido" });
            context.BoloesRequestsStatus.Add(new Domain.Entities.Boloes.BolaoRequestStatus(7) { Descricao = "Convidado" });


            context.Usuarios.Add(new Domain.Entities.Users.User("admin")
            { 
                Password = "admin123", Email = "thorisangelo@hotmail.com", FullName = "Admin Full Name", IsApproved= true, IsLockedOut = false
            });

            context.UserInRole.Add(new Domain.Entities.Users.UserInRole("admin", "Administrador"));

            context.Save();

        }
        #endregion
    }
}
