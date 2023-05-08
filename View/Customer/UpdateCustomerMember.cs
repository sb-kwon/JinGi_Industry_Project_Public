using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class UpdateCustomerMember : Form
    {
        private int _No, _CMNo;
        private BaseC _BaseCtrl;
        private CustomerMember _SelectedData;
        private List<CustomerMember> _LCM;
        private CustomerView _CustomerView;

        public UpdateCustomerMember(int CustomerNo, int CMNo, CustomerView CustomerView)
        {
            _BaseCtrl = new BaseC();
            _SelectedData = new CustomerMember();
            _CustomerView = CustomerView;
            _No = CustomerNo;
            _CMNo = CMNo;

            InitializeComponent();
            SetRank();
            CMLoad(_No, _CMNo);
        }
        public List<CustomerMember> CustomerMember
        {
            get { return _LCM; }
            set { _LCM = value; }
        }
        private void CMLoad(int CustomerNo, int CMNo)
        {
            _BaseCtrl.CustomerName(CustomerNo, CMNo);
            CustomerMember = _BaseCtrl.CustomerMember;

            if (CustomerMember is null)
            {
                ;
            }
            else
            {
                foreach (CustomerMember CM in CustomerMember)
                {
                    txt_CustomerNo.Text = _No.ToString();
                    txt_CM_Name.Text = CM.CustomerMemberName;
                    txt_CM_Number.Text = CM.CustomerMemberNumber;
                    txt_CM_Mail.Text = CM.CustomerMembereMail;
                    txt_CM_Memo.Text = CM.CustomerMemberMemo;
                    Cb_CM_Rank.Text = CM.RankName;
                    lbl_CM_No.Text = CM.CustomerMemberNo.ToString();

                    CustomerNo = CM.CustomerMemberNo;
                }
            }
            CustomerNo = Convert.ToInt32(CustomerNo);

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
        private void SetRank()
        {
            txt_CustomerNo.Text = _No.ToString();
            Cb_CM_Rank.Items.Clear();

            List<String> Group = _BaseCtrl.GetRankList();

            foreach (string str in Group)
            {
                Cb_CM_Rank.Items.Add(str);
            }
        }
        private void SetAlarm(String str)
        {
            Alarm alarm = new Alarm(str);
            alarm.ShowDialog();
        }
        #region 검색 Button
        private void btn_Update_Click(object sender, EventArgs e)
        {
            CustomerMember CM = new CustomerMember();

            CM.CustomerNo = Convert.ToInt32(txt_CustomerNo.Text);
            CM.CustomerMemberNo = Convert.ToInt32(lbl_CM_No.Text);
            CM.CustomerMemberName = txt_CM_Name.Text;
            CM.CustomerMemberNumber = txt_CM_Number.Text;
            CM.CustomerMembereMail = txt_CM_Mail.Text;
            CM.CustomerMemberMemo = txt_CM_Memo.Text;
            CM.RankName = Cb_CM_Rank.Text;

            _BaseCtrl.ModifyCusMemberData(CM);
            _CustomerView.SetDgvCompany();

            SetAlarm("거래처 담당자 정보 수정이 완료 되었습니다.");
            this.Close();
        }

        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
    }
}
