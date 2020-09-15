using System;

namespace ConvertNumberToWords
{
	class Program
	{
		static void Main(string[] args)
		{
			int number = 1123123;
			var word = NumberToWords(number);
			Console.WriteLine(word);
			Console.ReadLine();
		}

		public static string NumberToWords(int number)
		{
			if (number == 0)
				return "zero";

			string words = "";

			if ((number / 1000000) > 0)
			{
				words += NumberToWords(number / 1000000) + " million, ";
				number %= 1000000;
			}

			if ((number / 1000) > 0)
			{
				words += NumberToWords(number / 1000) + " thousand, ";
				number %= 1000;
			}

			if ((number / 100) > 0)
			{
				words += NumberToWords(number / 100) + " hundred ";
				number %= 100;
			}

			if (number > 0)
			{
				if (!string.IsNullOrEmpty(words))
					words += "and ";
			}

			var unitsMap = new[] { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine", "ten", "eleven", "twelve", "thirteen", "fourteen", "fifteen", "sixteen", "seventeen", "eighteen", "nineteen" };
			var tensMaps = new[] { "zero", "ten", "twenty", "thirty", "fourty", "fifty", "sixty", "seventy", "eighty", "ninety" };

			if (number < 20)
				words += unitsMap[number];
			else
			{
				words += tensMaps[number / 10];
				if ((number % 10) > 0)
					words += "-" + unitsMap[number % 10];
			}

			return words;
		}
	}
}
