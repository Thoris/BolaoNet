using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Data.Entity.Validation;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BolaoNet.Dao.EF
{
    public class UnitOfWork : DbContext, Base.IUnitOfWork
    {
        #region Properties

        public DbSet<Entities.Users.User> Usuarios { get; set; }
        
        public DbSet<Entities.DadosBasicos.Time> Times { get; set; }
        public DbSet<Entities.DadosBasicos.Estadio> Estadios { get; set; }
        public DbSet<Entities.DadosBasicos.PagamentoTipo> PagamentosTipo { get; set; }
        public DbSet<Entities.DadosBasicos.CriterioFixo> CriteriosFixos { get; set; }

        public DbSet<Entities.Campeonatos.Campeonato> Campeonatos { get; set; }
        public DbSet<Entities.Campeonatos.CampeonatoTime> CampeonatosTimes { get; set; }
        public DbSet<Entities.Campeonatos.CampeonatoFase> CampeonatosFases { get; set; }
        public DbSet<Entities.Campeonatos.CampeonatoGrupo> CampeonatosGrupos { get; set; }
        public DbSet<Entities.Campeonatos.CampeonatoGrupoTime> CampeonatosGruposTimes { get; set; }        
        public DbSet<Entities.Campeonatos.CampeonatoClassificacao> CampeonatosClassificacao { get; set; }
        public DbSet<Entities.Campeonatos.CampeonatoPosicao> CampeonatosPosicoes { get; set; }
        public DbSet<Entities.Campeonatos.CampeonatoHistorico> CampeonatosHistorico { get; set; }
        public DbSet<Entities.Campeonatos.Jogo> Jogos { get; set; }
        
        public DbSet<Entities.Boloes.Bolao> Boloes { get; set; }
        public DbSet<Entities.Boloes.BolaoMembro> BoloesMembros { get; set; }
        public DbSet<Entities.Boloes.BolaoMembroClassificacao> BoloesMembrosClassificacao { get; set; }
        public DbSet<Entities.Boloes.BolaoMembroGrupo> BoloesMembrosGrupos { get; set; }
        public DbSet<Entities.Boloes.BolaoMembroPonto> BoloesMembrosPontos { get; set; }
        
        public DbSet<Entities.Boloes.BolaoCriterioPontos> BoloesCriteriosPontos { get; set; }
        public DbSet<Entities.Boloes.BolaoCriterioPontosTimes> BoloesCriteriosPontosTimes { get; set; }
        public DbSet<Entities.Boloes.BolaoPremio> BoloesPremios { get; set; }
        public DbSet<Entities.Boloes.BolaoRegra> BoloesRegras { get; set; }
        public DbSet<Entities.Boloes.BolaoRequest> BoloesRequests { get; set; }
        public DbSet<Entities.Boloes.BolaoRequestStatus> BoloesRequestsStatus { get; set; }

        public DbSet<Entities.Boloes.BolaoPontuacao> BoloesPontuacao { get; set; }
        public DbSet<Entities.Boloes.BolaoPontoRodada> BoloesPontosRodadas { get; set; }
        public DbSet<Entities.Boloes.BolaoPontoRodadaUsuario> BoloesPontosRodadasUsuarios { get; set; }

        public DbSet<Entities.Boloes.ApostaExtra> ApostasExtras { get; set; }
        public DbSet<Entities.Boloes.ApostaExtraUsuario> ApostasExtrasUsuarios { get; set; }
        
        public DbSet<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario> BoloesCampeonatosClassificacaoUsuarios { get; set; }        
         
        public DbSet<Entities.Boloes.JogoUsuario> JogosUsuarios { get; set; }
        public DbSet<Entities.Boloes.Mensagem> Mensagens { get; set; }
        public DbSet<Entities.Boloes.Pagamento> Pagamentos { get; set; }
        
        //public DbSet<Entities.Boloes.Profiles> Profiles{ get; set; }
        public DbSet<Entities.Users.Role> Roles { get; set; }
        public DbSet<Entities.Users.UserInRole> UserInRole { get; set; }

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
            Database.SetInitializer<UnitOfWork>(new DropCreateDatabaseAlways<UnitOfWork>());           
            //Database.SetInitializer<UnitOfWork>(new Initializer.AcademiaDataContextInitializer());
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




            //modelBuilder.Entity<Entities.Modalidade().ToTable("Modalidades");


            modelBuilder.Entity<Entities.Users.User>().ToTable("Usuarios");
        
            modelBuilder.Entity<Entities.DadosBasicos.Time>().ToTable("Times");
            modelBuilder.Entity<Entities.DadosBasicos.Estadio>().ToTable("Estadios");
            modelBuilder.Entity<Entities.DadosBasicos.PagamentoTipo>().ToTable("PagamentosTipo");
            modelBuilder.Entity<Entities.DadosBasicos.CriterioFixo>().ToTable("CriteriosFixos");

            modelBuilder.Entity<Entities.Campeonatos.Campeonato>().ToTable("Campeonatos");
            modelBuilder.Entity<Entities.Campeonatos.CampeonatoTime>().ToTable("CampeonatosTimes");
            modelBuilder.Entity<Entities.Campeonatos.CampeonatoFase>().ToTable("CampeonatosFases");
            modelBuilder.Entity<Entities.Campeonatos.CampeonatoGrupo>().ToTable("CampeonatosGrupos");
            modelBuilder.Entity<Entities.Campeonatos.CampeonatoGrupoTime>().ToTable("CampeonatosGruposTimes");        
            modelBuilder.Entity<Entities.Campeonatos.CampeonatoClassificacao>().ToTable("CampeonatosClassificacao");
            modelBuilder.Entity<Entities.Campeonatos.CampeonatoPosicao>().ToTable("CampeonatosPosicoes");
            modelBuilder.Entity<Entities.Campeonatos.CampeonatoHistorico>().ToTable("CampeonatosHistorico");
            modelBuilder.Entity<Entities.Campeonatos.Jogo>().ToTable("Jogos");
        
            modelBuilder.Entity<Entities.Boloes.Bolao>().ToTable("Boloes");
            modelBuilder.Entity<Entities.Boloes.BolaoMembro>().ToTable("BoloesMembros");
            modelBuilder.Entity<Entities.Boloes.BolaoMembroClassificacao>().ToTable("BoloesMembrosClassificacao");
            modelBuilder.Entity<Entities.Boloes.BolaoMembroGrupo>().ToTable("BoloesMembrosGrupos");
            modelBuilder.Entity<Entities.Boloes.BolaoMembroPonto>().ToTable("BoloesMembrosPontos");
        
            modelBuilder.Entity<Entities.Boloes.BolaoCriterioPontos>().ToTable("BoloesCriteriosPontos");
            modelBuilder.Entity<Entities.Boloes.BolaoCriterioPontosTimes>().ToTable("BoloesCriteriosPontosTimes");
            modelBuilder.Entity<Entities.Boloes.BolaoPremio>().ToTable("BoloesPremios");
            modelBuilder.Entity<Entities.Boloes.BolaoRegra>().ToTable("BoloesRegras");
            modelBuilder.Entity<Entities.Boloes.BolaoRequest>().ToTable("BoloesRequests");
            modelBuilder.Entity<Entities.Boloes.BolaoRequestStatus>().ToTable("BoloesRequestsStatus");

            modelBuilder.Entity<Entities.Boloes.BolaoPontuacao>().ToTable("BoloesPontuacao");
            modelBuilder.Entity<Entities.Boloes.BolaoPontoRodada>().ToTable("BoloesPontosRodadas");
            modelBuilder.Entity<Entities.Boloes.BolaoPontoRodadaUsuario>().ToTable("BoloesPontosRodadasUsuarios");

            modelBuilder.Entity<Entities.Boloes.ApostaExtra>().ToTable("ApostasExtras");
            modelBuilder.Entity<Entities.Boloes.ApostaExtraUsuario>().ToTable("ApostasExtrasUsuarios");
        
            modelBuilder.Entity<Entities.Boloes.BolaoCampeonatoClassificacaoUsuario>().ToTable("BoloesCampeonatosClassificacaoUsuarios");        
         
            modelBuilder.Entity<Entities.Boloes.JogoUsuario>().ToTable("JogosUsuarios");
            modelBuilder.Entity<Entities.Boloes.Mensagem>().ToTable("Mensagens");
            modelBuilder.Entity<Entities.Boloes.Pagamento>().ToTable("Pagamentos");
        
            //modelBuilder.Entity<Entities.Boloes.Profiles>().ToTable(" Profiles");
            modelBuilder.Entity<Entities.Users.Role>().ToTable("Roles");
            modelBuilder.Entity<Entities.Users.UserInRole>().ToTable("UserInRole");




            //modelBuilder.Entity<Entities.Modalidade>().ToTable("Modalidades");


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
