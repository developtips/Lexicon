using System;
using System.Collections.ObjectModel;

namespace Lexicon.DAL.Model
{
    public class PerusalHeader
    {
        public int Id { get; set; }
        public int FromWord { get; set; }
        public int ToWord { get; set; }
        public string Comment { get; set; }
        public DateTime CreateDate { get; set; }
        public virtual Collection<PerusalDetail> Details { get; set; }
    }
}