using BerlinClock.Services.ColorProvider;
using NUnit.Framework;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Assert = NUnit.Framework.Assert;

namespace BerlinClock.Tests.Services.ColorProvider
{
    [TestFixture()]
    public class RedColorProviderTests
    {
        [TestCase()]
        public void GetColor_Enabled()
        {
            var colorProvider = new RedColorProvider();
            var result = colorProvider.GetColor(true);

            Assert.AreEqual("R",result);
        } 
        
        [TestCase()]
        public void GetColor_Disabled()
        {
            var colorProvider = new RedColorProvider();
            var result = colorProvider.GetColor(false);

            Assert.AreEqual("O",result);
        }
    }
}
