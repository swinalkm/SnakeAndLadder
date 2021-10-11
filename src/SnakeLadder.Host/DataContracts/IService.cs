using SnakeLadder.Host.contracts;
using System.Collections.Generic;

namespace SnakeLadder.Host
{
    public interface IService
    {
        List<Player> Start(List<Player> players);
        void End(List<Player> players);
    }
}