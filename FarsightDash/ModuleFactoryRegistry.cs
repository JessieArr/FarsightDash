using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using FarsightDash.Common;
using FarsightDash.Common.Interfaces;

namespace FarsightDash
{
    public class ModuleRegistry : IFarsightModuleRegistry
    {
        public void RegisterModule(IFarsightDashModule newModule)
        {
            throw new NotImplementedException();
        }

        public void RegisterDataConsumer(string dataEmitterName, IDataConsumer consumer)
        {
            throw new NotImplementedException();
        }
    }
}
