using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IBolaoPremiacaoDao
    { 

        IList<Entities.Boloes.BolaoPremiacao> LoadPremiacaoBolao(string currentUserName, DateTime currentDateTime,
            Entities.Boloes.Bolao bolao);
    }
}
