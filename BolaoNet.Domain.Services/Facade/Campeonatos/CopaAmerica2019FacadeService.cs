using System;
using System.Collections.Generic;
using System.Linq;

namespace BolaoNet.Domain.Services.Facade.Campeonatos
{
    public class CopaAmerica2019FacadeService : BaseStructureCopaMundoFacadeService,
        Domain.Interfaces.Services.Facade.Campeonatos.ICopaAmerica2019FacadeService
    {

        #region Constants

        public const string Name = "Copa América 2019";

        public bool IsContainsResults
        {
            get { return false; }
        }

        #endregion

        #region Constructors/Destructors

        public CopaAmerica2019FacadeService(
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

        #region ICopaMundoFacadeService members

        public Entities.Campeonatos.Campeonato CreateCampeonato(string nomeCampeonato, bool isClube)
        {
            Entities.Campeonatos.Campeonato campeonato = new Entities.Campeonatos.Campeonato(nomeCampeonato)
            {
                IsClube = isClube,
                IsIniciado = false,
                TipoCampeonato = (int)Entities.Campeonatos.Campeonato.Tipos.CopaAmerica
            };

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            StoreData<Entities.Campeonatos.Campeonato>(_campeonatoService, campeonato);


            base.Campeonato = _campeonatoService.Load(campeonato);

            list = base.Merge(list, GetJogosGrupo());
            list = base.Merge(list, GetOitavasFinal());
            list = base.Merge(list, GetQuartasFinal());
            list = base.Merge(list, GetSemiFinal());
            list = base.Merge(list, GetFinal());

            for (int c = 0; c < list.Count; c++)
            {
                base.InsertAllJogoInformation(campeonato.IsClube, campeonato, list[c]);
            }

            string nomeFase = FaseClassificatoria;

            IList<Entities.Campeonatos.CampeonatoPosicao> listPosicao = this.GetCampeonatoPosicoes(campeonato, nomeFase);

            for (int c = 0; c < listPosicao.Count; c++)
            {
                StoreData<Entities.Campeonatos.CampeonatoPosicao>(_campeonatoPosicaoService, listPosicao[c]);
            }

            return campeonato;
        }        
        public IList<Entities.Campeonatos.Jogo> GetJogosGrupo()
        {
            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            string nomeFase =  FaseClassificatoria;

            IList<DateTime> datas = new List<DateTime>();
            IList<string> estadios = new List<string>();
            IList<int> ids = new List<int>();
            string[] grupoA = { "Brasil", "Bolívia", "Venezuela", "Peru" };
            datas.Add(new DateTime(2019, 6, 14, 21, 30, 0, 0)); estadios.Add("Morumbi"); ids.Add(1);
            datas.Add(new DateTime(2019, 6, 15, 16, 0, 0, 0)); estadios.Add("Arena do Grêmio"); ids.Add(2);
            datas.Add(new DateTime(2019, 6, 18, 18, 30, 0, 0)); estadios.Add("Maracanã"); ids.Add(7);
            datas.Add(new DateTime(2019, 6, 18, 21, 30, 0, 0)); estadios.Add("Fonte Nova"); ids.Add(8);
            datas.Add(new DateTime(2019, 6, 22, 16, 0, 0, 0)); estadios.Add("Arena Corinthians"); ids.Add(13);
            datas.Add(new DateTime(2019, 6, 22, 16, 0, 0, 0)); estadios.Add("Mineirão"); ids.Add(14);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "A", nomeFase, grupoA.ToList<string>(), datas, estadios, ids));

            string[] grupoB = { "Argentina", "Colômbia", "Paraguai", "Catar" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2019, 6, 15, 19, 0, 0, 0)); estadios.Add("Fonte Nova"); ids.Add(3);
            datas.Add(new DateTime(2019, 6, 16, 16, 0, 0, 0)); estadios.Add("Maracanã"); ids.Add(4);
            datas.Add(new DateTime(2019, 6, 19, 18, 30, 0, 0)); estadios.Add("Morumbi"); ids.Add(9);
            datas.Add(new DateTime(2019, 6, 19, 21, 30, 0, 0)); estadios.Add("Mineirão"); ids.Add(10);
            datas.Add(new DateTime(2019, 6, 23, 16, 0, 0, 0)); estadios.Add("Arena do Grêmio"); ids.Add(15);
            datas.Add(new DateTime(2019, 6, 23, 16, 0, 0, 0)); estadios.Add("Fonte Nova"); ids.Add(16);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "B", nomeFase, grupoB.ToList<string>(), datas, estadios, ids));

            string[] grupoC = { "Uruguai", "Equador", "Japão", "Chile" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2019, 6, 16, 19, 0, 0, 0)); estadios.Add("Mineirão"); ids.Add(5);
            datas.Add(new DateTime(2019, 6, 17, 20, 0, 0, 0)); estadios.Add("Morumbi"); ids.Add(6);
            datas.Add(new DateTime(2019, 6, 20, 20, 0, 0, 0)); estadios.Add("Arena do Grêmio"); ids.Add(11);
            datas.Add(new DateTime(2019, 6, 21, 20, 0, 0, 0)); estadios.Add("Fonte Nova"); ids.Add(12);
            datas.Add(new DateTime(2019, 6, 24, 20, 0, 0, 0)); estadios.Add("Maracanâ"); ids.Add(17);
            datas.Add(new DateTime(2019, 6, 24, 20, 0, 0, 0)); estadios.Add("Mineirão"); ids.Add(18);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "C", nomeFase, grupoC.ToList<string>(), datas, estadios, ids));
             
            return list;
        }
        public IList<Entities.Campeonatos.Jogo> GetOitavasFinal()
        {
            return new List<Entities.Campeonatos.Jogo>();
        }
        public IList<Entities.Campeonatos.Jogo> GetQuartasFinal()
        {
            string nomeFase = FaseQuartasFinal;
            IList<DateTime> datas = new List<DateTime>();
            IList<int> ids = new List<int>();
            IList<int> idsGanhadores = new List<int>();
            IList<string> estadios = new List<string>();


            datas.Add(new DateTime(2019, 6, 27, 21, 30, 0, 0)); estadios.Add("Arena do Grêmio"); ids.Add(19); 
            datas.Add(new DateTime(2019, 6, 28, 16, 0, 0, 0)); estadios.Add("Maracanã"); ids.Add(20);
            datas.Add(new DateTime(2019, 6, 28, 20, 0, 0, 0)); estadios.Add("Arena Corinthians"); ids.Add(21);
            datas.Add(new DateTime(2019, 6, 29, 16, 0, 0, 0)); estadios.Add("Fonte Nova"); ids.Add(22);


            int rodada = 4;
            string nomeGrupo = " ";


            //IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();
            //int c = 0;
            //int l = 0;

            //list.Add(CreateJogo(nomeCampeonato, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "A", 1, "B", 2, true, null));
            //c++;
            //list.Add(CreateJogo(nomeCampeonato, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "C", 1, "D", 2, true, null));
            //c++;
            //list.Add(CreateJogo(nomeCampeonato, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "B", 1, "A", 2, true, null));
            //c++;
            //list.Add(CreateJogo(nomeCampeonato, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "D", 1, "C", 2, true, null));

     

            //string nomeGrupo = " ";

            return this.GetJogosQuartas(base.Campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids, idsGanhadores);

            //return list;
        }
        public IList<Entities.Campeonatos.Jogo> GetSemiFinal()
        {
            string nomeFase = FaseSemiFinal;
            IList<DateTime> datas = new List<DateTime>();
            IList<int> ids = new List<int>();
            IList<int> idsGanhadores = new List<int>();
            IList<string> estadios = new List<string>();

            datas.Add(new DateTime(2019, 7, 2, 21,30, 0, 0)); estadios.Add("Mineirão"); ids.Add(23);
            idsGanhadores.Add(19); idsGanhadores.Add(20);
            datas.Add(new DateTime(2019, 7, 3, 21, 30, 0, 0)); estadios.Add("Arena do Grêmio"); ids.Add(24);
            idsGanhadores.Add(21); idsGanhadores.Add(22);


            int rodada = 5;
            string nomeGrupo = " ";

            return base.GetJogosSemi(base.Campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids, idsGanhadores);
        }
        public IList<Entities.Campeonatos.Jogo> GetFinal()
        {
            string nomeFase = FaseFinal;
            IList<DateTime> datas = new List<DateTime>();
            IList<int> ids = new List<int>();
            IList<int> idsGanhadores = new List<int>();
            IList<string> estadios = new List<string>();

            datas.Add(new DateTime(2019, 7, 6, 16, 0, 0, 0)); estadios.Add("Arena Corinthians"); ids.Add(25);
            idsGanhadores.Add(23); idsGanhadores.Add(24);
            datas.Add(new DateTime(2019, 7, 7, 17, 0, 0, 0)); estadios.Add("Maracanã"); ids.Add(26);
            idsGanhadores.Add(23); idsGanhadores.Add(24);


            int rodada = 6;
            string nomeGrupo = " ";

            return base.GetJogosFinal(base.Campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids, idsGanhadores);
        }
        public bool InsertResults(string nomeCampeonato, Entities.Users.User validatedBy)
        {
            IList<int> jogoLabels = new List<int>();
            IList<int> time1 = new List<int>();
            IList<int> time2 = new List<int>();
            IList<int?> penaltis1 = new List<int?>();
            IList<int?> penaltis2 = new List<int?>();

            base.Campeonato = new Entities.Campeonatos.Campeonato(nomeCampeonato);

            #region Resultados dos Jogos
             


            for (int c = 0; c < jogoLabels.Count; c++)
            {
                base.InsertResult(base.Campeonato, jogoLabels[c], true, validatedBy, time1[c], time2[c], penaltis1[c], penaltis2[c]);
            }

            #endregion


            return true;
        }
        public IList<Entities.Campeonatos.CampeonatoPosicao> GetCampeonatoPosicoes()
        {
            throw new NotImplementedException();
        }
        public override IList<Entities.Campeonatos.Jogo> GetJogosGrupo(Entities.Campeonatos.Campeonato campeonato, string nomeGrupo, string nomeFase, IList<string> times, IList<DateTime> datas, IList<string> estadios, IList<int> ids)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");
            if (string.IsNullOrEmpty(nomeGrupo))
                throw new ArgumentException("nomeGrupo");
            if (string.IsNullOrEmpty(nomeFase))
                throw new ArgumentException("nomeFase");
            if (times == null)
                throw new ArgumentException("times");
            if (datas == null)
                throw new ArgumentException("datas");
            if (estadios == null)
                throw new ArgumentException("estadios");
            if (ids == null)
                throw new ArgumentException("ids");
            if (times.Count != 4)
                throw new ArgumentException("times.Count != 4");
            if (estadios.Count != 6)
                throw new ArgumentException("estadios.Count != 6");
            if (ids.Count != 6)
                throw new ArgumentException("ids.Count != 6");
            if (datas.Count != 6)
                throw new ArgumentException("datas.Count != 6");


            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            int c = 0;
            int rodada = 1;

            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, times[0], times[1], rodada, ids[0], false));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, times[2], times[3], rodada, ids[1], false));
            c++;
            rodada++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, times[1], times[3], rodada, ids[2], false));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, times[0], times[2], rodada, ids[3], false));
            c++;
            rodada++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, times[3], times[0], rodada, ids[4], false));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, times[1], times[2], rodada, ids[5], false));

            return list;
        }
        public override IList<Entities.Campeonatos.Jogo> GetJogosQuartas(Entities.Campeonatos.Campeonato campeonato, int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids, IList<int> idsGanhadores)
        {
            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");
            if (string.IsNullOrEmpty(nomeGrupo))
                throw new ArgumentException("nomeGrupo");
            if (string.IsNullOrEmpty(nomeFase))
                throw new ArgumentException("nomeFase");
            if (datas == null)
                throw new ArgumentException("datas");
            if (estadios == null)
                throw new ArgumentException("estadios");
            if (ids == null)
                throw new ArgumentException("ids");
            if (estadios.Count != 4)
                throw new ArgumentException("estadios.Count != 4");
            if (ids.Count != 4)
                throw new ArgumentException("ids.Count != 4");
            if (datas.Count != 4)
                throw new ArgumentException("datas.Count != 4");
            if (idsGanhadores == null)
                throw new ArgumentException("idsGanhadores");

            //if (idsGanhadores.Count != 8)
            //    throw new ArgumentException("idsGanhadores.Count != 8");
            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            int c = 0; 
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "A", 1, "BC", 3, true, null, true));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "A", 2, "B", 2, true, null, null));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "B", 1, "C", 2, true, null, null));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "C", 1, "AB", 3, true, null, true));



              

            return list;

        }
        public override IList<Entities.Campeonatos.CampeonatoPosicao> GetCampeonatoPosicoes(Entities.Campeonatos.Campeonato campeonato, string nomeFase)
        {
            IList<Entities.Campeonatos.CampeonatoPosicao> list = new List<Entities.Campeonatos.CampeonatoPosicao>();

            list = Merge(list, CreateCampeonatoPosicao(campeonato, nomeFase, "A"));
            list = Merge(list, CreateCampeonatoPosicao(campeonato, nomeFase, "B"));
            list = Merge(list, CreateCampeonatoPosicao(campeonato, nomeFase, "C"));

            return list;
        }
        #endregion

    }
}
