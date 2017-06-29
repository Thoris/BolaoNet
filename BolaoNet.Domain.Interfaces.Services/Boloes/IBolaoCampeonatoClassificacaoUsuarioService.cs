using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoCampeonatoClassificacaoUsuarioService 
        : Base.IGenericService<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>
    {
        IList<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> LoadClassificacao(
            Entities.Boloes.Bolao bolao, Entities.Campeonatos.CampeonatoFase fase, 
            Entities.Campeonatos.CampeonatoGrupo grupo, Entities.Users.User user);
    }
}
