using HangMan.Data;
using HangMan.Logic;

namespace HangMan.Display
{
	internal class DisplayItems
	{
		#region Internals
		internal void DisplayRules()
		{
			Console.WriteLine("RULES\n=============================");
			Console.WriteLine("Rule1: The game randomly selects a secret word from a predefined word list. \r\nRule2: The game displays blanks representing each letter of the secret word. \r\nRule3: The player guesses one letter at a time. \r\nRule4: If the guessed letter appears in the secret word, all matching positions are revealed. \r\nRule5: If the guessed letter is not in the secret word, the game adds one part to the hangman drawing (a strike). \r\nRule6: The player wins by revealing all letters before reaching the maximum number of strikes. \r\nRule7: The player loses if the hangman drawing is completed before the word is fully guessed. ");
		}

		internal static string DisplayDrawing(int n)
		{
			switch(n)
			{
				case 1:
					return Drawing.strFirstChance;
				case 2:
					return Drawing.strSecondChance;
				case 3:
					return Drawing.strThirdChance;
				case 4:
					return Drawing.strFourthChance;
				case 5:
					return Drawing.strFifthChance;
				case 6:
					return Drawing.strSixthChance;
				case 7:
					return Drawing.strSeventhChance;
			}

			return string.Empty;
		}

		internal static string DisplayQuestion()
		{
			HangManBO hangManBO = new HangManBO();
			string strQuesiton = hangManBO.GenerateQuestion();

			return strQuesiton;
		}

		internal void DisplayResult(bool bResult)
		{
			if(bResult)
			{
				Console.WriteLine(Message.strWonMessage);
			}
			else
			{
				Console.WriteLine(Message.strLostMessage);
			}
		}
		#endregion
	}
}