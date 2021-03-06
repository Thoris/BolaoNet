﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IApostaExtraDao : Base.IGenericDao<Entities.Boloes.ApostaExtra>
    {
        bool InsertResult(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, 
            Entities.DadosBasicos.Time time, int posicao, Entities.Users.User validadoBy);

        IList<Entities.Boloes.ApostaExtra> GetApostasBolao(string currentUserName, DateTime currentDateTime, 
            Entities.Boloes.Bolao bolao);
    }
}
