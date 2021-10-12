using Moq;
using SnakeLadder.Host;
using SnakeLadder.Host.DataContracts;
using System;
using Xunit;

namespace SnakeLadder.Tests
{
    public class PlayerServiceTests
    {
        private readonly Mock<IBoard> _board;
        private readonly Mock<ISnake> _snake;
        private readonly Mock<ILadder> _ladder;
        private readonly NormalPlayer _playerServices;
        public PlayerServiceTests()
        {
            _board = new Mock<IBoard>();
            _snake = new Mock<ISnake>();
            _ladder = new Mock<ILadder>();
            _playerServices = new NormalPlayer(_board.Object, _snake.Object, _ladder.Object);
        }

        [Fact]
        public void MovePlayer_SetsPlayerToRolledposition_Successfully()
        {
            _board.Setup(x => x.GetBoard()).Returns(new BoardService().SetBoard(new SnakeService(_board.Object).SetSnakes(), new LadderService(_board.Object).SetLadders()));
            _ladder.Setup(x => x.GetLadders()).Returns(new LadderService(_board.Object).SetLadders());
            var response = _playerServices.MovePlayer(new Player("player1", 1, new Index(0, 0)), 3); //player rolled to 3 dice from 1st position
            Assert.NotNull(response);
            Assert.Equal(response.CurrenKey, 4);
        }
    }
}
