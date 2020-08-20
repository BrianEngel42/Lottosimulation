using System;
using System.Collections.Generic;
using System.Text;

namespace Lottosimulation
{
    public class Lottoschein
    {

        private int[] numbers;
        private int superNumber;
        private Random random;
        
        public Lottoschein()
        {
            this.random = new Random();
            this.numbers = new int[6];
        }



        public void fillRandom()
        {

            for(int i = 0; i<this.numbers.Length; i++)
            {
                while (true)
                {
                    if(this.addNumber(i, this.random.Next(0, 49)))
                    {
                        break;
                    }
                }
            }

            this.superNumber = this.random.Next(0, 9);

        }

        /*
         * This function returns true if the lottoschein does not contain the given number
         */

        private bool isNumberUnique(int num)
        {

            for(int i = 0; i<this.numbers.Length; i++)
            {
                if(this.numbers[i] == num)
                {
                    return false;
                }
            }

            return true;

        }

        /*
         * This function returns true if the given number could be added
         */ 

        public bool addNumber(int index, int num)
        {

            if (isNumberUnique(num))
            {
                this.numbers[index] = num;
                return true;
            }
            else
            {
                return false;
            }
        }


        public void setSuperNumber(int num)
        {
            this.superNumber = num;
        }

        public int[] getNumbers()
        {
            return this.numbers;
        }


        public int getSuperNumber()
        {
            return this.superNumber;
        }

        /*
         * This function prints all numbers of the lottoschein 
         */ 
        public void printNumbers()
        {

            //print the numbers and ask whether to continue or not

            Console.Write("Ihre Lottozahlen lauten: ");

            for (int i = 0; i < this.numbers.Length; i++)
            {
                int currentLottoZahl = this.numbers[i];

                Console.Write(currentLottoZahl);

                if (i == (this.numbers.Length - 1))
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

            Console.WriteLine("Ihre Superzahl lautet: " + this.superNumber);

            Console.WriteLine("");

        }



    }
}
