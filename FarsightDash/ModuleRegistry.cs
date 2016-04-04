using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash
{
    public class ModuleRegistry : IFarsightModuleRegistry
    {
        public static ModuleRegistry DefaultRegistry = new ModuleRegistry();

        private Dictionary<string, IFarsightDashModule> _Modules = new Dictionary<string, IFarsightDashModule>();

        public void RegisterModule(IFarsightDashModule newModule)
        {
            if (_Modules.ContainsKey(newModule.ModuleName))
            {
                throw new Exception($"Module {newModule.ModuleName} already registered!");
            }

            _Modules.Add(newModule.ModuleName, newModule);
        }

        public void UnregisterModule(IFarsightDashModule newModule)
        {
            if (!_Modules.ContainsKey(newModule.ModuleName))
            {
                throw new Exception($"Module {newModule.ModuleName} is not registered!");
            }

            _Modules.Remove(newModule.ModuleName);
        }

        public List<ISavableModuleData> GetSavableModuleData()
        {
            var list = new List<ISavableModuleData>();

            var savableModules = _Modules.Select(x =>
            {
                if (x.Value is ISavableModule)
                {
                    return x.Value as ISavableModule;
                }
                return null;
            });
            foreach (var module in savableModules)
            {
                var moduleData = new SavableModuleData();
                moduleData.ModuleTypeName = module.ModuleTypeName;
                moduleData.ModuleName = module.ModuleName;
                moduleData.ModuleData = module.GetSaveString();
                list.Add(moduleData);
            }

            return list;
        }

        public List<ModuleManagementData> GetRegisteredControlNames()
        {
            return _Modules.Select(x => new ModuleManagementData(x.Value)).ToList();
        } 
    }
}
