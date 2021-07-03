using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public interface IUiVisualizer
    {
        string WelcomeScreen();  // it will priint welcome screen
        string MrHangman(int wrongGuessCount);  // it will print hangman
        string ResponseWord(IEnumerable<char> word);  // it will print response of key pressed
        string LoseScreen(IEnumerable<char> word);
        string WinScreen(IEnumerable<char> word);
        string RequestGuess();  // This asks from user to press an alphabet
        string AlreadyGuessed(char guess);  // it prints if user has already pressed the same key
        string InvalidGuess();  // if there is a validation error in key pressed
    }
}
