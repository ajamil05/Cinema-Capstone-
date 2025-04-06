﻿using System.Text;

namespace Capstone.Menus
{
	/// <summary>
	/// Provides helper methods for console input and output.
	/// </summary>
	internal static class ConsoleHelpers
	{
		/// <summary>
		/// Prompts the user to enter an integer within a specified range.
		/// </summary>
		/// <param name="pMin">The minimum acceptable value (inclusive).</param>
		/// <param name="pMax">The maximum acceptable value (inclusive).</param>
		/// <param name="pMessage">The message to display to the user.</param>
		/// <returns>An integer entered by the user within the specified range.</returns>
		/// <exception cref="Exception">Thrown when the minimum value is greater than the maximum value.</exception>
		public static int GetIntegerInRange(int pMin, int pMax, string pMessage)
		{
			if (pMin > pMax)
			{
				throw new Exception($"Minimum value {pMin} cannot be greater than maximum value {pMax}");
			}

			int result;

			do
			{
				Console.WriteLine(pMessage);
				Console.WriteLine($"Please enter a number between {pMin} and {pMax} inclusive.");
				string userInput = Console.ReadLine();

				try
				{
					result = int.Parse(userInput);
				}
				catch
				{
					Console.WriteLine($"{userInput} is not a number");
					continue;
				}

				if (result >= pMin && result <= pMax)
				{
					return result;
				}
				Console.WriteLine($"{result} is not between {pMin} and {pMax} inclusive.");
			} while (true);
		}
		public static string GetStringInRange(string pMessage, string Message, string Messages)
		{
            Console.WriteLine(pMessage);

            string firstname = Console.ReadLine();

            Console.WriteLine(Message);

            string lastname = Console.ReadLine();

            Console.WriteLine(Messages);

            string email = Console.ReadLine();

            using (StreamWriter sw = new StreamWriter("LoyalityMember.txt"))
			{
                bool Num = int.TryParse(firstname, out int i1);

                bool Num2 = int.TryParse(lastname, out int i2);

                bool First = char.IsUpper(firstname[0]);

                bool Last = char.IsUpper(lastname[0]);

                if (Num! && Num2! || !First && !Last)
                {
                    Console.WriteLine("invalid Names");
                    return GetStringInRange(pMessage, Message, Messages);
                }

                for (int i = 0; i < email.Length; i++)
                {
                    if (email[0] == '@' || email[0] == '.' || email.Length == '@' || email.Length == '.')
                    {
                        Console.WriteLine("invalid Email Address");
                        return GetStringInRange(pMessage, Message, Messages);
                    }
                }
                sw.WriteLine($"{pMessage}:{firstname} {Message}:{lastname} {Messages}:{email}");
            }
			return $"{pMessage}:{firstname} {Message}:{lastname} {Messages}:{email}";
		}

		/// <summary>
		/// Displays a list of items as a menu and prompts the user to select one.
		/// </summary>
		/// <param name="items">The list of items to display in the menu.</param>
		/// <param name="prompt">The prompt message to display to the user.</param>
		/// <returns>The index of the selected item (zero-based).</returns>
		public static int GetSelectionFromMenu(IEnumerable<string> items, string prompt)
		{
			StringBuilder sb = new StringBuilder();
			sb.AppendLine(prompt);

			int itemNumber = 0;

			foreach (string item in items)
			{
				itemNumber++;
				sb.AppendLine($"{itemNumber}. {item}");
			}

			return GetIntegerInRange(1, itemNumber, sb.ToString()) - 1;
		}
	}
}
