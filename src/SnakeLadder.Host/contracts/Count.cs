namespace SnakeLadder.Host.contracts
{
    public class Count
    {
        public Count(string key, Index index)
        {
            Key = key;
            Index = index;
        }

        public string Key { get; set; }
        public Index Index { get; set; }
    }
}
