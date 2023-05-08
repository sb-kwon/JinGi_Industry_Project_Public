using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Model;
using Controller;
namespace View
{
    public partial class Outsourcing_Status : Form, IBasicForm
    {
        private bool kkw;
        private Member _LoginInfo;
        private BasicForm _Mother;
        private ProcessC _ProcessC;
        private List<String[]> OutList, OutProduct, ViewList;
        private List<WorkOrder> OrderName, CustomerGroup;
        public Outsourcing_Status(Member member, BasicForm form)
        {
            InitializeComponent();

            _LoginInfo = member;
            _Mother = form;
            _ProcessC = new ProcessC();

            GetOutData();
        }
        #region 검색 IBasicForm
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            GetOutData();
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

            cb_CGroup.Items.Clear();
            cb_CGroup.Items.Add("모두");
            CustomerGroup = _ProcessC.GetCustomerGroup();
            for (int i = 0; i < CustomerGroup.Count(); i++)
            {
                cb_CGroup.Items.Add(CustomerGroup[i].CustomerGroup);
                cb_CGroup.SelectedIndex = 0;
            }
        }
        #region 검색 DGV
        private void GetOutData()
        {
            OutList = _ProcessC.GetOutDataList();
            GetOrderState();
            SetOutListView();
        }
        private void SetOutListView()
        {
            dgv_Out.Rows.Clear();
            dgv_Out_Product.Rows.Clear();
            if (OutList != null)
                foreach (string[] array in OutList)
                {
                    dgv_Out.Rows.Add(array[0], array[1], SetOrderState(array[2]), array[3], array[4], array[5], array[6], array[7], array[8]);
                }
            SumPrice();
        }
        private void dgv_Out_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                SetSelectedData(dgv.SelectedRows[0]);

