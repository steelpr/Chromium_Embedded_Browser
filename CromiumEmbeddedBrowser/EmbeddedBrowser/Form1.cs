using CefSharp;
using CefSharp.WinForms;
using EmbeddedBrowser.Handler;
using System;
using System.Windows.Forms;

namespace EmbeddedBrowser
{
    public partial class BrowserForm : Form
    {
        const string defaultUrl = "https://fanagoriatravel.com/";
        readonly CustomRequestHandler requestHandler;
        readonly ChromiumWebBrowser browser;

        [Obsolete]
        public BrowserForm()
        {
            InitializeComponent();
            browser = new ChromiumWebBrowser(defaultUrl);
            requestHandler = new CustomRequestHandler(browser);
        }

        private void BrowserForm_Load(object sender, EventArgs e)
        {
            browser.Dock = DockStyle.Fill;

            this.browserPanel.Controls.Add(browser);
          
            browser.AddressChanged += AddressChanged;


        }
        private void BrowserForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Cef.Shutdown();
        }

        private void BtnForward(object sender, EventArgs e)
        {
            if (browser.CanGoForward)
            {
                browser.Forward();
            }
        }
        private void BtnBack(object sender, EventArgs e)
        {
            if (browser.CanGoBack)
            {
                browser.Back();
            }
        }

        private void BtnRefresh(object sender, EventArgs e)
        {
            browser.Refresh();
        }

        private void AddressChanged(object sender, AddressChangedEventArgs e)
        {
            this.Invoke(new MethodInvoker(() =>
             {
                 url.Text = e.Address;
                 this.Text = e.Address;
             }));
        }

        private void Url_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)13)
            {
                browser.Load(url.Text);
                //browser.ShowDevTools();  
            }
        }
    }
}
