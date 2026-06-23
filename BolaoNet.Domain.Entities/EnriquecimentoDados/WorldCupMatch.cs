using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolaoNet.Domain.Entities.EnriquecimentoDados
{
    public class WorldCupMatch
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
         
        public string ExternalId { get; set; } // idEvent da API

        public int LeagueId { get; set; }

        public string Season { get; set; }

        public DateTime MatchDate { get; set; }

        public string HomeTeam { get; set; }

        public string AwayTeam { get; set; }

        public int? HomeScore { get; set; }

        public int? AwayScore { get; set; }

        public string Status { get; set; } // Scheduled, Live, Finished

        public string Venue { get; set; }
        
        public string HomeTeamId { get; set; }

        public string AwayTeamId { get; set; }

        public int? HomeShots { get; set; }

        public int? AwayShots { get; set; }

        public double? HomePossession { get; set; }

        public double? AwayPossession { get; set; }

        public string Round { get; set; }

        public string Group { get; set; }

        public string Ground { get; set; }

        public DateTime? LastSync { get; set; }

        public List<MatchEvent> Events { get; set; } 
    }
}
