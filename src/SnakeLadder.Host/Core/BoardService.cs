using SnakeLadder.Host.DataContracts;
using System;
using System.Collections.Generic;

namespace SnakeLadder.Host
{
    public class BoardService : IBoard
    {
        public List<BoardBlock> Grid { get; set; }

        public List<BoardBlock> GetBoard()
        {
            Grid.EnsureNotNullOrEmpty();
            return Grid;
        }

        public List<BoardBlock> SetBoard(List<Snake> snakes, List<Ladder> ladders)
        {
            snakes.EnsureNotNullOrEmpty();
            ladders.EnsureNotNullOrEmpty();
            Grid = new List<BoardBlock>();
            Console.WriteLine("\t\t\t\t\t ****GAME BOARD**** ");
            int dessendingBoardValues = 100; // hardcoded numbers, since board is static
            int assendingBoardValues = 81;
            string boardValue = null;
            for (int row = 0; row < 10; row++)
            {
                for (int column = 0; column < 10; column++)
                {
                    boardValue = SetObjects(snakes, ladders, dessendingBoardValues, assendingBoardValues, row, column);
                    if (row % 2 == 0)
                        dessendingBoardValues--;
                    else
                        assendingBoardValues++;
                    Console.Write("    " + boardValue + "(" + row + column + ")" + "    ");
                    Grid.Add(new BoardBlock(boardValue, new Index(row, column)));
                }
                if (row % 2 == 0)
                    dessendingBoardValues = dessendingBoardValues - 10;
                else
                    assendingBoardValues = assendingBoardValues - 30;
                Console.WriteLine();
            }
            return Grid;
        }

        private static string SetObjects(List<Snake> snakes, List<Ladder> ladders, int dessendingBoardValues, int assendingBoardValues, int i, int j)
        {
            string boardValue;
            if ((snakes.Exists(snake => snake.Head.Row.Equals(i) && snake.Head.Column.Equals(j))) || (ladders.Exists(ladder => ladder.Foot.Row.Equals(i) && ladder.Foot.Column.Equals(j))))
                boardValue = Helper.SetSnakeNLadder(snakes, ladders, i, j);
            else
                boardValue = Helper.SetOtherValues(dessendingBoardValues, assendingBoardValues, i, j);
            return boardValue;
        }
    }
}
