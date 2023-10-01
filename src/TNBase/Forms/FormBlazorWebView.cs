using Microsoft.AspNetCore.Components.WebView.WindowsForms;
using System.Windows.Forms;
using TNBase.Blazor.Pages;

namespace TNBase.Forms
{
    public partial class FormBlazorWebView : Form
    {
        public FormBlazorWebView()
        {
            InitializeComponent();
            blazor.HostPage = "wwwroot\\index.html";
            blazor.Services = Program.ServiceProvider;
            blazor.RootComponents.Add<DeletedListeners>("#app");
        }
    }
}
