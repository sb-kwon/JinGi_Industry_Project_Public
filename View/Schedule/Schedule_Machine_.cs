using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Calendar.NET;

namespace View
{
    public partial class Schedule_Machine : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private MachineC _MachineCtrl;
        private ProcessC _ProcessC;
        private List<String[]> ViewList;
        private int cnt = 0, randomnum, diffDay;
        private string OrderName, MachineName, SDate, EDate;
        private bool check;
        public Schedule_Machine(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;
            _ProcessC = new ProcessC();
            _MachineCtrl = new MachineC();

            InitializeComponent();
            LoadData();
        }
        private void LoadData()
        {
            GetMachineNameData();
            //GetMachineType();
            ViewReset();
        }
        private void GetMachineNameData()
        {
            ViewList = _ProcessC.GetMachineNameData();
            SetProductListView();
        }
        private void SetProductListView()
        {
            dgv_machine.Rows.Clear();
            dgv_Product.Rows.Clear();
            dgv_machine.Visible = true;
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    dgv_machine.Rows.Add(array[0], array[1], array[2], SetProcessState(array[3]), array[4], array[5], array[6], array[7], array[8]);
                }
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
        private void dgv_product_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = dgv_machine.Rows[e.RowIndex];
            row.HeaderCell.Style.BackColor = Color.Gray;
            row.HeaderCell.Style.ForeColor = Color.Gray;
        }
        private void SetCalendar()
        {
            calendar1.ClearEvents();
            //foreach (string[] array in ViewList)
            //{
            ColorNum();

            SDate = lbl_Start.Text;
            EDate = lbl_End.Text;
            MachineName = lbl_Name.Text;
            OrderName = lbl_OrderName.Text;

            DateTime T1 = DateTime.Parse(SDate);
            DateTime T2 = DateTime.Parse(EDate);
            TimeSpan TS = T2 - T1;

            calendar1.CalendarDate = T1;
            diffDay = TS.Days;

            for (int i = 0; i < diffDay + 1; i++)
            {
                int startyear = Int32.Parse(T1.ToString().Substring(0, 4));
                int startmonth = Int32.Parse(T1.ToString().Substring(5, 2));
                int startday = Int32.Parse(T1.ToString().Substring(8, 2));
                var groundhogEvent = new CustomEvent()
                {
                    Date = new DateTime(startyear, startmonth, startday),
                    EventText = MachineName,
                    EventMessage = CreateMultiLineEventMessage(),
                    EventColor = Color.FromArgb(randomnum)
                };
                calendar1.AddEvent(groundhogEvent);

                T1 = T1.AddDays(+1);
            }
            //}
        }
        private string CreateMultiLineEventMessage()
        {
            StringBuilder LineMessage = new StringBuilder();
            LineMessage.AppendLine("장비명 : " + MachineName + "\n수주명 : " + OrderName + "\n일정 : " + SDate.Substring(0, 10) + " ~ " + EDate.Substring(0, 10));
            return LineMessage.ToString();
        }
        private void ColorNum()
        {
            Random random = new Random();
            randomnum = random.Next(256);
        }
        #region 검색 basicform
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            ViewReset();
            LoadData();
            ReFreshText();
        }
        public Form SetForm()
        {
            return this;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }
        private void dgv_machine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                label2.Text = "※ 작업중인 장비 상세보기";
                dgv_machine.Visible = false;
                DataGridView dgv = (DataGridView)sender;
                SetSelectedData(dgv.SelectedRows[0]);

                ViewList = _ProcessC.GetMachineBomData(_ProcessC.Machine);

                SetMachineDetailListView();
            }
        }
        private void SetSelectedData(DataGridViewRow dgvr)
        {
            Machine _mac = new Machine();

            _mac.MachineNo = Convert.ToInt32(dgvr.Cells[0].Value.ToString());
            _mac.MachineName = lbl_Name.Text = dgvr.Cells[1].Value.ToString();
            _mac.MachineType = lbl_Type.Text = dgvr.Cells[2].Value.ToString();
            _mac.WorkProcess.WorkProcessStateName = lbl_State.Text = dgvr.Cells[3].Value.ToString();
            _mac.OrderName = lbl_OrderName.Text = dgvr.Cells[4].Value.ToString();
            _mac.MemberName = lbl_Member.Text = dgvr.Cells[5].Value.ToString();
            _mac.WorkProcessPlanStart = lbl_Start.Text = dgvr.Cells[6].Value.ToString();
            _mac.WorkProcessPlanEnd = lbl_End.Text = dgvr.Cells[7].Value.ToString();
            _mac.MachineETC = lbl_Memo.Text = dgvr.Cells[8].Value.ToString();

            _ProcessC.Machine = _mac;

            SetCalendar();
        }
        private void SetMachineDetailListView()
        {
            dgv_Product.Rows.Clear();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    dgv_Product.Rows.Add(array[0], array[1], array[2], array[3], array[4], array[5] + "개", array[6]);
                }
        }
        private void ClickCalendar()
        {
            foreach (string[] array in ViewList)
            {
                ColorNum();

                SDate = array[4].ToString();
                EDate = array[5].ToString();
                //ordername = array[1].ToString();
                //ProductName = array[2].ToString();

                DateTime T1 = DateTime.Parse(SDate);
                DateTime T2 = DateTime.Parse(EDate);
                TimeSpan TS = T2 - T1;

                diffDay = TS.Days;


                for (int i = 0; i < diffDay + 1; i++)
                {
                    int startyear = Int32.Parse(T1.ToString().Substring(0, 4));
                    int startmonth = Int32.Parse(T1.ToString().Substring(5, 2));
                    int startday = Int32.Parse(T1.ToString().Substring(8, 2));
                    var groundhogEvent = new CustomEvent()
                    {
                        Date = new DateTime(startyear, startmonth, startday),
                        EventText = array[1].ToString(),
                        EventMessage = CreateMultiLineEventMessage(),
                        EventColor = Color.FromArgb(randomnum)
                    };
                    calendar1.AddEvent(groundhogEvent);

                    T1 = T1.AddDays(+1);
                }
            }
        }

        private void Btn_All_Click(object sender, EventArgs e)
        {
            LoadData();
            ViewReset();
            ReFreshText();
        }
        private void ViewReset()
        {
            tb_MachineName.Text = "";
            Cb_Type.SelectedIndex = 0;

            dgv_machine.Visible = true;
            calendar1.ClearEvents();
            calendar1.CalendarDate = DateTime.Now;
        }
        private void ReFreshText()
        {
            lbl_RealStart.Text = "작업 예정일";
            lbl_RealEnd.Text = "종료 예정일";
            label2.Text = "※ 작업중인 장비 리스트";
            label4.Text = "※ 작업중인 장비 품목 리스트";
        }
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            if (Cb_Type.Text.Equals("진행중"))
            {
                lbl_RealStart.Text = "작업 예정일";
                lbl_RealEnd.Text = "종료 예정일";
                label2.Text = "※ 작업중인 장비 리스트";
                label4.Text = "※ 작업중인 장비 품목 리스트";
            }
            else
            {
                lbl_RealStart.Text = "작업 시작시간";
                lbl_RealEnd.Text = "작업 종료시간";
                label2.Text = "※ 장비 리스트";
                label4.Text = "※ 완료, 폐기된 품목 리스트";
            }

            dgv_machine.Visible = true;
            dgv_machine.Rows.Clear();
            dgv_Product.Rows.Clear();

            List<string[]> ViewList = _ProcessC.GetSearchMachineSchedule(Cb_Type.Text);
            if (ViewList != null)
                foreach (string[] str in ViewList)
                {
                    if ((str[1].IndexOf(tb_MachineName.Text) != -1) && Cb_Type.SelectedItem.Equals(SetProcessState(str[3])))
                    {
                        dgv_machine.Rows.Add(str[0], str[1], str[2], SetProcessState(str[3]), str[4], str[5], str[6], str[7], str[8]);
                    }
                }
            ViewReset();
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
    }
}
