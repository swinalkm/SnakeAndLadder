using System;

namespace SnakeLadder.Host.DataContracts
{
    public class Dice
    {
        public Random Count { get; set; } = new Random();
    }
}
