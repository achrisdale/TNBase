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
            tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            btnFinished = new System.Windows.Forms.Button();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // blazor
            // 
            blazor.Dock = System.Windows.Forms.DockStyle.Fill;
            blazor.Location = new System.Drawing.Point(3, 3);
            blazor.Name = "blazor";
            blazor.Size = new System.Drawing.Size(860, 650);
            blazor.TabIndex = 0;
            blazor.Text = "blazorWebView1";
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = System.Drawing.Color.WhiteSmoke;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel1.Controls.Add(btnFinished, 0, 1);
            tableLayoutPanel1.Controls.Add(blazor, 0, 0);
            tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 89.13043F));
            tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 10.869565F));
            tableLayoutPanel1.Size = new System.Drawing.Size(866, 736);
            tableLayoutPanel1.TabIndex = 1;
            // 
            // btnFinished
            // 
            btnFinished.BackColor = System.Drawing.Color.FromArgb(128, 255, 128);
            btnFinished.DialogResult = System.Windows.Forms.DialogResult.OK;
            btnFinished.Dock = System.Windows.Forms.DockStyle.Right;
            btnFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            btnFinished.ForeColor = System.Drawing.Color.Black;
            btnFinished.Location = new System.Drawing.Point(632, 666);
            btnFinished.Margin = new System.Windows.Forms.Padding(10);
            btnFinished.Name = "btnFinished";
            btnFinished.Size = new System.Drawing.Size(224, 60);
            btnFinished.TabIndex = 20;
            btnFinished.Text = "Finished";
            btnFinished.UseVisualStyleBackColor = false;
            // 
            // FormBlazorWebView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(866, 736);
            Controls.Add(tableLayoutPanel1);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Name = "FormBlazorWebView";
            Text = "TNBase";
            tableLayoutPanel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Microsoft.AspNetCore.Components.WebView.WindowsForms.BlazorWebView blazor;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button btnFinished;
    }
}