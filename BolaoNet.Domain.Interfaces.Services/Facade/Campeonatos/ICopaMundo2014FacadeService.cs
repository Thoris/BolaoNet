using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Facade.Campeonatos
{
    public interface ICopaMundo2014FacadeService
    {
        //Entities.Campeonatos.Campeonato Campeonato { get; }

        Entities.Campeonatos.Campeonato CreateCampeonato(string nomeCampeonato, bool isClube);

        //IList<Entities.Campeonatos.Jogo> GetJogosGrupo();

        //IList<Entities.Campeonatos.Jogo> GetOitavasFinal();

        //IList<Entities.Campeonatos.Jogo> GetQuartasFinal();

        //IList<Entities.Campeonatos.Jogo> GetSemiFinal();

        //IList<Entities.Campeonatos.Jogo> GetFinal();

        //IList<Entities.Campeonatos.CampeonatoPosicao> GetCampeonatoPosicoes();

        bool InsertResults(string nomeCampeonato, Entities.Users.User validatedBy);
        
    }
}
