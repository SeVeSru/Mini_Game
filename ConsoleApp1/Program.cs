using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int[,] Field = new int[25, 25];
            Random random = new Random();

            for (int i = 0; i < 25; i++)
            {
                for (int j = 0; j < 25; j++)
                {
                    Field[i, j] = 0;
                }
            }

            string player1Str = "OO";
            string player2Str = "XX";
            string fieldStr = "##";

            FieldOut(Field, player1Str, player2Str, fieldStr);
            Console.ReadKey();

            int round = 2;
            do
            {
                if (round == 1)
                    round++;
                else round = 1;

                int x = random.Next(1, 7), y = random.Next(1, 7);
                InterfaceMove(round, x, y, Field, player1Str, player2Str, fieldStr);
                Console.ReadKey();

            } while (true);
        }

        static void InterfaceMove(int move, int x, int y, int[,] F, string p1, string p2, string f)
        {
            int x1, y1;
            Console.Clear();

            FieldOut(F, p1, p2, f);
            Console.WriteLine("Dice drop: " + x + ", and " + y);

            Console.Write("Place at: \nx(vertical): ");
            x1 = Convert.ToInt32(Console.ReadLine());
            Console.Write("y(horizontal): ");
            y1 = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();
            if (move == 1)
                for (int i = x1; i < x1 + x; i++)
                {
                    for (int j = y1; j < y1 + y; j++)
                    {
                        F[i, j] = move;
                    }
                }
            else if (move == 2)
                for (int i = x1; i < x1 + x; i++)
                {
                    for (int j = y1; j < y1 + y; j++)
                    {
                        F[24 - i, 24 - j] = move;
                    }
                }
        }

        static void FieldOut(int[,] F, string p1, string p2, string f)
        {
            for (int i = 0; i < 27; i++)
            {
                for (int j = 0; j < 27; j++)
                {
                    if (i == 0 && j == 0)
                        Console.Write("   ");
                    else if (i == 0 && j < 11)
                        Console.Write(j - 1 + " ");
                    else if (i == 0 && j == 26)
                        Console.Write("");
                    else if (i < 11 && j == 0)
                        Console.Write(" " + (i - 1) + " ");
                    else if (i < 11 && j == 26)
                        Console.Write(" " + (25 - i));
                    else if (i == 26 && j == 26)
                        Console.Write("  ");
                    else if (j == 26)
                        Console.Write(" " + (25 - i));
                    else if (i == 26 && j == 0)
                        Console.Write("   ");
                    else if (i == 26 && (25 - j) > 9)
                        Console.Write(25 - j);
                    else if (i == 26 && j != 0)
                        Console.Write(" " + (25 - j));
                    else if (i == 0)
                        Console.Write(j - 1);
                    else if (j == 0)
                        Console.Write((i - 1) + " ");

                    else
                    {
                        if (F[i - 1, j - 1] == 0)
                            Console.Write(f);
                        else if (F[i - 1, j - 1] == 1)
                            Console.Write(p1);
                        else if (F[i - 1, j - 1] == 2)
                            Console.Write(p2);
                    }
                }
                Console.WriteLine();
            }
        }
    }
}