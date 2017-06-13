using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Tests.CopaDoMundoTests.CopaDoMundo2014Tests
{
    public class BolaoCopaMundo2014UserApostasAppTests
    {
         #region Variables

        private Application.Interfaces.Users.IUserApp _userApp;
        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;
        private Application.Interfaces.Boloes.IBolaoApp _bolaoApp;
        private Application.Interfaces.Boloes.IBolaoMembroApp _bolaoMembroApp;
        private Application.Interfaces.Campeonatos.ICampeonatoApp _campeonatoApp;
        //private Application.Interfaces.Facade.IBolaoFacadeApp _bolaoFacadeApp;
        private Application.Interfaces.Facade.IUserFacadeApp _userFacadeApp;
        private Application.Interfaces.Boloes.IApostaExtraApp _apostaExtraApp;

        //private Application.Interfaces.IFactoryBO _factory;

        #endregion

        #region Constructors/Destructors

        //public BolaoCopaMundo2014UserApostasAppTests(BolaoNet.Business.Interfaces.IFactoryBO factory)
        //{
        //    _factory = factory;
        //    _userBO = factory.CreateUserBO();
        //    _jogoUsuarioBO = factory.CreateJogoUsuarioBO();
        //    _jogoBO = factory.CreateJogoBO();
        //    _bolaoBO = factory.CreateBolaoBO();
        //    _bolaoMembroBO = factory.CreateBolaoMembroBO();
        //    _campeonatoBO = factory.CreateCampeonatoBO();
        //    _bolaoFacadeBO = factory.CreateBolaoFacadeBO();
        //    _userFacadeBO = factory.CreateUserFacadeBO();
        //    _apostaExtraBO = factory.CreateApostaExtraBO();

        //}

        public BolaoCopaMundo2014UserApostasAppTests()
        {

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

                //_bolaoFacadeBO.InsertJogoUsuario(user, bolao, jogo, 1, (int)jogos[c].ApostaTime1, (int)jogos[c].ApostaTime2, 
                //    jogos[c].ApostaPenaltis1, jogos[c].ApostaPenaltis2);

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
        public Domain.Entities.Users.User CreateUserApostasThoris(Domain.Entities.Boloes.Bolao bolao)
        {

            Domain.Entities.Users.User user = new Domain.Entities.Users.User("Thoris")
            {
                Email = "thoris@thoris.com"
            };

            Domain.Entities.Boloes.Bolao bolaoLoaded = _bolaoApp.Load(bolao);
            Domain.Entities.Campeonatos.Campeonato campeonato = _campeonatoApp.Load (new Domain.Entities.Campeonatos.Campeonato(bolaoLoaded.NomeCampeonato));

            IList<Domain.Entities.Boloes.JogoUsuario> jogos = new List<Domain.Entities.Boloes.JogoUsuario>();

            //A
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 1, 2, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 2, 2, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 17, 2, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 18, 1, 2, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 33, 1, 3, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 34, 1, 1, null, null));
            //B
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 3, 1, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 4, 3, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 19, 0, 2, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 20, 3, 2, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 35, 0, 4, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 36, 1, 2, null, null));
            //C
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 5, 2, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 6, 1, 2, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 21, 2, 2, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 22, 1, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 37, 1, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 38, 0, 1, null, null));
            //D
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 7, 2, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 8, 2, 2, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 23, 2, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 24, 3, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 39, 2, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 40, 0, 3, null, null));
            //E
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 9, 2, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 10, 3, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 25, 1, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 26, 1, 2, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 41, 0, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 42, 0, 2, null, null));
            //F
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 11, 4, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 12, 0, 3, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 27, 3, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 28, 3, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 43, 1, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 44, 0, 1, null, null));
            //G
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 13, 2, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 14, 1, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 29, 3, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 30, 1, 2, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 45, 1, 3, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 46, 2, 0, null, null));
            //H
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 15, 2, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 16, 1, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 31, 2, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 32, 1, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 47, 0, 2, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 48, 0, 0, null, null));
            //Oitavas
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 49, 2, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 50, 1, 2, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 51, 2, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 52, 2, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 53, 1, 2, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 54, 3, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 55, 2, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 56, 1, 2, null, null));
            //Quartas
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 57, 2, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 58, 1, 2, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 59, 2, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 60, 1, 1, 0, 1));
            //Semi
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 61, 2, 1, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 62, 2, 1, null, null));
            //Final
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 63, 2, 0, null, null));
            jogos.Add(CreateJogoUsuario(user, bolao, campeonato, 64, 2, 0, null, null));


            CreateUserApostas(user, bolao, jogos);

            return user;
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

            for (int c = 0; c < 64; c++ )
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

            for (int c = 0; c < 64; c++)
            {
                int valueTime1 = rnd.Next(0, maxTime1);
                int valueTime2 = rnd.Next(0, maxTime2);
                jogos.Add(CreateJogoUsuario(user, bolao, campeonato, c + 1, valueTime1, valueTime2, null, null));
            }

            CreateUserApostas(user, bolao, jogos);

            return user;
        }

        //public void CreateAllData()
        //{

        //    BolaoNet.Business.Facade.Campeonatos.CopaMundo2014FacadeBO campeonatoBO =
        //        new BolaoNet.Business.Facade.Campeonatos.CopaMundo2014FacadeBO(_factory);

        //    Domain.Entities.Campeonatos.Campeonato campeonato = campeonatoBO.CreateCampeonato();

        //    TestsVS.Business.Facade.BolaoCopaMundo2014FacadeBO bolaoBO = new BolaoCopaMundo2014FacadeBO(_factory);

        //    Domain.Entities.Boloes.Bolao bolao = bolaoBO.CreateBolao(campeonato);

        //    CreateUserApostasThoris(bolao);
        //    //CreateUserApostasFixo(bolao, "Usuario1", "email1@email.com", 1, 0);
        //    //CreateUserApostasFixo(bolao, "Usuario2", "email2@email.com", 0, 1);
        //    //CreateUserApostasFixo(bolao, "Usuario3", "email3@email.com", 1, 1);
        //    //CreateUserApostasRandom(bolao, "Usuario4", "email4@email.com", 3, 3);
        //    //CreateUserApostasRandom(bolao, "Usuario5", "email5@email.com", 3, 3);
        //    //CreateUserApostasRandom(bolao, "Usuario6", "email6@email.com", 3, 3);
        //    //CreateUserApostasRandom(bolao, "Usuario7", "email7@email.com", 3, 3);
        //    //CreateUserApostasRandom(bolao, "Usuario8", "email8@email.com", 3, 3);
        //    //CreateUserApostasRandom(bolao, "Usuario9", "email9@email.com", 3, 3);
        //    CreateUserApostasRandom(bolao, "Usuario10", "email10@email.com", 3, 3);

        //    bolaoBO.StartBolao(new Domain.Entities.Users.User("Thoris"), bolao);

        //    campeonatoBO.InsertResults(campeonato);

        //    bolaoBO.InsertFinalResult();

        //}
        
        #endregion
    }
}
