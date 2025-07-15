using System;

namespace ScriptureMemorizer
{
    public class ScriptureReference
    {
        private string _book;
        private int _chapter;
        private int _verseStart;
        private int? _verseEnd;

        public ScriptureReference(string book, int chapter, int verse)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verse;
            _verseEnd = null;
        }

        public ScriptureReference(string book, int chapter, int verseStart, int verseEnd)
        {
            _book = book;
            _chapter = chapter;
            _verseStart = verseStart;
            _verseEnd = verseEnd;
        }

        public static ScriptureReference Parse(string reference)
        {
            var parts = reference.Split(' ', 2);
            string book = parts[0];
            string[] chapterVerse = parts[1].Split(':');
            int chapter = int.Parse(chapterVerse[0]);

            if (chapterVerse[1].Contains("-"))
            {
                var verses = chapterVerse[1].Split('-');
                return new ScriptureReference(book, chapter, int.Parse(verses[0]), int.Parse(verses[1]));
            }
            else
            {
                return new ScriptureReference(book, chapter, int.Parse(chapterVerse[1]));
            }
        }

        public override string ToString()
        {
            return _verseEnd.HasValue
                ? $"{_book} {_chapter}:{_verseStart}-{_verseEnd.Value}"
                : $"{_book} {_chapter}:{_verseStart}";
        }
    }
}
