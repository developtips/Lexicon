using Lexicon.DAL.Entities;

namespace Lexicon.DAL.Model
{
    public class Symphonic: Entity
    {
        public int Id { get; set; }
        public int WordId { get; set; }
        public int SymphonicWordId { get; set; }
        public virtual Word Word { get; set; }
        public virtual Word SymphonicWord { get; set; }
    }
}