using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Repositories.Boloes
{
    public interface IMensagemDao
    {
        IList<Entities.Boloes.Mensagem> GetMensagensUsuario(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user);
        int GetTotalMensagensNaoLidas(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user);
        void SetMensagensLidas(string currentUserName, DateTime currentDateTime, Entities.Boloes.Bolao bolao, Entities.Users.User user);
    }
}
