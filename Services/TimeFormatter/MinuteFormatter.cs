using System;
using System.Text;
using BerlinClock.Model;
using BerlinClock.Services.ColorProvider;

namespace BerlinClock.Services.TimeFormatter
{
    public class MinuteFormatter : ITimeFormatter
    {
        private const int FirstLineLampsCount = 11;
        private const int SecondLineLampsCount = 4;

        private readonly IColorProvider _mainColorProvider;
        private readonly IColorProvider _separatorColorProvider;

        public MinuteFormatter(IColorProvider mainColorProvider, IColorProvider separatorColorProvider)
        {
            _mainColorProvider = mainColorProvider;
            _separatorColorProvider = separatorColorProvider;
        }

        public string GetFormattedStringBlock(TimeHolder time)
        {
            if (time is null)
            {
                throw new ArgumentNullException();
            }

            if (time.Minutes < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var sb = new StringBuilder();

            var firstLineMultiplier = time.Minutes / 5;
            for (int i = 0; i < FirstLineLampsCount; i++)
            {
                if (i % 3 == 2)
                {
                    sb.Append(_separatorColorProvider.GetColor(i < firstLineMultiplier));
                }
                else
                {
                    sb.Append(_mainColorProvider.GetColor(i < firstLineMultiplier));
                }
               
            }

            sb.AppendLine();

            var secondLineMultiplier = time.Minutes % 5;
            for (int i = 0; i < SecondLineLampsCount; i++)
            {
                sb.Append(_mainColorProvider.GetColor(i < secondLineMultiplier));
            }

            sb.AppendLine();
            return sb.ToString();
        }
    }
}
