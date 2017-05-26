using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.Boloes
{
    public interface IApostaExtraDao : IGenericDao<Entities.Boloes.ApostaExtra>
    {
        //bool InsertResult(string currentUserName, Entities.Boloes.ApostaExtra entry);
        IList<Entities.Boloes.ApostaExtra> GetApostasBolao(string currentUserName, Entities.Boloes.Bolao bolao);
    }
}
