
namespace View
{
    partial class Schedule_Order
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
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_State = new System.Windows.Forms.Label();
            this.lbl_Start = new System.Windows.Forms.Label();
            this.lbl_End = new System.Windows.Forms.Label();
            this.lbl_Customer = new System.Windows.Forms.Label();
            this.lbl_Memo = new System.Windows.Forms.Label();
            this.lbl_Phone = new System.Windows.Forms.Label();
            this.lbl_Manager = new System.Windows.Forms.Label();
            this.lbl_Name = new System.Windows.Forms.Label();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_RealStart = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_C_Group = new System.Windows.Forms.Label();
            this.lbl_C_No = new System.Windows.Forms.Label();
            this.lbl_RealEnd = new System.Windows.Forms.Label();
            this.panel4 = new System.Windows.Forms.Panel();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.dgv_order_detail = new System.Windows.Forms.DataGridView();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column16 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label5 = new System.Windows.Forms.Label();
            this.dgv_order = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column17 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column18 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Btn_Search = new System.Windows.Forms.Button();
            this.Btn_All = new System.Windows.Forms.Button();
            this.tb_OrderName = new System.Windows.Forms.TextBox();
            this.calendar1 = new Calendar.NET.Calendar();
            this.Cb_State = new FlatComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_order_detail)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_order)).BeginInit();
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
            this.label2.Text = "※ 진행중인 수주 리스트";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(1057, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(149, 30);
            this.label1.TabIndex = 233;
            this.label1.Text = "※ 수주명 조회";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(17, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(100, 30);
            this.label3.TabIndex = 232;
            this.label3.Text = "※ 일정표";
            // 
            // lbl_State
            // 
            this.lbl_State.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_State.Location = new System.Drawing.Point(1647, 128);
            this.lbl_State.Name = "lbl_State";
            this.lbl_State.Size = new System.Drawing.Size(210, 27);
            this.lbl_State.TabIndex = 237;
            this.lbl_State.Text = "수주 상태";
            this.lbl_State.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Start
            // 
            this.lbl_Start.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_Start.Location = new System.Drawing.Point(1257, 171);
            this.lbl_Start.Name = "lbl_Start";
            this.lbl_Start.Size = new System.Drawing.Size(210, 27);
            this.lbl_Start.TabIndex = 238;
            this.lbl_Start.Text = "수주 시작일";
            this.lbl_Start.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_End
            // 
            this.lbl_End.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_End.Location = new System.Drawing.Point(1647, 171);
            this.lbl_End.Name = "lbl_End";
            this.lbl_End.Size = new System.Drawing.Size(210, 27);
            this.lbl_End.TabIndex = 239;
            this.lbl_End.Text = "출하 예정일";
            this.lbl_End.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Customer
            // 
            this.lbl_Customer.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_Customer.Location = new System.Drawing.Point(1257, 214);
            this.lbl_Customer.Name = "lbl_Customer";
            this.lbl_Customer.Size = new System.Drawing.Size(210, 27);
            this.lbl_Customer.TabIndex = 240;
            this.lbl_Customer.Text = "거래처";
            this.lbl_Customer.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Memo
            // 
            this.lbl_Memo.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_Memo.Location = new System.Drawing.Point(1257, 300);
            this.lbl_Memo.Name = "lbl_Memo";
            this.lbl_Memo.Size = new System.Drawing.Size(600, 27);
            this.lbl_Memo.TabIndex = 241;
            this.lbl_Memo.Text = "수주 메모";
            this.lbl_Memo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Phone
            // 
            this.lbl_Phone.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_Phone.Location = new System.Drawing.Point(1257, 257);
            this.lbl_Phone.Name = "lbl_Phone";
            this.lbl_Phone.Size = new System.Drawing.Size(210, 27);
            this.lbl_Phone.TabIndex = 242;
            this.lbl_Phone.Text = "거래처 전화번호";
            this.lbl_Phone.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Manager
            // 
            this.lbl_Manager.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_Manager.Location = new System.Drawing.Point(1647, 214);
            this.lbl_Manager.Name = "lbl_Manager";
            this.lbl_Manager.Size = new System.Drawing.Size(210, 27);
            this.lbl_Manager.TabIndex = 244;
            this.lbl_Manager.Text = "거래처 담당자";
            this.lbl_Manager.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Name
            // 
            this.lbl_Name.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.lbl_Name.Location = new System.Drawing.Point(1257, 128);
            this.lbl_Name.Name = "lbl_Name";
            this.lbl_Name.Size = new System.Drawing.Size(210, 27);
            this.lbl_Name.TabIndex = 245;
            this.lbl_Name.Text = "수주명";
            this.lbl_Name.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel6.Location = new System.Drawing.Point(1084, 334);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(780, 1);
            this.panel6.TabIndex = 262;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel5.Location = new System.Drawing.Point(1084, 291);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(780, 1);
            this.panel5.TabIndex = 258;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel2.Location = new System.Drawing.Point(1082, 162);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(780, 1);
            this.panel2.TabIndex = 250;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel3.Location = new System.Drawing.Point(1083, 205);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(780, 1);
            this.panel3.TabIndex = 252;
            // 
            // lbl_RealStart
            // 
            this.lbl_RealStart.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_RealStart.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_RealStart.ForeColor = System.Drawing.Color.Black;
            this.lbl_RealStart.Location = new System.Drawing.Point(1082, 162);
            this.lbl_RealStart.Name = "lbl_RealStart";
            this.lbl_RealStart.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_RealStart.Size = new System.Drawing.Size(169, 44);
            this.lbl_RealStart.TabIndex = 253;
            this.lbl_RealStart.Text = "수주 예정일";
            this.lbl_RealStart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel1.Location = new System.Drawing.Point(1083, 119);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(780, 1);
            this.panel1.TabIndex = 249;
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
            this.lbl_C_Group.TabIndex = 248;
            this.lbl_C_Group.Text = "수주 상태";
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
            this.lbl_C_No.TabIndex = 247;
            this.lbl_C_No.Text = "수주명";
            this.lbl_C_No.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_RealEnd
            // 
            this.lbl_RealEnd.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_RealEnd.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_RealEnd.ForeColor = System.Drawing.Color.Black;
            this.lbl_RealEnd.Location = new System.Drawing.Point(1473, 161);
            this.lbl_RealEnd.Name = "lbl_RealEnd";
            this.lbl_RealEnd.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_RealEnd.Size = new System.Drawing.Size(169, 44);
            this.lbl_RealEnd.TabIndex = 254;
            this.lbl_RealEnd.Text = "출하 예정일";
            this.lbl_RealEnd.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel4.Location = new System.Drawing.Point(1083, 248);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(780, 1);
            this.panel4.TabIndex = 257;
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(1082, 205);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label15.Size = new System.Drawing.Size(169, 44);
            this.label15.TabIndex = 259;
            this.label15.Text = "거래처";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
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
            this.label16.TabIndex = 260;
            this.label16.Text = "거래처 전화번호";
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
            this.label17.TabIndex = 263;
            this.label17.Text = "수주 메모";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(1473, 205);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label18.Size = new System.Drawing.Size(169, 44);
            this.label18.TabIndex = 265;
            this.label18.Text = "거래처 담당자";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(1057, 357);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(289, 30);
            this.label4.TabIndex = 268;
            this.label4.Text = "※ 진행중인 수주 품목 리스트";
            // 
            // dgv_order_detail
            // 
            this.dgv_order_detail.AllowUserToAddRows = false;
            this.dgv_order_detail.AllowUserToDeleteRows = false;
            this.dgv_order_detail.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_order_detail.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_order_detail.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_order_detail.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_order_detail.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_order_detail.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_order_detail.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_order_detail.ColumnHeadersHeight = 40;
            this.dgv_order_detail.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_order_detail.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column15,
            this.Column16,
            this.Column8,
            this.Column14});
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_order_detail.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_order_detail.EnableHeadersVisualStyles = false;
            this.dgv_order_detail.Location = new System.Drawing.Point(1083, 386);
            this.dgv_order_detail.MultiSelect = false;
            this.dgv_order_detail.Name = "dgv_order_detail";
            this.dgv_order_detail.ReadOnly = true;
            this.dgv_order_detail.RowHeadersVisible = false;
            this.dgv_order_detail.RowTemplate.Height = 30;
            this.dgv_order_detail.RowTemplate.ReadOnly = true;
            this.dgv_order_detail.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_order_detail.Size = new System.Drawing.Size(780, 563);
            this.dgv_order_detail.TabIndex = 269;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "품목명";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            this.Column15.Width = 300;
            // 
            // Column16
            // 
            this.Column16.HeaderText = "품목타입";
            this.Column16.Name = "Column16";
            this.Column16.ReadOnly = true;
            this.Column16.Width = 150;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "수량";
            this.Column8.Name = "Column8";
            this.Column8.ReadOnly = true;
            this.Column8.Width = 80;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "비고";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            this.Column14.Width = 350;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label5.Location = new System.Drawing.Point(1411, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(177, 30);
            this.label5.TabIndex = 270;
            this.label5.Text = "※ 수주 상태 선택";
            // 
            // dgv_order
            // 
            this.dgv_order.AllowUserToAddRows = false;
            this.dgv_order.AllowUserToDeleteRows = false;
            this.dgv_order.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_order.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_order.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
            | System.Windows.Forms.AnchorStyles.Left)
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_order.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_order.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_order.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_order.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_order.ColumnHeadersHeight = 40;
            this.dgv_order.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dgv_order.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column17,
            this.Column5,
            this.Column18,
            this.Column3,
            this.Column4,
            this.Column7});
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle6.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_order.DefaultCellStyle = dataGridViewCellStyle6;
            this.dgv_order.EnableHeadersVisualStyles = false;
            this.dgv_order.Location = new System.Drawing.Point(1083, 118);
            this.dgv_order.MultiSelect = false;
            this.dgv_order.Name = "dgv_order";
            this.dgv_order.ReadOnly = true;
            this.dgv_order.RowHeadersVisible = false;
            this.dgv_order.RowHeadersWidth = 5;
            this.dgv_order.RowTemplate.Height = 30;
            this.dgv_order.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_order.Size = new System.Drawing.Size(780, 238);
            this.dgv_order.TabIndex = 274;
            this.dgv_order.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_order_CellClick);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "고유번호";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            this.Column1.Visible = false;
            this.Column1.Width = 70;
            // 
            // Column2
            // 
            this.Column2.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.Column2.HeaderText = "수주명";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            this.Column2.Width = 510;
            // 
            // Column17
            // 
            this.Column17.HeaderText = "수주상태";
            this.Column17.Name = "Column17";
            this.Column17.ReadOnly = true;
            this.Column17.Visible = false;
            this.Column17.Width = 150;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "거래처";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            this.Column5.Width = 268;
            // 
            // Column18
            // 
            this.Column18.HeaderText = "거래처 담당자";
            this.Column18.Name = "Column18";
            this.Column18.ReadOnly = true;
            this.Column18.Visible = false;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "수주 시작일";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            this.Column3.Visible = false;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "출하 예정일";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            this.Column4.Visible = false;
            // 
            // Column7
            // 
            this.Column7.HeaderText = "메모";
            this.Column7.Name = "Column7";
            this.Column7.ReadOnly = true;
            this.Column7.Visible = false;
            this.Column7.Width = 500;
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
            this.Btn_Search.TabIndex = 275;
            this.Btn_Search.Text = "⌕ 조 회";
            this.Btn_Search.UseVisualStyleBackColor = false;
            this.Btn_Search.Click += new System.EventHandler(this.Btn_Search_Click);
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
            this.Btn_All.TabIndex = 276;
            this.Btn_All.Text = "⟲ 모두 보기";
            this.Btn_All.UseVisualStyleBackColor = false;
            this.Btn_All.Click += new System.EventHandler(this.Btn_All_Click);
            // 
            // tb_OrderName
            // 
            this.tb_OrderName.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_OrderName.Location = new System.Drawing.Point(1212, 12);
            this.tb_OrderName.Name = "tb_OrderName";
            this.tb_OrderName.Size = new System.Drawing.Size(193, 27);
            this.tb_OrderName.TabIndex = 277;
            // 
            // calendar1
            // 
            this.calendar1.AllowEditingEvents = true;
            this.calendar1.BackColor = System.Drawing.Color.Gainsboro;
            this.calendar1.CalendarDate = new System.DateTime(2021, 6, 23, 16, 23, 0, 0);
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
            // Cb_State
            // 
            this.Cb_State.BorderColor = System.Drawing.Color.Black;
            this.Cb_State.ButtonColor = System.Drawing.Color.LightSkyBlue;
            this.Cb_State.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_State.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.Cb_State.ForeColor = System.Drawing.SystemColors.WindowText;
            this.Cb_State.FormattingEnabled = true;
            this.Cb_State.Items.AddRange(new object[] {
            "진행중",
            "완료",
            "폐기"});
            this.Cb_State.Location = new System.Drawing.Point(1594, 10);
            this.Cb_State.Name = "Cb_State";
            this.Cb_State.Size = new System.Drawing.Size(179, 29);
            this.Cb_State.TabIndex = 273;
            // 
            // Schedule_Order
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.ClientSize = new System.Drawing.Size(1910, 956);
            this.Controls.Add(this.dgv_order);
            this.Controls.Add(this.tb_OrderName);
            this.Controls.Add(this.Btn_Search);
            this.Controls.Add(this.Btn_All);
            this.Controls.Add(this.Cb_State);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgv_order_detail);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.panel6);
            this.Controls.Add(this.panel5);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.lbl_RealStart);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.lbl_C_Group);
            this.Controls.Add(this.lbl_C_No);
            this.Controls.Add(this.lbl_RealEnd);
            this.Controls.Add(this.panel4);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.lbl_Name);
            this.Controls.Add(this.lbl_Manager);
            this.Controls.Add(this.lbl_Phone);
            this.Controls.Add(this.lbl_Memo);
            this.Controls.Add(this.lbl_Customer);
            this.Controls.Add(this.lbl_End);
            this.Controls.Add(this.lbl_Start);
            this.Controls.Add(this.lbl_State);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.calendar1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Schedule_Order";
            this.Text = "Schedule_Order";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_order_detail)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_order)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private Calendar.NET.Calendar calendar1;
        private System.Windows.Forms.Label lbl_State;
        private System.Windows.Forms.Label lbl_Start;
        private System.Windows.Forms.Label lbl_End;
        private System.Windows.Forms.Label lbl_Customer;
        private System.Windows.Forms.Label lbl_Memo;
        private System.Windows.Forms.Label lbl_Phone;
        private System.Windows.Forms.Label lbl_Manager;
        private System.Windows.Forms.Label lbl_Name;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_RealStart;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_C_Group;
        private System.Windows.Forms.Label lbl_C_No;
        private System.Windows.Forms.Label lbl_RealEnd;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.DataGridView dgv_order_detail;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column16;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.Label label5;
        private FlatComboBox Cb_State;
        private System.Windows.Forms.DataGridView dgv_order;
        private System.Windows.Forms.Button Btn_Search;
        private System.Windows.Forms.Button Btn_All;
        private System.Windows.Forms.TextBox tb_OrderName;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column17;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column18;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
    }
}