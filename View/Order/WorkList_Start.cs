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
    public partial class WorkList_Start : Form
    {
        private ProcessC _ProcessC, _SelectData;
        private Member _LoginInfo;
        private List<String[]> ViewList;
        private string SearchName, SearchTable;
        private bool _Type;
        public WorkList_Start(Member mem, ProcessC Pro)
        {
            _ProcessC = new ProcessC();
            _SelectData = Pro;

            InitializeComponent();
            _LoginInfo = mem;
            _Type = true;

            SetType();
            SetFormView();
        }
        private void SetFormView()
        {
            //SetDataGridView(dgv_process);
            SetComboBox();
            GetWorkDataList_Detail();
        }
        private void SetComboBox()
        {
            comboBox7.Items.Clear();
            comboBox9.Items.Clear();

            comboBox7.Items.Add("모두");
            comboBox9.Items.Add("모두");

            //맵핑명
            List<String> list4 = _ProcessC.GetDefFairName();

            if (list4 != null)
            {
                foreach (string array in list4)
                    comboBox7.Items.Add(array);

                comboBox7.SelectedIndex = 0;
            }
            List<String> list5 = _ProcessC.GetDefFairName();

            //장비명
            List<String[]> list6 = new List<string[]>();
            list6 = _ProcessC.GetComboMachine();
            ViewList = list6;

            if (ViewList != null)
            {
                foreach (string[] str in list6)
                {
                    ComboboxItem cbi = new ComboboxItem();
                    cbi.Text = str[1]; //name
                    cbi.Value = str[0];//id
                    comboBox9.Items.Add(cbi);
                }
                comboBox9.SelectedIndex = 0;
                ViewList.Clear();
            }
        }
        private void ComboBox_Changed(string str, string SearchName)
        {
            foreach (Control p in panel2.Controls)
            {
                ComboBox com = p as ComboBox;
                if (!(com.Name.Equals(str)))
                {
                    com.SelectedIndex = 0;
                }
            }
            switch (str)
            {
                case "cb_order":
                    SearchTable = "wo.OrderNo";
                    break;
                case "cb_state":
                    SearchTable = "wp.WorkProcessStateName";
                    break;
                case "cb_fairname":
                    SearchTable = "wp.FairName";
                    break;
                case "cb_realname":
                    SearchTable = "wp.FairReal";
                    break;
                case "cb_member":
                    SearchTable = "mem.MemberId";
                    break;
                case "cb_machine":
                    SearchTable = "ma.MachineNo";
                    break;
            }
            dgv_process.Rows.Clear();

            List<string[]> list = new List<string[]>();

            //list = _ProcessC.GetWorkProcessList_Start(SearchTable, SearchName, false);
            ViewList = list;

            SetWorkDataList_Detail();
        }
        private void GetWorkDataList_Detail()
        {
            dgv_process.Rows.Clear();
            ViewList = _ProcessC.GetWorkProcessList_Start(SearchTable, SearchName, true, _SelectData.WorkProcess);
            SetWorkDataList_Detail();
        }
        private void SetWorkDataList_Detail()
        {
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    dgv_process.Rows.Add(array[0], array[1], array[2], array[5], array[6], array[7], SetProcessState(array[8]), array[9], array[10], array[11], array[12], "상세보기", "일시중지", array[15], array[16], array[17], array[18]);
                }
            if (dgv_process.RowCount != 0) SetSelectedData(dgv_process.Rows[0]);
            foreach (DataGridViewRow dgvr in dgv_process.Rows)
            {
                if (dgvr.Cells[3].Value.Equals("일시중지"))
                {
                    dgvr.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                }
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dgvr.Cells[12];
                buttonCell.FlatStyle = FlatStyle.Popup;
                buttonCell.Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                DataGridViewButtonCell buttonCell2 = (DataGridViewButtonCell)dgvr.Cells[11];
                buttonCell2.FlatStyle = FlatStyle.Popup;
                buttonCell2.Style.BackColor = System.Drawing.Color.FromArgb(0, 198, 179);
            }
        }
        private String SetProcessState(string state)
        {
            string str = "";

            if (state == "0") str = "작업 전";
            if (state == "1") str = "작업 중";
            if (state == "2") str = "폐기";
            if (state == "3") str = "일시중지";
            if (state == "4") str = "중지";
            if (state == "5") str = "작업완료";

            return str;
        }
        #region 검색 gridviewUI
        private void SetDataGridView(DataGridView dgv)
        {

            dgv_process.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[4].Width = 70;
            dgv_process.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[5].Width = 100;
            dgv_process.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[8].Width = 100;
            dgv_process.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[9].Width = 100;

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
                f.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                f.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            });
            dgv.Rows.Cast<DataGridViewRow>().Where((x, i) => i % 2 != 0).ToList().ForEach(r => r.DefaultCellStyle.BackColor = Color.AliceBlue);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        #endregion
        #region 검색 공통
        private void btn_all_Click(object sender, EventArgs e)
        {
            GetWorkDataList_Detail();
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            if (_ProcessC.WorkProcess.WorkProcessNo == 0) MessageBox.Show("폐기할 항목을 선택해주십시오!");
            else
            {
                _ProcessC.DeleteProcessState();

                SetFormView();
                MessageBox.Show("폐기 완료");
            }
        }
        private void ck_time_CheckedChanged(object sender, EventArgs e)
        {
            if (ck_time.Checked == true)
            {
                dtp_date.Enabled = true;
                dtp_time.Enabled = true;
            }
            else
            {
                dtp_date.Enabled = false;
                dtp_time.Enabled = false;
            }
        }
        private void btn_start_Click(object sender, EventArgs e)
        {
            if (_ProcessC.WorkProcess.FairName == null)
                SetAlarm("공정을 선택 해주세요.");
            else if (_ProcessC.WorkProcess.MemberId == "" && lbl_member_code.Text == "")
                SetAlarm("작업자를 등록 해주세요.");
            else
            {
                if (_ProcessC.WorkProcess.MemberId == null)
                    _ProcessC.WorkProcess.MemberId = lbl_member_code.Text;
                if (ck_time.Checked == true)
                    _ProcessC.WorkProcess.WorkProcessStartTime = dtp_date.Value.Date + dtp_time.Value.TimeOfDay;
                else
                    _ProcessC.WorkProcess.WorkProcessStartTime = DateTime.Now;

                if (_ProcessC.WorkProcess.OrderStartSchedule == null)
                    _ProcessC.OrderScheduleStart();

                string _checktype = "2";
                _ProcessC.WorkProcess.WorkProcessStateName = "1";
                _ProcessC.UpdateProcessState(_checktype); //작업시작
                SetAlarm("작업을 시작했습니다.");

                GetWorkDataList_Detail();
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        #endregion
        private void dgv_process_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var senderGrid = (DataGridView)sender;
                var senderGridrow = senderGrid.Rows[e.RowIndex];

                SetSelectedData(senderGrid.SelectedRows[0]);

                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != -1)
                {
                    int wpNo = Convert.ToInt32(senderGridrow.Cells[13].Value);

                    WorkProcessDetailView popup = new WorkProcessDetailView(wpNo, _ProcessC);
                    popup.StartPosition = FormStartPosition.CenterParent;
                    popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                    popup.ShowDialog();
                }
            }
        }
        private void SetSelectedData(DataGridViewRow dgvr)
        {
            WorkProcess _wp = new WorkProcess();

            _wp.OrderNo = Convert.ToInt32(dgvr.Cells[0].Value.ToString());
            _wp.OrderName = dgvr.Cells[1].Value.ToString();
            _wp.WorkInstructionNo = Convert.ToInt64(dgvr.Cells[2].Value.ToString());
            _wp.FairName = dgvr.Cells[3].Value.ToString();
            _wp.FairReal = dgvr.Cells[4].Value.ToString();
            _wp.FairSort = Convert.ToInt32(dgvr.Cells[5].Value.ToString());
            _wp.WorkProcessStateName = dgvr.Cells[6].Value.ToString();
            if (dgvr.Cells[7].Value.ToString().Equals("") && checkBox1.Checked)
            {
                _wp.MemberId = lbl_member_code.Text;
            }
            else
            {
                checkBox1.Checked = false;
                _wp.MemberId = dgvr.Cells[7].Value.ToString();
            }
            _wp.MemberName = dgvr.Cells[8].Value.ToString();
            if (dgvr.Cells[9].Value != "") _wp.MachineNo = Convert.ToInt32(dgvr.Cells[9].Value.ToString());
            _wp.MachineName = dgvr.Cells[10].Value.ToString();
            _wp.WorkProcessNo = Convert.ToInt32(dgvr.Cells[13].Value.ToString());
            if (dgvr.Cells[14].Value != "") _wp.OrderStartSchedule = dgvr.Cells[14].Value.ToString();
            if (dgvr.Cells[15].Value != "") _wp.OrderEndSchedule = dgvr.Cells[15].Value.ToString();
            _wp.FairGroup = dgvr.Cells[16].Value.ToString();

            _ProcessC.WorkProcess = _wp;
        }
        private void dgv_shipmet_list_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                SetSelectedData2(dgv.SelectedRows[0]);
            }
        }
        private void SetSelectedData2(DataGridViewRow dgvr)
        {
            WorkProcess _wp = new WorkProcess();

            _wp.OrderNo = Convert.ToInt32(dgvr.Cells[0].Value.ToString());
            _wp.OrderName = dgvr.Cells[1].Value.ToString();
            _wp.WorkInstructionNo = Convert.ToInt64(dgvr.Cells[2].Value.ToString());
            _wp.FairName = dgvr.Cells[3].Value.ToString();
            _wp.FairReal = dgvr.Cells[4].Value.ToString();
            _wp.FairSort = Convert.ToInt32(dgvr.Cells[5].Value.ToString());
            _wp.WorkProcessStateName = dgvr.Cells[6].Value.ToString();
            _wp.MemberId = dgvr.Cells[7].Value.ToString();
            _wp.MemberName = dgvr.Cells[8].Value.ToString();
            if (dgvr.Cells[9].Value != "") _wp.MachineNo = Convert.ToInt32(dgvr.Cells[9].Value.ToString());
            _wp.MachineName = dgvr.Cells[10].Value.ToString();
            _wp.WorkProcessNo = Convert.ToInt32(dgvr.Cells[13].Value.ToString());
            if (dgvr.Cells[14].Value != "") _wp.OrderStartSchedule = dgvr.Cells[14].Value.ToString();
            if (dgvr.Cells[15].Value != "") _wp.OrderEndSchedule = dgvr.Cells[15].Value.ToString();

            _ProcessC.WorkProcess = _wp;
        }
        private void btn_member_Click(object sender, EventArgs e)
        {
            View.ETC.NumberKey numberKey = new ETC.NumberKey(this, "");
            numberKey.StartPosition = FormStartPosition.CenterParent;
            numberKey.Location = new Point(this.Location.X + this.Width, this.Location.Y);

            string agoStr;
            if (this.Tag is null) agoStr = "0";
            else agoStr = this.Tag.ToString();
            numberKey.ShowDialog();

            string afteroStr = "";
            if (this.Tag is null) afteroStr = "0";
            else afteroStr = this.Tag.ToString();

            if (!agoStr.Equals(afteroStr)) SetMemberValue(afteroStr);
        }
        private void SetMemberValue(string MemberNo)
        {
            Member_Ctrl mc = new Member_Ctrl();
            Member member = mc.FindMember(Convert.ToInt32(MemberNo));

            if (member != null)
            {
                lbl_member_code.Text = member.Memberid;
                lbl_member_name.Text = member.Membername;
            }
            else
            {
                MessageBox.Show("등록된 번호가 없습니다.");
            }
        }
        private void SetType()
        {
            if (_Type) // 로그인 정보이면
            {
                btn_member.Enabled = false;

                lbl_member_code.Text = _LoginInfo.Memberid;
                lbl_member_name.Text = _LoginInfo.Membername;
            }
            else
            {
                btn_member.Enabled = true;

                lbl_member_code.Text = "";
                lbl_member_name.Text = "";
                if (dgv_process.Rows.Count != 0)
                    _ProcessC.WorkProcess.MemberId = dgv_process.Rows[0].Cells[7].Value.ToString();
            }
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            _Type = checkBox1.Checked;
            SetType();
        }
        private void label14_Click(object sender, EventArgs e)
        {
            Label textbox = (Label)sender;
            View.ETC.KeyBoard numberKey = new ETC.KeyBoard(this, (Label)sender);
            numberKey.StartPosition = FormStartPosition.CenterParent;
            numberKey.Location = new Point(this.Location.X + this.Width, this.Location.Y);

            string agoStr;
            this.Tag = null;
            numberKey.ShowDialog();

            if (this.Tag != null) textbox = (Label)this.Tag;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dgv_process.Rows.Clear();

            List<string[]> list = new List<string[]>();

            list = _ProcessC.GetWorkProcessList_Start(SearchTable, SearchName, true, _SelectData.WorkProcess);
            ViewList = list;
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    if ((comboBox7.SelectedItem.Equals("모두") || comboBox7.SelectedItem.ToString().ToLower() == array[6].ToLower())
                        && (comboBox9.SelectedItem.Equals("모두") || comboBox9.SelectedItem.ToString().ToLower() == array[9].ToLower())
                        && array[1].ToLower().IndexOf(label12.Text.ToLower()) != -1
                         && array[2].ToLower().IndexOf(label13.Text.ToLower()) != -1)

                        dgv_process.Rows.Add(array[0], array[1], array[2], array[5], array[6], array[7], SetProcessState(array[8]), array[9], array[10], array[11], array[12], "상세보기", "일시중지", array[15], array[16], array[17]);
                }
            foreach (DataGridViewRow dgvr in dgv_process.Rows)
            {
                if (dgvr.Cells[3].Value.Equals("일시중지"))
                {
                    dgvr.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                }
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dgvr.Cells[12];
                buttonCell.FlatStyle = FlatStyle.Popup;
                buttonCell.Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                DataGridViewButtonCell buttonCell2 = (DataGridViewButtonCell)dgvr.Cells[11];
                buttonCell2.FlatStyle = FlatStyle.Popup;
                buttonCell2.Style.BackColor = System.Drawing.Color.FromArgb(0, 198, 179);
            }
        }
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
    }
}