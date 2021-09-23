using FluentAssertions;
using SnakeLadder.Host;
using SnakeLadder.Host.DataContracts;
using Xunit;

namespace SnakeLadder.Tests
{
    public class ServiceTests
    {
        private Service _service;
        private IConstants _constants;
        public ServiceTests()
        {
            _service = new Service();
            _constants = new Constants();
        }

        [Fact]
        public void RollDice_with_validInput_should_run_successfully()
        {
            var response = _service.RollDice(new System.Random(), true);
            response.Should().NotBe(0);
            response.Should().BeLessThan(7);
            response.Should().BeGreaterThan(0);
        }
        [Fact]
        public void RollDice_with_CrookedDice_should_run_successfully()
        {
            var response = _service.RollDice(new System.Random(), false);
            response.Should().NotBe(0);
            Assert.True(response % 2 == 0);
            response.Should().BeGreaterThan(0);
        }
        [Fact]
        public void Snake_at21_shouldMovePlayerTo2_success()
        {
            var snake = _constants.SetSnakes();
            var ladder = _constants.SetLadders();
            var response = _service.GetCurrentPosition(snake, ladder, _constants.SetBoard(snake, ladder), new Host.contracts.Player(20, new Host.contracts.Index(8, 0)), 1);

            Assert.NotNull(response);
            Assert.Equal(response.CurrentPossition, 2);
            Assert.Equal(response.Index.Row, 9);
            Assert.Equal(response.Index.Column, 1);
        }
        [Fact]
        public void Ladder_at7_shouldMovePlayerTo40_success()
        {
            var snake = _constants.SetSnakes();
            var ladder = _constants.SetLadders();
            var response = _service.GetCurrentPosition(snake, ladder, _constants.SetBoard(snake, ladder), new Host.contracts.Player(6, new Host.contracts.Index(6, 3)), 1);

            Assert.NotNull(response);
            Assert.Equal(response.CurrentPossition, 40);
            Assert.Equal(response.Index.Row, 6);
            Assert.Equal(response.Index.Column, 0);
        }
    }
}
