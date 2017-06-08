using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Campeonatos
{
    public interface ICampeonatoClassificacaoDao : Base.IGenericDao<Entities.Campeonatos.CampeonatoClassificacao>
    {
        bool LoadRodada(string currentUserName, DateTime currentDateTime, int rodada, Entities.Campeonatos.Campeonato campeonato,
            Entities.Campeonatos.CampeonatoFase currentFase, Entities.Campeonatos.CampeonatoGrupo currentGrupo);


        bool Organize(string currentUserName, DateTime currentDateTime, int currentRodada, Entities.Campeonatos.Campeonato campeonato,
            Entities.Campeonatos.CampeonatoFase currentFase, Entities.Campeonatos.CampeonatoGrupo currentGrupo);
    }
}
