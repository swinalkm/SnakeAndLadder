using SnakeLadder.Host.contracts;
using System.Collections.Generic;

namespace SnakeLadder.Host.DataContracts
{
    public interface ISnake
    {
        Player BitePlayer(Player player, int diceRolled);
        List<Snake> SetSnakes();
        List<Snake> GetSnakes();
    }
}
