using System;
using System.Collections.Generic;
using System.Text;

namespace Lottosimulation
{
    public class Lottomaschine
    {
        private int[] winningNumbers;
        private int winningSuperNumber;
        private Random random;

        public Lottomaschine()
        {
            this.winningNumbers = new int[6];
            this.random = new Random();
        }


        public void generateWinningNumbers()
        {
            for(int i = 0; i<5; i++)
            {
                this.winningNumbers[i] = this.random.Next(0, 49);
            }

            this.winningSuperNumber = this.random.Next(0, 9);
        }

        public int[] getWinningNumbers()
        {
            return this.winningNumbers;
        }

        public int getWinningSuperNumber()
        {
            return this.winningSuperNumber;
        }

        /*
        * This function prints all numbers of the lottoschein 
        */
        public void printWinningNumbers()
        {

            //print the numbers and ask whether to continue or not

            Console.Write("Die Gewinnzahlen lauten: ");

            for (int i = 0; i < this.winningNumbers.Length; i++)
            {
                int currentWinningNumber = this.winningNumbers[i];

                Console.Write(currentWinningNumber);

                if (i == (this.winningNumbers.Length - 1))
                {
                    //add a new line if this is the last element in the array
                    Console.WriteLine("");
                }
                else
                {
                    //add a ', ' if this is not the last element in the array
                    Console.Write(", ");
                }

            }

            Console.WriteLine("Die Gewinn Superzahl lautet: " + this.winningSuperNumber);

            Console.WriteLine("");

        }


    }
}
