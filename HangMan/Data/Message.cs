namespace HangMan.Data
{
	internal class Message
	{
		#region Fields
		public static string strWelcome = "Welcome to Hangman!\n";
		public static string strWonMessage = "Congratulations! You've won!";
		public static string strLostMessage = "Sorry, you've lost. Better luck next time!";
		#endregion

		#region Properties
		public static string strChanceMessage { get; set; }
		#endregion

		#region Publics
		public void CheckRemainingChances()
		{
		}
		#endregion
	}
}