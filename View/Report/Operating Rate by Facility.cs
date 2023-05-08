using Controller;
using Model;
using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace View
{
    public partial class Operating_Rate_by_Facility : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private List<Machine> _LM;
        private List<Operating_Rate> _OR;
        public String MachineName, CbText;
        private MachineC _MachineCtrl;
        public Operating_Rate_by_Facility(Member member, BasicForm form)
        {
            InitializeComponent();

            _LoginInfo = member;
            _Mother = form;
            _MachineCtrl = new MachineC();

            //SetComboBox();
            DefaultDay();
            cb_Machine.SelectedIndex = 0;
        }
        public Form SetForm()
        {
            return this;
        }
        public string GetText()
        {
            return this.Text;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            if (this.Text.Equals(seletedPageName) || check)
            {
                SetInvoke();
            }
        }
        public void RefreshForm()
        {
            //SetComboBox();
            DefaultDay();
            SetInvoke();
            cb_Machine.SelectedIndex = 0;
        }
        public List<Machine> Machines
        {
            get { return _LM; }
            set { _LM = value; }
        }
        public List<Operating_Rate> Facilities
        {
            get { return _OR; }
            set { _OR = value; }
        }
        private void GetComboBox()
        {
            _MachineCtrl.GetComboBox();
            Machines = _MachineCtrl.Machine;
        }
        private void GetDataGridView(string MachineName)
        {
            _MachineCtrl.GetDataGridView(MachineName);
            Facilities = _MachineCtrl.Facility;
        }
        private void SetComboBox()
        {
            GetComboBox();
            
            foreach (Machine machine in Machines)
            {
                cb_Machine.Items.Add(machine.MachineName);
            }
            if (cb_Machine.Items.Count != -1)
            {
                cb_Machine.SelectedIndex = 0;
            }
            Dtp_Start.Value = DateTime.Now;
            Dtp_End.Value = DateTime.Now;
        }
        private void cb_Machine_SelectedIndexChanged(object sender, EventArgs e)
        {
            GetPicture();

            Chart_Period.Series["Select"].Points.Clear();
            btn_Chart.Enabled = true;
            DefaultDay();
            SetDataGridView();
            SetChart();
        }
        private void GetPicture()
        {
            if (cb_Machine.Text.Equals(pnl_11.Tag))
            {
                pnl_11.BringToFront();
            }
            if (cb_Machine.Text.Equals(pnl_12.Tag))
            {
                pnl_12.BringToFront();
            }
            else if (cb_Machine.Text.Equals(pnl_13.Tag))
            {
                pnl_13.BringToFront();
            }
            else if (cb_Machine.Text.Equals(pnl_14.Tag))
            {
                pnl_14.BringToFront();
            }
            else if (cb_Machine.Text.Equals(pnl_15.Tag))
            {
                pnl_15.BringToFront();
            }
            else if (cb_Machine.Text.Equals(pnl_16.Tag))
            {
                pnl_16.BringToFront();
            }
            else if (cb_Machine.Text.Equals(pnl_17.Tag))
            {
                pnl_17.BringToFront();
            }
        }
        private void SetInvoke()
        {
            if (this.InvokeRequired)
            {
                // 작업쓰레드인 경우
                this.BeginInvoke(new Action(() =>
                {
                    SetDataGridView();
                    SetChart();
                }));
            }
            else
            {
                SetDataGridView();
                SetChart();
            }
        }
        private void SetChart()
        {
            List<String> Names = new List<String> { "Operation", "Unoperation" };

            chart_Month.Series.Clear();
            Chart_Count.Series.Clear();

            for (int i = 0; i < 2; i++)
            {
                Series S = chart_Month.Series.Add(Names[i]);
                S.ChartType = SeriesChartType.Column;
                S.CustomProperties = "DrawingStyle = Cylinder, PointWidth = 1.0";

                Series S2 = Chart_Count.Series.Add(Names[i]);
                S2.ChartType = SeriesChartType.Line;
                S2.BorderWidth = 2;
            }
            foreach (DataGridViewRow row in dgv_Daily.Rows)
            {
                for (int i = 1; i <= 2; i++)
                {
                    double time = (Convert.ToDouble(row.Cells[i].Value) * 16) / 3600;
                    chart_Month.Series[dgv_Daily.Columns[i].HeaderCell.Value.ToString()].Points.AddXY(row.Cells[0].Value.ToString(), string.Format("{0:0.#}", time));
                    chart_Month.Series[0].IsVisibleInLegend = false;
                    chart_Month.Series[1].IsVisibleInLegend = false;
                }
            }
            foreach (DataGridViewRow row in dgv_Count.Rows)
            {
                for (int i = 1; i <= 2; i++)
                {
                    Chart_Count.Series[dgv_Count.Columns[i].HeaderCell.Value.ToString()].Points.AddXY(row.Cells[0].Value.ToString(), row.Cells[i].Value.ToString());
                    Chart_Count.Series[0].IsVisibleInLegend = false;
                    Chart_Count.Series[1].IsVisibleInLegend = false;
                }
            }
            ColorChart();
        }
        private void ColorChart()
        {
            string seriesname = "Operation";
            string SeriesName = "Unoperation";

            Chart_Count.Series[0].MarkerStyle = Chart_Count.Series[1].MarkerStyle = MarkerStyle.Circle;
            Chart_Count.Series[0].MarkerSize = Chart_Count.Series[1].MarkerSize = 5;
            Chart_Count.Series[0].MarkerColor = Color.Lime;
            Chart_Count.Series[1].MarkerColor = Color.DarkOrange;

            int cnt = 0;
            foreach (DataGridViewRow dgvr in dgv_Count.Rows)
            {
                string pointcolor = dgv_Count.Columns[1].HeaderText;

                switch (pointcolor)
                {
                    case "Operation":
                        chart_Month.Series[seriesname].Points[cnt].Color = Color.Lime;
                        Chart_Count.Series[seriesname].Points[cnt].Color = Color.Lime;
                        break;
                }
                cnt++;
            }
            int Cnt = 0;
            foreach (DataGridViewRow dgv in dgv_Count.Rows)
            {
                string PointColor = dgv_Count.Columns[2].HeaderText;

                switch (PointColor)
                {
                    case "Unoperation":
                        chart_Month.Series[SeriesName].Points[Cnt].Color = Color.DarkOrange;
                        Chart_Count.Series[SeriesName].Points[Cnt].Color = Color.DarkOrange;
                        break;
                }
                Cnt++;
            }
        }
        private void SetDataGridView()
        {
            int days = -30;

            dgv_Daily.Rows.Clear();
            dgv_Count.Rows.Clear();
            while (days != 1)
            {
                string date = DateTime.Now.AddDays(days).ToShortDateString();
                dgv_Daily.Rows.Add(date);
                days++;
            }
            MachineName = cb_Machine.Text;
            GetDataGridView(MachineName);
            foreach (DataGridViewRow dgvr in dgv_Daily.Rows)
            {
                for (int i = 0; i < dgvr.Cells.Count; i++)
                {
                    if (dgvr.Cells[i].Value is null)
                    {
                        dgvr.Cells[i].Value = 0;
                    }
                }
            }
            foreach (Operating_Rate Facility in Facilities)
            {
                foreach (DataGridViewRow dgvr in dgv_Daily.Rows)
                {
                    if (dgvr.Cells[0].Value.ToString().Equals(Facility.Day.Substring(0, 10)))
                    {
                        string str = "";
                        if (Facility.MachineValue.Equals("Operation"))
                        {
                            str = "Operation";
                            dgvr.Cells[1].Value = Convert.ToInt32(dgvr.Cells[1].Value) + Facility.Count;
                        }
                        else if (Facility.MachineValue.Equals("Unoperation"))
                        {
                            str = "Unoperation";
                            dgvr.Cells[2].Value = Convert.ToInt32(dgvr.Cells[2].Value) + Facility.Count;
                        }
                    }
                }
            }
            SetDataGridViewSum();
        }
        private void SetDataGridViewSum()
        {
            int Sum_1 = 0;
            int Sum_2 = 0;

            foreach (DataGridViewRow dgvr in dgv_Daily.Rows)
            {
                Sum_1 = Convert.ToInt32(dgvr.Cells[1].Value) + Sum_1;
                Sum_2 = Convert.ToInt32(dgvr.Cells[2].Value) + Sum_2;

                dgv_Count.Rows.Add(dgvr.Cells[0].Value.ToString(), Sum_1, Sum_2);
            }
        }
        private void SetDGVChart()
        {
            DateTime Date_1 = Convert.ToDateTime(Dtp_End.Value);
            DateTime Date_2 = Convert.ToDateTime(Dtp_Start.Value);

            int Day = (Date_1 - Date_2).Days;
            int Plus = 0;
            dgv_Count.Rows.Clear();
            dgv_Daily.Rows.Clear();
            while (Plus != Day + 1)
            {
                DateTime Date = Date_2;
                string DGVDate = Date.AddDays(Plus).ToShortDateString();
                dgv_Daily.Rows.Add(DGVDate, 0, 0);
                Plus++;
            }
            MachineName = cb_Machine.Text;
            List<Operating_Rate> operating_Rates = _MachineCtrl.GetSearchDataGrid(Dtp_Start.Value, Dtp_End.Value, CbText);
            foreach (DataGridViewRow dgvr in dgv_Daily.Rows)
            {
                for (int i = 0; i < dgvr.Cells.Count; i++)
                {
                    if (dgvr.Cells[i].Value is null)
                    {
                        dgvr.Cells[i].Value = 0;
                    }
                }
            }
            foreach (Operating_Rate Facility in operating_Rates)
            {
                foreach (DataGridViewRow dgvr in dgv_Daily.Rows)
                {
                    if (dgvr.Cells[0].Value.ToString().Equals(Facility.Day.Substring(0, 10)))
                    {
                        string str = "";
                        if (Facility.MachineValue.Equals("Operation"))
                        {
                            str = "Operation";
                            dgvr.Cells[1].Value = Convert.ToInt32(dgvr.Cells[1].Value) + Facility.Count;
                        }
                        else if (Facility.MachineValue.Equals("Unoperation"))
                        {
                            str = "Unoperation";
                            dgvr.Cells[2].Value = Convert.ToInt32(dgvr.Cells[2].Value) + Facility.Count;
                        }
                    }
                }
            }
            SetDataGridViewSum();
            SetChart();
        }
        private void DefaultDay()
        {
            CbText = cb_Machine.Text;
            String[] list = _MachineCtrl.GetSelectDayData(DateTime.Today.AddDays(-1), DateTime.Today.AddDays(-1), CbText);

            Chart_Period.Series["Select"].Points.Clear();
            Chart_Period.Series["Select"].ChartType = SeriesChartType.Doughnut;

            foreach (string result in list)
            {
                Chart_Period.Series["Select"].Points.AddXY(result, Convert.ToDouble(result));
                Chart_Period.Series["Select"].Points[0].LegendText = "Operation";
            }
            Chart_Period.Series[0].Points[0].Color = Color.Lime;
            Chart_Period.Series[0].Points[1].Color = Color.DarkOrange;
        }
        private void btn_Chart_Click(object sender, EventArgs e)
        {
            DateTime Start = DateTime.Parse(Dtp_Start.Text);
            DateTime End = DateTime.Parse(Dtp_End.Text);
            int TimeResult = DateTime.Compare(Start, End);

            if (TimeResult > 0)
            {
                Alarm("종료 날짜가 시작 날짜보다 이전일 수 없습니다.");
            }
            else
            CbText = cb_Machine.Text;
            string[] list = _MachineCtrl.GetSelectDayData(Dtp_Start.Value, Dtp_End.Value, CbText);
            SetDGVChart();
            Chart_Period.Series["Select"].Points.Clear();
            Chart_Period.Series["Select"].ChartType = SeriesChartType.Doughnut;

            foreach (string result in list)
            {
                Chart_Period.Series["Select"].Points.AddXY(result, Convert.ToDouble(result));
                Chart_Period.Series["Select"].Points[0].LegendText = "Operation";
            }
            Chart_Period.Series[0].Points[0].Color = Color.Lime;
            Chart_Period.Series[0].Points[1].Color = Color.DarkOrange;
        }
        private void Alarm(String str)
        {
            Alarm Alarm = new Alarm(str);
            Alarm.ShowDialog();
        }
    }
}