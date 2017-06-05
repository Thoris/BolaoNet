using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Domain.Entities.Boloes
{
    public class BolaoCampeonatoClassificacaoUsuario : Base.AuditModel
    {
        #region Properties

        [Key, Column(Order = 0)]        
        public string NomeCampeonato { get; set; }
        //[ForeignKey("NomeCampeonato")]
        //public virtual Campeonatos.Campeonato Campeonato { get; set; }

        [Key, Column(Order = 1)]
        public string NomeFase { get; set; }
        [ForeignKey ("NomeCampeonato, NomeFase")]
        public virtual Campeonatos.CampeonatoFase CampeonatoFase { get; set; }

        [Key, Column(Order = 2)]
        public string NomeGrupo { get; set; }
        [ForeignKey("NomeCampeonato, NomeGrupo")]
        public virtual Campeonatos.CampeonatoGrupo CampeonatoGrupo { get; set; }

        [Key, Column(Order = 3)]
        public string NomeTime { get; set; }
        [ForeignKey ("NomeTime")]
        public virtual DadosBasicos.Time Time { get; set; }

        [Key, Column(Order = 4)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao { get; set; }


        [Key, Column(Order = 5)]
        public string UserName { get; set; }
        [ForeignKey ("UserName")]
        public virtual Users.User User { get; set; }



        public int? Posicao { get; set; }

        public int? TotalVitorias { get; set; }

        public int? TotalDerrotas { get; set; }

        public int? TotalEmpates { get; set; }

        public int? TotalGolsContra { get; set; }

        public int? TotalGolsPro { get; set; }

        public int? TotalPontos { get; set; }

        #endregion

        #region Constructors/Destructors

        public BolaoCampeonatoClassificacaoUsuario()
        {

        }
        public BolaoCampeonatoClassificacaoUsuario(string nomeCampeonato, string nomeFase, string nomeGrupo, string nomeTime, string userName, string nomeBolao)
        {
            this.NomeCampeonato = nomeCampeonato;
            this.NomeFase = nomeFase;
            this.NomeGrupo = nomeGrupo;
            this.NomeTime = nomeTime;
            this.UserName = userName;
            this.NomeBolao = nomeBolao;
        }

        #endregion
    }
}
