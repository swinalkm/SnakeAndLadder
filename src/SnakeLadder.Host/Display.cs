using SnakeLadder.Host.contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeLadder.Host
{
    public static class Display
    {
        public static List<Count> SetBoard(List<Snake> snakes, List<Ladder> ladders)
        {
            List<Count> board = new List<Count>();
            Display.PrintRules();
            Console.WriteLine("\t\t\t\t\t ****GAME BOARD**** ");
            int dessendingBoardValues = 100; // hardcoded numbers, since board is static
            int assendingBoardValues = 81;
            string boardValue = null;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((snakes.Exists(snake => snake.Head.Row.Equals(i) && snake.Head.Column.Equals(j))) || (ladders.Exists(ladder => ladder.Tip.Row.Equals(i) && ladder.Tip.Column.Equals(j))))
                    {
                        boardValue = Display.SetSnakeNLadder(snakes, ladders, i, j);
                    }
                    else
                    {
                        boardValue = Display.SetOtherValues(dessendingBoardValues, assendingBoardValues, i, j);
                    }
                    if (i % 2 == 0)
                        dessendingBoardValues--;
                    else
                        assendingBoardValues++;
                    Console.Write("    " + boardValue + "    ");
                    board.Add(new contracts.Count(boardValue, new Index(i, j)));
                }
                if (i % 2 == 0)
                    dessendingBoardValues = dessendingBoardValues - 10;
                else
                    assendingBoardValues = assendingBoardValues - 30;
                Console.WriteLine();
            }
            return board;
        }

        private static string SetOtherValues(int dessendingBoardValues, int assendingBoardValues, int i, int j)
        {
            string boardValue;
            if (i % 2 == 0)
                boardValue = " " + dessendingBoardValues.ToString() + " ";
            else
            {
                if (i == 9 && j != 9)
                    boardValue = "  " + assendingBoardValues.ToString() + " ";
                else
                    boardValue = " " + assendingBoardValues.ToString() + " ";
            }

            return boardValue;
        }

        private static string SetSnakeNLadder(List<Snake> snakes, List<Ladder> ladders, int i, int j)
        {
            string boardValue;
            var snakeToPrint = snakes.FirstOrDefault(snake => snake.Head.Row.Equals(i) && snake.Head.Column.Equals(j))?.Key;
            var ladderToPrint = ladders.FirstOrDefault(ladder => ladder.Tip.Row.Equals(i) && ladder.Tip.Column.Equals(j))?.Key;

            if (snakeToPrint != null)
                boardValue = snakeToPrint;
            else
                boardValue = ladderToPrint;
            return boardValue;
        }

        private static void PrintRules()
        {
            Console.WriteLine("GAME RULES : ");
            Console.WriteLine("1. TWO PLAYERS can play at a time.");
            Console.WriteLine("2. S - SNAKE . start position > end position");
            Console.WriteLine("3. L - LADDER . start position < end position");
            Console.WriteLine("4. If any Player is on SNAKE S-, then it would scroll to desired number on board. eg: S-64 would scroll player to 64 number on board.");
            Console.WriteLine("5. If any Player is on LADDER L-, then it would scroll to desired number on board. eg: L-38 would scroll player to 38 number on board.");
        }
        public static bool SetDice()
        {
            bool isNormalDice = true;
            Console.WriteLine("1. PRESS 1 FOR NORMAL DICE");
            Console.WriteLine("2. PRESS 2 FOR CROOKED DICE");
            var dice = Console.ReadLine();
            if (dice == "1" || dice == "2")
            {
                if (dice == "1")
                    isNormalDice = true;
                else
                    isNormalDice = false;
            }
            else
            {
                Console.WriteLine("INVALID INPUT !!!");
                Console.ReadKey();
                Environment.Exit(0);
            }

            return isNormalDice;
        }

    }
}
