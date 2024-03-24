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
    partial class FormFinished : System.Windows.Forms.Form
    {

        //Form overrides dispose to clean up the component list.
        [System.Diagnostics.DebuggerNonUserCode()]
        protected override void Dispose(bool disposing)
        {
            try
            {
                if (disposing && components != null)
                {
                    components.Dispose();
                }
            }
            finally
            {
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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFinished));
            Label1 = new Label();
            Label2 = new Label();
            Label3 = new Label();
            Label4 = new Label();
            Label5 = new Label();
            Label6 = new Label();
            Label7 = new Label();
            Label8 = new Label();
            Label9 = new Label();
            lblStartTime = new Label();
            lblFinishTime = new Label();
            lblElapsedTime = new Label();
            lblScannedIn = new Label();
            lblScannedOut = new Label();
            tmrQuit = new Timer(components);
            SuspendLayout();
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 72F, FontStyle.Regular, GraphicsUnit.Point);
            Label1.ForeColor = SystemColors.Highlight;
            Label1.Location = new Point(295, 10);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(391, 108);
            Label1.TabIndex = 0;
            Label1.Text = "TNBase";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Regular, GraphicsUnit.Point);
            Label2.ForeColor = Color.FromArgb(0, 192, 0);
            Label2.Location = new Point(279, 145);
            Label2.Margin = new Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(439, 55);
            Label2.TabIndex = 1;
            Label2.Text = "Programme Closed";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            Label3.Location = new Point(372, 265);
            Label3.Margin = new Padding(4, 0, 4, 0);
            Label3.Name = "Label3";
            Label3.Size = new Size(147, 31);
            Label3.TabIndex = 2;
            Label3.Text = "Start Time:";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            Label4.Location = new Point(382, 312);
            Label4.Margin = new Padding(4, 0, 4, 0);
            Label4.Name = "Label4";
            Label4.Size = new Size(137, 31);
            Label4.TabIndex = 3;
            Label4.Text = "End Time:";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            Label5.Location = new Point(332, 359);
            Label5.Margin = new Padding(4, 0, 4, 0);
            Label5.Name = "Label5";
            Label5.Size = new Size(187, 31);
            Label5.TabIndex = 4;
            Label5.Text = "Elapsed Time:";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            Label6.Location = new Point(188, 406);
            Label6.Margin = new Padding(4, 0, 4, 0);
            Label6.Name = "Label6";
            Label6.Size = new Size(331, 31);
            Label6.TabIndex = 5;
            Label6.Text = "News Wallets Scanned In:";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            Label7.Location = new Point(218, 453);
            Label7.Margin = new Padding(4, 0, 4, 0);
            Label7.Name = "Label7";
            Label7.Size = new Size(301, 31);
            Label7.TabIndex = 6;
            Label7.Text = "News Wallets Sent Out:";
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Microsoft Sans Serif", 36F, FontStyle.Regular, GraphicsUnit.Point);
            Label8.ForeColor = Color.FromArgb(255, 128, 0);
            Label8.Location = new Point(233, 537);
            Label8.Margin = new Padding(4, 0, 4, 0);
            Label8.Name = "Label8";
            Label8.Size = new Size(518, 55);
            Label8.TabIndex = 7;
            Label8.Text = "Have a good weekend!";
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Font = new Font("Microsoft Sans Serif", 15.75F, FontStyle.Regular, GraphicsUnit.Point);
            Label9.Location = new Point(334, 614);
            Label9.Margin = new Padding(4, 0, 4, 0);
            Label9.Name = "Label9";
            Label9.Size = new Size(389, 25);
            Label9.TabIndex = 8;
            Label9.Text = "Note: This form will close automatically.";
            // 
            // lblStartTime
            // 
            lblStartTime.AutoSize = true;
            lblStartTime.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblStartTime.Location = new Point(573, 265);
            lblStartTime.Margin = new Padding(4, 0, 4, 0);
            lblStartTime.Name = "lblStartTime";
            lblStartTime.Size = new Size(29, 31);
            lblStartTime.TabIndex = 9;
            lblStartTime.Text = "?";
            // 
            // lblFinishTime
            // 
            lblFinishTime.AutoSize = true;
            lblFinishTime.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblFinishTime.Location = new Point(573, 312);
            lblFinishTime.Margin = new Padding(4, 0, 4, 0);
            lblFinishTime.Name = "lblFinishTime";
            lblFinishTime.Size = new Size(29, 31);
            lblFinishTime.TabIndex = 10;
            lblFinishTime.Text = "?";
            // 
            // lblElapsedTime
            // 
            lblElapsedTime.AutoSize = true;
            lblElapsedTime.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblElapsedTime.Location = new Point(573, 359);
            lblElapsedTime.Margin = new Padding(4, 0, 4, 0);
            lblElapsedTime.Name = "lblElapsedTime";
            lblElapsedTime.Size = new Size(29, 31);
            lblElapsedTime.TabIndex = 11;
            lblElapsedTime.Text = "?";
            // 
            // lblScannedIn
            // 
            lblScannedIn.AutoSize = true;
            lblScannedIn.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblScannedIn.Location = new Point(573, 406);
            lblScannedIn.Margin = new Padding(4, 0, 4, 0);
            lblScannedIn.Name = "lblScannedIn";
            lblScannedIn.Size = new Size(29, 31);
            lblScannedIn.TabIndex = 12;
            lblScannedIn.Text = "?";
            // 
            // lblScannedOut
            // 
            lblScannedOut.AutoSize = true;
            lblScannedOut.Font = new Font("Microsoft Sans Serif", 20.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblScannedOut.Location = new Point(573, 453);
            lblScannedOut.Margin = new Padding(4, 0, 4, 0);
            lblScannedOut.Name = "lblScannedOut";
            lblScannedOut.Size = new Size(29, 31);
            lblScannedOut.TabIndex = 13;
            lblScannedOut.Text = "?";
            // 
            // tmrQuit
            // 
            tmrQuit.Enabled = true;
            tmrQuit.Interval = 8000;
            tmrQuit.Tick += tmrQuit_Tick;
            // 
            // FormFinished
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1065, 691);
            Controls.Add(lblScannedOut);
            Controls.Add(lblScannedIn);
            Controls.Add(lblElapsedTime);
            Controls.Add(lblFinishTime);
            Controls.Add(lblStartTime);
            Controls.Add(Label9);
            Controls.Add(Label8);
            Controls.Add(Label7);
            Controls.Add(Label6);
            Controls.Add(Label5);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(Label2);
            Controls.Add(Label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormFinished";
            RightToLeftLayout = true;
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label Label1;
        internal Label Label2;
        internal Label Label3;
        internal Label Label4;
        internal Label Label5;
        internal Label Label6;
        internal Label Label7;
        internal Label Label8;
        internal Label Label9;
        internal Label lblStartTime;
        internal Label lblFinishTime;
        internal Label lblElapsedTime;
        internal Label lblScannedIn;
        internal Label lblScannedOut;
        private Timer tmrQuit;
    }
}
