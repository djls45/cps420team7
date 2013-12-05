namespace CheckTracker
{
    partial class EmployeeForm
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
            this.btnSave = new System.Windows.Forms.Button();
            this.btnCancel = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.StoreChoice = new System.Windows.Forms.ComboBox();
            this.SupervisorChoice = new System.Windows.Forms.ComboBox();
            this.LNameBox = new System.Windows.Forms.TextBox();
            this.FNameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEditSupervisor = new System.Windows.Forms.Button();
            this.btnEditStore = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.UsernameBox = new System.Windows.Forms.TextBox();
            this.Password1Box = new System.Windows.Forms.TextBox();
            this.Password2Box = new System.Windows.Forms.TextBox();
            this.TypeChoice = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(188, 256);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(269, 256);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 23);
            this.btnCancel.TabIndex = 1;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.TypeChoice);
            this.groupBox1.Controls.Add(this.Password2Box);
            this.groupBox1.Controls.Add(this.Password1Box);
            this.groupBox1.Controls.Add(this.UsernameBox);
            this.groupBox1.Controls.Add(this.label8);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.btnEditStore);
            this.groupBox1.Controls.Add(this.btnEditSupervisor);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.StoreChoice);
            this.groupBox1.Controls.Add(this.SupervisorChoice);
            this.groupBox1.Controls.Add(this.LNameBox);
            this.groupBox1.Controls.Add(this.FNameBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(332, 238);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Employee Information";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(63, 205);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(32, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Store";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(38, 178);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(57, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Supervisor";
            // 
            // StoreChoice
            // 
            this.StoreChoice.FormattingEnabled = true;
            this.StoreChoice.Location = new System.Drawing.Point(101, 202);
            this.StoreChoice.Name = "StoreChoice";
            this.StoreChoice.Size = new System.Drawing.Size(135, 21);
            this.StoreChoice.TabIndex = 7;
            // 
            // SupervisorChoice
            // 
            this.SupervisorChoice.FormattingEnabled = true;
            this.SupervisorChoice.Location = new System.Drawing.Point(101, 175);
            this.SupervisorChoice.Name = "SupervisorChoice";
            this.SupervisorChoice.Size = new System.Drawing.Size(135, 21);
            this.SupervisorChoice.TabIndex = 6;
            // 
            // LNameBox
            // 
            this.LNameBox.Location = new System.Drawing.Point(101, 45);
            this.LNameBox.Name = "LNameBox";
            this.LNameBox.Size = new System.Drawing.Size(216, 20);
            this.LNameBox.TabIndex = 4;
            // 
            // FNameBox
            // 
            this.FNameBox.Location = new System.Drawing.Point(101, 19);
            this.FNameBox.Name = "FNameBox";
            this.FNameBox.Size = new System.Drawing.Size(216, 20);
            this.FNameBox.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(64, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(35, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Type*";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(37, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name*";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(38, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(61, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name*";
            // 
            // btnEditSupervisor
            // 
            this.btnEditSupervisor.Location = new System.Drawing.Point(242, 173);
            this.btnEditSupervisor.Name = "btnEditSupervisor";
            this.btnEditSupervisor.Size = new System.Drawing.Size(75, 23);
            this.btnEditSupervisor.TabIndex = 10;
            this.btnEditSupervisor.Text = "Edit...";
            this.btnEditSupervisor.UseVisualStyleBackColor = true;
            this.btnEditSupervisor.Click += new System.EventHandler(this.btnEditSupervisor_Click);
            // 
            // btnEditStore
            // 
            this.btnEditStore.Location = new System.Drawing.Point(242, 200);
            this.btnEditStore.Name = "btnEditStore";
            this.btnEditStore.Size = new System.Drawing.Size(75, 23);
            this.btnEditStore.TabIndex = 11;
            this.btnEditStore.Text = "Edit...";
            this.btnEditStore.UseVisualStyleBackColor = true;
            this.btnEditStore.Click += new System.EventHandler(this.btnEditStore_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 100);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(55, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Username";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(42, 126);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(53, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "Password";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 152);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Retype password";
            // 
            // UsernameBox
            // 
            this.UsernameBox.Location = new System.Drawing.Point(101, 97);
            this.UsernameBox.Name = "UsernameBox";
            this.UsernameBox.Size = new System.Drawing.Size(216, 20);
            this.UsernameBox.TabIndex = 15;
            // 
            // Password1Box
            // 
            this.Password1Box.Location = new System.Drawing.Point(101, 123);
            this.Password1Box.Name = "Password1Box";
            this.Password1Box.Size = new System.Drawing.Size(216, 20);
            this.Password1Box.TabIndex = 16;
            // 
            // Password2Box
            // 
            this.Password2Box.Location = new System.Drawing.Point(101, 149);
            this.Password2Box.Name = "Password2Box";
            this.Password2Box.Size = new System.Drawing.Size(216, 20);
            this.Password2Box.TabIndex = 17;
            // 
            // TypeChoice
            // 
            this.TypeChoice.FormattingEnabled = true;
            this.TypeChoice.Items.AddRange(new object[] {
            "U - User",
            "M - Manager",
            "A - Administrator"});
            this.TypeChoice.Location = new System.Drawing.Point(101, 70);
            this.TypeChoice.Name = "TypeChoice";
            this.TypeChoice.Size = new System.Drawing.Size(216, 21);
            this.TypeChoice.TabIndex = 18;
            // 
            // EmployeeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(364, 296);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancel);
            this.Controls.Add(this.btnSave);
            this.Name = "EmployeeForm";
            this.Text = "EmployeeForm";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        public System.Windows.Forms.TextBox LNameBox;
        public System.Windows.Forms.TextBox FNameBox;
        public System.Windows.Forms.ComboBox StoreChoice;
        public System.Windows.Forms.ComboBox SupervisorChoice;
        private System.Windows.Forms.Button btnEditStore;
        private System.Windows.Forms.Button btnEditSupervisor;
        private System.Windows.Forms.TextBox Password2Box;
        private System.Windows.Forms.TextBox Password1Box;
        private System.Windows.Forms.TextBox UsernameBox;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox TypeChoice;
    }
}