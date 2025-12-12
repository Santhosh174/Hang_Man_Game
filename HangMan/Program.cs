using HangMan.Data;
using HangMan.Display;

internal class HangManRunner
{
	private static void StartGame(string strMessage)
	{
		if(strMessage == "y" || strMessage == "Y")
		{
			Console.WriteLine(DisplayItems.DisplayQuestion());
		}
	}
	#region Privates
	private static void Main(string[] args)
	{
		Console.WriteLine(Message.strWelcome);
		DisplayItems displayItems = new DisplayItems();
		displayItems.DisplayRules();

		Console.WriteLine("Types Y to start the game or N to exit:");
		string strMessage = Console.ReadLine();
		StartGame(strMessage);

		Console.ReadLine();
	}
	#endregion
}