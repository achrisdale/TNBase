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
	partial class FormAddFull : System.Windows.Forms.Form
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAddFull));
            this.Label1 = new System.Windows.Forms.Label();
            this.Label2 = new System.Windows.Forms.Label();
            this.comboTitle = new System.Windows.Forms.ComboBox();
            this.Label3 = new System.Windows.Forms.Label();
            this.txtSurname = new System.Windows.Forms.TextBox();
            this.txtForename = new System.Windows.Forms.TextBox();
            this.Label4 = new System.Windows.Forms.Label();
            this.Label5 = new System.Windows.Forms.Label();
            this.txtAddr1 = new System.Windows.Forms.TextBox();
            this.txtAddr2 = new System.Windows.Forms.TextBox();
            this.Label6 = new System.Windows.Forms.Label();
            this.txtTown = new System.Windows.Forms.TextBox();
            this.Label7 = new System.Windows.Forms.Label();
            this.txtCounty = new System.Windows.Forms.TextBox();
            this.Label8 = new System.Windows.Forms.Label();
            this.txtPostcode = new System.Windows.Forms.TextBox();
            this.Label9 = new System.Windows.Forms.Label();
            this.txtTelephone = new System.Windows.Forms.TextBox();
            this.Label10 = new System.Windows.Forms.Label();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnFinished = new System.Windows.Forms.Button();
            this.chkTape = new System.Windows.Forms.CheckBox();
            this.chkMagazine = new System.Windows.Forms.CheckBox();
            this.Label12 = new System.Windows.Forms.Label();
            this.txtInformation = new System.Windows.Forms.TextBox();
            this.chkNoBirthday = new System.Windows.Forms.CheckBox();
            this.cbxBirthdayDay = new System.Windows.Forms.ComboBox();
            this.cbxBirthdayMonth = new System.Windows.Forms.ComboBox();
            this.errorProvider = new System.Windows.Forms.ErrorProvider(this.components);
            this.chkOnlineOnly = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).BeginInit();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label1.Location = new System.Drawing.Point(37, 107);
            this.Label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(45, 24);
            this.Label1.TabIndex = 0;
            this.Label1.Text = "Title";
            // 
            // Label2
            // 
            this.Label2.AutoSize = true;
            this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.Label2.Location = new System.Drawing.Point(482, 10);
            this.Label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label2.Name = "Label2";
            this.Label2.Size = new System.Drawing.Size(309, 37);
            this.Label2.TabIndex = 1;
            this.Label2.Text = "Add a new Listener";
            // 
            // comboTitle
            // 
            this.comboTitle.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboTitle.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboTitle.FormattingEnabled = true;
            this.comboTitle.Location = new System.Drawing.Point(172, 104);
            this.comboTitle.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.comboTitle.Name = "comboTitle";
            this.comboTitle.Size = new System.Drawing.Size(242, 32);
            this.comboTitle.TabIndex = 2;
            // 
            // Label3
            // 
            this.Label3.AutoSize = true;
            this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label3.Location = new System.Drawing.Point(38, 145);
            this.Label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label3.Name = "Label3";
            this.Label3.Size = new System.Drawing.Size(87, 24);
            this.Label3.TabIndex = 3;
            this.Label3.Text = "Forname";
            // 
            // txtSurname
            // 
            this.txtSurname.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtSurname.Location = new System.Drawing.Point(172, 177);
            this.txtSurname.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtSurname.MaxLength = 50;
            this.txtSurname.Name = "txtSurname";
            this.txtSurname.Size = new System.Drawing.Size(353, 29);
            this.txtSurname.TabIndex = 4;
            // 
            // txtForename
            // 
            this.txtForename.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtForename.Location = new System.Drawing.Point(172, 142);
            this.txtForename.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtForename.MaxLength = 50;
            this.txtForename.Name = "txtForename";
            this.txtForename.Size = new System.Drawing.Size(353, 29);
            this.txtForename.TabIndex = 3;
            // 
            // Label4
            // 
            this.Label4.AutoSize = true;
            this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label4.Location = new System.Drawing.Point(38, 180);
            this.Label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label4.Name = "Label4";
            this.Label4.Size = new System.Drawing.Size(87, 24);
            this.Label4.TabIndex = 5;
            this.Label4.Text = "Surname";
            // 
            // Label5
            // 
            this.Label5.AutoSize = true;
            this.Label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label5.Location = new System.Drawing.Point(38, 228);
            this.Label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label5.Name = "Label5";
            this.Label5.Size = new System.Drawing.Size(80, 24);
            this.Label5.TabIndex = 7;
            this.Label5.Text = "Address";
            // 
            // txtAddr1
            // 
            this.txtAddr1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAddr1.Location = new System.Drawing.Point(172, 225);
            this.txtAddr1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAddr1.MaxLength = 50;
            this.txtAddr1.Name = "txtAddr1";
            this.txtAddr1.Size = new System.Drawing.Size(353, 29);
            this.txtAddr1.TabIndex = 8;
            // 
            // txtAddr2
            // 
            this.txtAddr2.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtAddr2.Location = new System.Drawing.Point(172, 260);
            this.txtAddr2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtAddr2.MaxLength = 50;
            this.txtAddr2.Name = "txtAddr2";
            this.txtAddr2.Size = new System.Drawing.Size(353, 29);
            this.txtAddr2.TabIndex = 9;
            // 
            // Label6
            // 
            this.Label6.AutoSize = true;
            this.Label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label6.Location = new System.Drawing.Point(38, 298);
            this.Label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label6.Name = "Label6";
            this.Label6.Size = new System.Drawing.Size(58, 24);
            this.Label6.TabIndex = 10;
            this.Label6.Text = "Town";
            // 
            // txtTown
            // 
            this.txtTown.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTown.Location = new System.Drawing.Point(172, 295);
            this.txtTown.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTown.MaxLength = 50;
            this.txtTown.Name = "txtTown";
            this.txtTown.Size = new System.Drawing.Size(353, 29);
            this.txtTown.TabIndex = 11;
            // 
            // Label7
            // 
            this.Label7.AutoSize = true;
            this.Label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label7.Location = new System.Drawing.Point(38, 333);
            this.Label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label7.Name = "Label7";
            this.Label7.Size = new System.Drawing.Size(69, 24);
            this.Label7.TabIndex = 12;
            this.Label7.Text = "County";
            // 
            // txtCounty
            // 
            this.txtCounty.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtCounty.Location = new System.Drawing.Point(172, 330);
            this.txtCounty.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtCounty.MaxLength = 50;
            this.txtCounty.Name = "txtCounty";
            this.txtCounty.Size = new System.Drawing.Size(353, 29);
            this.txtCounty.TabIndex = 13;
            // 
            // Label8
            // 
            this.Label8.AutoSize = true;
            this.Label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label8.Location = new System.Drawing.Point(38, 368);
            this.Label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label8.Name = "Label8";
            this.Label8.Size = new System.Drawing.Size(89, 24);
            this.Label8.TabIndex = 14;
            this.Label8.Text = "Postcode";
            // 
            // txtPostcode
            // 
            this.txtPostcode.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtPostcode.Location = new System.Drawing.Point(172, 365);
            this.txtPostcode.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtPostcode.MaxLength = 8;
            this.txtPostcode.Name = "txtPostcode";
            this.txtPostcode.Size = new System.Drawing.Size(242, 29);
            this.txtPostcode.TabIndex = 15;
            // 
            // Label9
            // 
            this.Label9.AutoSize = true;
            this.Label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label9.Location = new System.Drawing.Point(38, 417);
            this.Label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label9.Name = "Label9";
            this.Label9.Size = new System.Drawing.Size(103, 24);
            this.Label9.TabIndex = 16;
            this.Label9.Text = "Telephone";
            // 
            // txtTelephone
            // 
            this.txtTelephone.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtTelephone.Location = new System.Drawing.Point(172, 414);
            this.txtTelephone.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtTelephone.MaxLength = 11;
            this.txtTelephone.Name = "txtTelephone";
            this.txtTelephone.Size = new System.Drawing.Size(242, 29);
            this.txtTelephone.TabIndex = 17;
            this.txtTelephone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtTelephone_KeyPress);
            // 
            // Label10
            // 
            this.Label10.AutoSize = true;
            this.Label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label10.Location = new System.Drawing.Point(652, 228);
            this.Label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label10.Name = "Label10";
            this.Label10.Size = new System.Drawing.Size(77, 24);
            this.Label10.TabIndex = 19;
            this.Label10.Text = "Birthday";
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnCancel.Location = new System.Drawing.Point(59, 655);
            this.btnCancel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(240, 69);
            this.btnCancel.TabIndex = 32;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnFinished
            // 
            this.btnFinished.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnFinished.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnFinished.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.btnFinished.Location = new System.Drawing.Point(1011, 655);
            this.btnFinished.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.btnFinished.Name = "btnFinished";
            this.btnFinished.Size = new System.Drawing.Size(240, 69);
            this.btnFinished.TabIndex = 31;
            this.btnFinished.Text = "Continue";
            this.btnFinished.UseVisualStyleBackColor = false;
            this.btnFinished.Click += new System.EventHandler(this.btnFinished_Click);
            // 
            // chkTape
            // 
            this.chkTape.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkTape.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkTape.Location = new System.Drawing.Point(652, 137);
            this.chkTape.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkTape.Name = "chkTape";
            this.chkTape.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkTape.Size = new System.Drawing.Size(287, 43);
            this.chkTape.TabIndex = 18;
            this.chkTape.Text = "Memory stick player issued";
            this.chkTape.UseVisualStyleBackColor = true;
            // 
            // chkMagazine
            // 
            this.chkMagazine.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkMagazine.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkMagazine.Location = new System.Drawing.Point(652, 175);
            this.chkMagazine.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkMagazine.Name = "chkMagazine";
            this.chkMagazine.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkMagazine.Size = new System.Drawing.Size(287, 37);
            this.chkMagazine.TabIndex = 19;
            this.chkMagazine.Text = "Magazine";
            this.chkMagazine.UseVisualStyleBackColor = true;
            // 
            // Label12
            // 
            this.Label12.AutoSize = true;
            this.Label12.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.Label12.Location = new System.Drawing.Point(660, 378);
            this.Label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.Label12.Name = "Label12";
            this.Label12.Size = new System.Drawing.Size(107, 24);
            this.Label12.TabIndex = 25;
            this.Label12.Text = "Information:";
            // 
            // txtInformation
            // 
            this.txtInformation.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.txtInformation.Location = new System.Drawing.Point(667, 423);
            this.txtInformation.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.txtInformation.MaxLength = 1000;
            this.txtInformation.Multiline = true;
            this.txtInformation.Name = "txtInformation";
            this.txtInformation.Size = new System.Drawing.Size(602, 200);
            this.txtInformation.TabIndex = 30;
            // 
            // chkNoBirthday
            // 
            this.chkNoBirthday.AutoSize = true;
            this.chkNoBirthday.BackColor = System.Drawing.Color.Transparent;
            this.chkNoBirthday.Checked = true;
            this.chkNoBirthday.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkNoBirthday.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkNoBirthday.Location = new System.Drawing.Point(848, 263);
            this.chkNoBirthday.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkNoBirthday.Name = "chkNoBirthday";
            this.chkNoBirthday.Size = new System.Drawing.Size(205, 29);
            this.chkNoBirthday.TabIndex = 22;
            this.chkNoBirthday.Text = "Birthday Unknown";
            this.chkNoBirthday.UseVisualStyleBackColor = false;
            this.chkNoBirthday.CheckedChanged += new System.EventHandler(this.chkNoBirthday_CheckedChanged);
            this.chkNoBirthday.Validating += new System.ComponentModel.CancelEventHandler(this.chkNoBirthday_Validating);
            // 
            // cbxBirthdayDay
            // 
            this.cbxBirthdayDay.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.cbxBirthdayDay.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cbxBirthdayDay.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBirthdayDay.Enabled = false;
            this.cbxBirthdayDay.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxBirthdayDay.FormattingEnabled = true;
            this.cbxBirthdayDay.Location = new System.Drawing.Point(765, 225);
            this.cbxBirthdayDay.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxBirthdayDay.MaxDropDownItems = 10;
            this.cbxBirthdayDay.Name = "cbxBirthdayDay";
            this.cbxBirthdayDay.Size = new System.Drawing.Size(84, 32);
            this.cbxBirthdayDay.TabIndex = 20;
            this.cbxBirthdayDay.Validating += new System.ComponentModel.CancelEventHandler(this.cbxBirthdayDay_Validating);
            // 
            // cbxBirthdayMonth
            // 
            this.cbxBirthdayMonth.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbxBirthdayMonth.Enabled = false;
            this.cbxBirthdayMonth.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.cbxBirthdayMonth.FormattingEnabled = true;
            this.cbxBirthdayMonth.Location = new System.Drawing.Point(857, 225);
            this.cbxBirthdayMonth.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.cbxBirthdayMonth.Name = "cbxBirthdayMonth";
            this.cbxBirthdayMonth.Size = new System.Drawing.Size(196, 32);
            this.cbxBirthdayMonth.TabIndex = 21;
            this.cbxBirthdayMonth.Validating += new System.ComponentModel.CancelEventHandler(this.cbxBirthdayMonth_Validating);
            // 
            // errorProvider
            // 
            this.errorProvider.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this.errorProvider.ContainerControl = this;
            // 
            // chkOnlineOnly
            // 
            this.chkOnlineOnly.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.chkOnlineOnly.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.chkOnlineOnly.Location = new System.Drawing.Point(652, 99);
            this.chkOnlineOnly.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.chkOnlineOnly.Name = "chkOnlineOnly";
            this.chkOnlineOnly.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.chkOnlineOnly.Size = new System.Drawing.Size(287, 43);
            this.chkOnlineOnly.TabIndex = 33;
            this.chkOnlineOnly.Text = "Online only";
            this.chkOnlineOnly.UseVisualStyleBackColor = true;
            this.chkOnlineOnly.CheckedChanged += new System.EventHandler(this.chkOnlineOnly_CheckedChanged);
            // 
            // FormAddFull
            // 
            this.AcceptButton = this.btnFinished;
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(1315, 757);
            this.Controls.Add(this.chkOnlineOnly);
            this.Controls.Add(this.cbxBirthdayMonth);
            this.Controls.Add(this.cbxBirthdayDay);
            this.Controls.Add(this.chkNoBirthday);
            this.Controls.Add(this.txtInformation);
            this.Controls.Add(this.Label12);
            this.Controls.Add(this.chkMagazine);
            this.Controls.Add(this.chkTape);
            this.Controls.Add(this.btnFinished);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.Label10);
            this.Controls.Add(this.txtTelephone);
            this.Controls.Add(this.Label9);
            this.Controls.Add(this.txtPostcode);
            this.Controls.Add(this.Label8);
            this.Controls.Add(this.txtCounty);
            this.Controls.Add(this.Label7);
            this.Controls.Add(this.txtTown);
            this.Controls.Add(this.Label6);
            this.Controls.Add(this.txtAddr2);
            this.Controls.Add(this.txtAddr1);
            this.Controls.Add(this.Label5);
            this.Controls.Add(this.txtForename);
            this.Controls.Add(this.Label4);
            this.Controls.Add(this.txtSurname);
            this.Controls.Add(this.Label3);
            this.Controls.Add(this.comboTitle);
            this.Controls.Add(this.Label2);
            this.Controls.Add(this.Label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormAddFull";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormAddFull_FormClosing);
            this.Load += new System.EventHandler(this.FormAddFull_Load);
            ((System.ComponentModel.ISupportInitialize)(this.errorProvider)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}
		internal System.Windows.Forms.Label Label1;
		internal System.Windows.Forms.Label Label2;
		internal System.Windows.Forms.ComboBox comboTitle;
		internal System.Windows.Forms.Label Label3;
		internal System.Windows.Forms.TextBox txtSurname;
		internal System.Windows.Forms.TextBox txtForename;
		internal System.Windows.Forms.Label Label4;
		internal System.Windows.Forms.Label Label5;
		internal System.Windows.Forms.TextBox txtAddr1;
		internal System.Windows.Forms.TextBox txtAddr2;
		internal System.Windows.Forms.Label Label6;
		internal System.Windows.Forms.TextBox txtTown;
		internal System.Windows.Forms.Label Label7;
		internal System.Windows.Forms.TextBox txtCounty;
		internal System.Windows.Forms.Label Label8;
		internal System.Windows.Forms.TextBox txtPostcode;
		internal System.Windows.Forms.Label Label9;
        private System.Windows.Forms.TextBox txtTelephone;
		internal System.Windows.Forms.Label Label10;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Button btnFinished;
		internal System.Windows.Forms.CheckBox chkTape;
		internal System.Windows.Forms.CheckBox chkMagazine;
		internal System.Windows.Forms.Label Label12;
		internal System.Windows.Forms.TextBox txtInformation;
        private System.Windows.Forms.CheckBox chkNoBirthday;
        private ComboBox cbxBirthdayDay;
        private ComboBox cbxBirthdayMonth;
        private ErrorProvider errorProvider;
        internal CheckBox chkOnlineOnly;
    }
}
