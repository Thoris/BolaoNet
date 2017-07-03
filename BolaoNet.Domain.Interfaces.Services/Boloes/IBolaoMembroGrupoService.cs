using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Boloes
{
    public interface IBolaoMembroGrupoService
        : Base.IGenericService<Entities.Boloes.BolaoMembroGrupo>
    {
        IList<Entities.ValueObjects.BolaoGrupoComparacaoClassificacaoVO> LoadClassificacao(Entities.Boloes.Bolao bolao, Entities.Users.User user);
    }
}
