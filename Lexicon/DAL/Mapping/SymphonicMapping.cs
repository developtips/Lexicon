using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Lexicon.DAL.Model;

namespace Lexicon.DAL.Mapping
{
    internal class SymphonicMapping : EntityTypeConfiguration<Symphonic>
    {
        public SymphonicMapping()
        {
            ToTable("Symphonics","Lex")
                .HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(c=>c.SymphonicWord).WithMany().HasForeignKey(c=>c.SymphonicWordId).WillCascadeOnDelete(false);
        }
    }
}