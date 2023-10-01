namespace TNBase.Forms
{
    partial class FormBlazorWebView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormBlazorWebView));
            blazor = new Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView();
            SuspendLayout();
            // 
            // blazor
            // 
            blazor.Dock = System.Windows.Forms.DockStyle.Fill;
            blazor.Location = new System.Drawing.Point(0, 0);
            blazor.Name = "blazor";
            blazor.Size = new System.Drawing.Size(800, 450);
            blazor.TabIndex = 0;
            blazor.Text = "blazorWebView1";
            // 
            // FormBlazorWebView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 450);
            Controls.Add(blazor);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormBlazorWebView";
            Text = "TNBase";
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView blazor;
    }
}