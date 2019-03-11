using System;
using System.Data.Entity;
using System.Data.Entity.Validation;
using CodeFirstStoreFunctions;
using Lexicon.DAL;
using Lexicon.DAL.Mapping;
using Lexicon.DAL.Model;


namespace Ikco.Data
{
    public class MyDbContext : DbContext
    {
        public static string ConStr { get; set; } = "Server=.;Database=Lexicon;User Id=sa;Password = VSH5054;MultipleActiveResultSets=True";

        private MyDbContext(string conStr) : base(conStr)
        {
            Database.SetInitializer<DbContext>(null);
            //            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }
        private static readonly Lazy<MyDbContext> Lazy = new Lazy<MyDbContext>(() => new MyDbContext(ConStr)
        {
            Configuration = { LazyLoadingEnabled = false }
        });

        public static MyDbContext Instance => Lazy.Value.Reset();
        static MyDbContext()
        {
            System.Data.Entity.Infrastructure.Interception.DbInterception.Add(new CommandInterceptor());
        }
        public override int SaveChanges()
        {
            try
            {
                return base.SaveChanges();
            }
            catch (DbEntityValidationException ex)
            {
                var newException = new FormattedDbEntityValidationException(ex);
                throw newException;
            }
            catch (Exception ex)
            {
                var newException =
                    new ApplicationException(string.Concat(ex.GetBaseException().Message));
                throw newException;
            }
        }

        //        [DbFunction("EpDbContext", "DbConvertDateToShamsi")]
        //        public ObjectQuery<string> DbConvertDateToShamsi(DateTime date, string type)
        //        {
        //            List<ObjectParameter> parameters = new List<ObjectParameter>(2);
        //            parameters.Add(new ObjectParameter("Date", date));
        //            parameters.Add(new ObjectParameter("Type", type));
        //            var lObjectContext = ((IObjectContextAdapter)this).ObjectContext;
        //            var output = lObjectContext.
        //                    CreateQuery<string>("EpDbContext.ConvertDateToShamsi(@Date, @Type)", parameters.ToArray());
        //            return output;
        //        }
        public virtual DbSet<Word> Words { get; set; }
        public virtual DbSet<EnglishDescription> EnglishDescriptions{ get; set; }
        public virtual DbSet<FarsiDescription> FarsiDescriptions{ get; set; }
        public virtual DbSet<Synonym> Synonyms{ get; set; }
        public virtual DbSet<Symphonic> Symphonics{ get; set; }
        public virtual DbSet<PerusalHeader> PerusalHeaders{ get; set; }
        public virtual DbSet<PerusalDetail> PerusalDetails{ get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Database.Log = (query) => Debug.Write(query); // For Log to output Console
            modelBuilder.Conventions.Add(new FunctionsConvention("dbo", typeof(Functions)));
            //modelBuilder.BaseEntity<Parts>().HasRequired(a => a.Inventory).WithRequiredPrincipal(a => a.Parts);
            modelBuilder.Configurations.Add(new WordMapping());
            modelBuilder.Configurations.Add(new EnglishDescriptionMapping());
            modelBuilder.Configurations.Add(new FarsiDescriptionMapping());
            modelBuilder.Configurations.Add(new SynonymMapping());
            modelBuilder.Configurations.Add(new SymphonicMapping());
            modelBuilder.Configurations.Add(new PerusalHeaderMapping());
            modelBuilder.Configurations.Add(new PerusalDetailMapping());
        }
    }
}