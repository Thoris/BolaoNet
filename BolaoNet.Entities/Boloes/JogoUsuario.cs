using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class JogoUsuario : Entities.Campeonatos.Jogo, Interfaces.IPontosJogosUsuarioEntity
    {
        #region Enumeration
        public enum TypeAposta
        {
            Todos = 0,
            Nao_Apostados = 1,
            Apostados = 2,
        }

        public enum TypeAutomatico
        {
            Todos = 0,
            Automatico = 1,
            Manual = 2,
        }
        #endregion

        #region Variables

        private DadosBasicos.Time _timeResult1;
        private DadosBasicos.Time _timeResult2;

        #endregion

        #region Properties

        [Key, Column(Order = 2)]
        public string NomeBolao { get; set; }
        [ForeignKey("NomeBolao")]
        public virtual Bolao Bolao { get; set; }

        [Key, Column(Order = 3)]
        public string UserName { get; set; }
        [ForeignKey("UserName")]
        public virtual Users.User User { get; set; }

        public DateTime DataAposta {get;set;}
        public bool Automatico{get;set;}

        public int ApostaTime1{get;set;}
        public int ApostaTime2{get;set;}
        public int? ApostaPenaltis1 { get; set; }
        public int? ApostaPenaltis2 { get; set; }

        public bool Valido{get;set;}


        public string NomeTimeResult1 { get; set; }
        [ForeignKey("NomeTime1Result1")]
        public virtual DadosBasicos.Time TimeResult1 { get; set; }

        public string NomeTimeResult2 { get; set; }
        [ForeignKey("TimeResult2")]
        public virtual DadosBasicos.Time TimeResult2 { get; set; }
        
        public int Pontos {get;set;}

        public bool IsEmpate {get;set;}
        public bool IsDerrota{get;set;}
        public bool IsVitoria{get;set;}
        public bool IsGolsGanhador{get;set;}
        public bool IsGolsPerdedor{get;set;}
        public bool IsResultTime1{get;set;}
        public bool IsResultTime2{get;set;}
        public bool IsVDE{get;set;}
        public bool IsErro{get;set;}
        public bool IsGolsGanhadorFora{get;set;}
        public bool IsGolsGanhadorDentro{get;set;}
        public bool IsGolsPerdedorFora{get;set;}
        public bool IsGolsPerdedorDentro{get;set;}
        public bool IsGolsEmpate{get;set;}
        public bool IsGolsTime1{get;set;}
        public bool IsGolsTime2{get;set;}
        public bool IsPlacarCheio{get;set;}
        public bool IsMultiploTime{get;set;}
        public int MultiploTime{get;set;} 

        public int Ganhador{get;set;} 
        public DateTime DataFacebook{get;set;}

        #endregion
        
        #region Constructors/Destructors

        public JogoUsuario()
        {

        }
        public JogoUsuario(string userName, string nomeBolao, string nomeCampeonato, int jogoId)
            : base(nomeCampeonato, jogoId)
        {

        }

        #endregion
    }
}
