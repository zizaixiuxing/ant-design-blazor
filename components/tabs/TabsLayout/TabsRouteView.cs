using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Rendering;

namespace AntDesign
{
    public class TabsRouteView : RouteView
    {
        protected override void Render(RenderTreeBuilder builder)
        {
            var layoutType = RouteData.PageType.GetCustomAttribute<LayoutAttribute>()?.LayoutType ?? DefaultLayout;

            builder.OpenComponent(0, layoutType);
            builder.AddAttribute(1, "Body", CreateBody(RouteData.PageType, RouteData.RouteValues));

            if (layoutType == typeof(TabsLayout))
            {
                builder.AddAttribute(2, "PageType", RouteData.PageType);
                builder.AddAttribute(3, "RouteValues", RouteData.RouteValues);
            }

            builder.CloseComponent();
        }

        private static RenderFragment CreateBody(Type pageType, IReadOnlyDictionary<string, object> routeValues) => builder =>
        {
            builder.OpenComponent(0, pageType);
            foreach (KeyValuePair<string, object> routeValue in routeValues)
            {
                builder.AddAttribute(1, routeValue.Key, routeValue.Value);
            }
            builder.CloseComponent();
        };
    }
}
