namespace SnakeLadder.Host.contracts
{
    public class Snake
    {
        //lets say S-2 is at position 21 in board 
        //Key = S-2
        //headValue = 21
        //Head index{7,0}
        //Tail index{9,1}
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
