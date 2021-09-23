﻿using SnakeLadder.Host.contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeLadder.Host
{
    public static class Helper
    {
        public static string SetOtherValues(int dessendingBoardValues, int assendingBoardValues, int i, int j)
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

        public static string SetSnakeNLadder(List<Snake> snakes, List<Ladder> ladders, int i, int j)
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

        public static void PrintRules()
        {
            Console.WriteLine("GAME RULES : ");
            Console.WriteLine("1. TWO PLAYERS can play at a time.");
            Console.WriteLine("2. S - SNAKE . start position > end position");
            Console.WriteLine("3. L - LADDER . start position < end position");
            Console.WriteLine("4. If any Player is on SNAKE S-, then it would scroll to desired number on board. eg: S-64 would scroll player to 64 number on board.");
            Console.WriteLine("5. If any Player is on LADDER L-, then it would scroll to desired number on board. eg: L-38 would scroll player to 38 number on board.");
        }
    }
}