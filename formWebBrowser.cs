using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WebBrowser
{
    public partial class formWebBrowser : Form
    {
        private const string HOME_URL = "https://www.google.co.jp/";
        private string m_strUrl;
        private ToolTip m_toolTip;

        public formWebBrowser()
        {
            InitializeComponent();
            m_strUrl = "";
        }

        ~formWebBrowser()
        {
            m_toolTip = null;
        }

        private void textUrl_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                m_strUrl = textUrl.Text;
                webBrowser.Navigate(m_strUrl);
            }
        }

        private void formWebBrowser_FormClosed(object sender, FormClosedEventArgs e)
        {
            formWebBrowser form = Program.g_listWebBrowser[uint.Parse(this.Name)];
            form = null;
            Program.g_listWebBrowser.Remove(uint.Parse(this.Name));
        }

        private void formWebBrowser_Load(object sender, EventArgs e)
        {
            setInitToolTip();
            showHome();
        }

        private void setInitToolTip()
        {
            m_toolTip = new ToolTip();
            m_toolTip.SetToolTip(textUrl, "After entering the URL, please press the enter key!!!");
        }

        private void showHome()
        {
            Uri uri = new Uri(HOME_URL);
            webBrowser.Navigate(uri);
            textUrl.Text = m_strUrl;
            this.Text = m_strUrl;
        }

        private void buttonAbove_Click(object sender, EventArgs e)
        {
            if ( webBrowser.CanGoBack == true )
            {
                webBrowser.GoBack();
            }
        }

        private void buttonNext_Click(object sender, EventArgs e)
        {
            if (webBrowser.CanGoForward == true)
            {
                webBrowser.GoForward();
            }
        }

        private void buttonRefresh_Click(object sender, EventArgs e)
        {
            webBrowser.Refresh();
        }

        private void formWebBrowser_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textUrl.Text = webBrowser.Url.AbsoluteUri;
            this.Text = webBrowser.Url.AbsoluteUri;
        }
    }
}