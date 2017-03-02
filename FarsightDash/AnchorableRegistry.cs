using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xceed.Wpf.AvalonDock.Layout;

namespace FarsightDash
{
    public class AnchorableRegistry
    {
        public static AnchorableRegistry DefaultRegistry = new AnchorableRegistry();

        private Dictionary<string, LayoutAnchorable> _Anchorables = new Dictionary<string, LayoutAnchorable>();

        public void RegisterAnchorable(LayoutAnchorable newAnchorable)
        {
            if (_Anchorables.ContainsKey(newAnchorable.Title))
            {
                throw new Exception($"Anchorable {newAnchorable.Title} already registered!");
            }

            _Anchorables.Add(newAnchorable.Title, newAnchorable);
        }

        internal LayoutAnchorable GetRegisteredAnchorable(string paneName)
        {
            if (!_Anchorables.ContainsKey(paneName))
            {
                throw new Exception($"Anchorable {paneName} was not registered!");
            }

            return _Anchorables[paneName];
        }

        internal bool IsAnchorableRegistered(string anchorableName)
        {
            return _Anchorables.ContainsKey(anchorableName);
        }

        public void UnregisterModule(LayoutAnchorable newModule)
        {
            if (!_Anchorables.ContainsKey(newModule.Title))
            {
                throw new Exception($"Anchorable {newModule.Title} is not registered!");
            }

            _Anchorables.Remove(newModule.Title);
        }
    }
}
