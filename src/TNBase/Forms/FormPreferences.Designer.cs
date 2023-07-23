namespace TNBase.Forms
{
    partial class FormPreferences
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
            this.ApplicationTitleLabel = new System.Windows.Forms.Label();
            this.ApplicationTitleTextBox = new System.Windows.Forms.TextBox();
            this.CancelButton = new System.Windows.Forms.Button();
            this.OKButton = new System.Windows.Forms.Button();
            this.LogoFileNameTextBox = new System.Windows.Forms.TextBox();
            this.LogoFileNameLabel = new System.Windows.Forms.Label();
            this.SelectLogoButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ApplicationTitleLabel
            // 
            this.ApplicationTitleLabel.AutoSize = true;
            this.ApplicationTitleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ApplicationTitleLabel.Location = new System.Drawing.Point(12, 15);
            this.ApplicationTitleLabel.Name = "ApplicationTitleLabel";
            this.ApplicationTitleLabel.Size = new System.Drawing.Size(148, 24);
            this.ApplicationTitleLabel.TabIndex = 0;
            this.ApplicationTitleLabel.Text = "Application Title:";
            // 
            // ApplicationTitleTextBox
            // 
            this.ApplicationTitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ApplicationTitleTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.ApplicationTitleTextBox.Location = new System.Drawing.Point(183, 12);
            this.ApplicationTitleTextBox.MaxLength = 50;
            this.ApplicationTitleTextBox.Name = "ApplicationTitleTextBox";
            this.ApplicationTitleTextBox.Size = new System.Drawing.Size(592, 29);
            this.ApplicationTitleTextBox.TabIndex = 1;
            // 
            // CancelButton
            // 
            this.CancelButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.CancelButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.CancelButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.CancelButton.Location = new System.Drawing.Point(411, 93);
            this.CancelButton.Name = "CancelButton";
            this.CancelButton.Size = new System.Drawing.Size(131, 37);
            this.CancelButton.TabIndex = 6;
            this.CancelButton.Text = "Cancel";
            this.CancelButton.UseVisualStyleBackColor = false;
            // 
            // OKButton
            // 
            this.OKButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.OKButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.OKButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.OKButton.Location = new System.Drawing.Point(245, 93);
            this.OKButton.Name = "OKButton";
            this.OKButton.Size = new System.Drawing.Size(131, 37);
            this.OKButton.TabIndex = 5;
            this.OKButton.Text = "Save";
            this.OKButton.UseVisualStyleBackColor = false;
            this.OKButton.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // LogoFileNameTextBox
            // 
            this.LogoFileNameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LogoFileNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LogoFileNameTextBox.Location = new System.Drawing.Point(183, 47);
            this.LogoFileNameTextBox.MaxLength = 50;
            this.LogoFileNameTextBox.Name = "LogoFileNameTextBox";
            this.LogoFileNameTextBox.ReadOnly = true;
            this.LogoFileNameTextBox.Size = new System.Drawing.Size(455, 29);
            this.LogoFileNameTextBox.TabIndex = 3;
            // 
            // LogoFileNameLabel
            // 
            this.LogoFileNameLabel.AutoSize = true;
            this.LogoFileNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.LogoFileNameLabel.Location = new System.Drawing.Point(12, 50);
            this.LogoFileNameLabel.Name = "LogoFileNameLabel";
            this.LogoFileNameLabel.Size = new System.Drawing.Size(58, 24);
            this.LogoFileNameLabel.TabIndex = 2;
            this.LogoFileNameLabel.Text = "Logo:";
            // 
            // SelectLogoButton
            // 
            this.SelectLogoButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.SelectLogoButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.SelectLogoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.SelectLogoButton.Location = new System.Drawing.Point(644, 47);
            this.SelectLogoButton.Name = "SelectLogoButton";
            this.SelectLogoButton.Size = new System.Drawing.Size(131, 29);
            this.SelectLogoButton.TabIndex = 4;
            this.SelectLogoButton.Text = "Select";
            this.SelectLogoButton.UseVisualStyleBackColor = false;
            this.SelectLogoButton.Click += new System.EventHandler(this.btnSelectLogo_Click);
            // 
            // FormPreferences
            // 
            this.AcceptButton = this.OKButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.CancelButton;
            this.ClientSize = new System.Drawing.Size(787, 143);
            this.Controls.Add(this.SelectLogoButton);
            this.Controls.Add(this.LogoFileNameTextBox);
            this.Controls.Add(this.LogoFileNameLabel);
            this.Controls.Add(this.CancelButton);
            this.Controls.Add(this.OKButton);
            this.Controls.Add(this.ApplicationTitleTextBox);
            this.Controls.Add(this.ApplicationTitleLabel);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormPreferences";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Preferences";
            this.Load += new System.EventHandler(this.FormPreferences_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label ApplicationTitleLabel;
        private System.Windows.Forms.TextBox ApplicationTitleTextBox;
        private System.Windows.Forms.Button CancelButton;
        private System.Windows.Forms.Button OKButton;
        private System.Windows.Forms.TextBox LogoFileNameTextBox;
        private System.Windows.Forms.Label LogoFileNameLabel;
        private System.Windows.Forms.Button SelectLogoButton;
    }
}