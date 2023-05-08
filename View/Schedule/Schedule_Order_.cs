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
    public partial class Schedule_Order : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private ProcessC _ProcessC;
        private List<String[]> ViewList;
        private int cnt = 0, randomnum, diffDay;
        private string customername, ordername, SDate, EDate;
        private bool check;
        public Schedule_Order(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;
            _ProcessC = new ProcessC();

            InitializeComponent();
            GetOrderData();
        }
        #region 검색 DGV
        private void GetScheduleOrder()
        {
            ViewList = _ProcessC.GetOrderDataSchedule();
        }
        private void GetOrderData()
        {
            ViewList = _ProcessC.GetOrderData();
            SetOrderListView();
            ViewReset();
        }
        private void SetOrderListView()
        {
            dgv_order.Rows.Clear();
            dgv_order.Visible = true;
            Cb_State.SelectedIndex = 0;
            dgv_order_detail.Rows.Clear();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    dgv_order.Rows.Add(array[0], array[1], SetOrderState(array[2]), array[5], array[6], array[3], array[4], array[7]);
                }
        }
        private void dgv_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex != -1)
            {
                label2.Text = "※ 진행중인 수주 상세보기";
                dgv_order.Visible = false;
                DataGridView dgv = (DataGridView)sender;
                SetSelectedData(dgv.SelectedRows[0]);

                ViewList = _ProcessC.GetBOMData(_ProcessC.WorkOrder);
                //GetScheduleOrder();
                SetOrderDetailListView();
            }
        }
        private void SetSelectedData(DataGridViewRow dgvr)
        {
            WorkOrder _wor = new WorkOrder();

            _wor.OrderNo = Convert.ToInt32(dgvr.Cells[0].Value);
            _wor.OrderName = lbl_Name.Text = dgvr.Cells[1].Value.ToString();
            _wor.OrderStateName = lbl_State.Text = dgvr.Cells[2].Value.ToString();
            _wor.CustomerName = lbl_Customer.Text = dgvr.Cells[3].Value.ToString();
            _wor.CustomerMemberName = lbl_Manager.Text = dgvr.Cells[4].Value.ToString();
            _wor.OrderDate = lbl_Start.Text = dgvr.Cells[5].Value.ToString();
            _wor.OrderDateEnd = lbl_End.Text = dgvr.Cells[6].Value.ToString();
            _wor.OrderMemo = lbl_Memo.Text = dgvr.Cells[7].Value.ToString();

            _ProcessC.WorkOrder = _wor;

            SetCalendar();
        }
        private void SetOrderDetailListView()
        {
            dgv_order_detail.Rows.Clear();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    dgv_order_detail.Rows.Add(array[7], array[8], array[10] + "개", array[13]);
                }
        }
        #endregion
        #region Calendar
        private void SetCalendar()
        {
            calendar1.ClearEvents();
            //foreach (string[] array in ViewList)
            //{
            ColorNum();

            SDate = lbl_Start.Text;
            EDate = lbl_End.Text;
            ordername = lbl_Name.Text;
            customername = lbl_Customer.Text;

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
                    EventText = ordername,
                    EventMessage = CreateMultiLineEventMessage(),
                    EventColor = Color.FromArgb(randomnum)
                };
                calendar1.AddEvent(groundhogEvent);

                T1 = T1.AddDays(+1);
                //}
            }
        }
        private string CreateMultiLineEventMessage()
        {
            StringBuilder LineMessage = new StringBuilder();
            LineMessage.AppendLine("수주명 : " + ordername + "\n거래처명 : " + customername + "\n일정 : " + SDate + " ~ " + EDate);
            return LineMessage.ToString();
        }
        private void ColorNum()
        {
            Random random = new Random();
            randomnum = random.Next(256);
        }
