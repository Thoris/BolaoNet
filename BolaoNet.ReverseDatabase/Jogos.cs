namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Jogos
    {
        public Jogos()
        {
            JogosUsuarios = new HashSet<JogosUsuarios>();
        }

        [Key]
        [Column(Order = 0)]
        [StringLength(50)]
        public string NomeCampeonato { get; set; }

        [Key]
        [Column(Order = 1)]
        public int IdJogo { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        [StringLength(100)]
        public string Titulo { get; set; }

        public bool? ActiveFlag { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        [StringLength(30)]
        public string NomeTime1 { get; set; }

        [StringLength(255)]
        public string DescricaoTime1 { get; set; }

        [StringLength(30)]
        public string NomeTime2 { get; set; }

        [StringLength(30)]
        public string NomeFase { get; set; }

        [StringLength(20)]
        public string NomeGrupo { get; set; }

        public short? Gols1 { get; set; }

        public short? Gols2 { get; set; }

        [StringLength(255)]
        public string DescricaoTime2 { get; set; }

        public short? Penaltis1 { get; set; }

        public short? Penaltis2 { get; set; }

        public DateTime? DataJogo { get; set; }

        public int? Rodada { get; set; }

        public bool? IsValido { get; set; }

        public DateTime? DataValidacao { get; set; }

        [StringLength(25)]
        public string ValidadoBy { get; set; }

        [StringLength(30)]
        public string NomeEstadio { get; set; }

        [StringLength(20)]
        public string PendenteTime1NomeGrupo { get; set; }

        public int? PendenteTime1PosGrupo { get; set; }

        public int? PendenteTime1JogoID { get; set; }

        public bool? PendenteTime1Ganhador { get; set; }

        [StringLength(20)]
        public string PendenteTime2NomeGrupo { get; set; }

        public int? PendenteTime2PosGrupo { get; set; }

        public int? PendenteTime2JogoID { get; set; }

        public bool? PendenteTime2Ganhador { get; set; }

        [StringLength(5)]
        public string JogoLabel { get; set; }

        public virtual Campeonatos Campeonatos { get; set; }

        public virtual CampeonatosFases CampeonatosFases { get; set; }

        public virtual CampeonatosGrupos CampeonatosGrupos { get; set; }

        public virtual CampeonatosGrupos CampeonatosGrupos1 { get; set; }

        public virtual CampeonatosGrupos CampeonatosGrupos2 { get; set; }

        public virtual CampeonatosTimes CampeonatosTimes { get; set; }

        public virtual CampeonatosTimes CampeonatosTimes1 { get; set; }

        public virtual Estadios Estadios { get; set; }

        public virtual Users Users { get; set; }

        public virtual Users Users1 { get; set; }

        public virtual Users Users2 { get; set; }

        public virtual ICollection<JogosUsuarios> JogosUsuarios { get; set; }
    }
}
