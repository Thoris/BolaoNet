using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.DadosBasicos
{
    public class Estadio : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 0)]
        public string Nome { get; set; }
        public string Pais { get; set; }
        public string Estado { get; set; }
        public string Cidade { get; set; }
        public long Capacidade { get; set; }
        public string Descricao { get; set; }

        [NotMapped]
        public Image Foto { get; set; }

        [ForeignKey("NomeTime")]
        public virtual DadosBasicos.Time Time { get; set; }
        public string NomeTime { get; set; }

        #endregion

        #region Constructors/Destructors

        public Estadio()
        {

        }
        public Estadio(string nome)
        {
            this.Nome = nome;
        }

        #endregion
    }
}