#endregion
        #region 검색 Button
        private void Btn_All_Click(object sender, EventArgs e)
        {
            ViewReset();
            ReFreshText();
            GetOrderData();
        }
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            if (Cb_State.Text.Equals("진행중"))
            {
                lbl_RealStart.Text = "수주 예정일";
                lbl_RealEnd.Text = "출하 예정일";
                label2.Text = "※ 진행중인 수주 리스트";
                label4.Text = "※ 진행중인 수주 품목 리스트";
            }
            else
            {
                lbl_RealStart.Text = "수주 시작일";
                lbl_RealEnd.Text = "수주 출하일";
                label2.Text = "※ 완료, 폐기된 수주 리스트";
                label4.Text = "※ 완료, 폐기된 수주 품목 리스트";
            }

            dgv_order.Visible = true;
            dgv_order.Rows.Clear();
            dgv_order_detail.Rows.Clear();

            List<string[]> ViewList = _ProcessC.GetSearchOrderSchedule(Cb_State.Text);
            if (ViewList != null)
                foreach (string[] str in ViewList)
                {
                    if ((str[1].IndexOf(tb_OrderName.Text) != -1) && Cb_State.SelectedItem.Equals(SetOrderState(str[2])))
                    {
                        dgv_order.Rows.Add(str[0], str[1], SetOrderState(str[2]), str[3], str[4], str[5], str[6], str[7]);
                    }
                }
            ViewReset();
        }
        #endregion
        #region Method
        private String SetOrderState(string state)
        {
            string str = "";

            if (state == "0") str = "대기";
            if (state == "1") str = "등록";
            if (state == "2") str = "진행중";
            if (state == "3") str = "출하 대기";
            if (state == "4") str = "출하 진행중";
            if (state == "5") str = "완료";
            if (state == "6") str = "폐기";

            return str;
        }
        private void ViewReset()
        {
            tb_OrderName.Text = "";
            Cb_State.SelectedIndex = 0;

            dgv_order.Visible = true;
            calendar1.ClearEvents();
            calendar1.CalendarDate = DateTime.Now;
        }
        #endregion
        #region 검색 basicform
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            ViewReset();
            ReFreshText();
            GetOrderData();
        }
        public Form SetForm()
        {
            return this;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }
        private void ReFreshText()
        {
            label2.Text = "※ 진행중인 수주 리스트";
            label4.Text = "※ 진행중인 수주 품목 리스트";
            lbl_RealStart.Text = "수주 예정일";
            lbl_End.Text = "출하 예정일";
        }
        private void ClickCalendar()
        {
            foreach (string[] array in ViewList)
            {
                ColorNum();

                SDate = array[3].ToString();
                EDate = array[4].ToString();
                ordername = array[1].ToString();
                customername = array[5].ToString();

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
        #endregion
        #region 검색 그리드뷰 병합 지금 안씀
        /*private void SetSelectedData(DataGridViewRow dgvr)
        {
            WorkOrder _wor = new WorkOrder();

            _wor.OrderNo = Convert.ToInt32(dgvr.Cells[0].Value);
            _wor.OrderName = dgvr.Cells[1].Value.ToString();
            _wor.OrderStateName = dgvr.Cells[2].Value.ToString();
            _wor.CustomerName = dgvr.Cells[5].Value.ToString();
            _wor.OrderDate = dgvr.Cells[3].Value.ToString();
            _wor.OrderDateEnd = dgvr.Cells[4].Value.ToString();
            _wor.OrderMemo = dgvr.Cells[6].Value.ToString();

            _ProcessC.WorkOrder = _wor;
        }
        private void dgv_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            SetSelectedData(dgv.SelectedRows[0]);

            calendar1.ClearEvents();
            //ClickCalendar();
        }
        private void SetDataGridView(DataGridView dgv)
        {
            dgv.Font = new Font("맑은 고딕", 11, FontStyle.Regular);

            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 72, 81);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.SeaGreen;

            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.CurrentCell = null;

            dgv.BackgroundColor = SystemColors.GradientInactiveCaption;


            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
            dgv.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f =>
            {
                f.SortMode = DataGridViewColumnSortMode.NotSortable;
                f.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                f.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            });
            dgv.Rows.Cast<DataGridViewRow>().Where((x, i) => i % 2 != 0).ToList().ForEach(r => r.DefaultCellStyle.BackColor = Color.AliceBlue);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        private void Form4_Load(object sender, EventArgs e)
        {
            dgv_order.AutoGenerateColumns = false;
        }
        bool IsTheSameCellValue(int column, int row)
        {
            check = false;
            DataGridViewCell cell1 = dgv_order[column, row];
            DataGridViewCell cell2 = dgv_order[column, row - 1];
            if (cell1.Value == null || cell2.Value == null)
            {
                return false;
            }
            if ((cell1.Value.ToString() == cell2.Value.ToString()) && column != 5 && column != 6)
                return true;
            else
                return false;
        }
        private void dataGridView1_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
                if (e.RowIndex < 1 || e.ColumnIndex < 0)
                    return;
                if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
                {
                    e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
                }
                else
                {
                    e.AdvancedBorderStyle.Top = dgv_order.AdvancedCellBorderStyle.Top;
                }
            }
        }
        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex == 0)
                return;
            if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
            {
                e.Value = "";
                e.FormattingApplied = true;
            }
        }*/
        #endregion
    }
}