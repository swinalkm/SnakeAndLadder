using SnakeLadder.Host.contracts;
using System.Collections.Generic;

namespace SnakeLadder.Host.DataContracts
{
    public interface ILadder
    {
        Player StepUp();
        List<Ladder> SetLadders();
        List<Ladder> GetLadders();
    }
}
