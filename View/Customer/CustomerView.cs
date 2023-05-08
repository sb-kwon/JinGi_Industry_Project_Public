using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;

using Controller;
using Model;

namespace View
{
    public partial class CustomerView : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private BaseC _BaseCtrl;
        private List<Customer> _LCCUS;
        private List<CustomerMember> _LCMB;
        public Customer _SelectDataCustomer;
        private CustomerMember _SelectDataCusMember;

        public CustomerView(Member member, BasicForm form)
        {
            InitializeComponent();

            _LoginInfo = member;
            _Mother = form;
            _BaseCtrl = new BaseC();

            _SelectDataCustomer = new Customer();
            _SelectDataCusMember = new CustomerMember();

            SetDgvCompany();
        }
        public List<Customer> Customers
        {
            get { return _LCCUS; }
            set { _LCCUS = value; }
        }
        public List<CustomerMember> CustomerMembers
        {
            get { return _LCMB; }
            set { _LCMB = value; }
        }
        #region 검색 DGV
        public void SetDgvCompany()
        {
            SetCombobox();
            dgv_customer.Rows.Clear();
            dgv_customermember.Rows.Clear();

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
        public void SetDgvMember(Customer _SelectDataCustomer)
        {
            dgv_customermember.Rows.Clear();

            _BaseCtrl.GetDgvMember(_SelectDataCustomer.CustomerNo);
            CustomerMembers = _BaseCtrl.CustomerMembers;

            if (CustomerMembers is null)
            {
                ;
            }
            else
            {
                foreach (CustomerMember cusmem in CustomerMembers)
                {
                    dgv_customermember.Rows.Add(cusmem.CustomerNo, cusmem.CustomerMemberName, cusmem.RankName, cusmem.CustomerMemberNumber, cusmem.CustomerMembereMail, cusmem.CustomerMemberMemo, cusmem.CustomerMemberNo);
                    _SelectDataCusMember.CustomerMemberNo = cusmem.CustomerMemberNo;
                }
            }
            _SelectDataCusMember.CustomerNo = Convert.ToInt32(_SelectDataCustomer.CustomerNo);

            string tableName = "def_rank";
            string tabletype = "RankName";

            List<String> list = new List<string>();
            list = _BaseCtrl.ComboboxListCollection(tableName, tabletype);

            if (!(list is null))
            {
                foreach (string str in list)
                {
                }
                list.Clear();
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
                    _SelectDataCustomer.CustomerNo = (int)dgvr.Cells[0].Value;
                    Btn_CM_Add.Enabled = Btn_CM_Update.Enabled = Btn_CM_Delete.Enabled = true;
                }
            }
            SetDgvMember(_SelectDataCustomer);
        }
        private void dgv_customermember_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedRows.Count != 0)
            {
                DataGridViewRow dgvr = dgv.SelectedRows[0];

                if (!(dgvr.Cells[0].Value is null))
                {
                    _SelectDataCusMember.CustomerMemberNo = (int)dgvr.Cells[6].Value;
                }
            }
        }
        #endregion
        //검색
        #region IBasicForm
        private void ResetCustomer()
        {
            txt_cusomer_searchbox.Text = string.Empty;
            cb_customer_Select.SelectedIndex = 0;
            Btn_CM_Add.Enabled = Btn_CM_Update.Enabled = Btn_CM_Delete.Enabled = false;
        }
        public Form SetForm()
        {
            return this;
        }
        public string GetText()
        {
            return this.Text;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }
        public void RefreshForm()
        {
            SetDgvCompany();
            ResetCustomer();
        }
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.ShowDialog();
        }
        private void SetCDAlram(String str)
        {
            DeleteCustomer DC = new DeleteCustomer(_SelectDataCusMember.CustomerNo, str, this);
            DC.StartPosition = FormStartPosition.CenterParent;
            DC.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            DC.ShowDialog();
        }
        private void SetCMDAlram(String str)
        {
            DeleteCM DCM = new DeleteCM(_SelectDataCusMember.CustomerMemberNo, str, this);
            DCM.StartPosition = FormStartPosition.CenterParent;
            DCM.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            DCM.ShowDialog();
        }
        private void SetCombobox()
        {
            cb_customer_Select.Items.Clear();
            cb_customer_Select.Items.Add("모두");

            if (_BaseCtrl.GroupList != null)
                foreach (string str in _BaseCtrl.GroupList)
                    cb_customer_Select.Items.Add(str);

            cb_customer_Select.SelectedIndex = 0;
        }
#endregion
        #region 검색 Button
        private void btn_search_Click(object sender, EventArgs e)
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
                ResetCustomer();
            }
        private void Btn_CM_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_customermember.SelectedRows.Count == 0)
            {
                SetCMDAlram("담당자를 선택해 주세요");
            }
            else SetCMDAlram("정말 삭제하시겠습니까?");
        }
        private void Btn_CM_Update_Click(object sender, EventArgs e)
        {
            UpdateCustomerMember UpdateCustomerManager = new UpdateCustomerMember(_SelectDataCusMember.CustomerNo, _SelectDataCusMember.CustomerMemberNo, this);

            UpdateCustomerManager.StartPosition = FormStartPosition.CenterParent;
            UpdateCustomerManager.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            UpdateCustomerManager.ShowDialog();
        }
        private void Btn_CM_Add_Click(object sender, EventArgs e)
        {
            if (_SelectDataCusMember.CustomerNo == 0)
            {
                SetAlarm("거래처 정보를 선택해 주세요!");
            }
            else
            {
                AddCustomerMember AddCustomerManager = new AddCustomerMember(_SelectDataCusMember.CustomerNo, this);

                AddCustomerManager.StartPosition = FormStartPosition.CenterParent;
                AddCustomerManager.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                AddCustomerManager.ShowDialog();
            }
        }
        private void Btn_C_Add_Click(object sender, EventArgs e)
        {
            AddCustomer AddCustomer = new AddCustomer(this);

            AddCustomer.StartPosition = FormStartPosition.CenterParent;
            AddCustomer.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            AddCustomer.ShowDialog();
        }
        private void Btn_C_Update_Click(object sender, EventArgs e)
        {
            UpdateCustomer UpdateCustomer = new UpdateCustomer(this);

            UpdateCustomer.StartPosition = FormStartPosition.CenterParent;
            UpdateCustomer.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            UpdateCustomer.ShowDialog();
        }
        private void Btn_C_Delete_Click(object sender, EventArgs e)
        {
            if (dgv_customer.SelectedRows.Count == 0)
            {
                SetCDAlram("거래처를 선택해 주세요");
            }
            else SetCDAlram("정말 삭제하시겠습니까?");
        }
        #endregion        
    }
}