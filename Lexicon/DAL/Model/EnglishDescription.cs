using Lexicon.DAL.Entities;

namespace Lexicon.DAL.Model
{
    public class EnglishDescription: Entity
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public string Description { get; set; }
        public string Comment { get; set; }

        public virtual Word Word { get; set; }
    }
}