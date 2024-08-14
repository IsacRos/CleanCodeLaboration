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
			service.AddLogging(l => l.AddConsole());
			service.AddScoped<GameController>();

			var gameController = service
				.BuildServiceProvider()
				.GetRequiredService<GameController>();

			gameController.Start();
			//GameController gameController = new();
   //         RepositoryTxt repo = new();
   //         ConsoleIO io = new();
   //         Moo game = new();
   //         ScoreService scoreService = new(io, repo);
			//GameService gameService = new(game, io);
			//ConsoleMenu menu = new();
			//menu.SelectGame();
			//gameService.RunGame();
			//bool playOn = true;
			//Console.WriteLine("Enter your user name:\n");
			//string name = Console.ReadLine();
			//while (playOn)
			//{
			//	//string goal = makeGoal();
			//	string goal = "";//gameService.SetTargetGoal();

			//	Console.WriteLine("New _game:\n");
			//	//comment out or remove next line to play real games!
			//	Console.WriteLine("For practice, number is: " + goal + "\n");
			//	string guess = Console.ReadLine();
				
			//	int nGuess = 1;
			//	string bbcc = checkBC(goal, guess);
			//	Console.WriteLine(bbcc + "\n");
			//	while (bbcc != "BBBB,")
			//	{
			//		nGuess++;
			//		guess = Console.ReadLine();
			//		Console.WriteLine(guess + "\n");
			//		bbcc = checkBC(goal, guess);
			//		Console.WriteLine(bbcc + "\n");
			//	}
			//	StreamWriter output = new StreamWriter("result.txt", append: true);
			//	output.WriteLine(name + "#&#" + nGuess);
			//	output.Close();
			//	//showTopList();
			//	scoreService.DisplayScoreTable().Wait();
			//	Console.WriteLine("Correct, it took " + nGuess + " guesses\nContinue?");
			//	string answer = Console.ReadLine();
			//	if (answer != null && answer != "" && answer.Substring(0, 1) == "n")
			//	{
			//		playOn = false;
			//	}
			//}
		}
		//static string makeGoal()
		//{
		//	Random randomGenerator = new Random();
		//	string goal = "";
		//	for (int i = 0; i < 4; i++)
		//	{
		//		int random = randomGenerator.Next(10);
		//		string randomDigit = "" + random;
		//		while (goal.Contains(randomDigit))
		//		{
		//			random = randomGenerator.Next(10);
		//			randomDigit = "" + random;
		//		}
		//		goal = goal + randomDigit;
		//	}
		//	return goal;
		//}

		//static string checkBC(string goal, string guess)
		//{
		//	int cows = 0, bulls = 0;
		//	guess += "    ";     // if player entered less than 4 chars
		//	for (int i = 0; i < 4; i++)
		//	{
		//		for (int j = 0; j < 4; j++)
		//		{
		//			if (goal[i] == guess[j])
		//			{
		//				if (i == j)
		//				{
		//					bulls++;
		//				}
		//				else
		//				{
		//					cows++;
		//				}
		//			}
		//		}
		//	}
		//	return "BBBB".Substring(0, bulls) + "," + "CCCC".Substring(0, cows);
		//}


		/*static void showTopList()
		{
			StreamReader input = new StreamReader("result.txt");
			List<PlayerData> results = new List<PlayerData>();
			string line;
			while ((line = input.ReadLine()) != null)
			{
				string[] nameAndScore = line.Split(new string[] { "#&#" }, StringSplitOptions.None);
				string name = nameAndScore[0];
				int guesses = Convert.ToInt32(nameAndScore[1]);
				PlayerData pd = new PlayerData(name, guesses);
				int pos = results.IndexOf(pd);
				if (pos < 0)
				{
					results.Add(pd);
				}
				else
				{
					results[pos].Update(guesses);
				}
				
				
			}
			results.Sort((p1, p2) => p1.Average().CompareTo(p2.Average()));
			Console.WriteLine("Player   games average");
			foreach (PlayerData p in results)
			{
				Console.WriteLine(string.Format("{0,-9}{1,5:D}{2,9:F2}", p.Name, p.NGames, p.Average()));
			}
			input.Close();
		}*/
	}

	//public class PlayerData
	//{
	//	public string Name { get; private set; }
 //       public int NGames { get; private set; }
	//	public int TotalGuesses { get; private set; }
		

	//	public PlayerData(string name, int guesses)
	//	{
	//		this.Name = name;
	//		TotalGuesses = guesses;
	//	}

	//	public void Update(int guesses)
	//	{
	//		TotalGuesses += guesses;
	//		NGames++;
	//	}

	//	public double Average()
	//	{
	//		return (double)TotalGuesses / NGames;
	//	}

		
	// //   public override bool Equals(Object p)
	//	//{
	//	//	return Name.Equals(((PlayerData)p).Name);
	//	//}

		
	// //   public override int GetHashCode()
 // //      {
	//	//	return Name.GetHashCode();
	//	//}
	//}
}