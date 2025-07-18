using System;

namespace ScriptureMemorizer
{
    //Has a library of scriptures that can be selected at random.
    class Program
    {
        static void Main(string[] args)
        {
            // Define your library of scriptures
            List<(string reference, string text)> scriptureLibrary = new List<(string, string)>
            {
                ("Proverbs 3:5-6", "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths."),
                ("John 3:16", "For God so loved the world, that he gave his only begotten Son, that whosoever believeth in him should not perish, but have everlasting life."),
                ("2 Nephi 2:25", "Adam fell that men might be; and men are, that they might have joy."),
                ("Doctrine and Covenants 4:2", "O ye that embark in the service of God, see that ye serve him with all your heart, might, mind and strength..."),
                ("Psalm 23:1", "The Lord is my shepherd; I shall not want.")
            };

            Random rand = new Random();
            var selected = scriptureLibrary[rand.Next(scriptureLibrary.Count)];

            ScriptureReference reference = ScriptureReference.Parse(selected.reference);
            Scripture scripture = new Scripture(reference, selected.text);

            while (true)
            {
                Console.Clear();
                scripture.Display();

                if (scripture.AllWordsHidden())
                {
                    Console.WriteLine("All words are hidden. Press Enter to exit.");
                    Console.ReadLine();
                    break;
                }

                Console.WriteLine("Press Enter to hide words, or type 'quit' to exit.");
                string input = Console.ReadLine().Trim().ToLower();
                if (input == "quit") break;

                scripture.HideRandomWords(3);
            }
        }
    }
}