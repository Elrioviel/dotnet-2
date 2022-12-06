
namespace TestResultsBrowser
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.FileStripMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitItem = new System.Windows.Forms.ToolStripMenuItem();
            this.filtersToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.loadToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.studentData = new System.Windows.Forms.DataGridView();
            this.filterByNameBtn = new System.Windows.Forms.Button();
            this.addBtn = new System.Windows.Forms.Button();
            this.filterBySurnameBtn = new System.Windows.Forms.Button();
            this.filterByTestBtn = new System.Windows.Forms.Button();
            this.FilterByDateBtn = new System.Windows.Forms.Button();
            this.FilterByScoreBtn = new System.Windows.Forms.Button();
            this.DiscardFilterBtn = new System.Windows.Forms.Button();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentData)).BeginInit();
            this.SuspendLayout();
            // 
            // FileStripMenu
            // 
            this.FileStripMenu.Name = "File";
            this.FileStripMenu.Size = new System.Drawing.Size(61, 4);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileItem,
            this.filtersToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1062, 29);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileItem
            // 
            this.fileItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.openItem,
            this.saveToolStripMenuItem,
            this.exitItem});
            this.fileItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.fileItem.Name = "fileItem";
            this.fileItem.Size = new System.Drawing.Size(46, 25);
            this.fileItem.Text = "File";
            // 
            // openItem
            // 
            this.openItem.Name = "openItem";
            this.openItem.Size = new System.Drawing.Size(180, 26);
            this.openItem.Text = "Open";
            this.openItem.Click += new System.EventHandler(this.openItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(180, 26);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // exitItem
            // 
            this.exitItem.Name = "exitItem";
            this.exitItem.Size = new System.Drawing.Size(180, 26);
            this.exitItem.Text = "Exit";
            this.exitItem.Click += new System.EventHandler(this.exitItem_Click);
            // 
            // filtersToolStripMenuItem
            // 
            this.filtersToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.loadToolStripMenuItem});
            this.filtersToolStripMenuItem.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filtersToolStripMenuItem.Name = "filtersToolStripMenuItem";
            this.filtersToolStripMenuItem.Size = new System.Drawing.Size(64, 25);
            this.filtersToolStripMenuItem.Text = "Filters";
            // 
            // loadToolStripMenuItem
            // 
            this.loadToolStripMenuItem.Name = "loadToolStripMenuItem";
            this.loadToolStripMenuItem.Size = new System.Drawing.Size(114, 26);
            this.loadToolStripMenuItem.Text = "Load";
            this.loadToolStripMenuItem.Click += new System.EventHandler(this.loadToolStripMenuItem_Click);
            // 
            // studentData
            // 
            this.studentData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.studentData.Location = new System.Drawing.Point(12, 93);
            this.studentData.Name = "studentData";
            this.studentData.RowTemplate.Height = 25;
            this.studentData.Size = new System.Drawing.Size(1027, 469);
            this.studentData.TabIndex = 2;
            // 
            // filterByNameBtn
            // 
            this.filterByNameBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterByNameBtn.Location = new System.Drawing.Point(12, 569);
            this.filterByNameBtn.Name = "filterByNameBtn";
            this.filterByNameBtn.Size = new System.Drawing.Size(135, 32);
            this.filterByNameBtn.TabIndex = 3;
            this.filterByNameBtn.Text = "Filter By name";
            this.filterByNameBtn.UseVisualStyleBackColor = true;
            this.filterByNameBtn.Click += new System.EventHandler(this.filterByNameBtn_Click);
            // 
            // addBtn
            // 
            this.addBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.addBtn.Location = new System.Drawing.Point(881, 46);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(158, 32);
            this.addBtn.TabIndex = 4;
            this.addBtn.Text = "Add";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // filterBySurnameBtn
            // 
            this.filterBySurnameBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterBySurnameBtn.Location = new System.Drawing.Point(153, 569);
            this.filterBySurnameBtn.Name = "filterBySurnameBtn";
            this.filterBySurnameBtn.Size = new System.Drawing.Size(160, 32);
            this.filterBySurnameBtn.TabIndex = 5;
            this.filterBySurnameBtn.Text = "Filter By surname";
            this.filterBySurnameBtn.UseVisualStyleBackColor = true;
            this.filterBySurnameBtn.Click += new System.EventHandler(this.filterBySurnameBtn_Click);
            // 
            // filterByTestBtn
            // 
            this.filterByTestBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.filterByTestBtn.Location = new System.Drawing.Point(319, 569);
            this.filterByTestBtn.Name = "filterByTestBtn";
            this.filterByTestBtn.Size = new System.Drawing.Size(135, 32);
            this.filterByTestBtn.TabIndex = 6;
            this.filterByTestBtn.Text = "Filter By subject";
            this.filterByTestBtn.UseVisualStyleBackColor = true;
            this.filterByTestBtn.Click += new System.EventHandler(this.filterByTestBtn_Click);
            // 
            // FilterByDateBtn
            // 
            this.FilterByDateBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FilterByDateBtn.Location = new System.Drawing.Point(460, 569);
            this.FilterByDateBtn.Name = "FilterByDateBtn";
            this.FilterByDateBtn.Size = new System.Drawing.Size(135, 32);
            this.FilterByDateBtn.TabIndex = 7;
            this.FilterByDateBtn.Text = "Filter By date";
            this.FilterByDateBtn.UseVisualStyleBackColor = true;
            this.FilterByDateBtn.Click += new System.EventHandler(this.FilterByDateBtn_Click);
            // 
            // FilterByScoreBtn
            // 
            this.FilterByScoreBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.FilterByScoreBtn.Location = new System.Drawing.Point(601, 569);
            this.FilterByScoreBtn.Name = "FilterByScoreBtn";
            this.FilterByScoreBtn.Size = new System.Drawing.Size(135, 32);
            this.FilterByScoreBtn.TabIndex = 8;
            this.FilterByScoreBtn.Text = "Filter By score";
            this.FilterByScoreBtn.UseVisualStyleBackColor = true;
            this.FilterByScoreBtn.Click += new System.EventHandler(this.FilterByScoreBtn_Click);
            // 
            // DiscardFilterBtn
            // 
            this.DiscardFilterBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.DiscardFilterBtn.Location = new System.Drawing.Point(904, 569);
            this.DiscardFilterBtn.Name = "DiscardFilterBtn";
            this.DiscardFilterBtn.Size = new System.Drawing.Size(135, 32);
            this.DiscardFilterBtn.TabIndex = 9;
            this.DiscardFilterBtn.Text = "Discard Filters";
            this.DiscardFilterBtn.UseVisualStyleBackColor = true;
            this.DiscardFilterBtn.Click += new System.EventHandler(this.DiscardFilterBtn_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1062, 613);
            this.Controls.Add(this.DiscardFilterBtn);
            this.Controls.Add(this.FilterByScoreBtn);
            this.Controls.Add(this.FilterByDateBtn);
            this.Controls.Add(this.filterByTestBtn);
            this.Controls.Add(this.filterBySurnameBtn);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.filterByNameBtn);
            this.Controls.Add(this.studentData);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Test Results";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.studentData)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ContextMenuStrip FileStripMenu;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileItem;
        private System.Windows.Forms.ToolStripMenuItem openItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem exitItem;
        private System.Windows.Forms.DataGridView studentData;
        private System.Windows.Forms.Button filterByNameBtn;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.ToolStripMenuItem filtersToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem loadToolStripMenuItem;
        private System.Windows.Forms.Button filterBySurnameBtn;
        private System.Windows.Forms.Button filterByTestBtn;
        private System.Windows.Forms.Button FilterByDateBtn;
        private System.Windows.Forms.Button FilterByScoreBtn;
        private System.Windows.Forms.Button DiscardFilterBtn;
    }
}

