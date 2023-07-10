using CefSharp;
using EmbeddedBrowser.JSFilter;
using EmbeddedBrowser.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmbeddedBrowser.Handler
{
    public class CustomResourceRequestHandler : CefSharp.Handler.ResourceRequestHandler
    {
        readonly string injection = Resources.HideElement; 

        protected override IResponseFilter GetResourceResponseFilter(IWebBrowser browserControl, IBrowser browser, IFrame frame, IRequest request, IResponse response)
        {
            return new JavascriptInjectionFilter(injection);
        }
    }
}
