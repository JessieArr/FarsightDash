using FarsightDash.Common.Interfaces;
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
            var serializer = new XmlLayoutSerializer(dockingManager);
            serializer.LayoutSerializationCallback += (s, eventArgs) =>
            {
                var anchorable = eventArgs.Model as LayoutAnchorable;
                if (anchorable.IsHidden)
                {
                    // This is a workaround for the fact that anchorables aren't removed from the layout when the user clicks the 'X' button
                    // instead, they are moved to a "Hidden" group. By canceling the serialization, we omit them when loading the layout.
                    eventArgs.Cancel = true;
                }
                
                if(anchorable == null)
                {
                    return;
                }

                AnchorableRegistry.DefaultRegistry.RegisterAnchorable(anchorable);

                anchorable.Show();
            };
            serializer.Deserialize(layoutFileName);
        }
    }
}
