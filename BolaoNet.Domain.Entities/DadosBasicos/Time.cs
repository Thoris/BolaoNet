using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.DadosBasicos
{
    public class Time : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 0)]
        public string Nome { get; set; }
        public bool IsClube { get; set; }
        public DateTime ? Fundacao { get; set; }
        public string Site { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public string Descricao { get; set; }
        public string NomeMascote { get; set; }

        [NotMapped]
        public Image Escudo { get; set; }
        [NotMapped]
        public Image Mascote { get; set; }

        #endregion

        #region Constructors/Destructors

        public Time()
        {

        }
        public Time(string nome)
        {
            this.Nome = nome;
        }

        #endregion
    }
}
