namespace SnakeLadder.Host.DataContracts
{
    public class Player
    {
        public Player(string name, int currenKey, Index index)
        {
            Name = name;
            CurrenKey = currenKey;
            Index = index;
        }

        public string Name { get; set; }
        public int CurrenKey { get; set; }
        public Index Index { get; set; }
    }
}
