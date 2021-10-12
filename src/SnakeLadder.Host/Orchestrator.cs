using SnakeLadder.Host.DataContracts;
using System;
using System.Collections.Generic;

namespace SnakeLadder.Host
{
    public class Orchestrator : IOrchestrator
    {
        private IService _service;
        private IPlayer _player;
        private ISnake _snake;
        private ILadder _ladder;
        private IBoard _board;
        private IDiceFactory _diceFactory;
        public Orchestrator(IService service, IPlayer player, ISnake snake, ILadder ladder, IBoard board, IDiceFactory diceFactory)
        {
            _service = service;
            _player = player;
            _snake = snake;
            _ladder = ladder;
            _board = board;
            _diceFactory = diceFactory;
        }

        public List<Player> Start()
        {
            Helper.PrintRules();
            var snakes = _snake.SetSnakes();
            var ladders = _ladder.SetLadders();
            var dice = _diceFactory.SetDice();
            var board = _board.SetBoard(snakes, ladders);
            var players = _player.SetPlayers(2);

            return _service.Start(players);
        }
        public void End(List<Player> players)
        {
            _service.End(players);
        }
    }
}
