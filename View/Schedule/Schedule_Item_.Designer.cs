
namespace View
{
    partial class Schedule_Item
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
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.tb_ProductName = new System.Windows.Forms.TextBox();
            this.calendar1 = new Calendar.NET.Calendar();
            this.label2 = new System.Windows.Forms.Label();
            this.Btn_All = new System.Windows.Forms.Button();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_C_Group = new System.Windows.Forms.Label();
            this.lbl_C_No = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.lbl_RealStart = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.lbl_RealEnd = new System.Windows.Forms.Label();
            this.lbl_ProductName = new System.Windows.Forms.Label();
            this.lbl_End = new System.Windows.Forms.Label();
            this.lbl_ProductMemo = new System.Windows.Forms.Label();
            this.lbl_OrderMemo = new System.Windows.Forms.Label();
            this.lbl_Start = new System.Windows.Forms.Label();
            this.lbl_OrderName = new System.Windows.Forms.Label();
            this.lbl_FairReal = new System.Windows.Forms.Label();
            this.lbl_State = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.dgv_product = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cb_State = new FlatComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).BeginInit();
            this.SuspendLayout();
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 30);
            this.label3.TabIndex = 201;
            this.label3.Text = "※ 일정표";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(1057, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 30);
            this.label1.TabIndex = 217;
            this.label1.Text = "※ 품목명 조회";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(1057, 353);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(247, 30);
            this.label4.TabIndex = 229;
            this.label4.Text = "※ 작업 중인 품목 리스트";
            // 
            // tb_ProductName
            // 
            this.tb_ProductName.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_ProductName.Location = new System.Drawing.Point(1212, 12);
            this.tb_ProductName.Name = "tb_ProductName";
            this.tb_ProductName.Size = new System.Drawing.Size(193, 27);
            this.tb_ProductName.TabIndex = 278;
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
            this.calendar1.TabIndex = 0;
            this.calendar1.TodayFont = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(1057, 86);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(268, 30);
            this.label2.TabIndex = 279;
            this.label2.Text = "※ 작업 중인 품목 상세보기";
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
            this.Btn_All.TabIndex = 302;
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
            this.panel6.TabIndex = 299;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel5.Location = new System.Drawing.Point(1084, 291);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(780, 1);
            this.panel5.TabIndex = 296;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel2.Location = new System.Drawing.Point(1082, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 1);
            this.panel2.TabIndex = 291;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel3.Location = new System.Drawing.Point(1083, 205);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(780, 1);
            this.panel3.TabIndex = 292;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(1082, 162);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label13.Size = new System.Drawing.Size(169, 44);
            this.label13.TabIndex = 293;
            this.label13.Text = "공정명";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel1.Location = new System.Drawing.Point(1083, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 1);
            this.panel1.TabIndex = 290;
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
            this.lbl_C_Group.TabIndex = 289;
            this.lbl_C_Group.Text = "품목 작업상태";
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
            this.lbl_C_No.TabIndex = 288;
            this.lbl_C_No.Text = "품목명";
            this.lbl_C_No.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.BackColor = System.Drawing.SystemColors.Control;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label14.ForeColor = System.Drawing.Color.Black;
            this.label14.Location = new System.Drawing.Point(1473, 162);
            this.label14.Name = "label14";
            this.label14.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label14.Size = new System.Drawing.Size(169, 44);
            this.label14.TabIndex = 294;
            this.label14.Text = "수주명";
            this.label14.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel4.Location = new System.Drawing.Point(1083, 248);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(780, 1);
            this.panel4.TabIndex = 295;
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
            this.lbl_RealStart.TabIndex = 297;
            this.lbl_RealStart.Text = "작업시작 예정일";
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
            this.label16.TabIndex = 298;
            this.label16.Text = "품목 메모";
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
            this.label17.TabIndex = 300;
            this.label17.Text = "수주 메모";
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
            this.lbl_RealEnd.TabIndex = 301;
            this.lbl_RealEnd.Text = "작업종료 예정일";
            this.lbl_RealEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_ProductName
            // 
            this.lbl_ProductName.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_ProductName.Location = new System.Drawing.Point(1257, 128);
            this.lbl_ProductName.Name = "lbl_ProductName";
            this.lbl_ProductName.Size = new System.Drawing.Size(210, 27);
            this.lbl_ProductName.TabIndex = 287;
            this.lbl_ProductName.Text = "품목명";
            this.lbl_ProductName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_End
            // 
            this.lbl_End.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_End.Location = new System.Drawing.Point(1647, 214);
            this.lbl_End.Name = "lbl_End";
            this.lbl_End.Size = new System.Drawing.Size(210, 27);
            this.lbl_End.TabIndex = 286;
            this.lbl_End.Text = "작업종료 예정일";
            this.lbl_End.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_ProductMemo
            // 
            this.lbl_ProductMemo.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_ProductMemo.Location = new System.Drawing.Point(1257, 257);
            this.lbl_ProductMemo.Name = "lbl_ProductMemo";
            this.lbl_ProductMemo.Size = new System.Drawing.Size(600, 27);
            this.lbl_ProductMemo.TabIndex = 285;
            this.lbl_ProductMemo.Text = "품목 메모";
            this.lbl_ProductMemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderMemo
            // 
            this.lbl_OrderMemo.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_OrderMemo.Location = new System.Drawing.Point(1257, 300);
            this.lbl_OrderMemo.Name = "lbl_OrderMemo";
            this.lbl_OrderMemo.Size = new System.Drawing.Size(600, 27);
            this.lbl_OrderMemo.TabIndex = 284;
            this.lbl_OrderMemo.Text = "수주 메모";
            this.lbl_OrderMemo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Start
            // 
            this.lbl_Start.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_Start.Location = new System.Drawing.Point(1257, 214);
            this.lbl_Start.Name = "lbl_Start";
            this.lbl_Start.Size = new System.Drawing.Size(210, 27);
            this.lbl_Start.TabIndex = 283;
            this.lbl_Start.Text = "작업시작 예정일";
            this.lbl_Start.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_OrderName
            // 
            this.lbl_OrderName.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_OrderName.Location = new System.Drawing.Point(1647, 171);
            this.lbl_OrderName.Name = "lbl_OrderName";
            this.lbl_OrderName.Size = new System.Drawing.Size(210, 27);
            this.lbl_OrderName.TabIndex = 282;
            this.lbl_OrderName.Text = "수주명";
            this.lbl_OrderName.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_FairReal
            // 
            this.lbl_FairReal.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_FairReal.Location = new System.Drawing.Point(1257, 171);
            this.lbl_FairReal.Name = "lbl_FairReal";
            this.lbl_FairReal.Size = new System.Drawing.Size(210, 27);
            this.lbl_FairReal.TabIndex = 281;
            this.lbl_FairReal.Text = "공정명";
            this.lbl_FairReal.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_State
            // 
            this.lbl_State.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_State.Location = new System.Drawing.Point(1647, 128);
            this.lbl_State.Name = "lbl_State";
            this.lbl_State.Size = new System.Drawing.Size(210, 27);
            this.lbl_State.TabIndex = 280;
            this.lbl_State.Text = "품목 작업상태";
            this.lbl_State.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(1411, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 30);
            this.label5.TabIndex = 303;
            this.label5.Text = "※ 품목 상태 선택";
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
            this.Btn_Search.TabIndex = 305;
            this.Btn_Search.Text = "⌕ 조 회";
            this.Btn_Search.UseVisualStyleBackColor = false;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
            // 
            // dgv_product
            // 
            this.dgv_product.AllowUserToAddRows = false;
            this.dgv_product.AllowUserToDeleteRows = false;
            this.dgv_product.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_product.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_product.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_product.BackgroundColor = System.Drawing.Color.White;
            this.dgv_product.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_product.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_product.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_product.ColumnHeadersHeight = 40;
            this.dgv_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_product.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16,
            this.dataGridViewTextBoxColumn1,
            this.Column14,
            this.Column6,
            this.Column11,
            this.Column12,
            this.Column13,
            this.Column17});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_product.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_product.EnableHeadersVisualStyles = false;
            this.dgv_product.Location = new System.Drawing.Point(1083, 386);
            this.dgv_product.MultiSelect = false;
            this.dgv_product.Name = "dgv_product";
            this.dgv_product.ReadOnly = true;
            this.dgv_product.RowHeadersVisible = false;
            this.dgv_product.RowTemplate.Height = 30;
            this.dgv_product.RowTemplate.ReadOnly = true;
            this.dgv_product.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_product.Size = new System.Drawing.Size(780, 563);
            this.dgv_product.TabIndex = 306;
            this.dgv_product.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_product_CellClick);
            // 
            // Column15
            // 
            this.Column15.HeaderText = "품목번호";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Visible = false;
            this.Column15.Width = 300;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "품목명";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 360;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "공정명";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "품목 작업상태";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Visible = false;
            this.Column14.Width = 350;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "수주명";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            this.Column6.Width = 318;
            // 
            // Column11
            // 
            this.Column11.HeaderText = "작업 예정일";
            this.Column11.Name = "Column11";
            this.Column11.ReadOnly = true;
            this.Column11.Visible = false;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "종료 예정일";
            this.Column12.Name = "Column12";
            this.Column12.ReadOnly = true;
            this.Column12.Visible = false;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "품목 메모";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            this.Column13.Visible = false;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "수주 메모";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Visible = false;
            // 
            // Cb_State
            // 
            this.Cb_State.BorderColor = System.Drawing.Color.Black;
            this.Cb_State.ButtonColor = System.Drawing.Color.LightSkyBlue;
            this.Cb_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_State.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.Cb_State.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Cb_State.FormattingEnabled = true;
            this.Cb_State.Items.AddRange(new object[] {
            "작업 중",
            "작업완료",
            "폐기"});
            this.Cb_State.Location = new System.Drawing.Point(1594, 10);
            this.Cb_State.Name = "Cb_State";
            this.Cb_State.Size = new System.Drawing.Size(179, 29);
            this.Cb_State.TabIndex = 304;
            // 
            // Schedule_Item
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1910, 956);
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.Cb_State);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.Btn_All);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_C_Group);
            this.Controls.Add(this.lbl_C_No);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.lbl_RealStart);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.lbl_RealEnd);
            this.Controls.Add(this.lbl_ProductName);
            this.Controls.Add(this.lbl_End);
            this.Controls.Add(this.lbl_ProductMemo);
            this.Controls.Add(this.lbl_OrderMemo);
            this.Controls.Add(this.lbl_Start);
            this.Controls.Add(this.lbl_OrderName);
            this.Controls.Add(this.lbl_FairReal);
            this.Controls.Add(this.lbl_State);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tb_ProductName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calendar1);
            this.Controls.Add(this.dgv_product);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Schedule_Item";
            this.Text = "Schedule_Item";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private Calendar.NET.Calendar calendar1;
        private System.Windows.Forms.TextBox tb_ProductName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Btn_All;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_C_Group;
        private System.Windows.Forms.Label lbl_C_No;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label lbl_RealStart;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label lbl_RealEnd;
        private System.Windows.Forms.Label lbl_ProductName;
        private System.Windows.Forms.Label lbl_End;
        private System.Windows.Forms.Label lbl_ProductMemo;
        private System.Windows.Forms.Label lbl_OrderMemo;
        private System.Windows.Forms.Label lbl_Start;
        private System.Windows.Forms.Label lbl_OrderName;
        private System.Windows.Forms.Label lbl_FairReal;
        private System.Windows.Forms.Label lbl_State;
        private System.Windows.Forms.Label label5;
        private FlatComboBox Cb_State;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.DataGridView dgv_product;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column11;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column12;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
    }
}