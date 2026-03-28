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
	partial class FormChoosePrintPoint : System.Windows.Forms.Form
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormChoosePrintPoint));
            CheckBox1 = new CheckBox();
            CheckBox2 = new CheckBox();
            CheckBox3 = new CheckBox();
            CheckBox4 = new CheckBox();
            CheckBox5 = new CheckBox();
            CheckBox6 = new CheckBox();
            CheckBox8 = new CheckBox();
            CheckBox9 = new CheckBox();
            Label1 = new Label();
            Button1 = new Button();
            btnCancel = new Button();
            cmbSelection = new ComboBox();
            Label2 = new Label();
            SuspendLayout();
            // 
            // CheckBox1
            // 
            CheckBox1.AutoSize = true;
            CheckBox1.BackColor = Color.Transparent;
            CheckBox1.Checked = true;
            CheckBox1.CheckState = CheckState.Checked;
            CheckBox1.FlatAppearance.CheckedBackColor = Color.White;
            CheckBox1.Font = new Font("Microsoft Sans Serif", 21.75F);
            CheckBox1.Location = new Point(151, 81);
            CheckBox1.Name = "CheckBox1";
            CheckBox1.Size = new Size(15, 14);
            CheckBox1.TabIndex = 0;
            CheckBox1.UseVisualStyleBackColor = false;
            CheckBox1.Click += CheckBox1_Click;
            // 
            // CheckBox2
            // 
            CheckBox2.AutoSize = true;
            CheckBox2.BackColor = Color.Transparent;
            CheckBox2.Checked = true;
            CheckBox2.CheckState = CheckState.Checked;
            CheckBox2.Enabled = false;
            CheckBox2.FlatAppearance.CheckedBackColor = Color.White;
            CheckBox2.Font = new Font("Microsoft Sans Serif", 21.75F);
            CheckBox2.Location = new Point(185, 80);
            CheckBox2.Name = "CheckBox2";
            CheckBox2.Size = new Size(15, 14);
            CheckBox2.TabIndex = 1;
            CheckBox2.UseVisualStyleBackColor = false;
            // 
            // CheckBox3
            // 
            CheckBox3.AutoSize = true;
            CheckBox3.BackColor = Color.Transparent;
            CheckBox3.Checked = true;
            CheckBox3.CheckState = CheckState.Checked;
            CheckBox3.Enabled = false;
            CheckBox3.FlatAppearance.CheckedBackColor = Color.White;
            CheckBox3.Font = new Font("Microsoft Sans Serif", 21.75F);
            CheckBox3.Location = new Point(185, 103);
            CheckBox3.Name = "CheckBox3";
            CheckBox3.Size = new Size(15, 14);
            CheckBox3.TabIndex = 2;
            CheckBox3.UseVisualStyleBackColor = false;
            // 
            // CheckBox4
            // 
            CheckBox4.AutoSize = true;
            CheckBox4.BackColor = Color.Transparent;
            CheckBox4.Enabled = false;
            CheckBox4.FlatAppearance.CheckedBackColor = Color.White;
            CheckBox4.Font = new Font("Microsoft Sans Serif", 21.75F);
            CheckBox4.Location = new Point(185, 134);
            CheckBox4.Name = "CheckBox4";
            CheckBox4.Size = new Size(15, 14);
            CheckBox4.TabIndex = 5;
            CheckBox4.UseVisualStyleBackColor = false;
            // 
            // CheckBox5
            // 
            CheckBox5.AutoSize = true;
            CheckBox5.BackColor = Color.Transparent;
            CheckBox5.FlatAppearance.CheckedBackColor = Color.White;
            CheckBox5.Font = new Font("Microsoft Sans Serif", 21.75F);
            CheckBox5.Location = new Point(151, 134);
            CheckBox5.Name = "CheckBox5";
            CheckBox5.Size = new Size(15, 14);
            CheckBox5.TabIndex = 4;
            CheckBox5.UseVisualStyleBackColor = false;
            CheckBox5.Click += CheckBox5_Click;
            // 
            // CheckBox6
            // 
            CheckBox6.AutoSize = true;
            CheckBox6.BackColor = Color.Transparent;
            CheckBox6.Checked = true;
            CheckBox6.CheckState = CheckState.Checked;
            CheckBox6.Enabled = false;
            CheckBox6.FlatAppearance.CheckedBackColor = Color.White;
            CheckBox6.Font = new Font("Microsoft Sans Serif", 21.75F);
            CheckBox6.Location = new Point(151, 103);
            CheckBox6.Name = "CheckBox6";
            CheckBox6.Size = new Size(15, 14);
            CheckBox6.TabIndex = 3;
            CheckBox6.UseVisualStyleBackColor = false;
            // 
            // CheckBox8
            // 
            CheckBox8.AutoSize = true;
            CheckBox8.BackColor = Color.Transparent;
            CheckBox8.Enabled = false;
            CheckBox8.FlatAppearance.CheckedBackColor = Color.White;
            CheckBox8.Font = new Font("Microsoft Sans Serif", 21.75F);
            CheckBox8.Location = new Point(185, 161);
            CheckBox8.Name = "CheckBox8";
            CheckBox8.Size = new Size(15, 14);
            CheckBox8.TabIndex = 7;
            CheckBox8.UseVisualStyleBackColor = false;
            // 
            // CheckBox9
            // 
            CheckBox9.AutoSize = true;
            CheckBox9.BackColor = Color.Transparent;
            CheckBox9.Enabled = false;
            CheckBox9.FlatAppearance.CheckedBackColor = Color.White;
            CheckBox9.Font = new Font("Microsoft Sans Serif", 21.75F);
            CheckBox9.Location = new Point(151, 161);
            CheckBox9.Name = "CheckBox9";
            CheckBox9.Size = new Size(15, 14);
            CheckBox9.TabIndex = 6;
            CheckBox9.UseVisualStyleBackColor = false;
            // 
            // Label1
            // 
            Label1.AutoSize = true;
            Label1.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label1.Location = new Point(26, 21);
            Label1.Name = "Label1";
            Label1.Size = new Size(330, 33);
            Label1.TabIndex = 18;
            Label1.Text = "Choose a starting point..";
            // 
            // Button1
            // 
            Button1.BackColor = Color.FromArgb(128, 255, 128);
            Button1.Font = new Font("Microsoft Sans Serif", 21.75F);
            Button1.Location = new Point(442, 248);
            Button1.Name = "Button1";
            Button1.Size = new Size(160, 80);
            Button1.TabIndex = 19;
            Button1.Text = "Print";
            Button1.UseVisualStyleBackColor = false;
            Button1.Click += Button1_Click;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = Color.FromArgb(255, 128, 128);
            btnCancel.Font = new Font("Microsoft Sans Serif", 21.75F);
            btnCancel.Location = new Point(99, 248);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(160, 80);
            btnCancel.TabIndex = 20;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            btnCancel.Click += btnCancel_Click;
            // 
            // cmbSelection
            // 
            cmbSelection.BackColor = Color.White;
            cmbSelection.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbSelection.Font = new Font("Microsoft Sans Serif", 21.75F);
            cmbSelection.FormattingEnabled = true;
            //           cmbSelection.Items.AddRange(new object[] { "1 - 4", "5 - 8", "9 - 12", "13 - 16" });
            cmbSelection.Items.AddRange(new object[] { "1 - 4", "5 - 8"});
            cmbSelection.Location = new Point(352, 134);
            cmbSelection.Name = "cmbSelection";
            cmbSelection.Size = new Size(249, 41);
            cmbSelection.TabIndex = 21;
            cmbSelection.SelectedIndexChanged += cmbSelection_SelectedIndexChanged;
            // 
            // Label2
            // 
            Label2.AutoSize = true;
            Label2.Font = new Font("Microsoft Sans Serif", 21.75F);
            Label2.Location = new Point(345, 92);
            Label2.Name = "Label2";
            Label2.Size = new Size(143, 33);
            Label2.TabIndex = 22;
            Label2.Text = "Selection:";
            // 
            // FormChoosePrintPoint
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(691, 358);
            Controls.Add(Label2);
            Controls.Add(cmbSelection);
            Controls.Add(btnCancel);
            Controls.Add(Button1);
            Controls.Add(Label1);
            Controls.Add(CheckBox8);
            Controls.Add(CheckBox9);
            Controls.Add(CheckBox4);
            Controls.Add(CheckBox5);
            Controls.Add(CheckBox6);
            Controls.Add(CheckBox3);
            Controls.Add(CheckBox2);
            Controls.Add(CheckBox1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "FormChoosePrintPoint";
            StartPosition = FormStartPosition.CenterScreen;
            Load += FormChoosePrintPoint_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.CheckBox CheckBox1;
		internal System.Windows.Forms.CheckBox CheckBox2;
		internal System.Windows.Forms.CheckBox CheckBox3;
		internal System.Windows.Forms.CheckBox CheckBox4;
        private System.Windows.Forms.CheckBox CheckBox5;
		internal System.Windows.Forms.CheckBox CheckBox6;
		internal System.Windows.Forms.CheckBox CheckBox8;
		internal System.Windows.Forms.CheckBox CheckBox9;
		internal System.Windows.Forms.Label Label1;
        private System.Windows.Forms.Button Button1;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.ComboBox cmbSelection;
		internal System.Windows.Forms.Label Label2;
	}
}
