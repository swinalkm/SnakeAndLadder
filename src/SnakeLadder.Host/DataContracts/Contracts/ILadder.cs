using System.Collections.Generic;

namespace SnakeLadder.Host.DataContracts
{
    public interface ILadder
    {
        Player StepUp(Player player, int diceRolled);
        List<Ladder> SetLadders();
        List<Ladder> GetLadders();
    }
}
