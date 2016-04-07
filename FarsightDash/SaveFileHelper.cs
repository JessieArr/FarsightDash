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
using IniParser;
using IniParser.Model;
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

            SaveModuleData("Autosave.ini", savableData, consumerHierarchyDictionary);
        }

        public void SaveModuleData(string fileName, List<ISavableModuleData> moduleData, Dictionary<string, List<string>> consumerHierarchyDictionary)
        {
            var iniData = new IniData();
            foreach (var datum in moduleData)
            {
                if (!iniData.Sections.ContainsSection(datum.ModuleName))
                {
                    iniData.Sections.AddSection(datum.ModuleTypeName);
                }
                iniData[datum.ModuleTypeName].AddKey(datum.ModuleName, datum.ModuleData);
            }

            iniData.Sections.AddSection(_ConsumerHierarchySectionName);
            foreach (var consumer in consumerHierarchyDictionary)
            {
                if (consumer.Value.Count > 0)
                {
                    iniData[_ConsumerHierarchySectionName].AddKey(consumer.Key, consumer.Value.Aggregate((a, b) =>
                    {
                        return a + _ConsumerHierarchyDelimiter + b;
                    }));
                }
            }

            var parser = new FileIniDataParser();
            parser.WriteFile(fileName, iniData);
        }

        public List<ISavableModule> GetSavedModulesFromFile(string fileName)
        {
            var list = new List<ISavableModule>();
            var parser = new FileIniDataParser();

            var iniData = parser.ReadFile(fileName);

            foreach (var section in iniData.Sections)
            {
                var factoryRegistry = ModuleFactoryRegistry.DefaultRegistry;

                if (section.SectionName == _ConsumerHierarchySectionName)
                {
                    continue;
                }

                try
                {
                    var factory = factoryRegistry.GetSavableModuleFactory(section.SectionName);
                    foreach (var key in section.Keys)
                    {
                        var module = factory.GetSavableModuleFromString(key.Value);
                        module.ModuleName = key.KeyName;
                        list.Add(module);
                    }
                }
                catch (Exception)
                {
                    FarsightLogger.DefaultLogger.LogWarning($"No SavableModuleFactory found for module type name: " + section.SectionName);
                }
            }

            return list;
        }

        public void LoadSavedModuleFromFile(string fileName)
        {
            var savedModules = GetSavedModulesFromFile(fileName);
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
        }
    }
}
