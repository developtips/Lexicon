using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Lexicon.DAL.Model;

namespace Lexicon.DAL.Mapping
{
    internal class FarsiDescriptionMapping: EntityTypeConfiguration<FarsiDescription>
    {
        public FarsiDescriptionMapping()
        {
            ToTable("FarsiDescriptions","Lex")
                .HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.Description)
                .IsUnicode(true)
                .IsMaxLength()
                .IsRequired()
                .HasColumnType("nvarchar")
                .HasMaxLength(50)
                .IsVariableLength();

            Property(c => c.Comment)
                .IsUnicode(true)
                .IsMaxLength()
                .IsOptional()
                .HasColumnType("nvarchar")
                .HasMaxLength(150)
                .IsVariableLength();
        }
    }
}