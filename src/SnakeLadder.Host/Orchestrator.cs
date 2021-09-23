using SnakeLadder.Host.DataContracts;
using System;

namespace SnakeLadder.Host
{
    public class Orchestrator : IOrchestrator
    {
        private IConstants _constants;
        private IService _service;

        public Orchestrator(IConstants constants, IService service)
        {
            _constants = constants;
            _service = service;
        }

        public void Start()
        {
            Helper.PrintRules();
            var snakes = _constants.SetSnakes();
            var ladders = _constants.SetLadders();
            var dice = _constants.SetDice();
            var board = _constants.SetBoard(snakes, ladders);

            _service.Start(snakes, ladders, board, dice.IsNormalDice);
        }
        public void End()
        {
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}
