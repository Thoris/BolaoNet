using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.Boloes
{
    public interface IBolaoDao : IGenericDao<Entities.Boloes.Bolao>
    {        

        bool Iniciar(string currentUserName, string iniciadoBy, Entities.Boloes.Bolao bolao);
        bool Aguardar(string currentUserName, Entities.Boloes.Bolao bolao);

    }
}
