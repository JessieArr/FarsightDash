using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarsightDash
{
    public class SavableModuleData : ISavableModuleData
    {
        public string ModuleName { get; set; }
        public string ModuleTypeName { get; set; }
        public string ModuleData { get; set; }
    }
}
