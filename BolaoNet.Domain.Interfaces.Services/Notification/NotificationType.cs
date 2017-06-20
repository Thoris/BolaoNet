using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Interfaces.Services.Notification
{
    public enum NotificationType
    {
        Activation = 0,
        Welcome = 1,
        ResetPassword = 2,
        ApostasBolao = 3,
        ApostasRestantes = 4,
        PagamentosRestantes = 5,
    }
}
