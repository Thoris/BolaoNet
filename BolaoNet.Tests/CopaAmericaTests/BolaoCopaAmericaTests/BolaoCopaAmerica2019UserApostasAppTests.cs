using BolaoNet.Domain.Entities.Base.Common.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.CopaAmericaTests.BolaoCopaAmericaTests
{
    public class BolaoCopaAmerica2019UserApostasAppTests
    {
        #region Variables

        private Application.Interfaces.Users.IUserApp _userApp;
        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;
        private Application.Interfaces.Boloes.IBolaoApp _bolaoApp;
        private Application.Interfaces.Boloes.IBolaoMembroApp _bolaoMembroApp;
        private Application.Interfaces.Campeonatos.ICampeonatoApp _campeonatoApp;
        private Application.Interfaces.Facade.IUserFacadeApp _userFacadeApp;
        private Application.Interfaces.Boloes.IApostaExtraApp _apostaExtraApp;        
        private Application.Interfaces.Facade.Campeonatos.ICopaAmerica2019FacadeApp _copaAmerica2019FacadeApp;        

        #endregion

        #region Constructors/Destructors

        public BolaoCopaAmerica2019UserApostasAppTests(
            Application.Interfaces.Users.IUserApp userApp,
            Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp,
            Application.Interfaces.Campeonatos.IJogoApp jogoApp,
            Application.Interfaces.Boloes.IBolaoApp bolaoApp,
            Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp,
            Application.Interfaces.Campeonatos.ICampeonatoApp campeonatoApp,
            Application.Interfaces.Facade.IUserFacadeApp userFacadeApp,
            Application.Interfaces.Boloes.IApostaExtraApp apostaExtraApp,
            Application.Interfaces.Facade.Campeonatos.ICopaAmerica2019FacadeApp copaAmerica2019FacadeApp
            )
        {
            _userApp = userApp;
            _jogoUsuarioApp = jogoUsuarioApp;
            _jogoApp = jogoApp;
            _bolaoApp = bolaoApp;
            _bolaoMembroApp = bolaoMembroApp;
            _campeonatoApp = campeonatoApp;
            _userFacadeApp = userFacadeApp;
            _apostaExtraApp = apostaExtraApp;
            _copaAmerica2019FacadeApp = copaAmerica2019FacadeApp;
        }

        #endregion

        #region Methods
        
        public bool ApplyApostas(Domain.Entities.Users.User user, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.Campeonato campeonato, IList<int> jogoLabel, IList<int> time1, IList<int> time2, IList<int ?> penaltis1, IList<int ?> penaltis2)
        {
            if (user == null)
                throw new ArgumentException("user");
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (jogoLabel == null)
                throw new ArgumentException("jogoLabel");
            if (time1 == null)
                throw new ArgumentException("time1");
            if (time2 == null)
                throw new ArgumentException("time2");
            if (penaltis1 == null)
                throw new ArgumentException("penaltis1");
            if (penaltis2 == null)
                throw new ArgumentException("penaltis2");
            if (jogoLabel.Count != time1.Count || jogoLabel.Count != time2.Count || jogoLabel.Count != penaltis1.Count || jogoLabel.Count != penaltis2.Count)
                throw new ArgumentException("jogoLabel.Count != time1.Count != time2.Count != penaltis1.Count != penaltis2.Count");


            for (int c = 0; c < jogoLabel.Count; c++)
            {
                Domain.Entities.Campeonatos.Jogo jogo = new Domain.Entities.Campeonatos.Jogo(campeonato.Nome, jogoLabel[c]);

                _jogoUsuarioApp.ProcessAposta(bolao, user, jogo, 1, time1[c], time2[c], penaltis1[c], penaltis2[c], null);

            }//end for c

            


            return true;
        }
        public bool StoreData<T>(Domain.Interfaces.Services.Base.IGenericService<T> bo, T data)
        {
            T loaded = bo.Load(data);

            if (loaded == null)
            {
                long total = bo.Insert(data);

                if (total > 0)
                    return true;
                else
                    return false;
            }

            return false;
        }
        public bool CreateUserApostas(Domain.Entities.Users.User user, Domain.Entities.Boloes.Bolao bolao, IList<Domain.Entities.Boloes.JogoUsuario> jogos)
        {
            string activationCode = "";

            Domain.Entities.Boloes.Bolao bolaoLoaded = _bolaoApp.Load(bolao);


            Domain.Entities.Users.Role[] roles = {
                                              new Domain.Entities.Users.Role("Apostador"),
                                              new Domain.Entities.Users.Role("Convidado"),
                                              new Domain.Entities.Users.Role("Visitante de Bolão"),
                                              new Domain.Entities.Users.Role("Visitante de Campeonato"),
                                           };
            //"Administrador"
            //"Apostador"
            //"Convidado"
            //"Gerenciador de Avisos"
            //"Gerenciador de Bolão"
            //"Gerenciador de Campeonatos"
            //"Gerenciador de Critérios"
            //"Gerenciador de Dados Básicos"
            //"Gerenciador de Enquetes"
            //"Gerenciador de Mensagens"
            //"Gerenciador de Pagamentos"
            //"Gerenciador de Pontuação"
            //"Gerenciador de Publicidade"
            //"Gerenciador de Resultados"
            //"Visitante de Bolão"
            //"Visitante de Campeonato"


            if (_userApp.Load(user) == null)
            {
                _userFacadeApp.CreateUser(user, roles);
                _userFacadeApp.SendActivationCode(user);

                Domain.Entities.Users.User loadedUser = _userApp.Load(user);
                activationCode = loadedUser.ActivateKey;

                _userFacadeApp.ActivateUser(user, activationCode);
            }

            Domain.Entities.Boloes.BolaoMembro membro = new Domain.Entities.Boloes.BolaoMembro(user.UserName, bolao.Nome) { FullName = user.FullName };

            if (_bolaoMembroApp.Load(membro) == null)
            {
                _bolaoMembroApp.Insert(membro);
            }

            for (int c = 0; c < jogos.Count; c++ )
            {
                Domain.Entities.Campeonatos.Jogo jogo = new Domain.Entities.Campeonatos.Jogo(bolaoLoaded.NomeCampeonato, jogos[c].JogoId);
                
                _jogoUsuarioApp.ProcessAposta(bolao, user, jogo, 1, (int)jogos[c].ApostaTime1, (int)jogos[c].ApostaTime2,
                    jogos[c].ApostaPenaltis1, jogos[c].ApostaPenaltis2, null);
            }

            return true;
        }
        public Domain.Entities.Boloes.JogoUsuario CreateJogoUsuario(Domain.Entities.Users.User user, Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Campeonatos.Campeonato campeonato, int jogoId, int time1, int time2, int ? penaltis1, int ? penaltis2)
        {
            return new Domain.Entities.Boloes.JogoUsuario(user.UserName, bolao.Nome, campeonato.Nome, jogoId)
            {
                ApostaTime1 = time1,
                ApostaTime2 = time2,
                ApostaPenaltis1 = penaltis1,
                ApostaPenaltis2 = penaltis2
            };
        }
        public Domain.Entities.Users.User CreateUserApostasFixo (Domain.Entities.Boloes.Bolao bolao, string userName, string email, int time1, int time2)
        {
            Domain.Entities.Users.User user = new Domain.Entities.Users.User(userName)
            {
                Email = email
            };

            Domain.Entities.Boloes.Bolao bolaoLoaded = _bolaoApp.Load(bolao);
            Domain.Entities.Campeonatos.Campeonato campeonato = _campeonatoApp.Load(new Domain.Entities.Campeonatos.Campeonato(bolaoLoaded.NomeCampeonato));

            IList<Domain.Entities.Boloes.JogoUsuario> jogos = new List<Domain.Entities.Boloes.JogoUsuario>();

            for (int c = 0; c < 26; c++ )
            {
                jogos.Add(CreateJogoUsuario(user, bolao, campeonato, c+1, time1, time2, null, null));
            }
            
            CreateUserApostas(user, bolao, jogos);

            return user;
        }
        public Domain.Entities.Users.User CreateUserApostasRandom(Domain.Entities.Boloes.Bolao bolao, string userName, string email, int maxTime1, int maxTime2)
        {
            Domain.Entities.Users.User user = new Domain.Entities.Users.User(userName)
            {
                Email = email
            };

            Domain.Entities.Boloes.Bolao bolaoLoaded = _bolaoApp.Load(bolao);
            Domain.Entities.Campeonatos.Campeonato campeonato = _campeonatoApp.Load(new Domain.Entities.Campeonatos.Campeonato(bolaoLoaded.NomeCampeonato));

            IList<Domain.Entities.Boloes.JogoUsuario> jogos = new List<Domain.Entities.Boloes.JogoUsuario>();

            Random rnd = new Random();

            for (int c = 0; c < 26; c++)
            {
                int valueTime1 = rnd.Next(0, maxTime1);
                int valueTime2 = rnd.Next(0, maxTime2);
                jogos.Add(CreateJogoUsuario(user, bolao, campeonato, c + 1, valueTime1, valueTime2, null, null));
            }

            CreateUserApostas(user, bolao, jogos);

            return user;
        }
        
        #endregion

        #region Tests

        public void TestCreateBolaoCopaAmerica2019()
        {
            Domain.Entities.Campeonatos.Campeonato campeonato =
                _copaAmerica2019FacadeApp.CreateCampeonato("Copa América 2019", false);
        }
        public void TestInsertResultsCopaAmerica2019()
        {
            _copaAmerica2019FacadeApp.InsertResults("Copa América 2019", new Domain.Entities.Users.User("thoris"));
        }
        public void TestUserManagement()
        {
            Domain.Entities.Users.User user = new Domain.Entities.Users.User("testeUser");
            user.Email = "thorisangelo@hotmail.com";
            user.FullName = "Thoris Angelo Pivetta";
            user.Password = "senha01";

            ValidationResult resultRegistrationUser = _userApp.RegisterUser(user);

            if (!resultRegistrationUser.IsValid)
                return;


            string activationCode = _userApp.GenerateActivationCode(user);

            ValidationResult resultActivationCode = _userApp.ApproveUser(user, activationCode);

            if (!resultActivationCode.IsValid)
                return;

            ValidationResult resultLogin1 = _userApp.Login(user.UserName, user.Password);

            if (!resultLogin1.IsValid)
                return;

            string newPassword = "senha002";
            ValidationResult resultChangePassword = _userApp.ChangePassword(user.UserName, user.Password, newPassword, newPassword);

            if (!resultChangePassword.IsValid)
                return;

            ValidationResult resultLogin2 = _userApp.Login(user.UserName, newPassword);

            if (!resultLogin2.IsValid)
                return;
        }
        public void TestValidacaoPontosUsuarioCampeonato()
        {
            Domain.Entities.Boloes.Bolao bolao = new Domain.Entities.Boloes.Bolao("Copa América 2019");

            CreateUserApostasFixo(bolao, "Usuario0x0", "usuario0x0@hotmail.com", 0, 0);
            CreateUserApostasFixo(bolao, "Usuario1x0", "usuario1x0@hotmail.com", 1, 0);
            CreateUserApostasFixo(bolao, "Usuario0x1", "usuario0x1@hotmail.com", 0, 1);
            CreateUserApostasFixo(bolao, "Usuario1x1", "usuario1x1@hotmail.com", 1, 1);
            CreateUserApostasFixo(bolao, "Usuario2x0", "usuario2x0@hotmail.com", 2, 0);
            CreateUserApostasFixo(bolao, "Usuario2x1", "usuario2x1@hotmail.com", 2, 1);
            CreateUserApostasFixo(bolao, "Usuario0x2", "usuario0x2@hotmail.com", 0, 2);
            CreateUserApostasFixo(bolao, "Usuario1x2", "usuario1x2@hotmail.com", 1, 2);
            CreateUserApostasFixo(bolao, "Usuario2x2", "usuario2x2@hotmail.com", 2, 2);

            CreateUserApostasRandom(bolao, "UsuarioR001", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR002", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR003", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR004", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR005", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR006", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR007", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR008", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR009", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR010", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR011", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR012", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR013", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR014", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR015", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR016", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR017", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR018", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR019", "random1@hotmail.com", 0, 5);
            CreateUserApostasRandom(bolao, "UsuarioR020", "random1@hotmail.com", 0, 5);

            //Iniciando o bolão
            bool bolaoIniciado = _bolaoApp.Iniciar(new Domain.Entities.Users.User("thoris"), bolao);

            IList<Domain.Entities.Campeonatos.Jogo> jogos = _jogoApp.GetAll().OrderBy( x => x.JogoId).ToList();

            Random rnd = new Random();
            
            for (int c=0; c < jogos.Count; c++)
            {
                int gols1 = rnd.Next(0, 5);
                int gols2 = rnd.Next(0, 5);

                _jogoApp.InsertResult(jogos[c], gols1, null, gols2, null, true, new Domain.Entities.Users.User("thoris"));
            }
            

        }

        #endregion
    }
}
