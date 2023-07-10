using CefSharp;
using CefSharp.WinForms;

namespace EmbeddedBrowser.Handler
{
    public class CustomRequestHandler : CefSharp.Handler.RequestHandler
    {

        public CustomRequestHandler(ChromiumWebBrowser browser)
        {
            browser.RequestHandler = this;
        }
        protected override IResourceRequestHandler GetResourceRequestHandler(IWebBrowser chromiumWebBrowser, IBrowser browser, IFrame frame, IRequest request, bool isNavigation, bool isDownload, string requestInitiator, ref bool disableDefaultHandling)
        {
            return new CustomResourceRequestHandler();
        }
    }
}
