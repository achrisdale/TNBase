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
    partial class FormMain : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            Label1 = new Label();
            menuTop = new MenuStrip();
            mBtnListeners = new ToolStripMenuItem();
            AddToolStripMenuItem = new ToolStripMenuItem();
            DeleteToolStripMenuItem = new ToolStripMenuItem();
            EditToolStripMenuItem = new ToolStripMenuItem();
            StopSendingToolStripMenuItem = new ToolStripMenuItem();
            CancelAStopToolStripMenuItem = new ToolStripMenuItem();
            BrowseToolStripMenuItem = new ToolStripMenuItem();
            MaintenenceToolStripMenuItem = new ToolStripMenuItem();
            BackupToolStripMenuItem = new ToolStripMenuItem();
            RestoreToolStripMenuItem = new ToolStripMenuItem();
            PrintAllListenerLabelsToolStripMenuItem = new ToolStripMenuItem();
            logViewToolStripMenuItem = new ToolStripMenuItem();
            openLogDirectoryToolStripMenuItem = new ToolStripMenuItem();
            adjustStockLevelsToolStripMenuItem = new ToolStripMenuItem();
            dataImportToolStripMenuItem = new ToolStripMenuItem();
            dataExportToolStripMenuItem = new ToolStripMenuItem();
            updateDatabaseEncryptionKeyToolStripMenuItem = new ToolStripMenuItem();
            PrintingToolStripMenuItem = new ToolStripMenuItem();
            UpcomingBirthdaysToolStripMenuItem = new ToolStripMenuItem();
            RecentlyAddedListenersToolStripMenuItem = new ToolStripMenuItem();
            PrintAddressLabelsToolStripMenuItem = new ToolStripMenuItem();
            ListenersInactiveFor30DaysToolStripMenuItem = new ToolStripMenuItem();
            GPOSackLabelsToolStripMenuItem = new ToolStripMenuItem();
            StoppedListenersThisWeekToolStripMenuItem = new ToolStripMenuItem();
            WalletsNotSentOutToolStripMenuItem = new ToolStripMenuItem();
            UnreturnedSpeakersToolStripMenuItem = new ToolStripMenuItem();
            PrintAlphabeticSurnameListToolStripMenuItem = new ToolStripMenuItem();
            printCollectorForListenerToolStripMenuItem = new ToolStripMenuItem();
            magazineWalletsToolStripMenuItem = new ToolStripMenuItem();
            walletsStockToolStripMenuItem = new ToolStripMenuItem();
            magazineWalletStockToolStripMenuItem = new ToolStripMenuItem();
            onlineonlyListenersToolStripMenuItem = new ToolStripMenuItem();
            StatisticsHistoryToolStripMenuItem = new ToolStripMenuItem();
            StatisticsToolStripMenuItem = new ToolStripMenuItem();
            HistoryToolStripMenuItem = new ToolStripMenuItem();
            ScanningToolStripMenuItem = new ToolStripMenuItem();
            ScanInToolStripMenuItem = new ToolStripMenuItem();
            ScanOutToolStripMenuItem = new ToolStripMenuItem();
            CollectorsToolStripMenuItem = new ToolStripMenuItem();
            AddCollectorsToolStripMenuItem = new ToolStripMenuItem();
            BrowseToolStripMenuItem1 = new ToolStripMenuItem();
            helpToolStripMenuItem = new ToolStripMenuItem();
            viewHelpToolStripMenuItem = new ToolStripMenuItem();
            aboutToolStripMenuItem1 = new ToolStripMenuItem();
            lblDate = new Label();
            lblTime = new Label();
            timerUpdate = new Timer(components);
            GroupBox1 = new GroupBox();
            btnPrintLabels = new Button();
            btnCancelStop = new Button();
            btnStopSending = new Button();
            btnBrowse = new Button();
            btnEdit = new Button();
            btnRemove = new Button();
            btnAdd = new Button();
            btnFinished = new Button();
            GroupBox2 = new GroupBox();
            btnScanOut = new Button();
            btnScanIn = new Button();
            StatusStrip1 = new StatusStrip();
            lblHints = new ToolStripStatusLabel();
            timerHints = new Timer(components);
            backupDialog = new SaveFileDialog();
            PictureBox1 = new PictureBox();
            restoreDialog = new OpenFileDialog();
            lblVersion = new Label();
            lblWeekNumber = new Label();
            groupBox3 = new GroupBox();
            btnMagScanOut = new Button();
            btnMagScanIn = new Button();
            helpProvider = new HelpProvider();
            menuTop.SuspendLayout();
            GroupBox1.SuspendLayout();
            GroupBox2.SuspendLayout();
            StatusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).BeginInit();
            groupBox3.SuspendLayout();
            SuspendLayout();
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            Label1.Location = new Point(145, 63);
            Label1.Margin = new Padding(4, 0, 4, 0);
            Label1.Name = "Label1";
            Label1.Size = new Size(0, 39);
            Label1.TabIndex = 0;
            // 
            // menuTop
            // 
            menuTop.Font = new Font("Segoe UI", 11.25F, FontStyle.Regular, GraphicsUnit.Point);
            menuTop.ImageScalingSize = new Size(32, 32);
            menuTop.Items.AddRange(new ToolStripItem[] { mBtnListeners, MaintenenceToolStripMenuItem, PrintingToolStripMenuItem, StatisticsHistoryToolStripMenuItem, ScanningToolStripMenuItem, CollectorsToolStripMenuItem, helpToolStripMenuItem });
            menuTop.Location = new Point(0, 0);
            menuTop.Name = "menuTop";
            menuTop.Padding = new Padding(13, 4, 0, 4);
            menuTop.Size = new Size(1168, 32);
            menuTop.TabIndex = 1;
            menuTop.Text = "MenuStrip1";
            // 
            // mBtnListeners
            // 
            mBtnListeners.DropDownItems.AddRange(new ToolStripItem[] { AddToolStripMenuItem, DeleteToolStripMenuItem, EditToolStripMenuItem, StopSendingToolStripMenuItem, CancelAStopToolStripMenuItem, BrowseToolStripMenuItem });
            mBtnListeners.Name = "mBtnListeners";
            mBtnListeners.ShortcutKeyDisplayString = "";
            mBtnListeners.ShortcutKeys = Keys.Alt | Keys.L;
            mBtnListeners.Size = new Size(78, 24);
            mBtnListeners.Text = "&Listeners";
            // 
            // AddToolStripMenuItem
            // 
            AddToolStripMenuItem.Name = "AddToolStripMenuItem";
            AddToolStripMenuItem.Size = new Size(169, 24);
            AddToolStripMenuItem.Text = "Add";
            AddToolStripMenuItem.Click += AddToolStripMenuItem_Click;
            // 
            // DeleteToolStripMenuItem
            // 
            DeleteToolStripMenuItem.Name = "DeleteToolStripMenuItem";
            DeleteToolStripMenuItem.Size = new Size(169, 24);
            DeleteToolStripMenuItem.Text = "Delete";
            DeleteToolStripMenuItem.Click += DeleteToolStripMenuItem_Click;
            // 
            // EditToolStripMenuItem
            // 
            EditToolStripMenuItem.Name = "EditToolStripMenuItem";
            EditToolStripMenuItem.Size = new Size(169, 24);
            EditToolStripMenuItem.Text = "Edit";
            EditToolStripMenuItem.Click += EditToolStripMenuItem_Click;
            // 
            // StopSendingToolStripMenuItem
            // 
            StopSendingToolStripMenuItem.Name = "StopSendingToolStripMenuItem";
            StopSendingToolStripMenuItem.Size = new Size(169, 24);
            StopSendingToolStripMenuItem.Text = "Stop Sending";
            StopSendingToolStripMenuItem.Click += StopSendingToolStripMenuItem_Click;
            // 
            // CancelAStopToolStripMenuItem
            // 
            CancelAStopToolStripMenuItem.Name = "CancelAStopToolStripMenuItem";
            CancelAStopToolStripMenuItem.Size = new Size(169, 24);
            CancelAStopToolStripMenuItem.Text = "Cancel a Stop";
            CancelAStopToolStripMenuItem.Click += CancelAStopToolStripMenuItem_Click;
            // 
            // BrowseToolStripMenuItem
            // 
            BrowseToolStripMenuItem.Name = "BrowseToolStripMenuItem";
            BrowseToolStripMenuItem.Size = new Size(169, 24);
            BrowseToolStripMenuItem.Text = "Browse";
            BrowseToolStripMenuItem.Click += BrowseToolStripMenuItem_Click;
            // 
            // MaintenenceToolStripMenuItem
            // 
            MaintenenceToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { BackupToolStripMenuItem, RestoreToolStripMenuItem, PrintAllListenerLabelsToolStripMenuItem, logViewToolStripMenuItem, openLogDirectoryToolStripMenuItem, adjustStockLevelsToolStripMenuItem, dataImportToolStripMenuItem, dataExportToolStripMenuItem, updateDatabaseEncryptionKeyToolStripMenuItem });
            MaintenenceToolStripMenuItem.Name = "MaintenenceToolStripMenuItem";
            MaintenenceToolStripMenuItem.Size = new Size(106, 24);
            MaintenenceToolStripMenuItem.Text = "&Maintenence";
            // 
            // BackupToolStripMenuItem
            // 
            BackupToolStripMenuItem.Name = "BackupToolStripMenuItem";
            BackupToolStripMenuItem.Size = new Size(231, 24);
            BackupToolStripMenuItem.Text = "Backup";
            BackupToolStripMenuItem.Click += BackupToolStripMenuItem_Click;
            // 
            // RestoreToolStripMenuItem
            // 
            RestoreToolStripMenuItem.Name = "RestoreToolStripMenuItem";
            RestoreToolStripMenuItem.Size = new Size(231, 24);
            RestoreToolStripMenuItem.Text = "Restore";
            RestoreToolStripMenuItem.Click += RestoreToolStripMenuItem_Click;
            // 
            // PrintAllListenerLabelsToolStripMenuItem
            // 
            PrintAllListenerLabelsToolStripMenuItem.Name = "PrintAllListenerLabelsToolStripMenuItem";
            PrintAllListenerLabelsToolStripMenuItem.Size = new Size(231, 24);
            PrintAllListenerLabelsToolStripMenuItem.Text = "Print All Listener Labels";
            PrintAllListenerLabelsToolStripMenuItem.Click += PrintAllListenerLabelsToolStripMenuItem_Click;
            // 
            // logViewToolStripMenuItem
            // 
            logViewToolStripMenuItem.Name = "logViewToolStripMenuItem";
            logViewToolStripMenuItem.Size = new Size(231, 24);
            logViewToolStripMenuItem.Text = "Log View";
            logViewToolStripMenuItem.Click += LogViewToolStripMenuItem_Click;
            // 
            // openLogDirectoryToolStripMenuItem
            // 
            openLogDirectoryToolStripMenuItem.Name = "openLogDirectoryToolStripMenuItem";
            openLogDirectoryToolStripMenuItem.Size = new Size(231, 24);
            openLogDirectoryToolStripMenuItem.Text = "Open Log Directory";
            openLogDirectoryToolStripMenuItem.Click += OpenLogDirectoryToolStripMenuItem_Click;
            // 
            // adjustStockLevelsToolStripMenuItem
            // 
            adjustStockLevelsToolStripMenuItem.Name = "adjustStockLevelsToolStripMenuItem";
            adjustStockLevelsToolStripMenuItem.Size = new Size(231, 24);
            adjustStockLevelsToolStripMenuItem.Text = "Adjust Stock Levels";
            adjustStockLevelsToolStripMenuItem.Click += AdjustStockLevelsToolStripMenuItem_Click;
            // 
            // dataImportToolStripMenuItem
            // 
            dataImportToolStripMenuItem.Name = "dataImportToolStripMenuItem";
            dataImportToolStripMenuItem.Size = new Size(231, 24);
            dataImportToolStripMenuItem.Text = "Data Import";
            dataImportToolStripMenuItem.Click += dataImportToolStripMenuItem_Click;
            // 
            // dataExportToolStripMenuItem
            // 
            dataExportToolStripMenuItem.Name = "dataExportToolStripMenuItem";
            dataExportToolStripMenuItem.Size = new Size(231, 24);
            dataExportToolStripMenuItem.Text = "Data Export";
            dataExportToolStripMenuItem.Click += dataExportToolStripMenuItem_Click;
            // 
            // updateDatabaseEncryptionKeyToolStripMenuItem
            // 
            updateDatabaseEncryptionKeyToolStripMenuItem.Name = "updateDatabaseEncryptionKeyToolStripMenuItem";
            updateDatabaseEncryptionKeyToolStripMenuItem.Size = new Size(231, 24);
            updateDatabaseEncryptionKeyToolStripMenuItem.Text = "Database Encryption";
            updateDatabaseEncryptionKeyToolStripMenuItem.Click += updateDatabaseEncryptionKeyToolStripMenuItem_Click;
            // 
            // PrintingToolStripMenuItem
            // 
            PrintingToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { UpcomingBirthdaysToolStripMenuItem, RecentlyAddedListenersToolStripMenuItem, PrintAddressLabelsToolStripMenuItem, ListenersInactiveFor30DaysToolStripMenuItem, GPOSackLabelsToolStripMenuItem, StoppedListenersThisWeekToolStripMenuItem, WalletsNotSentOutToolStripMenuItem, UnreturnedSpeakersToolStripMenuItem, PrintAlphabeticSurnameListToolStripMenuItem, printCollectorForListenerToolStripMenuItem, magazineWalletsToolStripMenuItem, walletsStockToolStripMenuItem, magazineWalletStockToolStripMenuItem, onlineonlyListenersToolStripMenuItem });
            PrintingToolStripMenuItem.Name = "PrintingToolStripMenuItem";
            PrintingToolStripMenuItem.Size = new Size(72, 24);
            PrintingToolStripMenuItem.Text = "Prin&ting";
            // 
            // UpcomingBirthdaysToolStripMenuItem
            // 
            UpcomingBirthdaysToolStripMenuItem.Name = "UpcomingBirthdaysToolStripMenuItem";
            UpcomingBirthdaysToolStripMenuItem.Size = new Size(296, 24);
            UpcomingBirthdaysToolStripMenuItem.Text = "Upcoming Birthdays";
            UpcomingBirthdaysToolStripMenuItem.Click += UpcomingBirthdaysToolStripMenuItem_Click;
            // 
            // RecentlyAddedListenersToolStripMenuItem
            // 
            RecentlyAddedListenersToolStripMenuItem.Name = "RecentlyAddedListenersToolStripMenuItem";
            RecentlyAddedListenersToolStripMenuItem.Size = new Size(296, 24);
            RecentlyAddedListenersToolStripMenuItem.Text = "Recently Added Listeners";
            RecentlyAddedListenersToolStripMenuItem.Click += RecentlyAddedListenersToolStripMenuItem_Click;
            // 
            // PrintAddressLabelsToolStripMenuItem
            // 
            PrintAddressLabelsToolStripMenuItem.Name = "PrintAddressLabelsToolStripMenuItem";
            PrintAddressLabelsToolStripMenuItem.Size = new Size(296, 24);
            PrintAddressLabelsToolStripMenuItem.Text = "Print Address Labels";
            PrintAddressLabelsToolStripMenuItem.Click += PrintAddressLabelsToolStripMenuItem_Click;
            // 
            // ListenersInactiveFor30DaysToolStripMenuItem
            // 
            ListenersInactiveFor30DaysToolStripMenuItem.Name = "ListenersInactiveFor30DaysToolStripMenuItem";
            ListenersInactiveFor30DaysToolStripMenuItem.Size = new Size(296, 24);
            ListenersInactiveFor30DaysToolStripMenuItem.Text = "Listeners inactive for 30 days";
            ListenersInactiveFor30DaysToolStripMenuItem.Click += ListenersInactiveFor30DaysToolStripMenuItem_Click;
            // 
            // GPOSackLabelsToolStripMenuItem
            // 
            GPOSackLabelsToolStripMenuItem.Name = "GPOSackLabelsToolStripMenuItem";
            GPOSackLabelsToolStripMenuItem.Size = new Size(296, 24);
            GPOSackLabelsToolStripMenuItem.Text = "Print Sack Labels";
            GPOSackLabelsToolStripMenuItem.Click += GPOSackLabelsToolStripMenuItem_Click;
            // 
            // StoppedListenersThisWeekToolStripMenuItem
            // 
            StoppedListenersThisWeekToolStripMenuItem.Name = "StoppedListenersThisWeekToolStripMenuItem";
            StoppedListenersThisWeekToolStripMenuItem.Size = new Size(296, 24);
            StoppedListenersThisWeekToolStripMenuItem.Text = "Paused Wallet List";
            StoppedListenersThisWeekToolStripMenuItem.Click += StoppedListenersThisWeekToolStripMenuItem_Click;
            // 
            // WalletsNotSentOutToolStripMenuItem
            // 
            WalletsNotSentOutToolStripMenuItem.Name = "WalletsNotSentOutToolStripMenuItem";
            WalletsNotSentOutToolStripMenuItem.Size = new Size(296, 24);
            WalletsNotSentOutToolStripMenuItem.Text = "Unsent Wallets This Week";
            WalletsNotSentOutToolStripMenuItem.Click += WalletsNotSentOutToolStripMenuItem_Click;
            // 
            // UnreturnedSpeakersToolStripMenuItem
            // 
            UnreturnedSpeakersToolStripMenuItem.Name = "UnreturnedSpeakersToolStripMenuItem";
            UnreturnedSpeakersToolStripMenuItem.Size = new Size(296, 24);
            UnreturnedSpeakersToolStripMenuItem.Text = "Unreturned Memory Stick Players";
            UnreturnedSpeakersToolStripMenuItem.Click += UnreturnedSpeakersToolStripMenuItem_Click;
            // 
            // PrintAlphabeticSurnameListToolStripMenuItem
            // 
            PrintAlphabeticSurnameListToolStripMenuItem.Name = "PrintAlphabeticSurnameListToolStripMenuItem";
            PrintAlphabeticSurnameListToolStripMenuItem.Size = new Size(296, 24);
            PrintAlphabeticSurnameListToolStripMenuItem.Text = "Print Alphabetic (Surname) List";
            PrintAlphabeticSurnameListToolStripMenuItem.Click += PrintAlphabeticSurnameListToolStripMenuItem_Click;
            // 
            // printCollectorForListenerToolStripMenuItem
            // 
            printCollectorForListenerToolStripMenuItem.Name = "printCollectorForListenerToolStripMenuItem";
            printCollectorForListenerToolStripMenuItem.Size = new Size(296, 24);
            printCollectorForListenerToolStripMenuItem.Text = "Print Collector For Listener";
            printCollectorForListenerToolStripMenuItem.Click += PrintCollectorForListenerToolStripMenuItem_Click;
            // 
            // magazineWalletsToolStripMenuItem
            // 
            magazineWalletsToolStripMenuItem.Name = "magazineWalletsToolStripMenuItem";
            magazineWalletsToolStripMenuItem.Size = new Size(296, 24);
            magazineWalletsToolStripMenuItem.Text = "Magazine Wallets";
            magazineWalletsToolStripMenuItem.Click += MagazineWalletsToolStripMenuItem_Click;
            // 
            // walletsStockToolStripMenuItem
            // 
            walletsStockToolStripMenuItem.Name = "walletsStockToolStripMenuItem";
            walletsStockToolStripMenuItem.Size = new Size(296, 24);
            walletsStockToolStripMenuItem.Text = "News Wallet Stock";
            walletsStockToolStripMenuItem.Click += WalletsStockToolStripMenuItem_Click;
            // 
            // magazineWalletStockToolStripMenuItem
            // 
            magazineWalletStockToolStripMenuItem.Name = "magazineWalletStockToolStripMenuItem";
            magazineWalletStockToolStripMenuItem.Size = new Size(296, 24);
            magazineWalletStockToolStripMenuItem.Text = "Magazine Wallet Stock";
            magazineWalletStockToolStripMenuItem.Click += MagazineWalletStockToolStripMenuItem_Click;
            // 
            // onlineonlyListenersToolStripMenuItem
            // 
            onlineonlyListenersToolStripMenuItem.Name = "onlineonlyListenersToolStripMenuItem";
            onlineonlyListenersToolStripMenuItem.Size = new Size(296, 24);
            onlineonlyListenersToolStripMenuItem.Text = "Online-only Listeners";
            onlineonlyListenersToolStripMenuItem.Click += onlineonlyListenersToolStripMenuItem_Click;
            // 
            // StatisticsHistoryToolStripMenuItem
            // 
            StatisticsHistoryToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { StatisticsToolStripMenuItem, HistoryToolStripMenuItem });
            StatisticsHistoryToolStripMenuItem.Name = "StatisticsHistoryToolStripMenuItem";
            StatisticsHistoryToolStripMenuItem.Size = new Size(140, 24);
            StatisticsHistoryToolStripMenuItem.Text = "Statistics / Histor&y";
            // 
            // StatisticsToolStripMenuItem
            // 
            StatisticsToolStripMenuItem.Name = "StatisticsToolStripMenuItem";
            StatisticsToolStripMenuItem.Size = new Size(136, 24);
            StatisticsToolStripMenuItem.Text = "Statistics";
            StatisticsToolStripMenuItem.Click += StatisticsToolStripMenuItem_Click;
            // 
            // HistoryToolStripMenuItem
            // 
            HistoryToolStripMenuItem.Name = "HistoryToolStripMenuItem";
            HistoryToolStripMenuItem.Size = new Size(136, 24);
            HistoryToolStripMenuItem.Text = "History";
            HistoryToolStripMenuItem.Click += HistoryToolStripMenuItem_Click;
            // 
            // ScanningToolStripMenuItem
            // 
            ScanningToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { ScanInToolStripMenuItem, ScanOutToolStripMenuItem });
            ScanningToolStripMenuItem.Name = "ScanningToolStripMenuItem";
            ScanningToolStripMenuItem.Size = new Size(81, 24);
            ScanningToolStripMenuItem.Text = "Scanning";
            ScanningToolStripMenuItem.Visible = false;
            // 
            // ScanInToolStripMenuItem
            // 
            ScanInToolStripMenuItem.Name = "ScanInToolStripMenuItem";
            ScanInToolStripMenuItem.Size = new Size(137, 24);
            ScanInToolStripMenuItem.Text = "Scan In";
            ScanInToolStripMenuItem.Click += ScanInToolStripMenuItem_Click;
            // 
            // ScanOutToolStripMenuItem
            // 
            ScanOutToolStripMenuItem.Name = "ScanOutToolStripMenuItem";
            ScanOutToolStripMenuItem.Size = new Size(137, 24);
            ScanOutToolStripMenuItem.Text = "Scan Out";
            ScanOutToolStripMenuItem.Click += ScanOutToolStripMenuItem_Click;
            // 
            // CollectorsToolStripMenuItem
            // 
            CollectorsToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { AddCollectorsToolStripMenuItem, BrowseToolStripMenuItem1 });
            CollectorsToolStripMenuItem.Name = "CollectorsToolStripMenuItem";
            CollectorsToolStripMenuItem.Size = new Size(87, 24);
            CollectorsToolStripMenuItem.Text = "Collectors";
            // 
            // AddCollectorsToolStripMenuItem
            // 
            AddCollectorsToolStripMenuItem.Name = "AddCollectorsToolStripMenuItem";
            AddCollectorsToolStripMenuItem.Size = new Size(176, 24);
            AddCollectorsToolStripMenuItem.Text = "Add Collectors";
            AddCollectorsToolStripMenuItem.Click += AddCollectorsToolStripMenuItem_Click;
            // 
            // BrowseToolStripMenuItem1
            // 
            BrowseToolStripMenuItem1.Name = "BrowseToolStripMenuItem1";
            BrowseToolStripMenuItem1.Size = new Size(176, 24);
            BrowseToolStripMenuItem1.Text = "Browse";
            BrowseToolStripMenuItem1.Click += BrowseToolStripMenuItem1_Click;
            // 
            // helpToolStripMenuItem
            // 
            helpToolStripMenuItem.DropDownItems.AddRange(new ToolStripItem[] { viewHelpToolStripMenuItem, aboutToolStripMenuItem1 });
            helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            helpToolStripMenuItem.Size = new Size(53, 24);
            helpToolStripMenuItem.Text = "&Help";
            // 
            // viewHelpToolStripMenuItem
            // 
            viewHelpToolStripMenuItem.Name = "viewHelpToolStripMenuItem";
            viewHelpToolStripMenuItem.ShortcutKeys = Keys.F1;
            viewHelpToolStripMenuItem.Size = new Size(170, 24);
            viewHelpToolStripMenuItem.Text = "&View Help";
            viewHelpToolStripMenuItem.Click += viewHelpToolStripMenuItem_Click;
            // 
            // aboutToolStripMenuItem1
            // 
            aboutToolStripMenuItem1.Name = "aboutToolStripMenuItem1";
            aboutToolStripMenuItem1.Size = new Size(170, 24);
            aboutToolStripMenuItem1.Text = "Abo&ut";
            aboutToolStripMenuItem1.Click += aboutToolStripMenuItem1_Click;
            // 
            // lblDate
            // 
            lblDate.AutoSize = true;
            lblDate.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblDate.Location = new Point(1007, 128);
            lblDate.Margin = new Padding(4, 0, 4, 0);
            lblDate.Name = "lblDate";
            lblDate.Size = new Size(100, 24);
            lblDate.TabIndex = 2;
            lblDate.Text = "??/??/????";
            // 
            // lblTime
            // 
            lblTime.AutoSize = true;
            lblTime.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblTime.Location = new Point(86, 128);
            lblTime.Margin = new Padding(4, 0, 4, 0);
            lblTime.Name = "lblTime";
            lblTime.Size = new Size(80, 24);
            lblTime.TabIndex = 3;
            lblTime.Text = "??:??:??";
            // 
            // timerUpdate
            // 
            timerUpdate.Enabled = true;
            timerUpdate.Interval = 1000;
            timerUpdate.Tick += timerUpdate_Tick;
            // 
            // GroupBox1
            // 
            GroupBox1.Controls.Add(btnPrintLabels);
            GroupBox1.Controls.Add(btnCancelStop);
            GroupBox1.Controls.Add(btnStopSending);
            GroupBox1.Controls.Add(btnBrowse);
            GroupBox1.Controls.Add(btnEdit);
            GroupBox1.Controls.Add(btnRemove);
            GroupBox1.Controls.Add(btnAdd);
            GroupBox1.FlatStyle = FlatStyle.Popup;
            GroupBox1.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            GroupBox1.Location = new Point(62, 202);
            GroupBox1.Margin = new Padding(4, 3, 4, 3);
            GroupBox1.Name = "GroupBox1";
            GroupBox1.Padding = new Padding(4, 3, 4, 3);
            GroupBox1.Size = new Size(245, 422);
            GroupBox1.TabIndex = 4;
            GroupBox1.TabStop = false;
            GroupBox1.Text = "Listeners";
            // 
            // btnPrintLabels
            // 
            btnPrintLabels.BackColor = Color.White;
            btnPrintLabels.ImageAlign = ContentAlignment.MiddleLeft;
            btnPrintLabels.Location = new Point(7, 355);
            btnPrintLabels.Margin = new Padding(4, 3, 4, 3);
            btnPrintLabels.Name = "btnPrintLabels";
            btnPrintLabels.Size = new Size(231, 45);
            btnPrintLabels.TabIndex = 11;
            btnPrintLabels.Text = "&Print Labels";
            btnPrintLabels.UseVisualStyleBackColor = false;
            btnPrintLabels.Click += btnPrintLabels_Click;
            // 
            // btnCancelStop
            // 
            btnCancelStop.BackColor = Color.FromArgb(255, 128, 128);
            btnCancelStop.ImageAlign = ContentAlignment.MiddleLeft;
            btnCancelStop.Location = new Point(7, 252);
            btnCancelStop.Margin = new Padding(4, 3, 4, 3);
            btnCancelStop.Name = "btnCancelStop";
            btnCancelStop.Size = new Size(231, 45);
            btnCancelStop.TabIndex = 9;
            btnCancelStop.Text = "&Cancel a Stop";
            btnCancelStop.UseVisualStyleBackColor = false;
            btnCancelStop.Click += BtnCancelStop_Click;
            // 
            // btnStopSending
            // 
            btnStopSending.BackColor = Color.FromArgb(255, 192, 128);
            btnStopSending.ImageAlign = ContentAlignment.MiddleLeft;
            btnStopSending.Location = new Point(7, 303);
            btnStopSending.Margin = new Padding(4, 3, 4, 3);
            btnStopSending.Name = "btnStopSending";
            btnStopSending.Size = new Size(231, 45);
            btnStopSending.TabIndex = 8;
            btnStopSending.Text = "&Stop Sending";
            btnStopSending.UseVisualStyleBackColor = false;
            btnStopSending.Click += BtnStopSending_Click;
            // 
            // btnBrowse
            // 
            btnBrowse.BackColor = Color.FromArgb(255, 255, 128);
            btnBrowse.ImageAlign = ContentAlignment.MiddleLeft;
            btnBrowse.Location = new Point(7, 195);
            btnBrowse.Margin = new Padding(4, 3, 4, 3);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(231, 45);
            btnBrowse.TabIndex = 10;
            btnBrowse.Text = "Bro&wse";
            btnBrowse.UseVisualStyleBackColor = false;
            btnBrowse.Click += BtnBrowse_Click;
            // 
            // btnEdit
            // 
            btnEdit.BackColor = Color.FromArgb(128, 128, 255);
            btnEdit.ImageAlign = ContentAlignment.MiddleLeft;
            btnEdit.Location = new Point(7, 143);
            btnEdit.Margin = new Padding(4, 3, 4, 3);
            btnEdit.Name = "btnEdit";
            btnEdit.Size = new Size(231, 45);
            btnEdit.TabIndex = 7;
            btnEdit.Text = "&Edit";
            btnEdit.UseVisualStyleBackColor = false;
            btnEdit.Click += BtnEdit_Click;
            // 
            // btnRemove
            // 
            btnRemove.BackColor = Color.FromArgb(255, 128, 128);
            btnRemove.ImageAlign = ContentAlignment.MiddleLeft;
            btnRemove.Location = new Point(7, 92);
            btnRemove.Margin = new Padding(4, 3, 4, 3);
            btnRemove.Name = "btnRemove";
            btnRemove.Size = new Size(231, 44);
            btnRemove.TabIndex = 6;
            btnRemove.Text = "&Delete";
            btnRemove.UseVisualStyleBackColor = false;
            btnRemove.Click += BtnRemove_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.FromArgb(128, 255, 128);
            btnAdd.ImageAlign = ContentAlignment.MiddleLeft;
            btnAdd.Location = new Point(7, 36);
            btnAdd.Margin = new Padding(4, 3, 4, 3);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(231, 45);
            btnAdd.TabIndex = 5;
            btnAdd.Text = "&Add";
            btnAdd.UseVisualStyleBackColor = false;
            btnAdd.Click += BtnAdd_Click;
            // 
            // btnFinished
            // 
            btnFinished.BackColor = Color.FromArgb(255, 128, 128);
            btnFinished.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            btnFinished.ImageAlign = ContentAlignment.MiddleLeft;
            btnFinished.Location = new Point(492, 591);
            btnFinished.Margin = new Padding(4, 3, 4, 3);
            btnFinished.Name = "btnFinished";
            btnFinished.Size = new Size(209, 61);
            btnFinished.TabIndex = 12;
            btnFinished.Text = "&Finished";
            btnFinished.UseVisualStyleBackColor = false;
            btnFinished.Click += BtnFinished_Click;
            // 
            // GroupBox2
            // 
            GroupBox2.Controls.Add(btnScanOut);
            GroupBox2.Controls.Add(btnScanIn);
            GroupBox2.FlatStyle = FlatStyle.Popup;
            GroupBox2.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            GroupBox2.Location = new Point(896, 202);
            GroupBox2.Margin = new Padding(4, 3, 4, 3);
            GroupBox2.Name = "GroupBox2";
            GroupBox2.Padding = new Padding(4, 3, 4, 3);
            GroupBox2.Size = new Size(245, 167);
            GroupBox2.TabIndex = 12;
            GroupBox2.TabStop = false;
            GroupBox2.Text = "News Scanning";
            // 
            // btnScanOut
            // 
            btnScanOut.BackColor = Color.Yellow;
            btnScanOut.ImageAlign = ContentAlignment.MiddleLeft;
            btnScanOut.Location = new Point(7, 92);
            btnScanOut.Margin = new Padding(4, 3, 4, 3);
            btnScanOut.Name = "btnScanOut";
            btnScanOut.Size = new Size(231, 45);
            btnScanOut.TabIndex = 11;
            btnScanOut.Text = "Scan &Out";
            btnScanOut.UseVisualStyleBackColor = false;
            btnScanOut.Click += BtnScanOut_Click;
            // 
            // btnScanIn
            // 
            btnScanIn.BackColor = Color.Yellow;
            btnScanIn.ImageAlign = ContentAlignment.MiddleLeft;
            btnScanIn.Location = new Point(7, 36);
            btnScanIn.Margin = new Padding(4, 3, 4, 3);
            btnScanIn.Name = "btnScanIn";
            btnScanIn.Size = new Size(231, 45);
            btnScanIn.TabIndex = 10;
            btnScanIn.Text = "Scan &In";
            btnScanIn.UseVisualStyleBackColor = false;
            btnScanIn.Click += BtnScanIn_Click;
            // 
            // StatusStrip1
            // 
            StatusStrip1.ImageScalingSize = new Size(32, 32);
            StatusStrip1.ImeMode = ImeMode.Hiragana;
            StatusStrip1.Items.AddRange(new ToolStripItem[] { lblHints });
            StatusStrip1.Location = new Point(0, 672);
            StatusStrip1.Name = "StatusStrip1";
            StatusStrip1.Padding = new Padding(2, 0, 30, 0);
            StatusStrip1.Size = new Size(1168, 22);
            StatusStrip1.TabIndex = 14;
            StatusStrip1.Text = "StatusStrip1";
            // 
            // lblHints
            // 
            lblHints.Name = "lblHints";
            lblHints.Size = new Size(48, 17);
            lblHints.Text = "lblHints";
            // 
            // timerHints
            // 
            timerHints.Enabled = true;
            timerHints.Interval = 3000;
            timerHints.Tick += TimerHints_Tick;
            // 
            // backupDialog
            // 
            backupDialog.HelpRequest += BtnAdd_Click;
            // 
            // PictureBox1
            // 
            PictureBox1.BackgroundImageLayout = ImageLayout.Stretch;
            PictureBox1.InitialImage = (Image)resources.GetObject("PictureBox1.InitialImage");
            PictureBox1.Location = new Point(422, 202);
            PictureBox1.Margin = new Padding(4, 3, 4, 3);
            PictureBox1.Name = "PictureBox1";
            PictureBox1.Size = new Size(358, 302);
            PictureBox1.TabIndex = 15;
            PictureBox1.TabStop = false;
            // 
            // restoreDialog
            // 
            restoreDialog.FileName = "OpenFileDialog1";
            // 
            // lblVersion
            // 
            lblVersion.AutoSize = true;
            lblVersion.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblVersion.Location = new Point(546, 516);
            lblVersion.Margin = new Padding(4, 0, 4, 0);
            lblVersion.Name = "lblVersion";
            lblVersion.Size = new Size(83, 24);
            lblVersion.TabIndex = 16;
            lblVersion.Text = "V ?.?.?.?";
            // 
            // lblWeekNumber
            // 
            lblWeekNumber.AutoSize = true;
            lblWeekNumber.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            lblWeekNumber.Location = new Point(530, 128);
            lblWeekNumber.Margin = new Padding(4, 0, 4, 0);
            lblWeekNumber.Name = "lblWeekNumber";
            lblWeekNumber.Size = new Size(109, 24);
            lblWeekNumber.TabIndex = 17;
            lblWeekNumber.Text = "Week: ????";
            // 
            // groupBox3
            // 
            groupBox3.Controls.Add(btnMagScanOut);
            groupBox3.Controls.Add(btnMagScanIn);
            groupBox3.FlatStyle = FlatStyle.Popup;
            groupBox3.Font = new Font("Microsoft Sans Serif", 14.25F, FontStyle.Regular, GraphicsUnit.Point);
            groupBox3.Location = new Point(896, 435);
            groupBox3.Margin = new Padding(4, 3, 4, 3);
            groupBox3.Name = "groupBox3";
            groupBox3.Padding = new Padding(4, 3, 4, 3);
            groupBox3.Size = new Size(245, 167);
            groupBox3.TabIndex = 13;
            groupBox3.TabStop = false;
            groupBox3.Text = "Magazine Scanning";
            // 
            // btnMagScanOut
            // 
            btnMagScanOut.BackColor = Color.FromArgb(255, 128, 0);
            btnMagScanOut.ImageAlign = ContentAlignment.MiddleLeft;
            btnMagScanOut.Location = new Point(7, 92);
            btnMagScanOut.Margin = new Padding(4, 3, 4, 3);
            btnMagScanOut.Name = "btnMagScanOut";
            btnMagScanOut.Size = new Size(231, 45);
            btnMagScanOut.TabIndex = 13;
            btnMagScanOut.Text = "Scan &Out";
            btnMagScanOut.UseVisualStyleBackColor = false;
            btnMagScanOut.Click += BtnMagScanOut_Click;
            // 
            // btnMagScanIn
            // 
            btnMagScanIn.BackColor = Color.FromArgb(255, 128, 0);
            btnMagScanIn.ImageAlign = ContentAlignment.MiddleLeft;
            btnMagScanIn.Location = new Point(7, 36);
            btnMagScanIn.Margin = new Padding(4, 3, 4, 3);
            btnMagScanIn.Name = "btnMagScanIn";
            btnMagScanIn.Size = new Size(231, 45);
            btnMagScanIn.TabIndex = 12;
            btnMagScanIn.Text = "Scan &In";
            btnMagScanIn.UseVisualStyleBackColor = false;
            btnMagScanIn.Click += BtnMagScanIn_Click;
            // 
            // helpProvider
            // 
            helpProvider.HelpNamespace = "Resource\\TNBase.chm";
            // 
            // FormMain
            // 
            AccessibleRole = AccessibleRole.None;
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImageLayout = ImageLayout.None;
            ClientSize = new Size(1168, 694);
            Controls.Add(groupBox3);
            Controls.Add(lblWeekNumber);
            Controls.Add(lblVersion);
            Controls.Add(PictureBox1);
            Controls.Add(StatusStrip1);
            Controls.Add(GroupBox2);
            Controls.Add(btnFinished);
            Controls.Add(GroupBox1);
            Controls.Add(lblTime);
            Controls.Add(lblDate);
            Controls.Add(Label1);
            Controls.Add(menuTop);
            ForeColor = Color.Black;
            FormBorderStyle = FormBorderStyle.FixedSingle;
            helpProvider.SetHelpKeyword(this, "0");
            helpProvider.SetHelpNavigator(this, HelpNavigator.TopicId);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuTop;
            Margin = new Padding(4, 3, 4, 3);
            MaximizeBox = false;
            Name = "FormMain";
            helpProvider.SetShowHelp(this, true);
            StartPosition = FormStartPosition.CenterScreen;
            Load += formMain_Load;
            menuTop.ResumeLayout(false);
            menuTop.PerformLayout();
            GroupBox1.ResumeLayout(false);
            GroupBox2.ResumeLayout(false);
            StatusStrip1.ResumeLayout(false);
            StatusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PictureBox1).EndInit();
            groupBox3.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        internal Label Label1;
        internal MenuStrip menuTop;
        internal ToolStripMenuItem mBtnListeners;
        internal ToolStripMenuItem MaintenenceToolStripMenuItem;
        internal ToolStripMenuItem PrintingToolStripMenuItem;
        internal ToolStripMenuItem StatisticsHistoryToolStripMenuItem;
        internal Label lblDate;
        internal Label lblTime;
        private Timer timerUpdate;
        internal GroupBox GroupBox1;
        private Button btnAdd;
        private Button btnPrintLabels;
        private Button btnBrowse;
        private Button btnCancelStop;
        private Button btnStopSending;
        private Button btnEdit;
        private Button btnRemove;
        private Button btnFinished;
        internal GroupBox GroupBox2;
        private Button btnScanOut;
        private Button btnScanIn;
        internal StatusStrip StatusStrip1;
        internal ToolStripStatusLabel lblHints;
        private Timer timerHints;
        private ToolStripMenuItem AddToolStripMenuItem;
        private ToolStripMenuItem DeleteToolStripMenuItem;
        private ToolStripMenuItem EditToolStripMenuItem;
        private ToolStripMenuItem BackupToolStripMenuItem;
        internal SaveFileDialog backupDialog;
        internal PictureBox PictureBox1;
        private ToolStripMenuItem UpcomingBirthdaysToolStripMenuItem;
        private ToolStripMenuItem StopSendingToolStripMenuItem;
        private ToolStripMenuItem CancelAStopToolStripMenuItem;
        private ToolStripMenuItem BrowseToolStripMenuItem;
        private ToolStripMenuItem StatisticsToolStripMenuItem;
        private ToolStripMenuItem RestoreToolStripMenuItem;
        internal OpenFileDialog restoreDialog;
        private ToolStripMenuItem ScanningToolStripMenuItem;
        private ToolStripMenuItem ScanInToolStripMenuItem;
        private ToolStripMenuItem ScanOutToolStripMenuItem;
        private ToolStripMenuItem RecentlyAddedListenersToolStripMenuItem;
        private ToolStripMenuItem PrintAddressLabelsToolStripMenuItem;
        internal ToolStripMenuItem CollectorsToolStripMenuItem;
        private ToolStripMenuItem AddCollectorsToolStripMenuItem;
        private ToolStripMenuItem BrowseToolStripMenuItem1;
        internal Label lblVersion;
        private ToolStripMenuItem ListenersInactiveFor30DaysToolStripMenuItem;
        private ToolStripMenuItem HistoryToolStripMenuItem;
        private ToolStripMenuItem GPOSackLabelsToolStripMenuItem;
        private ToolStripMenuItem StoppedListenersThisWeekToolStripMenuItem;
        private ToolStripMenuItem WalletsNotSentOutToolStripMenuItem;
        private ToolStripMenuItem UnreturnedSpeakersToolStripMenuItem;
        private ToolStripMenuItem PrintAlphabeticSurnameListToolStripMenuItem;
        private ToolStripMenuItem PrintAllListenerLabelsToolStripMenuItem;
        internal Label lblWeekNumber;

        public FormMain()
        {
            FormClosing += formMain_FormClosing;
            Load += formMain_Load;
            InitializeComponent();
            Label1.Text = Properties.Settings.Default.AssociationName;
        }

        private ToolStripMenuItem logViewToolStripMenuItem;
        private ToolStripMenuItem openLogDirectoryToolStripMenuItem;
        private ToolStripMenuItem printCollectorForListenerToolStripMenuItem;
        private ToolStripMenuItem magazineWalletsToolStripMenuItem;
        private ToolStripMenuItem adjustStockLevelsToolStripMenuItem;
        private ToolStripMenuItem walletsStockToolStripMenuItem;
        internal GroupBox groupBox3;
        private Button btnMagScanOut;
        private Button btnMagScanIn;
        private ToolStripMenuItem magazineWalletStockToolStripMenuItem;
        private ToolStripMenuItem onlineonlyListenersToolStripMenuItem;
        private ToolStripMenuItem dataImportToolStripMenuItem;
        private ToolStripMenuItem helpToolStripMenuItem;
        private ToolStripMenuItem viewHelpToolStripMenuItem;
        private ToolStripMenuItem aboutToolStripMenuItem1;
        private HelpProvider helpProvider;
        private ToolStripMenuItem updateDatabaseEncryptionKeyToolStripMenuItem;
        private ToolStripMenuItem dataExportToolStripMenuItem;
        private ToolStripMenuItem settingsToolStripMenuItem;
    }
}
