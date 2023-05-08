using System;
using System.Collections.Generic;
using System.Windows.Forms.DataVisualization.Charting;
using System.Windows.Forms;
using Controller;
using Model;
using System.Drawing;

namespace View
{
    public partial class DefectAnalysis : Form, IBasicForm
    {
        private Quality _QM;
        private Member _LoginInfo;
        private BasicForm _Mother;
        private ProcessC _ProcessCtrl;
        List<Quality> DefectCount, InnerData;
        String DTP_StartTimeText, DTP_EndTimeText;
        String[] RegistSearchValue = new string[4];
        public DefectAnalysis(Member member, BasicForm form)
        {
            InitializeComponent();
            _Mother = form;
            _LoginInfo = member;
            _QM = new Quality();
            _ProcessCtrl = new ProcessC();

            SetDataGridView();
        }
        #region 검색 IBasicForm
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            SetDataGridView();
            TextClear();
        }
        public Form SetForm()
        {
            return this;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }
        #endregion
        #region 검색 DGV
        private void GetInnerData()
        {
            InnerData = _ProcessCtrl.GetDefectSituation();
            DefectCount = _ProcessCtrl.GetDefectCount();
        }
        private void dgv_Defect_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedRows.Count != 0)
            {
                DataGridViewRow dgvr = dgv.SelectedRows[0];

                if (!(dgvr.Cells[0].Value is null))
                {
                    _QM.InnerOrder = dgvr.Cells[1].Value.ToString();
                    _QM.InnerProductName = dgvr.Cells[2].Value.ToString();
                    _QM.InstructionNo = dgvr.Cells[3].Value.ToString();
                    _QM.FairName = dgvr.Cells[4].Value.ToString();
                    _QM.InnerState = dgvr.Cells[5].Value.ToString();
                    _QM.MemberName = dgvr.Cells[6].Value.ToString();
                    _QM.Machine.MachineName = dgvr.Cells[7].Value.ToString();
                    _QM.InnerStartTime = dgvr.Cells[8].Value.ToString();
                    _QM.InnerEndTime = dgvr.Cells[9].Value.ToString();
                    _QM.InnerManager = dgvr.Cells[10].Value.ToString();
                    _QM.InnerCause = dgvr.Cells[11].Value.ToString();
                    _QM.InnerDeadline = dgvr.Cells[12].Value.ToString();
                    _QM.InnerActions = dgvr.Cells[13].Value.ToString();
                    _QM.InnerRemark = dgvr.Cells[14].Value.ToString();
                }
            }
            SelectDefectAnalysis SDA = new SelectDefectAnalysis(_QM);
            SDA.StartPosition = FormStartPosition.CenterParent;
            SDA.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            SDA.ShowDialog();
        }
        private void SetDataGridView()
        {
            int day = -30;

            dgv_Daily.Rows.Clear();
            while (day != 1)
            {
                string date = DateTime.Now.AddDays(day).ToShortDateString();
                dgv_Daily.Rows.Add(date, 0, 0);
                day++;
            }
            dgv_Defect.Rows.Clear();
            GetInnerData();

            foreach (Quality quality in InnerData)
            {
                dgv_Defect.Rows.Add(quality.WorkProcessNo, quality.InnerOrder, quality.InnerProductName, quality.InstructionNo, quality.FairName,
                                    quality.InnerState, quality.MemberName, quality.Machine.MachineName, quality.InnerStartTime, quality.InnerEndTime,
                                    quality.InnerManager, quality.InnerCause, quality.InnerDeadline, quality.InnerActions, quality.InnerRemark, quality.InnerErrorTime);
            }
            foreach (Quality quality in DefectCount)
            {
                lbl_Clear.Text = quality.ClearCount + "개";
                lbl_Defect.Text = quality.DefectCount + "개";
                lbl_Error.Text = quality.KPIDefectTotalAmount + "개";
            }
            SetDgvChart();
        }
        #endregion
        #region 검색 Chart
        private void SetDgvChart()
        {
            foreach (DataGridViewRow dgvr in dgv_Defect.Rows)
            {
                foreach (DataGridViewRow dgvr2 in dgv_Daily.Rows)
                {
                    if (dgvr.Cells[12].Value.ToString().Equals(dgvr2.Cells[0].Value.ToString()))
                    {
                        if (dgvr.Cells[5].Value.ToString().Equals("양호")) dgvr2.Cells[1].Value = Convert.ToInt32(dgvr2.Cells[1].Value) + 1;
                        else dgvr2.Cells[2].Value = Convert.ToInt32(dgvr2.Cells[2].Value) + 1;
                    }
                }
            }
            SetChart();
        }
        private void SetChart()
        {
            List<String> Names = new List<string> { "양호", "폐기" };

            chart_Month.Series.Clear();

            for (int i = 0; i < 2; i++)
            {
                Series S = chart_Month.Series.Add(Names[i]);
                S.ChartType = SeriesChartType.Column;
                S.CustomProperties = "DrawingStyle = Cylinder, PointWidth = 1.0";
            }
            foreach (DataGridViewRow rows in dgv_Daily.Rows)
            {
                for (int i = 1; i <= 2; i++)
                {
                    double time = (Convert.ToDouble(rows.Cells[i].Value));
                    chart_Month.Series[dgv_Daily.Columns[i].HeaderCell.Value.ToString()].Points.AddXY(rows.Cells[0].Value.ToString(), string.Format("{0:0.#}", time));
                    chart_Month.Series[0].Label = "#VALY";
                    chart_Month.Series[1].Label = "#VALY";
                    //if (chart_Month.Series[0].Label.Equals("0") || chart_Month.Series[1].Label.Equals("0"))
                    //{
                    //    chart_Month.Series[0].Label = "";
                    //    chart_Month.Series[1].Label = "";
                    //}
                    chart_Month.Series[0].IsVisibleInLegend = false;
                    chart_Month.Series[1].IsVisibleInLegend = false;
                }
            }
            ColorChart();
        }
        private void ColorChart()
        {
            string seriesname = "양호";
            string SeriesName = "폐기";

            int cnt = 0;
            foreach (DataGridViewRow dgvr in dgv_Daily.Rows)
            {
                string pointcolor = dgv_Daily.Columns[1].HeaderText;

                switch (pointcolor)
                {
                    case "양호":
                        chart_Month.Series[seriesname].Points[cnt].Color = Color.Lime;
                        break;
                }
                cnt++;
            }
            int Cnt = 0;
            foreach (DataGridViewRow dgv in dgv_Daily.Rows)
            {
                string PointColor = dgv_Daily.Columns[2].HeaderText;

                switch (PointColor)
                {
                    case "폐기":
                        chart_Month.Series[SeriesName].Points[Cnt].Color = Color.Red;
                        break;
                }
                Cnt++;
            }
        }
        #endregion
        #region 검색 Button
        private void btn_Search_Click(object sender, EventArgs e)
        {
            DateTime Start = DateTime.Parse(DTP_StartTime.Text);
            DateTime End = DateTime.Parse(DTP_EndTime.Text);
            int TimeResult = DateTime.Compare(Start, End);

            if (TimeResult > 0)
            {
                Alarm("종료 날짜가 시작 날짜보다 이전일 수 없습니다.");
            }
            else
            {
                SearchDefectData();

                DateTime Date_1 = Convert.ToDateTime(DTP_EndTimeText);
                DateTime Date_2 = Convert.ToDateTime(DTP_StartTimeText);

                int Day = (Date_1 - Date_2).Days;
                int Plus = 0;
                dgv_Daily.Rows.Clear();
                while (Plus != Day + 1)
                {
                    DateTime Date = DateTime.Parse(DTP_StartTimeText);
                    string DGVDate = Date.AddDays(Plus).ToShortDateString();
                    dgv_Daily.Rows.Add(DGVDate, 0, 0);
                    Plus++;
                }
                dgv_Defect.Rows.Clear();

                if (InnerData is null)
                {
                    Alarm("검색어를 입력해주세요.");
                }
                else
                {
                    if (InnerData.Count != 0)
                    {
                        foreach (Quality quality in InnerData)
                        {
                            dgv_Defect.Rows.Add(quality.WorkProcessNo, quality.InnerOrder, quality.InnerProductName, quality.InstructionNo, quality.FairName,
                                                quality.InnerState, quality.MemberName, quality.Machine.MachineName, quality.InnerStartTime, quality.InnerEndTime,
                                                quality.InnerManager, quality.InnerCause, quality.InnerDeadline, quality.InnerActions, quality.InnerRemark, quality.InnerErrorTime);
                        }
                        foreach (Quality quality in DefectCount)
                        {
                            lbl_Clear.Text = quality.ClearCount + " " + "개";
                            lbl_Defect.Text = quality.DefectCount + " " + "개";
                            lbl_Error.Text = quality.KPIDefectTotalAmount + "개";
                        }
                        SetDgvChart();
                    }
                    else
                    {
                        Alarm("검색 된 내용이 없습니다.");
                        SetDataGridView();
                        TextClear();
                    }
                }
            }
        }
        #endregion
        private void SearchDefectData()
        {
            DTP_StartTimeText = DTP_StartTime.Text;
            DTP_EndTimeText = DTP_EndTime.Text;

            RegistSearchValue[0] = DTP_StartTimeText;
            RegistSearchValue[1] = DTP_EndTimeText;

            InnerData = _ProcessCtrl.SearchSituationData(RegistSearchValue);
            DefectCount = _ProcessCtrl.GetDefectSearchCount(RegistSearchValue);
        }
        private void Alarm(String str)
        {
            Alarm Alarm = new Alarm(str);
            Alarm.ShowDialog();
        }
        private void TextClear()
        {
            DTP_StartTime.Text = "";
            DTP_EndTime.Text = "";
        }
    }
}