using System.Globalization;

namespace XO
{
    internal class Program
    {
        static string[,] gamePoleMap = new string[3, 3];

        static void DefaultValueGame()
        {
            int count = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    count++;
                    gamePoleMap[i, j] = " [ " + count + " ] ";
                }
            }
            gamePoleMap[0, 2] = "X";
            gamePoleMap[1, 1] = "X";
            gamePoleMap[2, 0] = "X";
        }

        static void Write()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Console.Write("|" + gamePoleMap[i, j] + " ");
                }
                Console.WriteLine();
                Console.WriteLine("------------------------------");
            }
        }

        static string GetFigure()
        {
            string figure = Console.ReadLine();
            if (figure.ToUpper() != "O" && figure.ToUpper() != "X")
            {
                Console.WriteLine("Не тот выбор");
            }
            return figure;
        }

        static bool IsEmpty()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gamePoleMap[i, j] != "X" && gamePoleMap[i, j] != "O")
                    {
                        return true;
                    }
                }
            }
            return false;
        }


        static bool GetWinner(string figure)
        {
            int hor = 0;
            int vert = 0;
            int d = 0;
            int d1 = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (gamePoleMap[i, j] == figure)
                    {
                        hor++;
                    }

                    if (gamePoleMap[j, i] == figure)
                    {
                        vert++;
                    }

                    if (i == j)
                    {
                        if (gamePoleMap[i, j] == figure)
                        {
                            d++;
                        }
                    }

                    if (2 == i + j)
                    {
                        if (gamePoleMap[i, j] == figure)
                        {
                            d1++;
                        }
                    }
                }
            }

            if (hor == 3 || vert == 3 || d == 3 || d1 == 3)
            {
                return true;
            }
            return false;
        }

        static void PCStep(string figure)
        {
            Random rand = new Random();
            while (true)
            {
                int indexI = rand.Next(0, 3);
                int indexJ = rand.Next(0, 3);
                if (IsEmpty(indexI, indexJ))
                {
                    gamePoleMap[indexI, indexJ] = figure;
                    return;
                }
            }
        }

        static bool IsEmpty(int indexI, int indexJ)
        {
            if (gamePoleMap[indexI, indexJ] != "X" && gamePoleMap[indexI, indexJ] != "O")
            {
                return true;
            }
            return false;
        }

        static void Main(string[] args)
        {
            DefaultValueGame();
            PCStep("O");
            Write();
            Console.WriteLine(GetWinner("X"));
            Console.WriteLine(GetWinner("Git commit"));
            //Write();
        }
    }
}