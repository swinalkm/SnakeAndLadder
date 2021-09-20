using SnakeLadder.Host.contracts;
using System;
using System.Linq;

namespace SnakeLadder.Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            var snakes = Constants.SetSnakes();
            var ladders = Constants.SetLadders();
            var board = Display.SetBoard(snakes, ladders);
            bool isNormalDice = Display.SetDice();
            Service.Start(snakes, ladders, board, isNormalDice);

            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
