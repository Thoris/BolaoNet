﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IApostaExtraUsuarioDao : Base.IGenericDao<Entities.Boloes.ApostaExtraUsuario>
    {
        //IList<Entities.Boloes.ApostaExtraUsuario> SelectByUser(string currentUserName, Entities.Boloes.Bolao bolao, string userName, string condition);
        //IList<Entities.Boloes.ApostaExtraUsuario> SelectByPosicao(string currentUserName, Entities.Boloes.Bolao bolao, int posicao, string condition);


        IList<Domain.Entities.ValueObjects.ApostaExtraUsuarioVO> GetApostasUser(string currentUserName, DateTime currentDateTime, 
            Entities.Boloes.Bolao bolao, Entities.Users.User user);

        IList<Domain.Entities.Boloes.ApostaExtraUsuario> GetApostasBolao(string currentUserName, DateTime currentDateTime,
            Entities.Boloes.Bolao bolao);
    }
}
