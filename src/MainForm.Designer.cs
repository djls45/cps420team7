namespace CheckTracker
{
    partial class MainForm
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewHistoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.updateToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.employeesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemCreateEmployee = new System.Windows.Forms.ToolStripMenuItem();
            this.storesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.createStoreToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.changePasswordToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.printToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.allToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phase1ChecksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phase2ChecksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.phase3ChecksToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.selectedToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.checksBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.CheckDataGrid = new System.Windows.Forms.DataGridView();
            this.PrintCheckDialog = new System.Windows.Forms.PrintDialog();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checksBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckDataGrid)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.printToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(581, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openToolStripMenuItem,
            this.viewHistoryToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "&File";
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.openToolStripMenuItem.Text = "&Open...";
            // 
            // viewHistoryToolStripMenuItem
            // 
            this.viewHistoryToolStripMenuItem.Name = "viewHistoryToolStripMenuItem";
            this.viewHistoryToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.viewHistoryToolStripMenuItem.Text = "&View History";
            this.viewHistoryToolStripMenuItem.Click += new System.EventHandler(this.MenuChecksHistory);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(140, 22);
            this.exitToolStripMenuItem.Text = "Log Out/E&xit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.checksToolStripMenuItem,
            this.employeesToolStripMenuItem,
            this.storesToolStripMenuItem,
            this.changePasswordToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "&Edit";
            // 
            // checksToolStripMenuItem
            // 
            this.checksToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createToolStripMenuItem,
            this.updateToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.checksToolStripMenuItem.Name = "checksToolStripMenuItem";
            this.checksToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.checksToolStripMenuItem.Text = "Checks";
            // 
            // createToolStripMenuItem
            // 
            this.createToolStripMenuItem.Name = "createToolStripMenuItem";
            this.createToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.createToolStripMenuItem.Text = "&Create...";
            this.createToolStripMenuItem.Click += new System.EventHandler(this.MenuCreateCheck);
            // 
            // updateToolStripMenuItem
            // 
            this.updateToolStripMenuItem.Name = "updateToolStripMenuItem";
            this.updateToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.updateToolStripMenuItem.Text = "&Update...";
            this.updateToolStripMenuItem.Click += new System.EventHandler(this.MenuUpdateCheck);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(121, 22);
            this.deleteToolStripMenuItem.Text = "&Delete...";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.MenuDeleteCheck);
            // 
            // employeesToolStripMenuItem
            // 
            this.employeesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemCreateEmployee});
            this.employeesToolStripMenuItem.Name = "employeesToolStripMenuItem";
            this.employeesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.employeesToolStripMenuItem.Text = "Employees";
            // 
            // toolStripMenuItemCreateEmployee
            // 
            this.toolStripMenuItemCreateEmployee.Name = "toolStripMenuItemCreateEmployee";
            this.toolStripMenuItemCreateEmployee.Size = new System.Drawing.Size(172, 22);
            this.toolStripMenuItemCreateEmployee.Text = "Create Employee...";
            this.toolStripMenuItemCreateEmployee.Click += new System.EventHandler(this.MenuCreateEmployee);
            // 
            // storesToolStripMenuItem
            // 
            this.storesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.createStoreToolStripMenuItem});
            this.storesToolStripMenuItem.Name = "storesToolStripMenuItem";
            this.storesToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.storesToolStripMenuItem.Text = "Stores";
            // 
            // createStoreToolStripMenuItem
            // 
            this.createStoreToolStripMenuItem.Name = "createStoreToolStripMenuItem";
            this.createStoreToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.createStoreToolStripMenuItem.Text = "Create Store...";
            this.createStoreToolStripMenuItem.Click += new System.EventHandler(this.MenuCreateStore);
            // 
            // changePasswordToolStripMenuItem
            // 
            this.changePasswordToolStripMenuItem.Name = "changePasswordToolStripMenuItem";
            this.changePasswordToolStripMenuItem.Size = new System.Drawing.Size(177, 22);
            this.changePasswordToolStripMenuItem.Text = "Change Password...";
            this.changePasswordToolStripMenuItem.Click += new System.EventHandler(this.MenuChangePassword);
            // 
            // printToolStripMenuItem
            // 
            this.printToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.allToolStripMenuItem,
            this.phase1ChecksToolStripMenuItem,
            this.phase2ChecksToolStripMenuItem,
            this.phase3ChecksToolStripMenuItem,
            this.selectedToolStripMenuItem});
            this.printToolStripMenuItem.Name = "printToolStripMenuItem";
            this.printToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.printToolStripMenuItem.Text = "&Print";
            // 
            // allToolStripMenuItem
            // 
            this.allToolStripMenuItem.Name = "allToolStripMenuItem";
            this.allToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.allToolStripMenuItem.Text = "&All...";
            this.allToolStripMenuItem.Click += new System.EventHandler(this.MenuPrintAllChecks);
            // 
            // phase1ChecksToolStripMenuItem
            // 
            this.phase1ChecksToolStripMenuItem.Name = "phase1ChecksToolStripMenuItem";
            this.phase1ChecksToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.phase1ChecksToolStripMenuItem.Text = "Phase &1 Checks...";
            this.phase1ChecksToolStripMenuItem.Click += new System.EventHandler(this.MenuPrintP1Checks);
            // 
            // phase2ChecksToolStripMenuItem
            // 
            this.phase2ChecksToolStripMenuItem.Name = "phase2ChecksToolStripMenuItem";
            this.phase2ChecksToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.phase2ChecksToolStripMenuItem.Text = "Phase &2 Checks...";
            this.phase2ChecksToolStripMenuItem.Click += new System.EventHandler(this.MenuPrintP2Checks);
            // 
            // phase3ChecksToolStripMenuItem
            // 
            this.phase3ChecksToolStripMenuItem.Name = "phase3ChecksToolStripMenuItem";
            this.phase3ChecksToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.phase3ChecksToolStripMenuItem.Text = "Phase &3 Checks...";
            this.phase3ChecksToolStripMenuItem.Click += new System.EventHandler(this.MenuPrintP3Checks);
            // 
            // selectedToolStripMenuItem
            // 
            this.selectedToolStripMenuItem.Name = "selectedToolStripMenuItem";
            this.selectedToolStripMenuItem.Size = new System.Drawing.Size(164, 22);
            this.selectedToolStripMenuItem.Text = "&Selected...";
            this.selectedToolStripMenuItem.Click += new System.EventHandler(this.MenuPrintSelectedCheck);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "&Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(116, 22);
            this.aboutToolStripMenuItem.Text = "About...";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // checksBindingSource
            // 
            this.checksBindingSource.DataMember = "Checks";
            // 
            // CheckDataGrid
            // 
            this.CheckDataGrid.AllowUserToAddRows = false;
            this.CheckDataGrid.AllowUserToDeleteRows = false;
            this.CheckDataGrid.AllowUserToOrderColumns = true;
            this.CheckDataGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CheckDataGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckDataGrid.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.CheckDataGrid.Location = new System.Drawing.Point(0, 24);
            this.CheckDataGrid.MultiSelect = false;
            this.CheckDataGrid.Name = "CheckDataGrid";
            this.CheckDataGrid.ReadOnly = true;
            this.CheckDataGrid.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.CheckDataGrid.Size = new System.Drawing.Size(581, 349);
            this.CheckDataGrid.TabIndex = 2;
            this.CheckDataGrid.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.HandleDataError);
            // 
            // PrintCheckDialog
            // 
            this.PrintCheckDialog.UseEXDialog = true;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(581, 373);
            this.Controls.Add(this.CheckDataGrid);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Check Tracker";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainForm_FormClosed);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.checksBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.CheckDataGrid)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewHistoryToolStripMenuItem;
        private System.Windows.Forms.BindingSource checksBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkNumDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn amountDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn statusDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn employeeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateEnteredDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn recipientDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn imageFileDataGridViewTextBoxColumn;
        private System.Windows.Forms.ToolStripMenuItem changePasswordToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem checksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem updateToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem employeesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemCreateEmployee;
        private System.Windows.Forms.ToolStripMenuItem storesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem createStoreToolStripMenuItem;
        private System.Windows.Forms.DataGridView CheckDataGrid;
        private System.Windows.Forms.ToolStripMenuItem printToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phase1ChecksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phase2ChecksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem phase3ChecksToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem selectedToolStripMenuItem;
        private System.Windows.Forms.PrintDialog PrintCheckDialog;
        private System.Windows.Forms.ToolStripMenuItem allToolStripMenuItem;
    }
}

