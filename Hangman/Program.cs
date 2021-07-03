using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    class Program
    {
        public static readonly string[] wordList =
        {
            "DOG", "CAT", "TROPICAL", "COUNTRY", "ISLAND", "MOUNTAIN",
            "FLIGHT", "GREEN", "PROGRAM", "ORANGE", "TOWER", "TELEPHONE",
            "FOOTBALL", "BREAD", "COMPUTER", "MUSIC", "SPORT", "PHOTOSHOP",
            "HTML", "CSHARP", "WINDOWS", "HANGMAN",
        };
        static void Main(string[] args)
        {
            UiVisualizer ui = new UiVisualizer();

            Game game = new Game(ui, wordList[(new Random()).Next(wordList.Length)]);

        }
    }
}
