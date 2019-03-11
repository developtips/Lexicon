namespace Lexicon.DAL.Model
{
    public class PerusalDetail
    {
        public int Id { get; set; }
        public int HeaderId { get; set; }
        public int WordId { get; set; }

        public Word Word { get; set; }
        public PerusalHeader PerusalHeader { get; set; }
    }
}