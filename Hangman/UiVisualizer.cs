using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hangman
{
    public class UiVisualizer : IUiVisualizer
    {
        private string _mrHangingImg;
        public string WelcomeScreen()
        {
            return " Welcome to Hangman " + Environment.NewLine + " You have to guess all alphabets of word " +
                Environment.NewLine + " Please press 'Enter' to start the game";
        }

        public string MrHangman(int wrongGuessCount)
        {
            switch (wrongGuessCount)
            {
                case 0:
                    break;
                case 1:
                    this._mrHangingImg = "\n\n\n\n\n\n-------";
                    break;
                case 2:
                    this._mrHangingImg = this._mrHangingImg.Remove(1, 5);
                    this._mrHangingImg = this._mrHangingImg.Insert(1, "   |\n   |\n   |\n   |\n   |\n");
                    break;
                case 3:
                    this._mrHangingImg = this._mrHangingImg.Remove(0, 1);
                    this._mrHangingImg = this._mrHangingImg.Insert(0, "    ---\n");
                    break;
                case 4:
                    this._mrHangingImg = this._mrHangingImg.Insert(12, "   |");
                    break;
                case 5:
                    this._mrHangingImg = this._mrHangingImg.Insert(21, "   O");
                    break;
                case 6:
                    this._mrHangingImg = this._mrHangingImg.Insert(30, "   |");
                    break;
                case 7:
                    this._mrHangingImg = this._mrHangingImg.Remove(32, 1);
                    this._mrHangingImg = this._mrHangingImg.Insert(32, "-");
                    break;
                case 8:
                    this._mrHangingImg = this._mrHangingImg.Insert(34, "-");
                    break;
                case 9:
                    this._mrHangingImg = this._mrHangingImg.Insert(40, "  /");
                    break;
                case 10:
                    this._mrHangingImg = this._mrHangingImg.Insert(43, " \\");
                    break;
            }

            return _mrHangingImg;
        }

        public string ResponseWord(IEnumerable<char> word)
        {
            string responseString = Environment.NewLine + "Word: ";
            foreach (var letter in word)
                responseString += letter + " ";
            return responseString;
        }

        public string LoseScreen(IEnumerable<char> word)
        {
            return Environment.NewLine + "Oh! You Lost" + Environment.NewLine + "The word was: " + (new string(word.ToArray()));
        }

        public string WinScreen(IEnumerable<char> word)
        {
            return Environment.NewLine + "Congratulations, You Win!" + Environment.NewLine + "The final word was: " +
                (new string(word.ToArray()));          
        }

        public string RequestGuess()
        {
            return Environment.NewLine + "Enter a guess";
        }

        public string AlreadyGuessed(char guess)
        {
            return Environment.NewLine + "You have already guessed '"+guess+"' letter!";
        }

        public string InvalidGuess()
        {
            return Environment.NewLine + "Invalid Guess. Guess must be a single alphabetical letter.";
        }
      
    }
}
