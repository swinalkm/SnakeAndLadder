using SnakeLadder.Host.contracts;
using System.Collections.Generic;

namespace SnakeLadder.Host
{
    public interface IService
    {
        void Start(List<Snake> snakes, List<Ladder> ladders, List<Grid> board, bool isNormalDice);
    }
}