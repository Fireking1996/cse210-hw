using System;

namespace ScriptureMemorizer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Load a scripture reference
            ScriptureReference reference = ScriptureReference.Parse("Proverbs 3:5-6");

            // Scripture text
            string text = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. "
                        + "In all thy ways acknowledge him, and he shall direct thy paths.";

            Scripture scripture = new Scripture(reference, text);

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

                scripture.HideRandomWords(3); // Hide 3 words at a time
            }
        }
    }

    /*
     * Creativity and Stretch Features:
     * - This program exceeds the core requirements by:
     *   • Only hiding words that have not yet been hidden (stretch challenge).
     *   • Supporting scripture references with either a single verse or a range.
     *   • Using proper encapsulation: each class handles its own responsibilities.
     *   • Clear display formatting, hiding words with matching-length underscores.
     *   • Each class is placed in its own file, following C# conventions.
     */
}
