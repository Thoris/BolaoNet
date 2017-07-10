using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IBolaoMembroDao
    {

        bool OrganizePontosRodada(string currentUserName, DateTime currentDateTime, Entities.Campeonatos.CampeonatoFase fase, 
            Entities.Campeonatos.CampeonatoGrupo grupo, Entities.Boloes.Bolao bolao, int rodada);


        IList<Entities.Boloes.BolaoMembro> GetListUsersInBolao(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao);
        IList<Entities.Boloes.BolaoMembro> GetListBolaoInUsers(string currentUserName, DateTime currentDateTime, Entities.Users.User user);

        IList<Entities.ValueObjects.UserMembroStatusVO> GetUserStatus(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao);

        bool RemoverMembroBolao(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Boloes.BolaoMembro membro);
    }
}
