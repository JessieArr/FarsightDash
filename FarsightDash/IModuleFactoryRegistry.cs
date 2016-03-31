using System.Collections.Generic;
using FarsightDash.Common.Interfaces;
using FarsightDash.Common.Saving;

namespace FarsightDash
{
    public interface IModuleFactoryRegistry
    {
        void RegisterModuleFactory(IModuleFactory factory);

        IModuleFactory GetModuleFactory(string factoryName);

        void RegisterSavableModuleFactory(ISavableModuleFactory factory);

        ISavableModuleFactory GetSavableModuleFactory(string factoryName);

        List<string> GetAllRegisteredFactoryNames();
    }
}