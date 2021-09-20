namespace SnakeLadder.Host.contracts
{
    public class Snake
    {
        public Snake(string key, int headValue, Index head, Index tail)
        {
            Key = key;
            HeadValue = headValue;
            Head = head;
            Tail = tail;
        }
        public string Key { get; set; }
        public int HeadValue { get; set; }
        public Index Head { get; set; }
        public Index Tail { get; set; }
    }
}
