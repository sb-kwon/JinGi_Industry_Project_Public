
namespace View
{
    partial class OrderInput
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dtp_date_End = new System.Windows.Forms.DateTimePicker();
            this.cb_CGroup = new System.Windows.Forms.ComboBox();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.cb_OrderState = new System.Windows.Forms.ComboBox();
            this.tb_OrderName = new System.Windows.Forms.TextBox();
            this.tb_CustomerName = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.checkBox2 = new System.Windows.Forms.CheckBox();
            this.label12 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_bom_add = new System.Windows.Forms.Button();
            this.label11 = new System.Windows.Forms.Label();
            this.lbl_Price = new System.Windows.Forms.Label();
            this.dgv_order = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_order_detail = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_order)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_order_detail)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(17, 97);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(170, 30);
            this.label1.TabIndex = 201;
            this.label1.Text = "※ 진행중인 수주";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(128, 30);
            this.label3.TabIndex = 200;
            this.label3.Text = "※ 수주 조회";
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Search.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(1789, 10);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(83, 33);
            this.btn_Search.TabIndex = 195;
            this.btn_Search.Text = "☜ 조 회";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Add.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(1557, 6);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(141, 33);
            this.btn_Add.TabIndex = 198;
            this.btn_Add.Text = "↺ 수주 추가";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Update.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Update.Location = new System.Drawing.Point(1711, 6);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(83, 33);
            this.btn_Update.TabIndex = 196;
            this.btn_Update.Text = "↺ 수 정";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Delete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(1806, 6);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(83, 33);
            this.btn_Delete.TabIndex = 197;
            this.btn_Delete.Text = "⊝ 삭 제";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(17, 523);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(228, 30);
            this.label6.TabIndex = 210;
            this.label6.Text = "※ 수주 상세보기(품목)";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn4});
            this.dataGridView1.Location = new System.Drawing.Point(17, 771);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 23;
            this.dataGridView1.Size = new System.Drawing.Size(1871, 61);
            this.dataGridView1.TabIndex = 216;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "수주명";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "제품번호";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "수량";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // dataGridViewTextBoxColumn4
            // 
            this.dataGridViewTextBoxColumn4.HeaderText = "단가";
            this.dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.dtp_date_End);
            this.panel1.Controls.Add(this.cb_CGroup);
            this.panel1.Controls.Add(this.dtp_date);
            this.panel1.Controls.Add(this.cb_OrderState);
            this.panel1.Controls.Add(this.tb_OrderName);
            this.panel1.Controls.Add(this.tb_CustomerName);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label4);
            this.panel1.Controls.Add(this.checkBox2);
            this.panel1.Controls.Add(this.btn_Search);
            this.panel1.Controls.Add(this.label12);
            this.panel1.Location = new System.Drawing.Point(17, 42);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1881, 52);
            this.panel1.TabIndex = 217;
            // 
            // dtp_date_End
            // 
            this.dtp_date_End.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtp_date_End.Enabled = false;
            this.dtp_date_End.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.dtp_date_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_date_End.Location = new System.Drawing.Point(1589, 12);
            this.dtp_date_End.Name = "dtp_date_End";
            this.dtp_date_End.Size = new System.Drawing.Size(195, 27);
            this.dtp_date_End.TabIndex = 356;
            // 
            // cb_CGroup
            // 
            this.cb_CGroup.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_CGroup.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cb_CGroup.FormattingEnabled = true;
            this.cb_CGroup.IntegralHeight = false;
            this.cb_CGroup.ItemHeight = 20;
            this.cb_CGroup.Location = new System.Drawing.Point(1105, 12);
            this.cb_CGroup.Name = "cb_CGroup";
            this.cb_CGroup.Size = new System.Drawing.Size(150, 28);
            this.cb_CGroup.TabIndex = 355;
            // 
            // dtp_date
            // 
            this.dtp_date.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtp_date.Enabled = false;
            this.dtp_date.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtp_date.Location = new System.Drawing.Point(1388, 12);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(195, 27);
            this.dtp_date.TabIndex = 258;
            // 
            // cb_OrderState
            // 
            this.cb_OrderState.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_OrderState.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.cb_OrderState.FormattingEnabled = true;
            this.cb_OrderState.IntegralHeight = false;
            this.cb_OrderState.ItemHeight = 20;
            this.cb_OrderState.Location = new System.Drawing.Point(475, 13);
            this.cb_OrderState.Name = "cb_OrderState";
            this.cb_OrderState.Size = new System.Drawing.Size(150, 28);
            this.cb_OrderState.TabIndex = 353;
            // 
            // tb_OrderName
            // 
            this.tb_OrderName.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_OrderName.Location = new System.Drawing.Point(131, 12);
            this.tb_OrderName.Name = "tb_OrderName";
            this.tb_OrderName.Size = new System.Drawing.Size(213, 27);
            this.tb_OrderName.TabIndex = 252;
            // 
            // tb_CustomerName
            // 
            this.tb_CustomerName.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_CustomerName.Location = new System.Drawing.Point(761, 12);
            this.tb_CustomerName.Name = "tb_CustomerName";
            this.tb_CustomerName.Size = new System.Drawing.Size(213, 27);
            this.tb_CustomerName.TabIndex = 251;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel2.Location = new System.Drawing.Point(4, 47);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1872, 1);
            this.panel2.TabIndex = 241;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.ControlDarkDark;
            this.panel3.Location = new System.Drawing.Point(5, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1872, 1);
            this.panel3.TabIndex = 240;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label5.Location = new System.Drawing.Point(636, 4);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label5.Size = new System.Drawing.Size(119, 44);
            this.label5.TabIndex = 239;
            this.label5.Text = "거래처명";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label2.Location = new System.Drawing.Point(5, 4);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label2.Size = new System.Drawing.Size(119, 44);
            this.label2.TabIndex = 237;
            this.label2.Text = "수주명";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label4.Location = new System.Drawing.Point(350, 4);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label4.Size = new System.Drawing.Size(119, 44);
            this.label4.TabIndex = 253;
            this.label4.Text = "수주상태";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // checkBox2
            // 
            this.checkBox2.BackColor = System.Drawing.SystemColors.Control;
            this.checkBox2.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.checkBox2.Location = new System.Drawing.Point(1261, 4);
            this.checkBox2.Name = "checkBox2";
            this.checkBox2.Padding = new System.Windows.Forms.Padding(18, 10, 10, 10);
            this.checkBox2.Size = new System.Drawing.Size(121, 44);
            this.checkBox2.TabIndex = 257;
            this.checkBox2.Text = "수주 날짜";
            this.checkBox2.UseVisualStyleBackColor = false;
            this.checkBox2.CheckedChanged += new System.EventHandler(this.checkBox2_CheckedChanged);
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label12.Location = new System.Drawing.Point(980, 4);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(15, 12, 20, 12);
            this.label12.Size = new System.Drawing.Size(119, 44);
            this.label12.TabIndex = 354;
            this.label12.Text = "거래처그룹";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label7.Location = new System.Drawing.Point(255, 533);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 20);
            this.label7.TabIndex = 218;
            this.label7.Text = "착수일 :";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label8.Location = new System.Drawing.Point(324, 533);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(0, 20);
            this.label8.TabIndex = 219;
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label9.Location = new System.Drawing.Point(595, 532);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(0, 20);
            this.label9.TabIndex = 221;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label10.Location = new System.Drawing.Point(500, 532);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 20);
            this.label10.TabIndex = 220;
            this.label10.Text = "생산완료일 :";
            // 
            // btn_bom_add
            // 
            this.btn_bom_add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_bom_add.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_bom_add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_bom_add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_bom_add.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_bom_add.ForeColor = System.Drawing.Color.White;
            this.btn_bom_add.Location = new System.Drawing.Point(1418, 6);
            this.btn_bom_add.Name = "btn_bom_add";
            this.btn_bom_add.Size = new System.Drawing.Size(133, 33);
            this.btn_bom_add.TabIndex = 222;
            this.btn_bom_add.Text = "↺ BOM 추가";
            this.btn_bom_add.UseVisualStyleBackColor = false;
            this.btn_bom_add.Click += new System.EventHandler(this.btn_bom_add_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label11.Location = new System.Drawing.Point(193, 106);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(117, 20);
            this.label11.TabIndex = 223;
            this.label11.Text = "수주 총합 금액 :";
            // 
            // lbl_Price
            // 
            this.lbl_Price.AutoSize = true;
            this.lbl_Price.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_Price.Location = new System.Drawing.Point(316, 106);
            this.lbl_Price.Name = "lbl_Price";
            this.lbl_Price.Size = new System.Drawing.Size(0, 20);
            this.lbl_Price.TabIndex = 224;
            // 
            // dgv_order
            // 
            this.dgv_order.AllowUserToAddRows = false;
            this.dgv_order.AllowUserToDeleteRows = false;
            this.dgv_order.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_order.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_order.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_order.BackgroundColor = System.Drawing.Color.White;
            this.dgv_order.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_order.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_order.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_order.ColumnHeadersHeight = 35;
            this.dgv_order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column17,
            this.Column5,
            this.Column18,
            this.Column3,
            this.Column4,
            this.Column12,
            this.Column7,
            this.Column6});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_order.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_order.EnableHeadersVisualStyles = false;
            this.dgv_order.Location = new System.Drawing.Point(17, 138);
            this.dgv_order.MultiSelect = false;
            this.dgv_order.Name = "dgv_order";
            this.dgv_order.RowHeadersVisible = false;
            this.dgv_order.RowHeadersWidth = 5;
            this.dgv_order.RowTemplate.Height = 30;
            this.dgv_order.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_order.Size = new System.Drawing.Size(1871, 372);
            this.dgv_order.TabIndex = 225;
            this.dgv_order.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_order_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "수주번호";
            this.Column1.Name = "Column1";
            this.Column1.Width = 85;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "수주명";
            this.Column2.Name = "Column2";
            this.Column2.Width = 444;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "수주상태";
            this.Column17.Name = "Column17";
            this.Column17.Width = 120;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "거래처";
            this.Column5.Name = "Column5";
            this.Column5.Width = 200;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "거래처 담당자";
            this.Column18.Name = "Column18";
            this.Column18.Width = 130;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "수주일자";
            this.Column3.Name = "Column3";
            this.Column3.Width = 200;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "출하 예정일";
            this.Column4.Name = "Column4";
            this.Column4.Width = 200;
            // 
            // Column12
            // 
            this.Column12.FillWeight = 115F;
            this.Column12.HeaderText = "수주 금액(원)";
            this.Column12.Name = "Column12";
            this.Column12.Width = 115;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "메모";
            this.Column7.Name = "Column7";
            this.Column7.Width = 250;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "긴급";
            this.Column6.Name = "Column6";
            this.Column6.Width = 125;
            // 
            // dgv_order_detail
            // 
            this.dgv_order_detail.AllowUserToAddRows = false;
            this.dgv_order_detail.AllowUserToDeleteRows = false;
            this.dgv_order_detail.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_order_detail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_order_detail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_order_detail.BackgroundColor = System.Drawing.Color.White;
            this.dgv_order_detail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_order_detail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_order_detail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_order_detail.ColumnHeadersHeight = 35;
            this.dgv_order_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_order_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column9,
            this.Column15,
            this.Column16,
            this.Column10,
            this.Column11,
            this.Column13,
            this.Column14});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_order_detail.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_order_detail.EnableHeadersVisualStyles = false;
            this.dgv_order_detail.Location = new System.Drawing.Point(17, 563);
            this.dgv_order_detail.MultiSelect = false;
            this.dgv_order_detail.Name = "dgv_order_detail";
            this.dgv_order_detail.ReadOnly = true;
            this.dgv_order_detail.RowHeadersVisible = false;
            this.dgv_order_detail.RowTemplate.Height = 30;
            this.dgv_order_detail.RowTemplate.ReadOnly = true;
            this.dgv_order_detail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_order_detail.Size = new System.Drawing.Size(1871, 354);
            this.dgv_order_detail.TabIndex = 226;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "수주명";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 368;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "품목번호";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "품목명";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 280;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "품목타입";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 200;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "수량(개)";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Width = 160;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "단가(원)";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Width = 170;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "합계(원)";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 270;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "비고";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 421;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(1462, 99);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(138, 33);
            this.button1.TabIndex = 227;
            this.button1.Text = "신규 파일 생성";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Visible = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.button2.Enabled = false;
            this.button2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.button2.ForeColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(1750, 99);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(138, 33);
            this.button2.TabIndex = 227;
            this.button2.Text = "현재 항목 저장";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Visible = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.button3.Enabled = false;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.White;
            this.button3.Location = new System.Drawing.Point(1606, 99);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(138, 33);
            this.button3.TabIndex = 228;
            this.button3.Text = "파일 불러오기";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Visible = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // OrderInput
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1910, 956);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dgv_order_detail);
            this.Controls.Add(this.dgv_order);
            this.Controls.Add(this.lbl_Price);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_bom_add);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Add);
            this.Controls.Add(this.btn_Update);
            this.Controls.Add(this.btn_Delete);
            this.Controls.Add(this.dataGridView1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "OrderInput";
            this.Text = "OrderInput";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_order)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_order_detail)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox tb_CustomerName;
        private System.Windows.Forms.TextBox tb_OrderName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_OrderState;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.CheckBox checkBox2;
        private System.Windows.Forms.Button btn_bom_add;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label lbl_Price;
        private System.Windows.Forms.ComboBox cb_CGroup;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DataGridView dgv_order;
        private System.Windows.Forms.DataGridView dgv_order_detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
		private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
		private System.Windows.Forms.OpenFileDialog openFileDialog1;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.Button button3;
        private System.Windows.Forms.DateTimePicker dtp_date_End;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
    }
}