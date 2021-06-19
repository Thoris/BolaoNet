﻿namespace BolaoNet.Domain.Interfaces.Services.Facade.Campeonatos
{
    public interface ICopaFacadeService
    {
        Entities.Campeonatos.Campeonato CreateCampeonato(string nomeCampeonato, bool isClube);

        bool InsertResults(string nomeCampeonato, Entities.Users.User validatedBy);
    }
}
