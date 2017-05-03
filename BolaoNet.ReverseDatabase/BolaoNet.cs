namespace BolaoNet.ReverseDatabase
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class BolaoNet : DbContext
    {
        public BolaoNet()
            : base("name=BolaoNet")
        {
        }

        public virtual DbSet<ApostasExtras> ApostasExtras { get; set; }
        public virtual DbSet<ApostasExtrasUsuarios> ApostasExtrasUsuarios { get; set; }
        public virtual DbSet<Boloes> Boloes { get; set; }
        public virtual DbSet<BoloesCampeonatosClassificacaoUsuarios> BoloesCampeonatosClassificacaoUsuarios { get; set; }
        public virtual DbSet<BoloesCriteriosPontos> BoloesCriteriosPontos { get; set; }
        public virtual DbSet<BoloesCriteriosPontosTimes> BoloesCriteriosPontosTimes { get; set; }
        public virtual DbSet<BoloesMembros> BoloesMembros { get; set; }
        public virtual DbSet<BoloesMembrosClassificacao> BoloesMembrosClassificacao { get; set; }
        public virtual DbSet<BoloesMembrosGrupo> BoloesMembrosGrupo { get; set; }
        public virtual DbSet<BoloesMembrosPontos> BoloesMembrosPontos { get; set; }
        public virtual DbSet<BoloesPontosRodadas> BoloesPontosRodadas { get; set; }
        public virtual DbSet<BoloesPontosRodadasUsuarios> BoloesPontosRodadasUsuarios { get; set; }
        public virtual DbSet<BoloesPontuacao> BoloesPontuacao { get; set; }
        public virtual DbSet<BoloesPremios> BoloesPremios { get; set; }
        public virtual DbSet<BoloesRegras> BoloesRegras { get; set; }
        public virtual DbSet<BoloesRequests> BoloesRequests { get; set; }
        public virtual DbSet<BoloesRequestsStatus> BoloesRequestsStatus { get; set; }
        public virtual DbSet<Campeonatos> Campeonatos { get; set; }
        public virtual DbSet<CampeonatosClassificacao> CampeonatosClassificacao { get; set; }
        public virtual DbSet<CampeonatosFases> CampeonatosFases { get; set; }
        public virtual DbSet<CampeonatosGrupos> CampeonatosGrupos { get; set; }
        public virtual DbSet<CampeonatosGruposTimes> CampeonatosGruposTimes { get; set; }
        public virtual DbSet<CampeonatosHistorico> CampeonatosHistorico { get; set; }
        public virtual DbSet<CampeonatosPosicoes> CampeonatosPosicoes { get; set; }
        public virtual DbSet<CampeonatosTimes> CampeonatosTimes { get; set; }
        public virtual DbSet<CriteriosFixos> CriteriosFixos { get; set; }
        public virtual DbSet<Estadios> Estadios { get; set; }
        public virtual DbSet<Jogos> Jogos { get; set; }
        public virtual DbSet<JogosUsuarios> JogosUsuarios { get; set; }
        public virtual DbSet<Mensagens> Mensagens { get; set; }
        public virtual DbSet<Pagamentos> Pagamentos { get; set; }
        public virtual DbSet<PagamentoTipo> PagamentoTipo { get; set; }
        public virtual DbSet<Profiles> Profiles { get; set; }
        public virtual DbSet<Roles> Roles { get; set; }
        public virtual DbSet<Times> Times { get; set; }
        public virtual DbSet<UserMaritalStatus> UserMaritalStatus { get; set; }
        public virtual DbSet<Users> Users { get; set; }
        public virtual DbSet<UsersInRoles> UsersInRoles { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ApostasExtras>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ApostasExtras>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<ApostasExtras>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<ApostasExtras>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ApostasExtras>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<ApostasExtras>()
                .Property(e => e.ValidadoBy)
                .IsUnicode(false);

            modelBuilder.Entity<ApostasExtras>()
                .Property(e => e.NomeTimeValidado)
                .IsUnicode(false);

            modelBuilder.Entity<ApostasExtras>()
                .HasMany(e => e.ApostasExtrasUsuarios)
                .WithRequired(e => e.ApostasExtras)
                .HasForeignKey(e => new { e.Posicao, e.NomeBolao })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<ApostasExtrasUsuarios>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ApostasExtrasUsuarios>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<ApostasExtrasUsuarios>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<ApostasExtrasUsuarios>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<ApostasExtrasUsuarios>()
                .Property(e => e.NomeTime)
                .IsUnicode(false);

            modelBuilder.Entity<Boloes>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Boloes>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Boloes>()
                .Property(e => e.TaxaParticipacao)
                .HasPrecision(19, 4);

            modelBuilder.Entity<Boloes>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Boloes>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Boloes>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Boloes>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Boloes>()
                .Property(e => e.Pais)
                .IsUnicode(false);

            modelBuilder.Entity<Boloes>()
                .Property(e => e.IniciadoBy)
                .IsUnicode(false);

            modelBuilder.Entity<Boloes>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<Boloes>()
                .HasMany(e => e.ApostasExtras)
                .WithRequired(e => e.Boloes)
                .HasForeignKey(e => e.NomeBolao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Boloes>()
                .HasMany(e => e.BoloesCampeonatosClassificacaoUsuarios)
                .WithRequired(e => e.Boloes)
                .HasForeignKey(e => e.NomeBolao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Boloes>()
                .HasMany(e => e.BoloesCriteriosPontos)
                .WithRequired(e => e.Boloes)
                .HasForeignKey(e => e.NomeBolao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Boloes>()
                .HasMany(e => e.BoloesCriteriosPontosTimes)
                .WithRequired(e => e.Boloes)
                .HasForeignKey(e => e.NomeBolao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Boloes>()
                .HasMany(e => e.BoloesMembros)
                .WithRequired(e => e.Boloes)
                .HasForeignKey(e => e.NomeBolao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Boloes>()
                .HasMany(e => e.BoloesPontosRodadas)
                .WithRequired(e => e.Boloes)
                .HasForeignKey(e => e.NomeBolao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Boloes>()
                .HasMany(e => e.BoloesPontuacao)
                .WithRequired(e => e.Boloes)
                .HasForeignKey(e => e.NomeBolao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Boloes>()
                .HasMany(e => e.BoloesPremios)
                .WithRequired(e => e.Boloes)
                .HasForeignKey(e => e.NomeBolao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Boloes>()
                .HasMany(e => e.BoloesRegras)
                .WithRequired(e => e.Boloes)
                .HasForeignKey(e => e.NomeBolao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Boloes>()
                .HasMany(e => e.Pagamentos)
                .WithRequired(e => e.Boloes)
                .HasForeignKey(e => e.NomeBolao)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoloesCampeonatosClassificacaoUsuarios>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCampeonatosClassificacaoUsuarios>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCampeonatosClassificacaoUsuarios>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCampeonatosClassificacaoUsuarios>()
                .Property(e => e.NomeFase)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCampeonatosClassificacaoUsuarios>()
                .Property(e => e.NomeGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCampeonatosClassificacaoUsuarios>()
                .Property(e => e.NomeTime)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCampeonatosClassificacaoUsuarios>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCampeonatosClassificacaoUsuarios>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCriteriosPontos>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCriteriosPontos>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCriteriosPontos>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCriteriosPontos>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCriteriosPontosTimes>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCriteriosPontosTimes>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCriteriosPontosTimes>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesCriteriosPontosTimes>()
                .Property(e => e.NomeTime)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembros>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembros>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembros>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembros>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembros>()
                .HasOptional(e => e.BoloesMembrosClassificacao)
                .WithRequired(e => e.BoloesMembros);

            modelBuilder.Entity<BoloesMembros>()
                .HasMany(e => e.BoloesMembrosGrupo)
                .WithRequired(e => e.BoloesMembros)
                .HasForeignKey(e => new { e.UserName, e.NomeBolao })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoloesMembros>()
                .HasMany(e => e.BoloesMembrosGrupo1)
                .WithRequired(e => e.BoloesMembros1)
                .HasForeignKey(e => new { e.UserNameSelecionado, e.NomeBolao })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoloesMembros>()
                .HasMany(e => e.BoloesMembrosPontos)
                .WithRequired(e => e.BoloesMembros)
                .HasForeignKey(e => new { e.UserName, e.NomeBolao })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoloesMembros>()
                .HasMany(e => e.BoloesPontosRodadasUsuarios)
                .WithOptional(e => e.BoloesMembros)
                .HasForeignKey(e => new { e.UserName, e.NomeBolao });

            modelBuilder.Entity<BoloesMembros>()
                .HasMany(e => e.JogosUsuarios)
                .WithRequired(e => e.BoloesMembros)
                .HasForeignKey(e => new { e.UserName, e.NomeBolao })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoloesMembrosClassificacao>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosClassificacao>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosClassificacao>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosClassificacao>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosGrupo>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosGrupo>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosGrupo>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosGrupo>()
                .Property(e => e.UserNameSelecionado)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosGrupo>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosPontos>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosPontos>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosPontos>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosPontos>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosPontos>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosPontos>()
                .Property(e => e.NomeFase)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesMembrosPontos>()
                .Property(e => e.NomeGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadas>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadas>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadas>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadas>()
                .Property(e => e.NomeGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadas>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadas>()
                .Property(e => e.NomeFase)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadas>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadas>()
                .HasMany(e => e.BoloesPontosRodadasUsuarios)
                .WithRequired(e => e.BoloesPontosRodadas)
                .HasForeignKey(e => new { e.Posicao, e.NomeGrupo, e.NomeCampeonato, e.NomeFase, e.NomeBolao })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<BoloesPontosRodadasUsuarios>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadasUsuarios>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadasUsuarios>()
                .Property(e => e.NomeGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadasUsuarios>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadasUsuarios>()
                .Property(e => e.NomeFase)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadasUsuarios>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontosRodadasUsuarios>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontuacao>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontuacao>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontuacao>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontuacao>()
                .Property(e => e.ForeColor)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontuacao>()
                .Property(e => e.BackColor)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPontuacao>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPremios>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPremios>()
                .Property(e => e.BackColor)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPremios>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPremios>()
                .Property(e => e.ForeColor)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPremios>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesPremios>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesRegras>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesRegras>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesRegras>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesRegras>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesRequests>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesRequests>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesRequests>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesRequests>()
                .Property(e => e.RequestedBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesRequests>()
                .Property(e => e.Owner)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesRequests>()
                .Property(e => e.AnsweredBy)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesRequests>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<BoloesRequestsStatus>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Campeonatos>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Campeonatos>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Campeonatos>()
                .Property(e => e.FaseAtual)
                .IsUnicode(false);

            modelBuilder.Entity<Campeonatos>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Campeonatos>()
                .HasMany(e => e.Boloes)
                .WithOptional(e => e.Campeonatos)
                .HasForeignKey(e => e.NomeCampeonato);

            modelBuilder.Entity<Campeonatos>()
                .HasMany(e => e.BoloesCampeonatosClassificacaoUsuarios)
                .WithRequired(e => e.Campeonatos)
                .HasForeignKey(e => e.NomeCampeonato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Campeonatos>()
                .HasMany(e => e.CampeonatosTimes)
                .WithRequired(e => e.Campeonatos)
                .HasForeignKey(e => e.NomeCampeonato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Campeonatos>()
                .HasMany(e => e.CampeonatosFases)
                .WithRequired(e => e.Campeonatos)
                .HasForeignKey(e => e.NomeCampeonato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Campeonatos>()
                .HasMany(e => e.CampeonatosGrupos)
                .WithRequired(e => e.Campeonatos)
                .HasForeignKey(e => e.NomeCampeonato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Campeonatos>()
                .HasMany(e => e.CampeonatosHistorico)
                .WithRequired(e => e.Campeonatos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Campeonatos>()
                .HasMany(e => e.Jogos)
                .WithRequired(e => e.Campeonatos)
                .HasForeignKey(e => e.NomeCampeonato)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampeonatosClassificacao>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosClassificacao>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosClassificacao>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosClassificacao>()
                .Property(e => e.NomeFase)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosClassificacao>()
                .Property(e => e.NomeTime)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosClassificacao>()
                .Property(e => e.NomeGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosFases>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosFases>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosFases>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosFases>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosFases>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosFases>()
                .HasMany(e => e.BoloesCampeonatosClassificacaoUsuarios)
                .WithRequired(e => e.CampeonatosFases)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeFase })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampeonatosFases>()
                .HasMany(e => e.BoloesMembrosPontos)
                .WithRequired(e => e.CampeonatosFases)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeFase })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampeonatosFases>()
                .HasMany(e => e.BoloesPontosRodadas)
                .WithRequired(e => e.CampeonatosFases)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeFase })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampeonatosFases>()
                .HasMany(e => e.CampeonatosClassificacao)
                .WithRequired(e => e.CampeonatosFases)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeFase })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampeonatosFases>()
                .HasMany(e => e.CampeonatosPosicoes)
                .WithRequired(e => e.CampeonatosFases)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeFase })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampeonatosFases>()
                .HasMany(e => e.Jogos)
                .WithOptional(e => e.CampeonatosFases)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeFase });

            modelBuilder.Entity<CampeonatosGrupos>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosGrupos>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosGrupos>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosGrupos>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosGrupos>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosGrupos>()
                .HasMany(e => e.BoloesCampeonatosClassificacaoUsuarios)
                .WithRequired(e => e.CampeonatosGrupos)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeGrupo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampeonatosGrupos>()
                .HasMany(e => e.BoloesMembrosPontos)
                .WithRequired(e => e.CampeonatosGrupos)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeGrupo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampeonatosGrupos>()
                .HasMany(e => e.BoloesPontosRodadas)
                .WithRequired(e => e.CampeonatosGrupos)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeGrupo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampeonatosGrupos>()
                .HasMany(e => e.CampeonatosGruposTimes)
                .WithRequired(e => e.CampeonatosGrupos)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeGrupo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampeonatosGrupos>()
                .HasMany(e => e.CampeonatosPosicoes)
                .WithRequired(e => e.CampeonatosGrupos)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeGrupo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampeonatosGrupos>()
                .HasMany(e => e.Jogos)
                .WithOptional(e => e.CampeonatosGrupos)
                .HasForeignKey(e => new { e.NomeCampeonato, e.PendenteTime2NomeGrupo });

            modelBuilder.Entity<CampeonatosGrupos>()
                .HasMany(e => e.Jogos1)
                .WithOptional(e => e.CampeonatosGrupos1)
                .HasForeignKey(e => new { e.NomeCampeonato, e.PendenteTime1NomeGrupo });

            modelBuilder.Entity<CampeonatosGrupos>()
                .HasMany(e => e.Jogos2)
                .WithOptional(e => e.CampeonatosGrupos2)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeGrupo });

            modelBuilder.Entity<CampeonatosGruposTimes>()
                .Property(e => e.NomeTime)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosGruposTimes>()
                .Property(e => e.NomeGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosGruposTimes>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosGruposTimes>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosGruposTimes>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosGruposTimes>()
                .HasMany(e => e.CampeonatosClassificacao)
                .WithRequired(e => e.CampeonatosGruposTimes)
                .HasForeignKey(e => new { e.NomeTime, e.NomeGrupo, e.NomeCampeonato })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CampeonatosHistorico>()
                .Property(e => e.Sede)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosHistorico>()
                .Property(e => e.NomeTimeCampeao)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosHistorico>()
                .Property(e => e.NomeTimeVice)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosHistorico>()
                .Property(e => e.NomeTimeTerceiro)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosHistorico>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosHistorico>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosHistorico>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosPosicoes>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosPosicoes>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosPosicoes>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosPosicoes>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosPosicoes>()
                .Property(e => e.BackColor)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosPosicoes>()
                .Property(e => e.NomeFase)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosPosicoes>()
                .Property(e => e.ForeColor)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosPosicoes>()
                .Property(e => e.NomeGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosTimes>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosTimes>()
                .Property(e => e.NomeTime)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosTimes>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosTimes>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<CampeonatosTimes>()
                .HasMany(e => e.Jogos)
                .WithOptional(e => e.CampeonatosTimes)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeTime1 });

            modelBuilder.Entity<CampeonatosTimes>()
                .HasMany(e => e.Jogos1)
                .WithOptional(e => e.CampeonatosTimes1)
                .HasForeignKey(e => new { e.NomeCampeonato, e.NomeTime2 });

            modelBuilder.Entity<CriteriosFixos>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<CriteriosFixos>()
                .HasMany(e => e.BoloesCriteriosPontos)
                .WithRequired(e => e.CriteriosFixos)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Estadios>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Estadios>()
                .Property(e => e.Pais)
                .IsUnicode(false);

            modelBuilder.Entity<Estadios>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Estadios>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Estadios>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Estadios>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Estadios>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Estadios>()
                .Property(e => e.NomeTime)
                .IsUnicode(false);

            modelBuilder.Entity<Estadios>()
                .HasMany(e => e.Jogos)
                .WithOptional(e => e.Estadios)
                .HasForeignKey(e => e.NomeEstadio);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.Titulo)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.NomeTime1)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.DescricaoTime1)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.NomeTime2)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.NomeFase)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.NomeGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.DescricaoTime2)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.ValidadoBy)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.NomeEstadio)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.PendenteTime1NomeGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.PendenteTime2NomeGrupo)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .Property(e => e.JogoLabel)
                .IsUnicode(false);

            modelBuilder.Entity<Jogos>()
                .HasMany(e => e.JogosUsuarios)
                .WithRequired(e => e.Jogos)
                .HasForeignKey(e => new { e.NomeCampeonato, e.IdJogo })
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<JogosUsuarios>()
                .Property(e => e.NomeCampeonato)
                .IsUnicode(false);

            modelBuilder.Entity<JogosUsuarios>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<JogosUsuarios>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<JogosUsuarios>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<JogosUsuarios>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<JogosUsuarios>()
                .Property(e => e.NomeTimeResult1)
                .IsUnicode(false);

            modelBuilder.Entity<JogosUsuarios>()
                .Property(e => e.NomeTimeResult2)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagens>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagens>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagens>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagens>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagens>()
                .Property(e => e.ToUser)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagens>()
                .Property(e => e.Message)
                .IsUnicode(false);

            modelBuilder.Entity<Mensagens>()
                .Property(e => e.FromUser)
                .IsUnicode(false);

            modelBuilder.Entity<Pagamentos>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Pagamentos>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Pagamentos>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Pagamentos>()
                .Property(e => e.NomeBolao)
                .IsUnicode(false);

            modelBuilder.Entity<Pagamentos>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Pagamentos>()
                .Property(e => e.Valor)
                .HasPrecision(5, 2);

            modelBuilder.Entity<Pagamentos>()
                .Property(e => e.TipoPagamento)
                .IsUnicode(false);

            modelBuilder.Entity<PagamentoTipo>()
                .Property(e => e.TipoPagamento)
                .IsUnicode(false);

            modelBuilder.Entity<PagamentoTipo>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Profiles>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Roles>()
                .HasMany(e => e.UsersInRoles)
                .WithRequired(e => e.Roles)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Times>()
                .Property(e => e.Nome)
                .IsUnicode(false);

            modelBuilder.Entity<Times>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Times>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Times>()
                .Property(e => e.Site)
                .IsUnicode(false);

            modelBuilder.Entity<Times>()
                .Property(e => e.Pais)
                .IsUnicode(false);

            modelBuilder.Entity<Times>()
                .Property(e => e.Estado)
                .IsUnicode(false);

            modelBuilder.Entity<Times>()
                .Property(e => e.Cidade)
                .IsUnicode(false);

            modelBuilder.Entity<Times>()
                .Property(e => e.Descricao)
                .IsUnicode(false);

            modelBuilder.Entity<Times>()
                .Property(e => e.NomeMascote)
                .IsUnicode(false);

            modelBuilder.Entity<Times>()
                .HasMany(e => e.ApostasExtras)
                .WithOptional(e => e.Times)
                .HasForeignKey(e => e.NomeTimeValidado);

            modelBuilder.Entity<Times>()
                .HasMany(e => e.ApostasExtrasUsuarios)
                .WithOptional(e => e.Times)
                .HasForeignKey(e => e.NomeTime);

            modelBuilder.Entity<Times>()
                .HasMany(e => e.BoloesCampeonatosClassificacaoUsuarios)
                .WithRequired(e => e.Times)
                .HasForeignKey(e => e.NomeTime)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Times>()
                .HasMany(e => e.BoloesCriteriosPontosTimes)
                .WithRequired(e => e.Times)
                .HasForeignKey(e => e.NomeTime)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Times>()
                .HasMany(e => e.CampeonatosGruposTimes)
                .WithRequired(e => e.Times)
                .HasForeignKey(e => e.NomeTime)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Times>()
                .HasMany(e => e.CampeonatosTimes)
                .WithRequired(e => e.Times)
                .HasForeignKey(e => e.NomeTime)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Times>()
                .HasMany(e => e.Estadios)
                .WithOptional(e => e.Times)
                .HasForeignKey(e => e.NomeTime);

            modelBuilder.Entity<Times>()
                .HasMany(e => e.JogosUsuarios)
                .WithOptional(e => e.Times)
                .HasForeignKey(e => e.NomeTimeResult2);

            modelBuilder.Entity<Times>()
                .HasMany(e => e.JogosUsuarios1)
                .WithOptional(e => e.Times1)
                .HasForeignKey(e => e.NomeTimeResult1);

            modelBuilder.Entity<UserMaritalStatus>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.UserName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.FullName)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.CellPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PhoneNumber)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.CompanyPhone)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.City)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Country)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.State)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Street)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.CPF)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.RG)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.MSN)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Skype)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PasswordQuestion)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PasswordAnswer)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Password)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.ActivateKey)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.Comments)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.RequestedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.ApprovedBy)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .Property(e => e.PostalCode)
                .IsUnicode(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.ApostasExtras)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.ApostasExtras1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.ApostasExtras2)
                .WithOptional(e => e.Users2)
                .HasForeignKey(e => e.ValidadoBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.ApostasExtrasUsuarios)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.ApostasExtrasUsuarios1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.ApostasExtrasUsuarios2)
                .WithRequired(e => e.Users2)
                .HasForeignKey(e => e.UserName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Boloes)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Boloes1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.IniciadoBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Boloes2)
                .WithOptional(e => e.Users2)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesCampeonatosClassificacaoUsuarios)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesCampeonatosClassificacaoUsuarios1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesCampeonatosClassificacaoUsuarios2)
                .WithRequired(e => e.Users2)
                .HasForeignKey(e => e.UserName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesCriteriosPontos)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesCriteriosPontos1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesCriteriosPontosTimes)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesCriteriosPontosTimes1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesMembros)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesMembros1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesMembros2)
                .WithRequired(e => e.Users2)
                .HasForeignKey(e => e.UserName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesMembrosClassificacao)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesMembrosClassificacao1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesMembrosGrupo)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesMembrosGrupo1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesMembrosPontos)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesMembrosPontos1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesPontosRodadas)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesPontosRodadas1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesPontosRodadasUsuarios)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesPontosRodadasUsuarios1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesPontuacao)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesPontuacao1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesPremios)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesPremios1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesRegras)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.BoloesRegras1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Campeonatos)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Campeonatos1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosClassificacao)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosClassificacao1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosFases)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosFases1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosGrupos)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosGrupos1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosGruposTimes)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosGruposTimes1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosHistorico)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosHistorico1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosPosicoes)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosPosicoes1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosTimes)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.CampeonatosTimes1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Estadios)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Estadios1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Jogos)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Jogos1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Jogos2)
                .WithOptional(e => e.Users2)
                .HasForeignKey(e => e.ValidadoBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.JogosUsuarios)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.JogosUsuarios1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Pagamentos)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Pagamentos1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Pagamentos2)
                .WithRequired(e => e.Users2)
                .HasForeignKey(e => e.UserName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Roles)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Roles1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Times)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.Times1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UsersInRoles)
                .WithOptional(e => e.Users)
                .HasForeignKey(e => e.CreatedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UsersInRoles1)
                .WithOptional(e => e.Users1)
                .HasForeignKey(e => e.ModifiedBy);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UsersInRoles2)
                .WithRequired(e => e.Users2)
                .HasForeignKey(e => e.UserName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Users>()
                .HasMany(e => e.UsersInRoles3)
                .WithRequired(e => e.Users3)
                .HasForeignKey(e => e.UserName)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<UsersInRoles>()
                .Property(e => e.RoleName)
                .IsUnicode(false);

            modelBuilder.Entity<UsersInRoles>()
                .Property(e => e.CreatedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UsersInRoles>()
                .Property(e => e.ModifiedBy)
                .IsUnicode(false);

            modelBuilder.Entity<UsersInRoles>()
                .Property(e => e.UserName)
                .IsUnicode(false);
        }
    }
}
