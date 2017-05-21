using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class BolaoMembroClassificacao : Entities.Boloes.Pontuacao
    {
        #region Properties


        
        [Key, Column(Order = 1)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao, UserName")]
        public virtual BolaoMembro BolaoMembro { get; set; }

        [Key, Column(Order = 2)]
        public string UserName { get; set; }


        public int ? Posicao {get;set;}
        public int ? LastPosicao{get;set;}

        #endregion

        #region Constructors/Destructors

        public BolaoMembroClassificacao()
        {
        }
        public BolaoMembroClassificacao(string userName, string nomeBolao)
        {
            this.UserName = userName;
            this.NomeBolao = nomeBolao;
        }

        #endregion
    }
}