                OutProduct = _ProcessC.GetOutProductList(_ProcessC.WorkProcess.WorkOrder);
                OutDetailListView();
            }
        }
        private void SetSelectedData(DataGridViewRow dgvr)
        {
            WorkOrder _wor = new WorkOrder();

            _wor.OrderNo = Convert.ToInt32(dgvr.Cells[0].Value);
            _wor.OrderName = dgvr.Cells[1].Value.ToString();
            _wor.OrderStateName = dgvr.Cells[2].Value.ToString();
            _wor.CustomerName = dgvr.Cells[3].Value.ToString();
            _wor.CustomerGroup = dgvr.Cells[4].Value.ToString();
            _wor.OrderDate = dgvr.Cells[5].Value.ToString();
            _wor.OrderDateEnd = dgvr.Cells[6].Value.ToString();
            _wor.OrderPrice = Convert.ToInt64(dgvr.Cells[7].Value.ToString().Replace(",", ""));
            _wor.OrderMemo = dgvr.Cells[8].Value.ToString();
            
            _ProcessC.WorkProcess.WorkOrder = _wor;
            _ProcessC.WorkProcess.OrderNo = _wor.OrderNo;
        }
        private void OutDetailListView()
        {
            dgv_Out_Product.Rows.Clear();
            if (OutProduct != null)
                foreach (string[] array in OutProduct)
                {
                    if (!(array[7].Equals("")) && array[8].Equals(""))
                    {
                        dgv_Out_Product.Rows.Add(array[1], array[2], array[3], array[4], array[5], string.Format("{0:#,###}", Convert.ToInt32(array[6])),
                                             string.Format("{0:#,###}", Convert.ToInt32(Calculation(Int32.Parse(array[6]), Int32.Parse(array[5]))),
                                             Int32.Parse(array[5])), array[7], array[8], "품목 입고", array[9], array[10], array[11]);
                    }
                    else if (!(array[8].Equals("")))
                    {
                        dgv_Out_Product.Rows.Add(array[1], array[2], array[3], array[4], array[5], string.Format("{0:#,###}", Convert.ToInt32(array[6])),
                                             string.Format("{0:#,###}", Convert.ToInt32(Calculation(Int32.Parse(array[6]), Int32.Parse(array[5]))),
                                             Int32.Parse(array[5])), array[7], array[8], "입고 완료", array[9], array[10], array[11]);
                    }
                    else
                    {
                        dgv_Out_Product.Rows.Add(array[1], array[2], array[3], array[4], array[5], string.Format("{0:#,###}", Convert.ToInt32(array[6])),
                                                 string.Format("{0:#,###}", Convert.ToInt32(Calculation(Int32.Parse(array[6]), Int32.Parse(array[5]))),
                                                 Int32.Parse(array[5])), array[7], array[8], "품목 출고", array[9], array[10], array[11]);
                    }
                }
        }
        private void dgv_Out_Product_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dgv_Out_Product.Rows[e.RowIndex].Cells[9].Value.Equals("품목 입고")) dgv_Out_Product.Rows[e.RowIndex].Cells[9].Style.BackColor = dgv_Out_Product.Rows[e.RowIndex].Cells[9].Style.SelectionBackColor = Color.Lime;
            else if (dgv_Out_Product.Rows[e.RowIndex].Cells[9].Value.Equals("품목 출고")) dgv_Out_Product.Rows[e.RowIndex].Cells[9].Style.BackColor = dgv_Out_Product.Rows[e.RowIndex].Cells[9].Style.SelectionBackColor = Color.Red;
            else if (dgv_Out_Product.Rows[e.RowIndex].Cells[9].Value.Equals("입고 완료")) dgv_Out_Product.Rows[e.RowIndex].Cells[9].Style.BackColor = dgv_Out_Product.Rows[e.RowIndex].Cells[9].Style.SelectionBackColor = SystemColors.Control;
        }
        private void dgv_Out_Product_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            _ProcessC.WorkProcess.OrderMemo = dgv.Rows[e.RowIndex].Cells[10].Value.ToString();
            _ProcessC.WorkProcess.WorkInstructionNo = Convert.ToInt64(dgv.Rows[e.RowIndex].Cells[11].Value);
            _ProcessC.WorkProcess.ProductNo = Convert.ToInt32(dgv.Rows[e.RowIndex].Cells[12].Value);

            if (dgv.Columns[e.ColumnIndex].Index == 9 && dgv.Rows[e.RowIndex].Cells[9].Value.ToString() == "품목 출고")
            {
                kkw = true;
                if (MessageBox.Show("현재 날짜로 출고 하시겠습니까?", "출고 알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _ProcessC.WorkProcess.BomOutTime = DateTime.Now;
                    _ProcessC.OutInProduct(kkw);
                    _ProcessC.OutProcess(kkw);
                    SetAlarm("품목이 외주 출고 되었습니다.");
                }
                else
                {
                    ShowOutData();
                }
            }
            else if (dgv.Columns[e.ColumnIndex].Index == 9 && dgv.Rows[e.RowIndex].Cells[9].Value.ToString() == "품목 입고")
            {
                kkw = false;
                _ProcessC.WorkProcess.BomOutTime = Convert.ToDateTime(dgv.Rows[e.RowIndex].Cells[7].Value);
                if (MessageBox.Show("현재 날짜로 입고 하시겠습니까?", "입고 알림", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _ProcessC.WorkProcess.BomInTime = DateTime.Now;
                    _ProcessC.OutInProduct(kkw);
                    _ProcessC.OutProcess(kkw);

                    List<String[]> OutList = _ProcessC.CheckWorkInstructionState();
                    foreach (String[] str in OutList)
                    {
                        if (str[0].ToString() == str[1].ToString())
                        {
                            _ProcessC.OutProcess(kkw);
                        }
                    }
                    List<String[]> FairList = _ProcessC.ProcessCheckCompletion();
                    if (FairList != null)
                    {
                        foreach (String[] str in FairList)
                        {
                            if (str[0] == str[1])
                            {
                                _ProcessC.UpdateProcessCompletion();
                            }
                        }
                    }
                    SetAlarm("품목이 외주 입고 되었습니다.");
                }
                else
                {
                    ShowOutData();
                }
            }
            GetOutData();
        }
        #endregion
        #region Method
        private void ShowOutData()
        {
            /*OutDateForm ODF = new OutDateForm(kkw, _ProcessC, this);
            ODF.StartPosition = FormStartPosition.CenterParent;
            ODF.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            ODF.ShowDialog();*/
        }
        private double Calculation(double Price, double Count)
        {
            double result = Price * Count;
            return Math.Round(result);
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
        private void SumPrice()
        {
            int Sum = 0;
            for (int k = 0; k < dgv_Out.Rows.Count; k++)
            {
                Sum += Convert.ToInt32(dgv_Out.Rows[k].Cells[7].Value.ToString().Replace(",", ""));
            }
            lbl_Price.Text = string.Format("{0:#,###}", Sum) + "원";
        }
        private void Cb_Date_CheckedChanged(object sender, EventArgs e)
        {
            dtp_date.Enabled = Cb_Date.Checked;
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            dgv_Out.Rows.Clear();
            dgv_Out_Product.Rows.Clear();

            ViewList = _ProcessC.GetOutDataList();
            if (ViewList != null)
                foreach (string[] str in ViewList)
                {
                    if ((str[1].IndexOf(tb_OrderName.Text) != -1)
                        && (cb_OrderState.SelectedItem.Equals("모두") || cb_OrderState.SelectedItem.Equals(SetOrderState(str[2])))
                        && (str[3].IndexOf(tb_CustomerName.Text) != -1)
                        && (!dtp_date.Enabled || Convert.ToDateTime(str[5]).Date <= dtp_date.Value.Date)
                        && (!dtp_date.Enabled || Convert.ToDateTime(str[6]).Date >= dtp_date.Value.Date)
                        && cb_CGroup.SelectedItem.Equals("모두") || cb_CGroup.SelectedItem.Equals(str[4]))
                    {
                        dgv_Out.Rows.Add(str[0], str[1], SetOrderState(str[2]), str[3], str[4], str[5], str[6], str[7], str[8]);
                    }
                }
            SumPrice();
        }
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
        private void TextClear()
        {
            tb_OrderName.Text = "";
            tb_CustomerName.Text = "";
            cb_CGroup.SelectedIndex = 0;
            cb_OrderState.SelectedIndex = 0;
            dtp_date.Value = DateTime.Now;
        }
        #endregion
    }
}