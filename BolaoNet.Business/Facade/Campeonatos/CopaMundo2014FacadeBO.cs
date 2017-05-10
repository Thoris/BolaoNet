using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Business.Facade.Campeonatos
{
    public class CopaMundo2014FacadeBO : BaseCopaMundoFacadeBO, Interfaces.Facade.Campeonatos.ICopaMundoFacadeBO
    {
        #region Variables

        //private Interfaces.Facade.ICampeonatoFacadeBO _campeonatoFacadeBO;
        private Interfaces.Campeonatos.ICampeonatoBO _campeonatoBO;
        private Interfaces.DadosBasicos.ITimeBO _timeBO;
        private Interfaces.Campeonatos.ICampeonatoFaseBO _campeonatoFaseBO;
        private Interfaces.Campeonatos.ICampeonatoGrupoBO _campeonatoGrupoBO;
        private Interfaces.Campeonatos.ICampeonatoGrupoTimeBO _campeonatoGrupoTimeBO;
        private Interfaces.DadosBasicos.IEstadioBO _estadioBO;

        #endregion

        #region Constructors/Destructors

        public CopaMundo2014FacadeBO(Interfaces.IFactoryBO factory)
        {

            _campeonatoBO = factory.CreateCampeonatoBO();
            _timeBO = factory.CreateTimeBO();
            _campeonatoFaseBO = factory.CreateCampeonatoFaseBO();
            _campeonatoGrupoBO = factory.CreateCampeonatoGrupoBO();
            _campeonatoGrupoTimeBO = factory.CreateCampeonatoGrupoTimeBO();
            _estadioBO = factory.CreateEstadioBO();
        }

        #endregion

        #region Methods

        public bool InsertAllJogoInformation(bool isClube, Entities.Campeonatos.Campeonato campeonato, Entities.Campeonatos.Jogo jogo)
        {

            if (campeonato == null)
                throw new ArgumentException("campeonato");
            if (string.IsNullOrEmpty(campeonato.Nome))
                throw new ArgumentException("campeonato.Nome");
            if (jogo == null)
                throw new ArgumentException("jogo");
            if (string.IsNullOrEmpty(jogo.NomeTime1))
                throw new ArgumentException("jogo.NomeTime1");
            if (string.IsNullOrEmpty(jogo.NomeTime2))
                throw new ArgumentException("jogo.NomeTime2");
            if (string.IsNullOrEmpty(jogo.NomeEstadio))
                throw new ArgumentException("jogo.NomeEstadio");

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

            StoreData<Entities.DadosBasicos.Estadio>(_estadioBO, new Entities.DadosBasicos.Estadio(jogo.NomeEstadio));

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

        #endregion
    }
}
