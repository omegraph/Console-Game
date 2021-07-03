using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hangman
{
    public class Game
    {
        private readonly IUiVisualizer _ui;
        private string _secretWord;
        private List<char> wordToGuess, wordGuessed;

        //enume of game state
        enum State { Playing, Won, Over }; //using enum to control game state

        public Game(IUiVisualizer ui, string secretWord)
        {
            //Constractor....assign values to local variables from parameters
            _ui = ui;
            _secretWord = secretWord;

            //this will start the game
            Start();
        }

        private void Start()
        {
            //this will print our welcome screen
            Console.WriteLine(_ui.WelcomeScreen());
            Console.ReadLine();

            while (true)
            {
                //this variable will be used to ask user if he want to play again
                string againPlay = "";

                //this is enum and used to control our game flow
                State currentState = State.Playing;

                //these two lists of characters will have our secret word and guessed word
                wordToGuess = new List<char>();
                wordGuessed = new List<char>();

                List<char> wrongGuesses = new List<char>();

                //populating word to guess list
                wordToGuess.AddRange(_secretWord);

                //populating word guessed by user list
                foreach (char c in wordToGuess)
                {
                    wordGuessed.Add('*');
                }

                do
                {
                    Console.WriteLine("<============================================>");
                    Console.WriteLine("<============================================>");

                    //ask user for input
                    Console.WriteLine(_ui.RequestGuess());
                    var playerGuess = Console.ReadLine().ToUpper(); //user input 'a', 'c' ....

                    Console.WriteLine();

                    //if user pressed the right key
                    if (GuessValidation(playerGuess))
                    {
                        var guess = Convert.ToChar(playerGuess);

                        //check if the entred alphabet is in the lists
                        //WordGuessed or wrongGuesses
                        if (!wordGuessed.Contains(guess) && !wrongGuesses.Contains(guess))
                        {
                            //check if alphabet entred is in wordToGuess
                            if (wordToGuess.Contains(guess))
                            {
                                //place guessed words instead of underscores and populate wordGuessed list
                                for (int i = 0; i < wordToGuess.Count; i++)
                                {
                                    if (wordToGuess[i] == guess)
                                        wordGuessed[i] = guess;
                                }
                                Console.WriteLine();
                                //this will print our Mr. hangman
                                Console.WriteLine(_ui.MrHangman(0));
                                //this will print response to key pressed
                                Console.WriteLine(_ui.ResponseWord(wordGuessed));
                            }
                            else
                            {
                                Console.WriteLine();
                                wrongGuesses.Add(guess); //populate wrong guesses list
                                //this will print our Mr. hangman
                                Console.WriteLine(_ui.MrHangman(wrongGuesses.Count));
                                //this will print response to key pressed by user
                                Console.WriteLine(_ui.ResponseWord(wordGuessed));

                            }
                        }
                        else
                        {
                            Console.WriteLine();

                            //this will print our Mr. hangman
                            Console.WriteLine(_ui.MrHangman(0));
                            //this will print that user already entered this alphabet
                            Console.WriteLine(_ui.AlreadyGuessed(guess));
                            //it shows how many alphabets user has guessed
                            Console.WriteLine(_ui.ResponseWord(wordGuessed));
                        }
                    }
                    else
                    {
                        //this is validation error messaged
                        Console.WriteLine(_ui.InvalidGuess());
                    }

                    //if wordGuessed list doesn't have any remaining under scores then game is won
                    if (!wordGuessed.Contains('*'))
                    {
                        //game state will be changed to won
                        currentState = State.Won;
                        //this will print our last hangman
                        Console.WriteLine(_ui.MrHangman(0));
                        //this will print win screen
                        Console.WriteLine(_ui.WinScreen(wordGuessed));
                    }

                    //this for lose screen
                    if (wrongGuesses.Count == 10)
                    {
                        //print full mr. hangman
                        Console.WriteLine(_ui.MrHangman(wrongGuesses.Count));
                        //this will print lose screen
                        Console.WriteLine(_ui.LoseScreen(wordToGuess));
                        //game state will be changed to over
                        currentState = State.Over;
                    }
                } while (currentState == State.Playing); //game will exit from this do-while loop if game state changes from playing to any other state

                //this will ask user if he want to play again or not
                do
                {
                    Console.WriteLine("Play again? (Y/N)");
                    //wait for user to input / key press
                    ConsoleKeyInfo keyPress = Console.ReadKey();
                    againPlay = keyPress.Key.ToString();
                    Console.WriteLine();

                    if (againPlay.ToUpper() != "Y" && againPlay.ToUpper() != "N")
                    {
                        Console.WriteLine("Invalid response, please enter Y or N");
                        continue;
                    }
                    else
                    {
                        break;
                    }
                } while (true);

                if (againPlay.ToUpper() == "Y")
                {
                    //This will start a new game
                    Console.WriteLine();
                    //This will choose a new word from wordlist
                    _secretWord = Program.wordList[(new Random()).Next(Program.wordList.Length)];
                    continue;
                }
                else
                {
                    //Game will be end here
                    break;
                }
            }

        }

            private bool GuessValidation(string guess)
            {
                //validation for key pressed
                //it should be 1 character long/small or cap alphabets
                return (guess.Length == 1) && Regex.IsMatch(guess, @"^[a-zA-Z]+$");
            }
        }
    }