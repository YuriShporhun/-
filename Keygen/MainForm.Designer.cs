namespace AccountingForAgriculturalTax
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.clientsDataGridView = new System.Windows.Forms.DataGridView();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.AddNewKeyButton = new System.Windows.Forms.ToolStripButton();
            this.deleteRowButton = new System.Windows.Forms.ToolStripButton();
            this.copyKeyButton = new System.Windows.Forms.ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)(this.clientsDataGridView)).BeginInit();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clientsDataGridView
            // 
            this.clientsDataGridView.AllowUserToAddRows = false;
            this.clientsDataGridView.AllowUserToDeleteRows = false;
            this.clientsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.clientsDataGridView.Location = new System.Drawing.Point(0, 28);
            this.clientsDataGridView.Name = "clientsDataGridView";
            this.clientsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.clientsDataGridView.Size = new System.Drawing.Size(948, 473);
            this.clientsDataGridView.TabIndex = 0;
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.AddNewKeyButton,
            this.deleteRowButton,
            this.copyKeyButton});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(948, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // AddNewKeyButton
            // 
            this.AddNewKeyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.AddNewKeyButton.Image = ((System.Drawing.Image)(resources.GetObject("AddNewKeyButton.Image")));
            this.AddNewKeyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.AddNewKeyButton.Name = "AddNewKeyButton";
            this.AddNewKeyButton.Size = new System.Drawing.Size(49, 22);
            this.AddNewKeyButton.Text = "Новый";
            this.AddNewKeyButton.Click += new System.EventHandler(this.AddNewKeyButton_Click);
            // 
            // deleteRowButton
            // 
            this.deleteRowButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.deleteRowButton.Image = ((System.Drawing.Image)(resources.GetObject("deleteRowButton.Image")));
            this.deleteRowButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.deleteRowButton.Name = "deleteRowButton";
            this.deleteRowButton.Size = new System.Drawing.Size(55, 22);
            this.deleteRowButton.Text = "Удалить";
            this.deleteRowButton.Click += new System.EventHandler(this.deleteRowButton_Click);
            // 
            // copyKeyButton
            // 
            this.copyKeyButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.copyKeyButton.Image = ((System.Drawing.Image)(resources.GetObject("copyKeyButton.Image")));
            this.copyKeyButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.copyKeyButton.Name = "copyKeyButton";
            this.copyKeyButton.Size = new System.Drawing.Size(109, 22);
            this.copyKeyButton.Text = "Копировать ключ";
            this.copyKeyButton.Click += new System.EventHandler(this.copyKeyButton_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(948, 502);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.clientsDataGridView);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "Ключи";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.clientsDataGridView)).EndInit();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView clientsDataGridView;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton AddNewKeyButton;
        private System.Windows.Forms.ToolStripButton deleteRowButton;
        private System.Windows.Forms.ToolStripButton copyKeyButton;
    }
}

