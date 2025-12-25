using System;
using System.Collections.Generic;
using System.Linq;

namespace BolaoNet.Domain.Services.Facade.Campeonatos
{
    public class CopaMundo2026FacadeService : BaseStructureCopaMundoFacadeService, 
        Domain.Interfaces.Services.Facade.Campeonatos.ICopaMundo2026FacadeService
    {
        #region Constants

        public const string Name = "Copa do Mundo 2026";

        #endregion

        #region Properties

        public bool IsContainsResults { get { return false; } }

        #endregion

        #region Constructors/Destructors

        public CopaMundo2026FacadeService(
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
                TipoCampeonato = (int)Entities.Campeonatos.Campeonato.Tipos.CopaDoMundo
            };

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            StoreData<Entities.Campeonatos.Campeonato>(_campeonatoService, campeonato);


            base.Campeonato = _campeonatoService.Load(campeonato);

            list = base.Merge(list, GetJogosGrupo());
            list = base.Merge(list, GetDezesseisAvosFinal());
            list = base.Merge(list, GetOitavasFinal());
            list = base.Merge(list, GetQuartasFinal());
            list = base.Merge(list, GetSemiFinal());
            list = base.Merge(list, GetFinal());

            for (int c = 0; c < list.Count; c++)
            {
                base.InsertAllJogoInformation(campeonato.IsClube, campeonato, list[c]);
            }

            string nomeFase = FaseClassificatoria;
            IList<Entities.Campeonatos.CampeonatoPosicao> listPosicao = base.GetCampeonatoPosicoes(campeonato, nomeFase);

            for (int c = 0; c < listPosicao.Count; c++)
            {
                StoreData<Entities.Campeonatos.CampeonatoPosicao>(_campeonatoPosicaoService, listPosicao[c]);
            }

            CreateHistorico(base.Campeonato.Nome);

            return campeonato;
        }

