using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Infra.Data.EF
{
    public class UnitOfWork : DbContext, Base.IUnitOfWork
    {
        #region Properties

        public DbSet<Domain.Entities.Users.User> Usuarios { get; set; }
        
        public DbSet<Domain.Entities.DadosBasicos.Time> Times { get; set; }
        public DbSet<Domain.Entities.DadosBasicos.Estadio> Estadios { get; set; }
        public DbSet<Domain.Entities.DadosBasicos.PagamentoTipo> PagamentosTipo { get; set; }
        public DbSet<Domain.Entities.DadosBasicos.CriterioFixo> CriteriosFixos { get; set; }

        public DbSet<Domain.Entities.Campeonatos.Campeonato> Campeonatos { get; set; }
        public DbSet<Domain.Entities.Campeonatos.CampeonatoTime> CampeonatosTimes { get; set; }
        public DbSet<Domain.Entities.Campeonatos.CampeonatoFase> CampeonatosFases { get; set; }
        public DbSet<Domain.Entities.Campeonatos.CampeonatoGrupo> CampeonatosGrupos { get; set; }
        public DbSet<Domain.Entities.Campeonatos.CampeonatoGrupoTime> CampeonatosGruposTimes { get; set; }        
        public DbSet<Domain.Entities.Campeonatos.CampeonatoClassificacao> CampeonatosClassificacao { get; set; }
        public DbSet<Domain.Entities.Campeonatos.CampeonatoPosicao> CampeonatosPosicoes { get; set; }
        public DbSet<Domain.Entities.Campeonatos.CampeonatoHistorico> CampeonatosHistorico { get; set; }
        public DbSet<Domain.Entities.Campeonatos.Jogo> Jogos { get; set; }
        
        public DbSet<Domain.Entities.Boloes.Bolao> Boloes { get; set; }
        public DbSet<Domain.Entities.Boloes.BolaoMembro> BoloesMembros { get; set; }
        public DbSet<Domain.Entities.Boloes.BolaoMembroClassificacao> BoloesMembrosClassificacao { get; set; }
        public DbSet<Domain.Entities.Boloes.BolaoMembroGrupo> BoloesMembrosGrupos { get; set; }
        public DbSet<Domain.Entities.Boloes.BolaoMembroPonto> BoloesMembrosPontos { get; set; }
        
        public DbSet<Domain.Entities.Boloes.BolaoCriterioPontos> BoloesCriteriosPontos { get; set; }
        public DbSet<Domain.Entities.Boloes.BolaoCriterioPontosTimes> BoloesCriteriosPontosTimes { get; set; }
        public DbSet<Domain.Entities.Boloes.BolaoPremio> BoloesPremios { get; set; }
        public DbSet<Domain.Entities.Boloes.BolaoRegra> BoloesRegras { get; set; }
        public DbSet<Domain.Entities.Boloes.BolaoRequest> BoloesRequests { get; set; }
        public DbSet<Domain.Entities.Boloes.BolaoRequestStatus> BoloesRequestsStatus { get; set; }

        public DbSet<Domain.Entities.Boloes.BolaoPontuacao> BoloesPontuacao { get; set; }
        public DbSet<Domain.Entities.Boloes.BolaoPontoRodada> BoloesPontosRodadas { get; set; }
        public DbSet<Domain.Entities.Boloes.BolaoPontoRodadaUsuario> BoloesPontosRodadasUsuarios { get; set; }

        public DbSet<Domain.Entities.Boloes.ApostaExtra> ApostasExtras { get; set; }
        public DbSet<Domain.Entities.Boloes.ApostaExtraUsuario> ApostasExtrasUsuarios { get; set; }
        
        public DbSet<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> BoloesCampeonatosClassificacaoUsuarios { get; set; }        
         
        public DbSet<Domain.Entities.Boloes.JogoUsuario> JogosUsuarios { get; set; }
        public DbSet<Domain.Entities.Boloes.Mensagem> Mensagens { get; set; }
        public DbSet<Domain.Entities.Boloes.Pagamento> Pagamentos { get; set; }
        
        //public DbSet<Domain.Entities.Boloes.Profiles> Profiles{ get; set; }
        public DbSet<Domain.Entities.Users.Role> Roles { get; set; }
        public DbSet<Domain.Entities.Users.UserInRole> UserInRole { get; set; }

        public DbSet<Domain.Entities.Boloes.BolaoHistorico> BoloesHistorico { get; set; }

        public DbSet<Domain.Entities.LogReporting.LogEvent> Logging { get; set; }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="UnitOfWork"/>.
        /// </summary>
        public UnitOfWork()
            : base("DBProvider")
        {


#if (DEBUG)

            //Database.SetInitializer<UnitOfWork>(new CreateDatabaseIfNotExists<UnitOfWork>());           
            //Database.SetInitializer<UnitOfWork>(new DropCreateDatabaseAlways<UnitOfWork>());           
            //Database.SetInitializer<UnitOfWork>(new Initializers.SqlDataContextInitializer());
#else
            Database.SetInitializer<UnitOfWork>(new CreateDatabaseIfNotExists<UnitOfWork>());           

#endif
            //Dentro do construtor, eu costumo desabilitar o Lazy Loading, esse mecanismo faz com 
            //que o Entity Framework carregue automaticamente os relacionamentos em memória, 
            //o que pode causar perda de performance ao fazer um select na base de dados, 
            //quando essa opção é desabilitada (deixado como false), ele não carrega as dependências 
            //automaticamente e quando for necessário carregar, basta usar o método Include():
            Configuration.LazyLoadingEnabled = false;


            //Eu também costumo desabilitar a criação de proxy, o Entity Framework por padrão cria 
            //um proxy toda vez que é instanciado uma entidade POCO para que possa ser realizado 
            //eventuais mudanças e fazer o carregamento automático das propriedades virtuais, 
            //como não estamos usando o Lazy Loading habilitado, não tem muito sentido manter a 
            //criação de proxy habilitada também.
            Configuration.ProxyCreationEnabled = false;

        }

        #endregion
        
        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Removendo a pluralização de nomes das entidades
            ////Aqui vamos remover a pluralização padrão do Etity Framework que é em inglês
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

            //Basicamente a mesma configuração, porém em relacionamenos N:N
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            
            //Desabilitamos o delete em cascata em relacionamentos 1:N evitando ter registros filhos sem registros pai
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();




            //modelBuilder.Entity<Domain.Entities.Modalidade().ToTable("Modalidades");


            modelBuilder.Entity<Domain.Entities.Users.User>().ToTable("Usuarios");
        
            modelBuilder.Entity<Domain.Entities.DadosBasicos.Time>().ToTable("Times");
            modelBuilder.Entity<Domain.Entities.DadosBasicos.Estadio>().ToTable("Estadios");
            modelBuilder.Entity<Domain.Entities.DadosBasicos.PagamentoTipo>().ToTable("PagamentosTipo");
            modelBuilder.Entity<Domain.Entities.DadosBasicos.CriterioFixo>().ToTable("CriteriosFixos");

            modelBuilder.Entity<Domain.Entities.Campeonatos.Campeonato>().ToTable("Campeonatos");
            modelBuilder.Entity<Domain.Entities.Campeonatos.CampeonatoTime>().ToTable("CampeonatosTimes");
            modelBuilder.Entity<Domain.Entities.Campeonatos.CampeonatoFase>().ToTable("CampeonatosFases");
            modelBuilder.Entity<Domain.Entities.Campeonatos.CampeonatoGrupo>().ToTable("CampeonatosGrupos");
            modelBuilder.Entity<Domain.Entities.Campeonatos.CampeonatoGrupoTime>().ToTable("CampeonatosGruposTimes");        
            modelBuilder.Entity<Domain.Entities.Campeonatos.CampeonatoClassificacao>().ToTable("CampeonatosClassificacao");
            modelBuilder.Entity<Domain.Entities.Campeonatos.CampeonatoPosicao>().ToTable("CampeonatosPosicoes");
            modelBuilder.Entity<Domain.Entities.Campeonatos.CampeonatoHistorico>().ToTable("CampeonatosHistorico");
            modelBuilder.Entity<Domain.Entities.Campeonatos.Jogo>().ToTable("Jogos");
        
            modelBuilder.Entity<Domain.Entities.Boloes.Bolao>().ToTable("Boloes");
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoMembro>().ToTable("BoloesMembros");
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoMembroClassificacao>().ToTable("BoloesMembrosClassificacao");
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoMembroGrupo>().ToTable("BoloesMembrosGrupos");
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoMembroPonto>().ToTable("BoloesMembrosPontos");
        
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoCriterioPontos>().ToTable("BoloesCriteriosPontos");
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoCriterioPontosTimes>().ToTable("BoloesCriteriosPontosTimes");
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoPremio>().ToTable("BoloesPremios");
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoRegra>().ToTable("BoloesRegras");
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoRequest>().ToTable("BoloesRequests");
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoRequestStatus>().ToTable("BoloesRequestsStatus");

            modelBuilder.Entity<Domain.Entities.Boloes.BolaoPontuacao>().ToTable("BoloesPontuacao");
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoPontoRodada>().ToTable("BoloesPontosRodadas");
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoPontoRodadaUsuario>().ToTable("BoloesPontosRodadasUsuarios");

            modelBuilder.Entity<Domain.Entities.Boloes.ApostaExtra>().ToTable("ApostasExtras");
            modelBuilder.Entity<Domain.Entities.Boloes.ApostaExtraUsuario>().ToTable("ApostasExtrasUsuarios");
        
            modelBuilder.Entity<Domain.Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>().ToTable("BoloesCampeonatosClassificacaoUsuarios");        
         
            modelBuilder.Entity<Domain.Entities.Boloes.JogoUsuario>().ToTable("JogosUsuarios");
            modelBuilder.Entity<Domain.Entities.Boloes.Mensagem>().ToTable("Mensagens");
            modelBuilder.Entity<Domain.Entities.Boloes.Pagamento>().ToTable("Pagamentos");
        
            //modelBuilder.Entity<Domain.Entities.Boloes.Profiles>().ToTable(" Profiles");
            modelBuilder.Entity<Domain.Entities.Users.Role>().ToTable("Roles");
            modelBuilder.Entity<Domain.Entities.Users.UserInRole>().ToTable("UserInRole");


            modelBuilder.Entity<Domain.Entities.Boloes.BolaoHistorico>().ToTable("BoloesHistorico");


            //modelBuilder.Entity<Domain.Entities.Modalidade>().ToTable("Modalidades");


            //Definimos usando reflexão que toda propriedade que contenha
            //"Nome da classe" + Id como "CursoId" por exemplo, seja dada como
            //chave primária, caso não tenha sido especificado
            //modelBuilder.Properties()
            //             .Where(p => p.Name == p.ReflectedType.Name + "Id")
            //             .Configure(p => p.IsKey());

            //Toda propriedade do tipo string na entidade POCO seja configurado como VARCHAR no SQL Server
            modelBuilder.Properties<string>().Configure(p => p.HasColumnType("varchar"));

            //Toda propriedade do tipo string na entidade POCO seja configurado como VARCHAR (150) no banco de dados 
            modelBuilder.Properties<string>().Configure(p => p.HasMaxLength(250));






            //modelBuilder.Configurations.Add(new Mapping.Boloes.ApostaExtraConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.ApostaExtraUsuarioConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.ApostaPontosConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.ApostasRestantesConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoCampeonatoClassificacaoUsuarioConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoCriterioPontosConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoCriterioPontosTimesConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoMembroClassificacaoConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoMembroConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoMembroGrupoConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoPontoRodadaConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoPontoRodadaUsuarioConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoPontuacaoConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoPremioConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoRegraConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoRequestConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.BolaoRequestStatusConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.CriterioConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.JogoUsuarioConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.MensagemConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Boloes.PagamentoConfiguration());
            ////modelBuilder.Configurations.Add(new Mapping.Boloes.PontuacaoConfiguration());

            //modelBuilder.Configurations.Add(new Mapping.Campeonatos.CampeonatoClassificacaoConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Campeonatos.CampeonatoConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Campeonatos.CampeonatoFaseConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Campeonatos.CampeonatoGrupoConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Campeonatos.CampeonatoGrupoTimeConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Campeonatos.CampeonatoHistoricoConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Campeonatos.CampeonatoPosicaoConfiguration());
            ////modelBuilder.Configurations.Add(new Mapping.Campeonatos.CampeonatoRecordConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Campeonatos.CampeonatoTimeConfiguration());
            ////modelBuilder.Configurations.Add(new Mapping.Campeonatos.HistoricoConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Campeonatos.JogoConfiguration());
            ////modelBuilder.Configurations.Add(new Mapping.Campeonatos.PontuacaoConfiguration());

            //modelBuilder.Configurations.Add(new Mapping.DadosBasicos.CriterioFixoConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.DadosBasicos.EstadioConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.DadosBasicos.PagamentoTipoConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.DadosBasicos.TimeConfiguration());

            //modelBuilder.Configurations.Add(new Mapping.Users.RoleConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Users.UserConfiguration());
            //modelBuilder.Configurations.Add(new Mapping.Users.UserInRoleConfiguration());


            base.OnModelCreating(modelBuilder);
        }

        //public BaseRepositoryDao<T> Repository<T>() where T : BaseEntity
        //{
        //    if (repositories == null)
        //    {
        //        repositories = new Dictionary<string, object>();
        //    }

        //    var type = typeof(T).Name;

        //    if (!repositories.ContainsKey(type))
        //    {
        //        var repositoryType = typeof(Repository<>);
        //        var repositoryInstance = Activator.CreateInstance(repositoryType.MakeGenericType(typeof(T)), context);
        //        repositories.Add(type, repositoryInstance);
        //    }
        //    return (Repository<t>)repositories[type];
        //}
        #endregion

        #region IUnitOfWork members

        /// <summary>
        /// Método que atualiza os dados na base de dados.
        /// </summary>
        /// <returns>
        /// Quantidade de registros atualizados.
        /// </returns>
        public int Save()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {

                throw ex;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
