using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IApostaExtraService 
        : Base.IGenericService<Entities.Boloes.ApostaExtra>
    {

        bool InsertResult(Entities.Boloes.Bolao bolao, Entities.DadosBasicos.Time time, int posicao, 
            Entities.Users.User validadoBy);

        IList<Entities.Boloes.ApostaExtra> GetApostasBolao(Entities.Boloes.Bolao bolao);
    }
}
