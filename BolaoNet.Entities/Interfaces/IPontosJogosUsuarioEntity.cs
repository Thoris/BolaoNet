using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Interfaces
{
    public interface IPontosJogosUsuarioEntity
    {
        bool IsEmpate { get; set; }
        bool IsDerrota { get; set; }
        bool IsVitoria { get; set; }
        bool IsGolsGanhador { get; set; }
        bool IsGolsPerdedor { get; set; }
        bool IsResultTime1 { get; set; }
        bool IsResultTime2 { get; set; }
        bool IsVDE { get; set; }
        bool IsErro { get; set; }
        bool IsGolsGanhadorFora { get; set; }
        bool IsGolsGanhadorDentro { get; set; }
        bool IsGolsPerdedorFora { get; set; }
        bool IsGolsPerdedorDentro { get; set; }
        bool IsGolsEmpate { get; set; }
        bool IsGolsTime1 { get; set; }
        bool IsGolsTime2 { get; set; }
        bool IsPlacarCheio { get; set; }
        bool IsMultiploTime { get; set; }
        int MultiploTime { get; set; } 
    }
}
