namespace SnakeLadder.Host.DataContracts
{
    public class Snake
    {
        public Snake(string uniqueKey, int uniqueValue, Index head, Index tail)
        {
            UniqueKey = uniqueKey;
            UniqueValue = uniqueValue;
            Head = head;
            Tail = tail;
        }
        public string UniqueKey { get; set; }
        public int UniqueValue { get; set; }
        public Index Head { get; set; }
        public Index Tail { get; set; }
    }
}
