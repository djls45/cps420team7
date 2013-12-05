namespace CheckTracker
{
    partial class StoreForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.NameBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.AddressChoice = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.ConfigChoice = new System.Windows.Forms.ComboBox();
            this.FormsChoice = new System.Windows.Forms.ComboBox();
            this.btnEditAddress = new System.Windows.Forms.Button();
            this.btnEditConfig = new System.Windows.Forms.Button();
            this.btnEditForms = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnEditForms);
            this.groupBox1.Controls.Add(this.btnEditConfig);
            this.groupBox1.Controls.Add(this.btnEditAddress);
            this.groupBox1.Controls.Add(this.FormsChoice);
            this.groupBox1.Controls.Add(this.ConfigChoice);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.AddressChoice);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.NameBox);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(15, 18);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(320, 138);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(179, 162);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 1;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(260, 162);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Name";
            // 
            // NameBox
            // 
            this.NameBox.Location = new System.Drawing.Point(81, 19);
            this.NameBox.Name = "NameBox";
            this.NameBox.Size = new System.Drawing.Size(201, 20);
            this.NameBox.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(30, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(45, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Address";
            // 
            // AddressChoice
            // 
            this.AddressChoice.FormattingEnabled = true;
            this.AddressChoice.Location = new System.Drawing.Point(81, 45);
            this.AddressChoice.Name = "AddressChoice";
            this.AddressChoice.Size = new System.Drawing.Size(120, 21);
            this.AddressChoice.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(69, 13);
            this.label3.TabIndex = 4;
            this.label3.Text = "Configuration";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(26, 102);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 13);
            this.label4.TabIndex = 5;
            this.label4.Text = "Form Set";
            // 
            // ConfigChoice
            // 
            this.ConfigChoice.FormattingEnabled = true;
            this.ConfigChoice.Location = new System.Drawing.Point(81, 72);
            this.ConfigChoice.Name = "ConfigChoice";
            this.ConfigChoice.Size = new System.Drawing.Size(120, 21);
            this.ConfigChoice.TabIndex = 6;
            // 
            // FormsChoice
            // 
            this.FormsChoice.FormattingEnabled = true;
            this.FormsChoice.Location = new System.Drawing.Point(81, 99);
            this.FormsChoice.Name = "FormsChoice";
            this.FormsChoice.Size = new System.Drawing.Size(120, 21);
            this.FormsChoice.TabIndex = 7;
            // 
            // btnEditAddress
            // 
            this.btnEditAddress.Location = new System.Drawing.Point(207, 43);
            this.btnEditAddress.Name = "btnEditAddress";
            this.btnEditAddress.Size = new System.Drawing.Size(75, 23);
            this.btnEditAddress.TabIndex = 8;
            this.btnEditAddress.Text = "Edit...";
            this.btnEditAddress.UseVisualStyleBackColor = true;
            this.btnEditAddress.Click += new System.EventHandler(this.btnEditAddress_Click);
            // 
            // btnEditConfig
            // 
            this.btnEditConfig.Location = new System.Drawing.Point(207, 70);
            this.btnEditConfig.Name = "btnEditConfig";
            this.btnEditConfig.Size = new System.Drawing.Size(75, 23);
            this.btnEditConfig.TabIndex = 9;
            this.btnEditConfig.Text = "Edit...";
            this.btnEditConfig.UseVisualStyleBackColor = true;
            this.btnEditConfig.Click += new System.EventHandler(this.btnEditConfig_Click);
            // 
            // btnEditForms
            // 
            this.btnEditForms.Location = new System.Drawing.Point(207, 97);
            this.btnEditForms.Name = "btnEditForms";
            this.btnEditForms.Size = new System.Drawing.Size(75, 23);
            this.btnEditForms.TabIndex = 10;
            this.btnEditForms.Text = "Edit...";
            this.btnEditForms.UseVisualStyleBackColor = true;
            this.btnEditForms.Click += new System.EventHandler(this.btnEditForms_Click);
            // 
            // StoreForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(353, 201);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.groupBox1);
            this.Name = "StoreForm";
            this.Text = "StoreForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox NameBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox AddressChoice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox FormsChoice;
        private System.Windows.Forms.ComboBox ConfigChoice;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnEditForms;
        private System.Windows.Forms.Button btnEditConfig;
        private System.Windows.Forms.Button btnEditAddress;
    }
}