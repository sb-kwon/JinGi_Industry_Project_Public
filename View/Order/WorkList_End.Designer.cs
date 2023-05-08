
namespace View
{
    partial class WorkList_End
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
            this.btn_close = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.dgv_process = new System.Windows.Forms.DataGridView();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewButtonColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox9 = new System.Windows.Forms.ComboBox();
            this.button3 = new System.Windows.Forms.Button();
            this.comboBox7 = new System.Windows.Forms.ComboBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.rbt_good = new System.Windows.Forms.RadioButton();
            this.rbt_bad = new System.Windows.Forms.RadioButton();
            this.label2 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_all = new System.Windows.Forms.Button();
            this.dtp_time = new System.Windows.Forms.DateTimePicker();
            this.btn_start = new System.Windows.Forms.Button();
            this.dtp_date = new System.Windows.Forms.DateTimePicker();
            this.ck_time = new System.Windows.Forms.CheckBox();
            this.cb_Cause = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_process)).BeginInit();
            this.panel2.SuspendLayout();
            this.panel4.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_close
            // 
            this.btn_close.BackColor = System.Drawing.Color.White;
            this.btn_close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_close.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.btn_close.ForeColor = System.Drawing.Color.Black;
            this.btn_close.Location = new System.Drawing.Point(1188, 11);
            this.btn_close.Name = "btn_close";
            this.btn_close.Size = new System.Drawing.Size(98, 80);
            this.btn_close.TabIndex = 331;
            this.btn_close.Text = "닫 기";
            this.btn_close.UseVisualStyleBackColor = false;
            this.btn_close.Click += new System.EventHandler(this.btn_close_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label6.Location = new System.Drawing.Point(8, 61);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(177, 30);
            this.label6.TabIndex = 257;
            this.label6.Text = "※ 작업 중인 목록";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Window;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.cb_Cause);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.dgv_process);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel4);
            this.panel1.Controls.Add(this.button1);
            this.panel1.Controls.Add(this.btn_delete);
            this.panel1.Controls.Add(this.btn_all);
            this.panel1.Controls.Add(this.dtp_time);
            this.panel1.Controls.Add(this.btn_start);
            this.panel1.Controls.Add(this.dtp_date);
            this.panel1.Controls.Add(this.btn_close);
            this.panel1.Controls.Add(this.ck_time);
            this.panel1.Controls.Add(this.label6);
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1298, 658);
            this.panel1.TabIndex = 1;
            // 
            // dgv_process
            // 
            this.dgv_process.AllowUserToAddRows = false;
            this.dgv_process.AllowUserToDeleteRows = false;
            this.dgv_process.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_process.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_process.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_process.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_process.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_process.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_process.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_process.ColumnHeadersHeight = 40;
            this.dgv_process.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_process.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column8,
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column14,
            this.Column16,
            this.Column17,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column6,
            this.Column12,
            this.Column13,
            this.Column9,
            this.Column18,
            this.Column11,
            this.Column10,
            this.Column15});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.Format = "#,##0";
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_process.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_process.EnableHeadersVisualStyles = false;
            this.dgv_process.Location = new System.Drawing.Point(13, 97);
            this.dgv_process.MultiSelect = false;
            this.dgv_process.Name = "dgv_process";
            this.dgv_process.ReadOnly = true;
            this.dgv_process.RowHeadersVisible = false;
            this.dgv_process.RowTemplate.Height = 30;
            this.dgv_process.RowTemplate.ReadOnly = true;
            this.dgv_process.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_process.Size = new System.Drawing.Size(1273, 459);
            this.dgv_process.TabIndex = 349;
            this.dgv_process.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_process_CellClick);
            // 
            // Column8
            // 
            this.Column8.HeaderText = "수주번호";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "수주명";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Width = 171;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "지시번호";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 120;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "공정명";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Width = 70;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "공정 타입";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 70;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "공정순서";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Visible = false;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "진행상태";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "작업자아이디";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "작업자";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "장비번호";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "장비명";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "작업일정 (시작)";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Width = 110;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "작업일정(종료)";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Width = 110;
            // 
            // Column9
            // 
            this.Column9.FillWeight = 200F;
            this.Column9.HeaderText = "시작 시간";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Width = 230;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "상세보기";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Width = 90;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "일시중지";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Resizable = System.Windows.Forms.DataGridViewTriState.True;
            this.Column11.SortMode = System.Windows.Forms.DataGridViewColumnSortMode.Automatic;
            this.Column11.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "번호";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            this.Column10.Visible = false;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "공정 그룹";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            // 
            // panel2
            // 
            this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel2.Controls.Add(this.comboBox9);
            this.panel2.Controls.Add(this.button3);
            this.panel2.Controls.Add(this.comboBox7);
            this.panel2.Controls.Add(this.label13);
            this.panel2.Controls.Add(this.label12);
            this.panel2.Controls.Add(this.label11);
            this.panel2.Controls.Add(this.label8);
            this.panel2.Controls.Add(this.label7);
            this.panel2.Controls.Add(this.label5);
            this.panel2.Location = new System.Drawing.Point(218, 11);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(770, 80);
            this.panel2.TabIndex = 348;
            // 
            // comboBox9
            // 
            this.comboBox9.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox9.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.comboBox9.FormattingEnabled = true;
            this.comboBox9.IntegralHeight = false;
            this.comboBox9.ItemHeight = 20;
            this.comboBox9.Location = new System.Drawing.Point(481, 41);
            this.comboBox9.Name = "comboBox9";
            this.comboBox9.Size = new System.Drawing.Size(150, 28);
            this.comboBox9.TabIndex = 351;
            // 
            // button3
            // 
            this.button3.BackColor = System.Drawing.Color.White;
            this.button3.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button3.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.button3.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button3.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.button3.ForeColor = System.Drawing.Color.Black;
            this.button3.Location = new System.Drawing.Point(637, 10);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(119, 59);
            this.button3.TabIndex = 340;
            this.button3.Text = "찾 기";
            this.button3.UseVisualStyleBackColor = false;
            this.button3.Click += new System.EventHandler(this.button3_Click);
            // 
            // comboBox7
            // 
            this.comboBox7.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox7.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.comboBox7.FormattingEnabled = true;
            this.comboBox7.IntegralHeight = false;
            this.comboBox7.ItemHeight = 20;
            this.comboBox7.Location = new System.Drawing.Point(325, 41);
            this.comboBox7.Name = "comboBox7";
            this.comboBox7.Size = new System.Drawing.Size(150, 28);
            this.comboBox7.TabIndex = 349;
            // 
            // label13
            // 
            this.label13.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label13.Location = new System.Drawing.Point(169, 41);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(150, 28);
            this.label13.TabIndex = 346;
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label13.Click += new System.EventHandler(this.label14_Click);
            // 
            // label12
            // 
            this.label12.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 10F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(13, 41);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(150, 28);
            this.label12.TabIndex = 345;
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.label12.Click += new System.EventHandler(this.label14_Click);
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label11.Location = new System.Drawing.Point(481, 10);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(150, 28);
            this.label11.TabIndex = 264;
            this.label11.Text = "장 비";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label8.Location = new System.Drawing.Point(325, 10);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(150, 28);
            this.label8.TabIndex = 261;
            this.label8.Text = "공정 타입";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label7.Location = new System.Drawing.Point(169, 10);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(150, 28);
            this.label7.TabIndex = 260;
            this.label7.Text = "작업 번호";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(13, 10);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(150, 28);
            this.label5.TabIndex = 259;
            this.label5.Text = "수주 명";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.Window;
            this.panel4.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel4.Controls.Add(this.rbt_good);
            this.panel4.Controls.Add(this.rbt_bad);
            this.panel4.Controls.Add(this.label2);
            this.panel4.Location = new System.Drawing.Point(329, 562);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(404, 81);
            this.panel4.TabIndex = 343;
            // 
            // rbt_good
            // 
            this.rbt_good.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbt_good.BackColor = System.Drawing.Color.Lime;
            this.rbt_good.Checked = true;
            this.rbt_good.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbt_good.Dock = System.Windows.Forms.DockStyle.Left;
            this.rbt_good.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.rbt_good.Location = new System.Drawing.Point(0, 24);
            this.rbt_good.Name = "rbt_good";
            this.rbt_good.Size = new System.Drawing.Size(200, 55);
            this.rbt_good.TabIndex = 163;
            this.rbt_good.TabStop = true;
            this.rbt_good.Tag = "1";
            this.rbt_good.Text = "양호";
            this.rbt_good.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbt_good.UseVisualStyleBackColor = false;
            this.rbt_good.CheckedChanged += new System.EventHandler(this.rbt_good_CheckedChanged);
            // 
            // rbt_bad
            // 
            this.rbt_bad.Appearance = System.Windows.Forms.Appearance.Button;
            this.rbt_bad.BackColor = System.Drawing.Color.LightGray;
            this.rbt_bad.Cursor = System.Windows.Forms.Cursors.Hand;
            this.rbt_bad.Dock = System.Windows.Forms.DockStyle.Right;
            this.rbt_bad.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.rbt_bad.Location = new System.Drawing.Point(202, 24);
            this.rbt_bad.Name = "rbt_bad";
            this.rbt_bad.Size = new System.Drawing.Size(200, 55);
            this.rbt_bad.TabIndex = 164;
            this.rbt_bad.Tag = "0";
            this.rbt_bad.Text = "불량";
            this.rbt_bad.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.rbt_bad.UseVisualStyleBackColor = false;
            this.rbt_bad.CheckedChanged += new System.EventHandler(this.rbt_bad_CheckedChanged);
            // 
            // label2
            // 
            this.label2.Dock = System.Windows.Forms.DockStyle.Top;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.label2.Location = new System.Drawing.Point(0, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(402, 24);
            this.label2.TabIndex = 162;
            this.label2.Text = "공정 검사";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.button1.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.button1.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.button1.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.button1.ForeColor = System.Drawing.Color.White;
            this.button1.Location = new System.Drawing.Point(172, 562);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(153, 81);
            this.button1.TabIndex = 347;
            this.button1.Text = "－ 일시중지";
            this.button1.UseVisualStyleBackColor = false;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // btn_delete
            // 
            this.btn_delete.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_delete.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_delete.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_delete.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_delete.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.btn_delete.ForeColor = System.Drawing.Color.White;
            this.btn_delete.Location = new System.Drawing.Point(13, 562);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(153, 81);
            this.btn_delete.TabIndex = 342;
            this.btn_delete.Text = "× 공정 폐기";
            this.btn_delete.UseVisualStyleBackColor = false;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_all
            // 
            this.btn_all.BackColor = System.Drawing.Color.White;
            this.btn_all.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_all.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_all.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_all.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.btn_all.ForeColor = System.Drawing.Color.Black;
            this.btn_all.Location = new System.Drawing.Point(994, 11);
            this.btn_all.Name = "btn_all";
            this.btn_all.Size = new System.Drawing.Size(188, 80);
            this.btn_all.TabIndex = 339;
            this.btn_all.Text = "전체보기";
            this.btn_all.UseVisualStyleBackColor = false;
            this.btn_all.Click += new System.EventHandler(this.btn_all_Click);
            // 
            // dtp_time
            // 
            this.dtp_time.Enabled = false;
            this.dtp_time.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.dtp_time.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.dtp_time.Location = new System.Drawing.Point(992, 611);
            this.dtp_time.Name = "dtp_time";
            this.dtp_time.ShowUpDown = true;
            this.dtp_time.Size = new System.Drawing.Size(128, 31);
            this.dtp_time.TabIndex = 345;
            // 
            // btn_start
            // 
            this.btn_start.BackColor = System.Drawing.Color.Red;
            this.btn_start.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_start.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_start.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_start.Font = new System.Drawing.Font("맑은 고딕", 15F, System.Drawing.FontStyle.Bold);
            this.btn_start.ForeColor = System.Drawing.Color.White;
            this.btn_start.Location = new System.Drawing.Point(1126, 562);
            this.btn_start.Name = "btn_start";
            this.btn_start.Size = new System.Drawing.Size(160, 81);
            this.btn_start.TabIndex = 346;
            this.btn_start.Text = "작 업 완 료";
            this.btn_start.UseVisualStyleBackColor = false;
            this.btn_start.Click += new System.EventHandler(this.btn_start_Click);
            // 
            // dtp_date
            // 
            this.dtp_date.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.dtp_date.Enabled = false;
            this.dtp_date.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.dtp_date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtp_date.Location = new System.Drawing.Point(858, 611);
            this.dtp_date.Name = "dtp_date";
            this.dtp_date.Size = new System.Drawing.Size(128, 31);
            this.dtp_date.TabIndex = 344;
            // 
            // ck_time
            // 
            this.ck_time.BackColor = System.Drawing.SystemColors.Control;
            this.ck_time.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.ck_time.Location = new System.Drawing.Point(858, 562);
            this.ck_time.Name = "ck_time";
            this.ck_time.Padding = new System.Windows.Forms.Padding(18, 10, 10, 10);
            this.ck_time.Size = new System.Drawing.Size(282, 44);
            this.ck_time.TabIndex = 343;
            this.ck_time.Text = "수동 날짜 설정";
            this.ck_time.UseVisualStyleBackColor = false;
            this.ck_time.CheckedChanged += new System.EventHandler(this.ck_time_CheckedChanged);
            // 
            // cb_Cause
            // 
            this.cb_Cause.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Cause.Font = new System.Drawing.Font("맑은 고딕", 13F);
            this.cb_Cause.FormattingEnabled = true;
            this.cb_Cause.Items.AddRange(new object[] {
            "CAD",
            "자재",
            "절단",
            "절곡",
            "도금",
            "용접"});
            this.cb_Cause.Location = new System.Drawing.Point(739, 611);
            this.cb_Cause.Name = "cb_Cause";
            this.cb_Cause.Size = new System.Drawing.Size(113, 31);
            this.cb_Cause.TabIndex = 353;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(739, 562);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 44);
            this.label1.TabIndex = 352;
            this.label1.Text = "불량 사유";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // WorkList_End
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1299, 659);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "WorkList_End";
            this.Text = "WorkList_End";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_process)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel4.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btn_close;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btn_all;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.CheckBox ck_time;
        private System.Windows.Forms.DateTimePicker dtp_date;
        private System.Windows.Forms.DateTimePicker dtp_time;
        private System.Windows.Forms.Button btn_start;
        private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Panel panel4;
		private System.Windows.Forms.RadioButton rbt_good;
		private System.Windows.Forms.RadioButton rbt_bad;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.ComboBox comboBox9;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.ComboBox comboBox7;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DataGridView dgv_process;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewButtonColumn Column18;
        private System.Windows.Forms.DataGridViewButtonColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.ComboBox cb_Cause;
        private System.Windows.Forms.Label label1;
    }
}