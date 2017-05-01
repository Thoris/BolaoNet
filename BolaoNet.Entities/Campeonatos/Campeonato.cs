using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Campeonatos
{
    public class Campeonato : Base.AuditModel
    {
        #region Properties
        
        public string Nome {get;set;}
        public bool IsClube{get;set;}
        public string Descricao{get;set;}
        public string FaseAtual{get;set;}
        public int RodadaAtual{get;set;}
        public bool IsIniciado{get;set;}
        public DateTime DataIniciado{get;set;}
        public IList<DadosBasicos.Time> Times{get;set;}
        public IList<Grupo> Grupos {get;set;}
        public IList<Fase> Fases{get;set;}

        #endregion
    }
}
