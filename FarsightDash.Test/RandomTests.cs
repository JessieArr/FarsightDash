using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FarsightDash.Test
{
    [TestFixture]
    public class RandomTests
    {
        [Test]
        public void Test()
        {
            var SUT = new SaveFileHelper();
            SUT.SaveModuleData("Z:\\Test.ini", new List<ISavableModuleData>()
            {
                new SavableModuleData()
                {
                    ModuleTypeName = "TestType",
                    ModuleName = "TestName",
                    ModuleData= "TestData"
                }
            });
        }
    }
}
