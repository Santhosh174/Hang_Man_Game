using HangMan.Data;
using HangMan.Display;
using HangMan.Logic;

internal class HangManRunner
{
	public static void WriteColoredOutput(string strText, ConsoleColor color)
	{
		ConsoleColor colorPrevious = Console.ForegroundColor;

		Console.ForegroundColor = color;
		Console.WriteLine(strText);
		Console.ForegroundColor = colorPrevious;
	}
	#region Privates
	private static void StartGame(string strMessage)
	{
		if(strMessage == "y" || strMessage == "Y")
		{
			Console.WriteLine(DisplayItems.DisplayQuestion());
			while(!HangManBO.bGameEnd)
			{
				Console.WriteLine("\n-------------------------------------------------------------------------------------------------");
				string strGuess = Console.ReadLine();
				string result = (strGuess.Length == 1) ? HangManBO.CheckAnswer(strGuess[0]) : "Invalid Input. Please enter a letter.";
				Console.WriteLine(result);
			}
		}
		else
		{
			Console.WriteLine("------------Game End-----------");
		}
		DisplayItems.DisplayResult(HangManBO.bResult);
	}

	private static void Main(string[] args)
	{
		Console.WriteLine(Message.strWelcome);
		DisplayItems displayItems = new DisplayItems();
		displayItems.DisplayRules();
		Console.WriteLine("-----------------------");
		WriteColoredOutput("Press Y to start the game:", ConsoleColor.Yellow);
		string strMessage = Console.ReadLine();
		StartGame(strMessage);
	}
	#endregion
}