using System;

namespace Game
{
    class Program
    {
        static void Main(string[] args)
        {
            int SizeXY = 0;
            do
            {
                Console.Clear();
                Console.WriteLine("Выберите режим игры:");
                Console.WriteLine("1. Игрок против игрока");
                Console.WriteLine("2. Игрок против компьютера");
                Console.WriteLine("0. Выход");
                var Level = Console.ReadKey();
                switch (Level.Key)
                {
                    case ConsoleKey.D1:
                        SizeXY = SizeMenu();
                        if (SizeXY > 0)
                        {
                            GamePVP(SizeXY);
                            Console.Clear();
                            Console.WriteLine("Сыграть еще?");
                            Console.WriteLine("1. Да");
                            Console.WriteLine("2. Нет");
                            Level = Console.ReadKey();
                            if (Level.Key == ConsoleKey.D1) SizeXY = 0;
                        }
                        break;
                    case ConsoleKey.D2:
                        SizeXY = SizeMenu();
                        if (SizeXY > 0)
                        {
                            GamePVE(SizeXY);
                            Console.Clear();
                            Console.WriteLine("Сыграть еще?");
                            Console.WriteLine("1. Да");
                            Console.WriteLine("2. Нет");
                            Level = Console.ReadKey();
                            if (Level.Key == ConsoleKey.D1) SizeXY = 0;
                        }
                        break;
                    case ConsoleKey.D0:
                        Environment.Exit(0);
                        break;
                }
            } while (SizeXY == 0);
        }
        static int SizeMenu()
        {
            Console.Clear();
            Console.WriteLine("Выберите уровень сложности:");
            Console.WriteLine("1. Легкий (10х10)");
            Console.WriteLine("2. Нормальный (20х20)");
            Console.WriteLine("3. Сложный (30х30)");
            Console.WriteLine("4. Ввести в ручную размерность");
            Console.WriteLine("0. Назад");
            var Level = Console.ReadKey();
            switch (Level.Key)
            {
                case ConsoleKey.D1:
                    return 10;
                case ConsoleKey.D2:
                    return 20;
                case ConsoleKey.D3:
                    return 30;
                default:
                    Console.Clear();
                    Console.WriteLine("Введите размерность поля:");
                    return Convert.ToInt32(Console.ReadLine());
                case ConsoleKey.D0:
                    return 0;
            }
        }

        static void GamePVP(int SizeXY)
        {
            int[,] Field = new int[SizeXY, SizeXY];
            Random random = new Random();
            int EndRandom = SizeXY / 2 + 2;
            if (EndRandom > 10)
            {
                EndRandom = 10;
            }
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
            int win = 0;
            int round = 2;
            do
            {
                if (round == 1)
                    round++;
                else round = 1;

                int x = random.Next(1, EndRandom), y = random.Next(1, EndRandom);
                InterfaceMove(round, x, y, Field, player1Str, player2Str, fieldStr, SizeXY);
                win = Winner(Field, SizeXY);

            } while (win == 0);
        }

        static void GamePVE(int SizeXY)
        {
            int[,] Field = new int[SizeXY, SizeXY];
            Random random = new Random();

            for (int i = 0; i < SizeXY; i++)
            {
                for (int j = 0; j < SizeXY; j++)
                {
                    Field[i, j] = 0;
                }
            }
            int EndRandom = SizeXY / 2 + 2;
            if (EndRandom > 10)
            {
                EndRandom = 10;
            }
            string player1Str = " O";
            string player2Str = " X";
            string fieldStr = " #";
            int win = 0;

            int round = 1;
            do
            {
                int x = random.Next(1, EndRandom), y = random.Next(1, EndRandom);
                if (round == 1)
                {
                    InterfaceMove(round, x, y, Field, player1Str, player2Str, fieldStr, SizeXY);
                    round = 2;
                }
                else
                {
                    InterfaceMovePC(round, x, y, Field, SizeXY);
                    round = 1;
                }
                win = Winner(Field, SizeXY);
                if (win == 1 || win == 2)
                {
                    Console.Clear();
                    Console.WriteLine("---------------------");
                    Console.WriteLine("!!!Выйграл "+win+" игрок!!!");
                    Console.WriteLine("---------------------");
                    FieldOut(Field, player1Str, player2Str, fieldStr, SizeXY);
                    Console.WriteLine("\nНажмите любую клавишу что бы продолжить");
                    Console.ReadKey();
                }

            } while (win == 0);
        }

