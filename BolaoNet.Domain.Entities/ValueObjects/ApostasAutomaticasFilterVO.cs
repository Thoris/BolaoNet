using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.ValueObjects
{
    public class ApostasAutomaticasFilterVO
    {
        public int TipoAutomatico { get; set; }
        public int TipoAposta { get; set; }
        public int? Rodada { get; set; }
        public DateTime? DataInicial { get; set; }
        public DateTime? DataFinal { get; set; }
        public string NomeTime { get; set; }

        public int? ApostaTimeCasa { get; set; }
        public int? ApostaTimeFora { get; set; }
        public int? ValorInicial { get; set; }
        public int? ValorFinal { get; set; }
        public bool ValoresFixos { get; set; }

    //@CurrentLogin						varchar(25),
    //@CurrentDateTime					DateTime = null,
    //@NomeBolao							varchar(30),
    //@TipoAutomatico						int = 0,
    //-- 0 - Todos
    //-- 1 - Automatico
    //-- 2 - Manual
    //@TipoAposta							int = 0,
    //-- 0 - Todos
    //-- 1 - Não Apostados
    //-- 2 - Apostados
    //@Rodada								int = 0,
    //@DataInicial						datetime = null,
    //@DataFinal							datetime = null,
    //@NomeTime							varchar(30) = null,
    //@UserName							varchar(25),
    //@GolsTime1							smallint = 0,
    //@GolsTime2							smallint = 0,
    //@RandomInicial						smallint = 0,
    //@RandomFinal						smallint = 0,
    //@Randomizado						bit,
    }
}
