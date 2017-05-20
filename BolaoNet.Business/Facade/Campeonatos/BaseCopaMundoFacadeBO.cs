using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Facade.Campeonatos
{
    public class BaseCopaMundoFacadeBO
    {
        #region Variables

        protected Interfaces.DadosBasicos.ITimeBO _timeBO;
        protected Interfaces.Campeonatos.ICampeonatoBO _campeonatoBO;
        protected Interfaces.Campeonatos.ICampeonatoTimeBO _campeonatoTimeBO;
        protected Interfaces.Campeonatos.ICampeonatoFaseBO _campeonatoFaseBO;
        protected Interfaces.Campeonatos.ICampeonatoGrupoBO _campeonatoGrupoBO;
        protected Interfaces.Campeonatos.ICampeonatoGrupoTimeBO _campeonatoGrupoTimeBO;
        protected Interfaces.DadosBasicos.IEstadioBO _estadioBO;
        protected Interfaces.Campeonatos.IJogoBO _jogoBO;
        
        protected Interfaces.Facade.ICampeonatoFacadeBO _campeonatoFacadeBO;
        
        #endregion

        #region Constructors/Destructors

        public BaseCopaMundoFacadeBO(Interfaces.IFactoryBO factory)
        {            
            _timeBO = factory.CreateTimeBO();
            _campeonatoBO = factory.CreateCampeonatoBO();
            _campeonatoTimeBO = factory.CreateCampeonatoTimeBO();
            _campeonatoFaseBO = factory.CreateCampeonatoFaseBO();
            _campeonatoGrupoBO = factory.CreateCampeonatoGrupoBO();
            _campeonatoGrupoTimeBO = factory.CreateCampeonatoGrupoTimeBO();
            _estadioBO = factory.CreateEstadioBO();
            _jogoBO = factory.CreateJogoBO();
            
        }

        #endregion

        #region Methods

        public Entities.Campeonatos.Jogo CreateJogo(string nomeCampeonato, DateTime dataJogo, string nomeEstadio, string nomeFase, string nomeGrupo, int rodada, int id, string pendenteTime1NomeGrupo, int pendenteTime1PosGrupo, string pendenteTime2NomeGrupo, int pendenteTime2PosGrupo)
        {
            return new Entities.Campeonatos.Jogo(nomeCampeonato, id)
            {
                NomeCampeonato = nomeCampeonato,
                DataJogo = dataJogo,
                NomeEstadio = nomeEstadio,
                NomeFase = nomeFase,
                NomeGrupo = nomeGrupo,
                Rodada = rodada,
                PendenteTime1NomeGrupo = pendenteTime1NomeGrupo,
                PendenteTime1PosGrupo = pendenteTime1PosGrupo,
                PendenteTime2NomeGrupo = pendenteTime2NomeGrupo,
                PendenteTime2PosGrupo = pendenteTime2PosGrupo,
                DescricaoTime1 = pendenteTime1PosGrupo + pendenteTime1NomeGrupo,
                DescricaoTime2 = pendenteTime2PosGrupo + pendenteTime2NomeGrupo
            };
        }        
        public Entities.Campeonatos.Jogo CreateJogo(string nomeCampeonato, DateTime dataJogo, string nomeEstadio, string nomeFase, string nomeGrupo,int rodada, int id, int pendenteTime1, bool ganhadorTime1, int pendenteTime2, bool ganhadorTime2 )
        {
            string descricaoTime1 = "";
            if (ganhadorTime1)
                descricaoTime1 += "Vencedor jogo " + pendenteTime1;
            else
                descricaoTime1 += "Perdedor jogo " + pendenteTime1;

            string descricaoTime2 = "";
            if (ganhadorTime2)
                descricaoTime2 += "Vencedor jogo " + pendenteTime2;
            else
                descricaoTime2 += "Perdedor jogo " + pendenteTime2;


            return new Entities.Campeonatos.Jogo(nomeCampeonato, id)
            {
                NomeCampeonato = nomeCampeonato,
                DataJogo = dataJogo,
                NomeEstadio = nomeEstadio,
                NomeFase = nomeFase,
                NomeGrupo = nomeGrupo,
                Rodada = rodada,
                PendenteIdTime1 = pendenteTime1,
                PendenteTime1Ganhador = ganhadorTime1,
                PendenteIdTime2 = pendenteTime2,
                PendenteTime2Ganhador = ganhadorTime2,                
                DescricaoTime1 = descricaoTime1,
                DescricaoTime2 = descricaoTime2,

            };
        }        
        public Entities.Campeonatos.Jogo CreateJogo(string nomeCampeonato, DateTime dataJogo, string nomeEstadio, string nomeFase, string nomeGrupo, string nomeTime1, string nomeTime2, int rodada, int id)
        {
            return new Entities.Campeonatos.Jogo(nomeCampeonato, id)
            {
                NomeCampeonato = nomeCampeonato,
                DataJogo = dataJogo,
                NomeEstadio = nomeEstadio,
                NomeFase = nomeFase,
                NomeGrupo = nomeGrupo,
                NomeTime1 = nomeTime1,
                NomeTime2 = nomeTime2,
                Rodada = rodada
            };
        }
        
        public IList<Entities.Campeonatos.Jogo> GetJogosOitavas(Entities.Campeonatos.Campeonato campeonato, int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids)
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
            if (estadios.Count != 8)
                throw new ArgumentException("estadios.Count != 8");
            if (ids.Count != 8)
                throw new ArgumentException("ids.Count != 8");
            if (datas.Count != 8)
                throw new ArgumentException("datas.Count != 8");

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            int c = 0;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "A", 1, "B", 2));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "C", 1, "D", 2));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "B", 1, "A", 2));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "D", 1, "C", 2));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "E", 1, "F", 2));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "G", 1, "H", 2));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "F", 1, "E", 2));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], "H", 1, "G", 2));  

            return list;

        }
        public IList<Entities.Campeonatos.Jogo> GetJogosQuartas(Entities.Campeonatos.Campeonato campeonato, int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids, IList<int> idsGanhadores)
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
            if (idsGanhadores.Count != 8)
                throw new ArgumentException("idsGanhadores.Count != 8");

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            int c = 0;
            int l = 0;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], idsGanhadores[l++], true, idsGanhadores[l++], true));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], idsGanhadores[l++], true, idsGanhadores[l++], true));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], idsGanhadores[l++], true, idsGanhadores[l++], true));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], idsGanhadores[l++], true, idsGanhadores[l++], true));
            
            return list;

        }
        public IList<Entities.Campeonatos.Jogo> GetJogosSemi(Entities.Campeonatos.Campeonato campeonato, int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids, IList<int> idsGanhadores)
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
            if (estadios.Count != 2)
                throw new ArgumentException("estadios.Count != 2");
            if (ids.Count != 2)
                throw new ArgumentException("ids.Count != 2");
            if (datas.Count != 2)
                throw new ArgumentException("datas.Count != 2");
            if (idsGanhadores == null)
                throw new ArgumentException("idsGanhadores");
            if (idsGanhadores.Count != 4)
                throw new ArgumentException("idsGanhadores.Count != 4");

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            int c = 0;
            int l = 0;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], idsGanhadores[l++], true, idsGanhadores[l++], true));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], idsGanhadores[l++], true, idsGanhadores[l++], true));
            
            return list;

        }
        public IList<Entities.Campeonatos.Jogo> GetJogosFinal(Entities.Campeonatos.Campeonato campeonato, int rodada, string nomeGrupo, string nomeFase, IList<DateTime> datas, IList<string> estadios, IList<int> ids, IList<int> idsGanhadores)
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
            if (estadios.Count != 2)
                throw new ArgumentException("estadios.Count != 2");
            if (ids.Count != 2)
                throw new ArgumentException("ids.Count != 2");
            if (datas.Count != 2)
                throw new ArgumentException("datas.Count != 2");
            if (idsGanhadores == null)
                throw new ArgumentException("idsGanhadores");
            if (idsGanhadores.Count != 4)
                throw new ArgumentException("idsGanhadores.Count != 4");

            IList<Entities.Campeonatos.Jogo> list = new List<Entities.Campeonatos.Jogo>();

            int c = 0;
            int l = 0;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], idsGanhadores[l++], false, idsGanhadores[l++], false));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, rodada, ids[c], idsGanhadores[l++], true, idsGanhadores[l++], true));

            return list;

        }

        public IList<Entities.Campeonatos.Jogo> GetJogosGrupo(Entities.Campeonatos.Campeonato campeonato, string nomeGrupo, string nomeFase, IList<string> times, IList<DateTime> datas, IList<string> estadios, IList<int> ids)
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

            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, times[0], times[1], rodada, ids[0]));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, times[2], times[3], rodada, ids[1]));
            c++;
            rodada++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, times[0], times[2], rodada, ids[2]));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, times[3], times[1], rodada, ids[3]));
            c++;
            rodada++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, times[3], times[0], rodada, ids[4]));
            c++;
            list.Add(CreateJogo(campeonato.Nome, datas[c], estadios[c], nomeFase, nomeGrupo, times[1], times[2], rodada, ids[5]));

            return list;
        }
        public IList<Entities.Campeonatos.Jogo> Merge(IList<Entities.Campeonatos.Jogo> baseList, IList<Entities.Campeonatos.Jogo> mergeList)
        {
            if (baseList == null)
                throw new ArgumentException("baseList");
            if (mergeList == null)
                throw new ArgumentException("mergeList");


            for (int c = 0; c < mergeList.Count; c++)
            {
                baseList.Add(mergeList[c]);
            }
            return baseList;
        }
        public bool InsertAllJogoInformation(bool isClube, Entities.Campeonatos.Campeonato campeonato, Entities.Campeonatos.Jogo jogo)
        {

            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");
            if (jogo == null)
                throw new ArgumentException("jogo");
            //if (string.IsNullOrEmpty(jogo.NomeTime1))
            //    throw new ArgumentException("jogo.NomeTime1");
            //if (string.IsNullOrEmpty(jogo.NomeTime2))
            //    throw new ArgumentException("jogo.NomeTime2");
            if (string.IsNullOrEmpty(jogo.NomeEstadio))
                throw new ArgumentException("jogo.NomeEstadio");
            if (string.IsNullOrEmpty(jogo.NomeGrupo))
                throw new ArgumentException("jogo.NomeGrupo");
            if (string.IsNullOrEmpty(jogo.NomeFase))
                throw new ArgumentException("jogo.NomeFase");

            #region Estadio

            StoreData<Entities.DadosBasicos.Estadio>(_estadioBO,
                new Entities.DadosBasicos.Estadio(jogo.NomeEstadio));

            #endregion
            
            #region Campeonato Grupos

            StoreData<Entities.Campeonatos.CampeonatoGrupo>(_campeonatoGrupoBO,
                new Entities.Campeonatos.CampeonatoGrupo(jogo.NomeGrupo, campeonato.Nome));

            #endregion

            #region Times

            if (!string.IsNullOrEmpty(jogo.NomeTime1) && !string.IsNullOrEmpty(jogo.NomeTime2))
            {
                Entities.DadosBasicos.Time time1 = new Entities.DadosBasicos.Time(jogo.NomeTime1)
                {
                    IsClube = isClube
                };
                StoreData<Entities.DadosBasicos.Time>(_timeBO, time1);


                Entities.DadosBasicos.Time time2 = new Entities.DadosBasicos.Time(jogo.NomeTime2)
                {
                    IsClube = isClube
                };
                StoreData<Entities.DadosBasicos.Time>(_timeBO, time2);


            #endregion


            #region CampeonatosTimes


                StoreData<Entities.Campeonatos.CampeonatoTime>(_campeonatoTimeBO,
                    new Entities.Campeonatos.CampeonatoTime(time1.Nome, campeonato.Nome));
                StoreData<Entities.Campeonatos.CampeonatoTime>(_campeonatoTimeBO,
                    new Entities.Campeonatos.CampeonatoTime(time2.Nome, campeonato.Nome));

            #endregion

            #region Fases

            StoreData<Entities.Campeonatos.CampeonatoFase>(_campeonatoFaseBO,
                new Entities.Campeonatos.CampeonatoFase(jogo.NomeFase, campeonato.Nome));

            #endregion

            #region Campeonato Grupos Times


                StoreData<Entities.Campeonatos.CampeonatoGrupoTime>(_campeonatoGrupoTimeBO,
                    new Entities.Campeonatos.CampeonatoGrupoTime(time1.Nome, jogo.NomeGrupo, campeonato.Nome));
                StoreData<Entities.Campeonatos.CampeonatoGrupoTime>(_campeonatoGrupoTimeBO,
                    new Entities.Campeonatos.CampeonatoGrupoTime(time2.Nome, jogo.NomeGrupo, campeonato.Nome));
            }

            #endregion


            #region Campeonato Fases

            StoreData<Entities.Campeonatos.CampeonatoFase>(_campeonatoFaseBO,
               new Entities.Campeonatos.CampeonatoFase(jogo.NomeFase, campeonato.Nome));

            #endregion

            #region Jogos

            if (!IsAlreadyStored(jogo))
            {
                long total = _jogoBO.Insert(jogo);
            }

            #endregion


            return true;
        }
        public bool IsAlreadyStored(Entities.Campeonatos.Jogo jogo)
        {
            Entities.Campeonatos.Jogo jogoLoaded = _jogoBO.Load(jogo);

            if (jogoLoaded == null)
                return false;


            return true;
        }
        public bool StoreData<T>(Base.IGenericBusiness<T> bo, T data)
        {
            T loaded = bo.Load(data);

            if (loaded == null)
            {
                long total = bo.Insert(data);

                if (total > 0)
                    return true;
                else
                    return false;
            }

            return false;
        }

        public bool InsertResult(Entities.Campeonatos.Campeonato campeonato, int jogoID, int golsTime1, int golsTime2, int ? penaltis1, int ? penaltis2)
        {
            Entities.Campeonatos.Jogo jogo = new Entities.Campeonatos.Jogo(campeonato.Nome, jogoID);
            jogo.GolsTime1 = golsTime1;
            jogo.GolsTime2 = golsTime2;
            jogo.PenaltisTime1 = penaltis1;
            jogo.PenaltisTime2 = penaltis2;
            _campeonatoFacadeBO.InsertJogo(jogo);
            return true;
        }

        #endregion
    }
}
