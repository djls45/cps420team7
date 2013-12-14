namespace CheckTracker
{
    partial class HistoryForm
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
            this.CheckGridView = new System.Windows.Forms.DataGridView();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.selectDatesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.StatusBox = new System.Windows.Forms.ToolStripComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.CheckGridView)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // CheckGridView
            // 
            this.CheckGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.CheckGridView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CheckGridView.Location = new System.Drawing.Point(0, 27);
            this.CheckGridView.Name = "CheckGridView";
            this.CheckGridView.Size = new System.Drawing.Size(344, 235);
            this.CheckGridView.TabIndex = 0;
            this.CheckGridView.ColumnHeaderMouseClick += new System.Windows.Forms.DataGridViewCellMouseEventHandler(this.GridViewHeaderClick);
            this.CheckGridView.DataError += new System.Windows.Forms.DataGridViewDataErrorEventHandler(this.HandleDataError);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.selectDatesToolStripMenuItem,
            this.StatusBox});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(344, 27);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // selectDatesToolStripMenuItem
            // 
            this.selectDatesToolStripMenuItem.Name = "selectDatesToolStripMenuItem";
            this.selectDatesToolStripMenuItem.Size = new System.Drawing.Size(91, 23);
            this.selectDatesToolStripMenuItem.Text = "&Select Dates...";
            this.selectDatesToolStripMenuItem.Click += new System.EventHandler(this.selectDatesToolStripMenuItem_Click);
            // 
            // StatusBox
            // 
            this.StatusBox.Items.AddRange(new object[] {
            "All",
            "Phase 1",
            "Phase 2",
            "Phase 3",
            "Paid",
            "Deleted"});
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.Size = new System.Drawing.Size(121, 23);
            this.StatusBox.Text = "All";
            this.StatusBox.SelectedIndexChanged += new System.EventHandler(this.IndexChangedUpdateView);
            // 
            // HistoryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(344, 262);
            this.Controls.Add(this.CheckGridView);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "HistoryForm";
            this.ShowIcon = false;
            this.Text = "CheckHistoryForm";
            ((System.ComponentModel.ISupportInitialize)(this.CheckGridView)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView CheckGridView;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem selectDatesToolStripMenuItem;
        private System.Windows.Forms.ToolStripComboBox StatusBox;
    }
}