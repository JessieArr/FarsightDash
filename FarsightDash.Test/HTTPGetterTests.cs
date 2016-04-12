using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.BaseModules;
using FarsightDash.BaseModules.DataEmitters;
using NUnit.Framework;
using NUnit.Framework.Internal;

namespace FarsightDash.Test
{
    [TestFixture]
    public class HTTPGetterTests
    {
        [Test]
        public void IncludeAllFields()
        {
            var SUT = new HTTPGetter("http://google.com", 1, new WebResponseHelper(), true, true, true, true);
            SUT.EmitData += (sender, args) =>
            {
                var x = args.Data;
            };

            SUT.Initialize();
        }

        [Test]
        public void RedirectedURLOnly()
        {
            var SUT = new HTTPGetter("http://twitter.com", 1, new WebResponseHelper(), true, false, false, false);
            SUT.EmitData += (sender, args) =>
            {
                var x = args.Data;
            };

            SUT.Initialize();
        }

        [Test]
        public void URLAndStatus()
        {
            var SUT = new HTTPGetter("http://twitter.com", 1, new WebResponseHelper(), true, true, false, false);
            SUT.EmitData += (sender, args) =>
            {
                var x = args.Data;
            };

            SUT.Initialize();
        }

        [Test]
        public void HeadersOnly()
        {
            var SUT = new HTTPGetter("http://twitter.com", 1, new WebResponseHelper(), false, false, true, false);
            SUT.EmitData += (sender, args) =>
            {
                var x = args.Data;
            };

            SUT.Initialize();
        }

        [Test]
        public void BodyOnly()
        {
            var SUT = new HTTPGetter("http://twitter.com", 1, new WebResponseHelper(), false, false, false, true);
            SUT.EmitData += (sender, args) =>
            {
                var x = args.Data;
            };

            SUT.Initialize();
        }
    }
}
