using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.TestsVS.Business.Facade
{
    public class BolaoCopaMundo2014UserFacadeBO
    {
        #region Variables

        private BolaoNet.Business.Interfaces.Users.IUserBO _userBO;
        private BolaoNet.Business.Interfaces.Boloes.IJogoUsuarioBO _jogoUsuarioBO;
        private BolaoNet.Business.Interfaces.Campeonatos.IJogoBO _jogoBO;
        private BolaoNet.Business.Interfaces.Boloes.IBolaoBO _bolaoBO;
        private BolaoNet.Business.Interfaces.Boloes.IBolaoMembroBO _bolaoMembroBO;
        private BolaoNet.Business.Interfaces.Campeonatos.ICampeonatoBO _campeonatoBO;
        private BolaoNet.Business.Interfaces.Facade.IBolaoFacadeBO _bolaoFacadeBO;
        private BolaoNet.Business.Interfaces.Facade.IUserFacadeBO _userFacadeBO;

        private BolaoNet.Business.Interfaces.IFactoryBO _factory;

        #endregion

        #region Constructors/Destructors

        public BolaoCopaMundo2014UserFacadeBO(BolaoNet.Business.Interfaces.IFactoryBO factory)
        {
            _factory = factory;
            _userBO = factory.CreateUserBO();
            _jogoUsuarioBO = factory.CreateJogoUsuarioBO();
            _jogoBO = factory.CreateJogoBO();
            _bolaoBO = factory.CreateBolaoBO();
            _bolaoMembroBO = factory.CreateBolaoMembroBO();
            _campeonatoBO = factory.CreateCampeonatoBO();
            _bolaoFacadeBO = factory.CreateBolaoFacadeBO();
            _userFacadeBO = factory.CreateUserFacadeBO();

        }

        #endregion

        #region Methods

        
        public bool ApplyApostas(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.Campeonato campeonato, IList<int> jogoLabel, IList<int> time1, IList<int> time2, IList<int ?> penaltis1, IList<int ?> penaltis2)
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
                Entities.Campeonatos.Jogo jogo = new Entities.Campeonatos.Jogo(campeonato.Nome, jogoLabel[c]);

                _bolaoFacadeBO.InsertJogoUsuario(user, bolao, jogo, time1[c], time2[c], penaltis1[c], penaltis2[c]);

            }//end for c

            


            return true;
        }
        public bool StoreData<T>(BolaoNet.Business.Base.IGenericBusiness<T> bo, T data)
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
        public bool CreateUserApostas(Entities.Users.User user, Entities.Boloes.Bolao bolao, IList<Entities.Boloes.JogoUsuario> jogos)
        {
            string activationCode = "";

            Entities.Boloes.Bolao bolaoLoaded = _bolaoBO.Load(bolao);

            _userFacadeBO.CreateUser(user);
            _userFacadeBO.SendActivationCode(user);

            Entities.Users.User loadedUser = _userBO.Load(user);
            activationCode = loadedUser.ActivateKey;

            _userFacadeBO.ActivateUser(user, activationCode);

            Entities.Boloes.BolaoMembro membro = new Entities.Boloes.BolaoMembro(user.UserName, bolao.Nome) { FullName = user.FullName };
            _bolaoMembroBO.Insert(membro);

            for (int c = 0; c < jogos.Count; c++ )
            {
                Entities.Campeonatos.Jogo jogo = new Entities.Campeonatos.Jogo(bolaoLoaded.NomeCampeonato, jogos[c].JogoId);

                _bolaoFacadeBO.InsertJogoUsuario(user, bolao, jogo, jogos[c].ApostaTime1, jogos[c].ApostaTime2, 
                    jogos[c].ApostaPenaltis1, jogos[c].ApostaPenaltis2);
            }

            return true;
        }
        public Entities.Boloes.JogoUsuario CreateJogoUsuario(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.Campeonato campeonato, int jogoId, int time1, int time2, int ? penaltis1, int ? penaltis2)
        {
            return new Entities.Boloes.JogoUsuario(user.UserName, bolao.Nome, campeonato.Nome, jogoId)
            {
                ApostaTime1 = time1,
                ApostaTime2 = time2,
                ApostaPenaltis1 = penaltis1,
                ApostaPenaltis2 = penaltis2
            };
        }
        public Entities.Users.User CreateUserApostasThoris(Entities.Boloes.Bolao bolao)
        {
           
            Entities.Users.User user = new Entities.Users.User("Thoris");

            Entities.Boloes.Bolao bolaoLoaded = _bolaoBO.Load(bolao);
            Entities.Campeonatos.Campeonato campeonato = _campeonatoBO.Load (new Entities.Campeonatos.Campeonato(bolaoLoaded.NomeCampeonato));

            IList<Entities.Boloes.JogoUsuario> jogos = new List<Entities.Boloes.JogoUsuario>();

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
        public Entities.Users.User CreateUserApostasFixo (Entities.Boloes.Bolao bolao, string userName, int time1, int time2)
        {
            Entities.Users.User user = new Entities.Users.User(userName);

            Entities.Boloes.Bolao bolaoLoaded = _bolaoBO.Load(bolao);
            Entities.Campeonatos.Campeonato campeonato = _campeonatoBO.Load(new Entities.Campeonatos.Campeonato(bolaoLoaded.NomeCampeonato));

            IList<Entities.Boloes.JogoUsuario> jogos = new List<Entities.Boloes.JogoUsuario>();

            for (int c = 0; c < 64; c++ )
            {
                jogos.Add(CreateJogoUsuario(user, bolao, campeonato, c+1, time1, time2, null, null));
            }
            
            CreateUserApostas(user, bolao, jogos);

            return user;
        }
        public Entities.Users.User CreateUserApostasRandom(Entities.Boloes.Bolao bolao, string userName, int maxTime1, int maxTime2)
        {
            Entities.Users.User user = new Entities.Users.User(userName);

            Entities.Boloes.Bolao bolaoLoaded = _bolaoBO.Load(bolao);
            Entities.Campeonatos.Campeonato campeonato = _campeonatoBO.Load(new Entities.Campeonatos.Campeonato(bolaoLoaded.NomeCampeonato));

            IList<Entities.Boloes.JogoUsuario> jogos = new List<Entities.Boloes.JogoUsuario>();

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

        public void CreateAllData()
        {

            BolaoNet.Business.Facade.Campeonatos.CopaMundo2014FacadeBO campeonatoBO =
                new BolaoNet.Business.Facade.Campeonatos.CopaMundo2014FacadeBO(_factory);

            Entities.Campeonatos.Campeonato campeonato = campeonatoBO.CreateCampeonato();

            TestsVS.Business.Facade.BolaoCopaMundo2014FacadeBO bolaoBO = new BolaoCopaMundo2014FacadeBO(_factory);

            Entities.Boloes.Bolao bolao = bolaoBO.CreateBolao(campeonato);

            CreateUserApostasThoris(bolao);
            CreateUserApostasFixo(bolao, "Usuario1", 1, 0);
            CreateUserApostasFixo(bolao, "Usuario2", 0, 1);
            CreateUserApostasFixo(bolao, "Usuario3", 1, 1);
            CreateUserApostasRandom(bolao, "Usuario4", 3, 3);
            CreateUserApostasRandom(bolao, "Usuario5", 3, 3);
            CreateUserApostasRandom(bolao, "Usuario6", 3, 3);
            CreateUserApostasRandom(bolao, "Usuario7", 3, 3);
            CreateUserApostasRandom(bolao, "Usuario8", 3, 3);
            CreateUserApostasRandom(bolao, "Usuario9", 3, 3);
            CreateUserApostasRandom(bolao, "Usuario10", 3, 3);

            bolaoBO.StartBolao(bolao);

            campeonatoBO.InsertResults(campeonato);

        }
        
        #endregion
    }
}
