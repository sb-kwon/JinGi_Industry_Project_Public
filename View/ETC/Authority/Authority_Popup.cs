using System;
using Controller;
using Model;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class Authority_Popup : Form
    {
        private MemberAccess _SelectedData;
        private AuthorityC _AuthorityCtrl;
        private Authority_Setting _AuthorityView;
        public Authority_Popup(MemberAccess MemberA, Authority_Setting AuthorityView)
        {
            _SelectedData = MemberA;
            InitializeComponent();

            _AuthorityCtrl = new AuthorityC();
            _AuthorityView = AuthorityView;
            CheckAuthority();
        }
        #region 검색 DGV
        private void CheckAuthority()
        {
            lbl_AName.Text = _SelectedData.Authorityname;

            List<MemberAccess> MemberA = new List<MemberAccess>();
            List<MemberAccess> MemberB = new List<MemberAccess>();
            List<MemberAccess> MemberC = new List<MemberAccess>();
            MemberA = _AuthorityCtrl.AuthorityCheck();
            MemberB = _AuthorityCtrl.AuthorityCheck2();

            foreach (MemberAccess member in MemberA)
            {
                dgv_Location.Rows.Add(member.AuthorityLocation);
            }
            foreach (MemberAccess member in MemberB)
                if (member.Authorityname.Equals(lbl_AName.Text)) MemberC.Add(member);

            for (int i = 0; i < dgv_Location.RowCount; i++)
            {
                foreach (MemberAccess m in MemberC)
                    if (m.AuthorityLocation.Equals(dgv_Location.Rows[i].Cells[0].Value.ToString()))
                    {
                        dgv_Location.Rows[i].DefaultCellStyle.BackColor = Color.FromArgb(224, 240, 254); 
                        dgv_Location.Rows[i].DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 240, 254);
                        dgv_Location.Rows[i].DefaultCellStyle.ForeColor = Color.Black;
                    }
                    else if (dgv_Location.Rows[i].DefaultCellStyle.BackColor != Color.FromArgb(224, 240, 254) && dgv_Location.Rows[i].DefaultCellStyle.SelectionBackColor != Color.FromArgb(224, 240, 254))
                    {
                        dgv_Location.Rows[i].DefaultCellStyle.BackColor = Color.White;
                        dgv_Location.Rows[i].DefaultCellStyle.SelectionBackColor = Color.White;
                    }
            }
        }
        private void dgv_Location_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex != -1)
            {

                if (dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor == Color.FromArgb(224, 240, 254))
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
                    dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.White;
                    dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
                }
                else
                {
                    dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.FromArgb(224, 240, 254);
                    dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.FromArgb(224, 240, 254);
                    dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionForeColor = Color.Black;
                }

            }
        }
        private void DGVClear()
        {
            dgv_Location.ClearSelection();
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Authority_Popup_Load(object sender, EventArgs e)
        {
            DGVClear();
        }
        #endregion
        #region 검색 Button
        private void btn_Update_Click(object sender, EventArgs e)
        {
            List<MemberAccess> InsertList = new List<MemberAccess>();
            List<MemberAccess> DeleteList = new List<MemberAccess>();

            if (dgv_Location.Rows.Count != 0)
            {
                bool check = false;
                foreach (DataGridViewRow dgvr in dgv_Location.Rows)
                {
                    if (dgvr.Cells[0].Value.Equals("")) check = true;
                }
                if (check)
                {
                    MessageBox.Show("권한을 선택해 주세요.");
                }
                else
                {

                    foreach (DataGridViewRow dgvr in dgv_Location.Rows)
                    {
                        if (dgvr.DefaultCellStyle.BackColor == Color.FromArgb(224, 240, 254) || dgvr.DefaultCellStyle.SelectionBackColor == Color.FromArgb(224, 240, 254))
                        {
                            if (_SelectedData.Authorityname is null) InsertList.Add(InsertAuthority(dgvr));
                            else if (lbl_AName.Text == _SelectedData.Authorityname) InsertList.Add(InsertAuthority(dgvr));
                        }
                        else if (dgvr.DefaultCellStyle.BackColor == Color.White || dgvr.DefaultCellStyle.SelectionBackColor == Color.White) DeleteList.Add(InsertAuthority(dgvr));
                    }
                    _AuthorityCtrl.InDelAuthority(InsertList, DeleteList);
                }
            }
            _AuthorityView.SetAuthorityDGV();
            this.Close();
        }
        private MemberAccess InsertAuthority(DataGridViewRow dgvr)
        {
            MemberAccess MA = new MemberAccess();
            MA.Authorityname = _SelectedData.Authorityname;

            if (dgvr.Cells[0].Value is null) MA.AuthorityLocation = "";
            else MA.AuthorityLocation = dgvr.Cells[0].Value.ToString();

            return MA;
        }
        #endregion
    }
}
