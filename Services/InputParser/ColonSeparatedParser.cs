using System;
using System.Linq;
using System.Text.RegularExpressions;
using BerlinClock.Model;

namespace BerlinClock.Services.InputParser
{
    public class ColonSeparatedParser : IInputParser
    {
        public string ValidFormat => _validFormatExpression.ToString();
        private readonly Regex _validFormatExpression = new Regex(@"^([0-1]?[0-9]|2[0-3]):[0-5][0-9]:[0-5][0-9]$|^24:00:00$");

        public TimeHolder ParseInputString(string input)
        {
            if (!_validFormatExpression.IsMatch(input))
            {
                throw new ArgumentException($"Invalid format expected 00:00:00", nameof(input));
            }

            var split = input.Split(new[] {":"}, StringSplitOptions.RemoveEmptyEntries);
            var parsedNumbers = split.Select(x => Convert.ToInt32(x)).ToArray();

            return new TimeHolder()
            {
                Hours = parsedNumbers[0],
                Minutes = parsedNumbers[1],
                Seconds = parsedNumbers[2],
            };
        }
    }
}
