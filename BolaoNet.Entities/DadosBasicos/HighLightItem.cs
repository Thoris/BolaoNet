using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.DadosBasicos
{
    public class HighLightItem : Base.AuditModel
    {
        #region Properties

        public string Titulo { get; set; }

        public string ForeColorName { get; set; }
        [NotMapped]
        public Color ForeColor { get; set; }

        public string BackColorName { get; set; }
        [NotMapped]
        public Color BackColor { get; set; }

        public int Posicao { get; set; }

        #endregion

        #region Constructors/Destructors

        public HighLightItem()
        {

        }

        #endregion
    }
}
