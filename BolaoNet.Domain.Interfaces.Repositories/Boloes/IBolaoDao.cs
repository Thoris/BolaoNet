using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IBolaoDao : Base.IGenericDao<Entities.Boloes.Bolao>
    {

        bool Iniciar(string currentUserName, DateTime currentDateTime, Entities.Users.User iniciadoBy, Entities.Boloes.Bolao bolao);
        bool Aguardar(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao);

        IList<Entities.Boloes.Bolao> GetBoloesDisponiveis(string currentUserName, DateTime currentDateTime);

        IList<Entities.ValueObjects.UserBoloesVO> GetBoloesUsuario(string currentUserName, DateTime currentDateTime, Entities.Users.User user);

        IList<Entities.ValueObjects.UserSaldoBolaoVO> GetBoloesSaldoUsuario(string currentUserName, DateTime currentDateTime, Entities.Users.User user);

        bool IsIniciado(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao);

    }
}
