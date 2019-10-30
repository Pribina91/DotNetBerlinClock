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
    public class MinutesFormatterTests
    {
        private IColorProvider _redColorProvider;
        private IColorProvider _yellowColorProvider;

        [SetUp]
        public void Prepare()
        {
            var colorMock = new Mock<IColorProvider>();
            colorMock.Setup(x => x.GetColor(true)).Returns("R");
            colorMock.Setup(x => x.GetColor(false)).Returns("O");

            _redColorProvider = colorMock.Object;

            var colorMock2 = new Mock<IColorProvider>();
            colorMock2.Setup(x => x.GetColor(true)).Returns("Y");
            colorMock2.Setup(x => x.GetColor(false)).Returns("O");

            _yellowColorProvider = colorMock2.Object;

        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void GetFormatedString(int minutes)
        {
            var timeHolder = new TimeHolder()
            {
                Hours = 0,
                Minutes = minutes,
                Seconds = 0,
            };

            var formatter = new MinuteFormatter(_yellowColorProvider, _redColorProvider);
            var result = formatter.GetFormattedStringBlock(timeHolder);

            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(2, lines.Length);
            Assert.AreEqual(11, lines[0].Length);
            Assert.AreEqual(4, lines[1].Length);
        }
    }
}
