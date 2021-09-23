namespace SnakeLadder.Host.DataContracts
{
    public class Dice
    {
        public Dice(bool isNormalDice)
        {
            IsNormalDice = isNormalDice;
        }

        public bool IsNormalDice { get; set; }
    }
}
