using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace View
{
    public partial class WorkList_End : Form
    {
        private ProcessC _ProcessC, _SelectData;
        private List<String[]> ViewList;
        private string SearchName, SearchTable, _checktype;
        private bool _Type;
        public WorkList_End(ProcessC pro)
        {
            _ProcessC = new ProcessC();
            _SelectData = pro;
            InitializeComponent();
            SetFormView();
        }
        private void SetFormView()
        {
            //SetDataGridView(dgv_process);
            GetWorkDataList_Detail();
            SetComboBox();
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
            ViewList = _ProcessC.GetComboMachine();

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
        #region 검색 그리드뷰
        private void GetWorkDataList_Detail()
        {
            dgv_process.Rows.Clear();
            cb_Cause.Enabled = false;

            List<string[]> list = new List<string[]>();

            list = _ProcessC.GetWorkProcessList_Ongoing(SearchTable, SearchName, true, _SelectData.WorkProcess);
            ViewList = list;

            SetWorkDataList_Detail();
        }
        private void SetWorkDataList_Detail()
        {
            dgv_process.Rows.Clear();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    dgv_process.Rows.Add(array[0], array[1], array[2], array[5], array[6], array[7], SetProcessState(array[8]), array[9], array[10], array[11], array[12], array[16].Substring(0, 10), array[17].Substring(0, 10), array[13], "상세보기", "일시중지", array[15], array[18]);
                }
            if (dgv_process.RowCount != 0) SetSelectedData(dgv_process.Rows[0]);
            foreach (DataGridViewRow dgvr in dgv_process.Rows)
            {
                if (dgvr.Cells[3].Value.Equals("일시중지"))
                {
                    dgvr.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                }
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dgvr.Cells[15];
                buttonCell.FlatStyle = FlatStyle.Popup;
                buttonCell.Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                DataGridViewButtonCell buttonCell2 = (DataGridViewButtonCell)dgvr.Cells[14];
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
        private void dgv_process_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                var senderGrid = (DataGridView)sender;
                var senderGridrow = senderGrid.Rows[e.RowIndex];

                SetSelectedData(senderGrid.SelectedRows[0]);
                if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn && e.RowIndex != -1)
                {
                    int wpNo = Convert.ToInt32(senderGridrow.Cells[16].Value);

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
            _wp.MemberId = dgvr.Cells[7].Value.ToString();
            _wp.MemberName = dgvr.Cells[8].Value.ToString();
            if (dgvr.Cells[9].Value != "") _wp.MachineNo = Convert.ToInt32(dgvr.Cells[9].Value.ToString());
            _wp.MachineName = dgvr.Cells[10].Value.ToString();
            _wp.WorkProcessStartTime = Convert.ToDateTime(dgvr.Cells[13].Value.ToString());
            _wp.WorkProcessNo = Convert.ToInt32(dgvr.Cells[16].Value.ToString());
            _wp.WorkProcessPlanStart = dgvr.Cells[11].Value.ToString();
            _wp.WorkProcessPlanEnd = dgvr.Cells[12].Value.ToString();
            _wp.FairGroup = dgvr.Cells[17].Value.ToString();

            _ProcessC.WorkProcess = _wp;
        }
        private void btn_start_Click(object sender, EventArgs e) //진기수정
        {
            if (cb_Cause.Text != "") _ProcessC.WorkProcess.ProductType = cb_Cause.Text;
            if (_ProcessC.WorkProcess.FairName == null)
                SetAlarm("공정을 선택 해주세요.");
            else
            {
                if (ck_time.Checked == true)
                    _ProcessC.WorkProcess.WorkProcessEndTime = dtp_date.Value.Date + dtp_time.Value.TimeOfDay;
                else
                    _ProcessC.WorkProcess.WorkProcessEndTime = DateTime.Now;

                int result = DateTime.Compare(_ProcessC.WorkProcess.WorkProcessStartTime, _ProcessC.WorkProcess.WorkProcessEndTime);

                if (result > 0)
                    SetAlarm("종료시간이 시작시간보다 빠릅니다. 다시 확인 해주세요.");
                else
                {
                    if (rbt_bad.Checked)
                        _ProcessC.InsertDefectiveCheck();// 불량 체크 확인하고 불량이면 불량 등록

                    _ProcessC.WorkProcess.WorkProcessStateName = "5";
                    //_checktype = "3";
                    _checktype = "2";

                    _ProcessC.UpdateProcessState(_checktype); //작업완료

                    List<string[]> list2 = _ProcessC.CheckWorkInstructionState();
                    foreach (string[] str in list2)
                    {
                        if (str[0].ToString() == str[1].ToString())
                        {
                            _ProcessC.UpdateProcessState(_checktype);
                        }
                    }
                    //공정 다 완료 되었는지 확인
                    //ViewList = _ProcessC.ProcessCheckCompletion();
                    ViewList = _ProcessC.CheckWorkInstructionState();
                    if (ViewList != null)
                    {
                        foreach (string[] str in ViewList)
                        {
                            if (str[0] == str[1])
                            {
                                _ProcessC.UpdateProcessCompletion(); //작업지시서 3 완료, 수주 정보 출하 대기 변경
                                SetAlarm("공정이 모두 완료 되었습니다.");
                            }
                            else
                                SetAlarm("작업을 완료 되었습니다.");
                        }
                    }
                    SetFormView();
                }
            }
        }
        #endregion
        #region 검색 공정폐기, 닫기, 전체보기 버튼
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
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_all_Click(object sender, EventArgs e)
        {
            GetWorkDataList_Detail();
        }
        #endregion
        #region 검색 양품 버튼 / 날짜 지정


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
        #endregion
        #region 검색 gridviewUI
        private void SetDataGridView(DataGridView dgv)
        {

            dgv_process.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[5].Width = 60;
            dgv_process.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[6].Width = 100;


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

        private void button1_Click(object sender, EventArgs e)
        {
            if (_ProcessC.WorkProcess.WorkProcessStateName == "일시중지")
                SetAlarm("이미 일시중지 된 공정입니다.");
            else
            {
                _ProcessC.UpdatePause();
                _ProcessC.ProcessPauseLog();
                SetAlarm(_ProcessC.WorkProcess.FairName + " 의 작업이 일시중지 되었습니다.");
                GetWorkDataList_Detail();
            }
        }
        private void rbt_good_CheckedChanged(object sender, EventArgs e)
        {
            rbt_bad.BackColor = Color.LightGray;
            rbt_good.BackColor = Color.Lime;
            cb_Cause.Enabled = false;
        }
        private void rbt_bad_CheckedChanged(object sender, EventArgs e)
        {
            rbt_bad.BackColor = Color.Red;
            rbt_good.BackColor = Color.LightGray;
            cb_Cause.Enabled = true;
        }
        private void button3_Click(object sender, EventArgs e)
        {
            dgv_process.Rows.Clear();
            ViewList = _ProcessC.GetWorkProcessList_Ongoing(SearchTable, SearchName, true, _SelectData.WorkProcess);

            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    if ((comboBox7.SelectedItem.Equals("모두") || comboBox7.SelectedItem.ToString().Equals(array[4]))
                        && (comboBox9.SelectedItem.Equals("모두") || comboBox9.SelectedItem.ToString().Equals(array[10]))
                        && array[1].ToLower().IndexOf(label12.Text.ToLower()) != -1
                         && array[2].ToLower().IndexOf(label13.Text.ToLower()) != -1)
                        dgv_process.Rows.Add(array[0], array[1], array[2], array[5], array[6], array[7], SetProcessState(array[8]), array[9], array[10], array[11], array[12], array[16].Substring(0, 10), array[17].Substring(0, 10), array[13], "상세보기", "일시중지", array[15], array[16]);
                }
            foreach (DataGridViewRow dgvr in dgv_process.Rows)
            {
                if (dgvr.Cells[3].Value.Equals("일시중지"))
                {
                    dgvr.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                }
                DataGridViewButtonCell buttonCell = (DataGridViewButtonCell)dgvr.Cells[15];
                buttonCell.FlatStyle = FlatStyle.Popup;
                buttonCell.Style.BackColor = System.Drawing.Color.FromArgb(255, 255, 0);
                DataGridViewButtonCell buttonCell2 = (DataGridViewButtonCell)dgvr.Cells[14];
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