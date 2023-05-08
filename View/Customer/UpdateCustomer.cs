using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;
using System.Drawing;

namespace View
{
    public partial class UpdateCustomer : Form
    {
        private BaseC _BaseCtrl;
        private Point mousePoint;
        private Customer _SelectedData;
        private List<Customer> _LCCUS;
        private CustomerView _CustomerView;

        public UpdateCustomer(CustomerView CustomerView)
        {
            _BaseCtrl = new BaseC();
            _SelectedData = new Customer();
            _CustomerView = CustomerView;

            InitializeComponent();

            SetGroup();
            SetDgvCompany();
        }
        public List<Customer> Customers
        {
            get { return _LCCUS; }
            set { _LCCUS = value; }
        }
        private void SetGroup()
        {
            cb_customer_Select.Items.Clear();
            cb_Customer_Group.Items.Clear();
            cb_customer_Select.Items.Add("모두");

            if (_BaseCtrl.GroupList != null)
                foreach (string str in _BaseCtrl.GroupList)
                {
                    cb_customer_Select.Items.Add(str);
                    cb_Customer_Group.Items.Add(str);
                }

            cb_customer_Select.SelectedIndex = 0;
            cb_Customer_Group.SelectedIndex = 0;
        }
        #region 검색 DGV
        public void SetDgvCompany()
        {
            dgv_customer.Rows.Clear();

            _BaseCtrl.GetDgvCustomer();
            Customers = _BaseCtrl.Customers;

            if (Customers != null)
            {
                foreach (Customer cus in Customers)
                {
                    dgv_customer.Rows.Add(cus.CustomerNo, cus.CustomerGroup, cus.CustomerName, cus.CustomerGoods, cus.CustomerAddress, cus.CustomerNumber,
                                          cus.CustomerFax, cus.CustomerMemo);
                }
            }
        }
        private void dgv_customer_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedRows.Count != 0)
            {
                DataGridViewRow dgvr = dgv.SelectedRows[0];

                if (!(dgvr.Cells[0].Value is null))
                {
                    _SelectedData.CustomerNo = (int)dgvr.Cells[0].Value;
                    _SelectedData.CustomerGroup = dgvr.Cells[1].Value.ToString();
                    _SelectedData.CustomerName = dgvr.Cells[2].Value.ToString();
                    _SelectedData.CustomerGoods = dgvr.Cells[3].Value.ToString();
                    _SelectedData.CustomerAddress = dgvr.Cells[4].Value.ToString();
                    _SelectedData.CustomerNumber = dgvr.Cells[5].Value.ToString();
                    _SelectedData.CustomerFax = dgvr.Cells[6].Value.ToString();
                    _SelectedData.CustomerMemo = dgvr.Cells[7].Value.ToString();
                }
            }
            SetSelectData();
        }
        private void SetSelectData()
        {
            txt_Cusomer_No.Text = _SelectedData.CustomerNo.ToString();
            txt_Customer_Address.Text = _SelectedData.CustomerAddress;
            txt_Customer_Memo.Text = _SelectedData.CustomerMemo;
            txt_Customer_Name.Text = _SelectedData.CustomerName;
            txt_Customer_Number.Text = _SelectedData.CustomerNumber;
            cb_Customer_Group.Text = _SelectedData.CustomerGroup;
            tb_Fax.Text = _SelectedData.CustomerFax;
            tb_Goods.Text = _SelectedData.CustomerGoods;
        }
        #endregion
        private void SetAlarm(String str)
        {
            Alarm alarm = new Alarm(str);
            alarm.ShowDialog();
        }
        #region 검색 Button
        private void btn_Update_Click(object sender, EventArgs e)
        {
            Customer Cus = new Customer();

            Cus.CustomerNo = Convert.ToInt32(txt_Cusomer_No.Text);
            Cus.CustomerGroup = cb_Customer_Group.Text;
            Cus.CustomerName = txt_Customer_Name.Text;
            Cus.CustomerAddress = txt_Customer_Address.Text;
            Cus.CustomerNumber = txt_Customer_Number.Text;
            Cus.CustomerMemo = txt_Customer_Memo.Text;
            Cus.CustomerGoods = tb_Goods.Text;
            Cus.CustomerFax = tb_Fax.Text;

            _BaseCtrl.ModifyCustomerData(Cus);
            _CustomerView.SetDgvCompany();

            SetAlarm("거래처 정보 수정이 완료 되었습니다.");
            this.Close();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_C_Search_Click(object sender, EventArgs e)
        {
            dgv_customer.Rows.Clear();

            List<Customer> list = _BaseCtrl.Customers;
            if (list != null)
            {
                foreach (Customer cus in list)
                {
                    if (cus.CustomerName.IndexOf(txt_cusomer_searchbox.Text) != -1)
                    {
                        if (cb_customer_Select.SelectedItem.Equals("모두") || cb_customer_Select.SelectedItem.Equals(cus.CustomerGroup))
                            dgv_customer.Rows.Add(cus.CustomerNo, cus.CustomerGroup, cus.CustomerName, cus.CustomerGoods, cus.CustomerAddress, cus.CustomerNumber,
                                      cus.CustomerFax, cus.CustomerMemo);
                    }
                }
            }
            ViewReset();
    }
        private void UpdateCustomer_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void UpdateCustomer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            SetGroup();
            SetDgvCompany();
            ViewReset();
        }
        #endregion
        private void ViewReset()
        {
            cb_customer_Select.SelectedIndex = 0;
            cb_Customer_Group.SelectedIndex = 0;
            txt_Cusomer_No.Text = "";
            txt_cusomer_searchbox.Text = "";
            txt_Customer_Address.Text = "";
            txt_Customer_Memo.Text = "";
            txt_Customer_Name.Text = "";
            txt_Customer_Number.Text = "";
        }
    }
}
