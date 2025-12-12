using HangMan.Data;

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

		internal void DisplayDrawing(int n)
		{
			switch(n)
			{
				case 1:
					Console.WriteLine(Drawing.strFirstChance);
					break;
				case 2:
					Console.WriteLine(Drawing.strSecondChance);
					break;
				case 3:
					Console.WriteLine(Drawing.strThirdChance);
					break;
				case 4:
					Console.WriteLine(Drawing.strFourthChance);
					break;
				case 5:
					Console.WriteLine(Drawing.strFifthChance);
					break;
				case 6:
					Console.WriteLine(Drawing.strSixthChance);
					break;
				case 7:
					Console.WriteLine(Drawing.strSeventhChance);
					break;
			}
		}

		internal static string DisplayQuestion()
		{
			string filePath = @"../../../Data/Questions.txt";  // Update with your file path
			string content = File.ReadAllText(filePath);
			string[] words = content.Split(new char[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
			Random random = new Random();
			string randomWord = words[random.Next(words.Length)];

			return randomWord;
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