        static void InterfaceMove(int move, int x, int y, int[,] F, string p1, string p2, string f, int SizeXY)
        {
            int x1, y1;
            string sx1, sy1;
            Console.Clear();

            Console.WriteLine("Раунд " + move + "!\n");
            FieldOut(F, p1, p2, f, SizeXY);
            if (move % 2 == 0)
            {
                Console.WriteLine("Ходит 2 игрок (X)\nТебе выпало: " + x + " и " + y);
            }
            else
            {
                Console.WriteLine("Ходит 1 игрок (O)\nТебе выпало: " + x + " и " + y);
            }
            do
            {
                Console.Write("Пожалуйста укажи кординаты: \nx(вертикаль): ");
                sx1 = Console.ReadLine();
            } while (sx1 == "");
            do
            {
                Console.Write("y(горизонталь): ");
                sy1 = Console.ReadLine();
            } while (sy1 == "");
            x1 = Convert.ToInt32(sx1);
            y1 = Convert.ToInt32(sy1);
            Console.WriteLine();
            //if (move == 1) //Реализация игры от угла к углу
            for (int i = x1; i < x1 + x; i++)
             {
                    if (i >= SizeXY)
                        break;
                    for (int j = y1; j < y1 + y; j++)
                    {
                        if (j >= SizeXY)
                            break;
                        F[i, j] = move;
                    }
             }
            /*else if (move == 2) //Реализация игры от угла к углу
                for (int i = x1; i < x1 + x; i++)
                {
                    if (i > SizeXY)
                        break;
                    for (int j = y1; j < y1 + y; j++)
                    {
                        if (j > SizeXY)
                            break;
                        F[(SizeXY-1) - i, (SizeXY-1) - j] = move;
                    }
                }*/
        }

        static void InterfaceMovePC(int move, int x, int y, int[,] F, int SizeXY)
        {
            int x1, y1;
            List<int> sx1 = new List<int>();
            List<int> sy1 = new List<int>();

            for (int i = 0; i < SizeXY-x; i++)
            {
                for (int j = 0; j < SizeXY-y; j++)
                {
                    if (F[i, j] != 2)
                    {
                        sx1.Add(i);
                        sy1.Add(j);
                    }
                }
            }

            Random rnd = new Random();
            var index = rnd.Next(sx1.Count);
            x1 = sx1[index];
            y1 = sy1[index];
            for (int i = x1; i < x1 + x; i++)
            {
                if (i >= SizeXY)
                    break;
                for (int j = y1; j < y1 + y; j++)
                {
                    if (j >= SizeXY)
                        break;
                    F[i, j] = move;
                }
            }
        }

        static int Winner(int[,] F, int SizeXY)
        {
            int win1 = 0;
            int win2 = 0;
            for (int i = 0; i < SizeXY; i++)
            {
                for (int j = 0; j < SizeXY; j++)
                {
                    if (F[i, j] == 1)
                    {
                        win1++;
                    }
                    else if (F[i, j] == 2)
                    {
                        win2++;
                    }

                    if (win1 >= (SizeXY * SizeXY) / 2)
                    {
                        //Console.WriteLine("Выйграл 1 игрок");
                        //Console.ReadKey();
                        return 1;
                    }
                    else if (win2 >= (SizeXY * SizeXY) / 2)
                    {
                        //Console.WriteLine("Выйграл 2 игрок");
                        //Console.ReadKey();
                        return 2;
                    }
                }
            }
            return 0;
        }

        static void FieldOut(int[,] F, string p1, string p2, string f, int SizeXY)
        {
            for (int i = 0; i < SizeXY+1; i++)
            {
                for (int j = 0; j < SizeXY+1; j++)
                {
                    if (i == 0 && j == 0)
                        Console.Write("    ");
                    else if (i == 0 && j < 11)
                        Console.Write(j - 1 + " ");
                    else if (i == 0 && j == SizeXY + 1)
                        Console.Write("");
                    else if (i < 11 && j == 0)
                        Console.Write(" " + (i - 1) + " ");
                    else if (i < 11 && j == SizeXY + 1)
                        Console.Write(" " + (SizeXY - i));
                    else if (i == SizeXY + 1 && j == SizeXY + 1)
                        Console.Write("   ");
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