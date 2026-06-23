using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BolaoNet.Domain.Entities.EnriquecimentoDados
{
    public class TeamAlias
    {
        [Key, Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string LocalName { get; set; }

        public string ApiName { get; set; }

        public string ApiOpenFtName { get; set; }
    }
}
