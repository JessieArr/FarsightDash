using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock;
using Xceed.Wpf.AvalonDock.Layout;
using Xceed.Wpf.AvalonDock.Layout.Serialization;

namespace FarsightDash
{
    public static class SaveLayoutHelper
    {
        private static string layoutFileName = "layout.txt";

        public static bool LayoutSaveExists()
        {
            return File.Exists(layoutFileName);
        }

        public static void SaveLayout(DockingManager dockingManager)
        {
            var serializer = new XmlLayoutSerializer(dockingManager);
            serializer.Serialize(layoutFileName);
        }

        public static void LoadLayout(DockingManager dockingManager)
        {
            var saveFilehelper = new SaveFileHelper();
            var serializer = new XmlLayoutSerializer(dockingManager);
            serializer.LayoutSerializationCallback += (s, e) =>
            {
                var o = e.Model as LayoutAnchorable;
                if(o == null)
                {
                    return;
                }
                var savedModule = saveFilehelper.GetSavedModuleFromFile(o.Title);
                o.Content = savedModule;
                o.IsVisible = true;
            };
            serializer.Deserialize(layoutFileName);
        }
    }
}
