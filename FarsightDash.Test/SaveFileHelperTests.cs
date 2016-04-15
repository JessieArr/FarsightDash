using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace FarsightDash.Test
{
    [TestFixture]
    public class SaveFileHelperTests
    {
        [Test]
        public void JsonSaveSucceeds()
        {
            var SUT = new SaveFileHelper();
            SUT.SaveModuleDataJson("Z:\\Test.json", new List<ISavableModuleData>(){
            new SavableModuleData()
            {
                ModuleName = "TestName",
                ModuleTypeName = "TestModuleType",
                ModuleSaveString = "1 2 3"
            }
            }, new Dictionary<string, List<string>>());
        }
    }
}
