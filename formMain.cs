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
    public partial class formMain : Form
    {
        private uint m_nCountWebBrowser;

        public formMain()
        {
            InitializeComponent();
            Program.g_listWebBrowser = new Dictionary<uint, formWebBrowser>();
        }

        ~formMain()
        {
            Program.g_listWebBrowser.Clear();
            Program.g_listWebBrowser = null;
            m_nCountWebBrowser = 0;
        }

        private void formMain_Load(object sender, EventArgs e)
        {
            setFormMain();
            setFormChild();
        }

        private void setFormMain()
        {
            this.Size = new Size(1000, 600);
        }

        private void setFormChild()
        {
            formWebBrowser form = new formWebBrowser();
            form.MdiParent = this;
            form.WindowState = FormWindowState.Minimized;
            form.Show();
            form.Name = m_nCountWebBrowser.ToString();
            form.WindowState = FormWindowState.Maximized;
            Program.g_listWebBrowser.Add(uint.Parse(form.Name), form);
            m_nCountWebBrowser += 1;
        }

        private void menuFile_NewOpen_Click(object sender, EventArgs e)
        {
            setFormChild();
        }

        private void menuWindow_Cascade_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.Cascade);
        }

        private void menuWindow_TileHorizontal_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void menuWindow_TileVertical_Click(object sender, EventArgs e)
        {
            this.LayoutMdi(MdiLayout.TileVertical);
        }

        private void menuFile_End_Click(object sender, EventArgs e)
        {
            foreach (uint nKey in Program.g_listWebBrowser.Keys)
            {
                formWebBrowser form = Program.g_listWebBrowser[nKey];
                form = null;
            }
            this.Close();
        }

        private void formMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Program.g_listWebBrowser.Clear();
            Program.g_listWebBrowser = null;
        }
    }
}