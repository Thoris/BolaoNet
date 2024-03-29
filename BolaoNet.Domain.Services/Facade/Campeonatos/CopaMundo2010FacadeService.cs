﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace BolaoNet.Domain.Services.Facade.Campeonatos
{
    public class CopaMundo2010FacadeService : BaseStructureCopaMundoFacadeService, 
        Domain.Interfaces.Services.Facade.Campeonatos.ICopaMundo2010FacadeService
    {

        #region Constants

        public const string Name = "Copa do Mundo 2010";

        #endregion

        #region Properties

        public bool IsContainsResults { get { return true; } }

        #endregion

        #region Constructors/Destructors

        public CopaMundo2010FacadeService(
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

            return campeonato;
        }
        public IList<Entities.Campeonatos.Jogo> GetJogosGrupo()
        {
            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            string nomeFase =  FaseClassificatoria;

            IList<DateTime> datas = new List<DateTime>();
            IList<string> estadios = new List<string>();
            IList<int> ids = new List<int>();
            string[] grupoA = { "África do Sul", "México", "Uruguai", "França" };
            datas.Add(new DateTime(2010, 6, 12, 17, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(1);
            datas.Add(new DateTime(2010, 6, 13, 13, 0, 0, 0)); estadios.Add("Natal"); ids.Add(2);
            datas.Add(new DateTime(2010, 6, 17, 16, 0, 0, 0)); estadios.Add("Fortaleza"); ids.Add(17);
            datas.Add(new DateTime(2010, 6, 18, 19, 0, 0, 0)); estadios.Add("Manaus"); ids.Add(18);
            datas.Add(new DateTime(2010, 6, 23, 17, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(33);
            datas.Add(new DateTime(2010, 6, 23, 17, 0, 0, 0)); estadios.Add("Recife"); ids.Add(34);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "A", nomeFase, grupoA.ToList<string>(), datas, estadios, ids));

            string[] grupoB = { "Coreia do Sul", "Grécia", "Argentina", "Nigéria" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2010, 6, 13, 16, 0, 0, 0)); estadios.Add("Cuiabá"); ids.Add(3);
            datas.Add(new DateTime(2010, 6, 13, 18, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(4);
            datas.Add(new DateTime(2010, 6, 18, 16, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(19);
            datas.Add(new DateTime(2010, 6, 18, 18, 0, 0, 0)); estadios.Add("Porto Alegre"); ids.Add(20);
            datas.Add(new DateTime(2010, 6, 23, 13, 0, 0, 0)); estadios.Add("Curitiba"); ids.Add(35);
            datas.Add(new DateTime(2010, 6, 23, 13, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(36);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "B", nomeFase, grupoB.ToList<string>(), datas, estadios, ids));

            string[] grupoC = { "Inglaterra", "Estados Unidos", "Argélia" , "Eslovénia" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2010, 6, 14, 13, 0, 0, 0)); estadios.Add("Belo Horizonte"); ids.Add(5);
            datas.Add(new DateTime(2010, 6, 14, 22, 0, 0, 0)); estadios.Add("Recife"); ids.Add(6);
            datas.Add(new DateTime(2010, 6, 19, 13, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(21);
            datas.Add(new DateTime(2010, 6, 19, 19, 0, 0, 0)); estadios.Add("Natal"); ids.Add(22);
            datas.Add(new DateTime(2010, 6, 24, 16, 0, 0, 0)); estadios.Add("Cuiabá"); ids.Add(37);
            datas.Add(new DateTime(2010, 6, 24, 17, 0, 0, 0)); estadios.Add("Fortaleza"); ids.Add(38);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "C", nomeFase, grupoC.ToList<string>(), datas, estadios, ids));

            string[] grupoD = { "Sérvia", "Ghana", "Alemanha", "Austrália"};
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2010, 6, 14, 16, 0, 0, 0)); estadios.Add("Fortaleza"); ids.Add(7);
            datas.Add(new DateTime(2010, 6, 14, 19, 0, 0, 0)); estadios.Add("Manaus"); ids.Add(8);
            datas.Add(new DateTime(2010, 6, 19, 16, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(23);
            datas.Add(new DateTime(2010, 6, 20, 13, 0, 0, 0)); estadios.Add("Recife"); ids.Add(24);
            datas.Add(new DateTime(2010, 6, 24, 13, 0, 0, 0)); estadios.Add("Natal"); ids.Add(39);
            datas.Add(new DateTime(2010, 6, 24, 13, 0, 0, 0)); estadios.Add("Belo Horizonte"); ids.Add(40);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "D", nomeFase, grupoD.ToList<string>(), datas, estadios, ids));

            string[] grupoE = { "Holanda", "Dinamarca", "Japão", "Camarões" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2010, 6, 15, 13, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(9);
            datas.Add(new DateTime(2010, 6, 15, 16, 0, 0, 0)); estadios.Add("Porto Alegre"); ids.Add(10);
            datas.Add(new DateTime(2010, 6, 20, 16, 0, 0, 0)); estadios.Add("Salvador"); ids.Add(25);
            datas.Add(new DateTime(2010, 6, 20, 19, 0, 0, 0)); estadios.Add("Curitiba"); ids.Add(26);
            datas.Add(new DateTime(2010, 6, 25, 16, 0, 0, 0)); estadios.Add("Manaus"); ids.Add(41);
            datas.Add(new DateTime(2010, 6, 25, 17, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(42);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "E", nomeFase, grupoE.ToList<string>(), datas, estadios, ids));

            string[] grupoF = { "Itália" , "Paraguai", "Nova Zelândia", "Eslováquia" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2010, 6, 15, 19, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(11);
            datas.Add(new DateTime(2010, 6, 16, 16, 0, 0, 0)); estadios.Add("Curitiba"); ids.Add(12);
            datas.Add(new DateTime(2010, 6, 21, 13, 0, 0, 0)); estadios.Add("Belo Horizonte"); ids.Add(27);
            datas.Add(new DateTime(2010, 6, 21, 18, 0, 0, 0)); estadios.Add("Cuiabá"); ids.Add(28);
            datas.Add(new DateTime(2010, 6, 25, 13, 0, 0, 0)); estadios.Add("Porto Alegre"); ids.Add(43);
            datas.Add(new DateTime(2010, 6, 25, 13, 0, 0, 0)); estadios.Add("Salvador"); ids.Add(44);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "F", nomeFase, grupoF.ToList<string>(), datas, estadios, ids));

            string[] grupoG = { "Costa do Marfim", "Portugal", "Brasil", "Coréia do Norte" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2010, 6, 16, 13, 0, 0, 0)); estadios.Add("Salvador"); ids.Add(13);
            datas.Add(new DateTime(2010, 6, 16, 19, 0, 0, 0)); estadios.Add("Natal"); ids.Add(14);
            datas.Add(new DateTime(2010, 6, 21, 16, 0, 0, 0)); estadios.Add("Fortaleza"); ids.Add(29);
            datas.Add(new DateTime(2010, 6, 22, 19, 0, 0, 0)); estadios.Add("Manaus"); ids.Add(30);
            datas.Add(new DateTime(2010, 6, 26, 13, 0, 0, 0)); estadios.Add("Recife"); ids.Add(45);
            datas.Add(new DateTime(2010, 6, 26, 13, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(46);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "G", nomeFase, grupoG.ToList<string>(), datas, estadios, ids));

            string[] grupoH = { "Honduras", "Chile", "Espanha", "Suíça" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2010, 6, 17, 13, 0, 0, 0)); estadios.Add("Belo Horizonte"); ids.Add(15);
            datas.Add(new DateTime(2010, 6, 17, 18, 0, 0, 0)); estadios.Add("Cuiabá"); ids.Add(16);
            datas.Add(new DateTime(2010, 6, 22, 13, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(31);
            datas.Add(new DateTime(2010, 6, 22, 16, 0, 0, 0)); estadios.Add("Porto Alegre"); ids.Add(32);
            datas.Add(new DateTime(2010, 6, 26, 17, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(47);
            datas.Add(new DateTime(2010, 6, 26, 17, 0, 0, 0)); estadios.Add("Curitiba"); ids.Add(48);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "H", nomeFase, grupoH.ToList<string>(), datas, estadios, ids));

            return list;
        }
        public IList<Entities.Campeonatos.Jogo> GetOitavasFinal()
        {
            string nomeFase = FaseOitavasFinal;
            IList<DateTime> datas = new List<DateTime>();
            IList<int> ids = new List<int>();
            IList<string> estadios = new List<string>();

            datas.Add(new DateTime(2010, 6, 28, 13, 0, 0, 0)); estadios.Add("Belo Horizonte"); ids.Add(49);
            datas.Add(new DateTime(2010, 6, 28, 17, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(50);
            datas.Add(new DateTime(2010, 6, 29, 13, 0, 0, 0)); estadios.Add("Fortaleza"); ids.Add(51);
            datas.Add(new DateTime(2010, 6, 29, 17, 0, 0, 0)); estadios.Add("Recife"); ids.Add(52);
            datas.Add(new DateTime(2010, 6, 30, 13, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(53);
            datas.Add(new DateTime(2010, 6, 30, 17, 0, 0, 0)); estadios.Add("Porto Alegre"); ids.Add(54);
            datas.Add(new DateTime(2010, 7, 1, 13, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(55);
            datas.Add(new DateTime(2010, 7, 1, 17, 0, 0, 0)); estadios.Add("Salvador"); ids.Add(56);

            int rodada = 4;
            string nomeGrupo = " ";

            return base.GetJogosOitavas(base.Campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids);
        }
        public IList<Entities.Campeonatos.Jogo> GetQuartasFinal()
        {
            string nomeFase = FaseQuartasFinal;
            IList<DateTime> datas = new List<DateTime>();
            IList<int> ids = new List<int>();
            IList<int> idsGanhadores = new List<int>();
            IList<string> estadios = new List<string>();

            datas.Add(new DateTime(2010, 7, 4, 17, 0, 0, 0)); estadios.Add("Fortaleza"); ids.Add(57);
            idsGanhadores.Add(49); idsGanhadores.Add(50);
            datas.Add(new DateTime(2010, 7, 4, 13, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(58);
            idsGanhadores.Add(53); idsGanhadores.Add(54);
            datas.Add(new DateTime(2010, 7, 5, 17, 0, 0, 0)); estadios.Add("Salvador"); ids.Add(59);
            idsGanhadores.Add(51); idsGanhadores.Add(52);
            datas.Add(new DateTime(2010, 7, 5, 13, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(60);
            idsGanhadores.Add(55); idsGanhadores.Add(56);


            int rodada = 5;
            string nomeGrupo = " ";

            return base.GetJogosQuartas(base.Campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids, idsGanhadores);
        }
        public IList<Entities.Campeonatos.Jogo> GetSemiFinal()
        {
            string nomeFase = FaseSemiFinal;
            IList<DateTime> datas = new List<DateTime>();
            IList<int> ids = new List<int>();
            IList<int> idsGanhadores = new List<int>();
            IList<string> estadios = new List<string>();

            datas.Add(new DateTime(2010, 7, 8, 17, 0, 0, 0)); estadios.Add("Belo Horizonte"); ids.Add(61);
            idsGanhadores.Add(57); idsGanhadores.Add(58);
            datas.Add(new DateTime(2010, 7, 9, 17, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(62);
            idsGanhadores.Add(59); idsGanhadores.Add(60);


            int rodada = 6;
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

            datas.Add(new DateTime(2010, 7, 12, 17, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(63);
            idsGanhadores.Add(61); idsGanhadores.Add(62);
            datas.Add(new DateTime(2010, 7, 13, 16, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(64);
            idsGanhadores.Add(61); idsGanhadores.Add(62);


            int rodada = 7;
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

            //Rodada 1
            jogoLabels.Add(1); time1.Add(1); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(2); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(3); time1.Add(2); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(4); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(5); time1.Add(1); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(6); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(7); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(8); time1.Add(4); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(9); time1.Add(2); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(10); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(11); time1.Add(1); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(12); time1.Add(1); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(13); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(14); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(15); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(16); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);


            //Rodada 2
            jogoLabels.Add(17); time1.Add(0); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(18); time1.Add(0); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(19); time1.Add(1); time2.Add(4); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(20); time1.Add(1); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(21); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(22); time1.Add(2); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(23); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(24); time1.Add(1); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(25); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(26); time1.Add(1); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(27); time1.Add(1); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(28); time1.Add(0); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(29); time1.Add(1); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(30); time1.Add(0); time2.Add(7); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(31); time1.Add(0); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(32); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);

            //Rodada 3
            jogoLabels.Add(33); time1.Add(1); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(34); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(35); time1.Add(2); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(36); time1.Add(0); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(37); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(38); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(39); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(40); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(41); time1.Add(1); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(42); time1.Add(1); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(43); time1.Add(3); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(44); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(45); time1.Add(0); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(46); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(47); time1.Add(0); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(48); time1.Add(1); time2.Add(2); penaltis1.Add(null); penaltis2.Add(null);


            //Oitavas
            jogoLabels.Add(49); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(50); time1.Add(1); time2.Add(1); penaltis1.Add(1); penaltis2.Add(2);
            jogoLabels.Add(51); time1.Add(3); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(52); time1.Add(4); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(53); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(54); time1.Add(3); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(55); time1.Add(0); time2.Add(0); penaltis1.Add(1); penaltis2.Add(0);
            jogoLabels.Add(56); time1.Add(1); time2.Add(0); penaltis1.Add(null); penaltis2.Add(null);

            //Quartas
            jogoLabels.Add(58); time1.Add(2); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(57); time1.Add(1); time2.Add(1); penaltis1.Add(2); penaltis2.Add(1);
            jogoLabels.Add(59); time1.Add(0); time2.Add(4); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(60); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);

            //Semi
            jogoLabels.Add(61); time1.Add(2); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(62); time1.Add(0); time2.Add(1); penaltis1.Add(null); penaltis2.Add(null);

            //Final
            jogoLabels.Add(63); time1.Add(2); time2.Add(3); penaltis1.Add(null); penaltis2.Add(null);
            jogoLabels.Add(64); time1.Add(0); time2.Add(0); penaltis1.Add(0); penaltis2.Add(1);



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

        #endregion

    }
}
