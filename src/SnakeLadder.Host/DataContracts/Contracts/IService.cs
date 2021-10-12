﻿using System.Collections.Generic;

namespace SnakeLadder.Host.DataContracts
{
    public interface IService
    {
        List<Player> Start(List<Player> players);
        void End(List<Player> players);
    }
}