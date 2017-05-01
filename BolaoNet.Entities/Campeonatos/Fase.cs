using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class Fase : Base.AuditModel
    {
        #region Properties

        public Campeonatos.Campeonato Campeonato {get;set;}
        public string Nome {get;set;}
        public string Descricao{get;set;}

        #endregion

    }
}
