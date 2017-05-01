using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Entities.Boloes
{
    public class JogoUsuario : Entities.Campeonatos.Jogo
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

        #region Properties
        public DateTime DataAposta {get;set;}
        public bool Automatico{get;set;}
        public int ApostaTime1{get;set;}
        public int ApostaTime2{get;set;}
        public ApostaPontos ApostaPontos{get;set;}
        public bool Valido{get;set;}
        public string UserName{get;set;}
        public Bolao Bolao{get;set;}
        public DadosBasicos.Time NomeTimeResult1{get;set;}
        public DadosBasicos.Time NomeTimeResult2{get;set;}

        public new DadosBasicos.Time Time1
        {
            get
            {
                if (this.TimeResult1 == null || string.IsNullOrEmpty(TimeResult1.Nome))
                    return base.Time1;
                else
                    return TimeResult1;
            }
            set { base.Time1 = value; }
        }
        public new DadosBasicos.Time Time2
        {
            get
            {
                if (TaimeResult2 == null || string.IsNullOrEmpty(TimeResult2.Nome))
                    return base.Time2;
                else
                    return TimeResult2;
            }
            set { base.Time2 = value; }
        }

        public DadosBasicos.Time Time1Classificado {get;set;}
        public DadosBasicos.Time Time2Classificado {get;set;}

        public int Pontos {get;set;}
        public bool IsEmpate {get;}{get;set;}
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
    }
}
