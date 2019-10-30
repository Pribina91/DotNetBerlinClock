using System;
using System.Globalization;
using System.Text;
using BerlinClock.Model;
using BerlinClock.Services.ColorProvider;
using BerlinClock.Services.InputParser;
using BerlinClock.Services.TimeFormatter;

namespace BerlinClock
{
    public class TimeConverter : ITimeConverter
    {
        private readonly YellowColorProvider _yellowProvider;

        private readonly RedColorProvider _redProvider;

        private readonly ColonSeparatedParser _inputParser;

        public TimeConverter()
        {
            _yellowProvider = new YellowColorProvider();
            _redProvider = new RedColorProvider();
            _inputParser = new ColonSeparatedParser();
        }

        public string convertTime(string aTime)
        {
            if (string.IsNullOrEmpty(aTime))
            {
                throw new ArgumentNullException(nameof(aTime));
            }

            var timeHolder = _inputParser.ParseInputString(aTime);

            var sb = new StringBuilder();
            var seconds = new SecondFormatter(_yellowProvider);
            sb.Append(seconds.GetFormattedStringBlock(timeHolder));

            var hours = new HourFormatter(_redProvider);
            sb.Append(hours.GetFormattedStringBlock(timeHolder));

            var minutes = new MinuteFormatter(_yellowProvider, _redProvider);
            sb.Append(minutes.GetFormattedStringBlock(timeHolder));

            return sb.ToString().TrimEnd();
        }
    }
}
