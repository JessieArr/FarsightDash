using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        public void Autosave()
        {
            var savableData = ModuleRegistry.DefaultRegistry.GetSavableModuleData();

            SaveModuleData("Autosave.ini", savableData);
        }

        public void SaveModuleData(string fileName, List<ISavableModuleData> moduleData)
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

            foreach (var module in savedModules)
            {
                var newControl = new LayoutAnchorable();
                newControl.Content = module;
                ModuleRegistry.DefaultRegistry.RegisterModule(module);

                newControl.Title = module.ModuleName;
                newControl.Hiding += (o, args) =>
                {
                    ModuleRegistry.DefaultRegistry.UnregisterModule(module);
                };
                DockHelper.RootAnchorablePane.Children.Add(newControl);
            }
        }
    }
}
