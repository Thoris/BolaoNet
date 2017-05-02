using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class Historico : Base.AuditModel
    {
        #region Properties

        public string Nome { get; set; }
        public int Ano { get; set; }
        public virtual DadosBasicos.Time NomeTimeCampeao { get; set; }
        public virtual DadosBasicos.Time NomeTimeVice { get; set; }
        public virtual DadosBasicos.Time NomeTimeTerceiro { get; set; }
        public int FinalTime1 { get; set; }
        public int FinalTime2 { get; set; }
        public int FinalPenaltis1 { get; set; }
        public int FinalPenaltis2 { get; set; }
        public string Sede { get; set; }

        #endregion

        #region Constructors/Destructors

        public Historico()
        {

        }

        #endregion
    }
}
