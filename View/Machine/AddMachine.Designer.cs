namespace View
{
    partial class AddMachine
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
            this.Cb_Type = new System.Windows.Forms.ComboBox();
            this.pnl_Scanner = new System.Windows.Forms.Panel();
            this.panel4 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.lbl_Machine = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.lbl_ScannerName = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.cb_Machine = new System.Windows.Forms.ComboBox();
            this.btn_Reset = new System.Windows.Forms.Button();
            this.btn_Port_Check = new System.Windows.Forms.Button();
            this.tb_PortName = new System.Windows.Forms.TextBox();
            this.tb_ScannerName = new System.Windows.Forms.TextBox();
            this.btn_Close = new System.Windows.Forms.Button();
            this.btn_Add = new System.Windows.Forms.Button();
            this.btn_S_Check = new System.Windows.Forms.Button();
            this.lbl_PortNum = new System.Windows.Forms.Label();
            this.pnl_Machine = new System.Windows.Forms.Panel();
            this.tb_ETC = new System.Windows.Forms.TextBox();
            this.tb_Note = new System.Windows.Forms.TextBox();
            this.tb_Location = new System.Windows.Forms.TextBox();
            this.tb_Manager = new System.Windows.Forms.TextBox();
            this.DTP_Day = new System.Windows.Forms.DateTimePicker();
            this.btn_N_Check = new System.Windows.Forms.Button();
            this.tb_No = new System.Windows.Forms.TextBox();
            this.panel10 = new System.Windows.Forms.Panel();
            this.tb_Company = new System.Windows.Forms.TextBox();
            this.panel9 = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.panel5 = new System.Windows.Forms.Panel();
            this.panel6 = new System.Windows.Forms.Panel();
            this.panel7 = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.panel8 = new System.Windows.Forms.Panel();
            this.lbl_MachineName = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cb_Machine_type = new System.Windows.Forms.ComboBox();
            this.btn_Reset2 = new System.Windows.Forms.Button();
            this.tb_MachineName = new System.Windows.Forms.TextBox();
            this.btn_Close2 = new System.Windows.Forms.Button();
            this.btn_Add2 = new System.Windows.Forms.Button();
            this.btn_M_Check = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.pnl_SF = new System.Windows.Forms.Panel();
            this.tb_SF_Memo = new System.Windows.Forms.TextBox();
            this.tb_SF_Location = new System.Windows.Forms.TextBox();
            this.tb_Model = new System.Windows.Forms.TextBox();
            this.DTP_SF_Buy = new System.Windows.Forms.DateTimePicker();
            this.tb_SF_Company = new System.Windows.Forms.TextBox();
            this.panel13 = new System.Windows.Forms.Panel();
            this.panel14 = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.panel16 = new System.Windows.Forms.Panel();
            this.label12 = new System.Windows.Forms.Label();
            this.panel17 = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.label14 = new System.Windows.Forms.Label();
            this.cb_SF_Type = new System.Windows.Forms.ComboBox();
            this.btn_SF_Reset = new System.Windows.Forms.Button();
            this.tb_SF_Name = new System.Windows.Forms.TextBox();
            this.btn_SF_Close = new System.Windows.Forms.Button();
            this.btn_SF_Add = new System.Windows.Forms.Button();
            this.btn_SF_Check = new System.Windows.Forms.Button();
            this.label15 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.label20 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.pnl_Scanner.SuspendLayout();
            this.pnl_Machine.SuspendLayout();
            this.pnl_SF.SuspendLayout();
            this.SuspendLayout();
            // 
            // Cb_Type
            // 
            this.Cb_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.Cb_Type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.Cb_Type.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.Cb_Type.FormattingEnabled = true;
            this.Cb_Type.Items.AddRange(new object[] {
            "가공기",
            "SF_HardWare"});
            this.Cb_Type.Location = new System.Drawing.Point(12, 8);
            this.Cb_Type.Name = "Cb_Type";
            this.Cb_Type.Size = new System.Drawing.Size(160, 28);
            this.Cb_Type.TabIndex = 0;
            this.Cb_Type.SelectedIndexChanged += new System.EventHandler(this.Cb_Type_SelectedIndexChanged);
            // 
            // pnl_Scanner
            // 
            this.pnl_Scanner.Controls.Add(this.panel4);
            this.pnl_Scanner.Controls.Add(this.panel2);
            this.pnl_Scanner.Controls.Add(this.panel3);
            this.pnl_Scanner.Controls.Add(this.lbl_Machine);
            this.pnl_Scanner.Controls.Add(this.panel1);
            this.pnl_Scanner.Controls.Add(this.lbl_ScannerName);
            this.pnl_Scanner.Controls.Add(this.label1);
            this.pnl_Scanner.Controls.Add(this.cb_Machine);
            this.pnl_Scanner.Controls.Add(this.btn_Reset);
            this.pnl_Scanner.Controls.Add(this.btn_Port_Check);
            this.pnl_Scanner.Controls.Add(this.tb_PortName);
            this.pnl_Scanner.Controls.Add(this.tb_ScannerName);
            this.pnl_Scanner.Controls.Add(this.btn_Close);
            this.pnl_Scanner.Controls.Add(this.btn_Add);
            this.pnl_Scanner.Controls.Add(this.btn_S_Check);
            this.pnl_Scanner.Controls.Add(this.lbl_PortNum);
            this.pnl_Scanner.Enabled = false;
            this.pnl_Scanner.Location = new System.Drawing.Point(12, 42);
            this.pnl_Scanner.Name = "pnl_Scanner";
            this.pnl_Scanner.Size = new System.Drawing.Size(413, 223);
            this.pnl_Scanner.TabIndex = 1;
            this.pnl_Scanner.Visible = false;
            // 
            // panel4
            // 
            this.panel4.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel4.Location = new System.Drawing.Point(8, 175);
            this.panel4.Name = "panel4";
            this.panel4.Size = new System.Drawing.Size(400, 1);
            this.panel4.TabIndex = 238;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel2.Location = new System.Drawing.Point(7, 89);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(400, 1);
            this.panel2.TabIndex = 231;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel3.Location = new System.Drawing.Point(8, 132);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(400, 1);
            this.panel3.TabIndex = 232;
            // 
            // lbl_Machine
            // 
            this.lbl_Machine.AutoSize = true;
            this.lbl_Machine.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_Machine.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_Machine.ForeColor = System.Drawing.Color.Black;
            this.lbl_Machine.Location = new System.Drawing.Point(8, 132);
            this.lbl_Machine.Name = "lbl_Machine";
            this.lbl_Machine.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_Machine.Size = new System.Drawing.Size(124, 44);
            this.lbl_Machine.TabIndex = 234;
            this.lbl_Machine.Text = " 설비 명  ";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel1.Location = new System.Drawing.Point(8, 46);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(400, 1);
            this.panel1.TabIndex = 230;
            // 
            // lbl_ScannerName
            // 
            this.lbl_ScannerName.AutoSize = true;
            this.lbl_ScannerName.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_ScannerName.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_ScannerName.ForeColor = System.Drawing.Color.Black;
            this.lbl_ScannerName.Location = new System.Drawing.Point(8, 46);
            this.lbl_ScannerName.Name = "lbl_ScannerName";
            this.lbl_ScannerName.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_ScannerName.Size = new System.Drawing.Size(124, 44);
            this.lbl_ScannerName.TabIndex = 228;
            this.lbl_ScannerName.Text = "스캐너 명";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(3, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(206, 30);
            this.label1.TabIndex = 208;
            this.label1.Text = "※ Add Scanner List";
            // 
            // cb_Machine
            // 
            this.cb_Machine.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Machine.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Machine.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.cb_Machine.FormattingEnabled = true;
            this.cb_Machine.Location = new System.Drawing.Point(138, 140);
            this.cb_Machine.Name = "cb_Machine";
            this.cb_Machine.Size = new System.Drawing.Size(258, 28);
            this.cb_Machine.TabIndex = 111;
            // 
            // btn_Reset
            // 
            this.btn_Reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Reset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Reset.ForeColor = System.Drawing.Color.White;
            this.btn_Reset.Location = new System.Drawing.Point(146, 182);
            this.btn_Reset.Name = "btn_Reset";
            this.btn_Reset.Size = new System.Drawing.Size(83, 33);
            this.btn_Reset.TabIndex = 109;
            this.btn_Reset.Text = "⌛ Reset";
            this.btn_Reset.UseVisualStyleBackColor = false;
            this.btn_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // btn_Port_Check
            // 
            this.btn_Port_Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Port_Check.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_Port_Check.Location = new System.Drawing.Point(315, 99);
            this.btn_Port_Check.Name = "btn_Port_Check";
            this.btn_Port_Check.Size = new System.Drawing.Size(81, 27);
            this.btn_Port_Check.TabIndex = 108;
            this.btn_Port_Check.Text = "Check";
            this.btn_Port_Check.UseVisualStyleBackColor = true;
            this.btn_Port_Check.Click += new System.EventHandler(this.btn_Port_Check_Click);
            // 
            // tb_PortName
            // 
            this.tb_PortName.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_PortName.Location = new System.Drawing.Point(138, 99);
            this.tb_PortName.Name = "tb_PortName";
            this.tb_PortName.Size = new System.Drawing.Size(171, 27);
            this.tb_PortName.TabIndex = 107;
            // 
            // tb_ScannerName
            // 
            this.tb_ScannerName.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_ScannerName.Location = new System.Drawing.Point(138, 56);
            this.tb_ScannerName.Name = "tb_ScannerName";
            this.tb_ScannerName.Size = new System.Drawing.Size(171, 27);
            this.tb_ScannerName.TabIndex = 104;
            // 
            // btn_Close
            // 
            this.btn_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Close.ForeColor = System.Drawing.Color.White;
            this.btn_Close.Location = new System.Drawing.Point(324, 182);
            this.btn_Close.Name = "btn_Close";
            this.btn_Close.Size = new System.Drawing.Size(83, 33);
            this.btn_Close.TabIndex = 103;
            this.btn_Close.Text = "√ 닫 기";
            this.btn_Close.UseVisualStyleBackColor = false;
            this.btn_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Add
            // 
            this.btn_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Add.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Add.ForeColor = System.Drawing.Color.White;
            this.btn_Add.Location = new System.Drawing.Point(235, 182);
            this.btn_Add.Name = "btn_Add";
            this.btn_Add.Size = new System.Drawing.Size(83, 33);
            this.btn_Add.TabIndex = 102;
            this.btn_Add.Text = "↺ 추 가";
            this.btn_Add.UseVisualStyleBackColor = false;
            this.btn_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_S_Check
            // 
            this.btn_S_Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_S_Check.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_S_Check.Location = new System.Drawing.Point(315, 56);
            this.btn_S_Check.Name = "btn_S_Check";
            this.btn_S_Check.Size = new System.Drawing.Size(81, 27);
            this.btn_S_Check.TabIndex = 101;
            this.btn_S_Check.Text = "Check";
            this.btn_S_Check.UseVisualStyleBackColor = true;
            this.btn_S_Check.Click += new System.EventHandler(this.btn_S_Check_Click);
            // 
            // lbl_PortNum
            // 
            this.lbl_PortNum.AutoSize = true;
            this.lbl_PortNum.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_PortNum.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_PortNum.ForeColor = System.Drawing.Color.Black;
            this.lbl_PortNum.Location = new System.Drawing.Point(8, 90);
            this.lbl_PortNum.Name = "lbl_PortNum";
            this.lbl_PortNum.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_PortNum.Size = new System.Drawing.Size(124, 44);
            this.lbl_PortNum.TabIndex = 229;
            this.lbl_PortNum.Text = "포트 번호";
            // 
            // pnl_Machine
            // 
            this.pnl_Machine.Controls.Add(this.tb_ETC);
            this.pnl_Machine.Controls.Add(this.tb_Note);
            this.pnl_Machine.Controls.Add(this.tb_Location);
            this.pnl_Machine.Controls.Add(this.tb_Manager);
            this.pnl_Machine.Controls.Add(this.DTP_Day);
            this.pnl_Machine.Controls.Add(this.btn_N_Check);
            this.pnl_Machine.Controls.Add(this.tb_No);
            this.pnl_Machine.Controls.Add(this.panel10);
            this.pnl_Machine.Controls.Add(this.tb_Company);
            this.pnl_Machine.Controls.Add(this.panel9);
            this.pnl_Machine.Controls.Add(this.label3);
            this.pnl_Machine.Controls.Add(this.panel5);
            this.pnl_Machine.Controls.Add(this.panel6);
            this.pnl_Machine.Controls.Add(this.panel7);
            this.pnl_Machine.Controls.Add(this.label2);
            this.pnl_Machine.Controls.Add(this.panel8);
            this.pnl_Machine.Controls.Add(this.lbl_MachineName);
            this.pnl_Machine.Controls.Add(this.label4);
            this.pnl_Machine.Controls.Add(this.cb_Machine_type);
            this.pnl_Machine.Controls.Add(this.btn_Reset2);
            this.pnl_Machine.Controls.Add(this.tb_MachineName);
            this.pnl_Machine.Controls.Add(this.btn_Close2);
            this.pnl_Machine.Controls.Add(this.btn_Add2);
            this.pnl_Machine.Controls.Add(this.btn_M_Check);
            this.pnl_Machine.Controls.Add(this.label5);
            this.pnl_Machine.Controls.Add(this.label6);
            this.pnl_Machine.Controls.Add(this.label7);
            this.pnl_Machine.Controls.Add(this.label10);
            this.pnl_Machine.Controls.Add(this.label9);
            this.pnl_Machine.Controls.Add(this.label8);
            this.pnl_Machine.Location = new System.Drawing.Point(12, 42);
            this.pnl_Machine.Name = "pnl_Machine";
            this.pnl_Machine.Size = new System.Drawing.Size(752, 309);
            this.pnl_Machine.TabIndex = 2;
            // 
            // tb_ETC
            // 
            this.tb_ETC.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_ETC.Location = new System.Drawing.Point(509, 185);
            this.tb_ETC.Multiline = true;
            this.tb_ETC.Name = "tb_ETC";
            this.tb_ETC.Size = new System.Drawing.Size(233, 70);
            this.tb_ETC.TabIndex = 271;
            // 
            // tb_Note
            // 
            this.tb_Note.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_Note.Location = new System.Drawing.Point(509, 141);
            this.tb_Note.Name = "tb_Note";
            this.tb_Note.Size = new System.Drawing.Size(233, 27);
            this.tb_Note.TabIndex = 269;
            // 
            // tb_Location
            // 
            this.tb_Location.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_Location.Location = new System.Drawing.Point(509, 97);
            this.tb_Location.Name = "tb_Location";
            this.tb_Location.Size = new System.Drawing.Size(233, 27);
            this.tb_Location.TabIndex = 267;
            // 
            // tb_Manager
            // 
            this.tb_Manager.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_Manager.Location = new System.Drawing.Point(509, 54);
            this.tb_Manager.Name = "tb_Manager";
            this.tb_Manager.Size = new System.Drawing.Size(233, 27);
            this.tb_Manager.TabIndex = 265;
            // 
            // DTP_Day
            // 
            this.DTP_Day.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.DTP_Day.Location = new System.Drawing.Point(138, 184);
            this.DTP_Day.Name = "DTP_Day";
            this.DTP_Day.Size = new System.Drawing.Size(233, 27);
            this.DTP_Day.TabIndex = 263;
            // 
            // btn_N_Check
            // 
            this.btn_N_Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_N_Check.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_N_Check.Location = new System.Drawing.Point(301, 228);
            this.btn_N_Check.Name = "btn_N_Check";
            this.btn_N_Check.Size = new System.Drawing.Size(70, 27);
            this.btn_N_Check.TabIndex = 262;
            this.btn_N_Check.Text = "Check";
            this.btn_N_Check.UseVisualStyleBackColor = true;
            this.btn_N_Check.Click += new System.EventHandler(this.btn_Port_Check_Click);
            // 
            // tb_No
            // 
            this.tb_No.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_No.Location = new System.Drawing.Point(138, 228);
            this.tb_No.Name = "tb_No";
            this.tb_No.Size = new System.Drawing.Size(157, 27);
            this.tb_No.TabIndex = 261;
            // 
            // panel10
            // 
            this.panel10.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel10.Location = new System.Drawing.Point(8, 262);
            this.panel10.Name = "panel10";
            this.panel10.Size = new System.Drawing.Size(736, 1);
            this.panel10.TabIndex = 260;
            // 
            // tb_Company
            // 
            this.tb_Company.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_Company.Location = new System.Drawing.Point(138, 141);
            this.tb_Company.Name = "tb_Company";
            this.tb_Company.Size = new System.Drawing.Size(233, 27);
            this.tb_Company.TabIndex = 258;
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel9.Location = new System.Drawing.Point(7, 219);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(497, 1);
            this.panel9.TabIndex = 256;
            // 
            // label3
            // 
            this.label3.BackColor = System.Drawing.SystemColors.Control;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label3.ForeColor = System.Drawing.Color.Black;
            this.label3.Location = new System.Drawing.Point(7, 176);
            this.label3.Name = "label3";
            this.label3.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label3.Size = new System.Drawing.Size(124, 44);
            this.label3.TabIndex = 255;
            this.label3.Text = "구매 년도";
            this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel5.Location = new System.Drawing.Point(8, 175);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(736, 1);
            this.panel5.TabIndex = 254;
            // 
            // panel6
            // 
            this.panel6.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel6.Location = new System.Drawing.Point(7, 89);
            this.panel6.Name = "panel6";
            this.panel6.Size = new System.Drawing.Size(736, 1);
            this.panel6.TabIndex = 251;
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel7.Location = new System.Drawing.Point(8, 132);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(736, 1);
            this.panel7.TabIndex = 252;
            // 
            // label2
            // 
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label2.ForeColor = System.Drawing.Color.Black;
            this.label2.Location = new System.Drawing.Point(8, 132);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label2.Size = new System.Drawing.Size(124, 44);
            this.label2.TabIndex = 253;
            this.label2.Text = "제작 회사";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel8.Location = new System.Drawing.Point(8, 46);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(736, 1);
            this.panel8.TabIndex = 250;
            // 
            // lbl_MachineName
            // 
            this.lbl_MachineName.BackColor = System.Drawing.SystemColors.Control;
            this.lbl_MachineName.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.lbl_MachineName.ForeColor = System.Drawing.Color.Black;
            this.lbl_MachineName.Location = new System.Drawing.Point(8, 46);
            this.lbl_MachineName.Name = "lbl_MachineName";
            this.lbl_MachineName.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.lbl_MachineName.Size = new System.Drawing.Size(124, 44);
            this.lbl_MachineName.TabIndex = 248;
            this.lbl_MachineName.Text = " 설비 명  ";
            this.lbl_MachineName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label4.Location = new System.Drawing.Point(3, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(212, 30);
            this.label4.TabIndex = 247;
            this.label4.Text = "※ Add Machine List";
            // 
            // cb_Machine_type
            // 
            this.cb_Machine_type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_Machine_type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_Machine_type.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.cb_Machine_type.FormattingEnabled = true;
            this.cb_Machine_type.Location = new System.Drawing.Point(138, 98);
            this.cb_Machine_type.Name = "cb_Machine_type";
            this.cb_Machine_type.Size = new System.Drawing.Size(233, 28);
            this.cb_Machine_type.TabIndex = 246;
            // 
            // btn_Reset2
            // 
            this.btn_Reset2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Reset2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Reset2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Reset2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Reset2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Reset2.ForeColor = System.Drawing.Color.White;
            this.btn_Reset2.Location = new System.Drawing.Point(482, 269);
            this.btn_Reset2.Name = "btn_Reset2";
            this.btn_Reset2.Size = new System.Drawing.Size(83, 33);
            this.btn_Reset2.TabIndex = 245;
            this.btn_Reset2.Text = "⌛ Reset";
            this.btn_Reset2.UseVisualStyleBackColor = false;
            this.btn_Reset2.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // tb_MachineName
            // 
            this.tb_MachineName.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_MachineName.Location = new System.Drawing.Point(138, 54);
            this.tb_MachineName.Name = "tb_MachineName";
            this.tb_MachineName.Size = new System.Drawing.Size(157, 27);
            this.tb_MachineName.TabIndex = 242;
            // 
            // btn_Close2
            // 
            this.btn_Close2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Close2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Close2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Close2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Close2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Close2.ForeColor = System.Drawing.Color.White;
            this.btn_Close2.Location = new System.Drawing.Point(660, 269);
            this.btn_Close2.Name = "btn_Close2";
            this.btn_Close2.Size = new System.Drawing.Size(83, 33);
            this.btn_Close2.TabIndex = 241;
            this.btn_Close2.Text = "√ 닫 기";
            this.btn_Close2.UseVisualStyleBackColor = false;
            this.btn_Close2.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_Add2
            // 
            this.btn_Add2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Add2.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Add2.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_Add2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Add2.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Add2.ForeColor = System.Drawing.Color.White;
            this.btn_Add2.Location = new System.Drawing.Point(571, 269);
            this.btn_Add2.Name = "btn_Add2";
            this.btn_Add2.Size = new System.Drawing.Size(83, 33);
            this.btn_Add2.TabIndex = 240;
            this.btn_Add2.Text = "↺ 추 가";
            this.btn_Add2.UseVisualStyleBackColor = false;
            this.btn_Add2.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_M_Check
            // 
            this.btn_M_Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_M_Check.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_M_Check.Location = new System.Drawing.Point(301, 54);
            this.btn_M_Check.Name = "btn_M_Check";
            this.btn_M_Check.Size = new System.Drawing.Size(70, 27);
            this.btn_M_Check.TabIndex = 239;
            this.btn_M_Check.Text = "Check";
            this.btn_M_Check.UseVisualStyleBackColor = true;
            this.btn_M_Check.Click += new System.EventHandler(this.btn_S_Check_Click);
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label5.ForeColor = System.Drawing.Color.Black;
            this.label5.Location = new System.Drawing.Point(8, 90);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label5.Size = new System.Drawing.Size(124, 44);
            this.label5.TabIndex = 249;
            this.label5.Text = "설비 타입";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.SystemColors.Control;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label6.ForeColor = System.Drawing.Color.Black;
            this.label6.Location = new System.Drawing.Point(8, 219);
            this.label6.Name = "label6";
            this.label6.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label6.Size = new System.Drawing.Size(124, 44);
            this.label6.TabIndex = 259;
            this.label6.Text = "관리 번호";
            this.label6.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label7
            // 
            this.label7.BackColor = System.Drawing.SystemColors.Control;
            this.label7.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label7.ForeColor = System.Drawing.Color.Black;
            this.label7.Location = new System.Drawing.Point(377, 46);
            this.label7.Name = "label7";
            this.label7.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label7.Size = new System.Drawing.Size(126, 44);
            this.label7.TabIndex = 264;
            this.label7.Text = "관리자";
            this.label7.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label10
            // 
            this.label10.BackColor = System.Drawing.SystemColors.Control;
            this.label10.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label10.ForeColor = System.Drawing.Color.Black;
            this.label10.Location = new System.Drawing.Point(377, 176);
            this.label10.Name = "label10";
            this.label10.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label10.Size = new System.Drawing.Size(126, 44);
            this.label10.TabIndex = 270;
            this.label10.Text = "비고";
            this.label10.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label9
            // 
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label9.ForeColor = System.Drawing.Color.Black;
            this.label9.Location = new System.Drawing.Point(377, 133);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label9.Size = new System.Drawing.Size(126, 44);
            this.label9.TabIndex = 268;
            this.label9.Text = "특이사항";
            this.label9.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label8
            // 
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label8.ForeColor = System.Drawing.Color.Black;
            this.label8.Location = new System.Drawing.Point(377, 89);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label8.Size = new System.Drawing.Size(126, 44);
            this.label8.TabIndex = 266;
            this.label8.Text = "배정위치";
            this.label8.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pnl_SF
            // 
            this.pnl_SF.Controls.Add(this.tb_SF_Memo);
            this.pnl_SF.Controls.Add(this.tb_SF_Location);
            this.pnl_SF.Controls.Add(this.tb_Model);
            this.pnl_SF.Controls.Add(this.DTP_SF_Buy);
            this.pnl_SF.Controls.Add(this.tb_SF_Company);
            this.pnl_SF.Controls.Add(this.panel13);
            this.pnl_SF.Controls.Add(this.panel14);
            this.pnl_SF.Controls.Add(this.panel15);
            this.pnl_SF.Controls.Add(this.panel16);
            this.pnl_SF.Controls.Add(this.label12);
            this.pnl_SF.Controls.Add(this.panel17);
            this.pnl_SF.Controls.Add(this.label13);
            this.pnl_SF.Controls.Add(this.label14);
            this.pnl_SF.Controls.Add(this.cb_SF_Type);
            this.pnl_SF.Controls.Add(this.btn_SF_Reset);
            this.pnl_SF.Controls.Add(this.tb_SF_Name);
            this.pnl_SF.Controls.Add(this.btn_SF_Close);
            this.pnl_SF.Controls.Add(this.btn_SF_Add);
            this.pnl_SF.Controls.Add(this.btn_SF_Check);
            this.pnl_SF.Controls.Add(this.label15);
            this.pnl_SF.Controls.Add(this.label17);
            this.pnl_SF.Controls.Add(this.label18);
            this.pnl_SF.Controls.Add(this.label20);
            this.pnl_SF.Controls.Add(this.label11);
            this.pnl_SF.Location = new System.Drawing.Point(12, 42);
            this.pnl_SF.Name = "pnl_SF";
            this.pnl_SF.Size = new System.Drawing.Size(752, 268);
            this.pnl_SF.TabIndex = 272;
            // 
            // tb_SF_Memo
            // 
            this.tb_SF_Memo.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_SF_Memo.Location = new System.Drawing.Point(138, 185);
            this.tb_SF_Memo.Multiline = true;
            this.tb_SF_Memo.Name = "tb_SF_Memo";
            this.tb_SF_Memo.Size = new System.Drawing.Size(604, 27);
            this.tb_SF_Memo.TabIndex = 271;
            // 
            // tb_SF_Location
            // 
            this.tb_SF_Location.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_SF_Location.Location = new System.Drawing.Point(509, 97);
            this.tb_SF_Location.Name = "tb_SF_Location";
            this.tb_SF_Location.Size = new System.Drawing.Size(233, 27);
            this.tb_SF_Location.TabIndex = 267;
            // 
            // tb_Model
            // 
            this.tb_Model.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_Model.Location = new System.Drawing.Point(138, 98);
            this.tb_Model.Name = "tb_Model";
            this.tb_Model.Size = new System.Drawing.Size(233, 27);
            this.tb_Model.TabIndex = 265;
            // 
            // DTP_SF_Buy
            // 
            this.DTP_SF_Buy.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.DTP_SF_Buy.Location = new System.Drawing.Point(509, 141);
            this.DTP_SF_Buy.Name = "DTP_SF_Buy";
            this.DTP_SF_Buy.Size = new System.Drawing.Size(233, 27);
            this.DTP_SF_Buy.TabIndex = 263;
            // 
            // tb_SF_Company
            // 
            this.tb_SF_Company.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_SF_Company.Location = new System.Drawing.Point(138, 141);
            this.tb_SF_Company.Name = "tb_SF_Company";
            this.tb_SF_Company.Size = new System.Drawing.Size(233, 27);
            this.tb_SF_Company.TabIndex = 258;
            // 
            // panel13
            // 
            this.panel13.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel13.Location = new System.Drawing.Point(7, 219);
            this.panel13.Name = "panel13";
            this.panel13.Size = new System.Drawing.Size(736, 1);
            this.panel13.TabIndex = 256;
            // 
            // panel14
            // 
            this.panel14.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel14.Location = new System.Drawing.Point(8, 175);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(736, 1);
            this.panel14.TabIndex = 254;
            // 
            // panel15
            // 
            this.panel15.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel15.Location = new System.Drawing.Point(7, 89);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(736, 1);
            this.panel15.TabIndex = 251;
            // 
            // panel16
            // 
            this.panel16.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel16.Location = new System.Drawing.Point(8, 132);
            this.panel16.Name = "panel16";
            this.panel16.Size = new System.Drawing.Size(736, 1);
            this.panel16.TabIndex = 252;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Control;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label12.ForeColor = System.Drawing.Color.Black;
            this.label12.Location = new System.Drawing.Point(8, 132);
            this.label12.Name = "label12";
            this.label12.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label12.Size = new System.Drawing.Size(124, 44);
            this.label12.TabIndex = 253;
            this.label12.Text = "제작 회사";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // panel17
            // 
            this.panel17.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel17.Location = new System.Drawing.Point(8, 46);
            this.panel17.Name = "panel17";
            this.panel17.Size = new System.Drawing.Size(736, 1);
            this.panel17.TabIndex = 250;
            // 
            // label13
            // 
            this.label13.BackColor = System.Drawing.SystemColors.Control;
            this.label13.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label13.ForeColor = System.Drawing.Color.Black;
            this.label13.Location = new System.Drawing.Point(8, 46);
            this.label13.Name = "label13";
            this.label13.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label13.Size = new System.Drawing.Size(124, 44);
            this.label13.TabIndex = 248;
            this.label13.Text = " 설비 명  ";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label14.Location = new System.Drawing.Point(3, 4);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(212, 30);
            this.label14.TabIndex = 247;
            this.label14.Text = "※ Add Machine List";
            // 
            // cb_SF_Type
            // 
            this.cb_SF_Type.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cb_SF_Type.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cb_SF_Type.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.cb_SF_Type.FormattingEnabled = true;
            this.cb_SF_Type.Location = new System.Drawing.Point(509, 54);
            this.cb_SF_Type.Name = "cb_SF_Type";
            this.cb_SF_Type.Size = new System.Drawing.Size(233, 28);
            this.cb_SF_Type.TabIndex = 246;
            // 
            // btn_SF_Reset
            // 
            this.btn_SF_Reset.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_SF_Reset.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_SF_Reset.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_SF_Reset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SF_Reset.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_SF_Reset.ForeColor = System.Drawing.Color.White;
            this.btn_SF_Reset.Location = new System.Drawing.Point(481, 226);
            this.btn_SF_Reset.Name = "btn_SF_Reset";
            this.btn_SF_Reset.Size = new System.Drawing.Size(83, 33);
            this.btn_SF_Reset.TabIndex = 245;
            this.btn_SF_Reset.Text = "⌛ Reset";
            this.btn_SF_Reset.UseVisualStyleBackColor = false;
            this.btn_SF_Reset.Click += new System.EventHandler(this.btn_Reset_Click);
            // 
            // tb_SF_Name
            // 
            this.tb_SF_Name.Font = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.tb_SF_Name.Location = new System.Drawing.Point(138, 54);
            this.tb_SF_Name.Name = "tb_SF_Name";
            this.tb_SF_Name.Size = new System.Drawing.Size(157, 27);
            this.tb_SF_Name.TabIndex = 242;
            // 
            // btn_SF_Close
            // 
            this.btn_SF_Close.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_SF_Close.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_SF_Close.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_SF_Close.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SF_Close.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_SF_Close.ForeColor = System.Drawing.Color.White;
            this.btn_SF_Close.Location = new System.Drawing.Point(659, 226);
            this.btn_SF_Close.Name = "btn_SF_Close";
            this.btn_SF_Close.Size = new System.Drawing.Size(83, 33);
            this.btn_SF_Close.TabIndex = 241;
            this.btn_SF_Close.Text = "√ 닫 기";
            this.btn_SF_Close.UseVisualStyleBackColor = false;
            this.btn_SF_Close.Click += new System.EventHandler(this.btn_Close_Click);
            // 
            // btn_SF_Add
            // 
            this.btn_SF_Add.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_SF_Add.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_SF_Add.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0)))));
            this.btn_SF_Add.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SF_Add.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_SF_Add.ForeColor = System.Drawing.Color.White;
            this.btn_SF_Add.Location = new System.Drawing.Point(570, 226);
            this.btn_SF_Add.Name = "btn_SF_Add";
            this.btn_SF_Add.Size = new System.Drawing.Size(83, 33);
            this.btn_SF_Add.TabIndex = 240;
            this.btn_SF_Add.Text = "↺ 추 가";
            this.btn_SF_Add.UseVisualStyleBackColor = false;
            this.btn_SF_Add.Click += new System.EventHandler(this.btn_Add_Click);
            // 
            // btn_SF_Check
            // 
            this.btn_SF_Check.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_SF_Check.Font = new System.Drawing.Font("맑은 고딕", 11.25F, System.Drawing.FontStyle.Bold);
            this.btn_SF_Check.Location = new System.Drawing.Point(301, 54);
            this.btn_SF_Check.Name = "btn_SF_Check";
            this.btn_SF_Check.Size = new System.Drawing.Size(70, 27);
            this.btn_SF_Check.TabIndex = 239;
            this.btn_SF_Check.Text = "Check";
            this.btn_SF_Check.UseVisualStyleBackColor = true;
            this.btn_SF_Check.Click += new System.EventHandler(this.btn_S_Check_Click);
            // 
            // label15
            // 
            this.label15.BackColor = System.Drawing.SystemColors.Control;
            this.label15.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label15.ForeColor = System.Drawing.Color.Black;
            this.label15.Location = new System.Drawing.Point(377, 46);
            this.label15.Name = "label15";
            this.label15.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label15.Size = new System.Drawing.Size(124, 44);
            this.label15.TabIndex = 249;
            this.label15.Text = "설비 타입";
            this.label15.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label17
            // 
            this.label17.BackColor = System.Drawing.SystemColors.Control;
            this.label17.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label17.ForeColor = System.Drawing.Color.Black;
            this.label17.Location = new System.Drawing.Point(8, 89);
            this.label17.Name = "label17";
            this.label17.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label17.Size = new System.Drawing.Size(126, 44);
            this.label17.TabIndex = 264;
            this.label17.Text = "모델 명";
            this.label17.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label18
            // 
            this.label18.BackColor = System.Drawing.SystemColors.Control;
            this.label18.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label18.ForeColor = System.Drawing.Color.Black;
            this.label18.Location = new System.Drawing.Point(8, 175);
            this.label18.Name = "label18";
            this.label18.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label18.Size = new System.Drawing.Size(126, 44);
            this.label18.TabIndex = 270;
            this.label18.Text = "비고";
            this.label18.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label20
            // 
            this.label20.BackColor = System.Drawing.SystemColors.Control;
            this.label20.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label20.ForeColor = System.Drawing.Color.Black;
            this.label20.Location = new System.Drawing.Point(376, 89);
            this.label20.Name = "label20";
            this.label20.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label20.Size = new System.Drawing.Size(126, 44);
            this.label20.TabIndex = 266;
            this.label20.Text = "배정 위치";
            this.label20.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label11
            // 
            this.label11.BackColor = System.Drawing.SystemColors.Control;
            this.label11.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label11.ForeColor = System.Drawing.Color.Black;
            this.label11.Location = new System.Drawing.Point(378, 132);
            this.label11.Name = "label11";
            this.label11.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label11.Size = new System.Drawing.Size(124, 44);
            this.label11.TabIndex = 255;
            this.label11.Text = "구매 년도";
            this.label11.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // AddMachine
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(768, 315);
            this.Controls.Add(this.Cb_Type);
            this.Controls.Add(this.pnl_SF);
            this.Controls.Add(this.pnl_Scanner);
            this.Controls.Add(this.pnl_Machine);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "AddMachine";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "AddMachine";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.AddMachine_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.AddMachine_MouseMove);
            this.pnl_Scanner.ResumeLayout(false);
            this.pnl_Scanner.PerformLayout();
            this.pnl_Machine.ResumeLayout(false);
            this.pnl_Machine.PerformLayout();
            this.pnl_SF.ResumeLayout(false);
            this.pnl_SF.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ComboBox Cb_Type;
        private System.Windows.Forms.Panel pnl_Scanner;
        private System.Windows.Forms.ComboBox cb_Machine;
        private System.Windows.Forms.Button btn_Reset;
        private System.Windows.Forms.Button btn_Port_Check;
        private System.Windows.Forms.TextBox tb_PortName;
        private System.Windows.Forms.TextBox tb_ScannerName;
        private System.Windows.Forms.Button btn_Close;
        private System.Windows.Forms.Button btn_Add;
        private System.Windows.Forms.Button btn_S_Check;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label lbl_Machine;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbl_PortNum;
        private System.Windows.Forms.Label lbl_ScannerName;
        private System.Windows.Forms.Panel panel4;
        private System.Windows.Forms.Panel pnl_Machine;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.Panel panel6;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label lbl_MachineName;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cb_Machine_type;
        private System.Windows.Forms.Button btn_Reset2;
        private System.Windows.Forms.TextBox tb_MachineName;
        private System.Windows.Forms.Button btn_Close2;
        private System.Windows.Forms.Button btn_Add2;
        private System.Windows.Forms.Button btn_M_Check;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btn_N_Check;
        private System.Windows.Forms.TextBox tb_No;
        private System.Windows.Forms.Panel panel10;
        private System.Windows.Forms.TextBox tb_Company;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker DTP_Day;
        private System.Windows.Forms.TextBox tb_Manager;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox tb_ETC;
        private System.Windows.Forms.TextBox tb_Note;
        private System.Windows.Forms.TextBox tb_Location;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Panel pnl_SF;
        private System.Windows.Forms.TextBox tb_SF_Memo;
        private System.Windows.Forms.TextBox tb_SF_Location;
        private System.Windows.Forms.TextBox tb_Model;
        private System.Windows.Forms.DateTimePicker DTP_SF_Buy;
        private System.Windows.Forms.TextBox tb_SF_Company;
        private System.Windows.Forms.Panel panel13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Panel panel16;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Panel panel17;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.ComboBox cb_SF_Type;
        private System.Windows.Forms.Button btn_SF_Reset;
        private System.Windows.Forms.TextBox tb_SF_Name;
        private System.Windows.Forms.Button btn_SF_Close;
        private System.Windows.Forms.Button btn_SF_Add;
        private System.Windows.Forms.Button btn_SF_Check;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.Label label20;
    }
}