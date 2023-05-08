using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace View
{
    public partial class Part_Identification_Label : Form, IBasicForm
    {
        private bool _Mode;
        private Member _LoginInfo;
        private BasicForm _Mother;
        private ProcessC _ProcessC;
        private List<WorkOrder> OrderName;
        private List<WorkProcess> WorkProcess;
        private List<String[]> ViewList, BomList;
        public Part_Identification_Label(Member member, BasicForm form)
        {
            _Mode = false;
            _Mother = form;
            _LoginInfo = member;
            _ProcessC = new ProcessC();
            WorkProcess = new List<WorkProcess>();
            ViewList = BomList = new List<String[]>();

            InitializeComponent();
            SetFormView();
        }
        #region 검색 basicform
        private void SetFormView()
        {
            _Mode = false;
            GetShipmentOrderData();
            GetOrderState();
            ModeBtnColorSet();
        }
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            SetFormView();
        }
        public Form SetForm()
        {
            return this;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }
        private void GetShipmentOrderData()
        {
            ViewList = _ProcessC.GetShipmentOrderDataList();
            SetShipmentOrderListView();
        }
        #endregion
        #region 검색 DGV
        private void SetShipmentOrderListView()
        {
            dgv_order.Rows.Clear();
            if (ViewList != null)
                foreach (String[] array in ViewList)
                {
                    dgv_order.Rows.Add(array[0], array[1], array[12], SetOrderState(array[2]), array[3], array[4], array[5], array[6], array[7], array[8] + "/" + array[9], "수주 출하", array[10], array[8], array[9]);
                }
            SumPrice();
        }
        private void dgv_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                SetSelectedData(dgv.SelectedRows[0]);

                if (_Mode) SetMultiSelect(dgv.SelectedRows[0]);
                SetOrderDetailListView();
            }
        }
        private void SetMultiSelect(DataGridViewRow dgvr)
        {
            if ((bool)dgvr.Cells[14].Value) dgvr.Cells[14].Value = false;
            else dgvr.Cells[14].Value = true;
        }
        private void SetOrderDetailListView()
        {
            dgv_order_detail.Rows.Clear();
            BomList = _ProcessC.GetBOMData(_ProcessC.WorkOrder);

            if (BomList != null)
                foreach (String[] array in BomList)
                {
                    dgv_order_detail.Rows.Add(array[1], array[6], array[7], array[8], array[10]);
                }

            int i = dgv_order.CurrentCell.RowIndex;
            if (dgv_order.Rows[i].Cells[14].Value != null)
            if ((bool)dgv_order.Rows[i].Cells[14].Value)
            {
                foreach (DataGridViewRow dgvr in dgv_order_detail.Rows)
                {
                    WorkProcess _Wp = new WorkProcess();
                    _Wp.ProductName = dgvr.Cells[2].Value.ToString();
                    _Wp.OrderName = dgv_order.Rows[i].Cells[1].Value.ToString();

                    WorkProcess.Add(_Wp);
                }
            }
        }
        private void SetSelectedData(DataGridViewRow dgvr)
        {
            WorkOrder _wor = new WorkOrder();

            _wor.OrderNo = Convert.ToInt32(dgvr.Cells[0].Value);
            _wor.OrderName = dgvr.Cells[1].Value.ToString();
            _wor.OrderStateName = dgvr.Cells[3].Value.ToString();
            if (dgvr.Cells[4].Value.ToString() == "") _wor.OrderStartSchedule = dgvr.Cells[4].Value.ToString();
            if (dgvr.Cells[5].Value.ToString() == "") _wor.OrderEndSchedule = dgvr.Cells[5].Value.ToString();

            _ProcessC.WorkOrder = _wor;
        }
        #endregion
        private void SumPrice()
        {
            int Sum = 0;
            for (int k = 0; k < dgv_order.Rows.Count; k++)
            {
                Sum += Convert.ToInt32(dgv_order.Rows[k].Cells[8].Value.ToString().Replace(",", ""));
            }
            lbl_Price.Text = string.Format("{0:#,###}", Sum) + "원";
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
        private String SetOrderState(String state)
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
        #region 검색 Button
        private void btn_Search_Click_1(object sender, EventArgs e)
        {
            dgv_order.Rows.Clear();
            dgv_order_detail.Rows.Clear();

            List<String[]> ViewList = _ProcessC.GetShipmentOrderDataList();
            if (ViewList != null)
                foreach (String[] array in ViewList)
                {
                    if ((array[1].IndexOf(tb_OrderName.Text) != -1)
                        && (cb_OrderState.SelectedItem.Equals("모두") || cb_OrderState.SelectedItem.Equals(SetOrderState(array[2])))
                        && (!dtp_date.Enabled || Convert.ToDateTime(array[4]).Date <= dtp_date.Value.Date)
                        && (!dtp_date.Enabled || Convert.ToDateTime(array[5]).Date >= dtp_date.Value.Date)
                        && (!dateTimePicker1.Enabled || Convert.ToDateTime(array[6]).Date <= dateTimePicker1.Value.Date)
                        && (!dateTimePicker1.Enabled || Convert.ToDateTime(array[7]).Date >= dateTimePicker1.Value.Date))
                    {
                        dgv_order.Rows.Add(array[0], array[1], array[12], SetOrderState(array[2]), array[3], array[4], array[5], array[6], array[7], array[8] + "/" + array[9], "수주 출하", array[10], array[8], array[9]);
                    }
                }
            SumPrice();
        }
        private void btn_MultiCheck_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _Mode = !_Mode;
            ModeBtnColorSet();
        }
        private void btn_MultiPrint_Click(object sender, EventArgs e)
        {
            List<ProcessC> list = new List<ProcessC>();

            foreach (DataGridViewRow dgr in dgv_order.Rows)
            {
                if ((bool)dgr.Cells[14].Value)
                {
                    string Count = dgr.Cells[0].Value.ToString();
                    OrderName = _ProcessC.GetCount(Count);

                    for (int i = 0; i < OrderName.Count; i++)
                    {
                        for (int k = 0; k < WorkProcess.Count; k++)
                        {
                            if (k != WorkProcess.Count && i != OrderName.Count)
                            {
                                if (WorkProcess[k].OrderName.Equals(OrderName[i].OrderName))
                                {
                                    ProcessC processC = new ProcessC();

                                    processC.Product.ProductName = WorkProcess[k].ProductName;//dgv_order_detail.Rows[i].Cells[2].Value.ToString();
                                    processC.WorkOrder.OrderName = WorkProcess[k].OrderName;
                                    processC.WorkOrder.CustomerName = dgr.Cells[2].Value.ToString();
                                    processC.WorkOrder.OrderDate = dgr.Cells[4].Value.ToString();
                                    processC.WorkOrder.OrderDateEnd = dgr.Cells[5].Value.ToString();
                                    processC.WorkOrder.OrderEndSchedule = dgr.Cells[7].Value.ToString();

                                    list.Add(processC);
                                    i = i + 1;
                                }
                            }
                        }
                    }
                }
            }
            Label_Print_Multi print_Form = new Label_Print_Multi(list);

            print_Form.StartPosition = FormStartPosition.CenterParent;
            print_Form.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            print_Form.ShowDialog();
        }
        private void Btn_Print_Click(object sender, EventArgs e)
        {
            Label_Print print_Form = new Label_Print();

            print_Form.StartPosition = FormStartPosition.CenterParent;
            print_Form.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            print_Form.ShowDialog();
        }
        #endregion
        #region Event
        private void checkBox1_Click(object sender, EventArgs e)
        {
            dateTimePicker1.Enabled = checkBox1.Checked;
        }
        private void checkBox2_Click(object sender, EventArgs e)
        {
            dtp_date.Enabled = checkBox2.Checked;
        }
        private void ModeBtnColorSet()
        {
            if (_Mode)
            {
                btn_MultiCheck.BackColor = Color.Lime;
                btn_MultiPrint.Visible = true;
                dgv_order.Columns[14].Visible = true;

                //해수몬
                foreach (DataGridViewRow dgvr in dgv_order.Rows) dgvr.Cells[14].Value = false;
            }
            else
            {
                btn_MultiCheck.BackColor = Color.CornflowerBlue;
                btn_MultiPrint.Visible = false;
                dgv_order.Columns[14].Visible = false;
            }
        }
        #endregion
    }
}