using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public class BolaoAcertoTimePonto : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 1)]
        public string NomeCampeonato { get; set; }

        [Key, Column(Order = 2)]
        public int JogoId { get; set; }


        [ForeignKey("NomeCampeonato, JogoId")]
        public virtual Campeonatos.Jogo Jogo { get; set; }

        [Key, Column(Order = 3)]
        public string NomeBolao { get; set; }

        public int Pontos { get; set; }

        #endregion

        #region Properties

        public BolaoAcertoTimePonto()
        {

        }
        public BolaoAcertoTimePonto(string nomeCampeonato, int jogoId, string nomeBolao)
        {
            this.NomeBolao = nomeBolao;
            this.JogoId = jogoId;
            this.NomeCampeonato = nomeCampeonato;
        }

        #endregion
    }
}
