using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;
using System.Linq;
using System.Xml.Linq;
namespace TNBase
{
	[Microsoft.VisualBasic.CompilerServices.DesignerGenerated()]
	partial class FormPrintLabels : System.Windows.Forms.Form
	{

		//Form overrides dispose to clean up the component list.
		[System.Diagnostics.DebuggerNonUserCode()]
		protected override void Dispose(bool disposing)
		{
			try {
				if (disposing && components != null) {
					components.Dispose();
				}
			} finally {
				base.Dispose(disposing);
			}
		}

		//Required by the Windows Form Designer

		private System.ComponentModel.IContainer components;
        //NOTE: The following procedure is required by the Windows Form Designer
        //It can be modified using the Windows Form Designer.  
        //Do not modify it using the code editor.
        [System.Diagnostics.DebuggerStepThrough()]
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormPrintLabels));
            btnCancel = new Button();
            Label2 = new Label();
            printLabelDoc = new System.Drawing.Printing.PrintDocument();
            printPreview = new PrintPreviewDialogSelectPrinter();
            SuspendLayout();
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.Font = new Font("Microsoft Sans Serif", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnCancel.Location = new Point(196, 70);
            btnCancel.Margin = new Padding(4, 3, 4, 3);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(127, 46);
            btnCancel.TabIndex = 7;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Label2.Location = new Point(36, 25);
            Label2.Margin = new Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(214, 24);
            Label2.TabIndex = 6;
            Label2.Text = "Printing address labels...\r\n";
            // 
            // printLabelDoc
            // 
            printLabelDoc.PrintPage += printLabelDoc_PrintPage;
            // 
            // printPreview
            // 
            printPreview.AutoScrollMargin = new Size(0, 0);
            printPreview.AutoScrollMinSize = new Size(0, 0);
            printPreview.ClientSize = new Size(400, 300);
            printPreview.Enabled = true;
            printPreview.Icon = (Icon)resources.GetObject("printPreview.Icon");
            printPreview.Name = "PrintPreviewDialogSelectPrinter1";
            printPreview.Visible = false;
            // 
            // FormPrintLabels
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(507, 144);
            Controls.Add(btnCancel);
            Controls.Add(Label2);
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormPrintLabels";
            StartPosition = FormStartPosition.CenterScreen;
            Load += FormPrintLabels_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button btnCancel;
		internal System.Windows.Forms.Label Label2;
        private System.Drawing.Printing.PrintDocument printLabelDoc;
		internal TNBase.PrintPreviewDialogSelectPrinter printPreview;
	}
}
