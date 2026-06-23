using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolaoNet.Domain.Entities.EnriquecimentoDados
{
    public class MatchEvent
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
         
        public string ExternalId { get; set; } // idEvent da API

        public int MatchKeyId { get; set; }

        public string EventType { get; set; } // goal, yellowcard, redcard

        public string PlayerName { get; set; }

        public string AssistPlayerName { get; set; }

        public string TeamName { get; set; }

        public string TeamExternalId { get; set; }

        public int ? Minute { get; set; }

        public int? ExtraMinute { get; set; }
         
        public bool  ? IsHomeTeam { get; set; }

        public string RawDescription { get; set; }

        public DateTime ? CreatedAt { get; set; }

        [ForeignKey(nameof(MatchKeyId))]
        public virtual WorldCupMatch Match { get; set; }

        public bool ? IsPenalty { get; set; }

        public bool ? IsOwnGoal { get; set; }
    }
}
