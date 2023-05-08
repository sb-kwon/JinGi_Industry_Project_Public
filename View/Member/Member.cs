using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
namespace View
{
    public partial class MemberView : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private List<Member> _LMMB;
        private String _Memberview;
        private Member _SelectedData;
        private Member_Ctrl _MemberController;
        private Authority_Setting _AuthorityView;
        public MemberView(Member member, BasicForm form)
        {
            InitializeComponent();

            _MemberController = new Member_Ctrl();
            _Memberview = "";
            _Mother = form;
            _LoginInfo = member;
            _SelectedData = new Member();

            SetDGV();
        }
        public List<Member> Members
        {
            get { return _LMMB; }
            set { _LMMB = value; }
        }
        private void GetMember()
        {
            _MemberController.GetMember();
            Members = _MemberController.Members;
        }
        #region 검색 DGV
        public void SetDGV()
        {
            dgv_member.Rows.Clear();
            GetMember();

            foreach (Member mem in Members)
            {
                dgv_member.Rows.Add(mem.MemberNo, mem.Membername, mem.Memberid, mem.Membernumber, mem.Rankname, mem.MemberAddress, mem.MemberBirth,
                                    mem.MemberJoinDate, mem.MemberETC, mem.MemberAccess.Authorityname);
            }
        }
        private void dgv_member_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedRows.Count != 0)
            {
                DataGridViewRow dgvr = dgv.SelectedRows[0];

                if (!(dgvr.Cells[0].Value is null))
                {
                    _SelectedData.Membername = dgvr.Cells[1].Value.ToString();
                    _SelectedData.Rankname = dgvr.Cells[4].Value.ToString();
                    _SelectedData.Memberid = dgvr.Cells[2].Value.ToString();
                    _SelectedData.Membernumber = dgvr.Cells[3].Value.ToString();
                }
            }
            if (!(e.RowIndex == -1))
            {
                DataGridViewRow rows = dgv.Rows[e.RowIndex];
                _Memberview = rows.Cells[2].Value.ToString();
            }
        }
        #endregion
        #region IBasicForm
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            SetDGV();
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
        #region 검색 Alarm
        private void SetAlarm(String str)
        {
            MemberDeleteAlram alarm = new MemberDeleteAlram(str, _Memberview, this);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
        private void Alarm(String str)
        {
            Alarm Alarm = new Alarm(str);
            Alarm.ShowDialog();
        }
        #endregion
        #region 검색 Button
        private void btn_Update_Click(object sender, EventArgs e)
        {
            String str = btn_Update.Tag.ToString();
            _AuthorityView = new Authority_Setting(_LoginInfo, _Mother);

            UpdateMember memberupdate = new UpdateMember(_Memberview, this, _AuthorityView, str);

            memberupdate.StartPosition = FormStartPosition.CenterParent;
            memberupdate.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            memberupdate.ShowDialog();
        }
        private void btn_Delete_Apply_Click(object sender, EventArgs e)
        {
            if (dgv_member.SelectedRows.Count == 0)
            {
                SetAlarm("사원을 선택해 주세요");
            }
            SetAlarm("정말 삭제하시겠습니까?");
            SetDGV();
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (!(cb_SelectBox.SelectedIndex == -1))
            {
                String Value = cb_SelectBox.SelectedItem.ToString();
                string result = "";
                switch (Value)
                {
                    case "ID":
                        result = "M.memberId";
                        break;
                    case "이름":
                        result = "M.memberName";
                        break;
                    case "직급":
                        result = "M.RankName";
                        break;
                    case "전화번호":
                        result = "M.memberNumber";
                        break;
                }
                dgv_member.Rows.Clear();

                List<Member> member = new List<Member>();
                member = _MemberController.SearchData(result, tb_SelectData.Text);

                if (member is null || string.IsNullOrEmpty(tb_SelectData.Text))
                {
                    Alarm("검색어를 입력해주세요.");
                }
                else
                {
                    if (member.Count != 0)
                    {
                        foreach (Member members in member)
                        {
                            dgv_member.Rows.Add(members.MemberNo, members.Membername, members.Memberid, members.Membernumber, members.Rankname, members.MemberAddress, members.MemberBirth,
                                                members.MemberJoinDate, members.MemberETC, members.MemberAccess.Authorityname);
                        }
                    }
                    else
                    {
                        Alarm("검색 된 내용이 없습니다.");
                        SetDGV();
                        tb_SelectData.Text = string.Empty;
                    }
                }
                Reset();
            }
        }
        #endregion
        private void Reset()
        {
            cb_SelectBox.Text = null;
            tb_SelectData.Text = string.Empty;
        }
    }
}