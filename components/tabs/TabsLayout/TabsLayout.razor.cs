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

        [Inject]
        private NavigationManager NavigationManager { get; set; }

        private string _activeKey;
        private Dictionary<string, TabPage> _tabPages = new Dictionary<string, TabPage>();

        protected override bool ShouldRender()
        {
            var currentUrl = NavigationManager.Uri;

            if (_tabPages.TryGetValue(currentUrl, out var currentPage))
            {
            }
            else
            {
                currentPage = new TabPage(currentUrl, Body);
                _tabPages[currentUrl] = currentPage;
                _activeKey = currentUrl;
            }

            return base.ShouldRender();
        }
    }
}
