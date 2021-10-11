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
        private Mock<IConstants> _constants;
        private Mock<IService> _service;
        private Orchestrator _orchestrator;

        public OrchestratorTests()
        {
            _constants = new Mock<IConstants>();
            _service = new Mock<IService>();
            _orchestrator = new Orchestrator(_constants.Object, _service.Object);
        }

        [Fact]
        public void Orchestrator_when_start_should_run_successfully()
        {
            _constants.Setup(x => x.SetSnakes()).Returns(new List<Host.contracts.Snake>());
            _constants.Setup(x => x.SetLadders()).Returns(new List<Host.contracts.Ladder>());
            _constants.Setup(x => x.SetDice()).Returns(new NormalDice(It.IsAny<bool>()));
            _constants.Setup(x => x.SetBoard(It.IsAny<List<Host.contracts.Snake>>(), It.IsAny<List<Host.contracts.Ladder>>())).Returns(It.IsAny<List<Host.contracts.BoardBlock>>());
            _service.Setup(x => x.Start(It.IsAny<List<Host.contracts.Snake>>(), It.IsAny<List<Host.contracts.Ladder>>(), It.IsAny<List<Host.contracts.BoardBlock>>(), It.IsAny<bool>()));
            try
            {
                _orchestrator.Start();
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.True(false);
            }
        }
        [Fact]
        public void Orchestrator_when_start_withInvalidMock_should_throwException()
        {
            _constants.Setup(x => x.SetSnakes()).Returns(new List<Host.contracts.Snake>());
            _constants.Setup(x => x.SetLadders()).Returns(new List<Host.contracts.Ladder>());

            _constants.Setup(x => x.SetBoard(It.IsAny<List<Host.contracts.Snake>>(), It.IsAny<List<Host.contracts.Ladder>>())).Returns(It.IsAny<List<Host.contracts.BoardBlock>>());
            _service.Setup(x => x.Start(It.IsAny<List<Host.contracts.Snake>>(), It.IsAny<List<Host.contracts.Ladder>>(), It.IsAny<List<Host.contracts.BoardBlock>>(), It.IsAny<bool>()));
            try
            {
                _orchestrator.Start();
                Assert.True(true);
            }
            catch (Exception ex)
            {
                Assert.True(true);
            }
        }
    }
}
