namespace TNBase.Forms
{
    partial class FormDataImport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDataImport));
            this.ImportListenersButton = new System.Windows.Forms.Button();
            this.DownloadListenersTemplateLink = new System.Windows.Forms.LinkLabel();
            this.SuspendLayout();
            // 
            // ImportListenersButton
            // 
            this.ImportListenersButton.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ImportListenersButton.Location = new System.Drawing.Point(460, 50);
            this.ImportListenersButton.Name = "ImportListenersButton";
            this.ImportListenersButton.Size = new System.Drawing.Size(300, 79);
            this.ImportListenersButton.TabIndex = 0;
            this.ImportListenersButton.Text = "Import Listeners";
            this.ImportListenersButton.UseVisualStyleBackColor = true;
            this.ImportListenersButton.Click += new System.EventHandler(this.ImportListenersButton_Click);
            // 
            // DownloadListenersTemplateLink
            // 
            this.DownloadListenersTemplateLink.AutoSize = true;
            this.DownloadListenersTemplateLink.Location = new System.Drawing.Point(44, 77);
            this.DownloadListenersTemplateLink.Name = "DownloadListenersTemplateLink";
            this.DownloadListenersTemplateLink.Size = new System.Drawing.Size(326, 32);
            this.DownloadListenersTemplateLink.TabIndex = 1;
            this.DownloadListenersTemplateLink.TabStop = true;
            this.DownloadListenersTemplateLink.Text = "Get listeners import template";
            this.DownloadListenersTemplateLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.DownloadListenersTemplateLink_LinkClicked);
            // 
            // FormDataImport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 193);
            this.Controls.Add(this.DownloadListenersTemplateLink);
            this.Controls.Add(this.ImportListenersButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDataImport";
            this.Text = "Data Import";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ImportListenersButton;
        private System.Windows.Forms.LinkLabel DownloadListenersTemplateLink;
    }
}