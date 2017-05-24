﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.Boloes
{
    public interface IBolaoDao : IGenericDao<Entities.Boloes.Bolao>
    {

        bool Iniciar(string currentUserName, DateTime currentDateTime, Entities.Users.User iniciadoBy, Entities.Boloes.Bolao bolao);
        bool Aguardar(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao);

    }
}
