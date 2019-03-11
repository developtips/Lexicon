using System;
using System.Collections.Generic;
using Lexicon.DAL.Model;

namespace Lexicon.Class
{
    internal class PerusalItrate
    {
        private int _currentIndex;
        private readonly int _totalListCount;
        private readonly List<Word> _wordsList;
        public PerusalItrate(List<Word> wordsList)
        {
            _wordsList = wordsList;
            this._currentIndex = -1;
            this._totalListCount = wordsList.Count;
        }

        public Word GetCurrentWord()
        {
            if (!ListIsEmpty())
            {
                if (this._currentIndex < this._totalListCount && this._currentIndex >= 0)
                {
                    return this._wordsList[this._currentIndex];
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public bool HasValue()
        {
            return this._wordsList.Count > 0;
        }
        public Word GetNextWord()
        {
            if (this._currentIndex < this._totalListCount)
            {
                this._currentIndex++;
                return GetCurrentWord();
            }
            return null;
        }
        public Word GetPrevWord()
        {
            if (this._currentIndex > 0)
            {
                this._currentIndex--;
                return GetCurrentWord();
            }
            return null;
        }

        private bool ListIsEmpty()
        {
            return this._wordsList.Count <= 0;
        }
    }
}