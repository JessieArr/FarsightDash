using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        IModuleSetupView GetNewModuleSetupView(IFarsightModuleRegistry moduleRegistry);
    }
}
