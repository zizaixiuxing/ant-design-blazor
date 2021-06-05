using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Components;

namespace AntDesign
{
    internal class TabPage
    {
        private string _url;

        private DateTime _startTime = DateTime.Now;
        private DateTime _activeTime = DateTime.Now;
        private TimeSpan _maxLifeSpan;

        internal RenderFragment _pageBody;
        internal Type _pageType;
        internal RenderFragment _title;
        private IReadOnlyDictionary<string, object> _routeValues;

        private object _instance;

        public TabPage(string url, RenderFragment body)
        {
            this._url = url;
            this._pageBody = body;
        }

        public void BuildCustomBodyRenderer(Type pageType, IReadOnlyDictionary<string, object> routeValues)
        {
            this._pageType = pageType;
            this._routeValues = routeValues;
            this._pageBody = builder =>
            {
                builder.OpenComponent(0, _pageType);
                builder.SetKey(this._startTime);

                foreach (KeyValuePair<string, object> routeValue in _routeValues)
                {
                    builder.AddAttribute(1, routeValue.Key, routeValue.Value);
                }

                builder.AddComponentReferenceCapture(2, obj =>
                {
                    _instance = obj;
                });
                builder.CloseComponent();
            };
            this._title = builder =>
            {
                builder.AddContent(0, "tab");
            };
        }
    }
}
