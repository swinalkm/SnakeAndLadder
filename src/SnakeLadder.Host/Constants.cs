using SnakeLadder.Host.contracts;
using SnakeLadder.Host.DataContracts;
using System;
using System.Collections.Generic;

namespace SnakeLadder.Host
{
    public class Constants : IConstants
    {
        public List<Ladder> SetLadders()
        {
            //hardcoded values since ladders are static
            //DEFINING LADDER
            List<Ladder> ladders = new List<Ladder>();
            //Ladder("Name Of Ladder",foot value, Start Index, End Index)
            ladders.Add(new Ladder("L-98", 80, new Index(2, 0), new Index(0, 2)));//(L - 98, 20, 02)
            ladders.Add(new Ladder("L-77", 38, new Index(6, 2), new Index(2, 3)));//(L - 77, 62, 23)
            ladders.Add(new Ladder("L-55", 18, new Index(8, 2), new Index(4, 5)));//(L - 55, 82, 45)
            ladders.Add(new Ladder("L-65", 26, new Index(7, 5), new Index(3, 4)));//(L - 65, 75, 34)
            ladders.Add(new Ladder("L-86", 67, new Index(3, 6), new Index(1, 5)));//(L - 86, 36, 15)
            ladders.Add(new Ladder("L-40", 7, new Index(9, 6), new Index(6, 0)));//(L - 40, 96, 60)
            ladders.Add(new Ladder("L-32", 28, new Index(7, 7), new Index(6, 8)));//(L - 32, 77, 68)
            return ladders;
        }

        public List<Snake> SetSnakes()
        {
            //hardcoded values since snakes are static 
            //DEFINING SNAKES
            List<Snake> snakes = new List<Snake>();
            //Snake("Name of Snake",head value,Start Index,End Index)
            snakes.Add(new Snake("S-64", 99, new Index(0, 1), new Index(3, 3)));//(S - 64, 01, 33)
            snakes.Add(new Snake("S-02", 21, new Index(7, 0), new Index(9, 1)));//(S - 02, 70, 91)
            snakes.Add(new Snake("S-03", 62, new Index(3, 1), new Index(9, 2)));//(S - 03, 31, 92)
            snakes.Add(new Snake("S-55", 83, new Index(1, 2), new Index(4, 5)));//(S - 55, 12, 45)
            snakes.Add(new Snake("S-71", 95, new Index(0, 5), new Index(2, 9)));//(S - 71, 05, 29)
            snakes.Add(new Snake("S-57", 75, new Index(2, 5), new Index(4, 3)));//(S - 57, 25, 43)
            snakes.Add(new Snake("S-45", 87, new Index(1, 6), new Index(5, 4)));//(S - 45, 16, 54)
            snakes.Add(new Snake("S-06", 93, new Index(0, 7), new Index(9, 5)));//(S - 06, 07, 95)
            snakes.Add(new Snake("S-47", 73, new Index(2, 7), new Index(5, 6)));//(S - 47, 27, 56)
            snakes.Add(new Snake("S-09", 13, new Index(8, 7), new Index(9, 8)));//(S - 09, 87, 98)
            return snakes;
        }
        public Dice SetDice()
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
            return new Dice(isNormalDice);
        }

        public List<Grid> SetBoard(List<Snake> snakes, List<Ladder> ladders)
        {
            List<Grid> board = new List<Grid>();
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
                        boardValue = Helper.SetSnakeNLadder(snakes, ladders, i, j);
                    }
                    else
                    {
                        boardValue = Helper.SetOtherValues(dessendingBoardValues, assendingBoardValues, i, j);
                    }
                    if (i % 2 == 0)
                        dessendingBoardValues--;
                    else
                        assendingBoardValues++;
                    Console.Write("    " + boardValue + "    ");
                    board.Add(new Grid(boardValue, new Index(i, j)));
                }
                if (i % 2 == 0)
                    dessendingBoardValues = dessendingBoardValues - 10;
                else
                    assendingBoardValues = assendingBoardValues - 30;
                Console.WriteLine();
            }
            return board;
        }
    }
}
