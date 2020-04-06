namespace Papiloo
{
    partial class AddProdoct
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnSaveProdoct = new System.Windows.Forms.Button();
            this.txtPriceProdoct = new System.Windows.Forms.TextBox();
            this.txtSomeProdoct = new System.Windows.Forms.TextBox();
            this.txtStoreProdoct = new System.Windows.Forms.TextBox();
            this.txtNameProdoct = new System.Windows.Forms.TextBox();
            this.txtCodeProdoct = new System.Windows.Forms.TextBox();
            this.txtDetailProdoct = new System.Windows.Forms.TextBox();
            this.dateExpired = new Papiloo.FDate();
            this.SuspendLayout();
            // 
            // btnSaveProdoct
            // 
            this.btnSaveProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSaveProdoct.Location = new System.Drawing.Point(2, 1);
            this.btnSaveProdoct.Name = "btnSaveProdoct";
            this.btnSaveProdoct.Size = new System.Drawing.Size(57, 29);
            this.btnSaveProdoct.TabIndex = 15;
            this.btnSaveProdoct.Text = "ثبت";
            this.btnSaveProdoct.UseVisualStyleBackColor = true;
            this.btnSaveProdoct.Click += new System.EventHandler(this.btnSaveProdoct_Click);
            // 
            // txtPriceProdoct
            // 
            this.txtPriceProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPriceProdoct.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPriceProdoct.Location = new System.Drawing.Point(477, 3);
            this.txtPriceProdoct.Name = "txtPriceProdoct";
            this.txtPriceProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPriceProdoct.Size = new System.Drawing.Size(100, 26);
            this.txtPriceProdoct.TabIndex = 9;
            this.txtPriceProdoct.Text = "قیمت";
            // 
            // txtSomeProdoct
            // 
            this.txtSomeProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSomeProdoct.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSomeProdoct.Location = new System.Drawing.Point(578, 3);
            this.txtSomeProdoct.Name = "txtSomeProdoct";
            this.txtSomeProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSomeProdoct.Size = new System.Drawing.Size(49, 26);
            this.txtSomeProdoct.TabIndex = 7;
            this.txtSomeProdoct.Text = "مقدار";
            // 
            // txtStoreProdoct
            // 
            this.txtStoreProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtStoreProdoct.ForeColor = System.Drawing.Color.DarkGray;
            this.txtStoreProdoct.Location = new System.Drawing.Point(628, 3);
            this.txtStoreProdoct.Name = "txtStoreProdoct";
            this.txtStoreProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtStoreProdoct.Size = new System.Drawing.Size(136, 26);
            this.txtStoreProdoct.TabIndex = 5;
            this.txtStoreProdoct.Text = "نام فروشگاه یا فرد";
            // 
            // txtNameProdoct
            // 
            this.txtNameProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNameProdoct.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNameProdoct.Location = new System.Drawing.Point(765, 3);
            this.txtNameProdoct.Name = "txtNameProdoct";
            this.txtNameProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNameProdoct.Size = new System.Drawing.Size(103, 26);
            this.txtNameProdoct.TabIndex = 3;
            this.txtNameProdoct.Text = "نام کالا";
            this.txtNameProdoct.TabIndexChanged += new System.EventHandler(this.txtNameProdoct_TabIndexChanged);
            this.txtNameProdoct.Enter += new System.EventHandler(this.txtNameProdoct_Enter);
            this.txtNameProdoct.Leave += new System.EventHandler(this.txtNameProdoct_Leave);
            // 
            // txtCodeProdoct
            // 
            this.txtCodeProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCodeProdoct.ForeColor = System.Drawing.Color.DarkGray;
            this.txtCodeProdoct.Location = new System.Drawing.Point(870, 3);
            this.txtCodeProdoct.Name = "txtCodeProdoct";
            this.txtCodeProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodeProdoct.Size = new System.Drawing.Size(76, 26);
            this.txtCodeProdoct.TabIndex = 0;
            this.txtCodeProdoct.Text = "کد کالا";
            this.txtCodeProdoct.TabIndexChanged += new System.EventHandler(this.txtCodeProdoct_TabIndexChanged);
            this.txtCodeProdoct.Enter += new System.EventHandler(this.txtCodeProdoct_Enter);
            this.txtCodeProdoct.Leave += new System.EventHandler(this.txtCodeProdoct_Leave);
            // 
            // txtDetailProdoct
            // 
            this.txtDetailProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDetailProdoct.ForeColor = System.Drawing.Color.DarkGray;
            this.txtDetailProdoct.Location = new System.Drawing.Point(201, 3);
            this.txtDetailProdoct.Name = "txtDetailProdoct";
            this.txtDetailProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDetailProdoct.Size = new System.Drawing.Size(275, 26);
            this.txtDetailProdoct.TabIndex = 11;
            this.txtDetailProdoct.Text = "توضیحات";
            // 
            // dateExpired
            // 
            this.dateExpired.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dateExpired.Location = new System.Drawing.Point(60, 0);
            this.dateExpired.Name = "dateExpired";
            this.dateExpired.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateExpired.Size = new System.Drawing.Size(141, 29);
            this.dateExpired.TabIndex = 13;
            // 
            // AddProdoct
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dateExpired);
            this.Controls.Add(this.txtDetailProdoct);
            this.Controls.Add(this.txtCodeProdoct);
            this.Controls.Add(this.txtNameProdoct);
            this.Controls.Add(this.txtStoreProdoct);
            this.Controls.Add(this.txtSomeProdoct);
            this.Controls.Add(this.txtPriceProdoct);
            this.Controls.Add(this.btnSaveProdoct);
            this.Name = "AddProdoct";
            this.Size = new System.Drawing.Size(953, 33);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveProdoct;
        private System.Windows.Forms.TextBox txtPriceProdoct;
        private System.Windows.Forms.TextBox txtSomeProdoct;
        private System.Windows.Forms.TextBox txtStoreProdoct;
        private System.Windows.Forms.TextBox txtNameProdoct;
        private System.Windows.Forms.TextBox txtCodeProdoct;
        private System.Windows.Forms.TextBox txtDetailProdoct;
        private Papiloo.FDate dateExpired;
    }
}
