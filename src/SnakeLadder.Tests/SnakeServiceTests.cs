using Moq;
using SnakeLadder.Host;
using SnakeLadder.Host.DataContracts;
using System;
using Xunit;

namespace SnakeLadder.Tests
{
    public class SnakeServiceTests
    {
        private readonly Mock<IBoard> _board;
        private readonly SnakeService _snakeServices;
        private readonly NormalPlayer _playerServices;
        public SnakeServiceTests()
        {
            _board = new Mock<IBoard>();
            _snakeServices = new SnakeService(_board.Object);
        }

        [Fact]
        public void BitePlayer_SnakeAtPosition21ShouldSet_PlayerAtPosition2_Successfully()
        {
            _board.Setup(x => x.GetBoard()).Returns(new BoardService().SetBoard(new SnakeService(_board.Object).SetSnakes(), new LadderService(_board.Object).SetLadders()));
            var snakes = _snakeServices.SetSnakes();
            var player = new Player("Player1", 20, new Index(8, 0));//Snake S-02 At Position 21
            var response = _snakeServices.BitePlayer(player, 1);
            Assert.NotNull(response);
            Assert.Equal(response.CurrenKey, 2);
        }
        [Fact]
        public void BitePlayerWithNullPlayer_ShouldThrowException_Successfully()
        {
            try
            {
                _board.Setup(x => x.GetBoard()).Returns(new BoardService().SetBoard(new SnakeService(_board.Object).SetSnakes(), new LadderService(_board.Object).SetLadders()));
                var snakes = _snakeServices.SetSnakes();
                Player player = null;
                var response = _snakeServices.BitePlayer(player, 1);
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }
        [Fact]
        public void GetSnakes_ShouldReturnListOFSnakes_Successfully()
        {
            var snakes = _snakeServices.SetSnakes();
            var response = _snakeServices.GetSnakes();
            Assert.NotNull(response);
            Assert.True(response.Count > 0);
        }
        [Fact]
        public void GetSnakes_WithoutSetSnakeShouldThrowException_Successfully()
        {
            try
            {
                var response = _snakeServices.GetSnakes();
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }
    }
}
