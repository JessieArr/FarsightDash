using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FarsightDash.Saving
{
    public class DashboardSaveData
    {
        public List<ModuleTypeSaveData> ModuleTypeData { get; set; }
        public List<ModuleConsumerRelationship> ConsumerRelationships { get; set; }
        public List<ViewWindowSaveData> ViewWindowSaveData { get; set; } 
        public WindowPositionSaveData WindowPosition { get; set; }

        public DashboardSaveData()
        {
            ModuleTypeData = new List<ModuleTypeSaveData>();
            ConsumerRelationships = new List<ModuleConsumerRelationship>();
            ViewWindowSaveData = new List<ViewWindowSaveData>();
            WindowPosition = new WindowPositionSaveData();
        }
    }
}
