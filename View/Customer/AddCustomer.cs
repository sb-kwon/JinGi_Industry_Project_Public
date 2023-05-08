using System.Collections.Generic;
using System;
using System.Text;
using Controller;
using Model;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public partial class AddCustomer : Form
    {
        private List<Customer> _LCCUS;
        private Customer _SelectData;
        private BaseC _BaseCtrl;
        private Point mousePoint;
        private CustomerView _CustomerView;
        public AddCustomer(CustomerView CustomerView)
        {
            _BaseCtrl = new BaseC();
            _SelectData = new Customer();
            _CustomerView = CustomerView;

            InitializeComponent();
            CLoad();
        }
        public List<Customer> Customers
        {
            get { return _LCCUS; }
            set { _LCCUS = value; }
        }
        private void CLoad()
        {
            _BaseCtrl.LastCustomerCode();
            Customers = _BaseCtrl.Customers;

            foreach (Customer cus in Customers)
                txt_Cusomer_No.Text = cus.CustomerNo.ToString();

            cb_Customer_Group.Items.Clear();

            if (_BaseCtrl.GroupList != null)
                foreach (string str in _BaseCtrl.GroupList)
                    cb_Customer_Group.Items.Add(str);

            cb_Customer_Group.SelectedIndex = 0;
        }
        #region 검색 Button
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_C_Add_Click(object sender, EventArgs e)
        {
            SelectData();

            Customer cus = new Customer();

            cus.CustomerNo = _SelectData.CustomerNo;
            cus.CustomerAddress = _SelectData.CustomerAddress;
            cus.CustomerMemo = _SelectData.CustomerMemo;
            cus.CustomerName = _SelectData.CustomerName;
            cus.CustomerNumber = _SelectData.CustomerNumber;
            cus.CustomerGroup = _SelectData.CustomerGroup;
            cus.CustomerGoods = _SelectData.CustomerGoods;
            cus.CustomerFax = _SelectData.CustomerFax;

            _BaseCtrl.AddCustomerData(cus);
            _CustomerView.SetDgvCompany();
            SetAlarm("거래처 정보 추가가 완료 되었습니다.");

            ViewReset();
            this.Close();
        }
        private void AddCustomer_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }
        private void AddCustomer_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        #endregion
        private void SelectData()
        {
            _SelectData.CustomerNo = Convert.ToInt32(txt_Cusomer_No.Text);
            _SelectData.CustomerAddress = txt_Customer_Address.Text;
            _SelectData.CustomerMemo = txt_Customer_Memo.Text;
            _SelectData.CustomerName = txt_Customer_Name.Text;
            _SelectData.CustomerNumber = txt_Customer_Number.Text;
            _SelectData.CustomerGroup = cb_Customer_Group.Text;
            _SelectData.CustomerFax = tb_Fax.Text;
            _SelectData.CustomerGoods = tb_Goods.Text;
        }
        private void ViewReset()
        {
            txt_Cusomer_No.Text = "";
            txt_Customer_Address.Text = "";
            txt_Customer_Memo.Text = "";
            txt_Customer_Name.Text = "";
            txt_Customer_Number.Text = "";
            cb_Customer_Group.Text = "";
            tb_Goods.Text = "";
            tb_Fax.Text = "";
        }
        private void SetAlarm(String str)
        {
            Alarm alarm = new Alarm(str);
            alarm.ShowDialog();
        }
    }
}
