using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Linq;

namespace View
{
    public partial class WorkInstructionsView : Form, IBasicForm
    {
        #region 검색 gridviewUI
        private void SetDataGridView(DataGridView dgv)
        {
            dgv_work.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_work.Columns[0].Width = 110;
            dgv_work.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_work.Columns[1].Width = 120;
            dgv_work.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_work.Columns[2].Width = 100;
            dgv_work.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_work.Columns[4].Width = 250;
            dgv_work.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_work.Columns[5].Width = 80;
            dgv_work.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_work.Columns[7].Width = 130;
            dgv_work.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_work.Columns[8].Width = 100;
            dgv_work.Columns[9].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_work.Columns[9].Width = 100;
            dgv_work.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_work.Columns[10].Width = 100;
            dgv_work.Columns[11].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_work.Columns[11].Width = 100;
            dgv_work.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_work.Columns[12].Width = 110;
            dgv_work.Columns[15].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_work.Columns[15].Width = 110;

            dgv_process.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[1].Width = 250;
            dgv_process.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[2].Width = 90;
            dgv_process.Columns[3].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[3].Width = 100;
            dgv_process.Columns[4].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[4].Width = 100;
            dgv_process.Columns[5].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[5].Width = 100;
            dgv_process.Columns[6].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[6].Width = 100;
            dgv_process.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[7].Width = 120;
            dgv_process.Columns[8].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[8].Width = 120;
            dgv_process.Columns[10].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[10].Width = 100;
            dgv_process.Columns[12].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[12].Width = 100;
            dgv_process.Columns[13].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_process.Columns[13].Width = 100;

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
            dgv.MultiSelect = true;
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
        #region 검색 basicform
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            ck_all.Checked = false;
            SetFormView();
        }
        public Form SetForm()
        {
            return this;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
        #endregion
        private Member _LoginInfo;
        private BasicForm _Mother;
        private bool _Mode, _Check;
        private ProcessC _ProcessC;
        private List<String[]> _MultiList;
        private AuthorityC _AuthorityCtrl;
        private OrderChildOrder _OrderChildOrder;

        public WorkInstructionsView(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;
            _Mode = _Check =  false;
            _ProcessC = new ProcessC();
            _MultiList = new List<String[]>();
            _AuthorityCtrl = new AuthorityC();
            _OrderChildOrder = new OrderChildOrder(_ProcessC, this);

            InitializeComponent();
            SetFormView();
        }
        private void SetFormView()
        {
            _Mode = false;
            //SetDataGridView(dgv_work);
            //SetDataGridView(dgv_process);
            SetWorkListView();
            SetComboBoxView();
            ModeBtnColorSet();
        }
        private void SetWorkListView()
        {
            dgv_work.Rows.Clear();
            dgv_process.Rows.Clear();

            List<string[]> ViewList = _ProcessC.GetWorkDataList();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    if ((array[2] != "4") && (array[2] != "6") && (array[2] != "7") && (array[5] != "3") && (array[5] != "4") && (array[5] != "5"))
                    {
                        dgv_work.Rows.Add(array[0].Substring(0, 10), array[1], SetInstructionState(array[2]), array[3], array[4], SetOrderState(array[5]), array[6], array[7] + " 등 " + array[14] + "개", array[8], array[9].Substring(0, 10), array[10].Substring(0, 10), array[11], array[12], array[13], array[2]);
                    }
                }
        }
        private String SetOrderState(string state)
        {
            string str = "";

            if (state == "0") str = "대기";
            if (state == "1") str = "등록";
            if (state == "2") str = "진행중";
            if (state == "3") str = "출하 대기";
            if (state == "4") str = "출하 진행중";
            if (state == "5") str = "완료";
            if (state == "6") str = "폐기";

            return str;
        }
        private void SetComboBoxView()
        {
            cb_orderstate.Items.Clear();
            cb_orderstate.Items.Add("모두");
            List<String> list = _ProcessC.DefOrderStateList();

            if (!(list is null))
                foreach (string str in list)
                {
                    cb_orderstate.Items.Add(SetOrderState(str));
                }
            cb_orderstate.SelectedIndex = 0;

            cb_type.Items.Clear();
            cb_type.Items.Add("모두");
            List<String> list2 = _ProcessC.DefProductType();

            if (!(list2 is null))
                foreach (string str in list2)
                {
                    cb_type.Items.Add(str);
                }
            cb_type.SelectedIndex = 0;
        }
        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            dtp_date.Enabled = checkBox2.Checked;
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            ck_all.Checked = false;
            dgv_work.Rows.Clear();
            dgv_process.Rows.Clear();

