namespace SnakeLadder.Host.DataContracts
{
    public class Ladder
    {
        public Ladder(string uniqueKey, int uniqueValue, Index foot, Index tip)
        {
            UniqueKey = uniqueKey;
            UniqueValue = uniqueValue;
            Tip = tip;
            Foot = foot;
        }

        public string UniqueKey { get; set; }
        public int UniqueValue { get; set; }
        public Index Tip { get; set; }
        public Index Foot { get; set; }
    }
}
