using System.Collections.Generic;

namespace FarsightDash.Common.Interfaces
{
    public interface IFarsightModuleRegistry
    {
        void RegisterModule(IFarsightDashModule newModule);
    }
}