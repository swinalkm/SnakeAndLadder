using SnakeLadder.Host.contracts;
using System.Collections.Generic;

namespace SnakeLadder.Host.DataContracts
{
    public interface IPlayer
    {
        List<Player> SetPlayers(int players);
        Player GetPlayerCurrentPosition(string name);
        Player GetPlayerNextPosition(Player current, int diceRolled);
    }
}
