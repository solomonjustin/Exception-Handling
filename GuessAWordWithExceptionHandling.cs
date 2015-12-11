using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Console;

namespace Lab7
{
    class GuessAWordWithExceptionHandling
    {
        static void Main(string[] args)
        {
            int foundLetters = 0;
            bool 
                solved = false, 
                found = false;
            char entry;
            string test;

            //create array with 8 strings
            string[] word = { "apple", "grape", "banana", "berry", "tomato", "cranberry", "orange", "blueberry" };

            //choose a random index out of array
            Random random = new Random();
            int x = random.Next(0, word.Length);

            //create word array and hidden array; char arrays so you can modify each letter
            char[] randomWord = word[x].ToCharArray();
            char[] hidden = word[x].ToCharArray();

            //turn word into asterisks
            for (int d = 0; d < hidden.Length; ++d)
                hidden[d] = '*';

            WriteLine("Guess-A-Word");
            WriteLine("-----------------\n");

            while (solved == false)
            {
                TopOfWhile:
                WriteLine(hidden);

                //try to convert the input to a letter
                try
                {
                    Write("Guess a letter: ");
                    test = ReadLine().ToLower();

                    if(!(char.TryParse(test, out entry)) && (entry < 'a' || entry > 'z'))
                    {
                        NonLetterException nle = new NonLetterException(test);
                        throw (nle);
                    }

                    //test each letter
                    for (int a = 0; a < hidden.Length; ++a)
                    {
                        //if letter in word is the same as entry and has not already been found
                        if (entry == randomWord[a] && hidden[a] != entry)
                        {
                            hidden[a] = entry;
                            found = true;
                            ++foundLetters;
                        }

                        else if(hidden[a] == entry)
                        {
                            WriteLine(" :you already guessed {0}.\n", entry);
                            goto TopOfWhile; //goto start label
                        }
                    }

                    //if input != any letters in word
                    if (found == false)
                        WriteLine(" :the letter {0} is not in the word.\n", entry);
                    else
                    {
                        WriteLine(" :the letter {0} is in the word.\n", entry);
                        found = false; // reset false so that the next letter is not displayed as found
                    }
                }

                //catch invalid input
                catch(NonLetterException e)
                {
                    WriteLine();
                    WriteLine(e.Message);
                    WriteLine();
                }

                if (foundLetters == randomWord.Length)
                    solved = true;
            }

            WriteLine("You solved the word!\n");
            WriteLine(hidden);

        }
    }
}
