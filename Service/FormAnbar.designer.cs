namespace Service
{
    partial class FormAnbar
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormAnbar));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnNew = new System.Windows.Forms.Button();
            this.comCase = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtDetails = new System.Windows.Forms.TextBox();
            this.label32 = new System.Windows.Forms.Label();
            this.dgAnbar = new System.Windows.Forms.DataGridView();
            this.ProdoctCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ProdoctName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NameStore = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Count = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DateExpired = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnDelete = new System.Windows.Forms.DataGridViewButtonColumn();
            this.txtDetailProdoct = new System.Windows.Forms.TextBox();
            this.txtCodeProdoct = new System.Windows.Forms.TextBox();
            this.txtNameProdoct = new System.Windows.Forms.TextBox();
            this.txtNameStore = new System.Windows.Forms.TextBox();
            this.txtSomeProdoct = new System.Windows.Forms.TextBox();
            this.txtPriceProdoct = new System.Windows.Forms.TextBox();
            this.btnSaveProdoct = new System.Windows.Forms.Button();
            this.groupProdoct = new System.Windows.Forms.GroupBox();
            this.lblExistingProdoct = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.lblSugettion = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btnTest = new System.Windows.Forms.Button();
            this.btnRefreshDgProdoct = new System.Windows.Forms.Button();
            this.btnRefreshDgStore = new System.Windows.Forms.Button();
            this.btnDelStore = new System.Windows.Forms.Button();
            this.btnDelProdoct = new System.Windows.Forms.Button();
            this.btnEditProdoct = new System.Windows.Forms.Button();
            this.btnEditStore = new System.Windows.Forms.Button();
            this.dgStore = new System.Windows.Forms.DataGridView();
            this.dgProdoct = new System.Windows.Forms.DataGridView();
            this.lblCodeRahgiri = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSaveAllProdoct = new System.Windows.Forms.Button();
            this.lblTotalPrice = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.toolBtnAnbarReport = new System.Windows.Forms.ToolStripMenuItem();
            this.dateExpird = new Papiloo.FDate();
            this.ucDelStore = new Papiloo.ucButton();
            this.ucAddStore = new Papiloo.ucButton();
            this.Date = new Papiloo.FDate();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAnbar)).BeginInit();
            this.groupProdoct.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStore)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdoct)).BeginInit();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnNew);
            this.groupBox1.Controls.Add(this.comCase);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.Date);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.txtDetails);
            this.groupBox1.Controls.Add(this.label32);
            this.groupBox1.Location = new System.Drawing.Point(7, 27);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(946, 66);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btnNew
            // 
            this.btnNew.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnNew.Location = new System.Drawing.Point(5, 22);
            this.btnNew.Name = "btnNew";
            this.btnNew.Size = new System.Drawing.Size(54, 29);
            this.btnNew.TabIndex = 4;
            this.btnNew.Text = "جدید";
            this.btnNew.UseVisualStyleBackColor = true;
            this.btnNew.Click += new System.EventHandler(this.btnNew_Click);
            // 
            // comCase
            // 
            this.comCase.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.comCase.FormattingEnabled = true;
            this.comCase.Items.AddRange(new object[] {
            "رسید (خرید)",
            "حواله (فروش)",
            "حواله (مصرف)",
            "رسید (تولید)",
            "برگشت کالا (فروش)",
            "برگشت کالا (مصرف)",
            "حواله انبار (امانی)",
            "برگشت کالا (امانی)"});
            this.comCase.Location = new System.Drawing.Point(729, 22);
            this.comCase.Name = "comCase";
            this.comCase.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.comCase.Size = new System.Drawing.Size(152, 26);
            this.comCase.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(640, 25);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 18);
            this.label4.TabIndex = 31;
            this.label4.Text = "تاریخ ورود";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.label2.Location = new System.Drawing.Point(887, 25);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(52, 18);
            this.label2.TabIndex = 27;
            this.label2.Text = "عملیات";
            // 
            // txtDetails
            // 
            this.txtDetails.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtDetails.Location = new System.Drawing.Point(65, 22);
            this.txtDetails.Multiline = true;
            this.txtDetails.Name = "txtDetails";
            this.txtDetails.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDetails.Size = new System.Drawing.Size(354, 28);
            this.txtDetails.TabIndex = 3;
            // 
            // label32
            // 
            this.label32.AutoSize = true;
            this.label32.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label32.Location = new System.Drawing.Point(425, 27);
            this.label32.Name = "label32";
            this.label32.Size = new System.Drawing.Size(62, 18);
            this.label32.TabIndex = 18;
            this.label32.Text = "توضیحات";
            // 
            // dgAnbar
            // 
            this.dgAnbar.AllowUserToAddRows = false;
            this.dgAnbar.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgAnbar.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.ProdoctCode,
            this.ProdoctName,
            this.NameStore,
            this.Count,
            this.Price,
            this.Description,
            this.DateExpired,
            this.btnDelete});
            this.dgAnbar.EditMode = System.Windows.Forms.DataGridViewEditMode.EditOnEnter;
            this.dgAnbar.Location = new System.Drawing.Point(7, 388);
            this.dgAnbar.Name = "dgAnbar";
            this.dgAnbar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgAnbar.Size = new System.Drawing.Size(946, 253);
            this.dgAnbar.TabIndex = 9;
            this.dgAnbar.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgAnbar_CellClick);
            this.dgAnbar.EditingControlShowing += new System.Windows.Forms.DataGridViewEditingControlShowingEventHandler(this.dgAnbar_EditingControlShowing);
            this.dgAnbar.RowsAdded += new System.Windows.Forms.DataGridViewRowsAddedEventHandler(this.dgAnbar_RowsAdded);
            this.dgAnbar.RowsRemoved += new System.Windows.Forms.DataGridViewRowsRemovedEventHandler(this.dgAnbar_RowsRemoved);
            // 
            // ProdoctCode
            // 
            this.ProdoctCode.HeaderText = "کدکلا";
            this.ProdoctCode.Name = "ProdoctCode";
            this.ProdoctCode.ReadOnly = true;
            this.ProdoctCode.Width = 60;
            // 
            // ProdoctName
            // 
            this.ProdoctName.HeaderText = "نام کالا";
            this.ProdoctName.Name = "ProdoctName";
            this.ProdoctName.ReadOnly = true;
            this.ProdoctName.Width = 130;
            // 
            // NameStore
            // 
            this.NameStore.HeaderText = "نام فروشگاه یا فرد";
            this.NameStore.Name = "NameStore";
            this.NameStore.ReadOnly = true;
            this.NameStore.Width = 150;
            // 
            // Count
            // 
            this.Count.HeaderText = "تعداد";
            this.Count.Name = "Count";
            this.Count.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Count.Width = 50;
            // 
            // Price
            // 
            this.Price.HeaderText = "قیمت";
            this.Price.Name = "Price";
            this.Price.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Programmatic;
            this.Price.Width = 120;
            // 
            // Description
            // 
            this.Description.HeaderText = "توضیحات";
            this.Description.Name = "Description";
            this.Description.Width = 220;
            // 
            // DateExpired
            // 
            this.DateExpired.HeaderText = "تاریخ انقصا";
            this.DateExpired.Name = "DateExpired";
            this.DateExpired.ReadOnly = true;
            // 
            // btnDelete
            // 
            this.btnDelete.FillWeight = 50F;
            this.btnDelete.HeaderText = "";
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.ReadOnly = true;
            this.btnDelete.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.btnDelete.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.btnDelete.Text = "حذف";
            this.btnDelete.UseColumnTextForButtonValue = true;
            this.btnDelete.Width = 70;
            // 
            // txtDetailProdoct
            // 
            this.txtDetailProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtDetailProdoct.ForeColor = System.Drawing.Color.DarkGray;
            this.txtDetailProdoct.Location = new System.Drawing.Point(6, 86);
            this.txtDetailProdoct.Multiline = true;
            this.txtDetailProdoct.Name = "txtDetailProdoct";
            this.txtDetailProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtDetailProdoct.Size = new System.Drawing.Size(431, 53);
            this.txtDetailProdoct.TabIndex = 39;
            this.txtDetailProdoct.Text = "توضیحات";
            this.txtDetailProdoct.Enter += new System.EventHandler(this.txtDetailProdoct_Enter);
            this.txtDetailProdoct.Leave += new System.EventHandler(this.txtDetailProdoct_Leave);
            // 
            // txtCodeProdoct
            // 
            this.txtCodeProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtCodeProdoct.ForeColor = System.Drawing.Color.DarkGray;
            this.txtCodeProdoct.Location = new System.Drawing.Point(855, 22);
            this.txtCodeProdoct.Name = "txtCodeProdoct";
            this.txtCodeProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtCodeProdoct.Size = new System.Drawing.Size(84, 26);
            this.txtCodeProdoct.TabIndex = 34;
            this.txtCodeProdoct.Text = "کد کالا";
            this.txtCodeProdoct.Click += new System.EventHandler(this.txtCodeProdoct_Click);
            this.txtCodeProdoct.TextChanged += new System.EventHandler(this.txtCodeProdoct_TextChanged);
            this.txtCodeProdoct.Enter += new System.EventHandler(this.txtCodeProdoct_Enter);
            this.txtCodeProdoct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtCodeProdoct_KeyPress_1);
            this.txtCodeProdoct.Leave += new System.EventHandler(this.txtCodeProdoct_Leave);
            // 
            // txtNameProdoct
            // 
            this.txtNameProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNameProdoct.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNameProdoct.Location = new System.Drawing.Point(694, 22);
            this.txtNameProdoct.Name = "txtNameProdoct";
            this.txtNameProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNameProdoct.Size = new System.Drawing.Size(159, 26);
            this.txtNameProdoct.TabIndex = 35;
            this.txtNameProdoct.Text = "نام کالا";
            this.txtNameProdoct.TextChanged += new System.EventHandler(this.txtNameProdoct_TextChanged);
            this.txtNameProdoct.Enter += new System.EventHandler(this.txtNameProdoct_Enter);
            this.txtNameProdoct.Leave += new System.EventHandler(this.txtNameProdoct_Leave);
            // 
            // txtNameStore
            // 
            this.txtNameStore.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtNameStore.ForeColor = System.Drawing.Color.DarkGray;
            this.txtNameStore.Location = new System.Drawing.Point(443, 22);
            this.txtNameStore.Name = "txtNameStore";
            this.txtNameStore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtNameStore.Size = new System.Drawing.Size(245, 26);
            this.txtNameStore.TabIndex = 36;
            this.txtNameStore.Text = "طرف حساب";
            this.txtNameStore.TextChanged += new System.EventHandler(this.txtNameStore_TextChanged);
            this.txtNameStore.Enter += new System.EventHandler(this.txtStoreProdoct_Enter);
            this.txtNameStore.Leave += new System.EventHandler(this.txtStoreProdoct_Leave);
            // 
            // txtSomeProdoct
            // 
            this.txtSomeProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtSomeProdoct.ForeColor = System.Drawing.Color.DarkGray;
            this.txtSomeProdoct.Location = new System.Drawing.Point(315, 54);
            this.txtSomeProdoct.Name = "txtSomeProdoct";
            this.txtSomeProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtSomeProdoct.Size = new System.Drawing.Size(122, 26);
            this.txtSomeProdoct.TabIndex = 37;
            this.txtSomeProdoct.Text = "مقدار";
            this.txtSomeProdoct.Enter += new System.EventHandler(this.txtSomeProdoct_Enter);
            this.txtSomeProdoct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSomeProdoct_KeyPress);
            this.txtSomeProdoct.Leave += new System.EventHandler(this.txtSomeProdoct_Leave);
            // 
            // txtPriceProdoct
            // 
            this.txtPriceProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.txtPriceProdoct.ForeColor = System.Drawing.Color.DarkGray;
            this.txtPriceProdoct.Location = new System.Drawing.Point(151, 54);
            this.txtPriceProdoct.Name = "txtPriceProdoct";
            this.txtPriceProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.txtPriceProdoct.Size = new System.Drawing.Size(157, 26);
            this.txtPriceProdoct.TabIndex = 38;
            this.txtPriceProdoct.Text = "قیمت";
            this.txtPriceProdoct.TextChanged += new System.EventHandler(this.txtPriceProdoct_TextChanged);
            this.txtPriceProdoct.Enter += new System.EventHandler(this.txtPriceProdoct_Enter);
            this.txtPriceProdoct.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPriceProdoct_KeyPress);
            this.txtPriceProdoct.Leave += new System.EventHandler(this.txtPriceProdoct_Leave);
            // 
            // btnSaveProdoct
            // 
            this.btnSaveProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSaveProdoct.Location = new System.Drawing.Point(359, 149);
            this.btnSaveProdoct.Name = "btnSaveProdoct";
            this.btnSaveProdoct.Size = new System.Drawing.Size(77, 29);
            this.btnSaveProdoct.TabIndex = 41;
            this.btnSaveProdoct.Text = "ثبت";
            this.btnSaveProdoct.UseVisualStyleBackColor = true;
            this.btnSaveProdoct.Click += new System.EventHandler(this.btnSaveProdoct_Click);
            // 
            // groupProdoct
            // 
            this.groupProdoct.Controls.Add(this.lblExistingProdoct);
            this.groupProdoct.Controls.Add(this.label7);
            this.groupProdoct.Controls.Add(this.lblSugettion);
            this.groupProdoct.Controls.Add(this.label6);
            this.groupProdoct.Controls.Add(this.btnTest);
            this.groupProdoct.Controls.Add(this.dateExpird);
            this.groupProdoct.Controls.Add(this.btnRefreshDgProdoct);
            this.groupProdoct.Controls.Add(this.btnRefreshDgStore);
            this.groupProdoct.Controls.Add(this.btnDelStore);
            this.groupProdoct.Controls.Add(this.ucDelStore);
            this.groupProdoct.Controls.Add(this.ucAddStore);
            this.groupProdoct.Controls.Add(this.btnDelProdoct);
            this.groupProdoct.Controls.Add(this.btnEditProdoct);
            this.groupProdoct.Controls.Add(this.btnEditStore);
            this.groupProdoct.Controls.Add(this.dgStore);
            this.groupProdoct.Controls.Add(this.dgProdoct);
            this.groupProdoct.Controls.Add(this.lblCodeRahgiri);
            this.groupProdoct.Controls.Add(this.label1);
            this.groupProdoct.Controls.Add(this.txtNameProdoct);
            this.groupProdoct.Controls.Add(this.btnSaveProdoct);
            this.groupProdoct.Controls.Add(this.txtDetailProdoct);
            this.groupProdoct.Controls.Add(this.txtPriceProdoct);
            this.groupProdoct.Controls.Add(this.txtCodeProdoct);
            this.groupProdoct.Controls.Add(this.txtSomeProdoct);
            this.groupProdoct.Controls.Add(this.txtNameStore);
            this.groupProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.groupProdoct.Location = new System.Drawing.Point(7, 99);
            this.groupProdoct.Name = "groupProdoct";
            this.groupProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.groupProdoct.Size = new System.Drawing.Size(946, 282);
            this.groupProdoct.TabIndex = 42;
            this.groupProdoct.TabStop = false;
            this.groupProdoct.Text = "اضافه کردن کلا";
            // 
            // lblExistingProdoct
            // 
            this.lblExistingProdoct.AutoSize = true;
            this.lblExistingProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExistingProdoct.Location = new System.Drawing.Point(196, 154);
            this.lblExistingProdoct.Name = "lblExistingProdoct";
            this.lblExistingProdoct.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblExistingProdoct.Size = new System.Drawing.Size(0, 18);
            this.lblExistingProdoct.TabIndex = 106;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.Location = new System.Drawing.Point(279, 154);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(65, 18);
            this.label7.TabIndex = 105;
            this.label7.Text = "موجودی:";
            // 
            // lblSugettion
            // 
            this.lblSugettion.AutoSize = true;
            this.lblSugettion.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSugettion.Location = new System.Drawing.Point(156, 25);
            this.lblSugettion.Name = "lblSugettion";
            this.lblSugettion.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSugettion.Size = new System.Drawing.Size(0, 18);
            this.lblSugettion.TabIndex = 104;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(350, 25);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(87, 18);
            this.label6.TabIndex = 103;
            this.label6.Text = "آخرین قیمت:";
            // 
            // btnTest
            // 
            this.btnTest.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnTest.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTest.Location = new System.Drawing.Point(6, 14);
            this.btnTest.Name = "btnTest";
            this.btnTest.Size = new System.Drawing.Size(138, 34);
            this.btnTest.TabIndex = 102;
            this.btnTest.Text = "گزارش انبار";
            this.btnTest.UseVisualStyleBackColor = true;
            this.btnTest.Click += new System.EventHandler(this.btnTest_Click);
            // 
            // btnRefreshDgProdoct
            // 
            this.btnRefreshDgProdoct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefreshDgProdoct.BackgroundImage")));
            this.btnRefreshDgProdoct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshDgProdoct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshDgProdoct.Location = new System.Drawing.Point(694, 249);
            this.btnRefreshDgProdoct.Name = "btnRefreshDgProdoct";
            this.btnRefreshDgProdoct.Size = new System.Drawing.Size(42, 24);
            this.btnRefreshDgProdoct.TabIndex = 100;
            this.btnRefreshDgProdoct.UseVisualStyleBackColor = true;
            this.btnRefreshDgProdoct.Click += new System.EventHandler(this.btnRefreshDgProdoct_Click);
            // 
            // btnRefreshDgStore
            // 
            this.btnRefreshDgStore.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnRefreshDgStore.BackgroundImage")));
            this.btnRefreshDgStore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnRefreshDgStore.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRefreshDgStore.Location = new System.Drawing.Point(445, 250);
            this.btnRefreshDgStore.Name = "btnRefreshDgStore";
            this.btnRefreshDgStore.Size = new System.Drawing.Size(42, 24);
            this.btnRefreshDgStore.TabIndex = 99;
            this.btnRefreshDgStore.UseVisualStyleBackColor = true;
            this.btnRefreshDgStore.Click += new System.EventHandler(this.btnRefreshDgStore_Click);
            // 
            // btnDelStore
            // 
            this.btnDelStore.BackColor = System.Drawing.Color.Red;
            this.btnDelStore.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelStore.Location = new System.Drawing.Point(592, 250);
            this.btnDelStore.Name = "btnDelStore";
            this.btnDelStore.Size = new System.Drawing.Size(42, 24);
            this.btnDelStore.TabIndex = 98;
            this.btnDelStore.Text = "-";
            this.btnDelStore.UseVisualStyleBackColor = false;
            this.btnDelStore.Click += new System.EventHandler(this.btnDelStore_Click);
            // 
            // btnDelProdoct
            // 
            this.btnDelProdoct.BackColor = System.Drawing.Color.Red;
            this.btnDelProdoct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDelProdoct.Location = new System.Drawing.Point(841, 250);
            this.btnDelProdoct.Name = "btnDelProdoct";
            this.btnDelProdoct.Size = new System.Drawing.Size(42, 24);
            this.btnDelProdoct.TabIndex = 95;
            this.btnDelProdoct.Text = "-";
            this.btnDelProdoct.UseVisualStyleBackColor = false;
            this.btnDelProdoct.Click += new System.EventHandler(this.btnDelProdoct_Click);
            // 
            // btnEditProdoct
            // 
            this.btnEditProdoct.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditProdoct.BackgroundImage")));
            this.btnEditProdoct.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditProdoct.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditProdoct.Location = new System.Drawing.Point(793, 249);
            this.btnEditProdoct.Name = "btnEditProdoct";
            this.btnEditProdoct.Size = new System.Drawing.Size(42, 24);
            this.btnEditProdoct.TabIndex = 93;
            this.btnEditProdoct.UseVisualStyleBackColor = true;
            this.btnEditProdoct.Click += new System.EventHandler(this.btnEditProdoct_Click);
            // 
            // btnEditStore
            // 
            this.btnEditStore.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnEditStore.BackgroundImage")));
            this.btnEditStore.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.btnEditStore.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnEditStore.Location = new System.Drawing.Point(544, 250);
            this.btnEditStore.Name = "btnEditStore";
            this.btnEditStore.Size = new System.Drawing.Size(42, 24);
            this.btnEditStore.TabIndex = 50;
            this.btnEditStore.UseVisualStyleBackColor = true;
            this.btnEditStore.Click += new System.EventHandler(this.btnEditStore_Click);
            // 
            // dgStore
            // 
            this.dgStore.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgStore.Location = new System.Drawing.Point(443, 54);
            this.dgStore.Name = "dgStore";
            this.dgStore.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgStore.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgStore.Size = new System.Drawing.Size(245, 190);
            this.dgStore.TabIndex = 46;
            this.dgStore.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgStore_CellClick);
            // 
            // dgProdoct
            // 
            this.dgProdoct.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgProdoct.Location = new System.Drawing.Point(694, 54);
            this.dgProdoct.Name = "dgProdoct";
            this.dgProdoct.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dgProdoct.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgProdoct.Size = new System.Drawing.Size(245, 190);
            this.dgProdoct.TabIndex = 44;
            this.dgProdoct.CellEnter += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgProdoct_CellEnter);
            // 
            // lblCodeRahgiri
            // 
            this.lblCodeRahgiri.AutoSize = true;
            this.lblCodeRahgiri.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCodeRahgiri.Location = new System.Drawing.Point(195, 192);
            this.lblCodeRahgiri.Name = "lblCodeRahgiri";
            this.lblCodeRahgiri.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblCodeRahgiri.Size = new System.Drawing.Size(0, 18);
            this.lblCodeRahgiri.TabIndex = 43;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(264, 192);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 18);
            this.label1.TabIndex = 42;
            this.label1.Text = "کد رهگیری:";
            // 
            // btnSaveAllProdoct
            // 
            this.btnSaveAllProdoct.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.btnSaveAllProdoct.Location = new System.Drawing.Point(7, 648);
            this.btnSaveAllProdoct.Name = "btnSaveAllProdoct";
            this.btnSaveAllProdoct.Size = new System.Drawing.Size(83, 31);
            this.btnSaveAllProdoct.TabIndex = 101;
            this.btnSaveAllProdoct.Text = "ثبت نهایی";
            this.btnSaveAllProdoct.UseVisualStyleBackColor = true;
            this.btnSaveAllProdoct.Click += new System.EventHandler(this.btnSaveAllProdoct_Click);
            // 
            // lblTotalPrice
            // 
            this.lblTotalPrice.AutoSize = true;
            this.lblTotalPrice.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPrice.Location = new System.Drawing.Point(693, 654);
            this.lblTotalPrice.Name = "lblTotalPrice";
            this.lblTotalPrice.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.lblTotalPrice.Size = new System.Drawing.Size(0, 18);
            this.lblTotalPrice.TabIndex = 103;
            this.lblTotalPrice.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(873, 654);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(80, 18);
            this.label5.TabIndex = 102;
            this.label5.Text = ":جمع قیمت";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Tahoma", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolBtnAnbarReport});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.menuStrip1.Size = new System.Drawing.Size(960, 24);
            this.menuStrip1.TabIndex = 104;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // toolBtnAnbarReport
            // 
            this.toolBtnAnbarReport.Image = ((System.Drawing.Image)(resources.GetObject("toolBtnAnbarReport.Image")));
            this.toolBtnAnbarReport.Name = "toolBtnAnbarReport";
            this.toolBtnAnbarReport.Size = new System.Drawing.Size(96, 20);
            this.toolBtnAnbarReport.Text = "گزارش انبار";
            this.toolBtnAnbarReport.Click += new System.EventHandler(this.toolBtnAnbarReport_Click);
            // 
            // dateExpird
            // 
            this.dateExpird.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.dateExpird.Location = new System.Drawing.Point(5, 51);
            this.dateExpird.Name = "dateExpird";
            this.dateExpird.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.dateExpird.Size = new System.Drawing.Size(141, 31);
            this.dateExpird.TabIndex = 101;
            this.dateExpird.Load += new System.EventHandler(this.dateExpird_Load);
            // 
            // ucDelStore
            // 
            this.ucDelStore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucDelStore.Location = new System.Drawing.Point(890, 250);
            this.ucDelStore.Margin = new System.Windows.Forms.Padding(4);
            this.ucDelStore.Name = "ucDelStore";
            this.ucDelStore.Size = new System.Drawing.Size(42, 24);
            this.ucDelStore.TabIndex = 97;
            this.ucDelStore.Load += new System.EventHandler(this.ucDelStore_Load);
            // 
            // ucAddStore
            // 
            this.ucAddStore.Font = new System.Drawing.Font("Tahoma", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.ucAddStore.Location = new System.Drawing.Point(641, 250);
            this.ucAddStore.Margin = new System.Windows.Forms.Padding(4);
            this.ucAddStore.Name = "ucAddStore";
            this.ucAddStore.Size = new System.Drawing.Size(42, 24);
            this.ucAddStore.TabIndex = 96;
            this.ucAddStore.Load += new System.EventHandler(this.ucAddStore_Load);
            // 
            // Date
            // 
            this.Date.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.Date.Font = new System.Drawing.Font("Tahoma", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            this.Date.Location = new System.Drawing.Point(493, 20);
            this.Date.Name = "Date";
            this.Date.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.Date.Size = new System.Drawing.Size(141, 31);
            this.Date.TabIndex = 1;
            // 
            // FormAnbar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(960, 683);
            this.Controls.Add(this.lblTotalPrice);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.btnSaveAllProdoct);
            this.Controls.Add(this.groupProdoct);
            this.Controls.Add(this.dgAnbar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(976, 722);
            this.MinimumSize = new System.Drawing.Size(976, 722);
            this.Name = "FormAnbar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "انبار";
            this.Load += new System.EventHandler(this.FormAnbar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgAnbar)).EndInit();
            this.groupProdoct.ResumeLayout(false);
            this.groupProdoct.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgStore)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgProdoct)).EndInit();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox comCase;
        private System.Windows.Forms.Label label4;
        private Papiloo.FDate Date;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtDetails;
        private System.Windows.Forms.Label label32;
        private System.Windows.Forms.Button btnNew;
        private System.Windows.Forms.DataGridView dgAnbar;
        private System.Windows.Forms.TextBox txtDetailProdoct;
        private System.Windows.Forms.TextBox txtSomeProdoct;
        private System.Windows.Forms.TextBox txtPriceProdoct;
        private System.Windows.Forms.Button btnSaveProdoct;
        private System.Windows.Forms.GroupBox groupProdoct;
        private System.Windows.Forms.Label lblCodeRahgiri;
        private System.Windows.Forms.Label label1;
        public System.Windows.Forms.TextBox txtCodeProdoct;
        public System.Windows.Forms.TextBox txtNameProdoct;
        public System.Windows.Forms.Button btnEditStore;
        public System.Windows.Forms.Button btnDelProdoct;
        public System.Windows.Forms.Button btnEditProdoct;
        private Papiloo.ucButton ucAddStore;
        private Papiloo.ucButton ucDelStore;
        public System.Windows.Forms.Button btnDelStore;
        public System.Windows.Forms.DataGridView dgStore;
        public System.Windows.Forms.Button btnRefreshDgProdoct;
        public System.Windows.Forms.Button btnRefreshDgStore;
        public System.Windows.Forms.DataGridView dgProdoct;
        public System.Windows.Forms.TextBox txtNameStore;
        private System.Windows.Forms.Button btnSaveAllProdoct;
        private Papiloo.FDate dateExpird;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdoctCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn ProdoctName;
        private System.Windows.Forms.DataGridViewTextBoxColumn NameStore;
        private System.Windows.Forms.DataGridViewTextBoxColumn Count;
        private System.Windows.Forms.DataGridViewTextBoxColumn Price;
        private System.Windows.Forms.DataGridViewTextBoxColumn Description;
        private System.Windows.Forms.DataGridViewTextBoxColumn DateExpired;
        private System.Windows.Forms.DataGridViewButtonColumn btnDelete;
        private System.Windows.Forms.Label lblTotalPrice;
        private System.Windows.Forms.Label label5;
        public System.Windows.Forms.Button btnTest;
        private System.Windows.Forms.Label lblSugettion;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolBtnAnbarReport;
        private System.Windows.Forms.Label lblExistingProdoct;
        private System.Windows.Forms.Label label7;
    }
}