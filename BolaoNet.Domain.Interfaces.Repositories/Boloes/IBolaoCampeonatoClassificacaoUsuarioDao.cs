using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IBolaoCampeonatoClassificacaoUsuarioDao : 
        Base.IGenericDao<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>
    {
        IList<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> LoadClassificacao(
            string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, 
            Entities.Campeonatos.CampeonatoFase fase, Entities.Campeonatos.CampeonatoGrupo grupo, 
            Entities.Users.User user);
    }
}
