namespace View
{
    partial class Authority_Setting
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle7 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            Model.Def def1 = new Model.Def();
            Model.Def def2 = new Model.Def();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.dgv_member = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cb_SelectBox = new System.Windows.Forms.ComboBox();
            this.tb_SelectData = new System.Windows.Forms.TextBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btn_Add = new System.Windows.Forms.Button();
            this.lbl_Value = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.lbl_Table = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Delete = new System.Windows.Forms.Button();
            this.btn_Update = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_Authority = new System.Windows.Forms.DataGridView();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Athority_Update = new System.Windows.Forms.Button();
            this.btn_Member_Update = new System.Windows.Forms.Button();
            this.def_authority_list = new View.UserController.DefBoard();
            this.def_authority_main = new View.UserController.DefBoard();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_member)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Authority)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label2.Location = new System.Drawing.Point(23, 46);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label2.Size = new System.Drawing.Size(89, 44);
            this.label2.TabIndex = 182;
            this.label2.Text = "항목";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(22, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 30);
            this.label1.TabIndex = 186;
            this.label1.Text = "※ Member List";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(22, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(147, 30);
            this.label3.TabIndex = 185;
            this.label3.Text = "※ Search Box";
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Search.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(648, 55);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(83, 27);
            this.btn_Search.TabIndex = 177;
            this.btn_Search.Text = "⌕ 조 회";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label4.Location = new System.Drawing.Point(336, 46);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label4.Size = new System.Drawing.Size(89, 44);
            this.label4.TabIndex = 187;
            this.label4.Text = "검색";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel1.Location = new System.Drawing.Point(23, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1872, 1);
            this.panel1.TabIndex = 189;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel2.Location = new System.Drawing.Point(22, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1872, 1);
            this.panel2.TabIndex = 190;
            // 
            // dgv_member
            // 
            this.dgv_member.AllowUserToAddRows = false;
            this.dgv_member.AllowUserToDeleteRows = false;
            this.dgv_member.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_member.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_member.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_member.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_member.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_member.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_member.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_member.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_member.ColumnHeadersHeight = 35;
            this.dgv_member.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_member.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_member.EnableHeadersVisualStyles = false;
            this.dgv_member.Location = new System.Drawing.Point(12, 138);
            this.dgv_member.Name = "dgv_member";
            this.dgv_member.ReadOnly = true;
            this.dgv_member.RowHeadersVisible = false;
            this.dgv_member.RowHeadersWidth = 5;
            this.dgv_member.RowTemplate.Height = 30;
            this.dgv_member.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_member.Size = new System.Drawing.Size(939, 807);
            this.dgv_member.TabIndex = 191;
            this.dgv_member.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_member_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "이름";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "직급";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "아이디";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "전화번호";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "권한 명";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // cb_SelectBox
            // 
            this.cb_SelectBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SelectBox.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_SelectBox.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.cb_SelectBox.FormattingEnabled = true;
            this.cb_SelectBox.Items.AddRange(new object[] {
            "ID",
            "이름",
            "직급",
            "전화번호"});
            this.cb_SelectBox.Location = new System.Drawing.Point(118, 53);
            this.cb_SelectBox.Name = "cb_SelectBox";
            this.cb_SelectBox.Size = new System.Drawing.Size(212, 28);
            this.cb_SelectBox.TabIndex = 192;
            // 
            // tb_SelectData
            // 
            this.tb_SelectData.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_SelectData.Location = new System.Drawing.Point(431, 55);
            this.tb_SelectData.Name = "tb_SelectData";
            this.tb_SelectData.Size = new System.Drawing.Size(212, 27);
            this.tb_SelectData.TabIndex = 194;
            // 
            // panel3
            // 
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.btn_Add);
            this.panel3.Controls.Add(this.lbl_Value);
            this.panel3.Controls.Add(this.label9);
            this.panel3.Controls.Add(this.lbl_Table);
            this.panel3.Controls.Add(this.label6);
            this.panel3.Controls.Add(this.btn_Delete);
            this.panel3.Controls.Add(this.btn_Update);
            this.panel3.Controls.Add(this.label5);
            this.panel3.Location = new System.Drawing.Point(1503, 571);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(379, 189);
            this.panel3.TabIndex = 197;
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Add.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(132, 143);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(75, 41);
            this.btn_Add.TabIndex = 21;
            this.btn_Add.Text = "↺ 추 가";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // lbl_Value
            // 
            this.lbl_Value.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Value.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Value.Location = new System.Drawing.Point(168, 93);
            this.lbl_Value.Name = "lbl_Value";
            this.lbl_Value.Size = new System.Drawing.Size(200, 41);
            this.lbl_Value.TabIndex = 20;
            this.lbl_Value.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label9.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.label9.Location = new System.Drawing.Point(168, 53);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(200, 41);
            this.label9.TabIndex = 19;
            this.label9.Text = "선택 값";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Table
            // 
            this.lbl_Table.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lbl_Table.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Table.Location = new System.Drawing.Point(9, 93);
            this.lbl_Table.Name = "lbl_Table";
            this.lbl_Table.Size = new System.Drawing.Size(160, 41);
            this.lbl_Table.TabIndex = 18;
            this.lbl_Table.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(9, 53);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(160, 41);
            this.label6.TabIndex = 17;
            this.label6.Text = "선택 위치";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Delete
            // 
            this.btn_Delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Delete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Delete.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_Delete.ForeColor = System.Drawing.Color.White;
            this.btn_Delete.Location = new System.Drawing.Point(294, 143);
            this.btn_Delete.Name = "btn_Delete";
            this.btn_Delete.Size = new System.Drawing.Size(75, 41);
            this.btn_Delete.TabIndex = 16;
            this.btn_Delete.Text = "⊝ 삭 제";
            this.btn_Delete.UseVisualStyleBackColor = false;
            this.btn_Delete.Click += new System.EventHandler(this.btn_Delete_Click);
            // 
            // btn_Update
            // 
            this.btn_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Update.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Update.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Update.Location = new System.Drawing.Point(213, 143);
            this.btn_Update.Name = "btn_Update";
            this.btn_Update.Size = new System.Drawing.Size(75, 41);
            this.btn_Update.TabIndex = 15;
            this.btn_Update.Text = "↺ 수 정";
            this.btn_Update.UseVisualStyleBackColor = false;
            this.btn_Update.Click += new System.EventHandler(this.btn_Update_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.MenuBar;
            this.label5.Dock = System.Windows.Forms.DockStyle.Top;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 14F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(0, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(377, 38);
            this.label5.TabIndex = 13;
            this.label5.Text = "선택 정보";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Authority
            // 
            this.dgv_Authority.AllowUserToAddRows = false;
            this.dgv_Authority.AllowUserToDeleteRows = false;
            this.dgv_Authority.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.Empty;
            this.dgv_Authority.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Authority.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Authority.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Authority.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_Authority.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Authority.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Authority.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Authority.ColumnHeadersHeight = 35;
            this.dgv_Authority.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column6,
            this.Column7});
            dataGridViewCellStyle7.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle7.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle7.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle7.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle7.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle7.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle7.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Authority.DefaultCellStyle = dataGridViewCellStyle7;
            this.dgv_Authority.EnableHeadersVisualStyles = false;
            this.dgv_Authority.Location = new System.Drawing.Point(968, 137);
            this.dgv_Authority.Name = "dgv_Authority";
            this.dgv_Authority.ReadOnly = true;
            this.dgv_Authority.RowHeadersVisible = false;
            this.dgv_Authority.RowHeadersWidth = 5;
            this.dgv_Authority.RowTemplate.Height = 30;
            this.dgv_Authority.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Authority.Size = new System.Drawing.Size(914, 407);
            this.dgv_Authority.TabIndex = 198;
            this.dgv_Authority.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Authority_CellClick);
            // 
            // Column6
            // 
            this.Column6.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column6.FillWeight = 194.9239F;
            this.Column6.Frozen = true;
            this.Column6.HeaderText = "권한 명";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 200;
            // 
            // Column7
            // 
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.Column7.DefaultCellStyle = dataGridViewCellStyle6;
            this.Column7.FillWeight = 5.076141F;
            this.Column7.HeaderText = "권한 주소";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // btn_Athority_Update
            // 
            this.btn_Athority_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Athority_Update.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Athority_Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Athority_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Athority_Update.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_Athority_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Athority_Update.Location = new System.Drawing.Point(1724, 96);
            this.btn_Athority_Update.Name = "btn_Athority_Update";
            this.btn_Athority_Update.Size = new System.Drawing.Size(158, 35);
            this.btn_Athority_Update.TabIndex = 199;
            this.btn_Athority_Update.Text = "↺ 권한 리스트 수정";
            this.btn_Athority_Update.UseVisualStyleBackColor = false;
            this.btn_Athority_Update.Click += new System.EventHandler(this.btn_Athority_Update_Click);
            // 
            // btn_Member_Update
            // 
            this.btn_Member_Update.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Member_Update.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Member_Update.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Member_Update.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Member_Update.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_Member_Update.ForeColor = System.Drawing.Color.White;
            this.btn_Member_Update.Location = new System.Drawing.Point(831, 97);
            this.btn_Member_Update.Name = "btn_Member_Update";
            this.btn_Member_Update.Size = new System.Drawing.Size(120, 35);
            this.btn_Member_Update.TabIndex = 200;
            this.btn_Member_Update.Tag = "Authority";
            this.btn_Member_Update.Text = "↺ 권한 변경";
            this.btn_Member_Update.UseVisualStyleBackColor = false;
            this.btn_Member_Update.Click += new System.EventHandler(this.btn_Member_Update_Click);
            // 
            // def_authority_list
            // 
            def1.Columns = null;
            def1.SelectValue = null;
            def1.TableLogical = null;
            def1.TableName = null;
            def1.ValueLogical = null;
            this.def_authority_list.Def = def1;
            this.def_authority_list.Location = new System.Drawing.Point(1235, 571);
            this.def_authority_list.Name = "def_authority_list";
            this.def_authority_list.Size = new System.Drawing.Size(262, 373);
            this.def_authority_list.TabIndex = 196;
            this.def_authority_list.GetData += new System.EventHandler(this.def_GetData);
            this.def_authority_list.GetSelect += new System.EventHandler(this.def_GetSelect);
            // 
            // def_authority_main
            // 
            def2.Columns = null;
            def2.SelectValue = null;
            def2.TableLogical = null;
            def2.TableName = null;
            def2.ValueLogical = null;
            this.def_authority_main.Def = def2;
            this.def_authority_main.Location = new System.Drawing.Point(968, 571);
            this.def_authority_main.Name = "def_authority_main";
            this.def_authority_main.Size = new System.Drawing.Size(262, 373);
            this.def_authority_main.TabIndex = 195;
            this.def_authority_main.GetData += new System.EventHandler(this.def_GetData);
            this.def_authority_main.GetSelect += new System.EventHandler(this.def_GetSelect);
            // 
            // Authority_Setting
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1910, 956);
            this.Controls.Add(this.btn_Member_Update);
            this.Controls.Add(this.btn_Athority_Update);
            this.Controls.Add(this.dgv_Authority);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.def_authority_list);
            this.Controls.Add(this.def_authority_main);
            this.Controls.Add(this.tb_SelectData);
            this.Controls.Add(this.cb_SelectBox);
            this.Controls.Add(this.dgv_member);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Authority_Setting";
            this.Text = "MemberView";
            this.Load += new System.EventHandler(this.Authority_Setting_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_member)).EndInit();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Authority)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView dgv_member;
        private System.Windows.Forms.ComboBox cb_SelectBox;
        private System.Windows.Forms.TextBox tb_SelectData;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private UserController.DefBoard def_authority_main;
        private UserController.DefBoard def_authority_list;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Label lbl_Value;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label lbl_Table;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btn_Delete;
        private System.Windows.Forms.Button btn_Update;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_Authority;
        private System.Windows.Forms.Button btn_Athority_Update;
        private System.Windows.Forms.Button btn_Member_Update;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}