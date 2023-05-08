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
    public partial class RepairView1 : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private RepairCtrl _RepairCtrl;

        public RepairView1(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;

            InitializeComponent();
            _RepairCtrl = new RepairCtrl();
            SetView();
        }
        public void SetView()
        {
            dgv_product.Rows.Clear();
            if (_RepairCtrl.RepairhistoryList != null)
                foreach (Repairhistory rs in _RepairCtrl.RepairhistoryList)
                {
                    dgv_product.Rows.Add(
                        rs.Repairhistoryno,
                        rs.Repairname,
                        rs.Machinename,
                        _RepairCtrl.SetTimevalue(rs.Repairhistorytime),
                        rs.Repairitem,
                        rs.Repairhistorymemo);
                }

            button5.Tag = null;
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
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(255, 128, 0);

            RepairItem sm = new RepairItem(_RepairCtrl, this);

            sm.ShowDialog();
            btn.BackColor = Color.FromArgb(48, 103, 162);
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(255, 128, 0);

            RepairCheckInsert sm = new RepairCheckInsert(_RepairCtrl, this);

            sm.ShowDialog();
            btn.BackColor = Color.FromArgb(48, 103, 162);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            dataGridView1.Rows.Clear();

            if (btn.BackColor == Color.FromArgb(48, 103, 162))
            {
                if (_RepairCtrl.DefList != null)
                    foreach (string[] str in _RepairCtrl.DefList)
                    {
                        dataGridView1.Rows.Add(str[0], str[1]);
                    }
                btn.BackColor = Color.FromArgb(255, 128, 0);
                dgv_product.DefaultCellStyle.SelectionBackColor = Color.White;
                dgv_product.DefaultCellStyle.SelectionForeColor = Color.Black;

            }
            else
            {
                btn.BackColor = Color.FromArgb(48, 103, 162);
                dgv_product.DefaultCellStyle.SelectionBackColor = SystemColors.Highlight;
            }
        }
        private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string str = "";
            DataGridView dgv = (DataGridView)sender;
            if (e.RowIndex != -1)
            {
                str = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
                button5.Tag = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
            }
            dataGridView1.Rows.Clear();
            if (str.Length != 0)
            {
                foreach (string[] strs in _RepairCtrl.DefList)
                {
                    string[] array = str.Split(',');
                    foreach (string strs2 in array)
                    {
                        if (strs2.Equals(strs[0])) dataGridView1.Rows.Add(strs[0], strs[1]);
                    }
                }
            }
        }

        private void btn_Search_Click(object sender, EventArgs e)
        {
            dgv_product.Rows.Clear();
            if (_RepairCtrl.RepairhistoryList != null)
                foreach (Repairhistory rs in _RepairCtrl.RepairhistoryList)
                {
                    if (rs.Repairname.IndexOf(cb_name.Text) != -1)
                        dgv_product.Rows.Add(
                            rs.Repairhistoryno,
                            rs.Repairname,
                            rs.Machinename,
                            _RepairCtrl.SetTimevalue(rs.Repairhistorytime),
                            rs.Repairitem,
                            rs.Repairhistorymemo);
                }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(255, 128, 0);

            RepairCheckUpdate sm = new RepairCheckUpdate(_RepairCtrl, this);

            sm.ShowDialog();
            btn.BackColor = Color.FromArgb(48, 103, 162);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.Tag != null)
            {
                foreach (Repairhistory rs in _RepairCtrl.RepairhistoryList)
                {
                    if (rs.Repairhistoryno.ToString().Equals(btn.Tag.ToString()))
                    {
                        _RepairCtrl.InsertSituation(rs);

                        break;
                    }
                }
            }
            SetAlarm("점검 일지가 생성되었습니다.");
        }
    }
}
