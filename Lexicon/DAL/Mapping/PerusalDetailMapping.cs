using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Data.Entity.ModelConfiguration.Conventions;
using Lexicon.DAL.Model;

namespace Lexicon.DAL.Mapping
{
    internal class PerusalDetailMapping: EntityTypeConfiguration<PerusalDetail>
    {
        public PerusalDetailMapping()
        {
            ToTable("PerusalDetail", "Lex")
                .HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(c=>c.PerusalHeader).WithMany(c=>c.Details).HasForeignKey(c=>c.HeaderId).WillCascadeOnDelete(true);
            HasRequired(c=>c.Word).WithMany().HasForeignKey(c=>c.WordId).WillCascadeOnDelete(false);
        }
    }
}