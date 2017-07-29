using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Facade
{
    public class BolaoFacadeService
        : Interfaces.Services.Facade.IBolaoFacadeService
    {
        #region Variables

        private Interfaces.Services.Boloes.IBolaoService _bolaoBO;
        private Interfaces.Services.Boloes.IJogoUsuarioService _jogoUsuarioBO;
        private Interfaces.Services.Campeonatos.IJogoService _jogoBO;

        #endregion

        #region Constructors/Destructors

        public BolaoFacadeService(Interfaces.Services.IFactoryService factoryService)
        {
            _bolaoBO = factoryService.CreateBolaoService();
            _jogoUsuarioBO = factoryService.CreateJogoUsuarioService();
            _jogoBO = factoryService.CreateJogoService();
        }

        #endregion

        #region Methods

        public IList<Entities.Boloes.JogoUsuario> InsertJogoUsuario(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.Jogo jogo, int automatico, int time1, int time2, int? penaltis1, int? penaltis2)
        {
            _jogoUsuarioBO.ProcessAposta(bolao, user, jogo, automatico, time1, time2, penaltis1, penaltis2, null);

            return null;
        }


        //public IList<Entities.Boloes.JogoUsuario> InsertJogoUsuario(Entities.Users.User user, Entities.Boloes.Bolao bolao, Entities.Campeonatos.Jogo jogo, int time1, int time2, int ? penaltis1, int ? penaltis2)
        //{
        //    IList<Entities.Boloes.JogoUsuario> list = new List<Entities.Boloes.JogoUsuario>();

        //    Entities.Boloes.JogoUsuario jogoUsuario = new Entities.Boloes.JogoUsuario(user.UserName, bolao.Nome, jogo.NomeCampeonato, jogo.JogoId)
        //    {
        //        ApostaPenaltis1 = penaltis1,
        //        ApostaPenaltis2 = penaltis2,
        //        ApostaTime1 = time1,
        //        ApostaTime2 = time2,
        //        DataAposta = DateTime.Now,
        //    };

        //    //Carregando a existência do jogo na base
        //    Entities.Boloes.JogoUsuario jogoLoaded = _jogoUsuarioBO.Load(jogoUsuario);

        //    long res = 0;

        //    if (jogoLoaded == null)
        //    {
        //        res = _jogoUsuarioBO.Insert(jogoUsuario);
        //    }
        //    else
        //    {
        //        if (jogoUsuario.ApostaTime1 != jogoLoaded.ApostaTime1 ||
        //            jogoUsuario.ApostaTime2 != jogoLoaded.ApostaTime2 ||
        //            jogoUsuario.ApostaTime1 != jogoLoaded.ApostaTime1 ||
        //            jogoUsuario.ApostaTime2 != jogoLoaded.ApostaTime2)
        //        {
        //            bool resUpdate = _jogoUsuarioBO.Update(jogoUsuario);

        //            if (resUpdate)
        //                res = 1;
        //        }
        //    }

        //    if (res > 0)
        //    {
        //    }
            
            
        //    //bool res = _jogoUsuarioBO.InsertAposta(user, bolao, jogo, time1, time2, penaltis1, penaltis2);

        //    return list;
        //}



        #endregion
    }
}
