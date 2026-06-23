using System.Collections.Generic;

namespace BolaoNet.MVC.ViewModels.Bolao
{
    public class ApostasJogoConcluidoGolViewModel
    { 
        public string EventType { get; set; }
        public string TeamName { get; set; }
        public string PlayerName { get; set; }
        public int Minute { get; set; }
        public int ExtraMinute { get; set; }
        public bool IsPenalty { get; set; }
        public bool IsOwnGoal { get; set; }
        public bool IsHomeTeam { get; set; }
        public string RawDescription { get; set; }
        public IList<ApostaJogoUsuarioPontosViewModel> Acertadores { get; set; }  
        public int HomeScore { get; set; }
        public int AwayScore { get; set; }
    }
}
