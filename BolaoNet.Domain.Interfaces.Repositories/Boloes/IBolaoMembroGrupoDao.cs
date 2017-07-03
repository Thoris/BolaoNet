using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IBolaoMembroGrupoDao
    {
        IList<Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO> LoadClassificacao(string currentUserName, DateTime currentDateTime, 
            Entities.Boloes.Bolao bolao, Entities.Users.User user);
    }
}
