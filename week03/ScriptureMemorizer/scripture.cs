using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ScriptureMemorizer
{
    public class Scripture
    {
        private ScriptureReference _reference;
        private List<Word> _words;

        public Scripture(ScriptureReference reference, string text)
        {
            _reference = reference;
            _words = text
                .Split(' ')
                .Select(word => new Word(word))
                .ToList();
        }

        public void Display()
        {
            Console.WriteLine(_reference.ToString());
            Console.WriteLine();
            foreach (var word in _words)
            {
                Console.Write(word.ToString() + " ");
            }
            Console.WriteLine("\n");
        }

        public void HideRandomWords(int count)
        {
            var visibleWords = _words
                .Select((word, index) => new { word, index })
                .Where(x => !x.word.IsHidden)
                .ToList();

            Random rand = new Random();
            for (int i = 0; i < count && visibleWords.Count > 0; i++)
            {
                int randIndex = rand.Next(visibleWords.Count);
                visibleWords[randIndex].word.Hide();
                visibleWords.RemoveAt(randIndex);
            }
        }

        public bool AllWordsHidden()
        {
            return _words.All(w => w.IsHidden);
        }
    }
}
