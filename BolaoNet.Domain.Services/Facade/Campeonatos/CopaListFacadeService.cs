using BolaoNet.Domain.Interfaces.Services.Facade.Campeonatos;
using System;
using System.Collections.Generic;

namespace BolaoNet.Domain.Services.Facade.Campeonatos
{
    public class CopaListFacadeService : ICopaListFacadeService
    {

        #region Variables

        private Interfaces.Services.DadosBasicos.ITimeService _timeService;
        private Interfaces.Services.Campeonatos.ICampeonatoService _campeonatoService;
        private Interfaces.Services.Campeonatos.ICampeonatoTimeService _campeonatoTimeService;
        private Interfaces.Services.Campeonatos.ICampeonatoFaseService _campeonatoFaseService;
        private Interfaces.Services.Campeonatos.ICampeonatoGrupoService _campeonatoGrupoService;
        private Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService _campeonatoGrupoTimeService;
        private Interfaces.Services.DadosBasicos.IEstadioService _estadioService;
        private Interfaces.Services.Campeonatos.IJogoService _jogoService;
        private Interfaces.Services.Campeonatos.ICampeonatoPosicaoService _campeonatoPosicaoService;
        private Interfaces.Services.Campeonatos.ICampeonatoHistoricoService _campeonatoHistoricoService;

        #endregion

        #region Constructors/Destructors

        public CopaListFacadeService(
            Interfaces.Services.DadosBasicos.ITimeService timeService,
            Interfaces.Services.Campeonatos.ICampeonatoService campeonatoService,
            Interfaces.Services.Campeonatos.ICampeonatoTimeService campeonatoTimeService,
            Interfaces.Services.Campeonatos.ICampeonatoFaseService campeonatoFaseService,
            Interfaces.Services.Campeonatos.ICampeonatoGrupoService campeonatoGrupoService,
            Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService campeonatoGrupoTimeService,
            Interfaces.Services.DadosBasicos.IEstadioService estadioService,
            Interfaces.Services.Campeonatos.IJogoService jogoService,
            Interfaces.Services.Campeonatos.ICampeonatoPosicaoService campeonatoPosicaoService,
            Interfaces.Services.Campeonatos.ICampeonatoHistoricoService campeonatoHistoricoService
            )

        {
            _timeService = timeService;
            _campeonatoService = campeonatoService;
            _campeonatoTimeService = campeonatoTimeService;
            _campeonatoFaseService = campeonatoFaseService;
            _campeonatoGrupoService = campeonatoGrupoService;
            _campeonatoGrupoTimeService = campeonatoGrupoTimeService;
            _estadioService = estadioService;
            _jogoService = jogoService;
            _campeonatoPosicaoService = campeonatoPosicaoService;
            _campeonatoHistoricoService = campeonatoHistoricoService;
        }

        #endregion

        #region ICopaListFacadeService members

        public ICopaFacadeService GetInstance(string name)
        {
            switch (name)
            {
                case CopaMundo2010FacadeService.Name:
                    return new CopaMundo2010FacadeService(_timeService, _campeonatoService, _campeonatoTimeService,
                        _campeonatoFaseService, _campeonatoGrupoService, _campeonatoGrupoTimeService, _estadioService,
                        _jogoService, _campeonatoPosicaoService, _campeonatoHistoricoService);
                    
                case CopaMundo2014FacadeService.Name:
                    return new CopaMundo2014FacadeService(_timeService, _campeonatoService, _campeonatoTimeService,
                        _campeonatoFaseService, _campeonatoGrupoService, _campeonatoGrupoTimeService, _estadioService,
                        _jogoService, _campeonatoPosicaoService, _campeonatoHistoricoService);
                    
                case CopaMundo2018FacadeService.Name:
                    return new CopaMundo2018FacadeService(_timeService, _campeonatoService, _campeonatoTimeService,
                        _campeonatoFaseService, _campeonatoGrupoService, _campeonatoGrupoTimeService, _estadioService,
                        _jogoService, _campeonatoPosicaoService, _campeonatoHistoricoService);

                case CopaAmerica2019FacadeService.Name:
                    return new CopaAmerica2019FacadeService(_timeService, _campeonatoService, _campeonatoTimeService,
                        _campeonatoFaseService, _campeonatoGrupoService, _campeonatoGrupoTimeService, _estadioService,
                        _jogoService, _campeonatoPosicaoService, _campeonatoHistoricoService);

                case CopaMundo2022FacadeService.Name:
                    return new CopaMundo2022FacadeService(_timeService, _campeonatoService, _campeonatoTimeService,
                        _campeonatoFaseService, _campeonatoGrupoService, _campeonatoGrupoTimeService, _estadioService,
                        _jogoService, _campeonatoPosicaoService, _campeonatoHistoricoService);

                case CopaMundo2026FacadeService.Name:
                    return new CopaMundo2026FacadeService(_timeService, _campeonatoService, _campeonatoTimeService,
                        _campeonatoFaseService, _campeonatoGrupoService, _campeonatoGrupoTimeService, _estadioService,
                        _jogoService, _campeonatoPosicaoService, _campeonatoHistoricoService);
            }

            return null;
        }

        public IList<string> GetNames()
        {
            IList<string> list = new List<string>();

            list.Add(CopaMundo2010FacadeService.Name);
            list.Add(CopaMundo2014FacadeService.Name);
            list.Add(CopaMundo2018FacadeService.Name);
            list.Add(CopaAmerica2019FacadeService.Name);
            list.Add(CopaMundo2022FacadeService.Name);
            list.Add(CopaMundo2026FacadeService.Name);

            return list;
        }

        #endregion
    }
}
