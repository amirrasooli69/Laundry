namespace Service
{
    partial class FormReports
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormReports));
            this.PanelDate = new System.Windows.Forms.Panel();
            this.label6 = new System.Windows.Forms.Label();
            this.dtEnd = new BPersianCalender.BPersianCalenderTextBox();
            this.btnReport = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.dtStart = new BPersianCalender.BPersianCalenderTextBox();
            this.dgSearch = new System.Windows.Forms.DataGridView();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.lblTotallTakhfif = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lblTotalMande = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblTotalResive = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PanelUser = new System.Windows.Forms.Panel();
            this.txtPhone = new System.Windows.Forms.TextBox();
            this.txtEshterak = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnReportUser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.btnWordExport = new System.Windows.Forms.Button();
            this.btnExcelExport = new System.Windows.Forms.Button();
            this.btnPdfExport = new System.Windows.Forms.Button();
            this.panelProdoct = new System.Windows.Forms.Panel();
            this.label11 = new System.Windows.Forms.Label();
            this.dtEnd1 = new BPersianCalender.BPersianCalenderTextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.dtStart1 = new BPersianCalender.BPersianCalenderTextBox();
            this.comProdoct = new System.Windows.Forms.ComboBox();
            this.comCategory = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.btnReportProdoct = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.lblBestankar = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.PanelDate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearch)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.PanelUser.SuspendLayout();
            this.panelProdoct.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelDate
            // 
            this.PanelDate.Controls.Add(this.label6);
            this.PanelDate.Controls.Add(this.dtEnd);
            this.PanelDate.Controls.Add(this.btnReport);
            this.PanelDate.Controls.Add(this.label1);
            this.PanelDate.Controls.Add(this.dtStart);
            this.PanelDate.Location = new System.Drawing.Point(280, 12);
            this.PanelDate.Name = "PanelDate";
            this.PanelDate.Size = new System.Drawing.Size(685, 47);
            this.PanelDate.TabIndex = 0;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(365, 13);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(53, 19);
            this.label6.TabIndex = 55;
            this.label6.Text = "تا تاریخ";
            // 
            // dtEnd
            // 
            this.dtEnd.BackColor = System.Drawing.Color.White;
            this.dtEnd.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtEnd.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dtEnd.Location = new System.Drawing.Point(205, 10);
            this.dtEnd.Miladi = new System.DateTime(((long)(0)));
            this.dtEnd.Name = "dtEnd";
            this.dtEnd.NowDateSelected = false;
            this.dtEnd.ReadOnly = true;
            this.dtEnd.SelectedDate = null;
            this.dtEnd.Shamsi = null;
            this.dtEnd.Size = new System.Drawing.Size(154, 27);
            this.dtEnd.TabIndex = 54;
            this.dtEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // btnReport
            // 
            this.btnReport.Location = new System.Drawing.Point(13, 6);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(105, 32);
            this.btnReport.TabIndex = 5;
            this.btnReport.Text = "گزارش";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(621, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 19);
            this.label1.TabIndex = 53;
            this.label1.Text = "از تاریخ";
            // 
            // dtStart
            // 
            this.dtStart.BackColor = System.Drawing.Color.White;
            this.dtStart.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtStart.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dtStart.Location = new System.Drawing.Point(461, 10);
            this.dtStart.Miladi = new System.DateTime(((long)(0)));
            this.dtStart.Name = "dtStart";
            this.dtStart.NowDateSelected = false;
            this.dtStart.ReadOnly = true;
            this.dtStart.SelectedDate = null;
            this.dtStart.Shamsi = null;
            this.dtStart.Size = new System.Drawing.Size(154, 27);
            this.dtStart.TabIndex = 3;
            this.dtStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // dgSearch
            // 
            this.dgSearch.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgSearch.Location = new System.Drawing.Point(5, 65);
            this.dgSearch.Name = "dgSearch";
            this.dgSearch.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgSearch.Size = new System.Drawing.Size(945, 501);
            this.dgSearch.TabIndex = 23;
            this.dgSearch.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgSearch_CellDoubleClick);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.dgSearch);
            this.panel1.Location = new System.Drawing.Point(12, 65);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(954, 569);
            this.panel1.TabIndex = 24;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.lblBestankar);
            this.panel2.Controls.Add(this.label14);
            this.panel2.Controls.Add(this.lblTotallTakhfif);
            this.panel2.Controls.Add(this.label9);
            this.panel2.Controls.Add(this.lblTotalMande);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.lblTotalResive);
            this.panel2.Controls.Add(this.label4);
            this.panel2.Controls.Add(this.lblTotalPrice);
            this.panel2.Controls.Add(this.label3);
            this.panel2.Location = new System.Drawing.Point(5, 4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(945, 56);
            this.panel2.TabIndex = 25;
            // 
            // lblTotallTakhfif
            // 
            this.lblTotallTakhfif.AutoSize = true;
            this.lblTotallTakhfif.Location = new System.Drawing.Point(12, 17);
            this.lblTotallTakhfif.Name = "lblTotallTakhfif";
            this.lblTotallTakhfif.Size = new System.Drawing.Size(18, 19);
            this.lblTotallTakhfif.TabIndex = 64;
            this.lblTotallTakhfif.Text = "0";
            this.lblTotallTakhfif.TextChanged += new System.EventHandler(this.lblTotallTakhfif_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(96, 17);
            this.label9.Name = "label9";
            this.label9.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label9.Size = new System.Drawing.Size(84, 19);
            this.label9.TabIndex = 63;
            this.label9.Text = "کل تخفیف:";
            // 
            // lblTotalMande
            // 
            this.lblTotalMande.AutoSize = true;
            this.lblTotalMande.Location = new System.Drawing.Point(362, 17);
            this.lblTotalMande.Name = "lblTotalMande";
            this.lblTotalMande.Size = new System.Drawing.Size(18, 19);
            this.lblTotalMande.TabIndex = 62;
            this.lblTotalMande.Text = "0";
            this.lblTotalMande.TextChanged += new System.EventHandler(this.lblTotalMande_TextChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(459, 17);
            this.label7.Name = "label7";
            this.label7.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label7.Size = new System.Drawing.Size(74, 19);
            this.label7.TabIndex = 61;
            this.label7.Text = "کل مانده:";
            // 
            // lblTotalResive
            // 
            this.lblTotalResive.AutoSize = true;
            this.lblTotalResive.Location = new System.Drawing.Point(539, 17);
            this.lblTotalResive.Name = "lblTotalResive";
            this.lblTotalResive.Size = new System.Drawing.Size(18, 19);
            this.lblTotalResive.TabIndex = 58;
            this.lblTotalResive.Text = "0";
            this.lblTotalResive.TextChanged += new System.EventHandler(this.lblTotalResive_TextChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(656, 17);
            this.label4.Name = "label4";
            this.label4.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label4.Size = new System.Drawing.Size(91, 19);
            this.label4.TabIndex = 57;
            this.label4.Text = "کل دریافتی:";
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Location = new System.Drawing.Point(753, 17);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.Size = new System.Drawing.Size(18, 19);
            this.lblTotalPrice.TabIndex = 56;
            this.lblTotalPrice.Text = "0";
            this.lblTotalPrice.TextChanged += new System.EventHandler(this.lblTotalPrice_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(862, 17);
            this.label3.Name = "label3";
            this.label3.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label3.Size = new System.Drawing.Size(81, 19);
            this.label3.TabIndex = 55;
            this.label3.Text = "کل کارکرد:";
            // 
            // PanelUser
            // 
            this.PanelUser.Controls.Add(this.txtPhone);
            this.PanelUser.Controls.Add(this.txtEshterak);
            this.PanelUser.Controls.Add(this.label5);
            this.PanelUser.Controls.Add(this.btnReportUser);
            this.PanelUser.Controls.Add(this.label2);
            this.PanelUser.Location = new System.Drawing.Point(280, 12);
            this.PanelUser.Name = "PanelUser";
            this.PanelUser.Size = new System.Drawing.Size(685, 47);
            this.PanelUser.TabIndex = 26;
            // 
            // txtPhone
            // 
            this.txtPhone.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtPhone.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtPhone.Location = new System.Drawing.Point(165, 10);
            this.txtPhone.MaxLength = 11;
            this.txtPhone.Name = "txtPhone";
            this.txtPhone.Size = new System.Drawing.Size(165, 27);
            this.txtPhone.TabIndex = 59;
            this.txtPhone.TextChanged += new System.EventHandler(this.txtPhone_TextChanged);
            this.txtPhone.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPhone_KeyPress);
            // 
            // txtEshterak
            // 
            this.txtEshterak.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.txtEshterak.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.CustomSource;
            this.txtEshterak.Location = new System.Drawing.Point(439, 10);
            this.txtEshterak.MaxLength = 5;
            this.txtEshterak.Name = "txtEshterak";
            this.txtEshterak.Size = new System.Drawing.Size(147, 27);
            this.txtEshterak.TabIndex = 58;
            this.txtEshterak.TextChanged += new System.EventHandler(this.txtEshterak_TextChanged);
            this.txtEshterak.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtEshterak_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(336, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(97, 19);
            this.label5.TabIndex = 57;
            this.label5.Text = "شماره تماس";
            // 
            // btnReportUser
            // 
            this.btnReportUser.Location = new System.Drawing.Point(13, 6);
            this.btnReportUser.Name = "btnReportUser";
            this.btnReportUser.Size = new System.Drawing.Size(105, 32);
            this.btnReportUser.TabIndex = 2;
            this.btnReportUser.Text = "گزارش";
            this.btnReportUser.UseVisualStyleBackColor = true;
            this.btnReportUser.Click += new System.EventHandler(this.btnReportUser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(592, 13);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 19);
            this.label2.TabIndex = 53;
            this.label2.Text = "کد اشتراک";
            // 
            // btnWordExport
            // 
            this.btnWordExport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnWordExport.Image = ((System.Drawing.Image)(resources.GetObject("btnWordExport.Image")));
            this.btnWordExport.Location = new System.Drawing.Point(12, 6);
            this.btnWordExport.Name = "btnWordExport";
            this.btnWordExport.Size = new System.Drawing.Size(60, 53);
            this.btnWordExport.TabIndex = 28;
            this.btnWordExport.UseVisualStyleBackColor = false;
            this.btnWordExport.Click += new System.EventHandler(this.btnWordExport_Click);
            // 
            // btnExcelExport
            // 
            this.btnExcelExport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnExcelExport.Image = ((System.Drawing.Image)(resources.GetObject("btnExcelExport.Image")));
            this.btnExcelExport.Location = new System.Drawing.Point(72, 6);
            this.btnExcelExport.Name = "btnExcelExport";
            this.btnExcelExport.Size = new System.Drawing.Size(62, 53);
            this.btnExcelExport.TabIndex = 29;
            this.btnExcelExport.UseVisualStyleBackColor = false;
            this.btnExcelExport.Click += new System.EventHandler(this.btnExcelExport_Click);
            // 
            // btnPdfExport
            // 
            this.btnPdfExport.BackColor = System.Drawing.SystemColors.ButtonFace;
            this.btnPdfExport.Image = ((System.Drawing.Image)(resources.GetObject("btnPdfExport.Image")));
            this.btnPdfExport.Location = new System.Drawing.Point(134, 6);
            this.btnPdfExport.Name = "btnPdfExport";
            this.btnPdfExport.Size = new System.Drawing.Size(60, 53);
            this.btnPdfExport.TabIndex = 30;
            this.btnPdfExport.UseVisualStyleBackColor = false;
            this.btnPdfExport.Click += new System.EventHandler(this.btnPdfExport_Click);
            // 
            // panelProdoct
            // 
            this.panelProdoct.Controls.Add(this.label11);
            this.panelProdoct.Controls.Add(this.dtEnd1);
            this.panelProdoct.Controls.Add(this.label12);
            this.panelProdoct.Controls.Add(this.dtStart1);
            this.panelProdoct.Controls.Add(this.comProdoct);
            this.panelProdoct.Controls.Add(this.comCategory);
            this.panelProdoct.Controls.Add(this.label8);
            this.panelProdoct.Controls.Add(this.btnReportProdoct);
            this.panelProdoct.Controls.Add(this.label10);
            this.panelProdoct.Location = new System.Drawing.Point(194, 12);
            this.panelProdoct.Name = "panelProdoct";
            this.panelProdoct.Size = new System.Drawing.Size(763, 47);
            this.panelProdoct.TabIndex = 31;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label11.Location = new System.Drawing.Point(554, 15);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(46, 16);
            this.label11.TabIndex = 60;
            this.label11.Text = "تا تاریخ";
            // 
            // dtEnd1
            // 
            this.dtEnd1.BackColor = System.Drawing.Color.White;
            this.dtEnd1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dtEnd1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dtEnd1.Location = new System.Drawing.Point(443, 12);
            this.dtEnd1.Miladi = new System.DateTime(((long)(0)));
            this.dtEnd1.Name = "dtEnd1";
            this.dtEnd1.NowDateSelected = false;
            this.dtEnd1.ReadOnly = true;
            this.dtEnd1.SelectedDate = null;
            this.dtEnd1.Shamsi = null;
            this.dtEnd1.Size = new System.Drawing.Size(105, 23);
            this.dtEnd1.TabIndex = 59;
            this.dtEnd1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label12.Location = new System.Drawing.Point(714, 15);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(46, 16);
            this.label12.TabIndex = 58;
            this.label12.Text = "از تاریخ";
            // 
            // dtStart1
            // 
            this.dtStart1.BackColor = System.Drawing.Color.White;
            this.dtStart1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.dtStart1.ForeColor = System.Drawing.SystemColors.WindowText;
            this.dtStart1.Location = new System.Drawing.Point(606, 12);
            this.dtStart1.Miladi = new System.DateTime(((long)(0)));
            this.dtStart1.Name = "dtStart1";
            this.dtStart1.NowDateSelected = false;
            this.dtStart1.ReadOnly = true;
            this.dtStart1.SelectedDate = null;
            this.dtStart1.Shamsi = null;
            this.dtStart1.Size = new System.Drawing.Size(105, 23);
            this.dtStart1.TabIndex = 57;
            this.dtStart1.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // comProdoct
            // 
            this.comProdoct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comProdoct.FormattingEnabled = true;
            this.comProdoct.Location = new System.Drawing.Point(86, 13);
            this.comProdoct.Name = "comProdoct";
            this.comProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comProdoct.Size = new System.Drawing.Size(140, 24);
            this.comProdoct.TabIndex = 56;
            // 
            // comCategory
            // 
            this.comCategory.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comCategory.FormattingEnabled = true;
            this.comCategory.Location = new System.Drawing.Point(286, 13);
            this.comCategory.Name = "comCategory";
            this.comCategory.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comCategory.Size = new System.Drawing.Size(108, 24);
            this.comCategory.TabIndex = 55;
            this.comCategory.SelectedIndexChanged += new System.EventHandler(this.comCategory_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label8.Location = new System.Drawing.Point(232, 16);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(48, 16);
            this.label8.TabIndex = 54;
            this.label8.Text = "محصول";
            // 
            // btnReportProdoct
            // 
            this.btnReportProdoct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnReportProdoct.Location = new System.Drawing.Point(9, 8);
            this.btnReportProdoct.Name = "btnReportProdoct";
            this.btnReportProdoct.Size = new System.Drawing.Size(71, 32);
            this.btnReportProdoct.TabIndex = 5;
            this.btnReportProdoct.Text = "گزارش";
            this.btnReportProdoct.UseVisualStyleBackColor = true;
            this.btnReportProdoct.Click += new System.EventHandler(this.btnReportProdoct_Click);
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label10.Location = new System.Drawing.Point(398, 15);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(39, 16);
            this.label10.TabIndex = 53;
            this.label10.Text = "دسته";
            // 
            // lblBestankar
            // 
            this.lblBestankar.AutoSize = true;
            this.lblBestankar.Location = new System.Drawing.Point(195, 17);
            this.lblBestankar.Name = "lblBestankar";
            this.lblBestankar.Size = new System.Drawing.Size(18, 19);
            this.lblBestankar.TabIndex = 66;
            this.lblBestankar.Text = "0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(282, 17);
            this.label14.Name = "label14";
            this.label14.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.label14.Size = new System.Drawing.Size(71, 19);
            this.label14.TabIndex = 65;
            this.label14.Text = "بستانکار:";
            // 
            // FormReports
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(977, 646);
            this.Controls.Add(this.panelProdoct);
            this.Controls.Add(this.btnPdfExport);
            this.Controls.Add(this.PanelDate);
            this.Controls.Add(this.btnExcelExport);
            this.Controls.Add(this.btnWordExport);
            this.Controls.Add(this.PanelUser);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(993, 685);
            this.MinimumSize = new System.Drawing.Size(993, 685);
            this.Name = "FormReports";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "گزارش";
            this.Load += new System.EventHandler(this.FormReports_Load);
            this.PanelDate.ResumeLayout(false);
            this.PanelDate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgSearch)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.PanelUser.ResumeLayout(false);
            this.PanelUser.PerformLayout();
            this.panelProdoct.ResumeLayout(false);
            this.panelProdoct.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Label label1;
        public BPersianCalender.BPersianCalenderTextBox dtStart;
        public System.Windows.Forms.Panel PanelDate;
        private System.Windows.Forms.DataGridView dgSearch;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label lblTotalMande;
        private System.Windows.Forms.Label lblTotalResive;
        private System.Windows.Forms.Label lblTotalPrice;
        public System.Windows.Forms.Panel PanelUser;
        private System.Windows.Forms.Button btnReportUser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        public BPersianCalender.BPersianCalenderTextBox dtEnd;
        private System.Windows.Forms.Label lblTotallTakhfif;
        public System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btnWordExport;
        private System.Windows.Forms.Button btnExcelExport;
        private System.Windows.Forms.Button btnPdfExport;
        public System.Windows.Forms.TextBox txtEshterak;
        public System.Windows.Forms.TextBox txtPhone;
        public System.Windows.Forms.Panel panelProdoct;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button btnReportProdoct;
        private System.Windows.Forms.Label label10;
        public System.Windows.Forms.ComboBox comProdoct;
        public System.Windows.Forms.ComboBox comCategory;
        private System.Windows.Forms.Label label11;
        public BPersianCalender.BPersianCalenderTextBox dtEnd1;
        private System.Windows.Forms.Label label12;
        public BPersianCalender.BPersianCalenderTextBox dtStart1;
        private System.Windows.Forms.Label lblBestankar;
        public System.Windows.Forms.Label label14;
    }
}