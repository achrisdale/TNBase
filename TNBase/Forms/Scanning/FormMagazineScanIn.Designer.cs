namespace TNBase.Forms.Scanning
{
    partial class FormMagazineScanIn
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMagazineScanIn));
            this.lstScanned = new System.Windows.Forms.ListView();
            this.Wallet = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Quantity = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.btnFinish = new System.Windows.Forms.Button();
            this.txtScannerInput = new System.Windows.Forms.TextBox();
            this.Label2 = new System.Windows.Forms.Label();
            this.Label1 = new System.Windows.Forms.Label();
            this.btnScanOut = new System.Windows.Forms.Button();
            this.btnRemove = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lstScanned
            // 
            this.lstScanned.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Wallet,
            this.Quantity});
            this.lstScanned.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lstScanned.FullRowSelect = true;
            this.lstScanned.GridLines = true;
            this.lstScanned.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.lstScanned.HideSelection = false;
            this.lstScanned.Location = new System.Drawing.Point(12, 55);
            this.lstScanned.MultiSelect = false;
            this.lstScanned.Name = "lstScanned";
            this.lstScanned.Size = new System.Drawing.Size(369, 383);
            this.lstScanned.TabIndex = 106;
            this.lstScanned.TabStop = false;
            this.lstScanned.UseCompatibleStateImageBehavior = false;
            this.lstScanned.View = System.Windows.Forms.View.Details;
            // 
            // Wallet
            // 
            this.Wallet.Text = "Wallet";
            this.Wallet.Width = 209;
            // 
            // Quantity
            // 
            this.Quantity.Text = "Quantity";
            this.Quantity.Width = 140;
            // 
            // btnFinish
            // 
            this.btnFinish.BackColor = System.Drawing.Color.LimeGreen;
            this.btnFinish.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFinish.Location = new System.Drawing.Point(619, 369);
            this.btnFinish.Name = "btnFinish";
            this.btnFinish.Size = new System.Drawing.Size(169, 69);
            this.btnFinish.TabIndex = 105;
            this.btnFinish.TabStop = false;
            this.btnFinish.Text = "Finish";
            this.btnFinish.UseVisualStyleBackColor = false;
            this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
            // 
            // txtScannerInput
            // 
            this.txtScannerInput.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtScannerInput.Location = new System.Drawing.Point(397, 193);
            this.txtScannerInput.Name = "txtScannerInput";
            this.txtScannerInput.Size = new System.Drawing.Size(314, 40);
            this.txtScannerInput.TabIndex = 101;
            this.txtScannerInput.TextChanged += new System.EventHandler(this.txtScannerInput_TextChanged);
            this.txtScannerInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtScannerInput_KeyDown);
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label2.Location = new System.Drawing.Point(391, 157);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(320, 33);
            this.Label2.TabIndex = 103;
            this.Label2.Text = "Please scan in a wallet!";
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Label1.Location = new System.Drawing.Point(6, 11);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(375, 33);
            this.Label1.TabIndex = 102;
            this.Label1.Text = "Scanned Magazine Wallets:";
            // 
            // btnScanOut
            // 
            this.btnScanOut.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btnScanOut.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnScanOut.Location = new System.Drawing.Point(397, 369);
            this.btnScanOut.Name = "btnScanOut";
            this.btnScanOut.Size = new System.Drawing.Size(216, 69);
            this.btnScanOut.TabIndex = 107;
            this.btnScanOut.TabStop = false;
            this.btnScanOut.Text = "Scan Out";
            this.btnScanOut.UseVisualStyleBackColor = false;
            this.btnScanOut.Click += new System.EventHandler(this.btnScanOut_Click);
            // 
            // btnRemove
            // 
            this.btnRemove.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRemove.Location = new System.Drawing.Point(589, 12);
            this.btnRemove.Name = "btnRemove";
            this.btnRemove.Size = new System.Drawing.Size(199, 42);
            this.btnRemove.TabIndex = 108;
            this.btnRemove.Text = "Remove Scanned";
            this.btnRemove.UseVisualStyleBackColor = true;
            this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
            // 
            // FormMagazineScanIn
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnRemove);
            this.Controls.Add(this.btnScanOut);
            this.Controls.Add(this.lstScanned);
            this.Controls.Add(this.btnFinish);
            this.Controls.Add(this.txtScannerInput);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormMagazineScanIn";
            this.Text = "Magazine Scan In";
            this.Load += new System.EventHandler(this.FormMagazineScanIn_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.ListView lstScanned;
        internal System.Windows.Forms.ColumnHeader Wallet;
        internal System.Windows.Forms.ColumnHeader Quantity;
        private System.Windows.Forms.Button btnFinish;
        private System.Windows.Forms.TextBox txtScannerInput;
        internal System.Windows.Forms.Label Label2;
        internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button btnScanOut;
        private System.Windows.Forms.Button btnRemove;
    }
}