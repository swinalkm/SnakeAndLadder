using Microsoft.Extensions.DependencyInjection;
using SnakeLadder.Host.DataContracts;
namespace SnakeLadder.Host
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceCollection = new ServiceCollection()
                                   .AddSingleton<IConstants, Constants>()
                                   .AddSingleton<IOrchestrator, Orchestrator>()
                                   .AddSingleton<IService, Service>()
                                   .BuildServiceProvider();

            var orchestrator = serviceCollection.GetService<IOrchestrator>();

            orchestrator.Start();
            orchestrator.End();
        }
    }
}
