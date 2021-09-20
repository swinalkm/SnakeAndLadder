using SnakeLadder.Host.contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeLadder.Host
{
    public static class Display
    {
        public static void Board(List<Snake> snakes, List<Ladder> ladders)
        {
            PrintRules();
            Console.WriteLine("\t\t\t\t\t ****GAME BOARD**** ");
            int dessendingBoardValues = 100; // hardcoded numbers, since board is static
            int assendingBoardValues = 81;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((snakes.Exists(snake => snake.Mouth.Row.Equals(i) && snake.Mouth.Column.Equals(j))) || (ladders.Exists(ladder => ladder.Tip.Row.Equals(i) && ladder.Tip.Column.Equals(j))))
                    {
                        PrintSnakeORLadder(snakes, ladders, i, j);
                    }
                    else
                    {
                        PrintOtherNumbers(dessendingBoardValues, assendingBoardValues, i, j);
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
        }

        private static void PrintRules()
        {
            Console.WriteLine("GAME RULES : ");
            Console.WriteLine("1. TWO PLAYERS can play at a time.");
            Console.WriteLine("2. S - SNAKE");
            Console.WriteLine("3. L - LADDER");
            Console.WriteLine("4. If any Player is on SNAKE S-, then it would scroll to desired number on board. eg: S-64 would scroll player to 64 number on board.");
            Console.WriteLine("5. If any Player is on LADDER L-, then it would scroll to desired number on board. eg: L-38 would scroll player to 38 number on board.");
        }

        private static void PrintOtherNumbers(int dessendingBoardValues, int assendingBoardValues, int i, int j)
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

        private static void PrintSnakeORLadder(List<Snake> snakes, List<Ladder> ladders, int i, int j)
        {
            var snakeToPrint = snakes.FirstOrDefault(snake => snake.Mouth.Row.Equals(i) && snake.Mouth.Column.Equals(j))?.Key;
            var ladderToPrint = ladders.FirstOrDefault(ladder => ladder.Tip.Row.Equals(i) && ladder.Tip.Column.Equals(j))?.Key;

            if (snakeToPrint != null)
                Console.Write("    " + snakeToPrint + "  ");
            else
                Console.Write("    " + ladderToPrint + "  ");
        }
    }
}
