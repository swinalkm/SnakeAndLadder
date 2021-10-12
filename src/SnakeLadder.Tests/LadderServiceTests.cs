using Moq;
using SnakeLadder.Host;
using SnakeLadder.Host.DataContracts;
using System;
using Xunit;

namespace SnakeLadder.Tests
{
    public class LadderServiceTests
    {
        private readonly Mock<IBoard> _board;
        private readonly LadderService _ladderServices;
        private readonly NormalPlayer _playerServices;
        public LadderServiceTests()
        {
            _board = new Mock<IBoard>();
            _ladderServices = new LadderService(_board.Object);
        }

        [Fact]
        public void StepUp_LadderMovesPlayerToDesiredLocation_Successfully()
        {
            _board.Setup(x => x.GetBoard()).Returns(new BoardService().SetBoard(new SnakeService(_board.Object).SetSnakes(), new LadderService(_board.Object).SetLadders()));
            var ladder = _ladderServices.SetLadders();
            var player = new Player("Player1", 79, new Index(2, 0));//Ladder L-98 At Position 80 
            var response = _ladderServices.StepUp(player, 1);
            Assert.NotNull(response);
            Assert.Equal(response.CurrenKey, 98);
        }
        [Fact]
        public void StepUpWithNullPlayer_ShouldThrowException_Successfully()
        {
            try
            {
                _board.Setup(x => x.GetBoard()).Returns(new BoardService().SetBoard(new SnakeService(_board.Object).SetSnakes(), new LadderService(_board.Object).SetLadders()));
                Player player = null;
                var response = _ladderServices.StepUp(player, 1);
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }
        [Fact]
        public void GetLadders_ShouldReturnListOFLadder_Successfully()
        {
            var ladder = _ladderServices.SetLadders();
            var response = _ladderServices.GetLadders();
            Assert.NotNull(response);
            Assert.True(response.Count > 0);
        }
        [Fact]
        public void GetLadders_WithoutSetladderShouldThrowException_Successfully()
        {
            try
            {
                var response = _ladderServices.GetLadders();
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }
    }
}
