namespace SnakeLadder.Host.contracts
{
    public class Player
    {
        public Player(int currentPossition, Index index)
        {
            CurrentPossition = currentPossition;
            Index = index;
        }

        public int CurrentPossition { get; set; }
        public Index Index { get; set; }
    }
}
