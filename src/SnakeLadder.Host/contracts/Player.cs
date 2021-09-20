namespace SnakeLadder.Host.contracts
{
    public class Player
    {
        public Player(int currentValue, Index index)
        {
            CurrentValue = currentValue;
            Index = index;
        }

        public int CurrentValue { get; set; }
        public Index Index { get; set; }
    }
}
