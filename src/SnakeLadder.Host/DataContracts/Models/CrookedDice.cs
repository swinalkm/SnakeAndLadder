namespace SnakeLadder.Host.DataContracts.Models
{
    public class CrookedDice : Dice, IDice
    {
        public int Roll()
        {
            var rolledValue = Count.Next(1, 7);
            if (rolledValue % 2 == 0)
                return rolledValue;
            else
                Roll();
            return 6;
        }
    }
}
