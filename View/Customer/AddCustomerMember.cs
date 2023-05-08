using System.Collections.Generic;
using System;
using System.Drawing;
using System.Text;
using Controller;
using Model;
using System.Windows.Forms;

namespace View
{
    public partial class AddCustomerMember : Form
    {
        private int _No;
        private BaseC _BaseCtrl;
        private Point mousePoint;
        private List<Customer> _LCCUS;
        private List<CustomerMember> _LCMB;
        private CustomerMember _SelectData;
        private CustomerView _CustomerView;

        public AddCustomerMember(int CustomerNo, CustomerView CustomerView)
        {
            _BaseCtrl = new BaseC();
            _SelectData = new CustomerMember();
            _CustomerView = CustomerView;
            _No = CustomerNo;

            InitializeComponent();
            CLoad();
        }
        private void CLoad()
        {
            txt_CustomerNo.Text = _No.ToString();
            Cb_CM_Rank.Items.Clear();

            List<String> Group = _BaseCtrl.GetRankList();

            foreach (string str in Group)
            {
                Cb_CM_Rank.Items.Add(str);
            }
        }
        #region 검색 Button
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_C_Add_Click(object sender, EventArgs e)
        {
            SelectData();

            CustomerMember CM = new CustomerMember();

            CM.CustomerNo = _SelectData.CustomerNo;
            CM.CustomerMembereMail = _SelectData.CustomerMembereMail;
            CM.CustomerMemberMemo = _SelectData.CustomerMemberMemo;
            CM.CustomerMemberName = _SelectData.CustomerMemberName;
            CM.CustomerMemberNumber = _SelectData.CustomerMemberNumber;
            CM.RankName = _SelectData.RankName;

            _BaseCtrl.AddCusMemberData(CM);
            _CustomerView.SetDgvCompany();
            SetAlarm("거래처 담당자 정보 추가가 완료 되었습니다.");

            ViewReset();
            this.Close();
        }
        #endregion
        private void SelectData()
        {
            _SelectData.CustomerNo = Convert.ToInt32(txt_CustomerNo.Text);
            _SelectData.CustomerMembereMail = txt_CM_Mail.Text;
            _SelectData.CustomerMemberMemo = txt_CM_Memo.Text;
            _SelectData.CustomerMemberName = txt_CM_Name.Text;
            _SelectData.CustomerMemberNumber = txt_CM_Number.Text;
            _SelectData.RankName = Cb_CM_Rank.Text;
        }
        private void ViewReset()
        {
            txt_CM_Name.Text = "";
            txt_CM_Mail.Text = "";
            txt_CM_Memo.Text = "";
            txt_CM_Number.Text = "";
            txt_CustomerNo.Text = "";
            Cb_CM_Rank.Text = "";
        }
        private void SetAlarm(String str)
        {
            Alarm alarm = new Alarm(str);
            alarm.ShowDialog();
        }
        private void AddCustomerMember_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void AddCustomerMember_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }
    }
}
