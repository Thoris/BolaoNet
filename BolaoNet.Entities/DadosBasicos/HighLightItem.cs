using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.DadosBasicos
{
    public class HighLightItem : Base.BaseEntity
    {

        #region Properties

        public string Titulo {get;set;}
        public Color ForeColor{get;set;}
        public Color BackColor{get;set;}
        public int Posicao{get;set;}

        #endregion

    }
}
