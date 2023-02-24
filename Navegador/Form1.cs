using Microsoft.Web.WebView2.Core;
using System.Windows.Forms;

namespace Navegador
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void cargarUrl(string url) 
        {
            if (!string.IsNullOrEmpty(txtUrl.Text))
            {
                try
                {
                    webView.CoreWebView2.Navigate(txtUrl.Text);
                }
                catch (Exception ex)
                {
                    webView.CoreWebView2.ExecuteScriptAsync("alert('URL Invalida, debe ser un link https://')");
                }
                finally
                {
                    txtUrl.Text = null;
                }
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtUrl_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                cargarUrl(txtUrl.Text);    
            }
                
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.Navigate("https://www.google.com/");
        }

        private void btnEnter_Click(object sender, EventArgs e)
        {
            cargarUrl(txtUrl.Text);
        }
        private void btnBack_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.GoBack();
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            webView.CoreWebView2.GoForward();
        }

        private void btnRefresh_Click_1(object sender, EventArgs e)
        {
            webView.CoreWebView2.Reload();
        }

        private void webView_NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            ProgressBar1.Visible = true;
        }
        private void webView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            ProgressBar1.Visible = false;
        }
    }
}