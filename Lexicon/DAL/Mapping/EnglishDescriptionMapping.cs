using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Lexicon.DAL.Model;

namespace Lexicon.DAL.Mapping
{
    internal class EnglishDescriptionMapping : EntityTypeConfiguration<EnglishDescription>
    {
        public EnglishDescriptionMapping()
        {
            ToTable("EnglishDescriptions","Lex")
                .HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Description)
                .IsUnicode(false)
                .IsMaxLength()
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .IsVariableLength();
            Property(c => c.Comment)
                .IsUnicode(false)
                .IsMaxLength()
                .IsOptional()
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsVariableLength();
        }
    }
}