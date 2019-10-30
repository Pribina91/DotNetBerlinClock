﻿using System;
using System.Text;
using BerlinClock.Model;
using BerlinClock.Services.ColorProvider;

namespace BerlinClock.Services.TimeFormatter
{
    public class HourFormatter : ITimeFormatter
    {
        private readonly IColorProvider _colorProvider;

        public HourFormatter(IColorProvider colorProvider)
        {
            _colorProvider = colorProvider;
        }

        public string GetFormattedStringBlock(TimeHolder time)
        {
            if (time is null)
            {
                throw new ArgumentNullException();
            }

            if (time.Hours < 0 || time.Minutes < 0 || time.Seconds < 0)
            {
                throw new ArgumentOutOfRangeException();
            }

            var sb = new StringBuilder();

            var firstLineMultiplier = time.Hours / 5;
            for (int i = 0; i < 4; i++)
            {
                sb.Append(_colorProvider.GetColor(i < firstLineMultiplier));
            }

            sb.AppendLine();

            var secondLineMultiplier = time.Hours % 5;
            for (int i = 0; i < 4; i++)
            {
                sb.Append(_colorProvider.GetColor(i < secondLineMultiplier));
            }

            sb.AppendLine();
            return sb.ToString();
        }
    }
}