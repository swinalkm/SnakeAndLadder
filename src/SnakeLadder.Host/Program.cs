using Microsoft.Extensions.DependencyInjection;
using SnakeLadder.Host.DataContracts;
using SnakeLadder.Host.DataContracts.Models;

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
                                   .BuildServiceProvider();

            var orchestrator = serviceCollection.GetService<IOrchestrator>();

            var result = orchestrator.Start();
            orchestrator.End(result);
        }
    }
}
