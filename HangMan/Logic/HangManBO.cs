using HangMan.Display;

namespace HangMan.Logic
{
	internal class HangManBO
	{
		#region Properties
		private int nChance { get; set; }
		private string strQuestion { get; set; }
		private string strMaskedQuestion { get; set; }
		#endregion

		#region Internals
		internal string GenerateQuestion()
		{
			string strFilePath = @"../../../Data/Questions.txt"; // Update with your file path
			string strContent = File.ReadAllText(strFilePath);
			string[] words = strContent.Split(new[] { ' ', '\t', '\n', '\r', '.', ',', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);
			Random random = new Random();
			this.strQuestion = words[random.Next(words.Length)];
			this.strMaskedQuestion = " ";
			foreach(char c in this.strQuestion)
			{
				this.strMaskedQuestion += "_ ";
			}

			return this.strMaskedQuestion;
		}

		internal string CheckAnswer(char cGuessedLetter)
		{
			List<int> indexes = (this.strQuestion.Select((ch, index) => new { ch, index }).Where(x => x.ch == cGuessedLetter).Select(x => x.index)).ToList();

			if(indexes.Count > 0)
			{
				foreach(int index in indexes)
				{
					this.strMaskedQuestion = this.strMaskedQuestion.Remove(index * 2, 1).Insert(index * 2 + 1, cGuessedLetter.ToString());
				}

				return this.strMaskedQuestion;
			}

			this.nChance++;
			return DisplayItems.DisplayDrawing(this.nChance);
		}
		#endregion
	}
}