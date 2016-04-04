using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.Common.Interfaces;

namespace FarsightDash
{
    public class ModuleManagementData
    {
        public string ModuleName { get; set; }
        public string ModuleTypeName { get; set; }
        public bool IsDataEmitter { get; set; }
        public bool IsDataConsumer { get; set; }
        public bool IsDashboardView { get; set; }

        public ModuleManagementData(IFarsightDashModule module)
        {
            ModuleName = module.ModuleName;
            ModuleTypeName = module.ModuleTypeName;

            IsDataEmitter = module is IDataEmitter;
            IsDataConsumer = module is IDataConsumer;
            IsDashboardView = module is IDashboardView;
        }
    }
}
