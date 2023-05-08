namespace View
{
    partial class Operating_Rate_by_Period
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem1 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem2 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem3 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem4 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem5 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.LegendItem legendItem6 = new System.Windows.Forms.DataVisualization.Charting.LegendItem();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.Chart_Count = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dgv_Daily = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgv_Count = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Chart_Period = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label6 = new System.Windows.Forms.Label();
            this.btn_Chart = new System.Windows.Forms.Button();
            this.Dtp_End = new System.Windows.Forms.DateTimePicker();
            this.Dtp_Start = new System.Windows.Forms.DateTimePicker();
            this.label5 = new System.Windows.Forms.Label();
            this.chart_Month = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Daily)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Count)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Period)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Month)).BeginInit();
            this.SuspendLayout();
            // 
            // Chart_Count
            // 
            this.Chart_Count.BackColor = System.Drawing.SystemColors.Window;
            this.Chart_Count.BorderlineColor = System.Drawing.Color.Tan;
            chartArea1.AxisX.MajorGrid.Enabled = false;
            chartArea1.AxisX.MajorTickMark.Enabled = false;
            chartArea1.AxisY.MajorGrid.LineColor = System.Drawing.SystemColors.Control;
            chartArea1.AxisY.MajorGrid.LineWidth = 2;
            chartArea1.AxisY.MajorTickMark.Enabled = false;
            chartArea1.BackColor = System.Drawing.SystemColors.Window;
            chartArea1.Name = "ChartArea1";
            this.Chart_Count.ChartAreas.Add(chartArea1);
            legend1.BackColor = System.Drawing.SystemColors.Window;
            legendItem1.Color = System.Drawing.Color.Lime;
            legendItem1.Name = "Operation";
            legendItem2.Color = System.Drawing.Color.DarkOrange;
            legendItem2.Name = "Unoperation";
            legend1.CustomItems.Add(legendItem1);
            legend1.CustomItems.Add(legendItem2);
            legend1.Name = "Legend1";
            this.Chart_Count.Legends.Add(legend1);
            this.Chart_Count.Location = new System.Drawing.Point(12, 603);
            this.Chart_Count.Name = "Chart_Count";
            series1.BorderWidth = 3;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Lime;
            series1.IsValueShownAsLabel = true;
            series1.Label = "#VAL";
            series1.LabelBorderWidth = 3;
            series1.Legend = "Legend1";
            series1.MarkerBorderWidth = 2;
            series1.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series1.Name = "Operation";
            series1.YValuesPerPoint = 4;
            series2.BorderColor = System.Drawing.Color.Magenta;
            series2.BorderWidth = 3;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.DarkOrange;
            series2.IsValueShownAsLabel = true;
            series2.Label = "#VAL";
            series2.Legend = "Legend1";
            series2.MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
            series2.Name = "Unoperation";
            series2.YValuesPerPoint = 2;
            this.Chart_Count.Series.Add(series1);
            this.Chart_Count.Series.Add(series2);
            this.Chart_Count.Size = new System.Drawing.Size(1942, 306);
            this.Chart_Count.TabIndex = 88;
            this.Chart_Count.Text = "chart1";
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
            this.Column5,
            this.Column2});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Daily.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgv_Daily.Location = new System.Drawing.Point(124, 676);
            this.dgv_Daily.Name = "dgv_Daily";
            this.dgv_Daily.ReadOnly = true;
            this.dgv_Daily.RowHeadersWidth = 5;
            this.dgv_Daily.RowTemplate.Height = 30;
            this.dgv_Daily.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Daily.Size = new System.Drawing.Size(570, 236);
            this.dgv_Daily.TabIndex = 89;
            this.dgv_Daily.Visible = false;
            // 
            // Column1
            // 
            this.Column1.HeaderText = "날짜";
            this.Column1.Name = "Column1";
            this.Column1.ReadOnly = true;
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Operation";
            this.Column5.Name = "Column5";
            this.Column5.ReadOnly = true;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Unoperation";
            this.Column2.Name = "Column2";
            this.Column2.ReadOnly = true;
            // 
            // dgv_Count
            // 
            this.dgv_Count.AllowUserToAddRows = false;
            this.dgv_Count.AllowUserToDeleteRows = false;
            this.dgv_Count.AllowUserToResizeColumns = false;
            this.dgv_Count.AllowUserToResizeRows = false;
            dataGridViewCellStyle3.BackColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_Count.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle3;
            this.dgv_Count.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgv_Count.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv_Count.BackgroundColor = System.Drawing.SystemColors.Control;
            this.dgv_Count.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgv_Count.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgv_Count.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_Count.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.Column3,
            this.Column4});
            dataGridViewCellStyle4.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle4.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("굴림", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            dataGridViewCellStyle4.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle4.SelectionBackColor = System.Drawing.SystemColors.GradientActiveCaption;
            dataGridViewCellStyle4.SelectionForeColor = System.Drawing.SystemColors.Desktop;
            dataGridViewCellStyle4.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgv_Count.DefaultCellStyle = dataGridViewCellStyle4;
            this.dgv_Count.Location = new System.Drawing.Point(700, 676);
            this.dgv_Count.Name = "dgv_Count";
            this.dgv_Count.ReadOnly = true;
            this.dgv_Count.RowHeadersWidth = 5;
            this.dgv_Count.RowTemplate.Height = 30;
            this.dgv_Count.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgv_Count.Size = new System.Drawing.Size(570, 236);
            this.dgv_Count.TabIndex = 90;
            this.dgv_Count.Visible = false;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.HeaderText = "날짜";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            this.dataGridViewTextBoxColumn1.ReadOnly = true;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Operation";
            this.Column3.Name = "Column3";
            this.Column3.ReadOnly = true;
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Unoperation";
            this.Column4.Name = "Column4";
            this.Column4.ReadOnly = true;
            // 
            // Chart_Period
            // 
            this.Chart_Period.BackColor = System.Drawing.SystemColors.Window;
            this.Chart_Period.BorderlineColor = System.Drawing.Color.Black;
            this.Chart_Period.BorderlineDashStyle = System.Windows.Forms.DataVisualization.Charting.ChartDashStyle.Solid;
            chartArea2.BackColor = System.Drawing.SystemColors.Window;
            chartArea2.Name = "ChartArea1";
            chartArea2.ShadowColor = System.Drawing.SystemColors.Window;
            this.Chart_Period.ChartAreas.Add(chartArea2);
            legend2.BackColor = System.Drawing.SystemColors.Window;
            legendItem3.Color = System.Drawing.Color.Lime;
            legendItem3.Name = "Operation";
            legendItem4.Color = System.Drawing.Color.DarkOrange;
            legendItem4.Name = "Unoperation";
            legend2.CustomItems.Add(legendItem3);
            legend2.CustomItems.Add(legendItem4);
            legend2.Name = "Legend1";
            this.Chart_Period.Legends.Add(legend2);
            this.Chart_Period.Location = new System.Drawing.Point(1207, 119);
            this.Chart_Period.Name = "Chart_Period";
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Doughnut;
            series3.Color = System.Drawing.Color.Red;
            series3.CustomProperties = "DoughnutRadius=70, PieDrawingStyle=Concave";
            series3.Font = new System.Drawing.Font("맑은 고딕", 10.25F, System.Drawing.FontStyle.Bold);
            series3.IsVisibleInLegend = false;
            series3.Label = "#PERCENT";
            series3.Legend = "Legend1";
            series3.Name = "Select";
            series3.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.BrightPastel;
            this.Chart_Period.Series.Add(series3);
            this.Chart_Period.Size = new System.Drawing.Size(691, 391);
            this.Chart_Period.TabIndex = 92;
            this.Chart_Period.Text = "chart2";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.label6.Location = new System.Drawing.Point(1672, 41);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(218, 15);
            this.label6.TabIndex = 101;
            this.label6.Text = "기본 차트는 전날 데이터가 보여집니다.";
            // 
            // btn_Chart
            // 
            this.btn_Chart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Chart.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.btn_Chart.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(48)))), ((int)(((byte)(103)))), ((int)(((byte)(162)))));
            this.btn_Chart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btn_Chart.Font = new System.Drawing.Font("맑은 고딕", 11F, System.Drawing.FontStyle.Bold);
            this.btn_Chart.ForeColor = System.Drawing.Color.White;
            this.btn_Chart.Location = new System.Drawing.Point(1783, 74);
            this.btn_Chart.Name = "btn_Chart";
            this.btn_Chart.Size = new System.Drawing.Size(107, 29);
            this.btn_Chart.TabIndex = 98;
            this.btn_Chart.Text = "⌕ 조 회";
            this.btn_Chart.UseVisualStyleBackColor = false;
            this.btn_Chart.Click += new System.EventHandler(this.btn_Chart_Click);
            // 
            // Dtp_End
            // 
            this.Dtp_End.CalendarMonthBackground = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(0)))), ((int)(((byte)(64)))));
            this.Dtp_End.CalendarTitleBackColor = System.Drawing.Color.Red;
            this.Dtp_End.CustomFormat = "yyyy-MM-dd";
            this.Dtp_End.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.Dtp_End.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_End.Location = new System.Drawing.Point(1627, 74);
            this.Dtp_End.Name = "Dtp_End";
            this.Dtp_End.Size = new System.Drawing.Size(150, 29);
            this.Dtp_End.TabIndex = 66;
            // 
            // Dtp_Start
            // 
            this.Dtp_Start.CustomFormat = "yyyy-MM-dd";
            this.Dtp_Start.Font = new System.Drawing.Font("맑은 고딕", 12F, System.Drawing.FontStyle.Bold);
            this.Dtp_Start.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.Dtp_Start.Location = new System.Drawing.Point(1341, 74);
            this.Dtp_Start.Name = "Dtp_Start";
            this.Dtp_Start.Size = new System.Drawing.Size(150, 29);
            this.Dtp_Start.TabIndex = 65;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("맑은 고딕", 9F, System.Drawing.FontStyle.Bold);
            this.label5.Location = new System.Drawing.Point(1348, 9);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(542, 15);
            this.label5.TabIndex = 100;
            this.label5.Text = "장비 전체를 포함한 시간을 나타냅니다. 데이터는 24시간 기준 8초에 한 번씩 쌓인 스택 수치입니다.";
            // 
            // chart_Month
            // 
            chartArea3.Name = "ChartArea1";
            this.chart_Month.ChartAreas.Add(chartArea3);
            legendItem5.Color = System.Drawing.Color.Lime;
            legendItem5.Name = "Operation";
            legendItem6.Color = System.Drawing.Color.DarkOrange;
            legendItem6.Name = "Unoperation";
            legend3.CustomItems.Add(legendItem5);
            legend3.CustomItems.Add(legendItem6);
            legend3.Name = "Legend1";
            this.chart_Month.Legends.Add(legend3);
            this.chart_Month.Location = new System.Drawing.Point(26, 42);
            this.chart_Month.Name = "chart_Month";
            series4.BorderWidth = 50;
            series4.ChartArea = "ChartArea1";
            series4.Color = System.Drawing.Color.Lime;
            series4.CustomProperties = "DrawingStyle=Cylinder";
            series4.IsVisibleInLegend = false;
            series4.Legend = "Legend1";
            series4.Name = "Operation";
            series5.BorderWidth = 15;
            series5.ChartArea = "ChartArea1";
            series5.Color = System.Drawing.Color.DarkOrange;
            series5.CustomProperties = "DrawingStyle=Cylinder";
            series5.IsVisibleInLegend = false;
            series5.Legend = "Legend1";
            series5.Name = "Unoperation";
            this.chart_Month.Series.Add(series4);
            this.chart_Month.Series.Add(series5);
            this.chart_Month.Size = new System.Drawing.Size(1182, 521);
            this.chart_Month.TabIndex = 101;
            this.chart_Month.Text = "chart1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label1.Location = new System.Drawing.Point(34, 570);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(219, 30);
            this.label1.TabIndex = 200;
            this.label1.Text = "※ 기간별 누적 가동률";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label2.Location = new System.Drawing.Point(22, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(231, 30);
            this.label2.TabIndex = 201;
            this.label2.Text = "※ 기간별 가동률(30일)";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("맑은 고딕", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.label3.Location = new System.Drawing.Point(1202, 28);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(219, 30);
            this.label3.TabIndex = 200;
            this.label3.Text = "※ 기간별 가동률 조회";
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel2.Location = new System.Drawing.Point(1207, 110);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(690, 1);
            this.panel2.TabIndex = 218;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.SystemColors.InfoText;
            this.panel3.Location = new System.Drawing.Point(1208, 67);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(690, 1);
            this.panel3.TabIndex = 217;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.SystemColors.Control;
            this.label8.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label8.Location = new System.Drawing.Point(1211, 66);
            this.label8.Name = "label8";
            this.label8.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label8.Size = new System.Drawing.Size(124, 44);
            this.label8.TabIndex = 215;
            this.label8.Text = "시작 날짜";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.SystemColors.Control;
            this.label9.Font = new System.Drawing.Font("맑은 고딕", 11F);
            this.label9.Location = new System.Drawing.Point(1497, 66);
            this.label9.Name = "label9";
            this.label9.Padding = new System.Windows.Forms.Padding(25, 12, 25, 12);
            this.label9.Size = new System.Drawing.Size(124, 44);
            this.label9.TabIndex = 222;
            this.label9.Text = "종료 날짜";
            // 
            // Operating_Rate_by_Period
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(1910, 956);
            this.Controls.Add(this.Chart_Period);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.btn_Chart);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.Dtp_End);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.Dtp_Start);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chart_Month);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.dgv_Daily);
            this.Controls.Add(this.dgv_Count);
            this.Controls.Add(this.Chart_Count);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(1208, 67);
            this.Name = "Operating_Rate_by_Period";
            this.Text = "TimeOperationRate";
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Daily)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_Count)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.Chart_Period)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart_Month)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Count;
        private System.Windows.Forms.DataGridView dgv_Daily;
        private System.Windows.Forms.DataGridView dgv_Count;
        private System.Windows.Forms.DataVisualization.Charting.Chart Chart_Period;
        private System.Windows.Forms.Button btn_Chart;
        private System.Windows.Forms.DateTimePicker Dtp_End;
        private System.Windows.Forms.DateTimePicker Dtp_Start;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart_Month;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
    }
}