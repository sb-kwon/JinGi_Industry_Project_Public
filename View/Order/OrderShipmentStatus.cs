using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace View
{
    public partial class OrderShipmentStatus : Form, IBasicForm
    {
        #region 검색 gridviewUI
        private void SetDataGridView(DataGridView dgv)
        {
            //진행중인 수주
            dgv_order.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[0].Width = 60;
            dgv_order.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dgv_order.Columns[1].Width = 300;
            dgv_order.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[2].Width = 100;
            dgv_order.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[3].Width = 200;
            dgv_order.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[4].Width = 200;
            dgv_order.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[5].Width = 200;
            dgv_order.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[6].Width = 200;
            dgv_order.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[7].Width = 100;
            dgv_order.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[8].Width = 100;

            //수주 상세보기
            dgv_order_detail.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[1].Width = 70;
            dgv_order_detail.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[3].Width = 150;
            dgv_order_detail.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[4].Width = 150;
            dgv_order_detail.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[5].Width = 150;
            dgv_order_detail.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[6].Width = 150;
            dgv_order_detail.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[7].Width = 100;

            dgv.Font = new Font("맑은 고딕", 11, FontStyle.Regular);


            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 72, 81);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.SeaGreen;

            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.CurrentCell = null;

            dgv.BackgroundColor = SystemColors.GradientInactiveCaption;

            dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
            dgv.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f =>
            {
                f.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                f.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            });
            dgv.Rows.Cast<DataGridViewRow>().Where((x, i) => i % 2 != 0).ToList().ForEach(r => r.DefaultCellStyle.BackColor = Color.AliceBlue);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion

        #region 검색 basicform
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
        public string GetText()
        {
            return this.Text;
        }

        public void RefreshForm()
        {
            GetShipmentOrderData();
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

        private Member _LoginInfo;
        private BasicForm _Mother;

        private ProcessC _ProcessC;
        private AuthorityC _AuthorityCtrl;
        private List<WorkOrder> OrderName;

        private List<String[]> ViewList, ViewList2;
        public OrderShipmentStatus(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;

            _ProcessC = new ProcessC();
            _AuthorityCtrl = new AuthorityC();

            ViewList = new List<string[]>();
            ViewList2 = new List<string[]>();
            InitializeComponent();

           //SetDataGridView(dgv_order);
           //SetDataGridView(dgv_order_detail);

            GetShipmentOrderData();
            GetOrderState();
        }
        private void GetShipmentOrderData()
        {
            ViewList = _ProcessC.GetShipmentOrderDataList();
            SetShipmentOrderListView();
        }
        private void SetShipmentOrderListView()
        {
            dgv_order.Rows.Clear();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    dgv_order.Rows.Add(array[0], array[1], SetOrderState(array[2]), array[3], array[4], array[5], array[6], array[13], array[7], array[8] + "/" + array[9], "수주 출하", array[10], array[8], array[9]);
                }
            SumPrice();
        }
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
        private void dgv_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                SetSelectedData(dgv.SelectedRows[0]);

                SetOrderDetailListView();
            }
        }
        private void SetOrderDetailListView()
        {
            dgv_order_detail.Rows.Clear();
            ViewList2 = _ProcessC.GetShipmentProductData();
            if (ViewList2 != null)
                foreach (string[] array in ViewList2)
                {
                    dgv_order_detail.Rows.Add(array[0], array[1], array[2], array[3], SetInstructionState(array[4]), SetQualityState(array[5]), SetCnt(array[6], array[7], array[4]), "품목 출하", array[8]);
                }
        }
        private string SetCnt(string str1, string str2, string str3)
        {
            string str = "";

            if ((str1 == str2) && (str3 == "3")) str = "출고 가능";
            else if ((str1 != str2) && (str3 != "3")) str = "출고 불가";
            else if ((str1 == str2) && (str3 == "6")) str = "출고 완료";

            return str;
        }
        private String SetInstructionState(string state)
        {
            string str = "";

            if (state == "0") str = "대기";
            if (state == "1") str = "등록";
            if (state == "2") str = "진행중";
            if (state == "3") str = "완료";
            if (state == "4") str = "폐기";
            if (state == "5") str = "취소";
            if (state == "6") str = "출고 완료";

            return str;
        }
        private String SetQualityState(string state)
        {
            string str = "";

            //if (state == "0") str = "양호";
            if (state == "1") str = "불량";
            //if (state == "") str = "검사 전";

            return str;
        }
        private void SumPrice()
        {
            int Sum = 0;
            for (int k = 0; k < dgv_order.Rows.Count; k++)
            {
                Sum += Convert.ToInt32(dgv_order.Rows[k].Cells[8].Value.ToString().Replace(",", ""));
            }
            lbl_Price.Text = string.Format("{0:#,###}", Sum) + "원";
        }
        private void SetSelectedData(DataGridViewRow dgvr)
        {
            WorkOrder _wor = new WorkOrder();

            _wor.OrderNo = Convert.ToInt32(dgvr.Cells[0].Value);
            _wor.OrderName = dgvr.Cells[1].Value.ToString();
            _wor.OrderStateName = dgvr.Cells[2].Value.ToString();
            if (dgvr.Cells[3].Value.ToString() == "") _wor.OrderStartSchedule = dgvr.Cells[3].Value.ToString();
            if (dgvr.Cells[4].Value.ToString() == "") _wor.OrderEndSchedule = dgvr.Cells[4].Value.ToString();

            _ProcessC.WorkOrder = _wor;
        }
        private void GetOrderState()
        {
            cb_OrderState.Items.Clear();
            cb_OrderState.Items.Add("모두");
            OrderName = _ProcessC.GetOrderState();
            for (int i = 0; i < OrderName.Count(); i++)
            {
                cb_OrderState.Items.Add(SetOrderState(OrderName[i].OrderStateName));
                cb_OrderState.SelectedIndex = 0;
            }
        }
        private void btn_Search_Click_1(object sender, EventArgs e)
        {
            DateTime Start = DateTime.Parse(dtp_date.Text);
            DateTime End = DateTime.Parse(dtp_date_End.Text);
            DateTime start = DateTime.Parse(dateTimePicker1.Text);
            DateTime end = DateTime.Parse(dateTimePicker2.Text);
            int TimeResult = DateTime.Compare(Start, End);
            int TimeResult2 = DateTime.Compare(start, end);

            if (checkBox1.Checked || checkBox2.Checked)
            {
                if (TimeResult > 0 || TimeResult2 > 0) MessageBox.Show("종료 날짜가 시작 날짜보다 이전일 수 없습니다.");
                else
                {
                    dgv_order.Rows.Clear();
                    dgv_order_detail.Rows.Clear();

                    List<string[]> ViewList = _ProcessC.GetShipmentOrderDataList();
                    if (ViewList != null)
                        foreach (string[] array in ViewList)
                        {
                            if ((array[1].IndexOf(tb_OrderName.Text) != -1)
                                && (cb_OrderState.SelectedItem.Equals("모두") || cb_OrderState.SelectedItem.Equals(SetOrderState(array[2])))
                                && (!dtp_date.Enabled || dtp_date.Value.Date <= Convert.ToDateTime(array[3]).Date && Convert.ToDateTime(array[3]) <= dtp_date_End.Value.Date)
                                //&& (!dtp_date.Enabled || Convert.ToDateTime(array[4]).Date >= dtp_date.Value.Date)
                                && (!dateTimePicker1.Enabled || dateTimePicker1.Value.Date <= Convert.ToDateTime(array[5]).Date && Convert.ToDateTime(array[5]).Date <= dateTimePicker2.Value.Date))
                                //&& (!dateTimePicker1.Enabled || Convert.ToDateTime(array[6]).Date >= dateTimePicker1.Value.Date))
                            {
                                dgv_order.Rows.Add(array[0], array[1], SetOrderState(array[2]), array[3], array[4], array[5], array[6], array[13], array[7], array[8] + "/" + array[9], "수주 출하", array[10], array[8], array[9]);
                            }
                        }
                    SumPrice();
                }
            }
        }
        private void checkBox2_Click(object sender, EventArgs e)
        {
            dtp_date.Enabled = dtp_date_End.Enabled = checkBox2.Checked;
        }
        private void checkBox1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = dateTimePicker2.Enabled = checkBox1.Checked;
        }
    }
}