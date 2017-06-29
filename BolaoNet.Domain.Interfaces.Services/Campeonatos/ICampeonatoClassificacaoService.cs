using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Campeonatos
{
    public interface ICampeonatoClassificacaoService
        : Base.IGenericService<Entities.Campeonatos.CampeonatoClassificacao>
    {

        IList<Domain.Entities.Campeonatos.CampeonatoClassificacao> LoadClassificacao(
            Entities.Campeonatos.Campeonato campeonato, Entities.Campeonatos.CampeonatoFase fase, 
            Entities.Campeonatos.CampeonatoGrupo grupo, int rodada);
    }
}
