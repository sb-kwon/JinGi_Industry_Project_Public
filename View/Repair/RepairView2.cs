using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Model.Material;

namespace View
{
    public partial class RepairView2 : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private RepairCtrl _RepairCtrl;
        private Repairsituation _RepairSituation;

        public RepairView2(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;
            _RepairCtrl = new RepairCtrl();
            _RepairSituation = new Repairsituation();
            InitializeComponent();

            SetView();
        }
        public void SetView()
        {
            comboBox1.SelectedIndex = 0;

            dgv_situation.Rows.Clear();
            if (_RepairCtrl.RepairsituationList != null)
                foreach (Repairsituation rs in _RepairCtrl.RepairsituationList)
                {
                    dgv_situation.Rows.Add(
                        rs.Repairsituationno,
                        rs.Repairname,
                        SituationResult(rs.Repairsituationdetails),
                        rs.Repairsituationtime,
                        rs.Repairsituationmember,
                        rs.Repairsituationmemo,
                        rs.Repairsituationdetails,
                        rs.RepairsituationHistory
                         );
                }

            if(dgv_situation.Rows.Count != 0)
            {
                if(checkBox1.Checked)
                foreach(DataGridViewRow dgvr in dgv_situation.Rows)
                {
                        if (dgvr.Cells[2].Value.ToString().Equals("양호") || dgvr.Cells[2].Value.ToString().Equals("불량"))
                            dgvr.Visible = false;
                }
            }

            comboBox2.Items.Clear();
            Member_Ctrl mc = new Member_Ctrl();
            mc.GetMember();
            if (mc.Members != null)
                foreach (Member m in mc.Members)
                    comboBox2.Items.Add(m.Membername);

            comboBox2.SelectedIndex = 0;



        }
        private string SituationResult(string value)
        {
            string result = "검사전";
            if (value != null)
            {
                string[] array = value.Split(',');
                foreach (string str in array)
                {
                    string[] array2 = str.Split('_');
                    if (array2.Length == 1) return "검사전";
                    if (array2[1].Equals("n")) return "검사중";
                    if (array2[1].Equals("f")) result = "불량";
                }
                if (!result.Equals("불량"))
                    result = "양호";
            }
            return result;
        }


        #region 검색 basicform
        public string GetText()
        {
            return this.Text;
        }

        public void RefreshForm()
        {
            ;
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
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }

        #region UI




