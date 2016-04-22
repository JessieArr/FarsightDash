using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules.Transforms;
using FarsightDash.BaseModules.Transforms.RegexFilter;
using FarsightDash.Common;
using NUnit.Framework;

namespace FarsightDash.Test
{
    [TestFixture]
    public class RegexTransformTests
    {
        [Test]
        public void RegexTransform_MatchesInteger()
        {
            var SUT = new RegexFilter("\\d+");

            string result = null;
            SUT.EmitData += (sender, args) =>
            {
                result = args.Data;
            };
            SUT.DataHandler.Invoke(this, new EmitDataHandlerArgs("Test 12 Data"));

            Assert.That(result == "12");
        }

        [Test]
        public void RegexTransform_MatchesFirstInteger()
        {
            var SUT = new RegexFilter("\\d+");

            string result = null;
            SUT.EmitData += (sender, args) =>
            {
                result = args.Data;
            };
            SUT.DataHandler.Invoke(this, new EmitDataHandlerArgs("Test 12 Data 14"));

            Assert.That(result == "12");
        }
    }
}
