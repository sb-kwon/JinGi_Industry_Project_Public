using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeekPlanner;

namespace View
{
    public partial class Machine_Schedule : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private ProcessC _ProcessC;

        private int _DayCnt;
        private int[] _DayArray;
        private int _DayArrayCnt;

        public Machine_Schedule(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;
            _ProcessC = new ProcessC();

            _DayCnt = 0;
            _DayArray = new int[] { 1, 5, 10, 30 };
            _DayArrayCnt = 0;

            InitializeComponent();

            button5_Click(null, null);
            calendarPlanner1.DayCount = 20;
            calendarPlanner1.Columns.Add("장비명", "장비명", 100);
            calendarPlanner1.Columns.Add("상태", "상태", 100);
            calendarPlanner1.CurrentDate = DateTime.Now;

            comboBox7.SelectedIndex = 0;
            WeekplannerOpen();
        }

        private String SetProcessState(string state)
        {
            string str = "";

            if (state == "0") str = "작업 전";
            if (state == "1") str = "작업 중";
            if (state == "2") str = "폐기";
            if (state == "3") str = "일시중지";
            if (state == "4") str = "중지";
            if (state == "5") str = "작업완료";

            return str;
        }
        private void WeekplannerOpen()
        {
            datagridview1.Rows.Clear();
            List<string[]> orderList = _ProcessC.GetMachineNameData();
            if (orderList != null)
            {
                foreach (string[] os in orderList)
                {
                    if (os[5].Equals("")) os[5] = DateTime.Now.ToString();
                    if (os[6].Equals("")) os[6] = DateTime.Now.ToString();
                    if (os[7].Equals("")) os[7] = DateTime.Now.ToString();
                    if (os[8].Equals("")) os[8] = DateTime.Now.ToString();

                    datagridview1.Rows.Add(
                        os[0],
                        SetProcessState(os[1]),
                        os[2],
                        os[3],
                        os[4],
                        os[5],
                        os[6],
                        os[7],
                        os[8]
                        );
                }
                SetWeekPlanner();
            }
        }
        #region 검색 basicform
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            FormStart();
        }
        public Form SetForm()
        {
            return this;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }
        private void FormStart()
        {
            WeekplannerOpen();
            comboBox7.SelectedIndex = 0;
            calendarPlanner1.CurrentDate = DateTime.Now;
            textBox1.Text = textBox2.Text = textBox3.Text = null;
            dtp_date.Value = dateTimePicker1.Value = DateTime.Now;
        }
        #endregion

        #region 검색 gridviewUI 지금 안씀
        //private void GetMachineType()
        //{
        //    List<String> Type = _MachineCtrl.Types;
        //    Cb_Type.Items.Clear();
        //
        //    foreach (String str in Type)
        //    {
        //        Cb_Type.Items.Add(str);
        //    }
        //    Cb_Type.SelectedIndex = 0;
        //}
        //private void SetDataGridView(DataGridView dgv)
        //{
        //
        //
        //    dgv.Font = new Font("맑은 고딕", 11, FontStyle.Regular);
        //
        //    dgv.EnableHeadersVisualStyles = false;
        //    dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 72, 81);
        //    dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
        //    dgv.RowHeadersDefaultCellStyle.BackColor = Color.SeaGreen;
        //
        //    dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        //    dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
        //
        //    dgv.CurrentCell = null;
        //
        //    dgv.BackgroundColor = SystemColors.GradientInactiveCaption;
        //
        //
        //    dgv.ReadOnly = true;
        //    dgv.RowHeadersVisible = false;
        //    dgv.MultiSelect = false;
        //    dgv.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f =>
        //    {
        //        f.SortMode = DataGridViewColumnSortMode.NotSortable;
        //        f.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //        f.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
        //    });
        //    dgv.Rows.Cast<DataGridViewRow>().Where((x, i) => i % 2 != 0).ToList().ForEach(r => r.DefaultCellStyle.BackColor = Color.AliceBlue);
        //    dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        //    dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        //}
        #endregion

        #region 검색 그리드뷰 병합 지금 안쓸거임
        //private void Form4_Load(object sender, EventArgs e)
        //{
        //    dgv_machine.AutoGenerateColumns = false;
        //}
        //
        //bool IsTheSameCellValue(int column, int row)
        //{
        //    check = false;
        //    DataGridViewCell cell1 = dgv_machine[column, row];
        //    DataGridViewCell cell2 = dgv_machine[column, row - 1];
        //    if (cell1.Value == null || cell2.Value == null)
        //    {
        //        return false;
        //    }
        //    if ((cell1.Value.ToString() == cell2.Value.ToString()) && column != 5 && column != 6)
        //        return true;
        //    else
        //        return false;
        //}
        //
        //private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        //{
        //
        //}
        //
        //private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //
        //}
        #endregion        
        private void button5_Click(object sender, EventArgs e)
        {
            SetDayArray();
            button5.Text = _DayArray[_DayArrayCnt].ToString();
        }
        private void SetDayArray()
        {
            _DayArrayCnt++;

            if (_DayArrayCnt >= 4)
            {
                _DayArrayCnt = 0;
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            dtp_date.Enabled = checkBox1.Checked;
        }

        private void btn_all_Click(object sender, EventArgs e)
        {
            WeekplannerOpen();
        }
        private void SetWeekPlanner()
        {
            calendarPlanner1.Rows.Clear();

            string str = "";
            if (datagridview1.Rows.Count == 0) return;

            DataGridViewRow last = datagridview1.Rows[datagridview1.Rows.Count - 1];

            List<DataGridViewRow> list = new List<DataGridViewRow>();

            foreach (DataGridViewRow dgbr in datagridview1.Rows)
            {
                if (dgbr.Cells[0].Value.ToString().Equals(str)) // 동일한 장비 이면
                    list.Add(dgbr);
                else // 다른 장비 이면
                {
                    if (!str.Equals("") && list.Count != 0)
                    {
                        var itemCollectionP = new WeekPlannerItemCollection();
                        var itemCollectionW = new WeekPlannerItemCollection();
                        var ColumnRowsP = new DataColumns(calendarPlanner1.Calendar);
                        var ColumnRowsW = new DataColumns(calendarPlanner1.Calendar);

                        ColumnRowsP["장비명"].Data.Add(list[0].Cells[0].Value.ToString());
                        ColumnRowsP["상태"].Data.Add("계획");

                        ColumnRowsW["장비명"].Data.Add(list[0].Cells[0].Value.ToString());
                        ColumnRowsW["상태"].Data.Add("현황");


                        List<WeekPlannerItem> Planitems = new List<WeekPlannerItem>();
                        List<WeekPlannerItem> Workitems = new List<WeekPlannerItem>();
                        foreach (DataGridViewRow dgvr in list)
                        {
                            WeekPlannerItem itemP = new WeekPlannerItem();
                            WeekPlannerItem itemW = new WeekPlannerItem();

                            itemP.StartDate = DateTime.Parse(dgvr.Cells[5].Value.ToString()).AddDays(0);
                            itemP.EndDate = DateTime.Parse(dgvr.Cells[6].Value.ToString()).AddDays(0);
                            itemW.StartDate = DateTime.Parse(dgvr.Cells[7].Value.ToString()).AddDays(0);
                            itemW.EndDate = DateTime.Parse(dgvr.Cells[8].Value.ToString()).AddDays(0);

                            itemP.BackColor = Color.LightGreen;
                            itemW.BackColor = Color.LightBlue;

                            itemP.Subject = dgvr.Cells[2].Value.ToString() + dgvr.Cells[3].Value.ToString();
                            itemW.Subject = dgvr.Cells[2].Value.ToString() + dgvr.Cells[3].Value.ToString();

                            Planitems.Add(itemP);
                            Workitems.Add(itemW);
                        }

                        itemCollectionP.Adds(Planitems);
                        itemCollectionW.Adds(Workitems);

                        list = new List<DataGridViewRow>();

                        calendarPlanner1.Rows.Add(ColumnRowsP, itemCollectionP);
                        calendarPlanner1.Rows.Add(ColumnRowsW, itemCollectionW);

                        list.Add(dgbr);
                    }
                    else list.Add(dgbr);


                }
                if (last.Equals(dgbr))
                {
                    var itemCollectionP = new WeekPlannerItemCollection();
                    var itemCollectionW = new WeekPlannerItemCollection();
                    var ColumnRowsP = new DataColumns(calendarPlanner1.Calendar);
                    var ColumnRowsW = new DataColumns(calendarPlanner1.Calendar);

                    ColumnRowsP["장비명"].Data.Add(list[0].Cells[0].Value.ToString());
                    ColumnRowsP["상태"].Data.Add("계획");

                    ColumnRowsW["장비명"].Data.Add(list[0].Cells[0].Value.ToString());
                    ColumnRowsW["상태"].Data.Add("현황");


                    List<WeekPlannerItem> Planitems = new List<WeekPlannerItem>();
                    List<WeekPlannerItem> Workitems = new List<WeekPlannerItem>();
                    foreach (DataGridViewRow dgvr in list)
                    {
                        WeekPlannerItem itemP = new WeekPlannerItem();
                        WeekPlannerItem itemW = new WeekPlannerItem();

                        itemP.StartDate = DateTime.Parse(dgvr.Cells[5].Value.ToString()).AddDays(0);
                        itemP.EndDate = DateTime.Parse(dgvr.Cells[6].Value.ToString()).AddDays(0);
                        itemW.StartDate = DateTime.Parse(dgvr.Cells[7].Value.ToString()).AddDays(0);
                        itemW.EndDate = DateTime.Parse(dgvr.Cells[8].Value.ToString()).AddDays(0);

                        itemP.BackColor = Color.LightGreen;
                        itemW.BackColor = Color.LightBlue;

                        itemP.Subject = dgvr.Cells[2].Value.ToString() + dgvr.Cells[3].Value.ToString();
                        itemW.Subject = dgvr.Cells[2].Value.ToString() + dgvr.Cells[3].Value.ToString();

                        Planitems.Add(itemP);
                        Workitems.Add(itemW);
                    }
                    itemCollectionP.Adds(Planitems);
                    itemCollectionW.Adds(Workitems);

                    list = new List<DataGridViewRow>();

                    calendarPlanner1.Rows.Add(ColumnRowsP, itemCollectionP);
                    calendarPlanner1.Rows.Add(ColumnRowsW, itemCollectionW);

                }
                str = dgbr.Cells[0].Value.ToString();
            }
        }
        private void button4_Click(object sender, EventArgs e)
        {
            if (calendarPlanner1.Rows.Count != 0)
            {
                _DayCnt = _DayCnt - _DayArray[_DayArrayCnt];
                calendarPlanner1.CurrentDate = DateTime.Now.AddDays(_DayCnt);

                dateTimePicker1.Value = calendarPlanner1.CurrentDate;
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (calendarPlanner1.Rows.Count != 0)
            {
                _DayCnt = _DayCnt + _DayArray[_DayArrayCnt];
                calendarPlanner1.CurrentDate = DateTime.Now.AddDays(_DayCnt);

                dateTimePicker1.Value = calendarPlanner1.CurrentDate;
            }
        }
        private void button6_Click(object sender, EventArgs e)
        {
            calendarPlanner1.CurrentDate = dateTimePicker1.Value;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            datagridview1.Rows.Clear();
            List<string[]> orderList = _ProcessC.GetMachineNameData();
            if (orderList != null)
            {
                foreach (string[] os in orderList)
                {
                    if (os[5].Equals("")) os[5] = DateTime.Now.ToString();
                    if (os[6].Equals("")) os[6] = DateTime.Now.ToString();
                    if (os[7].Equals("")) os[7] = DateTime.Now.ToString();
                    if (os[8].Equals("")) os[8] = DateTime.Now.ToString();

                    DateTime datevalue = dtp_date.Value;
                    datevalue = Convert.ToDateTime(datevalue.ToString("yyyy-MM-dd"));

                    if ((comboBox7.SelectedItem.Equals("모두") || comboBox7.SelectedItem.Equals(SetProcessState(os[1])))
                    && (!dtp_date.Enabled
                        || (datevalue >= Convert.ToDateTime(os[5].Substring(0, 10)) && datevalue <= Convert.ToDateTime(os[6].Substring(0, 10)))
                        || (datevalue >= Convert.ToDateTime(os[7].Substring(0, 10)) && datevalue <= Convert.ToDateTime(os[8].Substring(0, 10))))
                        && os[2].IndexOf(textBox2.Text) != -1 && os[3].IndexOf(textBox1.Text) != -1 && os[4].IndexOf(textBox3.Text) != -1)
                    {
                        datagridview1.Rows.Add(
                        os[0],
                        SetProcessState(os[1]),
                        os[2],
                        os[3],
                        os[4],
                        os[5],
                        os[6],
                        os[7],
                        os[8]
                        );
                    }
                }
                SetWeekPlanner();
            }
        }
    }
}