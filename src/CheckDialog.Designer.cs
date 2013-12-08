namespace CheckTracker
{
    partial class CheckDialog
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.label8 = new System.Windows.Forms.Label();
            this.checkNumBox = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.recipientBox = new System.Windows.Forms.TextBox();
            this.imageFileBox = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.amountBox = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnEditAccount = new System.Windows.Forms.Button();
            this.AccountChoice = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.btnEditAddress = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.AddressChoice = new System.Windows.Forms.ComboBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.LongAmountText = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.browseButton = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.StatusChoice = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(347, 325);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 5;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(266, 325);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(266, 22);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(78, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Check Number";
            // 
            // checkNumBox
            // 
            this.checkNumBox.Location = new System.Drawing.Point(350, 19);
            this.checkNumBox.Name = "checkNumBox";
            this.checkNumBox.Size = new System.Drawing.Size(54, 20);
            this.checkNumBox.TabIndex = 1;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(42, 48);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(52, 13);
            this.label12.TabIndex = 5;
            this.label12.Text = "Recipient";
            // 
            // recipientBox
            // 
            this.recipientBox.Location = new System.Drawing.Point(100, 45);
            this.recipientBox.Name = "recipientBox";
            this.recipientBox.Size = new System.Drawing.Size(304, 20);
            this.recipientBox.TabIndex = 2;
            // 
            // imageFileBox
            // 
            this.imageFileBox.Location = new System.Drawing.Point(9, 19);
            this.imageFileBox.Name = "imageFileBox";
            this.imageFileBox.Size = new System.Drawing.Size(239, 20);
            this.imageFileBox.TabIndex = 0;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(47, 22);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(47, 13);
            this.label9.TabIndex = 4;
            this.label9.Text = "Amount*";
            // 
            // amountBox
            // 
            this.amountBox.Location = new System.Drawing.Point(100, 19);
            this.amountBox.Name = "amountBox";
            this.amountBox.Size = new System.Drawing.Size(54, 20);
            this.amountBox.TabIndex = 0;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditAccount);
            this.groupBox1.Controls.Add(this.AccountChoice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.btnEditAddress);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.AddressChoice);
            this.groupBox1.Location = new System.Drawing.Point(12, 146);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(410, 85);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Customer Information";
            // 
            // btnEditAccount
            // 
            this.btnEditAccount.Location = new System.Drawing.Point(329, 45);
            this.btnEditAccount.Name = "btnEditAccount";
            this.btnEditAccount.Size = new System.Drawing.Size(75, 23);
            this.btnEditAccount.TabIndex = 3;
            this.btnEditAccount.Text = "Edit";
            this.btnEditAccount.UseVisualStyleBackColor = true;
            this.btnEditAccount.Click += new System.EventHandler(this.btnEditAccount_Click);
            // 
            // AccountChoice
            // 
            this.AccountChoice.FormattingEnabled = true;
            this.AccountChoice.Location = new System.Drawing.Point(91, 47);
            this.AccountChoice.Name = "AccountChoice";
            this.AccountChoice.Size = new System.Drawing.Size(238, 21);
            this.AccountChoice.TabIndex = 2;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(34, 50);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(51, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Account*";
            // 
            // btnEditAddress
            // 
            this.btnEditAddress.Location = new System.Drawing.Point(329, 17);
            this.btnEditAddress.Name = "btnEditAddress";
            this.btnEditAddress.Size = new System.Drawing.Size(75, 23);
            this.btnEditAddress.TabIndex = 1;
            this.btnEditAddress.Text = "Edit";
            this.btnEditAddress.UseVisualStyleBackColor = true;
            this.btnEditAddress.Click += new System.EventHandler(this.btnEditAddress_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(36, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Address*";
            // 
            // AddressChoice
            // 
            this.AddressChoice.FormattingEnabled = true;
            this.AddressChoice.Location = new System.Drawing.Point(91, 19);
            this.AddressChoice.Name = "AddressChoice";
            this.AddressChoice.Size = new System.Drawing.Size(238, 21);
            this.AddressChoice.TabIndex = 0;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.LongAmountText);
            this.groupBox2.Controls.Add(this.amountBox);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.recipientBox);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.checkNumBox);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Location = new System.Drawing.Point(12, 41);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(410, 99);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Check Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(67, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Text Amount";
            // 
            // LongAmountText
            // 
            this.LongAmountText.Location = new System.Drawing.Point(100, 71);
            this.LongAmountText.Name = "LongAmountText";
            this.LongAmountText.Size = new System.Drawing.Size(304, 20);
            this.LongAmountText.TabIndex = 3;
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.browseButton);
            this.groupBox3.Controls.Add(this.imageFileBox);
            this.groupBox3.Location = new System.Drawing.Point(12, 237);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(264, 82);
            this.groupBox3.TabIndex = 2;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Check Image File";
            // 
            // browseButton
            // 
            this.browseButton.Location = new System.Drawing.Point(173, 45);
            this.browseButton.Name = "browseButton";
            this.browseButton.Size = new System.Drawing.Size(75, 23);
            this.browseButton.TabIndex = 1;
            this.browseButton.Text = "Browse";
            this.browseButton.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(12, 9);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(261, 29);
            this.label10.TabIndex = 6;
            this.label10.Text = "Check Information Dialog";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.StatusChoice);
            this.groupBox4.Location = new System.Drawing.Point(282, 237);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(140, 82);
            this.groupBox4.TabIndex = 3;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Status";
            // 
            // StatusChoice
            // 
            this.StatusChoice.FormattingEnabled = true;
            this.StatusChoice.Items.AddRange(new object[] {
            "1st Phase",
            "2nd Phase",
            "3rd Phase",
            "Paid",
            "Deleted"});
            this.StatusChoice.Location = new System.Drawing.Point(6, 19);
            this.StatusChoice.Name = "StatusChoice";
            this.StatusChoice.Size = new System.Drawing.Size(128, 21);
            this.StatusChoice.TabIndex = 0;
            // 
            // CheckDialog
            // 
            this.AcceptButton = this.saveButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.ClientSize = new System.Drawing.Size(435, 358);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.saveButton);
            this.Name = "CheckDialog";
            this.ShowIcon = false;
            this.Text = "Check Dialog";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Button browseButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.TextBox checkNumBox;
        public System.Windows.Forms.TextBox amountBox;
        public System.Windows.Forms.TextBox recipientBox;
        public System.Windows.Forms.TextBox imageFileBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditAddress;
        private System.Windows.Forms.Button btnEditAccount;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox AddressChoice;
        public System.Windows.Forms.ComboBox AccountChoice;
        public System.Windows.Forms.TextBox LongAmountText;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.ComboBox StatusChoice;
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                    