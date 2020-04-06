namespace Service
{
    partial class FormNotification
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
            this.dgShow = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgShow)).BeginInit();
            this.SuspendLayout();
            // 
            // dgShow
            // 
            this.dgShow.AllowUserToAddRows = false;
            this.dgShow.AllowUserToDeleteRows = false;
            this.dgShow.BackgroundColor = System.Drawing.Color.Gainsboro;
            this.dgShow.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgShow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgShow.Location = new System.Drawing.Point(0, 0);
            this.dgShow.Name = "dgShow";
            this.dgShow.ReadOnly = true;
            this.dgShow.RowHeadersVisible = false;
            this.dgShow.Size = new System.Drawing.Size(266, 429);
            this.dgShow.TabIndex = 0;
            this.dgShow.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgShow_CellDoubleClick);
            // 
            // FormNotification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(266, 429);
            this.Controls.Add(this.dgShow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FormNotification";
            this.Opacity = 0.3D;
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "FormNotification";
            this.Load += new System.EventHandler(this.FormNotification_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgShow)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        public System.Windows.Forms.DataGridView dgShow;
    }
}