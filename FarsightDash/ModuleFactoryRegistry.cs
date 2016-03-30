using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.Common.Interfaces;

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

        public List<string> GetAllRegisteredFactoryNames()
        {
            return _RegisteredFactories.Keys.ToList();
        } 
    }

    public interface IModuleFactoryRegistry
    {
        void RegisterModuleFactory(IModuleFactory factory);

        IModuleFactory GetModuleFactory(string factoryName);

        List<string> GetAllRegisteredFactoryNames();
    }
}
