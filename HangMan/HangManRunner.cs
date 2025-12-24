using HangMan.Data;
using HangMan.Display;
using HangMan.Logic;

internal class HangManRunner
{
	#region Privates
	private static void StartGame(string strMessage)
	{
		if(strMessage == "y" || strMessage == "Y")
		{
			Console.WriteLine(DisplayItems.DisplayQuestion());
			while(!HangManBO.bGameEnd)
			{
				string strGuess = Console.ReadLine();
				string result = (strGuess.Length == 1) ? HangManBO.CheckAnswer(strGuess[0]) : "Invalid Input. Please enter a letter.";
				Console.WriteLine(result);
			}
		}
		else
		{
			Console.WriteLine("------------Game End-----------");
		}
	}

	private static void Main(string[] args)
	{
		Console.WriteLine(Message.strWelcome);
		DisplayItems displayItems = new DisplayItems();
		displayItems.DisplayRules();
		Console.WriteLine("-----------------------");
		Console.WriteLine("Press Y to start the game:");
		string strMessage = Console.ReadLine();
		StartGame(strMessage);
	}
	#endregion
}