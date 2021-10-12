using System.Collections.Generic;

namespace SnakeLadder.Host.DataContracts
{
    public interface IBoard
    {
        List<BoardBlock> SetBoard(List<Snake> snakes, List<Ladder> ladders);
        List<BoardBlock> GetBoard();
    }
}
