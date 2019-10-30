using System;
using BerlinClock.Services.ColorProvider;
using NUnit.Framework;
using Assert = Microsoft.VisualStudio.TestTools.UnitTesting.Assert;

namespace BerlinClock.Tests.Services.ColorProvider
{
    [TestFixture()]
    public class YellowColorProviderTests
    {
        [TestCase()]
        public void GetColor_Enabled()
        {
            var colorProvider = new YellowColorProvider();
            var result = colorProvider.GetColor(true);

            Assert.AreEqual("Y", result);
        }

        [TestCase()]
        public void GetColor_Disabled()
        {
            var colorProvider = new YellowColorProvider();
            var result = colorProvider.GetColor(false);

            Assert.AreEqual("O", result);
        }
    }
}