            List<string[]> ViewList = _ProcessC.GetWorkDataList();
            if (ViewList != null)
                foreach (string[] str in ViewList)
                {
                    if ((str[4].IndexOf(textBox1.Text) != -1)
                        && (cb_orderstate.SelectedItem.Equals("모두") || cb_orderstate.SelectedItem.Equals(str[5]))
                        && (str[7].IndexOf(textBox2.Text) != -1)
                        && (cb_type.SelectedItem.Equals("모두") || cb_type.SelectedItem.Equals(str[8]))
                        && (!dtp_date.Enabled || Convert.ToDateTime(str[9]).Date <= dtp_date.Value.Date)
                        && (!dtp_date.Enabled || Convert.ToDateTime(str[10]).Date >= dtp_date.Value.Date)
                        && (str[11].IndexOf(textBox3.Text) != -1)
                        && (str[13].IndexOf(textBox4.Text) != -1))
                    {
                        dgv_work.Rows.Add(str[0].Substring(0, 10), str[1], SetInstructionState(str[2]), str[3], str[4], SetOrderState(str[5]), str[6], str[7] + " 등 " + str[14] + "개", str[8], str[9].Substring(0, 10), str[10].Substring(0, 10), str[11], str[12], str[13], str[2]);
                    }
                }
        }
        private void btn_MultiCheck_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            _Mode = !_Mode;
            ModeBtnColorSet();
        }
        private void ck_group_CheckedChanged(object sender, EventArgs e)
        {
            dgv_work.Rows.Clear();
            dgv_process.Rows.Clear();

            if (ck_all.Checked == true)
            {
                List<string[]> ViewList = _ProcessC.GetWorkDataList();
                if (ViewList != null)
                    foreach (string[] array in ViewList)
                        dgv_work.Rows.Add(array[0].Substring(0, 10), array[1], SetInstructionState(array[2]), array[3], array[4], SetOrderState(array[5]), array[6], array[7] + " 등 " + array[14] + "개", array[8], array[9].Substring(0, 10), array[10].Substring(0, 10), array[11], array[12], array[13], array[2]);
            }
            else
                SetWorkListView();
        }
        private void dgv_work_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                SetSelectedWorkinstruction(dgv.SelectedRows[0]);
                //해수몬
                if(_Mode) SetMultiSelect(dgv.SelectedRows[0]);

                SetWorkListDetialView();
            }
        }
        private void SetMultiSelect(DataGridViewRow dgvr)
        {
            if ((bool)dgvr.Cells[15].Value) dgvr.Cells[15].Value = false;
            else dgvr.Cells[15].Value = true;

         /*   if (!(btn_MultiCheck.BackColor.Equals(Color.CornflowerBlue)))
            {
                _Check = !_Check;
                if (_Check) dgvr.Cells[15].Value = true;
                else dgvr.Cells[15].Value = false;

                if (!(dgvr.Cells[15].Value is null))
                {
                    if (dgvr.Cells[15].Value.Equals(true))
                    {
                    *//*    MessageBox.Show(dgvr.Cells[1].Value.ToString());*//*
                    }
                }
            }
            _Check = false;*/
        }
        private void btn_MultiPrint_Click(object sender, EventArgs e)
        {
            //해수몬
            List<ProcessC> list = new List<ProcessC>();

            foreach(DataGridViewRow dgvr in dgv_work.Rows)
            {
                if ((bool)dgvr.Cells[15].Value)
                {
                    ProcessC processC = new ProcessC();

                    processC.WorkInstruction.WorkinstructionNo = Convert.ToInt64(dgvr.Cells[1].Value);
                    processC.WorkInstruction.WorkinstructionState = Convert.ToInt32(dgvr.Cells[14].Value);
                    processC.WorkOrder.OrderNo = Convert.ToInt32(dgvr.Cells[3].Value);
                    processC.WorkOrder.OrderName = dgvr.Cells[4].Value.ToString();
                    processC.WorkOrder.OrderStateName = dgvr.Cells[5].Value.ToString();
                    processC.Product.ProductNo = Convert.ToInt32(dgvr.Cells[6].Value);
                    processC.Product.ProductName = dgvr.Cells[7].Value.ToString();
                    processC.Product.ProductType = dgvr.Cells[8].Value.ToString();
                    processC.WorkOrder.OrderDate = dgvr.Cells[9].Value.ToString();
                    processC.WorkOrder.OrderDateEnd = dgvr.Cells[10].Value.ToString();
                    processC.WorkInstruction.WorkinstructionMemo = dgvr.Cells[13].Value.ToString();

                    list.Add(processC);
                }
            }
            Print_Multi print_Form = new Print_Multi(list);

            print_Form.StartPosition = FormStartPosition.CenterParent;
            print_Form.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            print_Form.ShowDialog();
        }
        private void SetSelectedWorkinstruction(DataGridViewRow dgvr)
        {
            for (int i = 0; i <= dgv_work.SelectedRows.Count; i++)
            {
                _ProcessC.WorkInstruction.WorkinstructionNo = Convert.ToInt64(dgvr.Cells[1].Value);
                _ProcessC.WorkInstruction.WorkinstructionState = Convert.ToInt32(dgvr.Cells[14].Value);
                _ProcessC.WorkOrder.OrderNo = Convert.ToInt32(dgvr.Cells[3].Value);
                _ProcessC.WorkOrder.OrderName = dgvr.Cells[4].Value.ToString();
                _ProcessC.WorkOrder.OrderStateName = dgvr.Cells[5].Value.ToString();
                _ProcessC.Product.ProductNo = Convert.ToInt32(dgvr.Cells[6].Value);
                _ProcessC.Product.ProductName = dgvr.Cells[7].Value.ToString();
                _ProcessC.Product.ProductType = dgvr.Cells[8].Value.ToString();
                _ProcessC.WorkOrder.OrderDate = dgvr.Cells[9].Value.ToString();
                _ProcessC.WorkOrder.OrderDateEnd = dgvr.Cells[10].Value.ToString();
                _ProcessC.WorkInstruction.WorkinstructionMemo = dgvr.Cells[13].Value.ToString();
            }
        }
        private void SetWorkListDetialView()
        {
            dgv_process.Rows.Clear();
            List<string[]> list = _ProcessC.GetWorkDataList_Detail();
            if (list != null)
            {
                foreach (string[] array in list)
                {
                    dgv_process.Rows.Add(array[0], array[1], array[2], array[3], array[4], array[5], SetProcessState(array[6]), array[7].Substring(0, 10), array[8].Substring(0, 10), array[9], array[10], array[11], array[12], NullChange(array[13]), array[14]);
                }
            }
        }
        private string NullChange(string str)
        {
            if (str == "") str = "검사 전";
            return str;
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
        private String SetInstructionState(string state)
        {
            string str = "";

            if (state == "0") str = "대기";
            if (state == "1") str = "등록";
            if (state == "2") str = "진행중";
            if (state == "3") str = "공정 완료";
            if (state == "4") str = "폐기";
            if (state == "5") str = "취소";
            if (state == "6") str = "품목 출고";
            if (state == "7") str = "출하";

            return str;
        }
        private void ModeBtnColorSet()
        {
            if (_Mode)
            {
                btn_MultiCheck.BackColor = Color.Lime;
                btn_MultiPrint.Visible = true;
                dgv_work.Columns[15].Visible = true;

                //해수몬
                foreach (DataGridViewRow dgvr in dgv_work.Rows)
                    dgvr.Cells[15].Value = false;
            }
            else
            {
                btn_MultiCheck.BackColor = Color.CornflowerBlue;
                btn_MultiPrint.Visible = false;
                dgv_work.Columns[15].Visible = false;
            }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (_ProcessC.WorkOrder.OrderName == null)
                SetAlarm("작업지시서를 선택 해주세요.");
            else if (_ProcessC.WorkInstruction.WorkinstructionState == 3 || _ProcessC.WorkInstruction.WorkinstructionState == 4)
                SetAlarm("공정을 등록할 수 없는 작업지시서입니다.");
            else
            {
                WorkInstructions_Popup popup = new WorkInstructions_Popup(_ProcessC);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                popup.ShowDialog();

                RefreshForm();
            }
        }
        #region 검색 작업지시서 출력
        private void Btn_Print_Click(object sender, EventArgs e)
        {
            if (_ProcessC.WorkOrder.OrderNo == 0)
                SetAlarm("작업지시서를 선택 해주세요.");
            else
            {
                if (_AuthorityCtrl.GetAuthority(_LoginInfo.MemberAccess.Authorityname, "버튼 누르기"))
                {
                    _OrderChildOrder.DetailTextSave(_ProcessC);

                    Print_Form print_Form = new Print_Form(_ProcessC);

                    print_Form.StartPosition = FormStartPosition.CenterParent;
                    print_Form.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                    print_Form.ShowDialog();
                }
                else
                {
                    SetAlarm("권한이 없습니다.");
                }
            }
        }
        #endregion
        private void btn_Add_Click_1(object sender, EventArgs e)
        {
            if (_ProcessC.WorkOrder.OrderName == null)
                SetAlarm("작업지시서를 선택 해주세요.");
            else if (_ProcessC.WorkInstruction.WorkinstructionState == 3 || _ProcessC.WorkInstruction.WorkinstructionState == 4)
                SetAlarm("공정을 등록할 수 없는 작업지시서입니다.");
            else
            {
                WorkInstructions_Popup popup = new WorkInstructions_Popup(_ProcessC);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                popup.ShowDialog();

                RefreshForm();
            }
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(_ProcessC.WorkOrder.OrderName + "의 작업지시서를 삭제하시겠습니까?", "작업지시서 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            if (MessageBox.Show("정말 삭제하시겠습니까?", "작업지시서 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
            if (_ProcessC.WorkOrder.OrderNo.ToString() == "0" || _ProcessC.WorkOrder.OrderNo.ToString() == "")
                SetAlarm("작업지시서를 선택 해주세요.");
            else if (_ProcessC.WorkOrder.OrderStateName == "폐기")
                SetAlarm("폐기 된 수주의 작업지시서는 자동 폐기됩니다.");
            else
            {
                _ProcessC.DeleteInstruction();
                SetAlarm("수주명 : " + _ProcessC.WorkOrder.OrderName.ToString() + "이(가) \n 폐기 처리 되었습니다.");
                RefreshForm();
            }
        }
        private void btn_Comp_Click(object sender, EventArgs e)
        {
            //if (MessageBox.Show(_ProcessC.WorkOrder.OrderName + "의 작업지시서를 강제완료하시겠습니까?", "작업지시서 강제완료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            //if (MessageBox.Show("정말 완료하시겠습니까?", "작업지시서 강제완료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            if (MessageBox.Show(_ProcessC.WorkOrder.OrderName + "의 작업지시서를 강제완료하시겠습니까?", "작업지시서 강제완료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            if (MessageBox.Show("정말 완료하시겠습니까?", "작업지시서 강제완료", MessageBoxButtons.YesNo) == DialogResult.Yes)
            if (_ProcessC.WorkInstruction.WorkinstructionNo == 0 || _ProcessC.WorkInstruction.WorkinstructionState == 0) SetAlarm("작업지시서가 선택되지 않았거나 \n" + "공정이 등록되지 않았습니다.");
            else if (_ProcessC.WorkInstruction.WorkinstructionState == 3 || _ProcessC.WorkInstruction.WorkinstructionState == 4
                    || _ProcessC.WorkInstruction.WorkinstructionState == 5 || _ProcessC.WorkInstruction.WorkinstructionState == 6)
                    SetAlarm("출하대기, 폐기 및 완료된 수주는 강제 완료를 할 수 없습니다.");
            else
            {
                _MultiList = _ProcessC.GetCheck();
                foreach (string[] str in _MultiList)
                {
                    _ProcessC.WorkProcess.WorkOrder.OrderName = str[0];
                    _ProcessC.WorkProcess.WorkInstructionNo = Convert.ToInt64(str[1]);
                    _ProcessC.WorkProcess.WorkProcessStateName = "5";
                    _ProcessC.WorkProcess.FairName = str[4];
                    if (str[6].Equals("")) _ProcessC.WorkProcess.WorkProcessStartTime = DateTime.Now;
                    else _ProcessC.WorkProcess.WorkProcessStartTime = Convert.ToDateTime(str[6]);
                    if (str[7].Equals("")) _ProcessC.WorkProcess.WorkProcessEndTime = DateTime.Now;
                    else _ProcessC.WorkProcess.WorkProcessEndTime = Convert.ToDateTime(str[7]);

                    _ProcessC.CompleteWorkInstruction();
                }
            }
        }
    }
}