using System;
using BerlinClock.Model;
using BerlinClock.Services.ColorProvider;

namespace BerlinClock.Services.TimeFormatter
{
    public class SecondFormatter : ITimeFormatter
    {
        private readonly IColorProvider _colorProvider;

        public SecondFormatter(IColorProvider colorProvider)
        {
            _colorProvider = colorProvider;
        }

        public string GetFormattedStringBlock(TimeHolder time)
        {
            if (time is null)
            {
                throw new ArgumentNullException(nameof(time));
            }

            if (time.Seconds < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var isSecondPlaceholderEnabled = time.Seconds % 2 == 0;
            return $"{_colorProvider.GetColor(isSecondPlaceholderEnabled)}{Environment.NewLine}" ;
        }
    }
}
