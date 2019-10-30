using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BerlinClock.Model;
using BerlinClock.Services.ColorProvider;
using BerlinClock.Services.TimeFormatter;
using Moq;
using NUnit.Framework;

namespace BerlinClock.Tests.Services.TimeFormatter
{
    [TestFixture()]
    public class SecondFormatterTests
    {
        private IColorProvider _yellowColorProvider;

        [SetUp]
        public void Prepare()
        {
            var colorMock2 = new Mock<IColorProvider>();
            colorMock2.Setup(x => x.GetColor(true)).Returns("Y");
            colorMock2.Setup(x => x.GetColor(false)).Returns("O");

            _yellowColorProvider = colorMock2.Object;
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void GetFormatedString(int second)
        {
            var timeHolder = new TimeHolder()
            {
                Hours = 0, Minutes = 0, Seconds = second,
            };

            var formatter = new SecondFormatter(_yellowColorProvider);
            var result = formatter.GetFormattedStringBlock(timeHolder);

            var trimmed = result.TrimEnd();
            Assert.AreEqual(1, trimmed.Length);
        }
    }
}
