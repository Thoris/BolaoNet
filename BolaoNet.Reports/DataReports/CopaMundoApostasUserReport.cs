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

        private Integration.Campeonatos.JogoIntegration _jogoBO;
        private Integration.Boloes.ApostaExtraIntegration _apostaExtraBO;
        private Integration.Boloes.ApostaExtraUsuarioIntegration _apostaExtraUsuarioBO;
        private Integration.Boloes.JogoUsuarioIntegration _jogoUsuarioBO;
        private Integration.Users.UserIntegration _userBO;
        private Integration.Boloes.BolaoIntegration _bolaoBO;
        private IApostasUserReport _apostaUserReport;

        #endregion

        #region Constructors/Destructors

        public CopaMundoApostasUserReport(Integration.FactoryIntegration factory, FactoryReport factoryReport)
        {
            _jogoBO = (Integration.Campeonatos.JogoIntegration)factory.CreateJogoBO();
            _apostaExtraBO = (Integration.Boloes.ApostaExtraIntegration)factory.CreateApostaExtraBO();
            _apostaExtraUsuarioBO = (Integration.Boloes.ApostaExtraUsuarioIntegration)factory.CreateApostaExtraUsuarioBO();
            _jogoUsuarioBO = (Integration.Boloes.JogoUsuarioIntegration)factory.CreateJogoUsuarioBO();
            _userBO = (Integration.Users.UserIntegration)factory.CreateUserBO();
            _bolaoBO = (Integration.Boloes.BolaoIntegration)factory.CreateBolaoBO();

            
            _apostaUserReport = factoryReport.GetFactoryBase ().CreateApostasUserReport();
        }

        #endregion

        #region Methods

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

            Entities.Campeonatos.Campeonato campeonato =new Entities.Campeonatos.Campeonato(bolao.NomeCampeonato);

            IList<Entities.Campeonatos.Jogo> jogosList = _jogoBO.GetJogosByCampeonato(campeonato);
            IList<Entities.Boloes.JogoUsuario> jogosUsuariosList = _jogoUsuarioBO.GetJogosByUser(bolao, user);
            IList<Entities.Boloes.ApostaExtra> apostasExtrasList = _apostaExtraBO.GetApostasBolao(bolao);
            IList<Entities.Boloes.ApostaExtraUsuario> apostasExtrasUsuariosList = _apostaExtraUsuarioBO.GetApostasUser(bolao, user);


            _apostaUserReport.CreatePageUserApostas(bolaoLoaded, campeonato, userLoaded,
                jogosList, jogosUsuariosList, apostasExtrasList, apostasExtrasUsuariosList);
        }

        #endregion
    }
}
