using System;

namespace Lottosimulation
{
    public class Lottoauswerter
    {
        private Lottomaschine maschine;
        private Lottoschein schein;

        public Lottoauswerter(Lottomaschine maschine, Lottoschein schein)
        {
            this.maschine = maschine;
            this.schein = schein;
        }

        private bool isSuperNumberCorrect()
        {
            return this.maschine.getWinningSuperNumber() == this.schein.getSuperNumber();
        }

        private int getCorrectNumbers()
        {
            int correctNumbers = 0;

            int[] winningNumbers = this.maschine.getWinningNumbers();
            int[] userNumbers = this.schein.getNumbers();

            for (int i = 0; i < winningNumbers.Length; i++)
            {
                if (winningNumbers[i] == userNumbers[i])
                {
                    correctNumbers++;
                }
            }

            return correctNumbers;
        }

        private int getWinningRank()
        {
            if (this.isSuperNumberCorrect() && this.getCorrectNumbers() == 6)
            {
                return 1;
            }
            else if (this.getCorrectNumbers() == 6)
            {
                return 2;
            }
            else if (this.isSuperNumberCorrect() && this.getCorrectNumbers() == 5)
            {
                return 3;
            }
            else if (this.getCorrectNumbers() == 5)
            {
                return 4;
            }
            else if (this.isSuperNumberCorrect() && this.getCorrectNumbers() == 4)
            {
                return 5;
            }
            else if (this.getCorrectNumbers() == 4)
            {
                return 6;
            }
            else if (this.isSuperNumberCorrect() && this.getCorrectNumbers() == 3)
            {
                return 7;
            }
            else if (this.getCorrectNumbers() == 3)
            {
                return 8;
            }
            else if (this.isSuperNumberCorrect() && this.getCorrectNumbers() == 2)
            {
                return 9;
            }

            return 10;
        }

        public bool isWin()
        {
            return this.getWinningRank() != 10;
        }

        public void printResult()
        {
            Console.WriteLine("--Auflösung--");

            Console.WriteLine(this.getCorrectNumbers() + " Richtige");

            if (this.isSuperNumberCorrect())
            {
                Console.WriteLine("Superzahl richtig");
            }
            else
            {
                Console.WriteLine("Superzahl falsch");
            }

            if (this.getWinningRank() == 10)
            {
                Console.WriteLine("Kein Gewinn");
            }
            else
            {
                Console.WriteLine("Gewinn Rang: " + this.getWinningRank());
            }

            Console.WriteLine("");
        }
    }
}