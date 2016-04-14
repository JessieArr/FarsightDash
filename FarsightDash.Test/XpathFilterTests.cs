using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.Transforms;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FarsightDash.Test
{
    [TestFixture]
    public class XpathFilterTests
    {
        private const string _TestXML = @"<?xml version=""1.0"" encoding=""UTF-8""?>

<bookstore>

<book>
  <title lang = ""en"" > Harry Potter</title>
  <price>29.99</price>
</book>

<book>
  <title lang = ""en"" > Learning XML</title>
  <price>39.95</price>
</book>

</bookstore>";

        private Mock<IFarsightLogger> _MockLogger;

        [SetUp]
        public void BeforeEachTest()
        {
            _MockLogger = new Mock<IFarsightLogger>();
            FarsightLogger.DefaultLogger = _MockLogger.Object;
        }

        [Test]
        public void SimpleXML_ReturnsExpectedValues()
        {
            string result = "";
            var SUT = new XpathFilter("//title");
            SUT.EmitData += (sender, args) =>
            {
                result = args.Data;
            };
            SUT.DataHandler(this, new EmitDataHandlerArgs(_TestXML));

            Assert.That(!String.IsNullOrEmpty(result));
            var lines = result.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Assert.That(lines.Length == 2);
        }

        [Test]
        public void InvalidXMLEmitsAndLogsError()
        {
            string result = "";
            var SUT = new XpathFilter("//title");
            SUT.EmitData += (sender, args) =>
            {
                result = args.Data;
            };
            SUT.DataHandler(this, new EmitDataHandlerArgs("1234"));

            Assert.That(!String.IsNullOrEmpty(result));
            Assert.That(result.Contains("error"));
            _MockLogger.Verify(x => x.LogError(It.IsAny<string>()), Times.Once);
        }
    }
}
