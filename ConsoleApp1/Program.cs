using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int SizeXY = 25;

            int[,] Field = new int[SizeXY, SizeXY];
            Random random = new Random();

            for (int i = 0; i < SizeXY; i++)
            {
                for (int j = 0; j < SizeXY; j++)
                {
                    Field[i, j] = 0;
                }
            }

            string player1Str = " O";
            string player2Str = " X";
            string fieldStr = " #";

            FieldOut(Field, player1Str, player2Str, fieldStr, SizeXY);
            Console.ReadKey();

            int round = 2;
            do
            {
                if (round == 1)
                    round++;
                else round = 1;

                int x = random.Next(1, 7), y = random.Next(1, 7);
                InterfaceMove(round, x, y, Field, player1Str, player2Str, fieldStr, SizeXY);
                Console.ReadKey();

            } while (true);
        }

        static void InterfaceMove(int move, int x, int y, int[,] F, string p1, string p2, string f, int SizeXY)
        {
            int x1, y1;
            string sx1, sy1;
            Console.Clear();

            FieldOut(F, p1, p2, f, SizeXY);
            Console.WriteLine("Dice drop: " + x + ", and " + y);
            do
            {
                Console.Write("Place at: \nx(vertical): ");
                sx1 = Console.ReadLine();
            } while (sx1 == "");
            do
            {
                Console.Write("y(horizontal): ");
                sy1 = Console.ReadLine();
            } while (sy1 == "");
            x1 = Convert.ToInt32(sx1);
            y1 = Convert.ToInt32(sy1);
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
                        F[(SizeXY-1) - i, (SizeXY-1) - j] = move;
                    }
                }
        }

        static void FieldOut(int[,] F, string p1, string p2, string f, int SizeXY)
        {
            for (int i = 0; i < SizeXY+1; i++)
            {
                for (int j = 0; j < SizeXY+1; j++)
                {
                    if (i == 0 && j == 0)
                        Console.Write("   ");
                    else if (i == 0 && j < (SizeXY/2-1))
                        Console.Write(j - 1 + " ");
                    else if (i == 0 && j == SizeXY + 1)
                        Console.Write("");
                    else if (i < (SizeXY / 2 - 1) && j == 0)
                        Console.Write(" " + (i - 1) + " ");
                    else if (i < (SizeXY / 2 - 1) && j == SizeXY + 1)
                        Console.Write(" " + (SizeXY - i));
                    else if (i == SizeXY + 1 && j == SizeXY + 1)
                        Console.Write("  ");
                    else if (j == SizeXY + 1)
                        Console.Write(" " + (SizeXY - i));
                    else if (i == SizeXY + 1 && j == 0)
                        Console.Write("   ");
                    else if (i == SizeXY + 1 && (SizeXY - j) > 9)
                        Console.Write(SizeXY - j);
                    else if (i == SizeXY + 1 && j != 0)
                        Console.Write(" " + (SizeXY - j));
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