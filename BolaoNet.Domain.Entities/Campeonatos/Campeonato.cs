using BolaoNet.Domain.Entities.Base.Common.Interfaces.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Campeonatos
{
    public class Campeonato : Base.BaseSelfValidationEntity, ISelfValidation
    {
        #region Properties

        [Key, Column(Order = 0)]
        public string Nome { get; set; }
        public bool IsClube { get; set; }
        public string Descricao { get; set; }
        public string FaseAtual { get; set; }
        public int RodadaAtual { get; set; }
        public bool IsIniciado { get; set; }
        public DateTime ? DataIniciado { get; set; }

        //public ICollection<DadosBasicos.Time> Times { get; set; }
        //public ICollection<Grupo> Grupos { get; set; }
        //public ICollection<Fase> Fases { get; set; }

        #endregion

        #region Constructors/Destructors

        public Campeonato()
        {

        }
        public Campeonato(string nome)
        {
            this.Nome = nome;
        }

        #endregion

        #region Methods

        public bool IsValid()
        {
            throw new NotImplementedException();
        }

        #endregion
    }
}
