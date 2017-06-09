﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Boloes
{
    public class JogoUsuarioApp :
        Base.GenericApp<Domain.Entities.Boloes.JogoUsuario>,
        Domain.Interfaces.Services.Boloes.IJogoUsuarioService
    {
        #region Properties

        private Domain.Interfaces.Services.Boloes.IJogoUsuarioService Service
        {
            get { return (Domain.Interfaces.Services.Boloes.IJogoUsuarioService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="JogoUsuarioApp" />.
        /// </summary>
        public JogoUsuarioApp(Domain.Interfaces.Services.Boloes.IJogoUsuarioService service)
            : base (service)
        {

        }

        #endregion

        #region IJogoUsuarioService members

        public bool ProcessAposta(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user, Domain.Entities.Campeonatos.Jogo jogo, int automatico, int apostaTime1, int apostaTime2, int? penaltis1, int? penaltis2, int? ganhador)
        {
            return Service.ProcessAposta(bolao, user, jogo, automatico, apostaTime1, apostaTime2, penaltis1, penaltis2, ganhador);
        }

        public IList<Domain.Entities.Boloes.JogoUsuario> GetJogosByUser(Domain.Entities.Boloes.Bolao bolao, Domain.Entities.Users.User user)
        {
            return Service.GetJogosByUser(bolao, user);
        }

        #endregion


    }
}
