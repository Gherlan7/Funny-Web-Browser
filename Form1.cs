using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace My_Web_Browser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("This browser was developed by Ioni aka Steve Wozniak from Dabu City !");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            NavigateTo();
        }

        private void NavigateTo()
        {

            webBrowser1.Navigate(textBox1.Text);
           
            toolStripStatusLabel1.Text = "Navigation started...";
        }
        /*
        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)ConsoleKey.Enter); 
            {
                //NavigateTo();
                button1_Click(null, null);
            }
        }
        */

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            button1.Enabled = true;
            textBox1.Enabled = true;
            toolStripStatusLabel1.Text = "Navigation complete";
            foreach (HtmlElement image in webBrowser1.Document.Images)
            {
                image.SetAttribute("src", "https://i.imgflip.com/75qo22.jpg");

            } 

        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            if (e.CurrentProgress > 0 && e.MaximumProgress > 0) 
            {
                    toolStripProgressBar1.ProgressBar.Value = (int)(e.CurrentProgress * 100 / e.MaximumProgress);
            }
            
        }
    }
}
