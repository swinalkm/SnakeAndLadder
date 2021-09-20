namespace SnakeLadder.Host.contracts
{
    public class Snake
    {
        public Snake(string key, Index mouth, Index tail)
        {
            Key = key;
            Mouth = mouth;
            Tail = tail;
        }

        public string Key { get; set; }
        public Index Mouth { get; set; }
        public Index Tail { get; set; }
    }
}
