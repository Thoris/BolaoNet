using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.DadosBasicos
{
    public class Time : Base.AuditModel
    {
        #region Properties

        public string Nome {get;set;}
        public bool IsClube{get;set;}
        public Image Escudo{get;set;}
        public DateTime Fundacao{get;set;}
        public string Site{get;set;}
        public string Pais{get;set;}
        public string Estado{get;set;}
        public string Cidade{get;set;}
        public string Descricao{get;set;}
        public string NomeMascote{get;set;}
        public Image Mascote{get;set;}

        #endregion

    }
}
