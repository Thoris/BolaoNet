using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.DadosBasicos
{
    public class Estadio : Base.BaseEntity
    {
        #region Properties

        public string Nome {get;set;}
        public string Pais{get;set;}
        public string Estado{get;set;}
        public string Cidade{get;set;}
        public Image Foto{get;set;}
        public long Capacidade{get;set;}
        public string Descricao{get;set;}
        public DadosBasicos.Time Time{get;set;}

        #endregion

    }
}
