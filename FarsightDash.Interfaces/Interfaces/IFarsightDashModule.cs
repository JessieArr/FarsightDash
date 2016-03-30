using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace FarsightDash.Common.Interfaces
{
    public interface IFarsightDashModule
    {
        /// <summary>
        /// A user-provided name for your module. They will use this when referring to it later.
        /// </summary>
        string ModuleName { get; set; }

        /// <summary>
        /// The name of this type of module. This will let the user know what sort of module it is
        /// when they are looking at their available modules
        /// </summary>
        string ModuleTypeName { get; }
    }
}
