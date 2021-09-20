namespace SnakeLadder.Host.contracts
{
    public class Ladder
    {
        public Ladder(string key, int footvalue, Index tip, Index foot)
        {
            Key = key;
            FootValue = footvalue;
            Tip = tip;
            Foot = foot;
        }

        public string Key { get; set; }
        public int FootValue { get; set; }
        public Index Tip { get; set; }
        public Index Foot { get; set; }
    }
}
