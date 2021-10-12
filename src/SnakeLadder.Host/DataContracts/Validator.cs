using System;
using System.Collections.Generic;

namespace SnakeLadder.Host.DataContracts
{
    public static class Validator
    {
        public static void EnsureNotNullOrEmpty(this List<Snake> snakes)
        {
            if (snakes == null || snakes.Count == 0)
                throw new Exception("Invalid or Null Object " + typeof(List<Snake>));
        }
        public static void EnsureNotNullOrEmpty(this List<Ladder> ladder)
        {
            if (ladder == null || ladder.Count == 0)
                throw new Exception("Invalid or Null Object " + typeof(List<Ladder>));
        }
        public static void EnsureNotNullOrEmpty(this List<BoardBlock> grid)
        {
            if (grid == null || grid.Count == 0)
                throw new Exception("Invalid or Null Object " + typeof(List<BoardBlock>));
        }
        public static void EnsureNotNullOrEmpty(this List<Player> players)
        {
            if (players == null || players.Count == 0)
                throw new Exception("Invalid or Null Object " + typeof(List<Player>));
        }
        public static void EnsureNotNullOrEmpty(this Player player)
        {
            if (player == null)
                throw new Exception("Invalid or Null Object " + typeof(List<Player>));
        }
    }
}
