using SnakeLadder.Host.DataContracts;
using System;

namespace SnakeLadder.Host
{
    public class Orchestrator : IOrchestrator
    {
        private IConstants _constants;

        public Orchestrator(IConstants constants)
        {
            _constants = constants;
        }

        public void Start()
        {
            Helper.PrintRules();
            var snakes = _constants.SetSnakes();
            var ladders = _constants.SetLadders();
            var dice = _constants.SetDice();
            var board = _constants.SetBoard(snakes, ladders);

            Service.Start(snakes, ladders, board, dice.IsNormalDice);
        }
        public void End()
        {
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
