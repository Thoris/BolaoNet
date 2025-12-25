using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Campeonatos
{
    public class CampeonatoFase : Base.AuditModel
    {
        #region Contants

        public const string FaseClassificatoria = "Classificatória";
        public const string FaseDezesseisAvosFinal = "Dezesseis avos final";
        public const string FaseOitavasFinal = "Oitavas de Final";
        public const string FaseQuartasFinal = "Quartas de Final";
        public const string FaseSemiFinal = "Semi Final";
        public const string FaseFinal = "Final";


        #endregion

        #region Properties

        [Key, Column(Order = 1)]
        public string NomeCampeonato { get; set; }
        [ForeignKey("NomeCampeonato")]
        public virtual Campeonato Campeonato { get; set; }
        
        [Key, Column(Order = 2)]
        public string Nome { get; set; }
       
        public string Descricao { get; set; }
        public int? Ordem { get; set; }

        #endregion

        #region Constructors/Destructors

        public CampeonatoFase()
        {

        }
        public CampeonatoFase(string nomeFase, string nomeCampeonato)
        {
            this.Nome = nomeFase;
            this.NomeCampeonato = nomeCampeonato;
        }

        #endregion
    }
}
