using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace FarsightDash.Common.Interfaces
{
    public interface IModuleFactory
    {
        /// <summary>
        /// The type of module for which this IModuleFactory should be used.
        /// </summary>
        string ModuleTypeName { get; }

        /// <summary>
        /// Creates a new view which the user can use to configure the newly created module(s)
        /// </summary>
        /// <returns>IModuleSetupView which can be used to finish creating the module.</returns>
        IModuleSetupView GetNewModuleSetupView();
    }

    public interface IModuleSetupView
    {
        /// <summary>
        /// The UserControl which the user will use to configure the new Module.
        /// </summary>
        UserControl Control { get; }

        /// <summary>
        /// This will trigger any relevant validation of the Control property in the UI.
        /// </summary>
        /// <returns>True if the control can be created now. False if there are validation
        /// errors the user needs to address.</returns>
        bool IsUserDataValid();

        /// <summary>
        /// Finishes the Module creation, and returns .
        /// </summary>
        /// <param name="moduleRegistry">The application's Module Registry.</param>
        /// <returns>One or more Farsight Dash Modules which are created by this control.</returns>
        List<IFarsightDashModule> CreateModules(IFarsightModuleRegistry moduleRegistry);
    }

    public interface IFarsightModuleRegistry
    {
        void RegisterModule(IFarsightDashModule newModule);
        void RegisterDataConsumer(string dataEmitterName, IDataConsumer consumer);
    }
}
