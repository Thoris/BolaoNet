namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Users
    {
        public Users()
        {
            ApostasExtras = new HashSet<ApostasExtras>();
            ApostasExtras1 = new HashSet<ApostasExtras>();
            ApostasExtras2 = new HashSet<ApostasExtras>();
            ApostasExtrasUsuarios = new HashSet<ApostasExtrasUsuarios>();
            ApostasExtrasUsuarios1 = new HashSet<ApostasExtrasUsuarios>();
            ApostasExtrasUsuarios2 = new HashSet<ApostasExtrasUsuarios>();
            Boloes = new HashSet<Boloes>();
            Boloes1 = new HashSet<Boloes>();
            Boloes2 = new HashSet<Boloes>();
            BoloesCampeonatosClassificacaoUsuarios = new HashSet<BoloesCampeonatosClassificacaoUsuarios>();
            BoloesCampeonatosClassificacaoUsuarios1 = new HashSet<BoloesCampeonatosClassificacaoUsuarios>();
            BoloesCampeonatosClassificacaoUsuarios2 = new HashSet<BoloesCampeonatosClassificacaoUsuarios>();
            BoloesCriteriosPontos = new HashSet<BoloesCriteriosPontos>();
            BoloesCriteriosPontos1 = new HashSet<BoloesCriteriosPontos>();
            BoloesCriteriosPontosTimes = new HashSet<BoloesCriteriosPontosTimes>();
            BoloesCriteriosPontosTimes1 = new HashSet<BoloesCriteriosPontosTimes>();
            BoloesMembros = new HashSet<BoloesMembros>();
            BoloesMembros1 = new HashSet<BoloesMembros>();
            BoloesMembros2 = new HashSet<BoloesMembros>();
            BoloesMembrosClassificacao = new HashSet<BoloesMembrosClassificacao>();
            BoloesMembrosClassificacao1 = new HashSet<BoloesMembrosClassificacao>();
            BoloesMembrosGrupo = new HashSet<BoloesMembrosGrupo>();
            BoloesMembrosGrupo1 = new HashSet<BoloesMembrosGrupo>();
            BoloesMembrosPontos = new HashSet<BoloesMembrosPontos>();
            BoloesMembrosPontos1 = new HashSet<BoloesMembrosPontos>();
            BoloesPontosRodadas = new HashSet<BoloesPontosRodadas>();
            BoloesPontosRodadas1 = new HashSet<BoloesPontosRodadas>();
            BoloesPontosRodadasUsuarios = new HashSet<BoloesPontosRodadasUsuarios>();
            BoloesPontosRodadasUsuarios1 = new HashSet<BoloesPontosRodadasUsuarios>();
            BoloesPontuacao = new HashSet<BoloesPontuacao>();
            BoloesPontuacao1 = new HashSet<BoloesPontuacao>();
            BoloesPremios = new HashSet<BoloesPremios>();
            BoloesPremios1 = new HashSet<BoloesPremios>();
            BoloesRegras = new HashSet<BoloesRegras>();
            BoloesRegras1 = new HashSet<BoloesRegras>();
            Campeonatos = new HashSet<Campeonatos>();
            Campeonatos1 = new HashSet<Campeonatos>();
            CampeonatosClassificacao = new HashSet<CampeonatosClassificacao>();
            CampeonatosClassificacao1 = new HashSet<CampeonatosClassificacao>();
            CampeonatosFases = new HashSet<CampeonatosFases>();
            CampeonatosFases1 = new HashSet<CampeonatosFases>();
            CampeonatosGrupos = new HashSet<CampeonatosGrupos>();
            CampeonatosGrupos1 = new HashSet<CampeonatosGrupos>();
            CampeonatosGruposTimes = new HashSet<CampeonatosGruposTimes>();
            CampeonatosGruposTimes1 = new HashSet<CampeonatosGruposTimes>();
            CampeonatosHistorico = new HashSet<CampeonatosHistorico>();
            CampeonatosHistorico1 = new HashSet<CampeonatosHistorico>();
            CampeonatosPosicoes = new HashSet<CampeonatosPosicoes>();
            CampeonatosPosicoes1 = new HashSet<CampeonatosPosicoes>();
            CampeonatosTimes = new HashSet<CampeonatosTimes>();
            CampeonatosTimes1 = new HashSet<CampeonatosTimes>();
            Estadios = new HashSet<Estadios>();
            Estadios1 = new HashSet<Estadios>();
            Jogos = new HashSet<Jogos>();
            Jogos1 = new HashSet<Jogos>();
            Jogos2 = new HashSet<Jogos>();
            JogosUsuarios = new HashSet<JogosUsuarios>();
            JogosUsuarios1 = new HashSet<JogosUsuarios>();
            Pagamentos = new HashSet<Pagamentos>();
            Pagamentos1 = new HashSet<Pagamentos>();
            Pagamentos2 = new HashSet<Pagamentos>();
            Roles = new HashSet<Roles>();
            Roles1 = new HashSet<Roles>();
            Times = new HashSet<Times>();
            Times1 = new HashSet<Times>();
            UsersInRoles = new HashSet<UsersInRoles>();
            UsersInRoles1 = new HashSet<UsersInRoles>();
            UsersInRoles2 = new HashSet<UsersInRoles>();
            UsersInRoles3 = new HashSet<UsersInRoles>();
        }

        [Key]
        [StringLength(25)]
        public string UserName { get; set; }

        [StringLength(150)]
        public string FullName { get; set; }

        public DateTime? BirthDate { get; set; }

        public bool? Male { get; set; }

        [StringLength(20)]
        public string CellPhone { get; set; }

        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [StringLength(20)]
        public string CompanyPhone { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(25)]
        public string Country { get; set; }

        [StringLength(30)]
        public string State { get; set; }

        [StringLength(50)]
        public string Street { get; set; }

        public int? StreetNumber { get; set; }

        [StringLength(20)]
        public string CPF { get; set; }

        [StringLength(20)]
        public string RG { get; set; }

        [StringLength(100)]
        public string MSN { get; set; }

        [StringLength(100)]
        public string Skype { get; set; }

        [StringLength(200)]
        public string Email { get; set; }

        public bool? IsApproved { get; set; }

        public bool? IsLockedOut { get; set; }

        public DateTime? LastActivityDate { get; set; }

        public DateTime? LastLockoutDate { get; set; }

        public DateTime? LastLoginDate { get; set; }

        public DateTime? LastPasswordChangedDate { get; set; }

        [StringLength(200)]
        public string PasswordQuestion { get; set; }

        public short? FailedPasswordAttemptCount { get; set; }

        public DateTime? FailedPasswordAttemptWindowStart { get; set; }

        public short? FailedPasswordAnswerAttemptCount { get; set; }

        public DateTime? FailedPasswordAnswerAttemptWindowStart { get; set; }

        public short? PasswordFormat { get; set; }

        [StringLength(100)]
        public string PasswordAnswer { get; set; }

        [StringLength(100)]
        public string Password { get; set; }

        public DateTime? CreatedDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public bool? ReceiveEmails { get; set; }

        [StringLength(100)]
        public string ActivateKey { get; set; }

        [StringLength(4000)]
        public string Comments { get; set; }

        [StringLength(25)]
        public string CreatedBy { get; set; }

        [StringLength(25)]
        public string RequestedBy { get; set; }

        public DateTime? RequestedDate { get; set; }

        [StringLength(25)]
        public string ModifiedBy { get; set; }

        public bool? ActiveFlag { get; set; }

        [StringLength(25)]
        public string ApprovedBy { get; set; }

        public DateTime? ApprovedDate { get; set; }

        [StringLength(20)]
        public string PostalCode { get; set; }

        public int? IdMaritalStatus { get; set; }

        public virtual ICollection<ApostasExtras> ApostasExtras { get; set; }

        public virtual ICollection<ApostasExtras> ApostasExtras1 { get; set; }

        public virtual ICollection<ApostasExtras> ApostasExtras2 { get; set; }

        public virtual ICollection<ApostasExtrasUsuarios> ApostasExtrasUsuarios { get; set; }

        public virtual ICollection<ApostasExtrasUsuarios> ApostasExtrasUsuarios1 { get; set; }

        public virtual ICollection<ApostasExtrasUsuarios> ApostasExtrasUsuarios2 { get; set; }

        public virtual ICollection<Boloes> Boloes { get; set; }

        public virtual ICollection<Boloes> Boloes1 { get; set; }

        public virtual ICollection<Boloes> Boloes2 { get; set; }

        public virtual ICollection<BoloesCampeonatosClassificacaoUsuarios> BoloesCampeonatosClassificacaoUsuarios { get; set; }

        public virtual ICollection<BoloesCampeonatosClassificacaoUsuarios> BoloesCampeonatosClassificacaoUsuarios1 { get; set; }

        public virtual ICollection<BoloesCampeonatosClassificacaoUsuarios> BoloesCampeonatosClassificacaoUsuarios2 { get; set; }

        public virtual ICollection<BoloesCriteriosPontos> BoloesCriteriosPontos { get; set; }

        public virtual ICollection<BoloesCriteriosPontos> BoloesCriteriosPontos1 { get; set; }

        public virtual ICollection<BoloesCriteriosPontosTimes> BoloesCriteriosPontosTimes { get; set; }

        public virtual ICollection<BoloesCriteriosPontosTimes> BoloesCriteriosPontosTimes1 { get; set; }

        public virtual ICollection<BoloesMembros> BoloesMembros { get; set; }

        public virtual ICollection<BoloesMembros> BoloesMembros1 { get; set; }

        public virtual ICollection<BoloesMembros> BoloesMembros2 { get; set; }

        public virtual ICollection<BoloesMembrosClassificacao> BoloesMembrosClassificacao { get; set; }

        public virtual ICollection<BoloesMembrosClassificacao> BoloesMembrosClassificacao1 { get; set; }

        public virtual ICollection<BoloesMembrosGrupo> BoloesMembrosGrupo { get; set; }

        public virtual ICollection<BoloesMembrosGrupo> BoloesMembrosGrupo1 { get; set; }

        public virtual ICollection<BoloesMembrosPontos> BoloesMembrosPontos { get; set; }

        public virtual ICollection<BoloesMembrosPontos> BoloesMembrosPontos1 { get; set; }

        public virtual ICollection<BoloesPontosRodadas> BoloesPontosRodadas { get; set; }

        public virtual ICollection<BoloesPontosRodadas> BoloesPontosRodadas1 { get; set; }

        public virtual ICollection<BoloesPontosRodadasUsuarios> BoloesPontosRodadasUsuarios { get; set; }

        public virtual ICollection<BoloesPontosRodadasUsuarios> BoloesPontosRodadasUsuarios1 { get; set; }

        public virtual ICollection<BoloesPontuacao> BoloesPontuacao { get; set; }

        public virtual ICollection<BoloesPontuacao> BoloesPontuacao1 { get; set; }

        public virtual ICollection<BoloesPremios> BoloesPremios { get; set; }

        public virtual ICollection<BoloesPremios> BoloesPremios1 { get; set; }

        public virtual ICollection<BoloesRegras> BoloesRegras { get; set; }

        public virtual ICollection<BoloesRegras> BoloesRegras1 { get; set; }

        public virtual ICollection<Campeonatos> Campeonatos { get; set; }

        public virtual ICollection<Campeonatos> Campeonatos1 { get; set; }

        public virtual ICollection<CampeonatosClassificacao> CampeonatosClassificacao { get; set; }

        public virtual ICollection<CampeonatosClassificacao> CampeonatosClassificacao1 { get; set; }

        public virtual ICollection<CampeonatosFases> CampeonatosFases { get; set; }

        public virtual ICollection<CampeonatosFases> CampeonatosFases1 { get; set; }

        public virtual ICollection<CampeonatosGrupos> CampeonatosGrupos { get; set; }

        public virtual ICollection<CampeonatosGrupos> CampeonatosGrupos1 { get; set; }

        public virtual ICollection<CampeonatosGruposTimes> CampeonatosGruposTimes { get; set; }

        public virtual ICollection<CampeonatosGruposTimes> CampeonatosGruposTimes1 { get; set; }

        public virtual ICollection<CampeonatosHistorico> CampeonatosHistorico { get; set; }

        public virtual ICollection<CampeonatosHistorico> CampeonatosHistorico1 { get; set; }

        public virtual ICollection<CampeonatosPosicoes> CampeonatosPosicoes { get; set; }

        public virtual ICollection<CampeonatosPosicoes> CampeonatosPosicoes1 { get; set; }

        public virtual ICollection<CampeonatosTimes> CampeonatosTimes { get; set; }

        public virtual ICollection<CampeonatosTimes> CampeonatosTimes1 { get; set; }

        public virtual ICollection<Estadios> Estadios { get; set; }

        public virtual ICollection<Estadios> Estadios1 { get; set; }

        public virtual ICollection<Jogos> Jogos { get; set; }

        public virtual ICollection<Jogos> Jogos1 { get; set; }

        public virtual ICollection<Jogos> Jogos2 { get; set; }

        public virtual ICollection<JogosUsuarios> JogosUsuarios { get; set; }

        public virtual ICollection<JogosUsuarios> JogosUsuarios1 { get; set; }

        public virtual ICollection<Pagamentos> Pagamentos { get; set; }

        public virtual ICollection<Pagamentos> Pagamentos1 { get; set; }

        public virtual ICollection<Pagamentos> Pagamentos2 { get; set; }

        public virtual ICollection<Roles> Roles { get; set; }

        public virtual ICollection<Roles> Roles1 { get; set; }

        public virtual ICollection<Times> Times { get; set; }

        public virtual ICollection<Times> Times1 { get; set; }

        public virtual UserMaritalStatus UserMaritalStatus { get; set; }

        public virtual ICollection<UsersInRoles> UsersInRoles { get; set; }

        public virtual ICollection<UsersInRoles> UsersInRoles1 { get; set; }

        public virtual ICollection<UsersInRoles> UsersInRoles2 { get; set; }

        public virtual ICollection<UsersInRoles> UsersInRoles3 { get; set; }
    }
}
