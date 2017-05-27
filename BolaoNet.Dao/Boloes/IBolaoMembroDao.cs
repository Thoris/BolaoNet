using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.Boloes
{
    public interface IBolaoMembroDao
    {

        bool OrganizePontosRodada(string currentUserName, DateTime currentDateTime, Entities.Campeonatos.CampeonatoFase fase, 
            Entities.Campeonatos.CampeonatoGrupo grupo, Entities.Boloes.Bolao bolao, int rodada);


        IList<Entities.Boloes.BolaoMembro> GetListUsersInBolao(string currentUserName, Entities.Boloes.Bolao bolao);

    }
}
