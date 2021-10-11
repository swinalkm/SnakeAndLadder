using System;
using System.Collections.Generic;
using System.Linq;
using SnakeLadder.Host.contracts;

namespace SnakeLadder.Host.DataContracts
{
    public class SnakeService : ISnake
    {
        private readonly IBoard _board;

        public SnakeService(IBoard board)
        {
            _board = board;
        }

        public List<Snake> Snakes { get; set; }
        public Player BitePlayer(Player player, int diceRolled)
        {
            var board = _board.GetBoard();
            var snake = Snakes.FirstOrDefault(x => x.HeadValue.Equals(player.CurrenKey + diceRolled));
            var playerValue = board.FirstOrDefault(x => x.Index.Row.Equals(snake.Tail.Row) && x.Index.Column.Equals(snake.Tail.Column));
            player.CurrenKey = Int16.Parse(GetValue(playerValue, "S-"));
            player.Index = new Index(snake.Tail.Row, snake.Tail.Column);
            return player;
        }
        public string GetValue(BoardBlock playerValue, string key)
        {
            return playerValue.Key.Replace(key, "  ").Trim();
        }
        public List<Snake> GetSnakes()
        {
            return Snakes;
        }

        public List<Snake> SetSnakes()
        {
            //hardcoded values since snakes are static 
            //DEFINING SNAKES
            Snakes = new List<Snake>();
            //Snake("Name of Snake",head value,Start Index,End Index)
            Snakes.Add(new Snake("S-64", 99, new Index(0, 1), new Index(3, 3)));//(S - 64, 01, 33)
            Snakes.Add(new Snake("S-02", 21, new Index(7, 0), new Index(9, 1)));//(S - 02, 70, 91)
            Snakes.Add(new Snake("S-03", 62, new Index(3, 1), new Index(9, 2)));//(S - 03, 31, 92)
            Snakes.Add(new Snake("S-55", 83, new Index(1, 2), new Index(4, 5)));//(S - 55, 12, 45)
            Snakes.Add(new Snake("S-71", 95, new Index(0, 5), new Index(2, 9)));//(S - 71, 05, 29)
            Snakes.Add(new Snake("S-57", 75, new Index(2, 5), new Index(4, 3)));//(S - 57, 25, 43)
            Snakes.Add(new Snake("S-45", 87, new Index(1, 6), new Index(5, 4)));//(S - 45, 16, 54)
            Snakes.Add(new Snake("S-06", 93, new Index(0, 7), new Index(9, 5)));//(S - 06, 07, 95)
            Snakes.Add(new Snake("S-47", 73, new Index(2, 7), new Index(5, 6)));//(S - 47, 27, 56)
            Snakes.Add(new Snake("S-09", 13, new Index(8, 7), new Index(9, 8)));//(S - 09, 87, 98)
            return Snakes;
        }
    }
}
