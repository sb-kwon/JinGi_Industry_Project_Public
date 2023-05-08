using Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using Model;

namespace View
{
    public partial class UpdateMember : Form
    {
        private List<Member> _LMMB;
        private BaseC _BaseCtrl;
        private String _memberId;
        private Point mousePoint;
        private String _ButtonTag;
        private Member _SelectedData;
        private MemberView _memberview;
        private Member_Ctrl _MemberController;
        private Authority_Setting _AuthorityView;
        public UpdateMember(String memberId, MemberView memberview, Authority_Setting AuthorityView, String str)
        {
            InitializeComponent();

            _ButtonTag = str;
            _memberId = memberId;
            _memberview = memberview;
            _AuthorityView = AuthorityView;
            _BaseCtrl = new BaseC();
            _SelectedData = new Member();
            _MemberController = new Member_Ctrl();

            SetPanel();
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
        private void SetDGV()
        {
            dgv_member.Rows.Clear();
            GetMember();
            Reset();

            foreach (Member mem in Members)
            {
                dgv_member.Rows.Add(mem.MemberNo, mem.Membername, mem.Memberid, mem.Membernumber, mem.Rankname, mem.MemberAddress, mem.MemberBirth,
                                    mem.MemberJoinDate, mem.MemberETC, mem.MemberAccess.Authorityname);
            }

            List<String> rank = _BaseCtrl.GetRankList();
            cb_Update_Rank.Items.Clear();

            foreach (String str in rank)
            {
                cb_Update_Rank.Items.Add(str);
            }

            List<String> Authority = _BaseCtrl.GetAuthority();
            cb_Authority.Items.Clear();

            foreach (String str in Authority)
            {
                cb_Authority.Items.Add(str);
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
                    _SelectedData.Memberid = dgvr.Cells[2].Value.ToString();
                    _SelectedData.Membernumber = dgvr.Cells[3].Value.ToString();
                    _SelectedData.Rankname = dgvr.Cells[4].Value.ToString();
                    _SelectedData.MemberAddress = dgvr.Cells[5].Value.ToString();
                    _SelectedData.MemberBirth = dgvr.Cells[6].Value.ToString();
                    _SelectedData.MemberJoinDate = dgvr.Cells[7].Value.ToString();
                    _SelectedData.MemberETC = dgvr.Cells[8].Value.ToString();
                    _SelectedData.MemberAccess.Authorityname = dgvr.Cells[9].Value.ToString();
                }
            }
            SetSelectData();
        }
        #endregion
        private void Reset()
        {
            tb_Update_ID.Clear();
            tb_Update_Name.Clear();
            tb_Update_Number.Clear();
            tb_Address.Clear();
            tb_ETC.Clear();
            DTP_Birth.Text = "";
            DTP_Join.Text = "";
            cb_Update_Rank.Text = "";
            cb_SelectBox.Text = null;
            tb_SelectData.Clear();
        }
        private void SetAlarm(String str)
        {
            Alarm alarm = new Alarm(str);
            alarm.ShowDialog();
        }
        private void SetSelectData()
        {
            tb_Update_Name.Text = _SelectedData.Membername;
            tb_Update_ID.Text = _SelectedData.Memberid;
            tb_Update_Number.Text = _SelectedData.Membernumber;
            cb_Update_Rank.Text = _SelectedData.Rankname;
            tb_Address.Text = _SelectedData.MemberAddress;
            tb_ETC.Text = _SelectedData.MemberETC;
            DTP_Birth.Text = _SelectedData.MemberBirth;
            DTP_Join.Text = _SelectedData.MemberJoinDate;
            cb_Authority.Text = _SelectedData.MemberAccess.Authorityname;
        }
        private void SetPanel()
        {
            if (_ButtonTag.Equals(panel1.Tag))
            {
                panel2.Visible = false;
                panel1.Visible = true;
            }
            else if (_ButtonTag.Equals(panel2.Tag))
            {
                panel1.Visible = false;
                panel2.Visible = true;
            }
        }
        #region 검색 Button
        private void btn_Update_Click(object sender, EventArgs e)
        {
            Member member = new Member();

            member.Membername = tb_Update_Name.Text;
            member.Memberid = tb_Update_ID.Text;
            member.Membernumber = tb_Update_Number.Text;
            member.Rankname = cb_Update_Rank.Text;
            member.MemberAddress = tb_Address.Text;
            if (panel2.Visible is true)
            {
                member.MemberBirth = _SelectedData.MemberBirth;
                member.MemberJoinDate = _SelectedData.MemberJoinDate; ;
            }
            else
            {
                member.MemberBirth = DTP_Birth.Text;
                member.MemberJoinDate = DTP_Join.Text;
            }
            member.MemberETC = tb_ETC.Text;
            member.MemberAccess.Authorityname = cb_Authority.Text;
            member.MemberAccess.Memberpwfailcnt = 1;

            _MemberController.UpdateMember(member);

            SetDGV();
            _memberview.SetDGV();
            _AuthorityView.SetDGV();
            SetAlarm("사원 정보 수정이 완료 되었습니다.");
            Reset();
        }
        private void Btn_LoginCount_Click(object sender, EventArgs e)
        {
            Member member = new Member();
            member.MemberAccess.Memberpwfailcnt = 1;
            member.Memberid = tb_Update_ID.Text;

            _MemberController.RefreshCount(member);
            SetAlarm("정지 풀림 ㅊㅋㅊㅋ");
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
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
                    SetAlarm("검색어를 입력해주세요.");
                    SetDGV();
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
                        SetAlarm("검색 된 내용이 없습니다.");
                        SetDGV();
                        tb_SelectData.Text = string.Empty;
                    }
                }
                Reset();
            }
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            SetDGV();
        }
        private void UpdateMember_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void UpdateMember_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }
        private void pnl_Update_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void pnl_Update_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }
        #endregion
    }
}