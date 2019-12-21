using System;
using System.Windows.Forms;

namespace TNBase.Forms
{
    public partial class FormInput : Form
    {
        public FormInput()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, EventArgs e)
        {

        }

        private void cancelButton_Click(object sender, EventArgs e)
        {

        }

        public string ShowDialog(string prompt, string title = "", string defaultResponse = "")
        {
            Text = title;
            promptLabel.Text = prompt;
            responseTextBox.Text = defaultResponse;

            var result = ShowDialog();
            if (result == DialogResult.OK)
            {
                return responseTextBox.Text;
            }
            else
            {
                return "";
            }
        }
    }
}
