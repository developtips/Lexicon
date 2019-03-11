using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using System.Threading;
using Lexicon.DAL.Model;

namespace Lexicon.DAL.Mapping
{
    internal class PerusalHeaderMapping: EntityTypeConfiguration<PerusalHeader>
    {
        public PerusalHeaderMapping()
        {
            ToTable("PerusalHeader","Lex")
                .HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Comment).IsOptional().IsUnicode(true).HasMaxLength(100).HasColumnType("nvarchar");
        }
    }
}