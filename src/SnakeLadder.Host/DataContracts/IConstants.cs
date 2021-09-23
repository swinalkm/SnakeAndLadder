using SnakeLadder.Host.contracts;
using System.Collections.Generic;

namespace SnakeLadder.Host.DataContracts
{
    public interface IConstants
    {
        List<Ladder> SetLadders();
        List<Snake> SetSnakes();
        Dice SetDice();
        List<Grid> SetBoard(List<Snake> snakes, List<Ladder> ladders);
    }
}
