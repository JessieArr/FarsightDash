using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;
using FarsightDash.Saving;
using IniParser;
using IniParser.Model;
using Newtonsoft.Json;
using Xceed.Wpf.AvalonDock.Layout;

namespace FarsightDash
{
    public class SaveFileHelper
    {
        private const string _ConsumerHierarchySectionName = "__FarsightDash.Consumer.Hierarchy";
        private const string _ConsumerHierarchyDelimiter = ", ";
        public void Autosave()
        {
            var savableData = ModuleRegistry.DefaultRegistry.GetSavableModuleData();
            var consumerHierarchyDictionary = ModuleRegistry.DefaultRegistry.GetSavableConsumerDictionary();

            SaveModuleDataJson("Autosave.json", savableData, consumerHierarchyDictionary);
        }

        public void LoadSavedModulesFromFile(string fileName)
        {
            var savedModules = GetSavedModulesFromFileJson(fileName);
            var anchorableService = new AnchorableViewService();

            foreach (var module in savedModules)
            {
                ModuleRegistry.DefaultRegistry.RegisterModule(module);

                if (module is IDashboardView)
                {
                    var newControl = anchorableService.GetAnchorableFromView((IDashboardView) module);
                    DockHelper.RootAnchorablePane.Children.Add(newControl);
                }
            }

            var relationships = GetConsumerRelationshipsFromFileJson(fileName);
            foreach (var relationship in relationships)
            {
                var emitter = ModuleRegistry.DefaultRegistry.GetRegisteredModule(relationship.EmitterModuleName);
                var consumer = ModuleRegistry.DefaultRegistry.GetRegisteredModule(relationship.ConsumingModuleName);

                ModuleRegistry.DefaultRegistry.ConsumeData(emitter, consumer);
            }
        }

        public List<ISavableModule> GetSavedModulesFromFileJson(string fileName)
        {
            var list = new List<ISavableModule>();
            var fileData = File.ReadAllText(fileName);
            var saveData = JsonConvert.DeserializeObject<DashboardSaveData>(fileData);

            foreach (var type in saveData.ModuleTypeData)
            {
                var factoryRegistry = ModuleFactoryRegistry.DefaultRegistry;
                
                try
                {
                    var factory = factoryRegistry.GetSavableModuleFactory(type.ModuleTypeName);
                    foreach (var savedModule in type.Modules)
                    {
                        var module = factory.GetSavableModuleFromString(savedModule.SaveString);
                        module.ModuleName = savedModule.ModuleName;
                        list.Add(module);
                    }
                }
                catch (Exception)
                {
                    FarsightLogger.DefaultLogger.LogWarning($"No SavableModuleFactory found for module type name: " + type.ModuleTypeName);
                }
            }

            return list;
        }

        public List<ModuleConsumerRelationship> GetConsumerRelationshipsFromFileJson(string fileName)
        {
            var list = new List<ISavableModule>();
            var fileData = File.ReadAllText(fileName);
            var saveData = JsonConvert.DeserializeObject<DashboardSaveData>(fileData);

            return saveData.ConsumerRelationships;
        }

        public void SaveModuleDataJson(string fileName, List<ISavableModuleData> moduleData,
            Dictionary<string, List<string>> consumerHierarchyDictionary)
        {
            var data = new DashboardSaveData();

            foreach (var module in moduleData)
            {
                var moduleTypeData = data.ModuleTypeData.FirstOrDefault(x => x.ModuleTypeName == module.ModuleTypeName);
                if (moduleTypeData == null)
                {
                    moduleTypeData = new ModuleTypeSaveData()
                    {
                        ModuleTypeName = module.ModuleTypeName
                    };
                    data.ModuleTypeData.Add(moduleTypeData);
                }
                moduleTypeData.Modules.Add(new ModuleSaveData()
                {
                    ModuleName = module.ModuleName,
                    SaveString = module.ModuleSaveString
                });
            }

            foreach (var key in consumerHierarchyDictionary)
            {
                foreach (var emitter in key.Value)
                {
                    data.ConsumerRelationships.Add(new ModuleConsumerRelationship()
                    {
                        ConsumingModuleName = key.Key,
                        EmitterModuleName = emitter
                    });
                }
            }

            var serializedData = JsonConvert.SerializeObject(data);
            File.WriteAllText(fileName, serializedData);
        }
    }
}
