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
        
        [Key, Column(Order = 2)]
        public string NomeGrupo { get; set; }
        
        [Key, Column(Order = 3)]
        public string NomeFase { get; set; }
        
        [Key, Column(Order = 4)]
        public string NomeBolao { get; set; }
        
        [Key, Column(Order = 5)]
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public virtual Users.User User { get; set; }
        
        [Key, Column(Order = 6)]
        public int Rodada { get; set; }

        [ForeignKey("Posicao, NomeCampeonato, NomeGrupo, NomeFase, NomeBolao")]
        public virtual BolaoPontoRodada BolaoPontoRodada { get; set; }

        #endregion

        #region Constructors/Destructors

        public BolaoPontoRodadaUsuario(int posicao, string nomeCampeonato, string nomeGrupo, string nomeFase, string nomeBolao, string userName, int rodada)
        {
            this.Posicao = posicao;
            this.NomeCampeonato = nomeCampeonato;
            this.NomeGrupo = nomeGrupo;
            this.NomeFase = nomeFase;
            this.NomeBolao = nomeBolao;
            this.UserName = userName;
            this.Rodada = rodada;
        }
        public BolaoPontoRodadaUsuario()
        {

        }

        #endregion
    }
}
