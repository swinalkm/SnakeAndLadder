using SnakeLadder.Host.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeLadder.Host
{
    public class NormalPlayer : IPlayer
    {
        private readonly IBoard _board;
        private readonly ISnake _snake;
        private readonly ILadder _ladder;

        public NormalPlayer(IBoard board, ISnake snake, ILadder ladder)
        {
            _board = board;
            _snake = snake;
            _ladder = ladder;
        }

        public Player GetPlayerCurrentPosition(string name)
        {
            return null;
        }

        public Player MovePlayer(Player currentPlayer, int diceRolled)
        {
            var total = currentPlayer.CurrenKey + diceRolled;
            var board = _board.GetBoard();
            var ladders = _ladder.GetLadders();

            if (board.Exists(x => x.Key.Trim().Equals(total.ToString())))
            {
                currentPlayer.CurrenKey = total;
                var count = board.FirstOrDefault(x => x.Key.Trim().Equals(total.ToString()));
                currentPlayer.Index = new Index(count.Index.Row, count.Index.Column);
            }
            else if (_snake.GetSnakes().Exists(x => x.UniqueValue.Equals(total)))
                currentPlayer = _snake.BitePlayer(currentPlayer, diceRolled);
            else if (ladders.Exists(x => x.UniqueValue.Equals(total)))
                currentPlayer = _ladder.StepUp(currentPlayer, diceRolled);
            return currentPlayer;
        }

        public List<Player> SetPlayers(int players)
        {
            Console.WriteLine("2 PLAYERS");
            return new List<Player>() {
                new Player("Player1",1, new Index(0, 0)),
                new Player("Player2",1, new Index(0, 0))
            };
        }
    }
}
