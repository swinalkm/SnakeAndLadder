namespace SnakeLadder.Host.contracts
{
    public class Ladder
    {
        public Ladder(string key, Index tip, Index foot)
        {
            Key = key;
            Tip = tip;
            Foot = foot;
        }

        public string Key { get; set; }
        public Index Tip { get; set; }
        public Index Foot { get; set; }
    }
}
