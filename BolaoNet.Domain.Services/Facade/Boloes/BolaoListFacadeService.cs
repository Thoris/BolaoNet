
using BolaoNet.Domain.Interfaces.Services.Facade.Boloes;
using System.Collections.Generic;

namespace BolaoNet.Domain.Services.Facade.Boloes
{
    public class BolaoListFacadeService
        : Interfaces.Services.Facade.Boloes.IBolaoListFacadeService
    {
        #region Variables


        private Interfaces.Services.Boloes.IApostaExtraService _apostaExtraService;
        private Interfaces.Services.Boloes.IBolaoService _bolaoService;
        private Interfaces.Services.Boloes.IBolaoPremioService _bolaoPremioService;
        private Interfaces.Services.Boloes.IBolaoCriterioPontosService _bolaoCriterioPontosService;
        private Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService _bolaoCriterioPontosTimesService;
        private Interfaces.Services.Boloes.IBolaoRegraService _bolaoRegraService;
        private Interfaces.Services.Boloes.IBolaoPontuacaoService _bolaoPontuacaoService;
        private Interfaces.Services.Boloes.IBolaoHistoricoService _bolaoHistoricoService;
        private Interfaces.Services.Users.IUserService _userService;
        private Interfaces.Services.Facade.IUserFacadeService _userFacadeService;
        private Interfaces.Services.Boloes.IBolaoMembroService _bolaoMembroService;
        private Interfaces.Services.Boloes.IJogoUsuarioService _jogoUsuarioService;

        #endregion

        #region Constructors/Destructors

        public BolaoListFacadeService(        
                Interfaces.Services.Boloes.IApostaExtraService apostaExtraService,
                Interfaces.Services.Boloes.IBolaoService bolaoService,
                Interfaces.Services.Boloes.IBolaoPremioService bolaoPremioService,
                Interfaces.Services.Boloes.IBolaoCriterioPontosService bolaoCriterioPontosService,
                Interfaces.Services.Boloes.IBolaoCriterioPontosTimesService bolaoCriterioPontosTimesService,
                Interfaces.Services.Boloes.IBolaoRegraService bolaoRegraService,
                Interfaces.Services.Boloes.IBolaoPontuacaoService bolaoPontuacaoService,
                Interfaces.Services.Boloes.IBolaoHistoricoService bolaoHistoricoService,
                Interfaces.Services.Users.IUserService userService,
                Interfaces.Services.Facade.IUserFacadeService userFacadeService,
                Interfaces.Services.Boloes.IBolaoMembroService bolaoMembroService,
                Interfaces.Services.Boloes.IJogoUsuarioService jogoUsuarioService
            )

        {
            _apostaExtraService = apostaExtraService;
            _bolaoService = bolaoService;
            _bolaoPremioService = bolaoPremioService;
            _bolaoCriterioPontosService = bolaoCriterioPontosService;
            _bolaoCriterioPontosTimesService = bolaoCriterioPontosTimesService;
            _bolaoRegraService = bolaoRegraService;
            _bolaoPontuacaoService = bolaoPontuacaoService;
            _bolaoHistoricoService = bolaoHistoricoService;
            _userService = userService;
            _userFacadeService = userFacadeService;
            _bolaoMembroService = bolaoMembroService;
            _jogoUsuarioService = jogoUsuarioService;
        }

        #endregion

        #region IBolaoListFacadeService members

        public IBolaoFacadeService GetInstance(string name)
        {
            switch (name)
            {
                case BolaoCopaMundo2010ServiceHelper.NomeBolao:

                    return new BolaoCopaMundo2010ServiceHelper(_apostaExtraService, _bolaoService, _bolaoPremioService,
                        _bolaoCriterioPontosService, _bolaoCriterioPontosTimesService, _bolaoRegraService, _bolaoPontuacaoService,
                        _bolaoHistoricoService, _userService, _userFacadeService, _bolaoMembroService, _jogoUsuarioService);

                case BolaoCopaMundo2014ServiceHelper.NomeBolao:

                    return new BolaoCopaMundo2014ServiceHelper(_apostaExtraService, _bolaoService, _bolaoPremioService,
                        _bolaoCriterioPontosService, _bolaoCriterioPontosTimesService, _bolaoRegraService, _bolaoPontuacaoService,
                        _bolaoHistoricoService, _userService, _userFacadeService, _bolaoMembroService, _jogoUsuarioService);

                case BolaoCopaMundo2018ServiceHelper.NomeBolao:

                    return new BolaoCopaMundo2018ServiceHelper(_apostaExtraService, _bolaoService, _bolaoPremioService,
                        _bolaoCriterioPontosService, _bolaoCriterioPontosTimesService, _bolaoRegraService, _bolaoPontuacaoService,
                        _bolaoHistoricoService, _userService, _userFacadeService, _bolaoMembroService, _jogoUsuarioService);

                case BolaoCopaAmerica2019ServiceHelper.NomeBolao:

                    return new BolaoCopaAmerica2019ServiceHelper(_apostaExtraService, _bolaoService, _bolaoPremioService,
                        _bolaoCriterioPontosService, _bolaoCriterioPontosTimesService, _bolaoRegraService, _bolaoPontuacaoService,
                        _bolaoHistoricoService, _userService, _userFacadeService, _bolaoMembroService, _jogoUsuarioService);

                case BolaoCopaMundo2022ServiceHelper.NomeBolao:

                    return new BolaoCopaMundo2022ServiceHelper(_apostaExtraService, _bolaoService, _bolaoPremioService,
                        _bolaoCriterioPontosService, _bolaoCriterioPontosTimesService, _bolaoRegraService, _bolaoPontuacaoService,
                        _bolaoHistoricoService, _userService, _userFacadeService, _bolaoMembroService, _jogoUsuarioService);

                case BolaoCopaMundo2026ServiceHelper.NomeBolao:

                    return new BolaoCopaMundo2026ServiceHelper(_apostaExtraService, _bolaoService, _bolaoPremioService,
                        _bolaoCriterioPontosService, _bolaoCriterioPontosTimesService, _bolaoRegraService, _bolaoPontuacaoService,
                        _bolaoHistoricoService, _userService, _userFacadeService, _bolaoMembroService, _jogoUsuarioService);
            }

            return null;
        }

        public IList<string> GetNames()
        {
            IList<string> list = new List<string>();

            list.Add(BolaoCopaMundo2010ServiceHelper.NomeBolao);
            list.Add(BolaoCopaMundo2014ServiceHelper.NomeBolao);
            list.Add(BolaoCopaMundo2018ServiceHelper.NomeBolao);
            list.Add(BolaoCopaAmerica2019ServiceHelper.NomeBolao);
            list.Add(BolaoCopaMundo2022ServiceHelper.NomeBolao);
            list.Add(BolaoCopaMundo2026ServiceHelper.NomeBolao);

            return list;
        }

        #endregion
    }
}
