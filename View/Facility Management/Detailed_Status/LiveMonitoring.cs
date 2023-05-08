using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class LiveMonitoring : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private Boolean _NoticeCheck;
        private MachineC _MachineCtrl;
        private NoticeCtrl _NoticeCtrl;
        private List<LiveMonitor> _Live;
        private List<LiveMonitor> _Error;
        private List<LiveMonitor> _AllError;
        private PrivateFontCollection _Font;
        String[] _MachineName = { "TruLaser3030", "TruLaser3030-2", "CNC-1500", "CNC-3000", "CNC-5170" };

        public LiveMonitoring(Member member, BasicForm form)
        {
            InitializeComponent();
            _NoticeCtrl = new NoticeCtrl();
            _MachineCtrl = new MachineC();
            _LoginInfo = member;
            _Mother = form;
            _Font = new PrivateFontCollection();

            SetError();
        }
        public List<LiveMonitor> LiveMonitors
        {
            get { return _Live; }
            set { _Live = value; }
        }
        public List<LiveMonitor> Errors
        {
            get { return _Error; }
            set { _Error = value; }
        }
        public List<LiveMonitor> AllError
        {
            get { return _AllError; }
            set { _AllError = value; }
        }
        private void GetMonitor()
        {
            _MachineCtrl.GetMonitor();
            LiveMonitors = _MachineCtrl.Live;
        }
        private void GetError()
        {
            _MachineCtrl.GetError();
            Errors = _MachineCtrl.Error;
        }
        private void GetAllError()
        {
            _MachineCtrl.GetAllError();
            AllError = _MachineCtrl.AllError;
        }
        private void LiveMonitoring_Load(object sender, EventArgs e)
        {
            Clock.Interval = 100;
            Clock.Enabled = true;
            Clock.Tick += Clock_Tick;

            SetInvoke();
            SetLiveState();
            Label();
        }
        #region IBasicForm
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            SetText();
            SetError();
            SetInvoke();
            SetLiveState();
        }
        public Form SetForm()
        {
            return this;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            if (this.Text.Equals(seletedPageName) || check)
            {
                SetInvoke();
                SetLiveState();
            }
        }
        #endregion
        #region Invoke
        private void SetInvoke()
        {
            if (this.InvokeRequired)
            {
                this.BeginInvoke(new Action(() =>
                {
                    SetDataGridView();
                }));
            }
            else
            {
                SetDataGridView();
            }
        }
        private void SetLiveState()
        {
            List<LiveMonitor> list = _MachineCtrl.GetLastStateData();

            if (list is null)
            {
            }
            else
            {
                if (this.InvokeRequired)
                {
                    // 작업쓰레드인 경우
                    this.BeginInvoke(new Action(() =>
                    {
                        DataPnlSet(list);
                    }));
                }
                else
                {
                    DataPnlSet(list);
                }
            }
        }
        private void SetError()
        {
            dgv_AllError.Rows.Clear();
            GetAllError();

            if (AllError != null)
            {
                foreach (LiveMonitor error in AllError)
                {
                    dgv_AllError.Rows.Add(error.MachineName, error.MachineValue, error.Count);
                }
                for (int i = 0; i < dgv_AllError.RowCount; i++)
                {
                    if (Convert.ToDouble(dgv_AllError.Rows[i].Cells[2].Value) >= 2)
                    {
                        _NoticeCheck = _NoticeCtrl.NoticeCheck(dgv_AllError.Rows[i].Cells[0].Value.ToString(), "2시간");
                        if (_NoticeCheck == true)
                        {
                            if (Convert.ToDouble(dgv_AllError.Rows[i].Cells[2].Value) >= 4)
                            {
                                _NoticeCheck = _NoticeCtrl.NoticeCheck(dgv_AllError.Rows[i].Cells[0].Value.ToString(), "4시간");
                                if (_NoticeCheck == true)
                                {
                                    ;
                                }
                                else
                                {
                                    if (MessageBox.Show(dgv_AllError.Rows[i].Cells[0].Value.ToString() + "장비 에러 시간이 4시간이 넘었습니다.", "장비 에러 팝업", MessageBoxButtons.YesNo) == DialogResult.Yes)
                                    {
                                        _NoticeCtrl.AddNoticeSys("시스템 에러", dgv_AllError.Rows[i].Cells[0].Value.ToString(), dgv_AllError.Rows[i].Cells[0].Value.ToString() + "장비 에러 시간이 4시간이 넘었습니다.");
                                    }
                                    else
                                    {
                                        ;
                                    }
                                }
                            }
                        }
                        else
                        {
                            if (MessageBox.Show(dgv_AllError.Rows[i].Cells[0].Value.ToString() + "장비 에러 시간이 2시간이 넘었습니다.", "장비 에러 팝업", MessageBoxButtons.YesNo) == DialogResult.Yes)
                            {
                                _NoticeCtrl.AddNoticeSys("시스템 에러", dgv_AllError.Rows[i].Cells[0].Value.ToString(), dgv_AllError.Rows[i].Cells[0].Value.ToString() + "장비 에러 시간이 2시간이 넘었습니다.");
                            }
                            else
                            {
                                ;
                            }
                        }
                    }
                }
            }
        }
        #endregion
        #region 검색 DGV
        private void SetDataGridView()
        {
            dgv_Count.Rows.Clear();
            dgv_Error.Rows.Clear();
            GetMonitor();
            GetError();

            string str = "";
            if (LiveMonitors != null)
            {
                foreach (LiveMonitor live in LiveMonitors)
                {
                    if (live.MachineValue.Equals("Operation")) str = "Operation";
                    else if (live.MachineValue.Equals("Unoperation")) str = "Unoperation";
                    else str = "";

                    dgv_Count.Rows.Add(live.MachineName, str, live.MachineValue, (((Convert.ToDouble(live.Count)) * 4) / 3600));
                }
            }
            if (Errors != null)
            {
                foreach (LiveMonitor error in Errors)
                {
                    if (error.MachineValue.Equals("Error")) str = "Error";
                    else str = "";

                    dgv_Error.Rows.Add(error.MachineName, str, error.MachineValue, error.Count);
                }
            }
            dgv_StateCount.Rows.Clear();
            dgv_PieChart.Rows.Clear();

            foreach (String i in _MachineName)
            {
                dgv_StateCount.Rows.Add(i, "Operation", 0);
                dgv_StateCount.Rows.Add(i, "Unoperation", 0);
                dgv_PieChart.Rows.Add(i, "Operation", 0);
                dgv_PieChart.Rows.Add(i, "Unoperation", 0);
            }
            foreach (DataGridViewRow row in dgv_Count.Rows)
            {
                foreach (DataGridViewRow row2 in dgv_StateCount.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(row2.Cells[0].Value.ToString()) && row.Cells[1].Value.ToString().Equals(row2.Cells[1].Value.ToString()))
                    {
                        row2.Cells[2].Value = Convert.ToDouble(row2.Cells[2].Value) + Convert.ToDouble(row.Cells[3].Value);
                    }
                }
            }
            foreach (DataGridViewRow rows in dgv_Error.Rows)
            {
                foreach (DataGridViewRow rows2 in dgv_StateCount.Rows)
                {
                    if (rows2.Cells[0].Value.ToString().Equals(rows.Cells[0].Value.ToString())
                        && rows2.Cells[1].Value.ToString().Equals("Operation"))
                    {
                        rows2.Cells[2].Value = Convert.ToDouble(rows2.Cells[2].Value) - Convert.ToDouble(rows.Cells[3].Value);
                    }
                }
            }
            MachinesChart();
            Label();
        }
        private void MachinesChart()
        {
            foreach (DataGridViewRow row in dgv_StateCount.Rows)
            {
                foreach (DataGridViewRow row2 in dgv_PieChart.Rows)
                {
                    if (row.Cells[0].Value.ToString().Equals(row2.Cells[0].Value.ToString()) && row.Cells[1].Value.ToString().Equals(row2.Cells[1].Value.ToString()))
                    {
                        row2.Cells[2].Value = Convert.ToDouble(row2.Cells[2].Value) + Convert.ToDouble(row.Cells[2].Value);
                    }
                }
            }
            foreach (DataGridViewRow dgvr in dgv_PieChart.Rows)
            {
                chart1.Series["Series1"].Points.Clear();
                chart2.Series["Series1"].Points.Clear();
                chart3.Series["Series1"].Points.Clear();
                chart4.Series["Series1"].Points.Clear();
                chart5.Series["Series1"].Points.Clear();
                //chart6.Series["Series1"].Points.Clear();
                //chart7.Series["Series1"].Points.Clear();
            }
            foreach (DataGridViewRow dgvr in dgv_PieChart.Rows)
            {
                if (dgvr.Cells[0].Value.ToString() == "TruLaser3030")
                    chart1.Series["Series1"].Points.AddXY(dgvr.Cells[0].Value.ToString(), dgvr.Cells[2].Value);
                else if (dgvr.Cells[0].Value.ToString() == "TruLaser3030-2")
                    chart2.Series["Series1"].Points.AddXY(dgvr.Cells[0].Value.ToString(), dgvr.Cells[2].Value);
                else if (dgvr.Cells[0].Value.ToString() == "CNC-1500")
                    chart3.Series["Series1"].Points.AddXY(dgvr.Cells[0].Value.ToString(), dgvr.Cells[2].Value);
                else if (dgvr.Cells[0].Value.ToString() == "CNC-3000")
                    chart4.Series["Series1"].Points.AddXY(dgvr.Cells[0].Value.ToString(), dgvr.Cells[2].Value);
                else if (dgvr.Cells[0].Value.ToString() == "CNC-5170")
                    chart5.Series["Series1"].Points.AddXY(dgvr.Cells[0].Value.ToString(), dgvr.Cells[2].Value);
                /*else if (dgvr.Cells[0].Value.ToString() == "MCT-21")
                    chart6.Series["Series1"].Points.AddXY(dgvr.Cells[0].Value.ToString(), dgvr.Cells[2].Value);
                else if (dgvr.Cells[0].Value.ToString() == "오면가공기")
                    chart7.Series["Series1"].Points.AddXY(dgvr.Cells[0].Value.ToString(), dgvr.Cells[2].Value);*/
            }
        }
        private void DataPnlSet(List<LiveMonitor> list)
        {
            foreach (LiveMonitor live in list)
            {
                for (int i = 0; i < this.pnl_State.Controls.Count; i++)
                {
                    if (!(pnl_State.Controls[i].Tag is null) && pnl_State.Controls[i].Tag.ToString().Equals(live.MachineName))
                    {
                        Panel panel = new Panel();
                        panel = (Panel)pnl_State.Controls[i];
                        List<Control> cons = new List<Control>();

                        foreach (Control ct in panel.Controls)
                        {
                            if (ct is Label || ct is System.Windows.Forms.DataVisualization.Charting.Chart)
                            {
                                cons.Add(ct);
                            }
                        }
                        foreach (Control ct in cons) panel.Controls.Remove(ct);

                        foreach (Panel pnl in panel.Controls)
                        {
                            pnl.BackColor = Color.Black;
                        }
                        for (int j = 0; j < panel.Controls.Count; j++)
                        {
                            Panel panel_chart = new Panel();

                            string str = "";
                            if (live.MachineValue.Equals("Operation")) str = "Operation";
                            else if (live.MachineValue.Equals("Unoperation")) str = "Unoperation";
                            else str = "";

                            if (panel.Controls[j].Tag.Equals(str))
                            {
                                if (str.Equals("Operation"))
                                {
                                    panel_chart = (Panel)panel.Controls[j];
                                    panel_chart.BackColor = Color.Lime;
                                }
                                else if (str.Equals("Unoperation"))
                                {
                                    panel_chart = (Panel)panel.Controls[j];
                                    panel_chart.BackColor = Color.DarkOrange;
                                }
                                break;
                            }
                        }
                        foreach (Control ct in cons) panel.Controls.Add(ct);
                        break;
                    }
                }
            }
        }
        #endregion
        private void Label()
        {
            DateTime start = Convert.ToDateTime(DateTime.Now.ToString("HH:mm:ss"));
            DateTime end = Convert.ToDateTime("09:00:00");
            TimeSpan timediff = start - end;

            lbl_O1.Text = lbl_O2.Text = lbl_O3.Text = lbl_O4.Text = lbl_O5.Text = timediff.ToString();
            lbl_Un1.Text = "00:06"; lbl_Un2.Text = "00:13"; lbl_Un3.Text = "00:10"; lbl_Un4.Text = "00:03"; lbl_Un5.Text = "00:03";
            lbl_Machine1.Text = lbl_MachineName_1.Text = dgv_StateCount.Rows[0].Cells[0].Value.ToString();
            //lbl_O1.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[0].Cells[2].Value) / 3600))).ToString();
            //lbl_Un1.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[1].Cells[2].Value) / 3600))).ToString();

            lbl_Machine2.Text = lbl_MachineName_2.Text = dgv_StateCount.Rows[2].Cells[0].Value.ToString();
            //lbl_O2.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[2].Cells[2].Value) / 3600))).ToString();
            //lbl_Un2.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[3].Cells[2].Value) / 3600))).ToString();

            lbl_Machine3.Text = lbl_MachineName_3.Text = dgv_StateCount.Rows[4].Cells[0].Value.ToString();
            //lbl_O3.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[4].Cells[2].Value) / 3600))).ToString();
            //lbl_Un3.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[5].Cells[2].Value) / 3600))).ToString();

            lbl_Machine4.Text = lbl_MachineName_4.Text = dgv_StateCount.Rows[6].Cells[0].Value.ToString();
            //lbl_O4.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[6].Cells[2].Value) / 3600))).ToString();
            //lbl_Un4.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[7].Cells[2].Value) / 3600))).ToString();

            lbl_Machine5.Text = lbl_MachineName_5.Text = dgv_StateCount.Rows[8].Cells[0].Value.ToString();
            //lbl_O5.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[8].Cells[2].Value) / 3600))).ToString();
            //lbl_Un5.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[9].Cells[2].Value) / 3600))).ToString();

/*            lbl_Machine6.Text = lbl_MachineName_6.Text = dgv_StateCount.Rows[10].Cells[0].Value.ToString();
            lbl_O6.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[10].Cells[2].Value) * 8) / 3600)).ToString();
            lbl_Un6.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[11].Cells[2].Value) * 8) / 3600)).ToString();

            lbl_Machine7.Text = lbl_MachineName_7.Text = dgv_StateCount.Rows[12].Cells[0].Value.ToString();
            lbl_O7.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[12].Cells[2].Value) * 8) / 3600)).ToString();
            lbl_Un7.Text = string.Format("{0:0.#}", ((Convert.ToDouble(dgv_StateCount.Rows[13].Cells[2].Value) * 8) / 3600)).ToString();*/

            chart1.Series[0].Points[0].Color = chart2.Series[0].Points[0].Color = chart3.Series[0].Points[0].Color = Color.Lime;
            chart1.Series[0].Points[1].Color = chart2.Series[0].Points[1].Color = chart3.Series[0].Points[1].Color = Color.DarkOrange;
            chart4.Series[0].Points[0].Color = chart5.Series[0].Points[0].Color = /*chart6.Series[0].Points[0].Color = chart7.Series[0].Points[0].Color =*/ Color.Lime;
            chart4.Series[0].Points[1].Color = chart5.Series[0].Points[1].Color = /*chart6.Series[0].Points[1].Color = chart7.Series[0].Points[1].Color =*/ Color.DarkOrange;
        }
        private void Clock_Tick(object sender, EventArgs e)
        {
            lbl_Time.Text = DateTime.Now.ToString("yyyy년" + "   " + "MM월" + "   " + "dd일" + "   " + "HH시" + "   " + "mm분" + "   " + "ss초");
            NewFont();
        }
        private void NewFont()
        {
            _Font.AddFontFile("DS-DIGI.TTF");

            Font font = new Font(_Font.Families[0], 50f);
            Font Font = new Font(_Font.Families[0], 23f);

            lbl_Time.Font = font;

            //lbl_Machine1.Font = lbl_Machine2.Font = lbl_Machine3.Font = lbl_Machine4.Font = lbl_Machine5.Font = lbl_Machine6.Font = lbl_Machine7.Font = Font;
            lbl_O1.Font = lbl_O2.Font = lbl_O3.Font = lbl_O4.Font = lbl_O5.Font = /*lbl_O6.Font = lbl_O7.Font =*/ Font;
            lbl_Un1.Font = lbl_Un2.Font = lbl_Un3.Font = lbl_Un4.Font = lbl_Un5.Font = /*lbl_Un6.Font = lbl_Un7.Font = */ Font;
        }
        private void btn_Save_Click(object sender, EventArgs e)
        {
            _MachineCtrl.InsertNon(cb_Machine.Text, cb_Detail.Text, tb_Memo.Text);
            SetText();
        }
        private void SetText()
        {
            cb_Machine.Text = null;
            cb_Detail.Text = null;
            tb_Memo.Text = null;
        }
    }
}