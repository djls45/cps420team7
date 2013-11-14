namespace CheckTracker
{
    partial class AccountForm
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEditBank = new System.Windows.Forms.Button();
            this.BankChoice = new System.Windows.Forms.ComboBox();
            this.AccountBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditOwner = new System.Windows.Forms.Button();
            this.OwnerChoice = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditOwner);
            this.groupBox1.Controls.Add(this.OwnerChoice);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.AccountBox);
            this.groupBox1.Controls.Add(this.btnEditBank);
            this.groupBox1.Controls.Add(this.BankChoice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Location = new System.Drawing.Point(13, 13);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(391, 109);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Account Information";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Bank*";
            // 
            // btnEditBank
            // 
            this.btnEditBank.Location = new System.Drawing.Point(301, 17);
            this.btnEditBank.Name = "btnEditBank";
            this.btnEditBank.Size = new System.Drawing.Size(75, 23);
            this.btnEditBank.TabIndex = 10;
            this.btnEditBank.Text = "Edit";
            this.btnEditBank.UseVisualStyleBackColor = true;
            this.btnEditBank.Click += new System.EventHandler(this.btnEditBank_Click);
            // 
            // BankChoice
            // 
            this.BankChoice.FormattingEnabled = true;
            this.BankChoice.Location = new System.Drawing.Point(118, 19);
            this.BankChoice.Name = "BankChoice";
            this.BankChoice.Size = new System.Drawing.Size(183, 21);
            this.BankChoice.TabIndex = 9;
            // 
            // AccountBox
            // 
            this.AccountBox.Location = new System.Drawing.Point(118, 73);
            this.AccountBox.Name = "AccountBox";
            this.AccountBox.Size = new System.Drawing.Size(183, 20);
            this.AccountBox.TabIndex = 11;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(21, 76);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(91, 13);
            this.label1.TabIndex = 12;
            this.label1.Text = "Account Number*";
            // 
            // btnEditOwner
            // 
            this.btnEditOwner.Location = new System.Drawing.Point(301, 44);
            this.btnEditOwner.Name = "btnEditOwner";
            this.btnEditOwner.Size = new System.Drawing.Size(75, 23);
            this.btnEditOwner.TabIndex = 15;
            this.btnEditOwner.Text = "Edit";
            this.btnEditOwner.UseVisualStyleBackColor = true;
            this.btnEditOwner.Click += new System.EventHandler(this.btnEditOwner_Click);
            // 
            // OwnerChoice
            // 
            this.OwnerChoice.FormattingEnabled = true;
            this.OwnerChoice.Location = new System.Drawing.Point(118, 46);
            this.OwnerChoice.Name = "OwnerChoice";
            this.OwnerChoice.Size = new System.Drawing.Size(183, 21);
            this.OwnerChoice.TabIndex = 14;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(70, 49);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(42, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Owner*";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(232, 129);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(313, 129);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // AccountForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(421, 168);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "AccountForm";
            this.Text = "AccountForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnEditOwner;
        private System.Windows.Forms.ComboBox OwnerChoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox AccountBox;
        private System.Windows.Forms.Button btnEditBank;
        private System.Windows.Forms.ComboBox BankChoice;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
    }
}