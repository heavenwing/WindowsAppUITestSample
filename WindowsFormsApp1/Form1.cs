using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Permissions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    [PermissionSet(SecurityAction.Demand, Name = "FullTrust")]
    [ComVisible(true)]
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            webBrowser1.AllowWebBrowserDrop = false;
            //webBrowser1.IsWebBrowserContextMenuEnabled = false;
            webBrowser1.WebBrowserShortcutsEnabled = false;
            webBrowser1.ObjectForScripting = this;
        }

        private void LoadDocument(object sender, EventArgs e)
        {
        }

        public void LoginClicked()
        {
            var username = webBrowser1.Document.GetElementById("txtUsername").GetAttribute("value");
            var password = webBrowser1.Document.GetElementById("txtPassword").GetAttribute("value");

            if (username == "zyg" && password == "123")
            {
                MessageBox.Show("Login Success");
                LoadListPage();
            }
            else
                MessageBox.Show("Login Failed");

        }

        private void LoadListPage()
        {
            webBrowser1.DocumentStream = File.OpenRead("list.html");
            webBrowser1.DocumentCompleted += ListLoaded;
        }

        private void ListLoaded(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            webBrowser1.DocumentCompleted -= ListLoaded;

            var lstItems = webBrowser1.Document.GetElementById("lstItems");

            var data = new string[] { "abc", "efg", "xyz" };
            foreach (var item in data)
            {
                AppendOptionIntoSelect(lstItems, item);
            }
        }

        private void AppendOptionIntoSelect(HtmlElement lstItems, string item)
        {
            var option = webBrowser1.Document.CreateElement("option");
            option.SetAttribute("value", item);
            option.InnerText = item;
            lstItems.AppendChild(option);
        }

        public void AddClicked()
        {
            var txtItem = webBrowser1.Document.GetElementById("txtItem");
            var lstItems = webBrowser1.Document.GetElementById("lstItems");
            AppendOptionIntoSelect(lstItems, txtItem.GetAttribute("value"));
        }

        private void Action1(object sender, EventArgs e)
        {
            //webBrowser1.Document.get
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webBrowser1.DocumentStream = File.OpenRead("index.html");
            //LoadListPage();
        }
    }
}
