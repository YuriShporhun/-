namespace AccountingForAgriculturalTax
{
    partial class AboutForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AboutForm));
            this.AdvPictureBox = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.ProgramChangesRichTextBox = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.AdvPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // AdvPictureBox
            // 
            this.AdvPictureBox.Cursor = System.Windows.Forms.Cursors.Hand;
            this.AdvPictureBox.Image = ((System.Drawing.Image)(resources.GetObject("AdvPictureBox.Image")));
            this.AdvPictureBox.Location = new System.Drawing.Point(2, 0);
            this.AdvPictureBox.Name = "AdvPictureBox";
            this.AdvPictureBox.Size = new System.Drawing.Size(265, 366);
            this.AdvPictureBox.TabIndex = 0;
            this.AdvPictureBox.TabStop = false;
            this.AdvPictureBox.Click += new System.EventHandler(this.AdvPictureBox_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(273, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(119, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Описание изменений:";
            // 
            // ProgramChangesRichTextBox
            // 
            this.ProgramChangesRichTextBox.BackColor = System.Drawing.SystemColors.ButtonHighlight;
            this.ProgramChangesRichTextBox.Location = new System.Drawing.Point(276, 25);
            this.ProgramChangesRichTextBox.Name = "ProgramChangesRichTextBox";
            this.ProgramChangesRichTextBox.ReadOnly = true;
            this.ProgramChangesRichTextBox.Size = new System.Drawing.Size(314, 341);
            this.ProgramChangesRichTextBox.TabIndex = 3;
            this.ProgramChangesRichTextBox.Text = "";
            this.ProgramChangesRichTextBox.ReadOnlyChanged += new System.EventHandler(this.ProgramChangesRichTextBox_ReadOnlyChanged);
            // 
            // AboutForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(595, 366);
            this.Controls.Add(this.ProgramChangesRichTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.AdvPictureBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "AboutForm";
            this.Text = "ЕСХН";
            this.Load += new System.EventHandler(this.AboutForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.AdvPictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox AdvPictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox ProgramChangesRichTextBox;
    }
}