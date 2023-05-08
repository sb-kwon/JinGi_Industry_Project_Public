
namespace View
{
    partial class DefectRegistration
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
            this.dp_startTime = new System.Windows.Forms.DateTimePicker();
            this.dp_endTime = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.cb_Fariname = new System.Windows.Forms.ComboBox();
            this.lbl_InstructionNo = new System.Windows.Forms.Label();
            this.lbl_fiarName = new System.Windows.Forms.Label();
            this.lbl_workProcessStartTime = new System.Windows.Forms.Label();
            this.lbl_workProcessEndTime = new System.Windows.Forms.Label();
            this.lbl_Numbercheck = new System.Windows.Forms.Label();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.tb_Cause = new System.Windows.Forms.TextBox();
            this.tb_Actions = new System.Windows.Forms.TextBox();
            this.tb_Manager = new System.Windows.Forms.TextBox();
            this.tb_Remark = new System.Windows.Forms.TextBox();
            this.dp_Deadline = new System.Windows.Forms.DateTimePicker();
            this.lbl_Member = new System.Windows.Forms.Label();
            this.lbl_Order = new System.Windows.Forms.Label();
            this.lbl_Product = new System.Windows.Forms.Label();
            this.lbl_Machine = new System.Windows.Forms.Label();
            this.dgv_Registration = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lbl_C_No = new System.Windows.Forms.Label();
            this.lbl_C_Group = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label22 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_Registration = new System.Windows.Forms.Button();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Registration)).BeginInit();
            this.SuspendLayout();
            // 
            // dp_startTime
            // 
            this.dp_startTime.CalendarFont = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.dp_startTime.CustomFormat = "yyyy-MM-dd";
            this.dp_startTime.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.dp_startTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_startTime.Location = new System.Drawing.Point(152, 53);
            this.dp_startTime.Margin = new System.Windows.Forms.Padding(2);
            this.dp_startTime.Name = "dp_startTime";
            this.dp_startTime.Size = new System.Drawing.Size(135, 29);
            this.dp_startTime.TabIndex = 130;
            // 
            // dp_endTime
            // 
            this.dp_endTime.CalendarFont = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.dp_endTime.CustomFormat = "yyyy-MM-dd";
            this.dp_endTime.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.dp_endTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_endTime.Location = new System.Drawing.Point(325, 53);
            this.dp_endTime.Margin = new System.Windows.Forms.Padding(2);
            this.dp_endTime.Name = "dp_endTime";
            this.dp_endTime.Size = new System.Drawing.Size(135, 29);
            this.dp_endTime.TabIndex = 130;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Window;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(292, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(28, 29);
            this.label3.TabIndex = 131;
            this.label3.Text = "~";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // cb_Fariname
            // 
            this.cb_Fariname.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Fariname.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Fariname.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.cb_Fariname.FormattingEnabled = true;
            this.cb_Fariname.Location = new System.Drawing.Point(605, 53);
            this.cb_Fariname.Name = "cb_Fariname";
            this.cb_Fariname.Size = new System.Drawing.Size(179, 29);
            this.cb_Fariname.TabIndex = 184;
            // 
            // lbl_InstructionNo
            // 
            this.lbl_InstructionNo.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_InstructionNo.Cursor = System.Windows.Forms.Cursors.No;
            this.lbl_InstructionNo.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_InstructionNo.Location = new System.Drawing.Point(202, 716);
            this.lbl_InstructionNo.Name = "lbl_InstructionNo";
            this.lbl_InstructionNo.Size = new System.Drawing.Size(252, 27);
            this.lbl_InstructionNo.TabIndex = 129;
            this.lbl_InstructionNo.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_fiarName
            // 
            this.lbl_fiarName.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_fiarName.Cursor = System.Windows.Forms.Cursors.No;
            this.lbl_fiarName.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_fiarName.Location = new System.Drawing.Point(202, 759);
            this.lbl_fiarName.Name = "lbl_fiarName";
            this.lbl_fiarName.Size = new System.Drawing.Size(252, 27);
            this.lbl_fiarName.TabIndex = 129;
            this.lbl_fiarName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_workProcessStartTime
            // 
            this.lbl_workProcessStartTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_workProcessStartTime.Cursor = System.Windows.Forms.Cursors.No;
            this.lbl_workProcessStartTime.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_workProcessStartTime.Location = new System.Drawing.Point(668, 716);
            this.lbl_workProcessStartTime.Name = "lbl_workProcessStartTime";
            this.lbl_workProcessStartTime.Size = new System.Drawing.Size(252, 27);
            this.lbl_workProcessStartTime.TabIndex = 129;
            this.lbl_workProcessStartTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_workProcessEndTime
            // 
            this.lbl_workProcessEndTime.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_workProcessEndTime.Cursor = System.Windows.Forms.Cursors.No;
            this.lbl_workProcessEndTime.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_workProcessEndTime.Location = new System.Drawing.Point(668, 759);
            this.lbl_workProcessEndTime.Name = "lbl_workProcessEndTime";
            this.lbl_workProcessEndTime.Size = new System.Drawing.Size(252, 27);
            this.lbl_workProcessEndTime.TabIndex = 129;
            this.lbl_workProcessEndTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Numbercheck
            // 
            this.lbl_Numbercheck.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.lbl_Numbercheck.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Numbercheck.Location = new System.Drawing.Point(460, 716);
            this.lbl_Numbercheck.Name = "lbl_Numbercheck";
            this.lbl_Numbercheck.Size = new System.Drawing.Size(31, 27);
            this.lbl_Numbercheck.TabIndex = 129;
            this.lbl_Numbercheck.Text = "2021-03-15";
            this.lbl_Numbercheck.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.lbl_Numbercheck.Visible = false;
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.BackColor = System.Drawing.SystemColors.Window;
            this.btn_Cancel.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Cancel.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(192)))));
            this.btn_Cancel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Cancel.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.btn_Cancel.ForeColor = System.Drawing.Color.CornflowerBlue;
            this.btn_Cancel.Location = new System.Drawing.Point(1639, 886);
            this.btn_Cancel.Margin = new System.Windows.Forms.Padding(2);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(120, 42);
            this.btn_Cancel.TabIndex = 185;
            this.btn_Cancel.Text = "√ 취소";
            this.btn_Cancel.UseVisualStyleBackColor = false;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // tb_Cause
            // 
            this.tb_Cause.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.tb_Cause.Location = new System.Drawing.Point(1135, 712);
            this.tb_Cause.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Cause.Name = "tb_Cause";
            this.tb_Cause.Size = new System.Drawing.Size(252, 29);
            this.tb_Cause.TabIndex = 186;
            // 
            // tb_Actions
            // 
            this.tb_Actions.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.tb_Actions.Location = new System.Drawing.Point(1135, 755);
            this.tb_Actions.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Actions.Name = "tb_Actions";
            this.tb_Actions.Size = new System.Drawing.Size(252, 29);
            this.tb_Actions.TabIndex = 186;
            // 
            // tb_Manager
            // 
            this.tb_Manager.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.tb_Manager.Location = new System.Drawing.Point(1135, 799);
            this.tb_Manager.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Manager.Name = "tb_Manager";
            this.tb_Manager.Size = new System.Drawing.Size(252, 29);
            this.tb_Manager.TabIndex = 186;
            // 
            // tb_Remark
            // 
            this.tb_Remark.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.tb_Remark.Location = new System.Drawing.Point(1428, 755);
            this.tb_Remark.Margin = new System.Windows.Forms.Padding(2);
            this.tb_Remark.Multiline = true;
            this.tb_Remark.Name = "tb_Remark";
            this.tb_Remark.Size = new System.Drawing.Size(456, 119);
            this.tb_Remark.TabIndex = 186;
            // 
            // dp_Deadline
            // 
            this.dp_Deadline.CalendarFont = new System.Drawing.Font("굴림", 25F);
            this.dp_Deadline.CustomFormat = "yyyy-MM-dd";
            this.dp_Deadline.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.dp_Deadline.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dp_Deadline.Location = new System.Drawing.Point(1135, 841);
            this.dp_Deadline.Margin = new System.Windows.Forms.Padding(2);
            this.dp_Deadline.Name = "dp_Deadline";
            this.dp_Deadline.Size = new System.Drawing.Size(252, 29);
            this.dp_Deadline.TabIndex = 187;
            // 
            // lbl_Member
            // 
            this.lbl_Member.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Member.Cursor = System.Windows.Forms.Cursors.No;
            this.lbl_Member.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Member.Location = new System.Drawing.Point(202, 802);
            this.lbl_Member.Name = "lbl_Member";
            this.lbl_Member.Size = new System.Drawing.Size(252, 27);
            this.lbl_Member.TabIndex = 188;
            this.lbl_Member.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Order
            // 
            this.lbl_Order.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Order.Cursor = System.Windows.Forms.Cursors.No;
            this.lbl_Order.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Order.Location = new System.Drawing.Point(202, 844);
            this.lbl_Order.Name = "lbl_Order";
            this.lbl_Order.Size = new System.Drawing.Size(252, 27);
            this.lbl_Order.TabIndex = 192;
            this.lbl_Order.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Product
            // 
            this.lbl_Product.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Product.Cursor = System.Windows.Forms.Cursors.No;
            this.lbl_Product.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Product.Location = new System.Drawing.Point(668, 844);
            this.lbl_Product.Name = "lbl_Product";
            this.lbl_Product.Size = new System.Drawing.Size(252, 27);
            this.lbl_Product.TabIndex = 190;
            this.lbl_Product.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Machine
            // 
            this.lbl_Machine.BackColor = System.Drawing.Color.WhiteSmoke;
            this.lbl_Machine.Cursor = System.Windows.Forms.Cursors.No;
            this.lbl_Machine.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Machine.Location = new System.Drawing.Point(668, 802);
            this.lbl_Machine.Name = "lbl_Machine";
            this.lbl_Machine.Size = new System.Drawing.Size(252, 27);
            this.lbl_Machine.TabIndex = 194;
            this.lbl_Machine.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dgv_Registration
            // 
            this.dgv_Registration.AllowUserToAddRows = false;
            this.dgv_Registration.AllowUserToDeleteRows = false;
            this.dgv_Registration.AllowUserToResizeColumns = false;
            this.dgv_Registration.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_Registration.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Registration.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Registration.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Registration.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_Registration.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Registration.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Registration.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Registration.ColumnHeadersHeight = 35;
            this.dgv_Registration.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column1,
            this.Column4,
            this.Column7,
            this.Column8,
            this.Column5,
            this.Column6,
            this.Column9,
            this.Column10});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Registration.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Registration.EnableHeadersVisualStyles = false;
            this.dgv_Registration.Location = new System.Drawing.Point(23, 137);
            this.dgv_Registration.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Registration.Name = "dgv_Registration";
            this.dgv_Registration.ReadOnly = true;
            this.dgv_Registration.RowHeadersVisible = false;
            this.dgv_Registration.RowHeadersWidth = 5;
            this.dgv_Registration.RowTemplate.Height = 30;
            this.dgv_Registration.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Registration.Size = new System.Drawing.Size(1861, 571);
            this.dgv_Registration.TabIndex = 129;
            this.dgv_Registration.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Registration_CellClick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(22, 99);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(177, 30);
            this.label1.TabIndex = 223;
            this.label1.Text = "※ 불량 발생 항목";
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel5.Location = new System.Drawing.Point(28, 879);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(1860, 1);
            this.panel5.TabIndex = 259;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel4.Location = new System.Drawing.Point(27, 707);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(1860, 1);
            this.panel4.TabIndex = 250;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel6.Location = new System.Drawing.Point(27, 836);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(1362, 1);
            this.panel6.TabIndex = 258;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel2.Location = new System.Drawing.Point(26, 750);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1362, 1);
            this.panel2.TabIndex = 251;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel3.Location = new System.Drawing.Point(27, 793);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(1362, 1);
            this.panel3.TabIndex = 252;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(493, 751);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label5.Size = new System.Drawing.Size(169, 42);
            this.label5.TabIndex = 255;
            this.label5.Text = "작업(종료)날짜";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(27, 794);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label2.Size = new System.Drawing.Size(169, 42);
            this.label2.TabIndex = 254;
            this.label2.Text = "작업자";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_C_No
            // 
            this.lbl_C_No.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_C_No.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_C_No.ForeColor = System.Drawing.Color.Black;
            this.lbl_C_No.Location = new System.Drawing.Point(27, 708);
            this.lbl_C_No.Name = "lbl_C_No";
            this.lbl_C_No.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_C_No.Size = new System.Drawing.Size(169, 42);
            this.lbl_C_No.TabIndex = 248;
            this.lbl_C_No.Text = "작업지시번호";
            this.lbl_C_No.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_C_Group
            // 
            this.lbl_C_Group.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_C_Group.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_C_Group.ForeColor = System.Drawing.Color.Black;
            this.lbl_C_Group.Location = new System.Drawing.Point(27, 751);
            this.lbl_C_Group.Name = "lbl_C_Group";
            this.lbl_C_Group.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_C_Group.Size = new System.Drawing.Size(169, 42);
            this.lbl_C_Group.TabIndex = 249;
            this.lbl_C_Group.Text = "공정 항목";
            this.lbl_C_Group.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label16
            // 
            this.label16.BackColor = System.Drawing.SystemColors.Control;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label16.ForeColor = System.Drawing.Color.Black;
            this.label16.Location = new System.Drawing.Point(493, 794);
            this.label16.Name = "label16";
            this.label16.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label16.Size = new System.Drawing.Size(169, 42);
            this.label16.TabIndex = 260;
            this.label16.Text = "작업 설비명";
            this.label16.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(493, 708);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label18.Size = new System.Drawing.Size(169, 42);
            this.label18.TabIndex = 263;
            this.label18.Text = "작업(시작)날짜";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(27, 836);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label20.Size = new System.Drawing.Size(169, 42);
            this.label20.TabIndex = 265;
            this.label20.Text = "수주 명";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label22
            // 
            this.label22.BackColor = System.Drawing.SystemColors.Control;
            this.label22.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label22.ForeColor = System.Drawing.Color.Black;
            this.label22.Location = new System.Drawing.Point(493, 836);
            this.label22.Name = "label22";
            this.label22.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label22.Size = new System.Drawing.Size(169, 42);
            this.label22.TabIndex = 267;
            this.label22.Text = "품목 명";
            this.label22.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label7.Location = new System.Drawing.Point(22, 9);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(128, 30);
            this.label7.TabIndex = 268;
            this.label7.Text = "※ 항목 조회";
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel7.Location = new System.Drawing.Point(23, 89);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1872, 1);
            this.panel7.TabIndex = 272;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel8.Location = new System.Drawing.Point(23, 46);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1872, 1);
            this.panel8.TabIndex = 271;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label8.Location = new System.Drawing.Point(475, 46);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label8.Size = new System.Drawing.Size(124, 44);
            this.label8.TabIndex = 270;
            this.label8.Text = "공정 항목";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label9.Location = new System.Drawing.Point(23, 46);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label9.Size = new System.Drawing.Size(124, 44);
            this.label9.TabIndex = 269;
            this.label9.Text = "날짜";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Search.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(790, 53);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(83, 29);
            this.btn_Search.TabIndex = 274;
            this.btn_Search.Text = "⌕ 조 회";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label10.ForeColor = System.Drawing.Color.IndianRed;
            this.label10.Location = new System.Drawing.Point(961, 751);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label10.Size = new System.Drawing.Size(169, 42);
            this.label10.TabIndex = 275;
            this.label10.Text = "불량 조치 사항";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label11.ForeColor = System.Drawing.Color.IndianRed;
            this.label11.Location = new System.Drawing.Point(961, 794);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label11.Size = new System.Drawing.Size(169, 42);
            this.label11.TabIndex = 276;
            this.label11.Text = "조치 담당자";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label12.ForeColor = System.Drawing.Color.IndianRed;
            this.label12.Location = new System.Drawing.Point(961, 708);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label12.Size = new System.Drawing.Size(169, 42);
            this.label12.TabIndex = 277;
            this.label12.Text = "불량 원인";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label13.ForeColor = System.Drawing.Color.IndianRed;
            this.label13.Location = new System.Drawing.Point(961, 838);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label13.Size = new System.Drawing.Size(169, 42);
            this.label13.TabIndex = 278;
            this.label13.Text = "조치 기한";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label4.ForeColor = System.Drawing.Color.Black;
            this.label4.Location = new System.Drawing.Point(1428, 708);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label4.Size = new System.Drawing.Size(169, 42);
            this.label4.TabIndex = 279;
            this.label4.Text = "비고";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btn_Registration
            // 
            this.btn_Registration.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Registration.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Registration.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Registration.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Registration.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.btn_Registration.ForeColor = System.Drawing.Color.White;
            this.btn_Registration.Location = new System.Drawing.Point(1764, 886);
            this.btn_Registration.Name = "btn_Registration";
            this.btn_Registration.Size = new System.Drawing.Size(120, 42);
            this.btn_Registration.TabIndex = 280;
            this.btn_Registration.Text = "↺ 불량 등록";
            this.btn_Registration.UseVisualStyleBackColor = false;
            this.btn_Registration.Click += new System.EventHandler(this.btn_Registration_Click);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "수주명";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "품목명";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "작업지시서 번호";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "공정명";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "작업자";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "작업설비명";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "작업시작시간";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column6
            // 
            this.Column6.HeaderText = "작업종료시간";
            this.Column6.Name = "Column6";
            this.Column6.ReadOnly = true;
            // 
            // Column9
            // 
            this.Column9.HeaderText = "No";
            this.Column9.Name = "Column9";
            this.Column9.ReadOnly = true;
            this.Column9.Visible = false;
            // 
            // Column10
            // 
            this.Column10.HeaderText = "불량 원인";
            this.Column10.Name = "Column10";
            this.Column10.ReadOnly = true;
            // 
            // DefectRegistration
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1910, 956);
            this.Controls.Add(this.btn_Registration);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.tb_Remark);
            this.Controls.Add(this.dp_Deadline);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.cb_Fariname);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_Machine);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.dp_startTime);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dp_endTime);
            this.Controls.Add(this.lbl_workProcessStartTime);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Numbercheck);
            this.Controls.Add(this.lbl_C_No);
            this.Controls.Add(this.tb_Cause);
            this.Controls.Add(this.tb_Actions);
            this.Controls.Add(this.lbl_Product);
            this.Controls.Add(this.lbl_C_Group);
            this.Controls.Add(this.tb_Manager);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.lbl_workProcessEndTime);
            this.Controls.Add(this.lbl_Order);
            this.Controls.Add(this.label22);
            this.Controls.Add(this.lbl_InstructionNo);
            this.Controls.Add(this.lbl_fiarName);
            this.Controls.Add(this.lbl_Member);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.dgv_Registration);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "DefectRegistration";
            this.Text = "DefectRegistration";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Registration)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DateTimePicker dp_startTime;
        private System.Windows.Forms.DateTimePicker dp_endTime;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cb_Fariname;
        private System.Windows.Forms.Label lbl_InstructionNo;
        private System.Windows.Forms.Label lbl_fiarName;
        private System.Windows.Forms.Label lbl_workProcessStartTime;
        private System.Windows.Forms.Label lbl_workProcessEndTime;
        private System.Windows.Forms.Label lbl_Numbercheck;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.TextBox tb_Cause;
        private System.Windows.Forms.TextBox tb_Actions;
        private System.Windows.Forms.TextBox tb_Manager;
        private System.Windows.Forms.TextBox tb_Remark;
        private System.Windows.Forms.DateTimePicker dp_Deadline;
        private System.Windows.Forms.Label lbl_Member;
        private System.Windows.Forms.Label lbl_Order;
        private System.Windows.Forms.Label lbl_Product;
        private System.Windows.Forms.Label lbl_Machine;
        private System.Windows.Forms.DataGridView dgv_Registration;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lbl_C_No;
        private System.Windows.Forms.Label lbl_C_Group;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label22;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_Registration;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
    }
}