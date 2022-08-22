using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Facade.Campeonatos
{
    public class StructureCopaMundoFacadeService  : BaseStructureCopaMundoFacadeService,
        Interfaces.Services.Facade.Campeonatos.IStructureCopaMundoFacadeService
    {
        #region Constructors/Destructors

        public StructureCopaMundoFacadeService(
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
            : base(
                timeService,
                campeonatoService,
                campeonatoTimeService,
                campeonatoFaseService,
                campeonatoGrupoService,
                campeonatoGrupoTimeService,
                estadioService, 
                jogoService,
                campeonatoPosicaoService,
                campeonatoHistoricoService
            )
        {
        
        }
        
        #endregion

        #region IStructureCopaMundoFacadeService members

        public Entities.Campeonatos.Campeonato CreateCampeonato(string nomeCampeonato, bool isTime)
        {
            Entities.Campeonatos.Campeonato campeonato = new Entities.Campeonatos.Campeonato(nomeCampeonato)
            {
                IsClube = isTime,
                IsIniciado = false
            };

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            StoreData<Entities.Campeonatos.Campeonato>(_campeonatoService, campeonato);


            base.Campeonato = _campeonatoService.Load(campeonato);

            return campeonato;
        }
        public IList<Entities.Campeonatos.CampeonatoPosicao> GetCampeonatoPosicoes(string nomeFase)
        {
            return base.GetCampeonatoPosicoes(base.Campeonato, nomeFase);
        }
        public IList<Entities.Campeonatos.Jogo> GetJogosOitavas(int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids)
        {
            return base.GetJogosOitavas(base.Campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids);
        }
        public IList<Entities.Campeonatos.Jogo> GetJogosQuartas(int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids, IList<int> idsGanhadores)
        {
            return base.GetJogosQuartas(base.Campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids, idsGanhadores);
        }
        public IList<Entities.Campeonatos.Jogo> GetJogosSemi(int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids, IList<int> idsGanhadores)
        {
            return base.GetJogosSemi(base.Campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids, idsGanhadores);
        }
        public IList<Entities.Campeonatos.Jogo> GetJogosFinal(int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids, IList<int> idsGanhadores)
        {
            return base.GetJogosFinal(base.Campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids, idsGanhadores);
        }
        public IList<Entities.Campeonatos.Jogo> GetJogosGrupo(string nomeGrupo, string nomeFase, IList<string> times, IList<DateTime> datas, IList<string> estadios, IList<int> ids)
        {
            return base.GetJogosGrupo(base.Campeonato, nomeGrupo, nomeFase, times, datas, estadios, ids);
        }
        public bool InsertResult(int jogoID, bool setCurrentData, Entities.Users.User validadoBy, int golsTime1, int golsTime2, int? penaltis1, int? penaltis2)
        {
            return base.InsertResult(base.Campeonato, jogoID, setCurrentData, validadoBy, golsTime1, golsTime2, penaltis1, penaltis2);
        }
        public bool RestartCampeonato(string nomeCampeonato)
        {
            throw new NotImplementedException();
        }

        #endregion


    }
}
