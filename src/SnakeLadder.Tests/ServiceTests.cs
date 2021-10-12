using FluentAssertions;
using Moq;
using SnakeLadder.Host;
using SnakeLadder.Host.DataContracts;
using System.Collections.Generic;
using Xunit;

namespace SnakeLadder.Tests
{
    public class ServiceTests
    {
        private readonly Mock<IDice> _dice;
        private readonly Mock<IPlayer> _player;
        private Service _service;
        public ServiceTests()
        {
            _dice = new Mock<IDice>();
            _player = new Mock<IPlayer>();
            _service = new Service(_dice.Object, _player.Object);
        }

        //[Fact]
        //public void Start_WithValidPlayersShouldReturnEndResultsOfPlayer_Successfully()
        //{
        //    var response = _service.Start(new List<Player>() { new Player("Player1",1, new Index(0, 0)),
        //        new Player("Player2",1, new Index(0, 0))});

        //}

    }
}
