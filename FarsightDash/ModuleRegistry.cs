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
        private Dictionary<string, List<string>> _ConsumerDictionary = new Dictionary<string, List<string>>();

        public void RegisterModule(IFarsightDashModule newModule)
        {
            if (_Modules.ContainsKey(newModule.ModuleName))
            {
                throw new Exception($"Module {newModule.ModuleName} already registered!");
            }

            _Modules.Add(newModule.ModuleName, newModule);
        }

        internal IFarsightDashModule GetRegisteredModule(string moduleName)
        {
            if (!_Modules.ContainsKey(moduleName))
            {
                throw new Exception($"Module {moduleName} was not registered!");
            }

            return _Modules[moduleName];
        }

        public void UnregisterModule(IFarsightDashModule newModule)
        {
            if (!_Modules.ContainsKey(newModule.ModuleName))
            {
                throw new Exception($"Module {newModule.ModuleName} is not registered!");
            }

            _Modules.Remove(newModule.ModuleName);
            if (_ConsumerDictionary.ContainsKey(newModule.ModuleName))
            {
                _ConsumerDictionary.Remove(newModule.ModuleName);
            }

            foreach (var key in _ConsumerDictionary)
            {
                if (key.Value.Any(x => x == newModule.ModuleName))
                {
                    key.Value.Remove(newModule.ModuleName);
                }
            }
        }

        public List<ISavableModuleData> GetSavableModuleData()
        {
            var list = new List<ISavableModuleData>();

            var savableModules = _Modules.Where(x =>
            {
                return x.Value is ISavableModule;
            }).Select(x =>
            {
                return x.Value as ISavableModule;
            });
            foreach (var module in savableModules)
            {
                var moduleData = new SavableModuleData();
                moduleData.ModuleTypeName = module.ModuleTypeName;
                moduleData.ModuleName = module.ModuleName;
                moduleData.ModuleSaveString = module.GetSaveString();
                list.Add(moduleData);
            }

            return list;
        }

        public List<ModuleManagementData> GetRegisteredControlData()
        {
            return _Modules.Select(x => new ModuleManagementData(x.Value)).ToList();
        }

        public void ConsumeData(IFarsightDashModule moduleToBeConsumed, IFarsightDashModule consumingModule)
        {
            var selectedEmitter = moduleToBeConsumed as IDataEmitter;
            var selectedConsumer = consumingModule as IDataConsumer;

            if (selectedEmitter == null)
            {
                throw new Exception($"{moduleToBeConsumed.ModuleName} is not a {nameof(IDataEmitter)}!");
            }
            if (selectedConsumer == null)
            {
                throw new Exception($"{consumingModule.ModuleName} is not a {nameof(IDataConsumer)}!");
            }

            if (!_ConsumerDictionary.ContainsKey(selectedConsumer.ModuleName))
            {
                _ConsumerDictionary.Add(selectedConsumer.ModuleName, new List<string>());
            }
            if (_ConsumerDictionary[selectedConsumer.ModuleName].Contains(selectedEmitter.ModuleName))
            {
                throw new Exception(
                    $"Module {selectedEmitter.ModuleName} is already being consumed by {selectedConsumer.ModuleName}");
            }
            else
            {
                _ConsumerDictionary[selectedConsumer.ModuleName].Add(selectedEmitter.ModuleName);
            }

            selectedEmitter.EmitData += selectedConsumer.DataHandler;
            selectedEmitter.Initialize();
        }

        public Dictionary<string, List<string>> GetSavableConsumerDictionary()
        {
            var result = new Dictionary<string, List<string>>();

            foreach (var consumer in _ConsumerDictionary)
            {
                var consumerObject = GetRegisteredModule(consumer.Key);
                if (!(consumerObject is ISavableModule))
                {
                    continue;
                }

                var savableEmitters =
                    _ConsumerDictionary[consumer.Key].Where(x => GetRegisteredModule(x) is ISavableModule).ToList();

                result.Add(consumer.Key, savableEmitters);
            }

            return result;
        }
    }
}
