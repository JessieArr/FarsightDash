using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FarsightDash.Common.Interfaces;
using Xceed.Wpf.AvalonDock.Layout;

namespace FarsightDash
{
    public class AnchorableViewService : IAnchorableViewService
    {
        public LayoutAnchorable GetAnchorableFromView(IDashboardView view)
        {
            var newAnchorable = new LayoutAnchorable();
            newAnchorable.Content = view.Control;
            newAnchorable.AutoHideMinHeight = 15;

            newAnchorable.Title = view.ModuleName;
            newAnchorable.ContentId = view.ModuleName;

            return newAnchorable;
        }
    }

    public interface IAnchorableViewService
    {
        LayoutAnchorable GetAnchorableFromView(IDashboardView view);
    }
}
