using System.Collections.Generic;

namespace SnakeLadder.Host.DataContracts
{
    public interface IOrchestrator
    {
        List<Player> Start();
        void End(List<Player> players);
    }
}
