namespace SnakeLadder.Host.contracts
{
    public class Ladder
    {
        //lets say L-22 is at position 2 in board 
        //Key = L-22
        //footvalue = 2
        //tip index{7,1}
        //foot index{9,1}
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
