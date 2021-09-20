using SnakeLadder.Host.contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeLadder.Host
{
    class Program
    {
        static void Main(string[] args)
        {

            var snakes = GetSnakes();
            var ladders = GetLadder();
            Console.WriteLine("GAME RULES : ");
            Console.WriteLine("1. TWO PLAYERS can play at a time.");
            Console.WriteLine("2. S - SNAKE");
            Console.WriteLine("3. L - LADDER");
            Console.WriteLine("4. If any Player is on SNAKE S-, then it would scroll to desired number on board. eg: S-64 would scroll player to 64 number on board.");
            Console.WriteLine("5. If any Player is on LADDER L-, then it would scroll to desired number on board. eg: L-38 would scroll player to 38 number on board.");
            Console.WriteLine("\t\t\t\t\t ****GAME BOARD**** ");
            int dessendingBoardValues = 100;
            int assendingBoardValues = 81;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((snakes.Exists(snake => snake.Mouth.Row.Equals(i) && snake.Mouth.Column.Equals(j))) || (ladders.Exists(ladder => ladder.Tip.Row.Equals(i) && ladder.Tip.Column.Equals(j))))
                    {

                        var snakeToPrint = snakes.FirstOrDefault(snake => snake.Mouth.Row.Equals(i) && snake.Mouth.Column.Equals(j))?.Key;
                        var ladderToPrint = ladders.FirstOrDefault(ladder => ladder.Tip.Row.Equals(i) && ladder.Tip.Column.Equals(j))?.Key;

                        if (snakeToPrint != null)
                            Console.Write("    " + snakeToPrint + "  ");
                        else
                            Console.Write("    " + ladderToPrint + "  ");
                    }
                    else
                    {
                        if (i % 2 == 0)
                            Console.Write("    " + dessendingBoardValues + "    ");
                        else
                        {
                            if (i == 9 && j != 9)
                                Console.Write("    0" + assendingBoardValues + "    ");
                            else
                                Console.Write("    " + assendingBoardValues + "    ");
                        }
                    }
                    if (i % 2 == 0)
                        dessendingBoardValues--;
                    else
                        assendingBoardValues++;
                }
                if (i % 2 == 0)
                    dessendingBoardValues = dessendingBoardValues - 10;
                else
                    assendingBoardValues = assendingBoardValues - 30;
                Console.WriteLine();
            }
            Console.ReadKey();
        }

        private static List<Ladder> GetLadder()
        {
            //DEFINING LADDER
            List<Ladder> ladders = new List<Ladder>();
            //Ladder("Name Of Ladder", Start Index, End Index)
            ladders.Add(new Ladder("L-98", new Index(2, 0), new Index(0, 2)));//(L - 98, 20, 02)
            ladders.Add(new Ladder("L-77", new Index(6, 2), new Index(2, 3)));//(L - 77, 62, 23)
            ladders.Add(new Ladder("L-55", new Index(8, 2), new Index(4, 5)));//(L - 55, 82, 45)
            ladders.Add(new Ladder("L-38", new Index(9, 3), new Index(6, 2)));//(L - 38, 93, 62)
            ladders.Add(new Ladder("L-65", new Index(7, 5), new Index(3, 4)));//(L - 65, 75, 34)
            ladders.Add(new Ladder("L-86", new Index(3, 6), new Index(1, 5)));//(L - 86, 36, 15)
            ladders.Add(new Ladder("L-40", new Index(9, 6), new Index(6, 0)));//(L - 40, 96, 60)
            ladders.Add(new Ladder("L-32", new Index(7, 7), new Index(6, 8)));//(L - 32, 77, 68)
            return ladders;
        }

        private static List<Snake> GetSnakes()
        {
            //DEFINING SNAKES
            List<Snake> snakes = new List<Snake>();
            //Snake("Name of Snake",Start Index,End Index)
            snakes.Add(new Snake("S-64", new Index(0, 1), new Index(3, 3)));//(S - 64, 01, 33)
            snakes.Add(new Snake("S-02", new Index(7, 0), new Index(9, 1)));//(S - 02, 70, 91)
            snakes.Add(new Snake("S-03", new Index(3, 1), new Index(9, 2)));//(S - 03, 31, 92)
            snakes.Add(new Snake("S-55", new Index(1, 2), new Index(4, 5)));//(S - 55, 12, 45)
            snakes.Add(new Snake("S-71", new Index(0, 5), new Index(2, 9)));//(S - 71, 05, 29)
            snakes.Add(new Snake("S-57", new Index(2, 5), new Index(4, 3)));//(S - 57, 25, 43)
            snakes.Add(new Snake("S-45", new Index(1, 6), new Index(5, 4)));//(S - 45, 16, 54)
            snakes.Add(new Snake("S-06", new Index(0, 7), new Index(9, 5)));//(S - 06, 07, 95)
            snakes.Add(new Snake("S-47", new Index(2, 7), new Index(5, 6)));//(S - 47, 27, 56)
            snakes.Add(new Snake("S-03", new Index(8, 7), new Index(9, 2)));//(S - 03, 87, 92)
            return snakes;
        }
    }
}
