using System.Collections.Generic;

namespace FarsightDash.Saving
{
    public class ModuleTypeSaveData
    {
        public string ModuleTypeName { get; set; }
        public List<ModuleSaveData> Modules { get; set; }

        public ModuleTypeSaveData()
        {
            Modules = new List<ModuleSaveData>();
        }
    }
}