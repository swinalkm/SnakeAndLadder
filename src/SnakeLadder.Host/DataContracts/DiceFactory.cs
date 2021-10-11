using SnakeLadder.Host.DataContracts.Models;
using System;

namespace SnakeLadder.Host.DataContracts
{
    public class DiceFactory : IDiceFactory
    {
        public IDice SetDice()
        {
            Console.WriteLine("1. PRESS 1 FOR NORMAL DICE");
            Console.WriteLine("2. PRESS 2 FOR CROOKED DICE");
            var dice = Console.ReadLine();
            if (dice == "1" || dice == "2")
            {
                if (dice == "1")
                    return new NormalDice();
                else
                    return new CrookedDice();
            }
            else
            {
                Console.WriteLine("INVALID INPUT !!!");
                Console.ReadKey();
                Environment.Exit(0);
            }
            return null;
        }
    }
}
