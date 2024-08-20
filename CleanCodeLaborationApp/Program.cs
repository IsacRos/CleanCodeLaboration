using CleanCodeLaborationInfrastructure.Controllers;
using CleanCodeLaborationApp.UserInterface;
using CleanCodeLaborationCore.Interfaces;
using CleanCodeLaborationInfrastructure.Data;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;


namespace MooGame
{
	class MainClass
	{
		public static void Main(string[] args)
		{
			var service = new ServiceCollection();
			service.AddSingleton<IIO, ConsoleIO>();
            service.AddSingleton<IMenu, ConsoleMenu>();
            service.AddSingleton<IRepository, RepositoryTxt>();
			service.AddScoped<GameController>();

			service.AddLogging(l => l.AddConsole());

			var gameController = service
				.BuildServiceProvider()
				.GetRequiredService<GameController>();

			gameController.Start();
		}
	}
}