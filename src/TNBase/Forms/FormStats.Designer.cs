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
	partial class FormStats : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormStats));
            Label1 = new Label();
            Label2 = new Label();
            lblDate = new Label();
            Label3 = new Label();
            Label4 = new Label();
            Label5 = new Label();
            Label6 = new Label();
            Label7 = new Label();
            Label8 = new Label();
            Label9 = new Label();
            Label10 = new Label();
            Label11 = new Label();
            Label13 = new Label();
            Label14 = new Label();
            Label15 = new Label();
            Label16 = new Label();
            btnFinished = new Button();
            btnPrint = new Button();
            lblWeeklyYearListeners = new Label();
            lblListenersToday = new Label();
            lblNewListeners = new Label();
            lblLostListeners = new Label();
            lblNetListeners = new Label();
            lblAverageListeners = new Label();
            lblInactiveWallets = new Label();
            lblAverageDispatched = new Label();
            lblWalletsDispatched = new Label();
            lblMemorySticksOnLoad = new Label();
            lblStoppedWallets = new Label();
            lblAverageStopped = new Label();
            lblDormant = new Label();
            printStatsDoc = new System.Drawing.Printing.PrintDocument();
            printPreview = new PrintPreviewDialogSelectPrinter();
            label12 = new Label();
            SuspendLayout();
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 24F);
            Label1.Location = new Point(296, 10);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(291, 37);
            Label1.TabIndex = 0;
            Label1.Text = "Database Statistics";
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 15.75F);
            Label2.ForeColor = Color.FromArgb(128, 64, 0);
            Label2.Location = new Point(206, 46);
            Label2.Margin = new Padding(4, 0, 4, 0);
            Label2.Name = "Label2";
            Label2.Size = new Size(381, 25);
            Label2.TabIndex = 1;
            Label2.Text = "This Year's Database Statistics Up To ";
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Microsoft Sans Serif", 15.75F);
            lblDate.ForeColor = Color.FromArgb(128, 64, 0);
            lblDate.Location = new Point(643, 46);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(120, 25);
            lblDate.TabIndex = 2;
            lblDate.Text = "??/??/????";
            // 
            // Label3
            // 
            Label3.AutoSize = true;
            Label3.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label3.Location = new Point(55, 152);
            Label3.Margin = new Padding(4, 0, 4, 0);
            Label3.Name = "Label3";
            Label3.Size = new Size(462, 33);
            Label3.TabIndex = 3;
            Label3.Text = "Current number of active listeners:";
            // 
            // Label4
            // 
            Label4.AutoSize = true;
            Label4.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label4.Location = new Point(55, 113);
            Label4.Margin = new Padding(4, 0, 4, 0);
            Label4.Name = "Label4";
            Label4.Size = new Size(527, 33);
            Label4.TabIndex = 4;
            Label4.Text = "Weekly listeners at the start of the year:";
            // 
            // Label5
            // 
            Label5.AutoSize = true;
            Label5.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label5.Location = new Point(55, 190);
            Label5.Margin = new Padding(4, 0, 4, 0);
            Label5.Name = "Label5";
            Label5.Size = new Size(457, 33);
            Label5.TabIndex = 5;
            Label5.Text = "Number of new listeners this year:";
            // 
            // Label6
            // 
            Label6.AutoSize = true;
            Label6.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label6.Location = new Point(55, 228);
            Label6.Margin = new Padding(4, 0, 4, 0);
            Label6.Name = "Label6";
            Label6.Size = new Size(450, 33);
            Label6.TabIndex = 6;
            Label6.Text = "Number of lost listeners this year:";
            // 
            // Label7
            // 
            Label7.AutoSize = true;
            Label7.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label7.Location = new Point(55, 266);
            Label7.Margin = new Padding(4, 0, 4, 0);
            Label7.Name = "Label7";
            Label7.Size = new Size(476, 33);
            Label7.TabIndex = 7;
            Label7.Text = "Net change of listeners for the year:";
            // 
            // Label8
            // 
            Label8.AutoSize = true;
            Label8.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label8.Location = new Point(55, 304);
            Label8.Margin = new Padding(4, 0, 4, 0);
            Label8.Name = "Label8";
            Label8.Size = new Size(620, 33);
            Label8.TabIndex = 8;
            Label8.Text = "Average number of active listeners for the year";
            // 
            // Label9
            // 
            Label9.AutoSize = true;
            Label9.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label9.Location = new Point(55, 342);
            Label9.Margin = new Padding(4, 0, 4, 0);
            Label9.Name = "Label9";
            Label9.Size = new Size(511, 33);
            Label9.TabIndex = 9;
            Label9.Text = "Inactive wallets (not available for use):";
            // 
            // Label10
            // 
            Label10.AutoSize = true;
            Label10.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label10.Location = new Point(55, 380);
            Label10.Margin = new Padding(4, 0, 4, 0);
            Label10.Name = "Label10";
            Label10.Size = new Size(664, 33);
            Label10.TabIndex = 10;
            Label10.Text = "Average number of wallets dispatched each week:";
            // 
            // Label11
            // 
            Label11.AutoSize = true;
            Label11.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label11.Location = new Point(55, 418);
            Label11.Margin = new Padding(4, 0, 4, 0);
            Label11.Name = "Label11";
            Label11.Size = new Size(468, 33);
            Label11.TabIndex = 11;
            Label11.Text = "News Wallets dispatched this year:";
            // 
            // Label13
            // 
            Label13.AutoSize = true;
            Label13.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label13.Location = new Point(55, 456);
            Label13.Margin = new Padding(4, 0, 4, 0);
            Label13.Name = "Label13";
            Label13.Size = new Size(411, 33);
            Label13.TabIndex = 13;
            Label13.Text = "Memory stick players on loan: ";
            // 
            // Label14
            // 
            Label14.AutoSize = true;
            Label14.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label14.Location = new Point(55, 494);
            Label14.Margin = new Padding(4, 0, 4, 0);
            Label14.Name = "Label14";
            Label14.Size = new Size(228, 33);
            Label14.TabIndex = 14;
            Label14.Text = "Stopped wallets:";
            // 
            // Label15
            // 
            Label15.AutoSize = true;
            Label15.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label15.Location = new Point(55, 532);
            Label15.Margin = new Padding(4, 0, 4, 0);
            Label15.Name = "Label15";
            Label15.Size = new Size(681, 33);
            Label15.TabIndex = 15;
            Label15.Text = "Average number of stopped wallets during the year:";
            // 
            // Label16
            // 
            Label16.AutoSize = true;
            Label16.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label16.Location = new Point(56, 573);
            Label16.Margin = new Padding(4, 0, 4, 0);
            Label16.Name = "Label16";
            Label16.Size = new Size(492, 33);
            Label16.TabIndex = 16;
            Label16.Text = "Listeners dormant for over 3 months:";
            // 
            // btnFinished
            // 
            btnFinished.BackColor = Color.FromArgb(128, 255, 128);
            btnFinished.Font = new Font("Microsoft Sans Serif", 21.75F);
            btnFinished.ForeColor = Color.Black;
            btnFinished.Location = new Point(170, 642);
            btnFinished.Margin = new Padding(4, 3, 4, 3);
            btnFinished.Name = "btnFinished";
            btnFinished.Size = new Size(224, 74);
            btnFinished.TabIndex = 19;
            btnFinished.Text = "Finished";
            btnFinished.UseVisualStyleBackColor = false;
            btnFinished.Click += btnFinished_Click;
            // 
            // btnPrint
            // 
            btnPrint.BackColor = Color.FromArgb(255, 192, 128);
            btnPrint.Font = new Font("Microsoft Sans Serif", 21.75F);
            btnPrint.Location = new Point(625, 642);
            btnPrint.Margin = new Padding(4, 3, 4, 3);
            btnPrint.Name = "btnPrint";
            btnPrint.Size = new Size(224, 74);
            btnPrint.TabIndex = 20;
            btnPrint.Text = "Print";
            btnPrint.UseVisualStyleBackColor = false;
            btnPrint.Click += btnPrint_Click;
            // 
            // lblWeeklyYearListeners
            // 
            lblWeeklyYearListeners.AutoSize = true;
            lblWeeklyYearListeners.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblWeeklyYearListeners.Location = new Point(870, 113);
            lblWeeklyYearListeners.Margin = new Padding(4, 0, 4, 0);
            lblWeeklyYearListeners.Name = "lblWeeklyYearListeners";
            lblWeeklyYearListeners.Size = new Size(31, 33);
            lblWeeklyYearListeners.TabIndex = 21;
            lblWeeklyYearListeners.Text = "?";
            // 
            // lblListenersToday
            // 
            lblListenersToday.AutoSize = true;
            lblListenersToday.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblListenersToday.Location = new Point(870, 152);
            lblListenersToday.Margin = new Padding(4, 0, 4, 0);
            lblListenersToday.Name = "lblListenersToday";
            lblListenersToday.Size = new Size(31, 33);
            lblListenersToday.TabIndex = 22;
            lblListenersToday.Text = "?";
            // 
            // lblNewListeners
            // 
            lblNewListeners.AutoSize = true;
            lblNewListeners.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblNewListeners.Location = new Point(870, 190);
            lblNewListeners.Margin = new Padding(4, 0, 4, 0);
            lblNewListeners.Name = "lblNewListeners";
            lblNewListeners.Size = new Size(31, 33);
            lblNewListeners.TabIndex = 23;
            lblNewListeners.Text = "?";
            // 
            // lblLostListeners
            // 
            lblLostListeners.AutoSize = true;
            lblLostListeners.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblLostListeners.Location = new Point(870, 228);
            lblLostListeners.Margin = new Padding(4, 0, 4, 0);
            lblLostListeners.Name = "lblLostListeners";
            lblLostListeners.Size = new Size(31, 33);
            lblLostListeners.TabIndex = 24;
            lblLostListeners.Text = "?";
            // 
            // lblNetListeners
            // 
            lblNetListeners.AutoSize = true;
            lblNetListeners.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblNetListeners.Location = new Point(870, 266);
            lblNetListeners.Margin = new Padding(4, 0, 4, 0);
            lblNetListeners.Name = "lblNetListeners";
            lblNetListeners.Size = new Size(31, 33);
            lblNetListeners.TabIndex = 25;
            lblNetListeners.Text = "?";
            // 
            // lblAverageListeners
            // 
            lblAverageListeners.AutoSize = true;
            lblAverageListeners.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblAverageListeners.Location = new Point(870, 304);
            lblAverageListeners.Margin = new Padding(4, 0, 4, 0);
            lblAverageListeners.Name = "lblAverageListeners";
            lblAverageListeners.Size = new Size(31, 33);
            lblAverageListeners.TabIndex = 26;
            lblAverageListeners.Text = "?";
            // 
            // lblInactiveWallets
            // 
            lblInactiveWallets.AutoSize = true;
            lblInactiveWallets.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblInactiveWallets.Location = new Point(870, 342);
            lblInactiveWallets.Margin = new Padding(4, 0, 4, 0);
            lblInactiveWallets.Name = "lblInactiveWallets";
            lblInactiveWallets.Size = new Size(31, 33);
            lblInactiveWallets.TabIndex = 27;
            lblInactiveWallets.Text = "?";
            // 
            // lblAverageDispatched
            // 
            lblAverageDispatched.AutoSize = true;
            lblAverageDispatched.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblAverageDispatched.Location = new Point(870, 380);
            lblAverageDispatched.Margin = new Padding(4, 0, 4, 0);
            lblAverageDispatched.Name = "lblAverageDispatched";
            lblAverageDispatched.Size = new Size(31, 33);
            lblAverageDispatched.TabIndex = 28;
            lblAverageDispatched.Text = "?";
            // 
            // lblWalletsDispatched
            // 
            lblWalletsDispatched.AutoSize = true;
            lblWalletsDispatched.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblWalletsDispatched.Location = new Point(870, 418);
            lblWalletsDispatched.Margin = new Padding(4, 0, 4, 0);
            lblWalletsDispatched.Name = "lblWalletsDispatched";
            lblWalletsDispatched.Size = new Size(31, 33);
            lblWalletsDispatched.TabIndex = 29;
            lblWalletsDispatched.Text = "?";
            // 
            // lblMemorySticksOnLoad
            // 
            lblMemorySticksOnLoad.AutoSize = true;
            lblMemorySticksOnLoad.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblMemorySticksOnLoad.Location = new Point(870, 456);
            lblMemorySticksOnLoad.Margin = new Padding(4, 0, 4, 0);
            lblMemorySticksOnLoad.Name = "lblMemorySticksOnLoad";
            lblMemorySticksOnLoad.Size = new Size(31, 33);
            lblMemorySticksOnLoad.TabIndex = 31;
            lblMemorySticksOnLoad.Text = "?";
            // 
            // lblStoppedWallets
            // 
            lblStoppedWallets.AutoSize = true;
            lblStoppedWallets.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblStoppedWallets.Location = new Point(870, 494);
            lblStoppedWallets.Margin = new Padding(4, 0, 4, 0);
            lblStoppedWallets.Name = "lblStoppedWallets";
            lblStoppedWallets.Size = new Size(31, 33);
            lblStoppedWallets.TabIndex = 32;
            lblStoppedWallets.Text = "?";
            // 
            // lblAverageStopped
            // 
            lblAverageStopped.AutoSize = true;
            lblAverageStopped.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblAverageStopped.Location = new Point(870, 532);
            lblAverageStopped.Margin = new Padding(4, 0, 4, 0);
            lblAverageStopped.Name = "lblAverageStopped";
            lblAverageStopped.Size = new Size(31, 33);
            lblAverageStopped.TabIndex = 33;
            lblAverageStopped.Text = "?";
            // 
            // lblDormant
            // 
            lblDormant.AutoSize = true;
            lblDormant.Font = new Font("Microsoft Sans Serif", 21.75F);
            lblDormant.Location = new Point(870, 570);
            lblDormant.Margin = new Padding(4, 0, 4, 0);
            lblDormant.Name = "lblDormant";
            lblDormant.Size = new Size(31, 33);
            lblDormant.TabIndex = 34;
            lblDormant.Text = "?";
            // 
            // printStatsDoc
            // 
            printStatsDoc.PrintPage += printStatsDoc_PrintPage;
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
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Microsoft Sans Serif", 15.75F);
            label12.ForeColor = Color.Gray;
            label12.Location = new Point(296, 75);
            label12.Margin = new Padding(4, 0, 4, 0);
            label12.Name = "label12";
            label12.Size = new Size(304, 25);
            label12.TabIndex = 35;
            label12.Text = "(includes online-only listeners)";
            // 
            // FormStats
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(993, 734);
            Controls.Add(label12);
            Controls.Add(lblDormant);
            Controls.Add(lblAverageStopped);
            Controls.Add(lblStoppedWallets);
            Controls.Add(lblMemorySticksOnLoad);
            Controls.Add(lblWalletsDispatched);
            Controls.Add(lblAverageDispatched);
            Controls.Add(lblInactiveWallets);
            Controls.Add(lblAverageListeners);
            Controls.Add(lblNetListeners);
            Controls.Add(lblLostListeners);
            Controls.Add(lblNewListeners);
            Controls.Add(lblListenersToday);
            Controls.Add(lblWeeklyYearListeners);
            Controls.Add(btnPrint);
            Controls.Add(btnFinished);
            Controls.Add(Label16);
            Controls.Add(Label15);
            Controls.Add(Label14);
            Controls.Add(Label13);
            Controls.Add(Label11);
            Controls.Add(Label10);
            Controls.Add(Label9);
            Controls.Add(Label8);
            Controls.Add(Label7);
            Controls.Add(Label6);
            Controls.Add(Label5);
            Controls.Add(Label4);
            Controls.Add(Label3);
            Controls.Add(lblDate);
            Controls.Add(Label2);
            Controls.Add(Label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormStats";
            StartPosition = FormStartPosition.CenterScreen;
            ResumeLayout(false);
            PerformLayout();
        }

        internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.Label lblDate;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.Label Label9;
		internal System.Windows.Forms.Label Label10;
		internal System.Windows.Forms.Label Label11;
		internal System.Windows.Forms.Label Label13;
		internal System.Windows.Forms.Label Label14;
		internal System.Windows.Forms.Label Label15;
		internal System.Windows.Forms.Label Label16;
        private System.Windows.Forms.Button btnFinished;
        private System.Windows.Forms.Button btnPrint;
		internal System.Windows.Forms.Label lblWeeklyYearListeners;
		internal System.Windows.Forms.Label lblListenersToday;
		internal System.Windows.Forms.Label lblNewListeners;
		internal System.Windows.Forms.Label lblLostListeners;
		internal System.Windows.Forms.Label lblNetListeners;
		internal System.Windows.Forms.Label lblAverageListeners;
		internal System.Windows.Forms.Label lblInactiveWallets;
		internal System.Windows.Forms.Label lblAverageDispatched;
		internal System.Windows.Forms.Label lblWalletsDispatched;
		internal System.Windows.Forms.Label lblMemorySticksOnLoad;
		internal System.Windows.Forms.Label lblStoppedWallets;
		internal System.Windows.Forms.Label lblAverageStopped;
        internal System.Windows.Forms.Label lblDormant;
        private System.Drawing.Printing.PrintDocument printStatsDoc;
        internal TNBase.PrintPreviewDialogSelectPrinter printPreview;
        internal Label label12;
    }
}
