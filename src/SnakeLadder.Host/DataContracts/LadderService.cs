using System;
using System.Collections.Generic;
using SnakeLadder.Host.contracts;

namespace SnakeLadder.Host.DataContracts
{
    public class LadderService : ILadder
    {
        public List<Ladder> Ladders { get; set; }

        public List<Ladder> GetLadders()
        {
            return Ladders;
        }

        public List<Ladder> SetLadders()
        {
            //hardcoded values since ladders are static
            //DEFINING LADDER
            Ladders = new List<Ladder>();
            //Ladder("Name Of Ladder",foot value, Start Index, End Index)
            Ladders.Add(new Ladder("L-98", 80, new Index(2, 0), new Index(0, 2)));//(L - 98, 20, 02)
            Ladders.Add(new Ladder("L-77", 38, new Index(6, 2), new Index(2, 3)));//(L - 77, 62, 23)
            Ladders.Add(new Ladder("L-55", 18, new Index(8, 2), new Index(4, 5)));//(L - 55, 82, 45)
            Ladders.Add(new Ladder("L-65", 26, new Index(7, 5), new Index(3, 4)));//(L - 65, 75, 34)
            Ladders.Add(new Ladder("L-86", 67, new Index(3, 6), new Index(1, 5)));//(L - 86, 36, 15)
            Ladders.Add(new Ladder("L-40", 7, new Index(9, 6), new Index(6, 0)));//(L - 40, 96, 60)
            Ladders.Add(new Ladder("L-32", 28, new Index(7, 7), new Index(6, 8)));//(L - 32, 77, 68)
            return Ladders;
        }

        public Player StepUp()
        {
            throw new NotImplementedException();
        }
    }
}
