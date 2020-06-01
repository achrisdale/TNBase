namespace TNBase.Forms
{
    partial class FormDelete
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormDelete));
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.listenerDetailsLabel = new System.Windows.Forms.Label();
            this.memStickQuestionLabel = new System.Windows.Forms.Label();
            this.yesMemStickRadioButton = new System.Windows.Forms.RadioButton();
            this.noMemStickRadioButton = new System.Windows.Forms.RadioButton();
            this.memStickGroupBox = new System.Windows.Forms.GroupBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.memStickGroupBox.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnDelete
            // 
            this.btnDelete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(128)))));
            this.btnDelete.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btnDelete.Enabled = false;
            this.btnDelete.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelete.Location = new System.Drawing.Point(145, 239);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(327, 58);
            this.btnDelete.TabIndex = 3;
            this.btnDelete.Text = "Mark for deletion";
            this.btnDelete.UseVisualStyleBackColor = false;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(128)))));
            this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnCancel.Font = new System.Drawing.Font("Microsoft Sans Serif", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(474, 239);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(128, 58);
            this.btnCancel.TabIndex = 4;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(460, 24);
            this.label1.TabIndex = 35;
            this.label1.Text = "Are you sure you want to delete the following listener?";
            // 
            // listenerDetailsLabel
            // 
            this.listenerDetailsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.listenerDetailsLabel.Location = new System.Drawing.Point(30, 52);
            this.listenerDetailsLabel.Name = "listenerDetailsLabel";
            this.listenerDetailsLabel.Size = new System.Drawing.Size(541, 114);
            this.listenerDetailsLabel.TabIndex = 36;
            this.listenerDetailsLabel.Text = "Listener Details";
            // 
            // memStickQuestionLabel
            // 
            this.memStickQuestionLabel.AutoSize = true;
            this.memStickQuestionLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.memStickQuestionLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(192)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.memStickQuestionLabel.Location = new System.Drawing.Point(6, 16);
            this.memStickQuestionLabel.Name = "memStickQuestionLabel";
            this.memStickQuestionLabel.Size = new System.Drawing.Size(400, 24);
            this.memStickQuestionLabel.TabIndex = 37;
            this.memStickQuestionLabel.Text = "Did the listener return the memory stick player?";
            // 
            // yesMemStickRadioButton
            // 
            this.yesMemStickRadioButton.AutoSize = true;
            this.yesMemStickRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesMemStickRadioButton.Location = new System.Drawing.Point(437, 14);
            this.yesMemStickRadioButton.Name = "yesMemStickRadioButton";
            this.yesMemStickRadioButton.Size = new System.Drawing.Size(60, 28);
            this.yesMemStickRadioButton.TabIndex = 1;
            this.yesMemStickRadioButton.TabStop = true;
            this.yesMemStickRadioButton.Text = "Yes";
            this.yesMemStickRadioButton.UseVisualStyleBackColor = true;
            this.yesMemStickRadioButton.CheckedChanged += new System.EventHandler(this.memStickRadioButton_CheckedChanged);
            // 
            // noMemStickRadioButton
            // 
            this.noMemStickRadioButton.AutoSize = true;
            this.noMemStickRadioButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noMemStickRadioButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.noMemStickRadioButton.Location = new System.Drawing.Point(512, 14);
            this.noMemStickRadioButton.Name = "noMemStickRadioButton";
            this.noMemStickRadioButton.Size = new System.Drawing.Size(53, 28);
            this.noMemStickRadioButton.TabIndex = 2;
            this.noMemStickRadioButton.TabStop = true;
            this.noMemStickRadioButton.Text = "No";
            this.noMemStickRadioButton.UseVisualStyleBackColor = true;
            this.noMemStickRadioButton.CheckedChanged += new System.EventHandler(this.memStickRadioButton_CheckedChanged);
            // 
            // memStickGroupBox
            // 
            this.memStickGroupBox.Controls.Add(this.memStickQuestionLabel);
            this.memStickGroupBox.Controls.Add(this.noMemStickRadioButton);
            this.memStickGroupBox.Controls.Add(this.yesMemStickRadioButton);
            this.memStickGroupBox.Location = new System.Drawing.Point(12, 169);
            this.memStickGroupBox.Name = "memStickGroupBox";
            this.memStickGroupBox.Size = new System.Drawing.Size(590, 51);
            this.memStickGroupBox.TabIndex = 41;
            this.memStickGroupBox.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel});
            this.statusStrip1.Location = new System.Drawing.Point(0, 313);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(614, 22);
            this.statusStrip1.SizingGrip = false;
            this.statusStrip1.TabIndex = 43;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel
            // 
            this.toolStripStatusLabel.Name = "toolStripStatusLabel";
            this.toolStripStatusLabel.Size = new System.Drawing.Size(112, 17);
            this.toolStripStatusLabel.Text = "toolStripStatusLabel";
            // 
            // FormDelete
            // 
            this.AcceptButton = this.btnDelete;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnCancel;
            this.ClientSize = new System.Drawing.Size(614, 335);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.memStickGroupBox);
            this.Controls.Add(this.listenerDetailsLabel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "FormDelete";
            this.Text = "Delete Listener";
            this.memStickGroupBox.ResumeLayout(false);
            this.memStickGroupBox.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label listenerDetailsLabel;
        private System.Windows.Forms.Label memStickQuestionLabel;
        private System.Windows.Forms.RadioButton yesMemStickRadioButton;
        private System.Windows.Forms.RadioButton noMemStickRadioButton;
        private System.Windows.Forms.GroupBox memStickGroupBox;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel;
    }
}