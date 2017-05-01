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

        //public DbSet<Entities.Modalidade> Modalidades { get; set; }

        #endregion

        #region Constructors/Destructors

        /// <summary>
        /// Inicializa uma nova instância da classe <see cref="UnitOfWork"/>.
        /// </summary>
        public UnitOfWork()
            : base("DBProvider")
        {


#if (DEBUG)

            //Database.SetInitializer<UnitOfWork>(new Initializer.AcademiaDataContextInitializer());
#else
            Database.SetInitializer<UnitOfWork>(new CreateDatabaseIfNotExists<UnitOfWork>());           

#endif
        }

        #endregion

        #region Comments

        //public new IDbSet<TEntity> Set<TEntity>() where TEntity : Entities.Base.BaseEntity
        //{
        //    return base.Set<TEntity>();
        //}

        //protected override void OnModelCreating(DbModelBuilder modelBuilder)
        //{
        //    var typesToRegister = Assembly.GetExecutingAssembly().GetTypes()
        //   .Where(type => !String.IsNullOrEmpty(type.Namespace))
        //   .Where(type => type.BaseType != null && type.BaseType.IsGenericType
        //        && type.BaseType.GetGenericTypeDefinition() == typeof(EntityTypeConfiguration<>));
        //    foreach (var type in typesToRegister)
        //    {
        //        dynamic configurationInstance = Activator.CreateInstance(type);
        //        modelBuilder.Configurations.Add(configurationInstance);
        //    }
        //    base.OnModelCreating(modelBuilder);
        //}
        #endregion

        #region Methods

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Removendo a pluralização de nomes das entidades
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();


            //modelBuilder.Entity<Entities.Modalidade>().ToTable("Modalidades");

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
