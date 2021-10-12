using Microsoft.Extensions.DependencyInjection;
using SnakeLadder.Host.DataContracts;

namespace SnakeLadder.Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
                                   .AddSingleton<IOrchestrator, Orchestrator>()
                                   .AddSingleton<IService, Service>()
                                   .AddSingleton<IDice, NormalDice>()
                                   .AddSingleton<IDice, CrookedDice>()
                                   .AddSingleton<IDiceFactory, DiceFactory>()
                                   .AddSingleton<ISnake, SnakeService>()
                                   .AddSingleton<ILadder, LadderService>()
                                   .AddSingleton<IPlayer, NormalPlayer>()
                                   .AddSingleton<IBoard, BoardService>()
                                   .BuildServiceProvider();

            var orchestrator = serviceCollection.GetService<IOrchestrator>();

            var result = orchestrator.Start();
            orchestrator.End(result);
        }
    }
}
