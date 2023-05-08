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
    public partial class Schedule_Item : Form, IBasicForm
    {
        private bool check;
        private Member _LoginInfo;
        private BasicForm _Mother;
        private ProcessC _ProcessC;
        private List<String[]> ViewList;
        private int cnt = 0, randomnum, diffDay;
        private string ProductName, ordername, SDate, EDate;
        public Schedule_Item(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;
            _ProcessC = new ProcessC();

            InitializeComponent();

            //SetDataGridView(dgv_product);
            GetProductData();
        }
        #region 검색 DGV
        private void GetProductData()
        {
            ViewList = _ProcessC.GeItemSchedule();
            SetProductListView();
            ViewReset();
        }
        private void SetProductListView()
        {
            dgv_product.Rows.Clear();
            Cb_State.SelectedIndex = 0;
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    dgv_product.Rows.Add(array[0], array[1] + " 등 " + array[9] + "개", array[2], SetProcessState(array[3]), array[4], array[5], array[6], array[7], array[8]);
                }
        }
        private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            SetSelectedData(dgv.SelectedRows[0]);
        }
        private void SetSelectedData(DataGridViewRow dgvr)
        {
            Product _pro = new Product();

            _pro.ProductNo = Convert.ToInt32(dgvr.Cells[0].Value);
            _pro.ProductName = lbl_ProductName.Text = dgvr.Cells[1].Value.ToString();
            _pro.WorkProcess.FairReal = lbl_FairReal.Text = dgvr.Cells[2].Value.ToString();
            _pro.WorkProcess.WorkProcessStateName = lbl_State.Text = dgvr.Cells[3].Value.ToString();
            _pro.OrderName = lbl_OrderName.Text = dgvr.Cells[4].Value.ToString();
            _pro.WorkProcessPlanStart = lbl_Start.Text = dgvr.Cells[5].Value.ToString();
            _pro.WorkProcessPlanEnd = lbl_End.Text = dgvr.Cells[6].Value.ToString();
            _pro.ProductMemo = lbl_ProductMemo.Text = dgvr.Cells[7].Value.ToString();
            _pro.WorkProcess.OrderMemo = lbl_OrderMemo.Text = dgvr.Cells[8].Value.ToString();

            _ProcessC.Product = _pro;

            SetCalendar();
        }
        private void dgv_product_RowHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            var row = dgv_product.Rows[e.RowIndex];
            row.HeaderCell.Style.BackColor = Color.Gray;
            row.HeaderCell.Style.ForeColor = Color.Gray;
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
        #endregion
        #region Calendar
        private void SetCalendar()
        {
            calendar1.ClearEvents();
            //foreach (string[] array in ViewList)
            //{
            if (lbl_Start.ToString() != "")
            {
                ColorNum();

                SDate = lbl_Start.Text;
                EDate = lbl_End.Text; ;
                ordername = lbl_OrderName.Text;
                ProductName = lbl_ProductName.Text;

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
                        EventText = ProductName,
                        EventMessage = CreateMultiLineEventMessage(),
                        EventColor = Color.FromArgb(randomnum)
                    };
                    calendar1.AddEvent(groundhogEvent);

                    T1 = T1.AddDays(+1);
                }
                //}
            }
        }
        private string CreateMultiLineEventMessage()
        {
            StringBuilder LineMessage = new StringBuilder();
            LineMessage.AppendLine("수주명 : " + ordername + "\n품목명 : " + ProductName + "\n일정 : " + SDate.Substring(0, 10) + " ~ " + EDate.Substring(0, 10));
            return LineMessage.ToString();
        }
        private void ColorNum()
        {
            Random random = new Random();
            randomnum = random.Next(256);
        }
        private void ClickCalendar()
        {
            calendar1.ClearEvents();

            foreach (string[] array in ViewList)
            {
                if (array[6].ToString() != "")
                {
                    ColorNum();

                    SDate = array[6].ToString();
                    EDate = array[7].ToString();
                    ordername = array[3].ToString();
                    ProductName = array[1].ToString();

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
        }
        private void GetScheduleItem()
        {
            ViewList = _ProcessC.GetProductDataSchedule();
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
            GetProductData();
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
        private void ReFreshText()
        {
            label2.Text = "※ 작업 중인 품목 상세보기";
            label4.Text = "※ 작업 중인 품목 리스트";
            lbl_RealStart.Text = "작업시작 예정일";
            lbl_RealEnd.Text = "작업종료 예정일";
        }
        private void ViewReset()
        {
            tb_ProductName.Text = "";
            Cb_State.SelectedIndex = 0;

            lbl_ProductName.Text = "";
            lbl_State.Text = "";
            lbl_OrderName.Text = "";
            lbl_FairReal.Text = "";
            lbl_Start.Text = "";
            lbl_End.Text = "";
            lbl_ProductMemo.Text = "";
            lbl_OrderMemo.Text = "";

            calendar1.ClearEvents();
            calendar1.CalendarDate = DateTime.Now;
        }
        #endregion        
        #region 검색 Button
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            if (Cb_State.Text.Equals("작업 중"))
            {
                lbl_RealStart.Text = "작업 예정일";
                lbl_RealEnd.Text = "종료 예정일";
                label2.Text = "※ 작업 중인 품목 상세보기";
                label4.Text = "※ 작업 중인 품목 리스트";
            }
            else
            {
                lbl_RealStart.Text = "작업 시작시간";
                lbl_RealEnd.Text = "작업 종료시간";
                label2.Text = "※ 완료, 폐기된 품목 리스트";
                label4.Text = "※ 완료, 폐기된 품목 리스트";
            }

            dgv_product.Rows.Clear();

            List<string[]> ViewList = _ProcessC.GetSearchItemSchedule(Cb_State.Text);
               if (ViewList != null)
               foreach (string[] str in ViewList)
               {
                   if ((str[1].IndexOf(tb_ProductName.Text) != -1) && Cb_State.SelectedItem.Equals(SetProcessState(str[3])))
                   {
                       dgv_product.Rows.Add(str[0], str[1] + " 등 " + str[9] + "개", str[2], SetProcessState(str[3]), str[4], str[5], str[6], str[7], str[8]);
                   }
               }
           ViewReset();
        }
        private void Btn_All_Click(object sender, EventArgs e)
        {
            ViewReset();
            ReFreshText();
            GetProductData();
        }
        #endregion
        #region 검색 gridviewUI 얘도
        //private void SetDataGridView(DataGridView dgv)
        //{
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
        #region 검색 그리드뷰 병합 지금 안씀
        //private void Form4_Load(object sender, EventArgs e)
        //{
        //   dgv_product.AutoGenerateColumns = false;
        //}
        //
        //bool IsTheSameCellValue(int column, int row)
        //{
        //    check = false;
        //    DataGridViewCell cell1 = dgv_product[column, row];
        //    DataGridViewCell cell2 = dgv_product[column, row - 1];
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
        //    if (e.RowIndex != -1)
        //    {
        //        e.AdvancedBorderStyle.Bottom = DataGridViewAdvancedCellBorderStyle.None;
        //        if (e.RowIndex < 1 || e.ColumnIndex < 0)
        //            return;
        //        if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
        //        {
        //            e.AdvancedBorderStyle.Top = DataGridViewAdvancedCellBorderStyle.None;
        //        }
        //        else
        //        {
        //            e.AdvancedBorderStyle.Top = dgv_product.AdvancedCellBorderStyle.Top;
        //        }
        //    }
        //}
        //private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        //{
        //    if (e.RowIndex == 0)
        //        return;
        //    if (IsTheSameCellValue(e.ColumnIndex, e.RowIndex))
        //    {
        //        e.Value = "";
        //        e.FormattingApplied = true;
        //    }
        //}
        #endregion
    }
}
