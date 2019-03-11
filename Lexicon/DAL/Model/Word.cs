using System;
using System.Collections.Generic;
using Lexicon.DAL.Entities;

namespace Lexicon.DAL.Model
{
    public class Word:Entity
    {
        public int Id { get; set; }
        public string WordName { get; set; }
        public DateTime CreateDate { get; set; }
        public string ShCreateDate { get; set; }

        public virtual List<FarsiDescription> FarsiDescriptions { get; set; }
        public virtual List<EnglishDescription> EnglishDescriptions { get; set; }
        public virtual List<Symphonic> Symphonics { get; set; }
        public List<Synonym> Synonyms { get; set; }
    }
}