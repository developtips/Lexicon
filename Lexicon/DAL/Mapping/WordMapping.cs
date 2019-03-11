using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Lexicon.DAL.Model;

namespace Lexicon.DAL.Mapping
{
    internal class WordMapping : EntityTypeConfiguration<Word>
    {
        public WordMapping()
        {
            ToTable("Words","Lex")
                .HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            Property(c => c.WordName)
                .IsUnicode(false)
                .IsMaxLength()
                .IsRequired()
                .HasColumnType("varchar")
                .HasMaxLength(50)
                .HasColumnName("Word")
                .IsVariableLength();

            Ignore(c=>c.ShCreateDate);
            HasMany(c=>c.FarsiDescriptions).WithRequired(c=>c.Word).HasForeignKey(c=>c.WordId).WillCascadeOnDelete(false);
            HasMany(c=>c.EnglishDescriptions).WithRequired(c=>c.Word).HasForeignKey(c=>c.WordId).WillCascadeOnDelete(false);

            HasMany(c=>c.Synonyms).WithRequired(c=>c.Word).HasForeignKey(c=>c.WordId).WillCascadeOnDelete(false);
            HasMany(c=>c.Synonyms).WithRequired(c=>c.SynonymWord).HasForeignKey(c=>c.SynonymWordId).WillCascadeOnDelete(false);

            HasMany(c=>c.Symphonics).WithRequired(c=>c.Word).HasForeignKey(c=>c.WordId).WillCascadeOnDelete(false);
            HasMany(c=>c.Symphonics).WithRequired(c=>c.SymphonicWord).HasForeignKey(c=>c.SymphonicWordId).WillCascadeOnDelete(false);
        }
    }
}