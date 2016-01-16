namespace Crestline.DNSMEU
{
    partial class Form1
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
			this.btnUpdate = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.txtDNSRecordID = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtPassword = new System.Windows.Forms.TextBox();
			this.btnCancel = new System.Windows.Forms.Button();
			this.label3 = new System.Windows.Forms.Label();
			this.txtIP = new System.Windows.Forms.TextBox();
			this.lblStatus = new System.Windows.Forms.Label();
			this.btnSaveSettings = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnUpdate
			// 
			this.btnUpdate.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnUpdate.Location = new System.Drawing.Point(216, 154);
			this.btnUpdate.Name = "btnUpdate";
			this.btnUpdate.Size = new System.Drawing.Size(75, 29);
			this.btnUpdate.TabIndex = 0;
			this.btnUpdate.Text = "Update";
			this.btnUpdate.UseVisualStyleBackColor = true;
			this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(12, 9);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(104, 17);
			this.label1.TabIndex = 1;
			this.label1.Text = "DNS Record ID";
			// 
			// txtDNSRecordID
			// 
			this.txtDNSRecordID.Location = new System.Drawing.Point(122, 6);
			this.txtDNSRecordID.Name = "txtDNSRecordID";
			this.txtDNSRecordID.Size = new System.Drawing.Size(250, 22);
			this.txtDNSRecordID.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(12, 37);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(69, 17);
			this.label2.TabIndex = 3;
			this.label2.Text = "Password";
			// 
			// txtPassword
			// 
			this.txtPassword.Location = new System.Drawing.Point(122, 37);
			this.txtPassword.Name = "txtPassword";
			this.txtPassword.Size = new System.Drawing.Size(250, 22);
			this.txtPassword.TabIndex = 4;
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(297, 154);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(75, 29);
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Close";
			this.btnCancel.UseVisualStyleBackColor = true;
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// label3
			// 
			this.label3.AutoSize = true;
			this.label3.Location = new System.Drawing.Point(12, 66);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(20, 17);
			this.label3.TabIndex = 6;
			this.label3.Text = "IP";
			// 
			// txtIP
			// 
			this.txtIP.Location = new System.Drawing.Point(122, 66);
			this.txtIP.Name = "txtIP";
			this.txtIP.Size = new System.Drawing.Size(250, 22);
			this.txtIP.TabIndex = 7;
			// 
			// lblStatus
			// 
			this.lblStatus.AutoSize = true;
			this.lblStatus.Location = new System.Drawing.Point(12, 116);
			this.lblStatus.Name = "lblStatus";
			this.lblStatus.Size = new System.Drawing.Size(0, 17);
			this.lblStatus.TabIndex = 8;
			// 
			// btnSaveSettings
			// 
			this.btnSaveSettings.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.btnSaveSettings.Location = new System.Drawing.Point(99, 154);
			this.btnSaveSettings.Name = "btnSaveSettings";
			this.btnSaveSettings.Size = new System.Drawing.Size(111, 29);
			this.btnSaveSettings.TabIndex = 9;
			this.btnSaveSettings.Text = "Save Settings";
			this.btnSaveSettings.UseVisualStyleBackColor = true;
			this.btnSaveSettings.Click += new System.EventHandler(this.btnSaveSettings_Click);
			// 
			// Form1
			// 
			this.AcceptButton = this.btnUpdate;
			this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(391, 199);
			this.Controls.Add(this.btnSaveSettings);
			this.Controls.Add(this.lblStatus);
			this.Controls.Add(this.txtIP);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.btnCancel);
			this.Controls.Add(this.txtPassword);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.txtDNSRecordID);
			this.Controls.Add(this.label1);
			this.Controls.Add(this.btnUpdate);
			this.Name = "Form1";
			this.Text = "DNSMEU Config";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.ResumeLayout(false);
			this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDNSRecordID;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtPassword;
        private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtIP;
		private System.Windows.Forms.Label lblStatus;
		private System.Windows.Forms.Button btnSaveSettings;
	}
}

