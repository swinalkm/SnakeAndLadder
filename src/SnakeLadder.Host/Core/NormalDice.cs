using SnakeLadder.Host.DataContracts;

namespace SnakeLadder.Host
{
    public class NormalDice : Dice, IDice
    {
        public int Roll()
        {
            return Count.Next(1, 7);
        }
    }
}
