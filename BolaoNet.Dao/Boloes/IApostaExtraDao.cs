using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.Boloes
{
    public interface IApostaExtraDao : IGenericDao<Entities.Boloes.ApostaExtra>
    {
        bool InsertResult(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.DadosBasicos.Time time, int posicao, Entities.Users.User validadoBy);
        IList<Entities.Boloes.ApostaExtra> GetApostasBolao(string currentUserName, Entities.Boloes.Bolao bolao);
    }
}
