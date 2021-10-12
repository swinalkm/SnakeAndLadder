namespace SnakeLadder.Host.DataContracts
{
    public class BoardBlock
    {
        public BoardBlock(string key, Index index)
        {
            Key = key;
            Index = index;
        }

        public string Key { get; set; }
        public Index Index { get; set; }
    }
}
