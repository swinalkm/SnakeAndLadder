namespace SnakeLadder.Host.contracts
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
    }
}
