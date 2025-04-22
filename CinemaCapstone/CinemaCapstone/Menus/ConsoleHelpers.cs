using System.Text;

namespace Capstone.Menus
{
	/// <summary>
	/// Provides helper methods for console input and output.
	/// </summary>
	internal static class ConsoleHelpers
	{
        /// <summary>
        /// Prompts the user to enter an integer within a specified range (inclusive).
        /// </summary>
        /// <param name="pMin"></param>
        /// <param name="pMax"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public static int GetIntegerInRange(int pMin, int pMax)
		{
			if (pMin > pMax)
			{
				throw new Exception($"Minimum value {pMin} cannot be greater than maximum value {pMax}");
			}

			int result;

			do
			{
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
			} while (true);
		}

        /// <summary>
        /// Prompts the user to enter an  valid age (inclusive) based on the rating of the movie.
        /// </summary>
        /// <param name="Size"></param>
        /// <param name="rating"></param>
        /// <returns></returns>
        public static int AgeInput(int Size, string rating)
		{
            int value = 0;
            if (rating == "18")
			{
				value = int.Parse(rating);
			}
			if (rating == "15")
			{
				value = int.Parse(rating);
			}
			if (rating == "12")
			{
				value = int.Parse(rating);
			}
			if (rating == "U")
			{
				value = 0;
			}
			for (int i = 0; i < Size; i++)
			{
                ConsoleHelpers.GetIntegerInRange(value, 100);
            }
            return value;
        }
    }
}
