using System;

namespace Lottosimulation
{
    public class Utils
    {
        /*
         * checks if a given string represents a number
         * On Success -> return the number as a int
         * On Failure -> return -1
        */

        private int isNumber(String s)
        {
            int num;

            if (int.TryParse(s, out num))
            {
                return num;
            }
            else
            {
                return -1;
            }
        }

        /*
         * Ask the user to choose a option
         * On Success -> return the number of the chosen option as a int
         * On Failure -> ask until success
         */

        public int askForNumberOption(String message, String[] options)
        {
            while (true)
            {
                //print out the message

                Console.WriteLine(message);

                //go through all options and print them

                for (int i = 0; i < options.Length; i++)
                {
                    string currentOption = options[i];
                    Console.WriteLine(String.Format("{0} -> {1}", i, currentOption));
                }

                //prompt the user to choose a option
                Console.Write("Antwort: ");

                //get the response as a string
                string response = Console.ReadLine();

                //check if the response string is a number
                int wantedOptionIndex = this.isNumber(response);

                if (wantedOptionIndex == -1)
                {
                    //the response is not a number

                    Console.WriteLine("");
                    Console.WriteLine("Fehler: Bitte geben Sie eine Zahl ein");
                    Console.WriteLine("");
                }
                else
                {
                    //the reponse is a number

                    //check if the given number as a actual option
                    if (wantedOptionIndex < 0)
                    {
                        Console.WriteLine("");
                        Console.WriteLine("Fehler: Die Nummer muss >= 0 sein.");
                        Console.WriteLine("");
                    }
                    else if (options.Length < wantedOptionIndex)
                    {
                        Console.WriteLine("");
                        Console.WriteLine(String.Format("Fehler: Die Option mit der Nummer {0} kann nicht gefunden werden.", wantedOptionIndex));
                        Console.WriteLine("");
                    }
                    else
                    {
                        //get the wanted option as a string
                        string wantedOptionStr = options[wantedOptionIndex];

                        //the reponse is a number and a valid option

                        Console.WriteLine("");
                        Console.WriteLine(String.Format("Sie haben die Option '{0}' gewählt", wantedOptionStr));
                        Console.WriteLine("");

                        return wantedOptionIndex;
                    }
                }
            }
        }

        public int askForNumber(string message, int minimum, int maximum)
        {
            while (true)
            {
                //print out the message
                Console.WriteLine(message);

                //prompt the user to choose a option
                Console.Write("Antwort: ");

                //get the response as a string
                string response = Console.ReadLine();

                int resultNum = this.isNumber(response);

                if (resultNum == -1)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Fehler: Bitte geben Sie eine Zahl ein");
                    Console.WriteLine("");
                }
                else if (resultNum < minimum)
                {
                    Console.WriteLine("");
                    Console.WriteLine(String.Format("Fehler: Die Zahl darf nicht kleiner als {0} sein.", minimum));
                    Console.WriteLine("");
                }
                else if (resultNum > maximum)
                {
                    Console.WriteLine("");
                    Console.WriteLine(String.Format("Fehler: Die Zahl darf nicht größer als {0} sein.", maximum));
                    Console.WriteLine("");
                }
                else
                {
                    return resultNum;
                }
            }
        }
    }
}