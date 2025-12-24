using HangMan.Display;

namespace HangMan.Logic
{
	internal class HangManBO
	{
		#region Properties
		internal static bool bResult { get; set; }
		internal static bool bGameEnd { get; set; }
		private static int nChance { get; set; }
		private static string strQuestion { get; set; }
		private static string strMaskedQuestion { get; set; }
		#endregion

		#region Internals
		internal string GenerateQuestion()
		{
			string strFilePath = @"../../../Data/Questions.txt";
			string strContent = File.ReadAllText(strFilePath);
			string[] words = strContent.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
			Random random = new Random();
			strQuestion = words[random.Next(words.Length)];
			strMaskedQuestion = " ";
			HangManRunner.WriteColoredOutput("\n" + 
			              strQuestion.Length + " letter word.\n",ConsoleColor.Blue);
			foreach(char c in strQuestion)
			{
				strMaskedQuestion += "_ ";
			}

			return strMaskedQuestion;
		}

		internal static string CheckAnswer(char cGuessedLetter)
		{
			List<int> indexes = (strQuestion.Select((ch, index) => new { ch, index }).Where(x => char.ToLower(x.ch) == char.ToLower(cGuessedLetter)).Select(x => x.index)).ToList();

			if(indexes.Count > 0)
			{
				foreach(int index in indexes)
				{
					strMaskedQuestion = strMaskedQuestion.Remove(index * 2 + 1, 1).Insert(index * 2 + 1, cGuessedLetter.ToString());
				}

				if(!strMaskedQuestion.Contains("_"))
				{
					bGameEnd = true;
					bResult = true;
					return strMaskedQuestion + "\nCongratulations! You've guessed the word: " + strQuestion;
				}

				return strMaskedQuestion;
			}

			nChance++;
			if(nChance == 7)
			{
				bGameEnd = true;
				bResult = false;
				return DisplayItems.DisplayDrawing(nChance) + "\nGame Over! The correct word was: " + strQuestion;
			}

			return DisplayItems.DisplayDrawing(nChance) + "\n" + strMaskedQuestion;
		}
		#endregion
	}
}