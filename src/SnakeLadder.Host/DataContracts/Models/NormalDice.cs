namespace SnakeLadder.Host.DataContracts
{
    public class NormalDice : Dice, IDice
    {
        public int Roll()
        {
            return Count.Next(1, 7);
        }
    }
}
