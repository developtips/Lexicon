using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using Lexicon.DAL.Model;

namespace Lexicon.DAL.Mapping
{
    internal class SynonymMapping : EntityTypeConfiguration<Synonym>
    {
        public SynonymMapping()
        {
            ToTable("Synonyms","Lex")
                .HasKey(c => c.Id)
                .Property(c => c.Id)
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);

            HasRequired(c => c.SynonymWord).WithMany().HasForeignKey(c => c.SynonymWordId).WillCascadeOnDelete(false);
        }
    }
}