using System;
using BerlinClock.Model;
using BerlinClock.Services.InputParser;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace BerlinClock.Tests.Services.InputParser
{
    [TestFixture()]
    public class ColonSeparatedParserTests 
    {
        [TestCase("00:00:00",0,0,0)]
        [TestCase("0:40:12",0,40,12)]
        [TestCase("24:00:00",24, 0 ,0)]
        [TestCase("23:55:43",23,55,43)]
        public void ParseInputString_ValidFormats(string input, int expectedHours, int expectedMinutes, int expectedSeconds)
        {
            var parser = new ColonSeparatedParser();
            var time = parser.ParseInputString(input);

            Assert.AreEqual(expectedHours, time.Hours);
            Assert.AreEqual(expectedMinutes, time.Minutes);
            Assert.AreEqual(expectedSeconds, time.Seconds);
        }

        [TestCase("24:10:00")]
        [TestCase("99:99:99")]
        [TestCase("00:00:60")]
        [TestCase("00:60:00")]
        [TestCase("aa")]
        [TestCase("-12:11")]
        public void ParseInputString_InvalidFormats(string input)
        {
            var parser = new ColonSeparatedParser();
            Assert.Throws<ArgumentException>(() => parser.ParseInputString(input));
        }
    }
}
