namespace View
{
    partial class DefectAnalysis
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem1 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem2 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.dgv_Daily = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.label6 = new System.Windows.Forms.Label();
            this.dgv_Defect = new System.Windows.Forms.DataGridView();
            this.chart_Month = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label16 = new System.Windows.Forms.Label();
            this.btn_Search = new System.Windows.Forms.Button();
            this.panel7 = new System.Windows.Forms.Panel();
            this.panel8 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.DTP_StartTime = new System.Windows.Forms.DateTimePicker();
            this.DTP_EndTime = new System.Windows.Forms.DateTimePicker();
            this.lbl_Defect = new System.Windows.Forms.Label();
            this.lbl_Clear = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.lbl_Error = new System.Windows.Forms.Label();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column15 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn11 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn12 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column14 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Daily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Defect)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Month)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_Daily
            // 
            this.dgv_Daily.AllowUserToAddRows = false;
            this.dgv_Daily.AllowUserToDeleteRows = false;
            this.dgv_Daily.AllowUserToResizeColumns = false;
            this.dgv_Daily.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_Daily.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgv_Daily.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Daily.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Daily.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Daily.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Daily.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Daily.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Daily.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column5});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Daily.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Daily.Location = new System.Drawing.Point(1031, 544);
            this.dgv_Daily.Name = "dgv_Daily";
            this.dgv_Daily.ReadOnly = true;
            this.dgv_Daily.RowHeadersWidth = 5;
            this.dgv_Daily.RowTemplate.Height = 30;
            this.dgv_Daily.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Daily.Size = new System.Drawing.Size(570, 361);
            this.dgv_Daily.TabIndex = 105;
            this.dgv_Daily.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "날짜";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "양호";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "폐기";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(1490, 9);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(394, 15);
            this.label6.TabIndex = 114;
            this.label6.Text = "불량 건수는 품목 불량 개수가 아닌 해당 날짜의 불량 발생 건 수 입니다.";
            // 
            // dgv_Defect
            // 
            this.dgv_Defect.AllowUserToAddRows = false;
            this.dgv_Defect.AllowUserToDeleteRows = false;
            this.dgv_Defect.AllowUserToResizeColumns = false;
            this.dgv_Defect.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_Defect.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Defect.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Defect.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Defect.BackgroundColor = System.Drawing.SystemColors.Window;
            this.dgv_Defect.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Defect.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgv_Defect.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Defect.ColumnHeadersHeight = 35;
            this.dgv_Defect.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn3,
            this.dataGridViewTextBoxColumn6,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn7,
            this.Column15,
            this.dataGridViewTextBoxColumn8,
            this.dataGridViewTextBoxColumn9,
            this.dataGridViewTextBoxColumn10,
            this.dataGridViewTextBoxColumn11,
            this.dataGridViewTextBoxColumn12,
            this.dataGridViewTextBoxColumn13,
            this.dataGridViewTextBoxColumn14,
            this.Column13,
            this.Column14,
            this.Column3});
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("맑은 고딕", 11F);
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(240)))), ((int)(((byte)(254)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Defect.DefaultCellStyle = dataGridViewCellStyle5;
            this.dgv_Defect.EnableHeadersVisualStyles = false;
            this.dgv_Defect.Location = new System.Drawing.Point(27, 496);
            this.dgv_Defect.Margin = new System.Windows.Forms.Padding(2);
            this.dgv_Defect.Name = "dgv_Defect";
            this.dgv_Defect.ReadOnly = true;
            this.dgv_Defect.RowHeadersVisible = false;
            this.dgv_Defect.RowHeadersWidth = 5;
            this.dgv_Defect.RowTemplate.Height = 30;
            this.dgv_Defect.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Defect.Size = new System.Drawing.Size(1861, 436);
            this.dgv_Defect.TabIndex = 296;
            this.dgv_Defect.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_Defect_CellClick);
            // 
            // chart_Month
            // 
            chartArea1.AxisY.Interval = 2D;
            chartArea1.Name = "ChartArea1";
            this.chart_Month.ChartAreas.Add(chartArea1);
            legendItem1.Color = System.Drawing.Color.Lime;
            legendItem1.Name = "양호";
            legendItem2.Color = System.Drawing.Color.Red;
            legendItem2.Name = "폐기";
            legend1.CustomItems.Add(legendItem1);
            legend1.CustomItems.Add(legendItem2);
            legend1.Name = "Legend1";
            this.chart_Month.Legends.Add(legend1);
            this.chart_Month.Location = new System.Drawing.Point(23, 136);
            this.chart_Month.Name = "chart_Month";
            series1.BorderWidth = 50;
            series1.ChartArea = "ChartArea1";
            series1.Color = System.Drawing.Color.Lime;
            series1.CustomProperties = "DrawingStyle=Cylinder";
            series1.IsValueShownAsLabel = true;
            series1.IsVisibleInLegend = false;
            series1.Label = "#VAL";
            series1.Legend = "Legend1";
            series1.Name = "양호";
            series2.BorderWidth = 15;
            series2.ChartArea = "ChartArea1";
            series2.Color = System.Drawing.Color.DarkOrange;
            series2.CustomProperties = "DrawingStyle=Cylinder";
            series2.IsValueShownAsLabel = true;
            series2.IsVisibleInLegend = false;
            series2.Label = "#VAL";
            series2.Legend = "Legend1";
            series2.Name = "폐기";
            this.chart_Month.Series.Add(series1);
            this.chart_Month.Series.Add(series2);
            this.chart_Month.Size = new System.Drawing.Size(1872, 326);
            this.chart_Month.TabIndex = 299;
            this.chart_Month.Text = "chart1";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label16.Location = new System.Drawing.Point(22, 9);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(177, 30);
            this.label16.TabIndex = 300;
            this.label16.Text = "※ 월간 조치 이력";
            // 
            // btn_Search
            // 
            this.btn_Search.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Search.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Search.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Search.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Search.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Search.ForeColor = System.Drawing.Color.White;
            this.btn_Search.Location = new System.Drawing.Point(465, 53);
            this.btn_Search.Name = "btn_Search";
            this.btn_Search.Size = new System.Drawing.Size(83, 29);
            this.btn_Search.TabIndex = 309;
            this.btn_Search.Text = "⌕ 조 회";
            this.btn_Search.UseVisualStyleBackColor = false;
            this.btn_Search.Click += new System.EventHandler(this.btn_Search_Click);
            // 
            // panel7
            // 
            this.panel7.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel7.Location = new System.Drawing.Point(23, 89);
            this.panel7.Name = "panel7";
            this.panel7.Size = new System.Drawing.Size(1872, 1);
            this.panel7.TabIndex = 308;
            // 
            // panel8
            // 
            this.panel8.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel8.Location = new System.Drawing.Point(23, 46);
            this.panel8.Name = "panel8";
            this.panel8.Size = new System.Drawing.Size(1872, 1);
            this.panel8.TabIndex = 307;
            // 
            // label5
            // 
            this.label5.BackColor = System.Drawing.SystemColors.Control;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label5.Location = new System.Drawing.Point(23, 46);
            this.label5.Name = "label5";
            this.label5.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label5.Size = new System.Drawing.Size(124, 44);
            this.label5.TabIndex = 305;
            this.label5.Text = "조회 일자";
            this.label5.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label12
            // 
            this.label12.BackColor = System.Drawing.SystemColors.Window;
            this.label12.Font = new System.Drawing.Font("맑은 고딕", 14.25F, System.Drawing.FontStyle.Bold);
            this.label12.Location = new System.Drawing.Point(292, 53);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(28, 29);
            this.label12.TabIndex = 303;
            this.label12.Text = "~";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // DTP_StartTime
            // 
            this.DTP_StartTime.CalendarFont = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.DTP_StartTime.CustomFormat = "yyyy-MM-dd";
            this.DTP_StartTime.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.DTP_StartTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_StartTime.Location = new System.Drawing.Point(152, 53);
            this.DTP_StartTime.Margin = new System.Windows.Forms.Padding(2);
            this.DTP_StartTime.Name = "DTP_StartTime";
            this.DTP_StartTime.Size = new System.Drawing.Size(135, 29);
            this.DTP_StartTime.TabIndex = 301;
            // 
            // DTP_EndTime
            // 
            this.DTP_EndTime.CalendarFont = new System.Drawing.Font("맑은 고딕", 11.25F);
            this.DTP_EndTime.CustomFormat = "yyyy-MM-dd";
            this.DTP_EndTime.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.DTP_EndTime.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.DTP_EndTime.Location = new System.Drawing.Point(325, 53);
            this.DTP_EndTime.Margin = new System.Windows.Forms.Padding(2);
            this.DTP_EndTime.Name = "DTP_EndTime";
            this.DTP_EndTime.Size = new System.Drawing.Size(135, 29);
            this.DTP_EndTime.TabIndex = 302;
            // 
            // lbl_Defect
            // 
            this.lbl_Defect.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Defect.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_Defect.Location = new System.Drawing.Point(1842, 53);
            this.lbl_Defect.Name = "lbl_Defect";
            this.lbl_Defect.Size = new System.Drawing.Size(50, 29);
            this.lbl_Defect.TabIndex = 369;
            this.lbl_Defect.Text = "label2";
            this.lbl_Defect.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lbl_Clear
            // 
            this.lbl_Clear.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Clear.ForeColor = System.Drawing.Color.PaleGreen;
            this.lbl_Clear.Location = new System.Drawing.Point(1657, 53);
            this.lbl_Clear.Name = "lbl_Clear";
            this.lbl_Clear.Size = new System.Drawing.Size(50, 29);
            this.lbl_Clear.TabIndex = 368;
            this.lbl_Clear.Text = "label1";
            this.lbl_Clear.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label1.Location = new System.Drawing.Point(1529, 46);
            this.label1.Name = "label1";
            this.label1.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label1.Size = new System.Drawing.Size(124, 44);
            this.label1.TabIndex = 370;
            this.label1.Text = "양품 개수";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label2.Location = new System.Drawing.Point(1715, 46);
            this.label2.Name = "label2";
            this.label2.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label2.Size = new System.Drawing.Size(124, 44);
            this.label2.TabIndex = 371;
            this.label2.Text = "폐기 개수";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.label3.Location = new System.Drawing.Point(1674, 465);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 15);
            this.label3.TabIndex = 372;
            this.label3.Text = "항목 클릭 시 자세히 보기가 나옵니다.";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.SystemColors.Control;
            this.label4.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label4.Location = new System.Drawing.Point(1343, 46);
            this.label4.Name = "label4";
            this.label4.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label4.Size = new System.Drawing.Size(124, 44);
            this.label4.TabIndex = 374;
            this.label4.Text = "불량 개수";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_Error
            // 
            this.lbl_Error.Font = new System.Drawing.Font("맑은 고딕", 12.25F, System.Drawing.FontStyle.Bold);
            this.lbl_Error.ForeColor = System.Drawing.Color.IndianRed;
            this.lbl_Error.Location = new System.Drawing.Point(1473, 53);
            this.lbl_Error.Name = "lbl_Error";
            this.lbl_Error.Size = new System.Drawing.Size(50, 29);
            this.lbl_Error.TabIndex = 373;
            this.lbl_Error.Text = "label2";
            this.lbl_Error.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "No";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            this.dataGridViewTextBoxColumn1.Visible = false;
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.HeaderText = "수주명";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            this.dataGridViewTextBoxColumn3.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn6
            // 
            this.dataGridViewTextBoxColumn6.HeaderText = "품목명";
            this.dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            this.dataGridViewTextBoxColumn6.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.HeaderText = "작업지시서 번호";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            this.dataGridViewTextBoxColumn2.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn7
            // 
            this.dataGridViewTextBoxColumn7.HeaderText = "공정명";
            this.dataGridViewTextBoxColumn7.Name = "dataGridViewTextBoxColumn7";
            this.dataGridViewTextBoxColumn7.ReadOnly = true;
            // 
            // Column15
            // 
            this.Column15.HeaderText = "품목상태";
            this.Column15.Name = "Column15";
            this.Column15.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn8
            // 
            this.dataGridViewTextBoxColumn8.HeaderText = "작업자";
            this.dataGridViewTextBoxColumn8.Name = "dataGridViewTextBoxColumn8";
            this.dataGridViewTextBoxColumn8.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn9
            // 
            this.dataGridViewTextBoxColumn9.HeaderText = "작업설비명";
            this.dataGridViewTextBoxColumn9.Name = "dataGridViewTextBoxColumn9";
            this.dataGridViewTextBoxColumn9.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn10
            // 
            this.dataGridViewTextBoxColumn10.HeaderText = "작업시작시간";
            this.dataGridViewTextBoxColumn10.Name = "dataGridViewTextBoxColumn10";
            this.dataGridViewTextBoxColumn10.ReadOnly = true;
            this.dataGridViewTextBoxColumn10.Visible = false;
            // 
            // dataGridViewTextBoxColumn11
            // 
            this.dataGridViewTextBoxColumn11.HeaderText = "작업종료시간";
            this.dataGridViewTextBoxColumn11.Name = "dataGridViewTextBoxColumn11";
            this.dataGridViewTextBoxColumn11.ReadOnly = true;
            this.dataGridViewTextBoxColumn11.Visible = false;
            // 
            // dataGridViewTextBoxColumn12
            // 
            this.dataGridViewTextBoxColumn12.HeaderText = "조치담당자";
            this.dataGridViewTextBoxColumn12.Name = "dataGridViewTextBoxColumn12";
            this.dataGridViewTextBoxColumn12.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn13
            // 
            this.dataGridViewTextBoxColumn13.HeaderText = "불량원인";
            this.dataGridViewTextBoxColumn13.Name = "dataGridViewTextBoxColumn13";
            this.dataGridViewTextBoxColumn13.ReadOnly = true;
            // 
            // dataGridViewTextBoxColumn14
            // 
            this.dataGridViewTextBoxColumn14.HeaderText = "불량조치기한";
            this.dataGridViewTextBoxColumn14.Name = "dataGridViewTextBoxColumn14";
            this.dataGridViewTextBoxColumn14.ReadOnly = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "불량조치사항";
            this.Column13.Name = "Column13";
            this.Column13.ReadOnly = true;
            // 
            // Column14
            // 
            this.Column14.HeaderText = "비고";
            this.Column14.Name = "Column14";
            this.Column14.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "불량 발생 시간";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // DefectAnalysis
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1910, 956);
            this.Controls.Add(this.lbl_Error);
            this.Controls.Add(this.dgv_Daily);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.btn_Search);
            this.Controls.Add(this.panel7);
            this.Controls.Add(this.panel8);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.DTP_StartTime);
            this.Controls.Add(this.DTP_EndTime);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.chart_Month);
            this.Controls.Add(this.dgv_Defect);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbl_Clear);
            this.Controls.Add(this.lbl_Defect);
            this.Controls.Add(this.label4);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "DefectAnalysis";
            this.Text = "Operating_Rate_by_Period";
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Daily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Defect)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Month)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataGridView dgv_Defect;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Month;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Button btn_Search;
        private System.Windows.Forms.Panel panel7;
        private System.Windows.Forms.Panel panel8;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.DateTimePicker DTP_StartTime;
        private System.Windows.Forms.DateTimePicker DTP_EndTime;
        private System.Windows.Forms.Label lbl_Defect;
        private System.Windows.Forms.Label lbl_Clear;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgv_Daily;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label lbl_Error;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column15;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn8;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn9;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn10;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn11;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn12;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn13;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column13;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column14;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
    }
}