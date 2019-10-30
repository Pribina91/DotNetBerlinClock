using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Assert = NUnit.Framework.Assert;

namespace BerlinClock.Tests.Classes
{
    [TestFixture]
    public class TimeConverterTests
    {
        [TestCase(
            "00:00:00",
            @"Y
OOOO
OOOO
OOOOOOOOOOO
OOOO")]
        [TestCase(
            "13:17:01",
            @"O
RROO
RRRO
YYROOOOOOOO
YYOO")][TestCase(
            "23:59:59",
            @"O
RRRR
RRRO
YYRYYRYYRYY
YYYY")][TestCase(
            "24:00:00",
            @"Y
RRRR
RRRR
OOOOOOOOOOO
OOOO")]
        public void convertTime_BDDTests(string timeString, string expected)
        {
            var timeConverter = new TimeConverter();
            var result = timeConverter.convertTime(timeString);

            Assert.AreEqual(expected, result);
        }

        [TestCase]
        public void convertTime_NullParameter()
        {
            var timeConverter = new TimeConverter();
            Assert.Throws<ArgumentNullException>(() => timeConverter.convertTime(null));
            Assert.Throws<ArgumentNullException>(() => timeConverter.convertTime(""));
        }
        [TestCase]
        public void convertTime_InvalidInputFormat()
        {
            var timeConverter = new TimeConverter();
            Assert.Throws<ArgumentException>(() => timeConverter.convertTime("aaaaa"));
        } 
        
        [TestCase("00:00:01","O")]
        [TestCase("00:00:00","Y")]
        [TestCase("00:00:59","O")]
        public void convertTime_SecondsLineCheck(string timeString, string expected)
        {
            var timeConverter = new TimeConverter();
            var result = timeConverter.convertTime(timeString).Split(new []{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries).First();
            
            Assert.AreEqual(expected, result);
        }    
        
        [TestCase("00:00:00","OOOO")]
        [TestCase("13:00:00", "RROO")]
        [TestCase("23:00:00", "RRRR")]
        [TestCase("24:00:00", "RRRR")]
        public void convertTime_HoursLine1Check(string timeString, string expected)
        {
            var timeConverter = new TimeConverter();
            var result = timeConverter.convertTime(timeString).Split(new []{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries)[1];
            
            Assert.AreEqual(expected, result);
        }

        [TestCase("00:00:00", "OOOO")]
        [TestCase("13:00:00", "RRRO")]
        [TestCase("23:00:00", "RRRO")]
        [TestCase("24:00:00", "RRRR")]
        public void convertTime_HoursLine2Check(string timeString, string expected)
        {
            var timeConverter = new TimeConverter();
            var result = timeConverter.convertTime(timeString).Split(new []{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries)[2];
            
            Assert.AreEqual(expected, result);
        }   
        
        [TestCase("00:00:00", "OOOOOOOOOOO")]
        [TestCase("13:17:00", "YYROOOOOOOO")]
        [TestCase("23:59:00", "YYRYYRYYRYY")]
        [TestCase("24:00:00", "OOOOOOOOOOO")]
        public void convertTime_MinutesLine1Check(string timeString, string expected)
        {
            var timeConverter = new TimeConverter();
            var result = timeConverter.convertTime(timeString).Split(new []{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries)[3];
            
            Assert.AreEqual(expected, result);
        }

        [TestCase("00:00:00", "OOOO")]
        [TestCase("13:17:00", "YYOO")]
        [TestCase("23:59:00", "YYYY")]
        [TestCase("24:00:00", "OOOO")]
        public void convertTime_MinutesLine2Check(string timeString, string expected)
        {
            var timeConverter = new TimeConverter();
            var result = timeConverter.convertTime(timeString).Split(new []{Environment.NewLine},StringSplitOptions.RemoveEmptyEntries)[4];
            
            Assert.AreEqual(expected, result);
        }   
    }
}
