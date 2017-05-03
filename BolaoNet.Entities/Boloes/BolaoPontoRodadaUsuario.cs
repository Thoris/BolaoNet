using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoPontoRodadaUsuario : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 0)]
        public int Posicao { get; set; }

        [Key, Column(Order = 1)]
        public string NomeCampeonato { get; set; }
        [ForeignKey("NomeCampeonato")]
        public virtual Campeonatos.Campeonato Campeonato { get; set; }

        [Key, Column(Order = 2)]
        public string NomeGrupo { get; set; }
        [ForeignKey("NomeGrupo")]
        public virtual Campeonatos.Grupo Grupo { get; set; }

        [Key, Column(Order = 3)]
        public string NomeFase { get; set; }
        [ForeignKey("NomeFase")]
        public virtual Campeonatos.Fase Fase { get; set; }

        [Key, Column(Order = 4)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao { get; set; }

        [Key, Column(Order = 5)]
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public virtual Users.User User { get; set; }

        public string Titulo { get; set; }
        public int Pontos { get; set; }
        public DateTime DataValidacao { get; set; }


        #endregion
    }
}
