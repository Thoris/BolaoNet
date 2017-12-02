using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Services.Facade.Campeonatos
{
    public class CopaMundo2018FacadeService : BaseStructureCopaMundoFacadeService, 
        Domain.Interfaces.Services.Facade.Campeonatos.ICopaMundo2018FacadeService
    {
        
        #region Constructors/Destructors

        public CopaMundo2018FacadeService(
            Interfaces.Services.DadosBasicos.ITimeService timeService,
            Interfaces.Services.Campeonatos.ICampeonatoService campeonatoService,
            Interfaces.Services.Campeonatos.ICampeonatoTimeService campeonatoTimeService,
            Interfaces.Services.Campeonatos.ICampeonatoFaseService campeonatoFaseService,
            Interfaces.Services.Campeonatos.ICampeonatoGrupoService campeonatoGrupoService,
            Interfaces.Services.Campeonatos.ICampeonatoGrupoTimeService campeonatoGrupoTimeService,
            Interfaces.Services.DadosBasicos.IEstadioService estadioService,
            Interfaces.Services.Campeonatos.IJogoService jogoService,
            Interfaces.Services.Campeonatos.ICampeonatoPosicaoService campeonatoPosicaoService
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
                campeonatoPosicaoService
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
                IsIniciado = false
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
            string[] grupoA = { "Rússia", "Arábia Saudita", "Egito", "Uruguai" };
            datas.Add(new DateTime(2018, 6, 14, 12, 0, 0, 0)); estadios.Add("Luzhniki"); ids.Add(1);
            datas.Add(new DateTime(2018, 6, 15, 9, 0, 0, 0)); estadios.Add("Ekaterinburg"); ids.Add(2);
            datas.Add(new DateTime(2018, 6, 19, 15, 0, 0, 0)); estadios.Add("Krestovsky"); ids.Add(17);
            datas.Add(new DateTime(2018, 6, 20, 12, 0, 0, 0)); estadios.Add("Arena Rostov"); ids.Add(18);
            datas.Add(new DateTime(2018, 6, 25, 11, 0, 0, 0)); estadios.Add("Estádio de Samara"); ids.Add(33);
            datas.Add(new DateTime(2018, 6, 25, 11, 0, 0, 0)); estadios.Add("Arena Volgogrado"); ids.Add(34);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "A", nomeFase, grupoA.ToList<string>(), datas, estadios, ids));

            //string[] grupoB = { "Espanha", "Irã", "Marrocos", "Portugal" };
            string[] grupoB = { "Portugal", "Espanha", "Marrocos", "Irã" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2018, 6, 15, 15, 0, 0, 0)); estadios.Add("Fisht Olympic"); ids.Add(3);
            datas.Add(new DateTime(2018, 6, 15, 12, 0, 0, 0)); estadios.Add("Krestovsky"); ids.Add(4);
            datas.Add(new DateTime(2018, 6, 20, 9, 0, 0, 0)); estadios.Add("Luzhniki"); ids.Add(19);
            datas.Add(new DateTime(2018, 6, 20, 15, 0, 0, 0)); estadios.Add("Kazan Arena"); ids.Add(20);
            datas.Add(new DateTime(2018, 6, 25, 15, 0, 0, 0)); estadios.Add("Arena Mordovia"); ids.Add(35);
            datas.Add(new DateTime(2018, 6, 25, 15, 0, 0, 0)); estadios.Add("Estádio de Kaliningrado"); ids.Add(36);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "B", nomeFase, grupoB.ToList<string>(), datas, estadios, ids));

            //string[] grupoC = { "Austrália", "Dinamarca", "França", "Peru" };
            string[] grupoC = { "França", "Austrália", "Peru", "Dinamarca" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2018, 6, 16, 7, 0, 0, 0)); estadios.Add("Kazan Arena"); ids.Add(5);
            datas.Add(new DateTime(2018, 6, 16, 13, 0, 0, 0)); estadios.Add("Arena Mordovia"); ids.Add(6);
            datas.Add(new DateTime(2018, 6, 21, 9, 0, 0, 0)); estadios.Add("Ekaterninburg Arena"); ids.Add(21);
            datas.Add(new DateTime(2018, 6, 21, 12, 0, 0, 0)); estadios.Add("Estádio de Samara"); ids.Add(22);
            datas.Add(new DateTime(2018, 6, 26, 11, 0, 0, 0)); estadios.Add("Luzhniki"); ids.Add(37);
            datas.Add(new DateTime(2018, 6, 26, 11, 0, 0, 0)); estadios.Add("Fisht Olympic"); ids.Add(38);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "C", nomeFase, grupoC.ToList<string>(), datas, estadios, ids));

            //string[] grupoD = { "Argentina", "Croácia", "Islândia", "Nigéria" };
            string[] grupoD = { "Argentina", "Islândia", "Croácia", "Nigéria" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2018, 6, 16, 10, 0, 0, 0)); estadios.Add("Otkrytiye Arena"); ids.Add(7);
            datas.Add(new DateTime(2018, 6, 16, 16, 0, 0, 0)); estadios.Add("Estádio de Kaliningrado"); ids.Add(8);
            datas.Add(new DateTime(2018, 6, 21, 15, 0, 0, 0)); estadios.Add("Novgorod"); ids.Add(23);
            datas.Add(new DateTime(2018, 6, 22, 12, 0, 0, 0)); estadios.Add("Arena Volgogrado"); ids.Add(24);
            datas.Add(new DateTime(2018, 6, 26, 15, 0, 0, 0)); estadios.Add("Krestovsky"); ids.Add(39);
            datas.Add(new DateTime(2018, 6, 26, 15, 0, 0, 0)); estadios.Add("Arena Rosov"); ids.Add(40);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "D", nomeFase, grupoD.ToList<string>(), datas, estadios, ids));

            //string[] grupoE = { "Brasil", "Costa Rica", "Sérvia", "Suíça" };
            string[] grupoE = { "Brasil", "Suíça", "Costa Rica", "Sérvia"  };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2018, 6, 17, 15, 0, 0, 0)); estadios.Add("Arena Rostov"); ids.Add(9);
            datas.Add(new DateTime(2018, 6, 17, 9, 0, 0, 0)); estadios.Add("Estádio de Samara"); ids.Add(10);
            datas.Add(new DateTime(2018, 6, 22, 9, 0, 0, 0)); estadios.Add("Krestovsky"); ids.Add(25);
            datas.Add(new DateTime(2018, 6, 22, 15, 0, 0, 0)); estadios.Add("Estádio de Kaliningrado"); ids.Add(26);
            datas.Add(new DateTime(2018, 6, 27, 15, 0, 0, 0)); estadios.Add("Otkrytiye Arena"); ids.Add(41);
            datas.Add(new DateTime(2018, 6, 27, 15, 0, 0, 0)); estadios.Add("Novgorod"); ids.Add(42);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "E", nomeFase, grupoE.ToList<string>(), datas, estadios, ids));

            //string[] grupoF = { "Alemanha", "Coreia do Sul", "México", "Suécia" };
            string[] grupoF = { "Alemanha", "México", "Suécia", "Coreia do Sul" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2018, 6, 17, 12, 0, 0, 0)); estadios.Add("Luzhniki"); ids.Add(11);
            datas.Add(new DateTime(2018, 6, 18, 9, 0, 0, 0)); estadios.Add("Novgorod"); ids.Add(12);
            datas.Add(new DateTime(2018, 6, 23, 12, 0, 0, 0)); estadios.Add("Fisht Olympic"); ids.Add(27);
            datas.Add(new DateTime(2018, 6, 23, 15, 0, 0, 0)); estadios.Add("Arena Rostov"); ids.Add(28);
            datas.Add(new DateTime(2018, 6, 27, 11, 0, 0, 0)); estadios.Add("Ekaterninburg Arena"); ids.Add(43);
            datas.Add(new DateTime(2018, 6, 27, 11, 0, 0, 0)); estadios.Add("Kazan Arena"); ids.Add(44);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "F", nomeFase, grupoF.ToList<string>(), datas, estadios, ids));

            //string[] grupoG = { "Bélgica", "Inglaterra", "Panamá", "Tunísia" };
            string[] grupoG = { "Bélgica", "Panamá", "Tunísia" , "Inglaterra"};
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2018, 6, 18, 12, 0, 0, 0)); estadios.Add("Fisht Olympic"); ids.Add(13);
            datas.Add(new DateTime(2018, 6, 18, 15, 0, 0, 0)); estadios.Add("Arena Volgogrado"); ids.Add(14);
            datas.Add(new DateTime(2018, 6, 23, 9, 0, 0, 0)); estadios.Add("Otkrytiye Arena"); ids.Add(29);
            datas.Add(new DateTime(2018, 6, 24, 9, 0, 0, 0)); estadios.Add("Novgorod"); ids.Add(30);
            datas.Add(new DateTime(2018, 6, 28, 15, 0, 0, 0)); estadios.Add("Arena Mordovia"); ids.Add(45);
            datas.Add(new DateTime(2018, 6, 28, 15, 0, 0, 0)); estadios.Add("Estádio de Kaliningrado"); ids.Add(46);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "G", nomeFase, grupoG.ToList<string>(), datas, estadios, ids));

            //string[] grupoH = { "Colômbia", "Japão", "Polônia", "Senegal" };
            string[] grupoH = { "Polônia", "Senegal", "Colômbia", "Japão", };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2018, 6, 19, 9, 0, 0, 0)); estadios.Add("Otkrytiye Arena"); ids.Add(15);
            datas.Add(new DateTime(2018, 6, 19, 12, 0, 0, 0)); estadios.Add("Arena Mordovia"); ids.Add(16);
            datas.Add(new DateTime(2018, 6, 24, 15, 0, 0, 0)); estadios.Add("Kazan Arena"); ids.Add(31);
            datas.Add(new DateTime(2018, 6, 24, 12, 0, 0, 0)); estadios.Add("Ekaterninburg Arena"); ids.Add(32);
            datas.Add(new DateTime(2018, 6, 28, 11, 0, 0, 0)); estadios.Add("Arena Volgogrado"); ids.Add(47);
            datas.Add(new DateTime(2018, 6, 28, 11, 0, 0, 0)); estadios.Add("Estádio de Samara"); ids.Add(48);
            list = Merge(list, base.GetJogosGrupo(base.Campeonato, "H", nomeFase, grupoH.ToList<string>(), datas, estadios, ids));

            return list;
        }
        public IList<Entities.Campeonatos.Jogo> GetOitavasFinal()
        {
            string nomeFase = FaseOitavasFinal;
            IList<DateTime> datas = new List<DateTime>();
            IList<int> ids = new List<int>();
            IList<string> estadios = new List<string>();

            datas.Add(new DateTime(2018, 6, 30, 15, 0, 0, 0)); estadios.Add("Fisht Olympic"); ids.Add(49);
            datas.Add(new DateTime(2018, 6, 30, 11, 0, 0, 0)); estadios.Add("Kazan Arena"); ids.Add(50);
            datas.Add(new DateTime(2018, 7, 1, 11, 0, 0, 0)); estadios.Add("Luzhniki"); ids.Add(51);
            datas.Add(new DateTime(2018, 7, 1, 15, 0, 0, 0)); estadios.Add("Novgorod"); ids.Add(52);
            datas.Add(new DateTime(2018, 7, 2, 11, 0, 0, 0)); estadios.Add("Estádio de Samara"); ids.Add(53);
            datas.Add(new DateTime(2018, 7, 2, 15, 0, 0, 0)); estadios.Add("Arena Rostov"); ids.Add(54);
            datas.Add(new DateTime(2018, 7, 3, 11, 0, 0, 0)); estadios.Add("Krestovsky"); ids.Add(55);
            datas.Add(new DateTime(2018, 7, 3, 15, 0, 0, 0)); estadios.Add("Otkrytiye Arena"); ids.Add(56);

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

            datas.Add(new DateTime(2018, 7, 6, 11, 0, 0, 0)); estadios.Add("Novgorod"); ids.Add(57);
            idsGanhadores.Add(49); idsGanhadores.Add(50);
            datas.Add(new DateTime(2018, 7, 6, 15, 0, 0, 0)); estadios.Add("Kazan Arena"); ids.Add(58);
            idsGanhadores.Add(53); idsGanhadores.Add(54);
            datas.Add(new DateTime(2018, 7, 7, 15, 0, 0, 0)); estadios.Add("Fisht Olympic"); ids.Add(59);
            idsGanhadores.Add(51); idsGanhadores.Add(52);
            datas.Add(new DateTime(2018, 7, 7, 11, 0, 0, 0)); estadios.Add("Estádio de Samara"); ids.Add(60);
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

            datas.Add(new DateTime(2018, 7, 10, 15, 0, 0, 0)); estadios.Add("Krestovsky"); ids.Add(61);
            idsGanhadores.Add(57); idsGanhadores.Add(58);
            datas.Add(new DateTime(2018, 7, 11, 15, 0, 0, 0)); estadios.Add("Luzhniki"); ids.Add(62);
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

            datas.Add(new DateTime(2018, 7, 14, 11, 0, 0, 0)); estadios.Add("Krestovsky"); ids.Add(63);
            idsGanhadores.Add(61); idsGanhadores.Add(62);
            datas.Add(new DateTime(2018, 7, 15, 12, 0, 0, 0)); estadios.Add("Luzhniki"); ids.Add(64);
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

        #endregion

    }
}
