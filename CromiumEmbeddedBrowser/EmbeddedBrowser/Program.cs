using CefSharp;
using CefSharp.WinForms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EmbeddedBrowser
{
    static class Program
    {
        [STAThread]
        [Obsolete]
        static int Main()
        {
            var settings = new CefSettings()
            {
                CachePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "CefSharp\\Cache")
            };

            settings.CefCommandLineArgs.Add("enable-media-stream");

            settings.CefCommandLineArgs.Add("use-fake-ui-for-media-stream");
            
            settings.CefCommandLineArgs.Add("enable-usermedia-screen-capturing");

            Cef.Initialize(settings, performDependencyCheck: true, browserProcessHandler: null);

            var browser = new BrowserForm();
            Application.Run(browser);

            return 0;
        }
    }
}
