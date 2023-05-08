using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace View
{
    public partial class OrderReciptView : Form, IBasicForm
    {
        #region 검색 basicform
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            GetOrderData();
            Reset();
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
        private List<String[]> ViewList, ViewList2;
        private List<WorkOrder> OrderName;
        public OrderReciptView(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;
            _ProcessC = new ProcessC();

            InitializeComponent();

            ViewList = ViewList2 = new List<String[]>();
            GetOrderData();
        }
        private void GetOrderData()
        {
            ViewList = _ProcessC.GetOrderDataListAll();
            GetOrderState();
            SetOrderListView();
        }
        private void SetOrderListView()
        {
            dgv_order.Rows.Clear();
            dgv_order_detail.Rows.Clear();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    dgv_order.Rows.Add(array[0], array[1], SetOrderState(array[2]), array[3], array[4], array[5], array[6], array[7], array[8] /* 수주 금액 추가 */);
                }
            SumPrice();
        }
        private void dgv_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                SetSelectedData(dgv.SelectedRows[0]);

                ViewList2 = _ProcessC.GetBOMDataRecipt(_ProcessC.WorkOrder);
                SetOrderDetailListView();
            }
        }
        private void SetSelectedData(DataGridViewRow dgvr)
        {
            WorkOrder _wor = new WorkOrder();

            _wor.OrderNo = Convert.ToInt32(dgvr.Cells[0].Value);
            _wor.OrderName = dgvr.Cells[1].Value.ToString();
            _wor.OrderStateName = dgvr.Cells[2].Value.ToString();
            _wor.CustomerName = dgvr.Cells[3].Value.ToString();
            _wor.CustomerMemberName = dgvr.Cells[4].Value.ToString();
            _wor.OrderDate = dgvr.Cells[5].Value.ToString();
            _wor.OrderDateEnd = dgvr.Cells[6].Value.ToString();
            _wor.OrderPrice = Convert.ToInt64(dgvr.Cells[7].Value.ToString().Replace(",", ""));
            _wor.OrderMemo = dgvr.Cells[8].Value.ToString();

            _ProcessC.WorkOrder = _wor;
        }
        private void SetOrderDetailListView()
        {
            dgv_order_detail.Rows.Clear();
            if (ViewList2 != null)
                foreach (string[] array in ViewList2)
                {
                    string pay = string.Format("{0:#,###}", Convert.ToInt32(array[9]));
                    string money = string.Format("{0:#,###}", Convert.ToInt32(Calculation(Int32.Parse(array[9]), Int32.Parse(array[10]))));
                    dgv_order_detail.Rows.Add(array[1], array[6], array[7], array[8], array[14], array[10], pay, money, array[13]);
                }
        }
        private double Calculation(double Price, double Count)
        {
            double result = 0;

            result = Price * Count;

            return Math.Round(result);
        }
        private void SumPrice()
        {
            int Sum = 0;
            for (int k = 0; k < dgv_order.Rows.Count; k++)
            {
                Sum += Convert.ToInt32(dgv_order.Rows[k].Cells[7].Value.ToString().Replace(",", ""));
            }
            dgv_order.Rows[0].Selected = false;
            lbl_Price.Text = string.Format("{0:#,###}", Sum) + "원";
        }
        #region 검색 상단 버튼 (조회, 추가, 수정, 삭제)
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
        private void btn_Search_Click(object sender, EventArgs e)
        {
            dgv_order.Rows.Clear();
            dgv_order_detail.Rows.Clear();

            List<string[]> ViewList = _ProcessC.GetOrderDataListAll();
            if (ViewList != null)
                foreach (string[] str in ViewList)
                {
                    if ((str[1].IndexOf(tb_OrderName.Text) != -1)
                        && (cb_OrderState.SelectedItem.Equals("모두") || cb_OrderState.SelectedItem.Equals(SetOrderState(str[2])))
                        && (str[3].IndexOf(tb_CustomerName.Text) != -1)
                        && (!dtp_date.Enabled || Convert.ToDateTime(str[5]).Date <= dtp_date.Value.Date)
                        && (!dtp_date.Enabled || Convert.ToDateTime(str[6]).Date >= dtp_date.Value.Date))
                    {
                        dgv_order.Rows.Add(str[0], str[1], SetOrderState(str[2]), str[3], str[4], str[5], str[6], str[7], str[8] /* 수주 금액 추가 */);
                    }
                }
            SumPrice();
        }
        private void Reset()
        {
            tb_OrderName.Text = "";
            tb_CustomerName.Text = "";
            dtp_date.Text = DateTime.Now.ToString();
        }
        #endregion
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dtp_date.Enabled = checkBox2.Checked;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Customer c = _ProcessC.GetCus();
            string[] list = {
               DateTime.Now.ToString("yyyy-MM-dd"),
               c.CustomerName,
               c.CustomerAddress,
               c.CustomerNumber,
               c.CustomerGoods
            };
            List<string[]> list1 = new List<string[]>();

            foreach (DataGridViewRow dgvr in dgv_order_detail.Rows)
            {
                string[] str = {
                      dgvr.Cells[2].Value.ToString()
                    , dgvr.Cells[4].Value.ToString()
                    , dgvr.Cells[5].Value.ToString()
                    , dgvr.Cells[6].Value.ToString()
                    , dgvr.Cells[7].Value.ToString()
                };
                list1.Add(str);
            }
            if (!(ViewList2.Count == 0))
            {
                OrderRecipt print_Form = new OrderRecipt(list, list1, "거 래 명 세 서");

                print_Form.StartPosition = FormStartPosition.CenterParent;
                print_Form.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                print_Form.ShowDialog();
            }
            else SetAlarm("인쇄할 항목을 선택해 주세요.");
        }
    }
}