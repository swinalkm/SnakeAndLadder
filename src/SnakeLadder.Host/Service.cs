using SnakeLadder.Host.contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeLadder.Host
{
    public class Service : IService
    {
        public void Start(List<Snake> snakes, List<Ladder> ladders, List<Grid> board, bool isNormalDice)
        {
            var player1 = new Player(1, new Index(0, 0));
            int toRollPlayer1 = 0;
            var player2 = new Player(1, new Index(0, 0));
            int toRollPlayer2 = 0;
            Random random = new Random();
            int index = 1;
            do
            {
                if (player1.CurrentPossition == 100 || player2.CurrentPossition == 100)
                    break;
                Console.WriteLine("PRESS ENTER");
                Console.ReadKey();
                Console.WriteLine("<--- SET " + index + " --->");
                //player 1
                toRollPlayer1 = RollDice(random, isNormalDice);
                Console.WriteLine("PLAYER 1 :  CURRENT POSITION = " + player1.CurrentPossition + ", DICE ROLLED TO = " + toRollPlayer1);
                player1 = GetNextCurrentPosition(snakes, ladders, board, player1, toRollPlayer1);
                //player 2
                toRollPlayer2 = RollDice(random, isNormalDice);
                Console.WriteLine("PLAYER 2 :  CURRENT POSITION = " + player2.CurrentPossition + ", DICE ROLLED TO = " + toRollPlayer2);
                player2 = GetNextCurrentPosition(snakes, ladders, board, player2, toRollPlayer2);
                index++;

            } while (true);
            Console.WriteLine("FINAL SCORES : ");
            if (player1.CurrentPossition == 100)
            {
                Console.WriteLine("!!! PLAYER 1 WINS !!!");
                Console.WriteLine("PLAYER 1 :  CURRENT POSITION = " + player1.CurrentPossition + ", DICE ROLLED TO = " + toRollPlayer1);
            }
            else
            {
                Console.WriteLine("!!! PLAYER 2 WINS !!!");
                Console.WriteLine("PLAYER 2 :  CURRENT POSITION = " + player2.CurrentPossition + ", DICE ROLLED TO = " + toRollPlayer2);
            }
        }

        public int RollDice(Random random, bool isNormalDice)
        {
            var randomNo = random.Next(1, 7);
            if (isNormalDice == true)
                return randomNo;
            else
            {
                if (randomNo % 2 == 0)
                    return randomNo;
                else
                    RollDice(new Random(), false);
            }
            return 6;
        }

        public Player GetNextCurrentPosition(List<Snake> snakes, List<Ladder> ladders, List<Grid> board, Player player, int toRoll)
        {
            var total = player.CurrentPossition + toRoll;

            if (board.Exists(x => x.Key.Trim().Equals(total.ToString())))
            {
                player.CurrentPossition = total;
                var count = board.FirstOrDefault(x => x.Key.Trim().Equals(total.ToString()));
                player.Index = new Index(count.Index.Row, count.Index.Column);
            }
            else if (snakes.Exists(x => x.HeadValue.Equals(total)))
            {
                var snake = snakes.FirstOrDefault(x => x.HeadValue.Equals(total));
                var playerValue = board.FirstOrDefault(x => x.Index.Row.Equals(snake.Tail.Row) && x.Index.Column.Equals(snake.Tail.Column));
                player.CurrentPossition = Int16.Parse(GetValue(playerValue, "S-"));
                player.Index = new Index(snake.Tail.Row, snake.Tail.Column);
            }
            else if (ladders.Exists(x => x.FootValue.Equals(total)))
            {
                var ladder = ladders.FirstOrDefault(x => x.FootValue.Equals(total));
                var playerValue = board.FirstOrDefault(x => x.Index.Row.Equals(ladder.Tip.Row) && x.Index.Column.Equals(ladder.Tip.Column));
                string stringValue = GetValue(playerValue, "L-");
                player.CurrentPossition = Int16.Parse(stringValue);
                player.Index = new Index(ladder.Tip.Row, ladder.Tip.Column);
            }
            return player;
        }

        public string GetValue(Grid playerValue, string key)
        {
            return playerValue.Key.Replace(key, "  ").Trim();
        }
    }
}
