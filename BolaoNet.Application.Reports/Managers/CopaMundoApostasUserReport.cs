using BolaoNet.Application.Reports.FormatReports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Reports.Managers
{
    public class CopaMundoApostasUserReport
    {
        #region Variables

        private Application.Interfaces.Campeonatos.IJogoApp _jogoApp;
        private Application.Interfaces.Boloes.IApostaExtraApp _apostaExtraApp;
        private Application.Interfaces.Boloes.IApostaExtraUsuarioApp _apostaExtraUsuarioApp;
        private Application.Interfaces.Boloes.IJogoUsuarioApp _jogoUsuarioApp;
        private Application.Interfaces.Users.IUserApp _userApp;
        private Application.Interfaces.Boloes.IBolaoApp _bolaoApp;
        private Application.Interfaces.Boloes.IBolaoMembroApp _bolaoMembroApp;
        
        #endregion

        #region Constructors/Destructors

        public CopaMundoApostasUserReport(Application.Interfaces.Campeonatos.IJogoApp jogoApp, 
            Application.Interfaces.Boloes.IApostaExtraApp apostaExtraApp, Application.Interfaces.Boloes.IApostaExtraUsuarioApp apostaExtraUsuarioApp,
            Application.Interfaces.Boloes.IJogoUsuarioApp jogoUsuarioApp, Application.Interfaces.Users.IUserApp userApp, 
            Application.Interfaces.Boloes.IBolaoApp bolaoApp, Application.Interfaces.Boloes.IBolaoMembroApp bolaoMembroApp)
        {
            _jogoApp = jogoApp;
            _apostaExtraApp = apostaExtraApp;
            _apostaExtraUsuarioApp = apostaExtraUsuarioApp;
            _jogoUsuarioApp = jogoUsuarioApp;
            _userApp = userApp;
            _bolaoApp = bolaoApp;
            _bolaoMembroApp = bolaoMembroApp;

        }
        
        #endregion

        #region Methods

        public void GenerateApostasUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, IApostasUserReport apostaUserReport)
        {
            if (bolao == null)
                throw new ArgumentException("bolao");
            if (string.IsNullOrEmpty(bolao.Nome))
                throw new ArgumentException("bolao.Nome");
            if (user == null)
                throw new ArgumentException("user");
            if (string.IsNullOrEmpty(user.UserName))
                throw new ArgumentException("user.UserName");

            Domain.Entities.Boloes.Bolao bolaoLoaded = _bolaoApp.Load(bolao);
            Domain.Entities.Users.User userLoaded = _userApp.Load(user);

            Domain.Entities.Campeonatos.Campeonato campeonato = 
                new Domain.Entities.Campeonatos.Campeonato(bolaoLoaded.NomeCampeonato);

            IList<Domain.Entities.Campeonatos.Jogo> jogosList = _jogoApp.GetJogosByCampeonato(campeonato);
            IList<Domain.Entities.Boloes.JogoUsuario> jogosUsuariosList = _jogoUsuarioApp.GetJogosByUser(bolao, userLoaded);
            IList<Domain.Entities.Boloes.ApostaExtra> apostasExtrasList = _apostaExtraApp.GetApostasBolao(bolao);
            IList<Domain.Entities.Boloes.ApostaExtraUsuario> apostasExtrasUsuariosList = _apostaExtraUsuarioApp.GetApostasUser(bolao, userLoaded);


            apostaUserReport.CreatePageUserApostas(bolaoLoaded, campeonato, userLoaded,
                jogosList, jogosUsuariosList, apostasExtrasList, apostasExtrasUsuariosList);

            apostaUserReport.Close();
        }

        #endregion
    }
}
