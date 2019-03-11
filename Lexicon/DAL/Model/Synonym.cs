using Lexicon.DAL.Entities;

namespace Lexicon.DAL.Model
{
    public class Synonym: Entity
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public int SynonymWordId { get; set; }
        public virtual Word Word { get; set; }
        public virtual Word SynonymWord { get; set; }

    }
}