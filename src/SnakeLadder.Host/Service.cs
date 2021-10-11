using SnakeLadder.Host.contracts;
using SnakeLadder.Host.DataContracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeLadder.Host
{
    public class Service : IService
    {
        private readonly IDice _dice;
        private readonly IPlayer _player;

        public Service(IDice dice, IPlayer player)
        {
            _dice = dice;
            _player = player;
        }

        public List<Player> Start(List<Player> players)
        {
            var player1 = players.FirstOrDefault(player => player.Name.Equals("player1", StringComparison.InvariantCultureIgnoreCase));
            int toRollPlayer1 = 0;
            var player2 = players.FirstOrDefault(player => player.Name.Equals("player2", StringComparison.InvariantCultureIgnoreCase));
            int toRollPlayer2 = 0;
            int index = 1;
            do
            {
                if (player1.CurrenKey == 100 || player2.CurrenKey == 100)
                    return End(player1, player2);
                Console.WriteLine("PRESS ENTER");
                Console.ReadKey();
                Console.WriteLine("<--- SET " + index + " --->");
                //player 1
                toRollPlayer1 = _dice.Roll();
                Console.WriteLine("PLAYER 1 :  CURRENT POSITION = " + player1.CurrenKey + ", DICE ROLLED TO = " + toRollPlayer1);
                player1 = _player.GetPlayerNextPosition(player1, toRollPlayer1);
                //player 2
                toRollPlayer2 = _dice.Roll();
                Console.WriteLine("PLAYER 2 :  CURRENT POSITION = " + player2.CurrenKey + ", DICE ROLLED TO = " + toRollPlayer2);
                player2 = _player.GetPlayerNextPosition(player2, toRollPlayer2);
                index++;

            } while (true);
        }

        private static List<Player> End(Player player1, Player player2)
        {
            var result = new List<Player>();
            result.Add(player1);
            result.Add(player2);
            return result;
        }

        public void End(List<Player> players)
        {
            var player1 = players.FirstOrDefault(player => player.Name.Equals("player1", StringComparison.InvariantCultureIgnoreCase));
            var player2 = players.FirstOrDefault(player => player.Name.Equals("player2", StringComparison.InvariantCultureIgnoreCase));
            Console.WriteLine("FINAL SCORES : ");
            if (player1.CurrenKey == 100)
            {
                Console.WriteLine("!!! PLAYER 1 WINS !!!");
                Console.WriteLine("PLAYER 1 :  CURRENT POSITION = " + player1.CurrenKey + ", TOTAL  = " + 100);
            }
            else
            {
                Console.WriteLine("!!! PLAYER 2 WINS !!!");
                Console.WriteLine("PLAYER 2 :  CURRENT POSITION = " + player2.CurrenKey + ", TOTAL = " + 100);
            }
        }
    }
}