        private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex != -1)
            {
                _RepairSituation.Repairsituationno = (int)dgv.Rows[e.RowIndex].Cells[0].Value;
                _RepairSituation.Repairname = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
                if (dgv.Rows[e.RowIndex].Cells[3].Value is null) _RepairSituation.Repairsituationtime = null;
                else _RepairSituation.Repairsituationtime = (DateTime)dgv.Rows[e.RowIndex].Cells[3].Value;
                _RepairSituation.Repairsituationmember = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                _RepairSituation.Repairsituationmemo = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();
                _RepairSituation.Repairsituationdetails = dgv.Rows[e.RowIndex].Cells[6].Value.ToString();
                _RepairSituation.RepairsituationHistory = (int)dgv.Rows[e.RowIndex].Cells[7].Value;
                foreach (var str in comboBox2.Items.ToString())
                {
                    if (str.ToString().Equals(_RepairSituation.Repairsituationmember))
                        comboBox2.SelectedItem = _RepairSituation.Repairsituationmember;
                }

            }
            if (dgv.Rows[e.RowIndex].Cells[2].Value.ToString().Equals("양호") ||
                dgv.Rows[e.RowIndex].Cells[2].Value.ToString().Equals("불량"))
            {
                textBox2.Enabled = false;
                comboBox2.Enabled = false;
                label7.Enabled = false;
                dataGridView1.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                textBox2.Enabled = true;
                comboBox2.Enabled = true;
                label7.Enabled = true;
                dataGridView1.Enabled = true;
                button1.Enabled = true;
            }

            //값 삽입

            textBox2.Text = _RepairSituation.Repairsituationmemo;
            label7.Text = _RepairSituation.Repairname;

            dataGridView1.Rows.Clear();
            List<string[]> list = _RepairCtrl.GetDefFindList(_RepairSituation.RepairsituationHistory);
            foreach (string[] str in list)
            {
                dataGridView1.Rows.Add(str[0], str[1]);
            }
            string[] value = _RepairSituation.Repairsituationdetails.Split(',');


            foreach (DataGridViewRow dgvr in dataGridView1.Rows)
            {
                DataGridViewCheckBoxCell dgvcbc1 = (DataGridViewCheckBoxCell)dgvr.Cells[2];
                DataGridViewCheckBoxCell dgvcbc2 = (DataGridViewCheckBoxCell)dgvr.Cells[3];
                foreach (string str in value)
                {
                    string[] array2 = str.Split('_');
                    if (array2[0].Equals(dgvr.Cells[0].Value.ToString()))
                        if (array2.Length == 1)
                        {
                            dgvcbc1.Value = false;
                            dgvcbc2.Value = false;
                        }
                        else if (array2[1].Equals("n"))
                        {
                            dgvcbc1.Value = false;
                            dgvcbc2.Value = false;
                        }
                        else if (array2[1].Equals("f"))
                        {
                            dgvcbc1.Value = false;
                            dgvcbc2.Value = true;
                        }
                        else if (array2[1].Equals("t"))
                        {
                            dgvcbc1.Value = true;
                            dgvcbc2.Value = false;
                        }
                }

            }

        }


        private void btn_Search_Click(object sender, EventArgs e)
        {
            dgv_situation.Rows.Clear();
            if (_RepairCtrl.RepairhistoryList != null)
                foreach (Repairsituation rs in _RepairCtrl.RepairsituationList)
                {
                    if (rs.Repairname.IndexOf(cb_name.Text) != -1)
                        dgv_situation.Rows.Add(
                        rs.Repairsituationno,
                        rs.Repairname,
                        SituationResult(rs.Repairsituationdetails),
                        rs.Repairsituationtime,
                        rs.Repairsituationmember,
                        rs.Repairsituationmemo,
                        rs.Repairsituationdetails,
                        rs.RepairsituationHistory
                         );
                }


            if (dgv_situation.Rows.Count != 0)
            {
                if (checkBox1.Checked)
                    foreach (DataGridViewRow dgvr in dgv_situation.Rows)
                    {
                        if (dgvr.Cells[2].Value.ToString().Equals("양호") || dgvr.Cells[2].Value.ToString().Equals("불량"))
                            dgvr.Visible = false;
                    }
            }

        }
        #endregion

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var senderGrid = (DataGridView)sender;
                if (senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex] is DataGridViewCheckBoxCell)
                {
                    if (e.ColumnIndex == 2)
                    {
                        senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex + 1].Value = false;
                    }
                    if (e.ColumnIndex == 3)
                    {
                        senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = true;
                        senderGrid.Rows[e.RowIndex].Cells[e.ColumnIndex - 1].Value = false;
                    }
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Repairsituation rs = _RepairSituation;

            if (_RepairSituation.Repairsituationno != 0 && comboBox2.Items.Count != 0)
            {
                rs.Repairsituationmember = comboBox2.SelectedItem.ToString();
                rs.Repairsituationmemo = textBox2.Text;

                string str = "";
                foreach (DataGridViewRow dgvr in dataGridView1.Rows)
                {
                    //value is null
                    if ((bool)dgvr.Cells[2].Value == true) str = str + dgvr.Cells[0].Value.ToString() + "_t,";
                    else if ((bool)dgvr.Cells[3].Value == true) str = str + dgvr.Cells[0].Value.ToString() + "_f,";
                    else str = str + dgvr.Cells[0].Value.ToString() + "_n,";
                }
                if (str.Length != 0)
                {
                    str = str.Remove(str.Length - 1);
                    rs.Repairsituationdetails = str;
                }
                _RepairCtrl.UpdateRepairSituraion(rs);
            }
            SetAlarm("적용되었습니다.");
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            SetView();
        }
    }
}
