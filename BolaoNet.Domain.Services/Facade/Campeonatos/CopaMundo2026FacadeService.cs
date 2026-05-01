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


            // GRUPO A
            string[] grupoA = { "México", "Coreia do Sul", "África do Sul", "República Tcheca" };

            // GRUPO B
            string[] grupoB = { "Canadá", "Suíça", "Catar", "Bósnia Herzegovina" };

            // GRUPO C
            string[] grupoC = { "Brasil", "Marrocos", "Escócia", "Haiti" };

            // GRUPO D
            string[] grupoD = { "Estados Unidos", "Paraguai", "Turquia", "Austrália" };

            // GRUPO E
            string[] grupoE = { "Alemanha", "Equador", "Costa do Marfim", "Curaçao" };

            // GRUPO F
            string[] grupoF = { "Holanda", "Japão", "Suécia", "Tunísia" };

            // GRUPO G
            string[] grupoG = { "Bélgica", "Egito", "Irã", "Nova Zelândia" };

            // GRUPO H
            string[] grupoH = { "Espanha", "Uruguai", "Arábia Saudita", "Cabo Verde" };

            // GRUPO I
            string[] grupoI = { "França", "Senegal", "Noruega", "Iraque" };

            // GRUPO J
            string[] grupoJ = { "Argentina", "Áustria", "Argélia", "Jordânia" };

            // GRUPO K
            string[] grupoK = { "Portugal", "Colômbia", "Uzbequistão", "RD Congo" };

            // GRUPO L
            string[] grupoL = { "Inglaterra", "Croácia", "Gana", "Panamá" };



            // =====================================================
            // GRUPO A
            // =====================================================

            // Rodada 1
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 11, 16, 0, 0), "Cidade do México", nomeFase, "A", grupoA[0], grupoA[2], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 11, 23, 0, 0), "Guadalajara", nomeFase, "A", grupoA[1], grupoA[3], 1, jogoId++, false));

            // Rodada 2
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 18, 13, 0, 0), "Atlanta", nomeFase, "A", grupoA[3], grupoA[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 18, 22, 0, 0), "Guadalajara", nomeFase, "A", grupoA[0], grupoA[1], 2, jogoId++, false));

            // Rodada 3
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 24, 22, 0, 0), "Cidade do México", nomeFase, "A", grupoA[3], grupoA[0], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 24, 22, 0, 0), "Monterrey", nomeFase, "A", grupoA[2], grupoA[1], 3, jogoId++, false));


            // =====================================================
            // GRUPO B
            // =====================================================

            // Rodada 1
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 12, 16, 0, 0), "Toronto", nomeFase, "B", grupoB[0], grupoB[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 13, 16, 0, 0), "San Francisco", nomeFase, "B", grupoB[2], grupoB[1], 1, jogoId++, false));

            // Rodada 2
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 18, 16, 0, 0), "Los Angeles", nomeFase, "B", grupoB[1], grupoB[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 18, 19, 0, 0), "Vancouver", nomeFase, "B", grupoB[0], grupoB[2], 2, jogoId++, false));

            // Rodada 3
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 24, 16, 0, 0), "Vancouver", nomeFase, "B", grupoB[1], grupoB[0], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 24, 16, 0, 0), "Seattle", nomeFase, "B", grupoB[3], grupoB[2], 3, jogoId++, false));


            // =====================================================
            // GRUPO C
            // =====================================================

            // Rodada 1
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 13, 19, 0, 0), "Nova York", nomeFase, "C", grupoC[0], grupoC[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 13, 22, 0, 0), "Boston", nomeFase, "C", grupoC[3], grupoC[2], 1, jogoId++, false));

            // Rodada 2
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 19, 19, 0, 0), "Boston", nomeFase, "C", grupoC[2], grupoC[1], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 19, 21, 30, 0), "Filadélfia", nomeFase, "C", grupoC[0], grupoC[3], 2, jogoId++, false));

            // Rodada 3
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 24, 19, 0, 0), "Miami", nomeFase, "C", grupoC[2], grupoC[0], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 24, 19, 0, 0), "Atlanta", nomeFase, "C", grupoC[1], grupoC[3], 3, jogoId++, false));


            // =====================================================
            // GRUPO D
            // =====================================================

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 12, 22, 0, 0), "Los Angeles", nomeFase, "D", grupoD[0], grupoD[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 13, 1, 0, 0), "Vancouver", nomeFase, "D", grupoD[3], grupoD[2], 1, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 19, 0, 0, 0), "San Francisco", nomeFase, "D", grupoD[2], grupoD[1], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 19, 16, 0, 0), "Seattle", nomeFase, "D", grupoD[0], grupoD[3], 2, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 25, 23, 0, 0), "Los Angeles", nomeFase, "D", grupoD[2], grupoD[0], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 25, 23, 0, 0), "San Francisco", nomeFase, "D", grupoD[1], grupoD[3], 3, jogoId++, false));


            // =====================================================
            // GRUPO E
            // =====================================================

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 14, 14, 0, 0), "Houston", nomeFase, "E", grupoE[0], grupoE[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 14, 20, 0, 0), "Filadélfia", nomeFase, "E", grupoE[2], grupoE[1], 1, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 20, 17, 0, 0), "Toronto", nomeFase, "E", grupoE[0], grupoE[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 20, 21, 0, 0), "Kansas City", nomeFase, "E", grupoE[1], grupoE[3], 2, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 25, 17, 0, 0), "Nova York", nomeFase, "E", grupoE[1], grupoE[0], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 25, 17, 0, 0), "Filadélfia", nomeFase, "E", grupoE[3], grupoE[2], 3, jogoId++, false));


            // =====================================================
            // GRUPO F
            // =====================================================

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 14, 17, 0, 0), "Dallas", nomeFase, "F", grupoF[0], grupoF[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 14, 23, 0, 0), "Monterrey", nomeFase, "F", grupoF[2], grupoF[3], 1, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 20, 14, 0, 0), "Houston", nomeFase, "F", grupoF[0], grupoF[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 21, 1, 0, 0), "Monterrey", nomeFase, "F", grupoF[3], grupoF[1], 2, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 25, 20, 0, 0), "Dallas", nomeFase, "F", grupoF[1], grupoF[2], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 25, 20, 0, 0), "Kansas City", nomeFase, "F", grupoF[3], grupoF[0], 3, jogoId++, false));


            // =====================================================
            // GRUPO G
            // =====================================================

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 15, 16, 0, 0), "Seattle", nomeFase, "G", grupoG[0], grupoG[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 15, 22, 0, 0), "Los Angeles", nomeFase, "G", grupoG[2], grupoG[3], 1, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 21, 16, 0, 0), "Los Angeles", nomeFase, "G", grupoG[0], grupoG[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 21, 22, 0, 0), "Vancouver", nomeFase, "G", grupoG[3], grupoG[1], 2, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 26, 0, 0, 0), "Seattle", nomeFase, "G", grupoG[1], grupoG[2], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 26, 0, 0, 0), "Vancouver", nomeFase, "G", grupoG[3], grupoG[0], 3, jogoId++, false));


            // =====================================================
            // GRUPO H
            // =====================================================

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 15, 13, 0, 0), "Atlanta", nomeFase, "H", grupoH[0], grupoH[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 15, 19, 0, 0), "Miami", nomeFase, "H", grupoH[2], grupoH[1], 1, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 21, 13, 0, 0), "Atlanta", nomeFase, "H", grupoH[0], grupoH[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 21, 19, 0, 0), "Miami", nomeFase, "H", grupoH[1], grupoH[3], 2, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 26, 21, 0, 0), "Houston", nomeFase, "H", grupoH[3], grupoH[2], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 26, 21, 0, 0), "Guadalajara", nomeFase, "H", grupoH[1], grupoH[0], 3, jogoId++, false));


            // =====================================================
            // GRUPO I
            // =====================================================

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 16, 16, 0, 0), "Nova York", nomeFase, "I", grupoI[0], grupoI[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 16, 19, 0, 0), "Boston", nomeFase, "I", grupoI[3], grupoI[2], 1, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 22, 18, 0, 0), "Filadélfia", nomeFase, "I", grupoI[0], grupoI[3], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 22, 21, 0, 0), "Nova York", nomeFase, "I", grupoI[2], grupoI[1], 2, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 26, 16, 0, 0), "Boston", nomeFase, "I", grupoI[2], grupoI[0], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 26, 16, 0, 0), "Toronto", nomeFase, "I", grupoI[1], grupoI[3], 3, jogoId++, false));


            // =====================================================
            // GRUPO J
            // =====================================================

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 16, 22, 0, 0), "Kansas City", nomeFase, "J", grupoJ[0], grupoJ[2], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 17, 1, 0, 0), "San Francisco", nomeFase, "J", grupoJ[1], grupoJ[3], 1, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 22, 14, 0, 0), "Dallas", nomeFase, "J", grupoJ[0], grupoJ[1], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 23, 0, 0, 0), "San Francisco", nomeFase, "J", grupoJ[3], grupoJ[2], 2, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 27, 23, 0, 0), "Dallas", nomeFase, "J", grupoJ[3], grupoJ[0], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 27, 23, 0, 0), "Kansas City", nomeFase, "J", grupoJ[2], grupoJ[1], 3, jogoId++, false));


            // =====================================================
            // GRUPO K
            // =====================================================

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 17, 14, 0, 0), "Houston", nomeFase, "K", grupoK[0], grupoK[3], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 17, 23, 0, 0), "Cidade do México", nomeFase, "K", grupoK[2], grupoK[1], 1, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 23, 14, 0, 0), "Houston", nomeFase, "K", grupoK[0], grupoK[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 23, 23, 0, 0), "Guadalajara", nomeFase, "K", grupoK[1], grupoK[3], 2, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 27, 20, 30, 0), "Miami", nomeFase, "K", grupoK[1], grupoK[0], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 27, 20, 30, 0), "Atlanta", nomeFase, "K", grupoK[3], grupoK[2], 3, jogoId++, false));


            // =====================================================
            // GRUPO L
            // =====================================================

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 17, 17, 0, 0), "Dallas", nomeFase, "L", grupoL[0], grupoL[1], 1, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 17, 20, 0, 0), "Toronto", nomeFase, "L", grupoL[2], grupoL[3], 1, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 23, 17, 0, 0), "Boston", nomeFase, "L", grupoL[0], grupoL[2], 2, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 23, 20, 0, 0), "Toronto", nomeFase, "L", grupoL[3], grupoL[1], 2, jogoId++, false));

            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 27, 18, 0, 0), "Nova York", nomeFase, "L", grupoL[3], grupoL[0], 3, jogoId++, false));
            list.Add(CreateJogo(campeonatoNome, new DateTime(2026, 6, 27, 18, 0, 0), "Filadélfia", nomeFase, "L", grupoL[1], grupoL[2], 3, jogoId++, false));
             
            return list;
        }

        public IList<Entities.Campeonatos.Jogo> GetDezesseisAvosFinal()
        {
            string nomeFase = FaseDezesseisAvosFinal;
            int rodada = 4;
            string nomeGrupo = " ";
             
            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            // =========================
            // 28/06
            // =========================
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 6, 28, 16, 0, 0), "Los Angeles", nomeFase, nomeGrupo, rodada, 73, "A", 2, "B", 2, true, null, null));

            // =========================
            // 29/06
            // =========================
            //list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 6, 29, 17, 30, 0), "Boston", nomeFase, nomeGrupo, rodada, 74, "E", 1, "ABCDF", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 6, 29, 17, 30, 0), "Boston", nomeFase, nomeGrupo, rodada, 74, "E", 1, "X", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 6, 29, 22, 0, 0), "Monterrey", nomeFase, nomeGrupo, rodada, 75, "F", 1, "C", 2, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 6, 29, 14, 0, 0), "Houston", nomeFase, nomeGrupo, rodada, 76, "C", 1, "F", 2, true, null, null));

            // =========================
            // 30/06
            // =========================
            //list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 6, 30, 18, 0, 0), "NY/New Jersey", nomeFase, nomeGrupo, rodada, 77, "I", 1, "CDFGH", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 6, 30, 18, 0, 0), "NY/New Jersey", nomeFase, nomeGrupo, rodada, 77, "I", 1, "X", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 6, 30, 14, 0, 0), "Dallas", nomeFase, nomeGrupo, rodada, 78, "E", 2, "I", 2, true, null, null));
            //list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 6, 30, 22, 0, 0), "Cidade do México", nomeFase, nomeGrupo, rodada, 79, "A", 1, "CEFHI", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 6, 30, 22, 0, 0), "Cidade do México", nomeFase, nomeGrupo, rodada, 79, "A", 1, "X", 3, true, null, null));

            // =========================
            // 01/07
            // =========================
            //list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 1, 13, 0, 0), "Atlanta", nomeFase, nomeGrupo, rodada, 80, "L", 1, "EHIJK", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 1, 13, 0, 0), "Atlanta", nomeFase, nomeGrupo, rodada, 80, "L", 1, "X", 3, true, null, null));
            //list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 1, 21, 0, 0), "San Francisco", nomeFase, nomeGrupo, rodada, 81, "D", 1, "BEFIJ", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 1, 21, 0, 0), "San Francisco", nomeFase, nomeGrupo, rodada, 81, "D", 1, "X", 3, true, null, null));
            //list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 1, 17, 0, 0), "Seattle", nomeFase, nomeGrupo, rodada, 82, "G", 1, "AEHIJ", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 1, 17, 0, 0), "Seattle", nomeFase, nomeGrupo, rodada, 82, "G", 1, "X", 3, true, null, null));

            // =========================
            // 02/07
            // =========================
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 2, 20, 0, 0), "Toronto", nomeFase, nomeGrupo, rodada, 83, "K", 2, "L", 2, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 2, 16, 0, 0), "Los Angeles", nomeFase, nomeGrupo, rodada, 84, "H", 1, "J", 2, true, null, null));
            //list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 2, 0, 0, 0), "Vancouver", nomeFase, nomeGrupo, rodada, 85, "B", 1, "EFGIJ", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 2, 0, 0, 0), "Vancouver", nomeFase, nomeGrupo, rodada, 85, "B", 1, "X", 3, true, null, null));

            // =========================
            // 03/07
            // =========================
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 3, 19, 0, 0), "Miami", nomeFase, nomeGrupo, rodada, 86, "J", 1, "H", 2, true, null, null));
            //list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 3, 22, 30, 0), "Kansas City", nomeFase, nomeGrupo, rodada, 87, "K", 1, "DEIJL", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 3, 22, 30, 0), "Kansas City", nomeFase, nomeGrupo, rodada, 87, "K", 1, "X", 3, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 3, 15, 0, 0), "Dallas", nomeFase, nomeGrupo, rodada, 88, "D", 2, "G", 2, true, null, null));
                         
            return list;
        }

        public IList<Entities.Campeonatos.Jogo> GetOitavasFinal()
        {
            string nomeFase = FaseOitavasFinal;
            int rodada = 5;
            string nomeGrupo = " ";

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            // =========================
            // Sábado, 04/07/2026
            // =========================
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 4, 18, 0, 0), "Filadélfia", nomeFase, nomeGrupo, rodada, 89, 74, true, 77, true, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 4, 14, 0, 0), "Houston", nomeFase, nomeGrupo, rodada, 90, 73, true, 75, true, true));

            // =========================
            // Domingo, 05/07/2026
            // =========================
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 5, 17, 0, 0), "NY/New Jersey", nomeFase, nomeGrupo, rodada, 91, 76, true, 78, true, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 5, 21, 0, 0), "Cidade do México", nomeFase, nomeGrupo, rodada, 92, 79, true, 80, true, true));

            // =========================
            // Segunda-feira, 06/07/2026
            // =========================
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 6, 16, 0, 0), "Dallas", nomeFase, nomeGrupo, rodada, 93, 83, true, 84, true, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 6, 21, 0, 0), "Seattle", nomeFase, nomeGrupo, rodada, 94, 81, true, 82, true, true));

            // =========================
            // Terça-feira, 07/07/2026
            // =========================
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 7, 13, 0, 0), "Atlanta", nomeFase, nomeGrupo, rodada, 95, 86, true, 88, true, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 7, 17, 0, 0), "Vancouver", nomeFase, nomeGrupo, rodada, 96, 85, true, 87, true, true));

            return list;
        }

        public IList<Entities.Campeonatos.Jogo> GetQuartasFinal()
        {
            string nomeFase = FaseQuartasFinal;
            int rodada = 6;
            string nomeGrupo = " ";

            return new List<Entities.Campeonatos.Jogo>
            {
                // =========================
                // Quinta-feira, 09/07/2026
                // =========================
                CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 9, 17, 0, 0), "Boston",
                    nomeFase, nomeGrupo, rodada, 97, 90, true, 89, true, true),

                // =========================
                // Sexta-feira, 10/07/2026
                // =========================
                CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 10, 16, 0, 0), "Los Angeles",
                    nomeFase, nomeGrupo, rodada, 98, 93, true, 94, true, true),

                // =========================
                // Sábado, 11/07/2026
                // =========================
                CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 11, 18, 0, 0), "Miami",
                    nomeFase, nomeGrupo, rodada, 99, 91, true, 92, true, true),

                CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 11, 22, 0, 0), "Kansas City",
                    nomeFase, nomeGrupo, rodada, 100, 95, true, 96, true, true)
            };
        }

        public IList<Entities.Campeonatos.Jogo> GetSemiFinal()
        {
            string nomeFase = FaseSemiFinal;
            int rodada = 7;
            string nomeGrupo = " ";

            return new List<Entities.Campeonatos.Jogo>
            {
                // =========================
                // Terça-feira, 14/07/2026
                // =========================
                CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 14, 16, 0, 0), "Dallas",
                    nomeFase, nomeGrupo, rodada, 101, 97, true, 99, true, true),

                // =========================
                // Quarta-feira, 15/07/2026
                // =========================
                CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 15, 16, 0, 0), "Atlanta",
                    nomeFase, nomeGrupo, rodada, 102, 98, true, 100, true, true)
            };
        }

        public IList<Entities.Campeonatos.Jogo> GetFinal()
        {
            string nomeFase = FaseFinal;
            int rodada = 8;
            string nomeGrupo = " ";

            return new List<Entities.Campeonatos.Jogo>
            {
                // =========================
                // Sábado, 18/07/2026 - 3º lugar
                // =========================
                CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 18, 18, 0, 0), "Miami",
                    nomeFase, nomeGrupo, rodada, 103, 101, false, 102, false, true),

                // =========================
                // Domingo, 19/07/2026 - Final
                // =========================
                CreateJogo(base.Campeonato.Nome, new DateTime(2026, 7, 19, 16, 0, 0), "NY/New Jersey",
                    nomeFase, nomeGrupo, rodada, 104, 101, true, 102, true, true)
            };
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