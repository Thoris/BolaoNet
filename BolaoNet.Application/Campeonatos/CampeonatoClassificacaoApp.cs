using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Application.Campeonatos
{
    public class CampeonatoClassificacaoApp :
        Base.GenericApp<Domain.Entities.Campeonatos.CampeonatoClassificacao>,
        Application.Interfaces.Campeonatos.ICampeonatoClassificacaoApp
    {
        #region Properties

        private Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService Service
        {
            get { return (Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService)base._service; }
        }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa nova instância da classe <see cref="CampeonatoClassificacaoApp" />.
        /// </summary>
        public CampeonatoClassificacaoApp(Domain.Interfaces.Services.Campeonatos.ICampeonatoClassificacaoService service)
            : base (service)
        {

        }

        #endregion

        #region ICampeonatoClassificacaoApp members

        public IList<Domain.Entities.Campeonatos.CampeonatoClassificacao> LoadClassificacao(Domain.Entities.Campeonatos.Campeonato campeonato, Domain.Entities.Campeonatos.CampeonatoFase fase, Domain.Entities.Campeonatos.CampeonatoGrupo grupo, int rodada)
        {
            return Service.LoadClassificacao(campeonato, fase, grupo, rodada);
        }

        #endregion
    }
}
