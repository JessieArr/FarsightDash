using System.Collections.Generic;
using System.Windows.Controls;

namespace FarsightDash.Common.Interfaces
{
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
        bool IsEnteredUserDataValid();

        /// <summary>
        /// Finishes the Module creation, and returns .
        /// </summary>
        /// <param name="moduleRegistry">The application's Module Registry.</param>
        /// <returns>One or more Farsight Dash Modules which are created by this control.</returns>
        List<IFarsightDashModule> CreateModules(IFarsightModuleRegistry moduleRegistry);
    }
}