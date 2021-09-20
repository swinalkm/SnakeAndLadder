using System;

namespace SnakeLadder.Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            var snakes = Constants.SetSnakes();
            var ladders = Constants.SetLadders();
            Display.Board(snakes, ladders);
            Console.ReadKey();
        }
    }
}
