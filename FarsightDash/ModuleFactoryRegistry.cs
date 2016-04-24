using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash
{
    public class ModuleFactoryRegistry : IModuleFactoryRegistry
    {
        public static IModuleFactoryRegistry DefaultRegistry = new ModuleFactoryRegistry();

        private Dictionary<string, IModuleFactory> _RegisteredFactories = new Dictionary<string, IModuleFactory>();

        public void RegisterModuleFactory(IModuleFactory factory)
        {
            if (_RegisteredFactories.ContainsKey(factory.ModuleTypeName))
            {
                throw new Exception($"Factory for control: {factory.ModuleTypeName} is already registered!");
            }
            _RegisteredFactories.Add(factory.ModuleTypeName, factory);
        }

        public IModuleFactory GetModuleFactory(string factoryName)
        {
            if (!_RegisteredFactories.ContainsKey(factoryName))
            {
                throw new Exception($"Factory for control: {factoryName} is not registered!");
            }
            return _RegisteredFactories[factoryName];
        }

        private Dictionary<string, ISavableModuleFactory> _RegisteredSavableFactories = new Dictionary<string, ISavableModuleFactory>();

        public void RegisterSavableModuleFactory(ISavableModuleFactory factory)
        {
            if (_RegisteredSavableFactories.ContainsKey(factory.ModuleTypeName))
            {
                throw new Exception($"Factory for control: {factory.ModuleTypeName} is already registered!");
            }
            _RegisteredSavableFactories.Add(factory.ModuleTypeName, factory);
        }

        public ISavableModuleFactory GetSavableModuleFactory(string factoryName)
        {
            if (!_RegisteredSavableFactories.ContainsKey(factoryName))
            {
                var errorString = $"Factory for control: {factoryName} is not registered!";
                throw new Exception(errorString);
            }
            return _RegisteredSavableFactories[factoryName];
        }

        public List<string> GetAllRegisteredFactoryNames()
        {
            return _RegisteredFactories.Keys.ToList();
        } 
    }
}
