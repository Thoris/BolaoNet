using BolaoNet.Reports.Base;
using BolaoNet.Reports.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Reports.DataReports
{
    public class CopaMundoApostasUserReport
    {
        #region Variables

        private Business.Interfaces.Campeonatos.IJogoBO _jogoBO;
        private Business.Interfaces.Boloes.IApostaExtraBO _apostaExtraBO;
        private Business.Interfaces.Boloes.IApostaExtraUsuarioBO _apostaExtraUsuarioBO;
        private Business.Interfaces.Boloes.IJogoUsuarioBO _jogoUsuarioBO;
        private Business.Interfaces.Users.IUserBO _userBO;
        private Business.Interfaces.Boloes.IBolaoBO _bolaoBO;
        private Business.Interfaces.Boloes.IBolaoMembroBO _bolaoMembroBO;
        private IApostasUserReport _apostaUserReport;

        #endregion

        #region Constructors/Destructors

        public CopaMundoApostasUserReport(Integration.FactoryIntegration factory, FactoryReport factoryReport)
        {
            _jogoBO = factory.CreateJogoBO();
            _apostaExtraBO = factory.CreateApostaExtraBO();
            _apostaExtraUsuarioBO = factory.CreateApostaExtraUsuarioBO();
            _jogoUsuarioBO = factory.CreateJogoUsuarioBO();
            _userBO = factory.CreateUserBO();
            _bolaoBO = factory.CreateBolaoBO();
            _bolaoMembroBO = factory.CreateBolaoMembroBO();

            
            _apostaUserReport = factoryReport.GetFactoryBase ().CreateApostasUserReport();
        }

        #endregion

        #region Methods

        public void GenerateApostasUsers(Entities.Boloes.Bolao bolao)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");


            IList<Entities.Boloes.BolaoMembro> users = _bolaoMembroBO.GetListUsersInBolao(bolao);

            
            Entities.Boloes.Bolao bolaoLoaded = _bolaoBO.Load (bolao);
            
            Entities.Campeonatos.Campeonato campeonato = new Entities.Campeonatos.Campeonato(bolaoLoaded.NomeCampeonato);

            IList<Entities.Campeonatos.Jogo> jogosList = _jogoBO.GetJogosByCampeonato(campeonato);
            IList<Entities.Boloes.ApostaExtra> apostasExtrasList = _apostaExtraBO.GetApostasBolao(bolao);
            


            for (int c=0; c < users.Count; c++)
            {
                Entities.Users.User userLoaded = _userBO.Load (new Entities.Users.User( users[c].UserName));
                IList<Entities.Boloes.JogoUsuario> jogosUsuariosList = _jogoUsuarioBO.GetJogosByUser(bolao, userLoaded);

                IList<Entities.Boloes.ApostaExtraUsuario> apostasExtrasUsuariosList = 
                    _apostaExtraUsuarioBO.GetApostasUser(bolao, userLoaded);

                
                _apostaUserReport.CreatePageUserApostas(bolaoLoaded, campeonato, userLoaded,
                    jogosList.ToList (), jogosUsuariosList, apostasExtrasList.ToList (), apostasExtrasUsuariosList);
            }

            _apostaUserReport.Close();

        }
        public void GenerateApostasUser(Entities.Boloes.Bolao bolao, Entities.Users.User user)
        {
            if (bolao == null)
                throw new ArgumentException ("bolao");
            if (string.IsNullOrEmpty (bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");

            Entities.Boloes.Bolao bolaoLoaded = _bolaoBO.Load (bolao);
            Entities.Users.User userLoaded = _userBO.Load (user);

            Entities.Campeonatos.Campeonato campeonato = new Entities.Campeonatos.Campeonato(bolaoLoaded.NomeCampeonato);

            IList<Entities.Campeonatos.Jogo> jogosList = _jogoBO.GetJogosByCampeonato(campeonato);
            IList<Entities.Boloes.JogoUsuario> jogosUsuariosList = _jogoUsuarioBO.GetJogosByUser(bolao, userLoaded);
            IList<Entities.Boloes.ApostaExtra> apostasExtrasList = _apostaExtraBO.GetApostasBolao(bolao);
            IList<Entities.Boloes.ApostaExtraUsuario> apostasExtrasUsuariosList = _apostaExtraUsuarioBO.GetApostasUser(bolao, userLoaded);


            _apostaUserReport.CreatePageUserApostas(bolaoLoaded, campeonato, userLoaded,
                jogosList, jogosUsuariosList, apostasExtrasList, apostasExtrasUsuariosList);

            _apostaUserReport.Close();
        }

        #endregion
    }
}
