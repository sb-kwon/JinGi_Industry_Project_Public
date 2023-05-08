
namespace View
{
    partial class Schedule_Machine
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.calendar1 = new Calendar.NET.Calendar();
            this.dgv_machine = new System.Windows.Forms.DataGridView();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cb_Type = new FlatComboBox();
            this.tb_MachineName = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.dgv_Product = new System.Windows.Forms.DataGridView();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label4 = new System.Windows.Forms.Label();
            this.Btn_All = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label200 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_C_Group = new System.Windows.Forms.Label();
            this.lbl_C_No = new System.Windows.Forms.Label();
            this.label100 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_RealStart = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_RealEnd = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.lbl_End = new System.Windows.Forms.Label();
            this.lbl_OrderName = new System.Windows.Forms.Label();
            this.lbl_Memo = new System.Windows.Forms.Label();
            this.lbl_Start = new System.Windows.Forms.Label();
            this.lbl_Member = new System.Windows.Forms.Label();
            this.lbl_State = new System.Windows.Forms.Label();
            this.lbl_Type = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_machine)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Product)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(1057, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(240, 30);
            this.label2.TabIndex = 235;
            this.label2.Text = "※ 작업중인 장비 리스트";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(1057, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 30);
            this.label1.TabIndex = 233;
            this.label1.Text = "※ 장비명 조회";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(18, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 30);
            this.label3.TabIndex = 232;
            this.label3.Text = "※ 일정표";
            // 
            // calendar1
            // 
            this.calendar1.AllowEditingEvents = true;
            this.calendar1.CalendarDate = new System.DateTime(2021, 6, 24, 0, 0, 0, 0);
            this.calendar1.CalendarView = Calendar.NET.CalendarViews.Month;
            this.calendar1.DateHeaderFont = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.calendar1.DayOfWeekFont = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.calendar1.DaysFont = new System.Drawing.Font("맑은 고딕", 9F);
            this.calendar1.DayViewTimeFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.calendar1.DimDisabledEvents = true;
            this.calendar1.ForeColor = System.Drawing.SystemColors.Desktop;
            this.calendar1.HighlightCurrentDay = true;
            this.calendar1.LoadPresetHolidays = true;
            this.calendar1.Location = new System.Drawing.Point(1, 42);
            this.calendar1.Name = "calendar1";
            this.calendar1.ShowArrowControls = true;
            this.calendar1.ShowDashedBorderOnDisabledEvents = true;
            this.calendar1.ShowDateInHeader = true;
            this.calendar1.ShowDisabledEvents = false;
            this.calendar1.ShowEventTooltips = true;
            this.calendar1.ShowTodayButton = true;
            this.calendar1.Size = new System.Drawing.Size(1051, 907);
            this.calendar1.TabIndex = 231;
            this.calendar1.TodayFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            // 
            // dgv_machine
            // 
            this.dgv_machine.AllowUserToAddRows = false;
            this.dgv_machine.AllowUserToDeleteRows = false;
            this.dgv_machine.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_machine.ColumnHeadersHeight = 40;
            this.dgv_machine.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column4,
            this.Column1,
            this.Column9,
            this.Column8,
            this.Column2,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column13});
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle1.Format = "#,##0";
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_machine.DefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_machine.Location = new System.Drawing.Point(1083, 118);
            this.dgv_machine.Name = "dgv_machine";
            this.dgv_machine.ReadOnly = true;
            this.dgv_machine.RowTemplate.Height = 30;
            this.dgv_machine.RowTemplate.ReadOnly = true;
            this.dgv_machine.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_machine.Size = new System.Drawing.Size(780, 238);
            this.dgv_machine.TabIndex = 237;
            this.dgv_machine.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_machine_CellClick);
            // 
            // Column4
            // 
            this.Column4.HeaderText = "고유번호";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "장비명";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "장비 타입";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "작업 상태";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "수주명";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "작업자";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "작업 예정일";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "종료 예정일";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "장비 메모";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Cb_Type
            // 
            this.Cb_Type.BorderColor = System.Drawing.Color.Black;
            this.Cb_Type.ButtonColor = System.Drawing.Color.LightSkyBlue;
            this.Cb_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_Type.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.Cb_Type.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Cb_Type.FormattingEnabled = true;
            this.Cb_Type.Items.AddRange(new object[] {
            "작업 중",
            "작업완료",
            "폐기"});
            this.Cb_Type.Location = new System.Drawing.Point(1594, 10);
            this.Cb_Type.Name = "Cb_Type";
            this.Cb_Type.Size = new System.Drawing.Size(179, 29);
            this.Cb_Type.TabIndex = 274;
            // 
            // tb_MachineName
            // 
            this.tb_MachineName.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_MachineName.Location = new System.Drawing.Point(1212, 12);
            this.tb_MachineName.Name = "tb_MachineName";
            this.tb_MachineName.Size = new System.Drawing.Size(193, 27);
            this.tb_MachineName.TabIndex = 278;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(1411, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 30);
            this.label5.TabIndex = 279;
            this.label5.Text = "※ 장비 타입 선택";
            // 
            // Btn_Search
            // 
            this.Btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.Btn_Search.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.Btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_Search.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.Btn_Search.ForeColor = System.Drawing.Color.White;
            this.Btn_Search.Location = new System.Drawing.Point(1779, 10);
            this.Btn_Search.Name = "Btn_Search";
            this.Btn_Search.Size = new System.Drawing.Size(83, 29);
            this.Btn_Search.TabIndex = 280;
            this.Btn_Search.Text = "⌕ 조 회";
            this.Btn_Search.UseVisualStyleBackColor = false;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // dgv_Product
            // 
            this.dgv_Product.AllowUserToAddRows = false;
            this.dgv_Product.AllowUserToDeleteRows = false;
            this.dgv_Product.AllowUserToResizeRows = false;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_Product.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Product.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Product.BackgroundColor = System.Drawing.Color.White;
            this.dgv_Product.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Product.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Product.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Product.ColumnHeadersHeight = 40;
            this.dgv_Product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_Product.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column10,
            this.Column15,
            this.Column11,
            this.Column16,
            this.Column12,
            this.dataGridViewTextBoxColumn1,
            this.Column14});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Product.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Product.EnableHeadersVisualStyles = false;
            this.dgv_Product.Location = new System.Drawing.Point(1083, 386);
            this.dgv_Product.MultiSelect = false;
            this.dgv_Product.Name = "dgv_Product";
            this.dgv_Product.ReadOnly = true;
            this.dgv_Product.RowHeadersVisible = false;
            this.dgv_Product.RowTemplate.Height = 30;
            this.dgv_Product.RowTemplate.ReadOnly = true;
            this.dgv_Product.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Product.Size = new System.Drawing.Size(780, 563);
            this.dgv_Product.TabIndex = 282;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "품목 번호";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "품목명";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 300;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "공정명";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "품목타입";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 150;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "작업 상태";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "수량";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Width = 80;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "비고";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 350;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(1057, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(289, 30);
            this.label4.TabIndex = 281;
            this.label4.Text = "※ 작업중인 장비 품목 리스트";
            // 
            // Btn_All
            // 
            this.Btn_All.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Btn_All.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.Btn_All.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.Btn_All.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Btn_All.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.Btn_All.ForeColor = System.Drawing.Color.White;
            this.Btn_All.Location = new System.Drawing.Point(1757, 84);
            this.Btn_All.Name = "Btn_All";
            this.Btn_All.Size = new System.Drawing.Size(105, 33);
            this.Btn_All.TabIndex = 305;
            this.Btn_All.Text = "⟲ 모두 보기";
            this.Btn_All.UseVisualStyleBackColor = false;
            this.Btn_All.Click += new System.EventHandler(this.Btn_All_Click);
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel6.Location = new System.Drawing.Point(1084, 334);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(780, 1);
            this.panel6.TabIndex = 302;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel5.Location = new System.Drawing.Point(1084, 291);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(780, 1);
            this.panel5.TabIndex = 299;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel2.Location = new System.Drawing.Point(1082, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 1);
            this.panel2.TabIndex = 294;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel3.Location = new System.Drawing.Point(1083, 205);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(780, 1);
            this.panel3.TabIndex = 295;
            // 
            // label200
            // 
            this.label200.BackColor = System.Drawing.SystemColors.Control;
            this.label200.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label200.ForeColor = System.Drawing.Color.Black;
            this.label200.Location = new System.Drawing.Point(1082, 162);
            this.label200.Name = "label200";
            this.label200.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label200.Size = new System.Drawing.Size(169, 44);
            this.label200.TabIndex = 296;
            this.label200.Text = "작업 상태";
            this.label200.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel1.Location = new System.Drawing.Point(1083, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 1);
            this.panel1.TabIndex = 293;
            // 
            // lbl_C_Group
            // 
            this.lbl_C_Group.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_C_Group.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_C_Group.ForeColor = System.Drawing.Color.Black;
            this.lbl_C_Group.Location = new System.Drawing.Point(1473, 119);
            this.lbl_C_Group.Name = "lbl_C_Group";
            this.lbl_C_Group.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_C_Group.Size = new System.Drawing.Size(169, 44);
            this.lbl_C_Group.TabIndex = 292;
            this.lbl_C_Group.Text = "장비 타입";
            this.lbl_C_Group.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_C_No
            // 
            this.lbl_C_No.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_C_No.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_C_No.ForeColor = System.Drawing.Color.Black;
            this.lbl_C_No.Location = new System.Drawing.Point(1082, 119);
            this.lbl_C_No.Name = "lbl_C_No";
            this.lbl_C_No.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_C_No.Size = new System.Drawing.Size(169, 44);
            this.lbl_C_No.TabIndex = 291;
            this.lbl_C_No.Text = "장비명";
            this.lbl_C_No.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label100
            // 
            this.label100.BackColor = System.Drawing.SystemColors.Control;
            this.label100.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label100.ForeColor = System.Drawing.Color.Black;
            this.label100.Location = new System.Drawing.Point(1473, 161);
            this.label100.Name = "label100";
            this.label100.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label100.Size = new System.Drawing.Size(169, 44);
            this.label100.TabIndex = 297;
            this.label100.Text = "작업자";
            this.label100.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel4.Location = new System.Drawing.Point(1083, 248);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(780, 1);
            this.panel4.TabIndex = 298;
            // 
            // lbl_RealStart
            // 
            this.lbl_RealStart.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_RealStart.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_RealStart.ForeColor = System.Drawing.Color.Black;
            this.lbl_RealStart.Location = new System.Drawing.Point(1082, 205);
            this.lbl_RealStart.Name = "lbl_RealStart";
            this.lbl_RealStart.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_RealStart.Size = new System.Drawing.Size(169, 44);
            this.lbl_RealStart.TabIndex = 300;
            this.lbl_RealStart.Text = "작업 예정일";
            this.lbl_RealStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(1082, 248);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label16.Size = new System.Drawing.Size(169, 44);
            this.label16.TabIndex = 301;
            this.label16.Text = "수주명";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(1082, 291);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label17.Size = new System.Drawing.Size(169, 44);
            this.label17.TabIndex = 303;
            this.label17.Text = "장비 메모";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_RealEnd
            // 
            this.lbl_RealEnd.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_RealEnd.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_RealEnd.ForeColor = System.Drawing.Color.Black;
            this.lbl_RealEnd.Location = new System.Drawing.Point(1473, 205);
            this.lbl_RealEnd.Name = "lbl_RealEnd";
            this.lbl_RealEnd.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_RealEnd.Size = new System.Drawing.Size(169, 44);
            this.lbl_RealEnd.TabIndex = 304;
            this.lbl_RealEnd.Text = "종료 예정일";
            this.lbl_RealEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Name
            // 
            this.lbl_Name.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_Name.Location = new System.Drawing.Point(1257, 128);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(210, 27);
            this.lbl_Name.TabIndex = 290;
            this.lbl_Name.Text = "장비명";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_End
            // 
            this.lbl_End.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_End.Location = new System.Drawing.Point(1647, 214);
            this.lbl_End.Name = "lbl_End";
            this.lbl_End.Size = new System.Drawing.Size(210, 27);
            this.lbl_End.TabIndex = 289;
            this.lbl_End.Text = "종료 예정일";
            this.lbl_End.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderName
            // 
            this.lbl_OrderName.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_OrderName.Location = new System.Drawing.Point(1257, 257);
            this.lbl_OrderName.Name = "lbl_OrderName";
            this.lbl_OrderName.Size = new System.Drawing.Size(210, 27);
            this.lbl_OrderName.TabIndex = 288;
            this.lbl_OrderName.Text = "수주명";
            this.lbl_OrderName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Memo
            // 
            this.lbl_Memo.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_Memo.Location = new System.Drawing.Point(1257, 300);
            this.lbl_Memo.Name = "lbl_Memo";
            this.lbl_Memo.Size = new System.Drawing.Size(600, 27);
            this.lbl_Memo.TabIndex = 287;
            this.lbl_Memo.Text = "장비 메모";
            this.lbl_Memo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Start
            // 
            this.lbl_Start.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_Start.Location = new System.Drawing.Point(1257, 214);
            this.lbl_Start.Name = "lbl_Start";
            this.lbl_Start.Size = new System.Drawing.Size(210, 27);
            this.lbl_Start.TabIndex = 286;
            this.lbl_Start.Text = "작업 예정일";
            this.lbl_Start.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Member
            // 
            this.lbl_Member.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_Member.Location = new System.Drawing.Point(1647, 171);
            this.lbl_Member.Name = "lbl_Member";
            this.lbl_Member.Size = new System.Drawing.Size(210, 27);
            this.lbl_Member.TabIndex = 285;
            this.lbl_Member.Text = "작업자";
            this.lbl_Member.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_State
            // 
            this.lbl_State.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_State.Location = new System.Drawing.Point(1257, 171);
            this.lbl_State.Name = "lbl_State";
            this.lbl_State.Size = new System.Drawing.Size(210, 27);
            this.lbl_State.TabIndex = 284;
            this.lbl_State.Text = "작업 상태";
            this.lbl_State.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Type
            // 
            this.lbl_Type.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_Type.Location = new System.Drawing.Point(1647, 128);
            this.lbl_Type.Name = "lbl_Type";
            this.lbl_Type.Size = new System.Drawing.Size(210, 27);
            this.lbl_Type.TabIndex = 283;
            this.lbl_Type.Text = "장비 타입";
            this.lbl_Type.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Schedule_Machine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.SeaShell;
            this.ClientSize = new System.Drawing.Size(1910, 956);
            this.Controls.Add(this.dgv_machine);
            this.Controls.Add(this.Btn_All);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label200);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_C_Group);
            this.Controls.Add(this.lbl_C_No);
            this.Controls.Add(this.label100);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lbl_RealStart);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lbl_RealEnd);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_End);
            this.Controls.Add(this.lbl_OrderName);
            this.Controls.Add(this.lbl_Memo);
            this.Controls.Add(this.lbl_Start);
            this.Controls.Add(this.lbl_Member);
            this.Controls.Add(this.lbl_State);
            this.Controls.Add(this.lbl_Type);
            this.Controls.Add(this.dgv_Product);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.tb_MachineName);
            this.Controls.Add(this.Cb_Type);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calendar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Schedule_Machine";
            this.Text = "Schedule_Machine";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_machine)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Calendar.NET.Calendar calendar1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridView dgv_machine;
        private FlatComboBox Cb_Type;
        private System.Windows.Forms.TextBox tb_MachineName;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.DataGridView dgv_Product;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.Button Btn_All;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label200;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_C_Group;
        private System.Windows.Forms.Label lbl_C_No;
        private System.Windows.Forms.Label label100;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_RealStart;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_RealEnd;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Label lbl_End;
        private System.Windows.Forms.Label lbl_OrderName;
        private System.Windows.Forms.Label lbl_Memo;
        private System.Windows.Forms.Label lbl_Start;
        private System.Windows.Forms.Label lbl_Member;
        private System.Windows.Forms.Label lbl_State;
        private System.Windows.Forms.Label lbl_Type;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
    }
}