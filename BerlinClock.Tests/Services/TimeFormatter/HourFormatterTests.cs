using System;
using BerlinClock.Model;
using BerlinClock.Services.ColorProvider;
using BerlinClock.Services.TimeFormatter;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BerlinClock.Tests.Services.TimeFormatter
{
    [TestClass]
    public class HourFormatterTests
    {
        private IColorProvider _redColorProvider;

        [SetUp]
        public void Prepare()
        {
            var colorMock = new Mock<IColorProvider>();
            colorMock.Setup(x => x.GetColor(true)).Returns("R");
            colorMock.Setup(x => x.GetColor(false)).Returns("O");

            _redColorProvider = colorMock.Object;
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void GetFormatedString(int hours)
        {
            var timeHolder = new TimeHolder()
            {
                Hours = hours,
                Minutes = 0,
                Seconds = 0,
            };

            var formatter = new HourFormatter(_redColorProvider);
            var result = formatter.GetFormattedStringBlock(timeHolder);

            var lines = result.Split(new []{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(2, lines.Length);
            Assert.AreEqual(4, lines[0].Length);
            Assert.AreEqual(4, lines[1].Length);
        }
    }
}
