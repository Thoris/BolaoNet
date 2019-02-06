using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Facade.Campeonatos
{
    public interface ICopaAmerica2019FacadeService
    { 

        Entities.Campeonatos.Campeonato CreateCampeonato(string nomeCampeonato, bool isClube);

        bool InsertResults(string nomeCampeonato, Entities.Users.User validatedBy);
    }
}
