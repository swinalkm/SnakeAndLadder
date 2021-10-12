namespace SnakeLadder.Host.DataContracts
{
    public class Index
    {
        public Index(int row, int column)
        {
            Row = row;
            Column = column;
        }

        public int Row { get; set; }
        public int Column { get; set; }
        public Index GetIndex(string key)
        {
            return new Index(1, 1);
        }
        public Index SetIndex(int row, int column)
        {
            return new Index(row, column);
        }
    }
}
