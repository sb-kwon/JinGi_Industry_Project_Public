using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using View.UserController;

namespace View
{
    public partial class Authority_Setting : Form, IBasicForm
    {
        private BaseC _BaseCtrl;
        private Member _LoginInfo;
        private BasicForm _Mother;
        private String _Memberview;
        private List<Def> _DefList;
        private List<Member> _LMMB;
        private List<MemberAccess> _MA;
        private Member _SelectedData;
        private MemberView _MemberForm;
        private MemberAccess _SelectData;
        private AuthorityC _AuthorityCtrl;
        private Member_Ctrl _MemberController;
        public Authority_Setting(Member member, BasicForm form)
        {
            InitializeComponent();
            _Memberview = "";
            _Mother = form;
            _LoginInfo = member;
            _BaseCtrl = new BaseC();
            _SelectedData = new Member();
            _SelectData = new MemberAccess();
            _AuthorityCtrl = new AuthorityC();
            _MemberController = new Member_Ctrl();
            _MemberForm = new MemberView(member, form);

            SetDGV();
            SetAuthorityDGV();
            SetTables();
        }
        #region IBasicForm
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            SetDGV();
            DGVClear();
            SetAuthorityDGV();
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
        public Def Def { get; set; }
        public List<Def> DefList
        {
            get
            {
                return _DefList;
            }
            set
            {
                _DefList = value;
                SetViewTable();
            }
        }
        public List<MemberAccess> MA
        {
            get { return _MA; }
            set { _MA = value; }
        }
        private void GetAuthority()
        {
            _AuthorityCtrl.GetAuthorityList();
            MA = _AuthorityCtrl.MemberAccess;
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
        private void Authority_Setting_Load(object sender, EventArgs e)
        {
            DGVClear();
            if (_AuthorityCtrl.GetAuthority(_LoginInfo.MemberAccess.Authorityname, "권한 설정"))
            {
                ;
            }
            else
            {
                _Mother.btn_Close_Click(sender, e);
                Alarm("권한이 없습니다.");
            }
        }
        private void DGVClear()
        {
            dgv_member.ClearSelection();
            dgv_Authority.ClearSelection();
        }
        public void SetAuthorityDGV()
        {
            dgv_Authority.Rows.Clear();
            GetAuthority();

            foreach (MemberAccess MA in MA)
            {
                dgv_Authority.Rows.Add(MA.Authorityname, MA.AuthorityLocation);
            }
        }
        public void SetDGV()
        {
            dgv_member.Rows.Clear();
            GetMember();

            foreach (Member mem in Members)
            {
                dgv_member.Rows.Add(mem.Membername, mem.Rankname, mem.Memberid, mem.Membernumber, mem.MemberAccess.Authorityname);
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
                    _SelectedData.Membername = dgvr.Cells[0].Value.ToString();
                    _SelectedData.Rankname = dgvr.Cells[1].Value.ToString();
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
        private void dgv_Authority_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedRows.Count != 0)
            {
                DataGridViewRow dgvr = dgv.SelectedRows[0];

                if (!(dgvr.Cells[0].Value is null))
                {
                    _SelectData.Authorityname = dgvr.Cells[0].Value.ToString();
                }
            }
        }
        #endregion
        #region GetDef
        private void SetViewTable()
        {
            foreach (Object ob in this.Controls)
            {
                if (ob.GetType().Name.ToString().Equals("DefBoard"))
                {
                    DefBoard defBoard = (DefBoard)ob;

                    foreach (Def def in DefList)
                    {
                        if (def.TableLogical != null)
                        {
                            if (def.TableLogical.Equals(defBoard.Name))
                            {
                                defBoard.Def = def;
                            }
                        }
                    }
                }
            }
        }
        private void SetTables()
        {
            DefList = _BaseCtrl.GetDefList(FindDefBoard());
        }
        private List<String> FindDefBoard()
        {
            List<String> list = new List<string>();
            foreach (Object ob in this.Controls)
            {
                if (ob.GetType().Name.ToString().Equals("DefBoard"))
                {
                    DefBoard defBoard = (DefBoard)ob;
                    list.Add(defBoard.Name);
                }
            }
            return list;
        }
        private void def_GetData(object sender, EventArgs e)
        {
            DefBoard db = (DefBoard)sender;
            Def = db.Def;

            lbl_Table.Text = db.Def.TableName;
            lbl_Value.Text = "";
        }

        private void def_GetSelect(object sender, EventArgs e)
        {
            DefBoard db = (DefBoard)sender;
            Def = db.Def;

            lbl_Table.Text = Def.TableName;
            lbl_Value.Text = Def.SelectValue;
        }
        #endregion
        #region 검색 Alarm
        private void Alarm(String str)
        {
            Alarm Alarm = new Alarm(str);
            Alarm.ShowDialog();
        }
        #endregion
        #region 검색 Button
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
                    SetDGV();
                }
                else
                {
                    if (member.Count != 0)
                    {
                        foreach (Member members in member)
                        {
                            dgv_member.Rows.Add(members.Membername, members.Rankname, members.Memberid, members.Membernumber, members.MemberAccess.Authorityname);
                        }
                    }
                    else
                    {
                        Alarm("검색 된 내용이 없습니다.");
                        tb_SelectData.Text = string.Empty;
                        SetDGV();
                    }
                }
            }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (lbl_Table.Text.Length != 0)
            {
                DefAddUpdate DAU = new DefAddUpdate(Def.TableName + " 테이블 항목추가 ", Def, false, _BaseCtrl);

                DAU.StartPosition = FormStartPosition.Manual;
                DAU.Location = new Point(this.Width / 2 - 100, this.Height / 2 - 150);
                DAU.ShowDialog();

                SetTables();
                SetViewTable();
                Reset();
            }
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (lbl_Table.Text.Length != 0 && lbl_Value.Text.Length != 0 && _BaseCtrl.DefCheck(Def))
            {
                DefAddUpdate DAU = new DefAddUpdate(Def.TableName + " 테이블 항목수정 \n 기존값 : " + Def.SelectValue, Def, true, _BaseCtrl);

                DAU.StartPosition = FormStartPosition.Manual;
                DAU.Location = new Point(this.Width / 2 - 100, this.Height / 2 - 150);
                DAU.ShowDialog();

                SetTables();
                SetViewTable();
                Reset();
            }
            else if (!_BaseCtrl.DefCheck(Def))
            {
                MessageBox.Show("해당 항목은 변경 불가 합니다.");
            }
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (lbl_Table.Text.Length != 0 && lbl_Value.Text.Length != 0 && _BaseCtrl.DefCheck(Def))
            {
                DefAddUpdate DAU = new DefAddUpdate(Def.TableName + " 테이블 항목삭제 \n 기존값 : " + Def.SelectValue, Def, null, _BaseCtrl);

                DAU.StartPosition = FormStartPosition.Manual;
                DAU.Location = new Point(this.Width / 2 - 100, this.Height / 2 - 150);
                DAU.ShowDialog();

                SetTables();
                SetViewTable();
                Reset();
            }
            else if (!_BaseCtrl.DefCheck(Def))
            {
                MessageBox.Show("해당 항목은 변경 불가 합니다.");
            }
        }
        private void btn_Athority_Update_Click(object sender, EventArgs e)
        {
            Authority_Popup AP = new Authority_Popup(_SelectData, this);
            AP.StartPosition = FormStartPosition.Manual;
            AP.Location = new Point(this.Width / 2 - 100, this.Height / 2 - 150);
            AP.ShowDialog();
        }
        private void btn_Member_Update_Click(object sender, EventArgs e)
        {
            String str = btn_Member_Update.Tag.ToString();

            UpdateMember UM = new UpdateMember(_Memberview, _MemberForm, this, str);
            UM.StartPosition = FormStartPosition.Manual;
            UM.Location = new Point(this.Width / 2 - 100, this.Height / 2 - 150);
            UM.ShowDialog();
        }
        #endregion
        private void Reset()
        {
            cb_SelectBox.Text = null;
            tb_SelectData.Text = string.Empty;
            lbl_Table.Text = string.Empty;
            lbl_Value.Text = string.Empty;
            DGVClear();
        }
    }
}