        public IList<Entities.Campeonatos.Jogo> GetJogosGrupo()
        {
            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            string nomeFase = FaseClassificatoria;
            string campeonatoNome = base.Campeonato.Nome;

            int jogoId = 1;

            // =========================
            // GRUPO A
            // =========================
            string[] grupoA = { "Estados Unidos", "México", "Japão", "Nigéria" };
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 11, 18, 0, 0), "Los Angeles", nomeFase, "A", grupoA[0], grupoA[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 11, 21, 0, 0), "Dallas", nomeFase, "A", grupoA[2], grupoA[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 15, 18, 0, 0), "Dallas", nomeFase, "A", grupoA[0], grupoA[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 15, 21, 0, 0), "Los Angeles", nomeFase, "A", grupoA[1], grupoA[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 19, 21, 0, 0), "Los Angeles", nomeFase, "A", grupoA[0], grupoA[3], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 19, 21, 0, 0), "Dallas", nomeFase, "A", grupoA[1], grupoA[2], 3, jogoId++, false));

            // =========================
            // GRUPO B
            // =========================
            string[] grupoB = { "Brasil", "Coreia do Sul", "Canadá", "Marrocos" };
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 12, 18, 0, 0), "Toronto", nomeFase, "B", grupoB[0], grupoB[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 12, 21, 0, 0), "Vancouver", nomeFase, "B", grupoB[2], grupoB[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 16, 18, 0, 0), "Toronto", nomeFase, "B", grupoB[0], grupoB[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 16, 21, 0, 0), "Vancouver", nomeFase, "B", grupoB[1], grupoB[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 20, 21, 0, 0), "Toronto", nomeFase, "B", grupoB[0], grupoB[3], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 20, 21, 0, 0), "Vancouver", nomeFase, "B", grupoB[2], grupoB[1], 3, jogoId++, false));

            // =========================
            // GRUPO C
            // =========================
            string[] grupoC = { "Argentina", "Polônia", "Egito", "Austrália" };
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 13, 18, 0, 0), "Miami", nomeFase, "C", grupoC[0], grupoC[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 13, 21, 0, 0), "Atlanta", nomeFase, "C", grupoC[2], grupoC[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 17, 18, 0, 0), "Miami", nomeFase, "C", grupoC[0], grupoC[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 17, 21, 0, 0), "Atlanta", nomeFase, "C", grupoC[1], grupoC[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 21, 21, 0, 0), "Miami", nomeFase, "C", grupoC[0], grupoC[3], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 21, 21, 0, 0), "Atlanta", nomeFase, "C", grupoC[1], grupoC[2], 3, jogoId++, false));

            // =========================
            // GRUPOS D
            // =========================
            string[] grupoD = { "França", "Tunísia", "Peru", "Dinamarca" };
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 14, 18, 0, 0), "Houston", nomeFase, "D", grupoD[0], grupoD[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 14, 21, 0, 0), "Monterrey", nomeFase, "D", grupoD[2], grupoD[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 18, 18, 0, 0), "Houston", nomeFase, "D", grupoD[0], grupoD[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 18, 21, 0, 0), "Monterrey", nomeFase, "D", grupoD[1], grupoD[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 22, 21, 0, 0), "Houston", nomeFase, "D", grupoD[0], grupoD[3], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 22, 21, 0, 0), "Monterrey", nomeFase, "D", grupoD[1], grupoD[2], 3, jogoId++, false));

            // =========================
            // GRUPOS E
            // =========================
            string[] grupoE = { "Espanha", "Japão", "Chile", "Irã" };
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 15, 18, 0, 0), "Seattle", nomeFase, "E", grupoE[0], grupoE[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 15, 21, 0, 0), "San Francisco", nomeFase, "E", grupoE[2], grupoE[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 19, 18, 0, 0), "Seattle", nomeFase, "E", grupoE[0], grupoE[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 19, 21, 0, 0), "San Francisco", nomeFase, "E", grupoE[1], grupoE[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 23, 21, 0, 0), "Seattle", nomeFase, "E", grupoE[0], grupoE[3], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 23, 21, 0, 0), "San Francisco", nomeFase, "E", grupoE[1], grupoE[2], 3, jogoId++, false));

            // =========================
            // GRUPOS F
            // =========================
            string[] grupoF = { "Alemanha", "Canadá", "Nigéria", "Arábia Saudita" };
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 16, 18, 0, 0), "Chicago", nomeFase, "F", grupoF[0], grupoF[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 16, 21, 0, 0), "Detroit", nomeFase, "F", grupoF[2], grupoF[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 20, 18, 0, 0), "Chicago", nomeFase, "F", grupoF[0], grupoF[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 20, 21, 0, 0), "Detroit", nomeFase, "F", grupoF[1], grupoF[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 24, 21, 0, 0), "Chicago", nomeFase, "F", grupoF[0], grupoF[3], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 24, 21, 0, 0), "Detroit", nomeFase, "F", grupoF[1], grupoF[2], 3, jogoId++, false));

            // =========================
            // GRUPOS G
            // =========================
            string[] grupoG = { "Inglaterra", "Gana", "Sérvia", "Coreia do Sul" };
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 17, 18, 0, 0), "Boston", nomeFase, "G", grupoG[0], grupoG[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 17, 21, 0, 0), "New York", nomeFase, "G", grupoG[2], grupoG[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 21, 18, 0, 0), "Boston", nomeFase, "G", grupoG[0], grupoG[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 21, 21, 0, 0), "New York", nomeFase, "G", grupoG[1], grupoG[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 25, 21, 0, 0), "Boston", nomeFase, "G", grupoG[0], grupoG[3], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 25, 21, 0, 0), "New York", nomeFase, "G", grupoG[1], grupoG[2], 3, jogoId++, false));

            // =========================
            // GRUPOS H
            // =========================
            string[] grupoH = { "Portugal", "Uruguai", "Camarões", "Austrália" };
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 18, 18, 0, 0), "Philadelphia", nomeFase, "H", grupoH[0], grupoH[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 18, 21, 0, 0), "Washington", nomeFase, "H", grupoH[2], grupoH[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 22, 18, 0, 0), "Philadelphia", nomeFase, "H", grupoH[0], grupoH[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 22, 21, 0, 0), "Washington", nomeFase, "H", grupoH[1], grupoH[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 26, 21, 0, 0), "Philadelphia", nomeFase, "H", grupoH[0], grupoH[3], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 26, 21, 0, 0), "Washington", nomeFase, "H", grupoH[1], grupoH[2], 3, jogoId++, false));


            // =========================
            // GRUPOS I
            // =========================
            string[] grupoI = { "Itália", "México", "Egito", "Japão" };
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 19, 18, 0, 0), "Orlando", nomeFase, "I", grupoI[0], grupoI[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 19, 21, 0, 0), "Tampa", nomeFase, "I", grupoI[2], grupoI[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 23, 18, 0, 0), "Orlando", nomeFase, "I", grupoI[0], grupoI[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 23, 21, 0, 0), "Tampa", nomeFase, "I", grupoI[1], grupoI[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 27, 21, 0, 0), "Orlando", nomeFase, "I", grupoI[0], grupoI[3], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 27, 21, 0, 0), "Tampa", nomeFase, "I", grupoI[1], grupoI[2], 3, jogoId++, false));

            // =========================
            // GRUPOS J
            // =========================
            string[] grupoJ = { "Holanda", "Colômbia", "Gales", "Tunísia" };
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 20, 18, 0, 0), "Denver", nomeFase, "J", grupoJ[0], grupoJ[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 20, 21, 0, 0), "Kansas City", nomeFase, "J", grupoJ[2], grupoJ[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 24, 18, 0, 0), "Denver", nomeFase, "J", grupoJ[0], grupoJ[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 24, 21, 0, 0), "Kansas City", nomeFase, "J", grupoJ[1], grupoJ[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 28, 21, 0, 0), "Denver", nomeFase, "J", grupoJ[0], grupoJ[3], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 28, 21, 0, 0), "Kansas City", nomeFase, "J", grupoJ[1], grupoJ[2], 3, jogoId++, false));

            // =========================
            // GRUPOS K
            // =========================
            string[] grupoK = { "Bélgica", "Suíça", "Costa Rica", "Uzbequistão" };
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 21, 18, 0, 0), "Phoenix", nomeFase, "K", grupoK[0], grupoK[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 21, 21, 0, 0), "Glendale", nomeFase, "K", grupoK[2], grupoK[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 25, 18, 0, 0), "Phoenix", nomeFase, "K", grupoK[0], grupoK[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 25, 21, 0, 0), "Glendale", nomeFase, "K", grupoK[1], grupoK[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 29, 21, 0, 0), "Phoenix", nomeFase, "K", grupoK[0], grupoK[3], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 29, 21, 0, 0), "Glendale", nomeFase, "K", grupoK[1], grupoK[2], 3, jogoId++, false));

            // =========================
            // GRUPOS L
            // =========================
            string[] grupoL = { "Croácia", "Suécia", "Equador", "Nova Zelândia" };
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 22, 18, 0, 0), "Las Vegas", nomeFase, "L", grupoL[0], grupoL[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 22, 21, 0, 0), "San Diego", nomeFase, "L", grupoL[2], grupoL[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 26, 18, 0, 0), "Las Vegas", nomeFase, "L", grupoL[0], grupoL[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 26, 21, 0, 0), "San Diego", nomeFase, "L", grupoL[1], grupoL[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 30, 21, 0, 0), "Las Vegas", nomeFase, "L", grupoL[0], grupoL[3], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 30, 21, 0, 0), "San Diego", nomeFase, "L", grupoL[1], grupoL[2], 3, jogoId++, false));

            return list;
        }

        public IList<Entities.Campeonatos.Jogo> GetDezesseisAvosFinal()
        {
            string nomeFase = FaseDezesseisAvosFinal;
            int rodada = 4;
            string nomeGrupo = " ";

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 1, 12, 0, 0), "Dallas", nomeFase, nomeGrupo, rodada, 73, "A", 1, "B", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 1, 16, 0, 0), "Houston", nomeFase, nomeGrupo, rodada, 74, "C", 1, "D", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 2, 12, 0, 0), "Atlanta", nomeFase, nomeGrupo, rodada, 75, "E", 1, "F", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 2, 16, 0, 0), "Miami", nomeFase, nomeGrupo, rodada, 76, "G", 1, "H", 3, true, null, null));

            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 3, 12, 0, 0), "Los Angeles", nomeFase, nomeGrupo, rodada, 77, "I", 1, "J", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 3, 16, 0, 0), "Seattle", nomeFase, nomeGrupo, rodada, 78, "K", 1, "L", 3, true, null, null));

            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 4, 12, 0, 0), "Toronto", nomeFase, nomeGrupo, rodada, 79, "B", 2, "A", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 4, 16, 0, 0), "Vancouver", nomeFase, nomeGrupo, rodada, 80, "D", 2, "C", 3, true, null, null));

            return list;
        }
        public IList<Entities.Campeonatos.Jogo> GetOitavasFinal()
        {
            string nomeFase = FaseOitavasFinal;
            int rodada = 5;
            string nomeGrupo = " ";

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 6, 12, 0, 0), "Dallas", nomeFase, nomeGrupo, rodada, 81, 73, true, 74, true, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 6, 16, 0, 0), "Houston", nomeFase, nomeGrupo, rodada, 82, 75, true, 76, true, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 7, 12, 0, 0), "Atlanta", nomeFase, nomeGrupo, rodada, 83, 77, true, 78, true, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 7, 16, 0, 0), "Miami", nomeFase, nomeGrupo, rodada, 84, 79, true, 80, true, true));

            return list;
        }
        public IList<Entities.Campeonatos.Jogo> GetQuartasFinal()
        {
            string nomeFase = FaseQuartasFinal;
            int rodada = 6;
            string nomeGrupo = " ";

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 9, 12, 0, 0), "Los Angeles", nomeFase, nomeGrupo, rodada, 85, 81, true, 82, true, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 9, 16, 0, 0), "Seattle", nomeFase, nomeGrupo, rodada, 86, 83, true, 84, true, true));

            return list;
        }
        public IList<Entities.Campeonatos.Jogo> GetSemiFinal()
        {
            string nomeFase = FaseSemiFinal;
            int rodada = 7;
            string nomeGrupo = " ";

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 12, 16, 0, 0), "New York", nomeFase, nomeGrupo, rodada, 87, 85, true, 86, true, true));

            return list;
        }
        public IList<Entities.Campeonatos.Jogo> GetFinal()
        {
            string nomeFase = FaseFinal;
            int rodada = 8;
            string nomeGrupo = " ";

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            // Terceiro lugar
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 17, 12, 0, 0), "Miami", nomeFase, nomeGrupo, rodada, 88, 87, false, 87, false, true));

            // Final
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 18, 16, 0, 0), "New York", nomeFase, nomeGrupo, rodada, 89, 87, true, 87, true, true));

            return list;
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

            //Rodada 1
            //jogoLabels.Add(1); time1.Add(3); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(2); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(3); time1.Add(1); time2.Add(5); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(4); time1.Add(3); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(5); time1.Add(3); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(6); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(7); time1.Add(1); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(8); time1.Add(1); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(9); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(10); time1.Add(3); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(11); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(12); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(13); time1.Add(4); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(14); time1.Add(1); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(15); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(16); time1.Add(1); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);


            ////Rodada 2
            //jogoLabels.Add(17); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(18); time1.Add(0); time2.Add(4); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(19); time1.Add(2); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(20); time1.Add(0); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(21); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(22); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(23); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(24); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(25); time1.Add(2); time2.Add(5); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(26); time1.Add(1); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(27); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(28); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(29); time1.Add(2); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(30); time1.Add(2); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(31); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(32); time1.Add(2); time2.Add(4); penaltis1.Add(null); penaltis2.Add(null);

            ////Rodada 3
            //jogoLabels.Add(33); time1.Add(1); time2.Add(4); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(34); time1.Add(1); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(35); time1.Add(0); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(36); time1.Add(2); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(37); time1.Add(1); time2.Add(4); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(38); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(39); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(40); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(41); time1.Add(0); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(42); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(43); time1.Add(2); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(44); time1.Add(3); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(45); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(46); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(47); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(48); time1.Add(1); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);


            ////Oitavas
            //jogoLabels.Add(49); time1.Add(1); time2.Add(1); penaltis1.Add(3); penaltis2.Add(2);
            //jogoLabels.Add(50); time1.Add(2); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(51); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(52); time1.Add(1); time2.Add(1); penaltis1.Add(4); penaltis2.Add(3);
            //jogoLabels.Add(53); time1.Add(2); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(54); time1.Add(0); time2.Add(0); penaltis1.Add(2); penaltis2.Add(1);
            //jogoLabels.Add(55); time1.Add(0); time2.Add(0); penaltis1.Add(1); penaltis2.Add(0);
            //jogoLabels.Add(56); time1.Add(0); time2.Add(0); penaltis1.Add(2); penaltis2.Add(1);

            ////Quartas
            //jogoLabels.Add(57); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(58); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(59); time1.Add(0); time2.Add(0); penaltis1.Add(3); penaltis2.Add(2);
            //jogoLabels.Add(60); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);

            ////Semi
            //jogoLabels.Add(61); time1.Add(1); time2.Add(7); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(62); time1.Add(0); time2.Add(0); penaltis1.Add(2); penaltis2.Add(4);

            ////Final
            //jogoLabels.Add(63); time1.Add(3); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            //jogoLabels.Add(64); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);



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
        private void CreateHistorico(string campeonato)
        {
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1930,
                NomeTimeCampeao = "Uruguai",
                FinalTime1 = 4,
                FinalTime2 = 2,
                NomeTimeVice = "Argentina",
                Sede = "Uruguai"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1934,
                NomeTimeCampeao = "Itália",
                FinalTime1 = 2,
                FinalTime2 = 1,
                NomeTimeVice = "Tchecoslováquia",
                Sede = "Itália"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1938,
                NomeTimeCampeao = "Itália",
                FinalTime1 = 4,
                FinalTime2 = 2,
                NomeTimeVice = "Hungria",
                Sede = "França"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1950,
                NomeTimeCampeao = "Uruguai",
                FinalTime1 = 2,
                FinalTime2 = 1,
                NomeTimeVice = "Brasil",
                Sede = "Brasil"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1954,
                NomeTimeCampeao = "Alemanha",
                FinalTime1 = 3,
                FinalTime2 = 2,
                NomeTimeVice = "Hungria",
                Sede = "Suíça"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1958,
                NomeTimeCampeao = "Brasil",
                FinalTime1 = 5,
                FinalTime2 = 2,
                NomeTimeVice = "Suécia",
                Sede = "Suécia"
            }); 
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1962,
                NomeTimeCampeao = "Brasil",
                FinalTime1 = 3,
                FinalTime2 = 1,
                NomeTimeVice = "Tchecoslováquia",
                Sede = "Chile"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1966,
                NomeTimeCampeao = "Inglaterra",
                FinalTime1 = 4,
                FinalTime2 = 2,
                NomeTimeVice = "Alemanha",
                Sede = "Inglaterra"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1970,
                NomeTimeCampeao = "Brasil",
                FinalTime1 = 4,
                FinalTime2 = 1,
                NomeTimeVice = "Itália",
                Sede = "México"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1974,
                NomeTimeCampeao = "Alemanha",
                FinalTime1 = 2,
                FinalTime2 = 1,
                NomeTimeVice = "Holanda",
                Sede = "Alemanha"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1978,
                NomeTimeCampeao = "Argentina",
                FinalTime1 = 3,
                FinalTime2 = 1,
                NomeTimeVice = "Holanda",
                Sede = "Argentina"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1982,
                NomeTimeCampeao = "Itália",
                FinalTime1 = 3,
                FinalTime2 = 1,
                NomeTimeVice = "Alemanha",
                Sede = "Espanha"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1986,
                NomeTimeCampeao = "Argentina",
                FinalTime1 = 3,
                FinalTime2 = 2,
                NomeTimeVice = "Alemanha",
                Sede = "México"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1990,
                NomeTimeCampeao = "Alemanha",
                FinalTime1 = 1,
                FinalTime2 = 0,
                NomeTimeVice = "Argentina",
                Sede = "Itália"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1994,
                NomeTimeCampeao = "Brasil",
                FinalTime1 = 0,
                FinalTime2 = 0,
                FinalPenaltis1 = 3,
                FinalPenaltis2 = 2,
                NomeTimeVice = "Itália",
                Sede = "Estados Unidos"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 1998,
                NomeTimeCampeao = "França",
                FinalTime1 = 3,
                FinalTime2 = 0,
                NomeTimeVice = "Brasil",
                Sede = "França"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 2002,
                NomeTimeCampeao = "Brasil",
                FinalTime1 = 2,
                FinalTime2 = 0,
                NomeTimeVice = "Alemanha",
                Sede = "Japão"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 2006,
                NomeTimeCampeao = "Itália",
                FinalTime1 = 1,
                FinalTime2 = 1,
                FinalPenaltis1 = 5,
                FinalPenaltis2 = 2,
                NomeTimeVice = "França",
                Sede = "Alemanha"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 2010,
                NomeTimeCampeao = "Espanha",
                FinalTime1 = 1,
                FinalTime2 = 0,
                NomeTimeVice = "Holanda",
                Sede = "África do Sul"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 2014,
                NomeTimeCampeao = "Alemanha",
                FinalTime1 = 1,
                FinalTime2 = 0,
                NomeTimeVice = "Argentina",
                Sede = "Brasil"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 2018,
                NomeTimeCampeao = "França",
                FinalTime1 = 4,
                FinalTime2 = 2,
                NomeTimeVice = "Croácia",
                Sede = "Rússia"
            });
            StoreData<Entities.Campeonatos.CampeonatoHistorico>(_campeonatoHistoricoService, new Entities.Campeonatos.CampeonatoHistorico()
            {
                NomeCampeonato = campeonato,
                Ano = 2022,
                NomeTimeCampeao = "Argentina",
                FinalTime1 = 3,
                FinalTime2 = 3,
                NomeTimeVice = "França",
                Sede = "Catar"
            });
        }

        #endregion

    }
} 