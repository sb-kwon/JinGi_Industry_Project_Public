using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace View
{
    public partial class WorkInstructions_Popup : Form
    {
        #region 검색 gridviewUI
        private void SetDataGridView(DataGridView dgv)
        {
            dgv_process.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[0].Width = 50;
            dgv_process.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[2].Width = 50;

            dgv_detail.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_detail.Columns[0].Width = 120;
            dgv_detail.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_detail.Columns[1].Width = 80;
            dgv_detail.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_detail.Columns[2].Width = 120;
            dgv_detail.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_detail.Columns[3].Width = 120;
            dgv_detail.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_detail.Columns[4].Width = 120;
            dgv_detail.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_detail.Columns[5].Width = 120;
            dgv_detail.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_detail.Columns[6].Width = 120;

            dgv.Font = new Font("맑은 고딕", 11, FontStyle.Regular);


            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 72, 81);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.SeaGreen;

            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.CurrentCell = null;

            dgv.BackgroundColor = SystemColors.GradientInactiveCaption;

            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
            dgv.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f =>
            {
                f.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                f.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            });
            dgv.Rows.Cast<DataGridViewRow>().Where((x, i) => i % 2 != 0).ToList().ForEach(r => r.DefaultCellStyle.BackColor = Color.AliceBlue);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion
        private ProcessC _ProcessC;
        private Point mousePoint;

        public WorkInstructions_Popup(ProcessC processC)
        {
            _ProcessC = processC;

            InitializeComponent();
            SetFormView();
        }
        private void SetFormView()
        {
            //SetDataGridView(dgv_process);
            //SetDataGridView(dgv_detail);

            SetTextView();
            SetDefFairView();
            SetComboList();
        }
        private void SetDefFairView()
        {
            dgv_process.Rows.Clear();

            List<string[]> ViewList = _ProcessC.GetDefFairList();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    dgv_process.Rows.Add(false, array[0], array[1], array[2], array[3], array[4]);
                }
        }

        private void SetTextView()
        {
            tb_workno.Text = _ProcessC.WorkInstruction.WorkinstructionNo.ToString();
            txt_orderno.Text = _ProcessC.WorkOrder.OrderName.ToString();
            txt_name.Text = _ProcessC.Product.ProductName.ToString();
            tb_producttype.Text = _ProcessC.Product.ProductType.ToString();
            tb_date.Text = _ProcessC.WorkOrder.OrderDate.ToString();
            tb_dateend.Text = _ProcessC.WorkOrder.OrderDateEnd.ToString();
            tb_memo.Text = _ProcessC.WorkInstruction.WorkinstructionMemo.ToString();
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void ck_group_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_group.Checked == true)
            {
                if (ck_name.Checked == true)
                {
                    ck_name.Checked = false;
                    cb_type.SelectedIndex = 0;
                    cb_name.SelectedIndex = 0;
                }

                cb_group.Enabled = true;
            }
            else
                cb_group.Enabled = false;

        }

        private void ck_name_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_name.Checked == true)
            {
                if (ck_group.Checked == true)
                {
                    ck_group.Checked = false;
                    cb_group.SelectedIndex = 0;
                }

                cb_name.Enabled = true;
                cb_type.Enabled = true;

                SetComboList();
            }
            else
            {
                cb_type.Enabled = false;
                cb_name.Enabled = false;
            }

        }

        private void SetComboList()
        {
            cb_group.Items.Clear();
            cb_group.Items.Add("모두");
            cb_type.Items.Clear();
            cb_type.Items.Add("모두");
            cb_name.Items.Clear();
            cb_name.Items.Add("모두");

            List<string[]> ViewList = _ProcessC.GetDefFairList();
            List<string> GroupList = new List<string>();
            GroupList.Clear();
            if (ViewList != null)
                foreach (string[] str in ViewList)
                {
                    GroupList.Add(str[2]);
                    cb_type.Items.Add(str[3]);
                    cb_name.Items.Add(str[4]);
                }

            GroupList = GroupList.Distinct().ToList();
            cb_group.Items.AddRange(GroupList.ToArray());

            cb_group.SelectedIndex = 0;
            cb_type.SelectedIndex = 0;
            cb_name.SelectedIndex = 0;
        }

        private void cb_type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_type.Text != "모두")
            {

                cb_name.Items.Clear();
                cb_name.Items.Add("모두");

                List<string[]> ViewList = _ProcessC.GetDefFairList();
                if (ViewList != null)
                    foreach (string[] str in ViewList)
                    {
                        if (str[3].Equals(cb_type.Text))
                        {
                            cb_name.Items.Add(str[4]);
                        }

                    }

                cb_name.SelectedIndex = 0;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            dgv_process.Rows.Clear();

            List<string[]> ViewList = _ProcessC.GetDefFairList();
            if (ViewList != null)
                foreach (string[] str in ViewList)
                {
                    if ((cb_group.SelectedItem.Equals("모두") || cb_group.SelectedItem.Equals(str[2]))
                        && (cb_type.SelectedItem.Equals("모두") || cb_type.SelectedItem.Equals(str[3]))
                        && (cb_name.SelectedItem.Equals("모두") || str[4].IndexOf(cb_name.Text) != -1))
                    {
                        dgv_process.Rows.Add(false, str[0], str[1], str[2], str[3], str[4]);
                    }
                }
        }


        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }

        private void dgv_process_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView senderGrid = (DataGridView)sender;
                if (senderGrid.Rows[e.RowIndex].Index != -1)
                {
                    dgv_detail.Rows.Add(
                        tb_workno.Text,
                        senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString(),
                        senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString(),
                        senderGrid.Rows[e.RowIndex].Cells[4].Value.ToString(),
                        senderGrid.Rows[e.RowIndex].Cells[5].Value.ToString(),
                        tb_date.Text,
                        tb_dateend.Text,
                        "", "", "", "", ""
                        );
                }
            }
        }
        private void dgv_detail_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (e.RowIndex != -1)
            {
                SetSelectedWorkinstruction(dgv.SelectedRows[0]);

                WorkInstructions_Popup_Click popup = new WorkInstructions_Popup_Click(_ProcessC);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                popup.ShowDialog();

                DataGridViewRow dgvr = dgv.SelectedRows[0];
                if (_ProcessC.WorkProcess.WorkProcessPlanStart != "")
                {
                    dgvr.Cells[5].Value = _ProcessC.WorkProcess.WorkProcessPlanStart;
                    dgvr.Cells[6].Value = _ProcessC.WorkProcess.WorkProcessPlanEnd;
                }
                dgvr.Cells[7].Value = _ProcessC.WorkProcess.MemberId;
                dgvr.Cells[8].Value = _ProcessC.WorkProcess.MemberName;
                dgvr.Cells[9].Value = _ProcessC.WorkProcess.MachineNo;
                dgvr.Cells[10].Value = _ProcessC.WorkProcess.MachineName;
                dgvr.Cells[11].Value = _ProcessC.WorkProcess.WorkProcessMemo;
            }
        }

        private void SetSelectedWorkinstruction(DataGridViewRow dgvr)
        {
            _ProcessC.WorkInstruction.WorkinstructionNo = Convert.ToInt64(dgvr.Cells[0].Value);
            _ProcessC.WorkProcess.FairSort = Convert.ToInt32(dgvr.Cells[1].Value);
            _ProcessC.WorkProcess.FairGroup = dgvr.Cells[2].Value.ToString();
            _ProcessC.WorkProcess.FairReal = dgvr.Cells[3].Value.ToString();
            _ProcessC.WorkProcess.FairName = dgvr.Cells[4].Value.ToString();
            _ProcessC.WorkProcess.WorkProcessPlanStart = dgvr.Cells[5].Value.ToString();
            _ProcessC.WorkProcess.WorkProcessPlanEnd = dgvr.Cells[6].Value.ToString();
            _ProcessC.WorkProcess.MemberId = dgvr.Cells[7].Value.ToString();
            _ProcessC.WorkProcess.MemberName = dgvr.Cells[8].Value.ToString();
            if (dgvr.Cells[9].Value.ToString() != "") _ProcessC.WorkProcess.MachineNo = Convert.ToInt32(dgvr.Cells[9].Value);
            _ProcessC.WorkProcess.MachineName = dgvr.Cells[10].Value.ToString();
            _ProcessC.WorkProcess.WorkProcessMemo = dgvr.Cells[11].Value.ToString();
        }

        private void btn_instruction_save_Click(object sender, EventArgs e)
        {
            if (dgv_detail.Rows.Count != 0)
            {
                foreach (DataGridViewRow dgvr in dgv_detail.Rows)
                {
                    List<string> list = new List<string>();
                    for (int i = 0; i < 12; i++)
                    {
                        list.Add(dgvr.Cells[i].Value.ToString());
                    }

                    _ProcessC.InsertInstructions(list);
                }

                SetAlarm("작업지시서에 공정이 등록 되었습니다.");
                dgv_detail.Rows.Clear();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgv_detail.Rows.Count != 0)
                dgv_detail.Rows.Remove(dgv_detail.Rows[this.dgv_detail.CurrentCell.RowIndex]);
        }

        private void dgv_detail_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                SetSelectedDetail(dgv.SelectedRows[0]);
            }
        }

        private void SetSelectedDetail(DataGridViewRow dgvr)
        {
            _ProcessC.WorkProcess.WorkInstructionNo = Convert.ToInt64(dgvr.Cells[0].Value.ToString());
            _ProcessC.WorkProcess.WorkProcessPlanStart = dgvr.Cells[5].Value.ToString();
            _ProcessC.WorkProcess.WorkProcessPlanEnd = dgvr.Cells[6].Value.ToString();
            _ProcessC.WorkProcess.MemberId = dgvr.Cells[7].Value.ToString();
            _ProcessC.WorkProcess.MemberName = dgvr.Cells[8].Value.ToString();
            if (dgvr.Cells[9].Value.ToString() != "") _ProcessC.WorkProcess.MachineNo = Convert.ToInt32(dgvr.Cells[9].Value.ToString());
            _ProcessC.WorkProcess.MachineName = dgvr.Cells[10].Value.ToString();
            _ProcessC.WorkProcess.WorkProcessMemo = dgvr.Cells[11].Value.ToString();
        }

        private void btn_process_all_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_process.Rows)
            {
                if (row.Cells[0].Value.Equals(true))
                {
                    dgv_detail.Rows.Add(
                              tb_workno.Text,
                              row.Cells[2].Value,
                              row.Cells[3].Value,
                              row.Cells[4].Value,
                              row.Cells[5].Value,
                              tb_date.Text,
                              tb_dateend.Text,
                              "", "", "", "", ""
                              );
                }
            }
        }

        private void dgv_process_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.ColumnIndex == 0 && e.RowIndex == -1)
            {
                e.PaintBackground(e.ClipBounds, false);

                Point pt = e.CellBounds.Location;  // where you want the bitmap in the cell

                int nChkBoxWidth = 15;
                int nChkBoxHeight = 15;
                int offsetx = (e.CellBounds.Width - nChkBoxWidth) / 2;
                int offsety = (e.CellBounds.Height - nChkBoxHeight) / 2;

                pt.X += offsetx;
                pt.Y += offsety;

                CheckBox cb = new CheckBox();
                cb.Size = new Size(nChkBoxWidth, nChkBoxHeight);
                cb.Location = pt;
                cb.CheckedChanged += new EventHandler(gvSheetListCheckBox_CheckedChanged);

                ((DataGridView)sender).Controls.Add(cb);

                e.Handled = true;
            }

        }

        private void gvSheetListCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_process.Rows)
            {
                row.Cells[0].Value = ((CheckBox)sender).Checked;
            }
        }

        private void dgv_process_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgv_process.Rows[e.RowIndex].Cells[0].Value.ToString() == "False")
                    dgv_process.Rows[e.RowIndex].Cells[0].Value = true;
                else
                    dgv_process.Rows[e.RowIndex].Cells[0].Value = false;
            }
        }
        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void panel1_MouseMove(object sender, MouseEventArgs e)
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
