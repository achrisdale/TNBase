using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using System.Windows.Forms;

namespace TNBase.Forms
{
    public partial class FormBlazorWebView : Form
    {
        public FormBlazorWebView()
        {
            InitializeComponent();
            blazor.HostPage = "wwwroot\\index.html";
            blazor.Services = Program.ServiceProvider;
        }

        public void ShowPage<T>() where T : IComponent
        {
            blazor.RootComponents.Clear();
            blazor.RootComponents.Add<T>("#app");
            ShowDialog();
        }
    }
}
