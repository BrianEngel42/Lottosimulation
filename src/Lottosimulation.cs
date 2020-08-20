using System;

namespace Lottosimulation
{
    public class Lottosimulation
    {
        private Utils utils;
        private Lottoschein currentLottoschein;
        private Lottomaschine lottomaschine;
        private Lottoauswerter lottoauswerter;

        public Lottosimulation()
        {
            this.lottomaschine = new Lottomaschine();
            this.currentLottoschein = new Lottoschein();
            this.lottoauswerter = null;
            this.utils = new Utils();
            this.reset();
        }

        private void reset()
        {
            Console.Clear();
            this.currentLottoschein = new Lottoschein();
        }

        private void begin()
        {
            String[] options = new String[]{
                "Ein neues manuelles Spiel starten",
                "Ein schnelles Spiel starten",
                "Schnelles Spiel bis ein Gewinn erziehlt wurde",
                "Das Programm beenden"
            };

            int result = this.utils.askForNumberOption("Was möchten Sie tun?", options);

            if (result == 0)
            {
                this.runManualGame();
            }
            else if (result == 1)
            {
                this.runFastGame();
            }
            else if (result == 2)
            {
                this.runFastGameUntilWin();
            }
            else if (result == 2)
            {
                Console.WriteLine("Bye!");
                System.Environment.Exit(0);
            }
        }

        private void runManualGame()
        {
            this.reset();
            this.getLottozahlen();
            this.getSuperNumber();
            this.printZahlenAndAskToContinue();
            this.genNumberAndGetRank();
        }

        private void runFastGame()
        {
            this.reset();
            this.currentLottoschein.fillRandom();
            this.currentLottoschein.printNumbers();
            this.genNumberAndGetRank();
        }

        private void runFastGameUntilWin()
        {
            Console.Clear();

            int games = 0;

            while (true)
            {
                games++;

                this.currentLottoschein = new Lottoschein();
                this.currentLottoschein.fillRandom();
                this.lottomaschine.generateWinningNumbers();
                this.lottoauswerter = new Lottoauswerter(this.lottomaschine, this.currentLottoschein);

                if (this.lottoauswerter.isWin())
                {
                    this.currentLottoschein.printNumbers();
                    this.lottomaschine.printWinningNumbers();
                    this.lottoauswerter.printResult();

                    Console.WriteLine(String.Format("Dieser Gewinn wurde nach {0} mal Spielen erziehlt", games));

                    Console.WriteLine("");

                    break;
                }
            }
        }

        private void getLottozahlen()
        {
            /*
             * Ask the user to enter 6 unique numbers between/inclduing 0 - 49
             */

            for (int i = 1; i <= 6; i++)
            {
                while (true)
                {
                    int num = this.utils.askForNumber(String.Format("Bitte geben Sie Ihre {0}. Lottozahl ein", i), 0, 49);

                    if (this.currentLottoschein.addNumber((i - 1), num))
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("");
                        Console.WriteLine(String.Format("Sie haben in Ihrem Lottoschein bereits die Zahl {0}", num));
                        Console.WriteLine("Zahlen dürfen nicht doppel vorkommen.");
                        Console.WriteLine("");
                    }
                }
            }

            Console.WriteLine("");
        }

        private void getSuperNumber()
        {
            int superNumber = this.utils.askForNumber("Bitte geben Sie Ihre Superzahl ein", 0, 9);
            this.currentLottoschein.setSuperNumber(superNumber);
            Console.WriteLine("");
        }

        private void printZahlenAndAskToContinue()
        {
            this.currentLottoschein.printNumbers();

            String[] options = new String[]{
                "Ja (zur Auswertung)",
                "Nein (erneut beginnen)"
            };

            int result = this.utils.askForNumberOption("Sind Ihre Zahlen korrekt?", options);

            if (result == 1)
            {
                this.runManualGame();
            }
        }

        private void genNumberAndGetRank()
        {
            this.lottomaschine.generateWinningNumbers();
            this.lottomaschine.printWinningNumbers();
            this.lottoauswerter = new Lottoauswerter(this.lottomaschine, this.currentLottoschein);
            this.lottoauswerter.printResult();
        }

        public void run()
        {
            while (true)
            {
                begin();
            }
        }
    }
}