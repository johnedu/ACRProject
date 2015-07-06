using Abp.EntityFramework;
using Bow.Administracion.Mappings;

namespace Bow.EntityFramework
{
    public class BowDbContext : AbpDbContext
    {
        //TODO: Define an IDbSet for each Entity...

        //Example:
        //public virtual IDbSet<User> Users { get; set; }

        /* NOTE: 
         *   Setting "Default" to base class helps us when working migration commands on Package Manager Console.
         *   But it may cause problems when working Migrate.exe of EF. If you will apply migrations on command line, do not
         *   pass connection string name to base classes. ABP works either way.
         */
        public BowDbContext()
            : base("Default")
        {

        }

        /* NOTE:
         *   This constructor is used by ABP to pass connection string defined in BowDataModule.PreInitialize.
         *   Notice that, actually you will not directly create an instance of BowDbContext since ABP automatically handles it.
         */
        public BowDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        protected override void OnModelCreating(System.Data.Entity.DbModelBuilder modelBuilder)
        {

            modelBuilder.HasDefaultSchema("bow");
            modelBuilder.Configurations.Add(new PreguntaFrecuenteMap());
            modelBuilder.Configurations.Add(new CasesMap());
            modelBuilder.Configurations.Add(new LocationsMap());
            modelBuilder.Configurations.Add(new NewsMap());
            modelBuilder.Configurations.Add(new DiagnosticMap());
            modelBuilder.Configurations.Add(new ReportTypeMap());
            modelBuilder.Configurations.Add(new SliderMap());
            modelBuilder.Configurations.Add(new DriverMap());

            base.OnModelCreating(modelBuilder);
        }
    }
}
