using System;
using System.Collections.Generic;
using SnakeLadder.Host.contracts;

namespace SnakeLadder.Host.DataContracts
{
    public class Board : IBoard
    {
        public List<BoardBlock> Grid { get; set; }

        public List<BoardBlock> GetBoard()
        {
            return Grid;
        }

        public List<BoardBlock> SetBoard(List<Snake> snakes, List<Ladder> ladders)
        {
            Grid = new List<BoardBlock>();
            Console.WriteLine("\t\t\t\t\t ****GAME BOARD**** ");
            int dessendingBoardValues = 100; // hardcoded numbers, since board is static
            int assendingBoardValues = 81;
            string boardValue = null;
            for (int i = 0; i < 10; i++)
            {
                for (int j = 0; j < 10; j++)
                {
                    if ((snakes.Exists(snake => snake.Head.Row.Equals(i) && snake.Head.Column.Equals(j))) || (ladders.Exists(ladder => ladder.Foot.Row.Equals(i) && ladder.Foot.Column.Equals(j))))
                        boardValue = Helper.SetSnakeNLadder(snakes, ladders, i, j);
                    else
                        boardValue = Helper.SetOtherValues(dessendingBoardValues, assendingBoardValues, i, j);
                    if (i % 2 == 0)
                        dessendingBoardValues--;
                    else
                        assendingBoardValues++;
                    Console.Write("    " + boardValue + "(" + i + j + ")" + "    ");
                    Grid.Add(new BoardBlock(boardValue, new Index(i, j)));
                }
                if (i % 2 == 0)
                    dessendingBoardValues = dessendingBoardValues - 10;
                else
                    assendingBoardValues = assendingBoardValues - 30;
                Console.WriteLine();
            }
            return Grid;
        }
    }
}
