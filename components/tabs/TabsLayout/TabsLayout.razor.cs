using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    public partial class TabsLayout : LayoutComponentBase
    {
        [Parameter]
        public Type PageType { get; set; }

        [Parameter]
        public IReadOnlyDictionary<string, object> RouteValues { get; set; }

        private string _activeKey;
        private Dictionary<string, TabPage> _tabPages = new Dictionary<string, TabPage>();
    }
}
