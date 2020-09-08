using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace Application.Helpers
{
	public static class SalaryHelpers
	{
		public static (int?,int?) ExtractSalary(string salary)
		{
			salary = salary.ToLower();

			var words = salary.Split(" ");
			var numbers = new List<int>();
			foreach (var word in words)
			{
				var number = Regex.Match(word, @"\d+.+\d").Value;
				if (number.Length > 0)
				{
					numbers.Add(Decimal.ToInt32((Decimal.Parse(number))));
				}
			}

			if (numbers.Count == 2)
				return (numbers[0], numbers[1]);
			if (numbers.Count == 1 && salary.Contains("nuo"))
			{
				return (numbers[0], null);
			}

			if (numbers.Count == 1 && salary.Contains("iki"))
			{
				return (null, numbers[0]);
			}

			return (null, null);
		}
	}
}
