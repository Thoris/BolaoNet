﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.Boloes
{
    public interface IApostaExtraUsuarioDao : IGenericDao<Entities.Boloes.ApostaExtraUsuario>
    {
        IList<Entities.Boloes.ApostaExtraUsuario> SelectByUser(string currentUserName, Entities.Boloes.Bolao bolao, string userName, string condition);
        IList<Entities.Boloes.ApostaExtraUsuario> SelectByPosicao(string currentUserName, Entities.Boloes.Bolao bolao, int posicao, string condition);

    }
}
