using SnakeLadder.Host.contracts;
using System;
using System.Collections.Generic;
using System.Linq;

namespace SnakeLadder.Host
{
    public class Service
    {
        public static void Start(List<Snake> snakes, List<Ladder> ladders, List<Count> board, bool isNormalDice)
        {
            var player1 = new Player(1, new Index(0, 0));
            int toRollPlayer1 = 0;
            var player2 = new Player(1, new Index(0, 0));
            int toRollPlayer2 = 0;
            Random random = new Random();
            int index = 1;
            do
            {
                if (player1.CurrentValue == 100 || player2.CurrentValue == 100)
                    break;
                Console.WriteLine("PRESS ENTER");
                Console.ReadKey();
                Console.WriteLine("<--- SET " + index + " --->");
                toRollPlayer1 = GetDiceValue(random, isNormalDice);
                Console.WriteLine("PLAYER 1 :  CURRENT POSITION = " + player1.CurrentValue + ", DICE ROLLED TO = " + toRollPlayer1);
                player1 = GetCurrentPosition(snakes, ladders, board, player1, toRollPlayer1);
                toRollPlayer2 = GetDiceValue(random, isNormalDice);
                Console.WriteLine("PLAYER 2 :  CURRENT POSITION = " + player2.CurrentValue + ", DICE ROLLED TO = " + toRollPlayer2);
                player2 = GetCurrentPosition(snakes, ladders, board, player2, toRollPlayer2);
                index++;

            } while (player1.CurrentValue != 100 || player2.CurrentValue != 100);
            Console.WriteLine("FINAL SCORES : ");
            if (player1.CurrentValue == 100)
            {
                Console.WriteLine("!!! PLAYER 1 WINS !!!");
                Console.WriteLine("PLAYER 1 :  CURRENT POSITION = " + player1.CurrentValue + ", DICE ROLLED TO = " + toRollPlayer1);
            }
            else
            {
                Console.WriteLine("!!! PLAYER 2 WINS !!!");
                Console.WriteLine("PLAYER 2 :  CURRENT POSITION = " + player2.CurrentValue + ", DICE ROLLED TO = " + toRollPlayer2);
            }
        }

        private static int GetDiceValue(Random random, bool isNormalDice)
        {
            if (isNormalDice == true)
                return random.Next(1, 7);
            else
            {
                var no = random.Next(1, 7);
                if (no % 2 == 0)
                    return no;
                else
                    GetDiceValue(new Random(), false);
            }
            return 6;
        }

        private static Player GetCurrentPosition(List<Snake> snakes, List<Ladder> ladders, List<Count> board, Player player, int toRoll)
        {
            var total = player.CurrentValue + toRoll;

            if (board.Exists(x => x.Key.Trim().Equals(total.ToString())))
            {
                player.CurrentValue = total;
                var count = board.FirstOrDefault(x => x.Key.Trim().Equals(total.ToString()));
                player.Index = new Index(count.Index.Row, count.Index.Column);
            }
            else if (snakes.Exists(x => x.HeadValue.Equals(total)))
            {
                var snake = snakes.FirstOrDefault(x => x.HeadValue.Equals(total));
                var playerValue = board.FirstOrDefault(x => x.Index.Row.Equals(snake.Tail.Row) && x.Index.Column.Equals(snake.Tail.Column));
                player.CurrentValue = Int16.Parse(GetValue(playerValue, "S-"));
                player.Index = new Index(snake.Tail.Row, snake.Tail.Column);
            }
            else if (ladders.Exists(x => x.FootValue.Equals(total)))
            {
                var ladder = ladders.FirstOrDefault(x => x.FootValue.Equals(total));
                var playerValue = board.FirstOrDefault(x => x.Index.Row.Equals(ladder.Tip.Row) && x.Index.Column.Equals(ladder.Tip.Column));
                string stringValue = GetValue(playerValue, "L-");
                player.CurrentValue = Int16.Parse(stringValue);
                player.Index = new Index(ladder.Tip.Row, ladder.Tip.Column);
            }
            return player;
        }

        private static string GetValue(Count playerValue, string key)
        {
            return playerValue.Key.Replace(key, "  ").Trim();
        }
    }
}
