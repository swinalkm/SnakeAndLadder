using Moq;
using SnakeLadder.Host;
using SnakeLadder.Host.DataContracts;
using System;
using System.Collections.Generic;
using Xunit;

namespace SnakeLadder.Tests
{
    public class OrchestratorTests
    {
        private Mock<IService> _service;
        private Mock<IPlayer> _player;
        private Mock<ISnake> _snake;
        private Mock<ILadder> _ladder;
        private Mock<IBoard> _board;
        private Mock<IDiceFactory> _diceFactory;
        private Orchestrator _orchestrator;
        public OrchestratorTests()
        {
            _service = new Mock<IService>();
            _player = new Mock<IPlayer>();
            _snake = new Mock<ISnake>();
            _ladder = new Mock<ILadder>();
            _board = new Mock<IBoard>();
            _diceFactory = new Mock<IDiceFactory>();
            _orchestrator = new Orchestrator(_service.Object, _player.Object, _snake.Object, _ladder.Object, _board.Object, _diceFactory.Object);
        }

        [Fact]
        public void Start_WithMockedvaluesShouldStartGame_AndReturnPlayerWithFinalPositions()
        {
            _service.Setup(x => x.Start(It.IsAny<List<Player>>())).Returns(new List<Player>());
            var response = _orchestrator.Start();
            Assert.NotNull(response);
        }
        [Fact]
        public void End_WithMockedvaluesShouldEndGame_Successfully()
        {
            try
            {
                _service.Setup(x => x.Start(It.IsAny<List<Player>>())).Returns(new List<Player>());
                var request = _orchestrator.Start();
                _orchestrator.End(request);
                Assert.True(true);
            }
            catch(Exception ex)
            {
                Assert.True(false);
            }
        }
    }
}
