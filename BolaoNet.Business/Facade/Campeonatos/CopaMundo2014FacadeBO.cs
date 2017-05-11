using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Facade.Campeonatos
{
    public class CopaMundo2014FacadeBO : BaseCopaMundoFacadeBO, Interfaces.Facade.Campeonatos.ICopaMundoFacadeBO
    {
        #region Constructors/Destructors

        public CopaMundo2014FacadeBO(Interfaces.IFactoryBO factory)
            : base (factory)
        {

        }

        #endregion

        #region ICopaMundoFacadeBO members
 
        public bool CreateCampeonato()
        {
            Entities.Campeonatos.Campeonato campeonato = new Entities.Campeonatos.Campeonato("Copa do Mundo 2014")
            {
                IsClube = false,
                IsIniciado = false                
            };

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            list = base.Merge(list, GetJogosGrupo(campeonato));
            list = base.Merge(list, GetOitavasFinal(campeonato));
            list = base.Merge(list, GetQuartasFinal(campeonato));
            list = base.Merge(list, GetSemiFinal(campeonato));
            list = base.Merge(list, GetFinal(campeonato));

            return true;
        }
        public IList<Entities.Campeonatos.Jogo> GetJogosGrupo(Entities.Campeonatos.Campeonato campeonato)
        {
            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            string nomeFase = "Classificatória";

            IList<DateTime> datas = new List<DateTime>();
            IList<string> estadios = new List<string>();
            IList<int> ids = new List<int>();
            string[] grupoA = { "Brasil", "Croácia", "México", "Camarões" };
            datas.Add(new DateTime(2014, 6, 12, 17, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(1);
            datas.Add (new DateTime(2014, 6, 13, 13, 0, 0, 0)); estadios.Add ("Natal"); ids.Add (2);
            datas.Add (new DateTime(2014, 6, 17, 16, 0, 0, 0)); estadios.Add ("Fortaleza"); ids.Add (17);
            datas.Add (new DateTime(2014, 6, 18, 19, 0, 0, 0)); estadios.Add ("Manaus"); ids.Add (18);
            datas.Add (new DateTime(2014, 6, 23, 17, 0, 0, 0)); estadios.Add ("Brasília"); ids.Add (33);
            datas.Add (new DateTime(2014, 6, 23, 17, 0, 0, 0)); estadios.Add ("Recife"); ids.Add (34);
            list = Merge(list, base.GetJogosGrupo(campeonato, "A", nomeFase, grupoA.ToList<string>(), datas, estadios, ids));
                        
            string[] grupoB = { "Espanha", "Holanda", "Chile", "Austrália" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2014, 6, 13, 16, 0, 0, 0)); estadios.Add("Cuiabá"); ids.Add(3);
            datas.Add(new DateTime(2014, 6, 13, 18, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(4);
            datas.Add(new DateTime(2014, 6, 18, 16, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(19);
            datas.Add(new DateTime(2014, 6, 18, 18, 0, 0, 0)); estadios.Add("Porto Alegre"); ids.Add(20);
            datas.Add(new DateTime(2014, 6, 23, 13, 0, 0, 0)); estadios.Add("Curitiba"); ids.Add(35);
            datas.Add(new DateTime(2014, 6, 23, 13, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(36);
            list = Merge(list, base.GetJogosGrupo(campeonato, "B", nomeFase, grupoB.ToList<string>(), datas, estadios, ids));
            
            string[] grupoC = { "Colômbia", "Grécia", "Costa do Marfim", "Japão" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2014, 6, 14, 13, 0, 0, 0)); estadios.Add("Belo Horizonte"); ids.Add(5);
            datas.Add(new DateTime(2014, 6, 14, 22, 0, 0, 0)); estadios.Add("Recife"); ids.Add(6);
            datas.Add(new DateTime(2014, 6, 19, 13, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(21);
            datas.Add(new DateTime(2014, 6, 19, 19, 0, 0, 0)); estadios.Add("Natal"); ids.Add(22);
            datas.Add(new DateTime(2014, 6, 24, 16, 0, 0, 0)); estadios.Add("Cuiabá"); ids.Add(37);
            datas.Add(new DateTime(2014, 6, 24, 17, 0, 0, 0)); estadios.Add("Fortaleza"); ids.Add(38);
            list = Merge(list, base.GetJogosGrupo(campeonato, "C", nomeFase, grupoC.ToList<string>(), datas, estadios, ids));

            string[] grupoD = { "Uruguai", "Costa Rica", "Inglaterra", "Itália" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2014, 6, 14, 16, 0, 0, 0)); estadios.Add("Fortaleza"); ids.Add(7);
            datas.Add(new DateTime(2014, 6, 14, 19, 0, 0, 0)); estadios.Add("Manaus"); ids.Add(8);
            datas.Add(new DateTime(2014, 6, 19, 16, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(23);
            datas.Add(new DateTime(2014, 6, 20, 13, 0, 0, 0)); estadios.Add("Recife"); ids.Add(24);
            datas.Add(new DateTime(2014, 6, 24, 13, 0, 0, 0)); estadios.Add("Natal"); ids.Add(39);
            datas.Add(new DateTime(2014, 6, 24, 13, 0, 0, 0)); estadios.Add("Belo Horizonte"); ids.Add(40);
            list = Merge(list, base.GetJogosGrupo(campeonato, "D", nomeFase, grupoD.ToList<string>(), datas, estadios, ids));

            string[] grupoE = { "Suíça", "Equador", "França", "Honduras" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2014, 6, 15, 13, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(9);
            datas.Add(new DateTime(2014, 6, 15, 16, 0, 0, 0)); estadios.Add("Porto Alegre"); ids.Add(10);
            datas.Add(new DateTime(2014, 6, 20, 16, 0, 0, 0)); estadios.Add("Salvador"); ids.Add(25);
            datas.Add(new DateTime(2014, 6, 20, 19, 0, 0, 0)); estadios.Add("Curitiba"); ids.Add(26);
            datas.Add(new DateTime(2014, 6, 25, 16, 0, 0, 0)); estadios.Add("Manaus"); ids.Add(41);
            datas.Add(new DateTime(2014, 6, 25, 17, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(42);
            list = Merge(list, base.GetJogosGrupo(campeonato, "E", nomeFase, grupoE.ToList<string>(), datas, estadios, ids));

            string[] grupoF = { "Argentina", "Bósnia e Herzegovina", "Irã", "Nigéria" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2014, 6, 15, 19, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(11);
            datas.Add(new DateTime(2014, 6, 16, 16, 0, 0, 0)); estadios.Add("Curitiba"); ids.Add(12);
            datas.Add(new DateTime(2014, 6, 21, 13, 0, 0, 0)); estadios.Add("Belo Horizonte"); ids.Add(27);
            datas.Add(new DateTime(2014, 6, 21, 18, 0, 0, 0)); estadios.Add("Cuiabá"); ids.Add(28);
            datas.Add(new DateTime(2014, 6, 25, 13, 0, 0, 0)); estadios.Add("Porto Alegre"); ids.Add(43);
            datas.Add(new DateTime(2014, 6, 25, 13, 0, 0, 0)); estadios.Add("Salvador"); ids.Add(44);
            list = Merge(list, base.GetJogosGrupo(campeonato, "F", nomeFase, grupoF.ToList<string>(), datas, estadios, ids));

            string[] grupoG = { "Alemanha", "Portugal", "Gana", "Estados Unidos" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>();
            datas.Add(new DateTime(2014, 6, 16, 13, 0, 0, 0)); estadios.Add("Salvador"); ids.Add(13);
            datas.Add(new DateTime(2014, 6, 16, 19, 0, 0, 0)); estadios.Add("Natal"); ids.Add(14);
            datas.Add(new DateTime(2014, 6, 21, 16, 0, 0, 0)); estadios.Add("Fortaleza"); ids.Add(29);
            datas.Add(new DateTime(2014, 6, 22, 19, 0, 0, 0)); estadios.Add("Manaus"); ids.Add(30);
            datas.Add(new DateTime(2014, 6, 26, 13, 0, 0, 0)); estadios.Add("Recife"); ids.Add(45);
            datas.Add(new DateTime(2014, 6, 26, 13, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(46);
            list = Merge(list, base.GetJogosGrupo(campeonato, "G", nomeFase, grupoG.ToList<string>(), datas, estadios, ids));

            string[] grupoH = { "Bélgica", "Argélia", "Rússia", "Coreia do Sul" };
            datas = new List<DateTime>(); estadios = new List<string>(); ids = new List<int>(); 
            datas.Add(new DateTime(2014, 6, 17, 13, 0, 0, 0)); estadios.Add("Belo Horizonte"); ids.Add(15);
            datas.Add(new DateTime(2014, 6, 17, 18, 0, 0, 0)); estadios.Add("Cuiabá"); ids.Add(16);
            datas.Add(new DateTime(2014, 6, 22, 13, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(31);
            datas.Add(new DateTime(2014, 6, 22, 16, 0, 0, 0)); estadios.Add("Porto Alegre"); ids.Add(32);
            datas.Add(new DateTime(2014, 6, 26, 17, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(47);
            datas.Add(new DateTime(2014, 6, 26, 17, 0, 0, 0)); estadios.Add("Curitiba"); ids.Add(48);
            list = Merge(list, base.GetJogosGrupo(campeonato, "H", nomeFase, grupoH.ToList<string>(), datas, estadios, ids));

            return list;
        }
        public IList<Entities.Campeonatos.Jogo> GetOitavasFinal(Entities.Campeonatos.Campeonato campeonato)
        {            
            string nomeFase = "Oitavas de Final";
            IList<DateTime> datas = new List<DateTime>();
            IList<int> ids = new List<int>();
            IList<string> estadios = new List<string>();

            datas.Add(new DateTime(2014, 6, 28, 13, 0, 0, 0)); estadios.Add("Belo Horizonte"); ids.Add(49);
            datas.Add(new DateTime(2014, 6, 28, 17, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(50);
            datas.Add(new DateTime(2014, 6, 29, 13, 0, 0, 0)); estadios.Add("Fortaleza"); ids.Add(51);
            datas.Add(new DateTime(2014, 6, 29, 17, 0, 0, 0)); estadios.Add("Recife"); ids.Add(52);
            datas.Add(new DateTime(2014, 6, 30, 13, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(53);
            datas.Add(new DateTime(2014, 6, 30, 17, 0, 0, 0)); estadios.Add("Porto Alegre"); ids.Add(54);
            datas.Add(new DateTime(2014, 7, 1, 13, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(55);
            datas.Add(new DateTime(2014, 7, 1, 17, 0, 0, 0)); estadios.Add("Salvador"); ids.Add(56);

            int rodada = 4;          
            string nomeGrupo = " ";

            return base.GetJogosOitavas(campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids);            
        }
        public IList<Entities.Campeonatos.Jogo> GetQuartasFinal(Entities.Campeonatos.Campeonato campeonato)
        {
            string nomeFase = "Quartas de Final";
            IList<DateTime> datas = new List<DateTime>();
            IList<int> ids = new List<int>();
            IList<int> idsGanhadores = new List<int>();
            IList<string> estadios = new List<string>();

            datas.Add(new DateTime(2014, 7, 4, 17, 0, 0, 0)); estadios.Add("Fortaleza"); ids.Add(57);
            idsGanhadores.Add(49); idsGanhadores.Add(50);
            datas.Add(new DateTime(2014, 7, 4, 13, 0, 0, 0)); estadios.Add("Rio de Janeiro"); ids.Add(58);
            idsGanhadores.Add(53); idsGanhadores.Add(54);
            datas.Add(new DateTime(2014, 7, 5, 17, 0, 0, 0)); estadios.Add("Salvador"); ids.Add(59);
            idsGanhadores.Add(51); idsGanhadores.Add(52);
            datas.Add(new DateTime(2014, 7, 5, 13, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(60);
            idsGanhadores.Add(55); idsGanhadores.Add(56);
            

            int rodada = 5;            
            string nomeGrupo = " ";

            return base.GetJogosQuartas(campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids, idsGanhadores);            
        }
        public IList<Entities.Campeonatos.Jogo> GetSemiFinal(Entities.Campeonatos.Campeonato campeonato)
        {
            string nomeFase = "Semi Final";
            IList<DateTime> datas = new List<DateTime>();
            IList<int> ids = new List<int>();
            IList<int> idsGanhadores = new List<int>();
            IList<string> estadios = new List<string>();

            datas.Add(new DateTime(2014, 7, 8, 17, 0, 0, 0)); estadios.Add("Belo Horizonte"); ids.Add(61);
            idsGanhadores.Add(57); idsGanhadores.Add(58);
            datas.Add(new DateTime(2014, 7, 9, 17, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(62);
            idsGanhadores.Add(59); idsGanhadores.Add(60);


            int rodada = 6;
            string nomeGrupo = " ";

            return base.GetJogosSemi(campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids, idsGanhadores);
        }
        public IList<Entities.Campeonatos.Jogo> GetFinal(Entities.Campeonatos.Campeonato campeonato)
        {
            string nomeFase = "Final";
            IList<DateTime> datas = new List<DateTime>();
            IList<int> ids = new List<int>();
            IList<int> idsGanhadores = new List<int>();
            IList<string> estadios = new List<string>();

            datas.Add(new DateTime(2014, 7, 12, 17, 0, 0, 0)); estadios.Add("Brasília"); ids.Add(63);
            idsGanhadores.Add(61); idsGanhadores.Add(62);
            datas.Add(new DateTime(2014, 7, 13, 16, 0, 0, 0)); estadios.Add("São Paulo"); ids.Add(64);
            idsGanhadores.Add(61); idsGanhadores.Add(61);


            int rodada = 6;
            string nomeGrupo = " ";

            return base.GetJogosFinal(campeonato, rodada, nomeGrupo, nomeFase, datas, estadios, ids, idsGanhadores);
        }

        #endregion
    }
}
