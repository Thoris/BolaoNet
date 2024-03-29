﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BolaoNet.Domain.Services.Facade.Campeonatos
{
    public class CopaMundo2022FacadeService : BaseStructureCopaMundoFacadeService, 
        Domain.Interfaces.Services.Facade.Campeonatos.ICopaMundo2022FacadeService
    {
        #region Constants

        public const string Name = "Copa do Mundo 2022";

        #endregion

        #region Properties

        public bool IsContainsResults { get { return false; } }

        #endregion

        #region Constructors/Destructors

        public CopaMundo2022FacadeService(
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

            string nomeFase =  FaseClassificatoria;

            IList<DateTime> datas = new List<DateTime>();
            IList<string> estadios = new List<string>();
            IList<int> ids = new List<int>();
            
            string campeonatoNome = base.Campeonato.Nome;

            string[] grupoA = { "Senegal", "Holanda", "Catar", "Equador" };
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 21, 13, 0, 0, 0), "Al Thumama", nomeFase, "A", grupoA[0], grupoA[1], 1, 1, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 20, 13, 0, 0, 0), "Al Khor", nomeFase, "A", grupoA[2], grupoA[3], 1, 2, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 25, 10, 0, 0, 0), "Al Thumama", nomeFase, "A", grupoA[2], grupoA[0], 2, 17, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 25, 13, 0, 0, 0), "Internacional Khalifa", nomeFase, "A", grupoA[1], grupoA[3], 2, 18, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 29, 12, 0, 0, 0), "Al Khor", nomeFase, "A", grupoA[1], grupoA[2], 3, 33, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 29, 12, 0, 0, 0), "Internacional Khalifa", nomeFase, "A", grupoA[0], grupoA[3], 3, 34, false));
            
            string[] grupoB = { "Inglaterra", "Irã", "Estados Unidos", "Gales" };
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 21, 10, 0, 0, 0), "Internacional Khalifa", nomeFase, "B", grupoB[0], grupoB[1], 1, 3, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 21, 16, 0, 0, 0), "Al Rayyan", nomeFase, "B", grupoB[2], grupoB[3], 1, 4, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 25, 7, 0, 0, 0), "Al Rayyan", nomeFase, "B", grupoB[3], grupoB[1], 2, 19, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 25, 16, 0, 0, 0), "Al Khor", nomeFase, "B", grupoB[0], grupoB[2], 2, 20, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 29, 16, 0, 0, 0), "Al Rayyan", nomeFase, "B", grupoB[3], grupoB[0], 3, 35, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 29, 16, 0, 0, 0), "Al Thumama", nomeFase, "B", grupoB[1], grupoB[2], 3, 36, false));

            string[] grupoC = { "Argentina", "Arábia Saudita", "México", "Polônia" };
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 22, 7, 0, 0, 0), "Nacional de Lusail", nomeFase, "C", grupoC[0], grupoC[1], 1, 5, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 22, 13, 0, 0, 0), "Porto de Doha", nomeFase, "C", grupoC[2], grupoC[3], 1, 6, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 26, 10, 0, 0, 0), "Cidade da Educação", nomeFase, "C", grupoC[3], grupoC[1], 2, 21, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 26, 16, 0, 0, 0), "Nacional de Lusail", nomeFase, "C", grupoC[0], grupoC[2], 2, 22, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 30, 16, 0, 0, 0), "Porto de Doha", nomeFase, "C", grupoC[3], grupoC[0], 3, 37, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 30, 16, 0, 0, 0), "Nacional de Lusail", nomeFase, "C", grupoC[1], grupoC[2], 3, 38, false));

            string[] grupoD = { "Dinamarca", "Tunísia", "França", "Austrália" };
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 22, 10, 0, 0, 0), "Cidade da Educação", nomeFase, "D", grupoD[0], grupoD[1], 1, 7, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 22, 16, 0, 0, 0), "Al Wakrah", nomeFase, "D", grupoD[2], grupoD[3], 1, 8, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 26, 7, 0, 0, 0), "Al Wakrah", nomeFase, "D", grupoD[1], grupoD[3], 2, 23, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 26, 13, 0, 0, 0), "Porto de Doha", nomeFase, "D", grupoD[2], grupoD[0], 2, 24, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 30, 12, 0, 0, 0), "Cidade da Educação", nomeFase, "D", grupoD[1], grupoD[2], 3, 39, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 30, 12, 0, 0, 0), "Al Wakrah", nomeFase, "D", grupoD[3], grupoD[0], 3, 40, false));

            string[] grupoE = { "Alemanha", "Japão", "Espanha", "Costa Rica"  };
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 23, 10, 0, 0, 0), "Internacional Khalifa", nomeFase, "E", grupoE[0], grupoE[1], 1, 9, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 23, 13, 0, 0, 0), "Al Thumama", nomeFase, "E", grupoE[2], grupoE[3], 1, 10, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 27, 7, 0, 0, 0), "Al Rayyan", nomeFase, "E", grupoE[1], grupoE[3], 2, 25, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 27, 16, 0, 0, 0), "Al Khor", nomeFase, "E", grupoE[2], grupoE[0], 2, 26, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 1, 16, 0, 0, 0), "Internacional Khalifa", nomeFase, "E", grupoE[1], grupoE[2], 3, 41, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 1, 16, 0, 0, 0), "Al Khor", nomeFase, "E", grupoE[3], grupoE[0], 3, 42, false));

            string[] grupoF = { "Marrocos", "Croácia", "Bélgica", "Canadá" };
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 23, 7, 0, 0, 0), "Al Khor", nomeFase, "F", grupoF[0], grupoF[1], 1, 11, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 23, 16, 0, 0, 0), "Al Rayyan", nomeFase, "F", grupoF[2], grupoF[3], 1, 12, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 27, 10, 0, 0, 0), "Al Thumama", nomeFase, "F", grupoF[2], grupoF[0], 2, 27, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 27, 13, 0, 0, 0), "Internacional Khalifa", nomeFase, "F", grupoF[1], grupoF[3], 2, 28, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 1, 12, 0, 0, 0), "Al Rayyan", nomeFase, "F", grupoF[1], grupoF[2], 3, 43, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 1, 12, 0, 0, 0), "Al Thumama", nomeFase, "F", grupoF[3], grupoF[0], 3, 44, false));

            string[] grupoG = { "Suíça" , "Camarões", "Brasil", "Sérvia" };
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 24, 7, 0, 0, 0), "Al Wakrah", nomeFase, "G", grupoG[0], grupoG[1], 1, 13, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 24, 16, 0, 0, 0), "Nacional de Lusail", nomeFase, "G", grupoG[2], grupoG[3], 1, 14, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 28, 7, 0, 0, 0), "Al Wakrah", nomeFase, "G", grupoG[1], grupoG[3], 2, 29, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 28, 13, 0, 0, 0), "Porto de Doha", nomeFase, "G", grupoG[2], grupoG[0], 2, 30, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 2, 16, 0, 0, 0), "Nacional de Lusail", nomeFase, "G", grupoG[1], grupoG[2], 3, 45, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 2, 16, 0, 0, 0), "Porto de Doha", nomeFase, "G", grupoG[3], grupoG[0], 3, 46, false));

            string[] grupoH = { "Uruguai", "Coréia do Sul", "Portugal", "Gana" };
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 24, 10, 0, 0, 0), "Cidade da Educação", nomeFase, "H", grupoH[0], grupoH[1], 1, 15, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 24, 13, 0, 0, 0), "Porto de Doha", nomeFase, "H", grupoH[2], grupoH[3], 1, 16, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 28, 10, 0, 0, 0), "Cidade da Educação", nomeFase, "H", grupoH[1], grupoH[3], 2, 31, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 11, 28, 16, 0, 0, 0), "Nacional de Lusail", nomeFase, "H", grupoH[2], grupoH[0], 2, 32, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 2, 12, 0, 0, 0), "Cidade da Educação", nomeFase, "H", grupoH[1], grupoH[2], 3, 47, false));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 2, 12, 0, 0, 0), "Al Wakrah", nomeFase, "H", grupoH[3], grupoH[0], 3, 48, false));
             

            return list;
        }
        public IList<Entities.Campeonatos.Jogo> GetOitavasFinal()
        {
            string nomeFase = FaseOitavasFinal;
            int rodada = 4;
            string nomeGrupo = " ";
            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 3, 12, 0, 0, 0), "Internacional Khalifa", nomeFase, nomeGrupo, rodada, 49, "A", 1, "B", 2, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 3, 16, 0, 0, 0), "Al Rayyan", nomeFase, nomeGrupo, rodada, 50, "C", 1, "D", 2, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 4, 12, 0, 0, 0), "Al Thumama", nomeFase, nomeGrupo, rodada, 52, "D", 1, "C", 2, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 4, 16, 0, 0, 0), "Al Khor", nomeFase, nomeGrupo, rodada, 51, "B", 1, "A", 2, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 5, 12, 0, 0, 0), "Al Wakrah", nomeFase, nomeGrupo, rodada, 53, "E", 1, "F", 2, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 5, 16, 0, 0, 0), "Porto de Dhoa", nomeFase, nomeGrupo, rodada, 54, "G", 1, "H", 2, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 6, 12, 0, 0, 0), "Cidade da Educação", nomeFase, nomeGrupo, rodada, 55, "F", 1, "E", 2, true, null, null));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 6, 16, 0, 0, 0), "Nacional de Lusail", nomeFase, nomeGrupo, rodada, 56, "H", 1, "G", 2, true, null, null));

            return list;
        }
        public IList<Entities.Campeonatos.Jogo> GetQuartasFinal()
        {
            string nomeFase = FaseQuartasFinal;
            int rodada = 5;
            string nomeGrupo = " ";

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 9, 12, 0, 0, 0), "Cidade da Educação", nomeFase, nomeGrupo, rodada, 58, 53, true, 54, true, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 9, 16, 0, 0, 0), "Nacional de Lusail", nomeFase, nomeGrupo, rodada, 57, 49, true, 50, true, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 10, 12, 0, 0, 0), "Cidade da Educação", nomeFase, nomeGrupo, rodada, 60, 55, true, 56, true, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 10, 16, 0, 0, 0), "Cidade da Educação", nomeFase, nomeGrupo, rodada, 59, 51, true, 52, true, true));
            
            return list;
        }
        public IList<Entities.Campeonatos.Jogo> GetSemiFinal()
        {
            string nomeFase = FaseSemiFinal;
            int rodada = 6;
            string nomeGrupo = " ";
            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 13, 16, 0, 0, 0), "Nacional de Lusail", nomeFase, nomeGrupo, rodada, 61, 57, true, 58, true, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 14, 16, 0, 0, 0), "Al Khor", nomeFase, nomeGrupo, rodada, 62, 59, true, 60, true, true));

            return list;           
        }
        public IList<Entities.Campeonatos.Jogo> GetFinal()
        {
            string nomeFase = FaseFinal;
            int rodada = 7;
            string nomeGrupo = " ";
            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 17, 12, 0, 0, 0), "Internacional de Khalifa", nomeFase, nomeGrupo, rodada, 63, 61, false, 62, false, true));
            list.Add(CreateJogo(base.Campeonato.Nome, new DateTime(2022, 12, 18, 12, 0, 0, 0), "Nacional de Lusail", nomeFase, nomeGrupo, rodada, 64, 61, true, 62, true, true));

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
        }

        #endregion

    }
} 