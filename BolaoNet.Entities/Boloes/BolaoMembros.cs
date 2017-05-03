using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoMembros : Entities.Boloes.Pontuacao
    {
        #region Properties
        
        public int Posicao {get;set;}
        public int LastPosicao{get;set;}

        [Key, Column(Order = 1)]
        public string UserName{get;set;}
        [ForeignKey("UserName")]
        public virtual Users.User User { get; set; }

        [Key, Column(Order=0)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Entities.Boloes.Bolao Bolao{get;set;}

        public string FullName{get;set;}

        #endregion

        #region Constructors/Destructors

        public BolaoMembros()
        {

        }

        #endregion
    }
}
