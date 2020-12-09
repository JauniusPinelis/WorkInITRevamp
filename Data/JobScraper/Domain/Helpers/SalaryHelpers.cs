using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace Domain.Helpers
{
    public static class SalaryHelpers
    {
        public static (int?, int?) ExtractSalary(string salary)
        {
            if (string.IsNullOrEmpty(salary))
            {
                return (null, null);
            }

            salary = salary.ToLower();

            var words = salary.Split(new char[] { ' ', '-' });
            var numbers = new List<int>();
            foreach (var word in words)
            {
                var number = Regex.Match(word, @"\d+.+\d").Value;
                if (number.Length > 0)
                {
                    numbers.Add(decimal.ToInt32(decimal.Parse(number)));
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
