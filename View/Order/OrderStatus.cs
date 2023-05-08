﻿using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace View
{
    public partial class OrderStatus : Form, IBasicForm
    {
        #region 검색 gridviewUI
        private void SetDataGridView(DataGridView dgv)
        {
            //진행중인 수주
            dgv_order.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[0].Width = 60;
            dgv_order.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[1].Width = 150;
            dgv_order.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[5].Width = 200;
            dgv_order.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[6].Width = 200;
            dgv_order.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order.Columns[8].Width = 350;

            //수주 상세보기
            dgv_order_detail.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[0].Width = 250;
            dgv_order_detail.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[1].Width = 100;
            dgv_order_detail.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[2].Width = 200;
            dgv_order_detail.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[3].Width = 100;
            dgv_order_detail.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[4].Width = 150;
            dgv_order_detail.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[5].Width = 150;
            dgv_order_detail.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_order_detail.Columns[6].Width = 150;

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
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            SetFormView();
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
        private List<String[]> ViewList;
        private List<String[]> ViewList2;
        private List<WorkOrder> OrderName, CustomerGroup;
        public OrderStatus(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;

            _ProcessC = new ProcessC();
            InitializeComponent();
            SetFormView();
        }
        private void SetFormView()
        {
            //SetDataGridView(dgv_order);
            //SetDataGridView(dgv_order_detail);
            GetOrderState();
            GetOrderData();
        }
        private void GetOrderData()
        {
            ViewList = _ProcessC.GetOrderDataList();
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
                    dgv_order.Rows.Add(array[0], array[1], SetOrderState(array[2]), array[3], array[4], array[5], array[6], array[7], array[8], array[10]);


                }
            SumPrice();
        }
        private void dgv_order_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                SetSelectedData(dgv.SelectedRows[0]);

                ViewList2 = _ProcessC.GetBOMData(_ProcessC.WorkOrder);
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
            _wor.OrderPrice = Convert.ToInt64(dgvr.Cells[7].Value.ToString().Replace(",",""));
            _wor.OrderMemo = dgvr.Cells[8].Value.ToString();
            _wor.OrderEmergency = dgvr.Cells[9].Value.ToString();

            _ProcessC.WorkOrder = _wor;
        }
        private void SetOrderDetailListView()
        {
            dgv_order_detail.Rows.Clear();
            if (ViewList2 != null)
                foreach (string[] array in ViewList2)
                {
                    dgv_order_detail.Rows.Add(array[1], array[6], array[7], array[8], array[10], string.Format("{0:#,###}", Convert.ToInt32(array[9])), string.Format("{0:#,###}", Convert.ToInt32(Calculation(Int32.Parse(array[9]), Int32.Parse(array[10]))), Int32.Parse(array[10])), array[13]);
                    if (array[11] != "") label8.Text = array[11].ToString().Substring(0, 10);
                    else if (array[11] == "") label8.Text = "";
                    if (array[12] != "") label9.Text = array[12].ToString().Substring(0, 10);
                    else if (array[12] == "") label9.Text = "";
                }
        }
        private double Calculation(double Price, double Count)
        {
            double result = 0;

            result = Price * Count;

            return Math.Round(result);
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

            cb_CGroup.Items.Clear();
            cb_CGroup.Items.Add("모두");
            CustomerGroup = _ProcessC.GetCustomerGroup();
            for (int i = 0; i < CustomerGroup.Count(); i++)
            {
                cb_CGroup.Items.Add(CustomerGroup[i].CustomerGroup);
                cb_CGroup.SelectedIndex = 0;
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

            List<string[]> ViewList = _ProcessC.GetOrderDataList();
            if (ViewList != null)
                foreach (string[] str in ViewList)
                {
                    if ((str[1].IndexOf(tb_OrderName.Text) != -1)
                        && (cb_OrderState.SelectedItem.Equals("모두") || cb_OrderState.SelectedItem.Equals(SetOrderState(str[2])))
                        && (str[3].IndexOf(tb_CustomerName.Text) != -1)
                        && (!dtp_date.Enabled || dtp_date.Value.Date <= Convert.ToDateTime(str[5]).Date && Convert.ToDateTime(str[5]) <= dtp_date_End.Value.Date)
                        //&& (!dtp_date.Enabled || Convert.ToDateTime(str[6]).Date >= dtp_date.Value.Date)
                        && cb_CGroup.SelectedItem.Equals("모두") || cb_CGroup.SelectedItem.Equals(str[9]))
                    {
                        dgv_order.Rows.Add(str[0], str[1], SetOrderState(str[2]), str[3], str[4], str[5], str[6], str[7], str[8], str[10]);
                    }
                }
            SumPrice();
        }
        private void SumPrice()
        {
            int Sum = 0;
            for (int k = 0; k < dgv_order.Rows.Count; k++)
            {
                Sum += Convert.ToInt32(dgv_order.Rows[k].Cells[7].Value.ToString().Replace(",", ""));
                if (Convert.ToDateTime(Convert.ToDateTime(dgv_order.Rows[k].Cells[6].Value).ToString("yyyy-MM-dd")) < Convert.ToDateTime(DateTime.Now.ToString("yyyyy-MM-dd")))
                    dgv_order.Rows[k].DefaultCellStyle.BackColor = Color.Red;
            }
            lbl_Price.Text = string.Format("{0:#,###}", Sum) + "원";
        }
        private void Reset()
        {
            tb_OrderName.Text = "";
            tb_CustomerName.Text = "";
            dtp_date.Text = DateTime.Now.ToString();
            dtp_date_End.Text = DateTime.Now.ToString();
        }

        private void OrderStatus_Load(object sender, EventArgs e)
        {
            ClearDGV();
        }
        public void ClearDGV()
        {
            dgv_order.ClearSelection();
        }
        private void checkBox2_Click(object sender, EventArgs e)
        {
            dtp_date.Enabled = dtp_date_End.Enabled = checkBox2.Checked;
        }
    }
}