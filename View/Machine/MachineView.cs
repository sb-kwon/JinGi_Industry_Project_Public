using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace View
{
    public partial class MachineView : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private List<Machine> _LM;
        private Machine _SelectedData;
        private MachineC _MachineCtrl;

        public MachineView(Member member, BasicForm form)
        {
            InitializeComponent();
            _Mother = form;
            _LoginInfo = member;
            _SelectedData = new Machine();
            _MachineCtrl = new MachineC();

            SetMachine();
            SetMachineList();
        }
        #region IBasicForm
        private void Alarm(String str)
        {
            Alarm Alarm = new Alarm(str);
            Alarm.ShowDialog();
        }
        public string GetText()
        {
            return this.Text;
        }
        public void RefreshForm()
        {
            SetMachine();
            SetMachineList();
            Reset();
            //ClearDGV();
        }
        public Form SetForm()
        {
            return this;
        }
        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }
        public void Reset()
        {
            cb_Type.SelectedIndex = 0;
            Cb_Scanner.SelectedIndex = 0;
            cb_Machine.SelectedIndex = 0;
            tb_Scanner.Text = "";
            tb_Machine.Text = "";
        }
        #endregion
        public List<Machine> Machines
        {
            get { return _LM; }
            set { _LM = value; }
        }
        private void GetMachine()
        {
            _MachineCtrl.GetMachine();
            Machines = _MachineCtrl.SF_Machine;
        }
        private void GetMachineList()
        {
            _MachineCtrl.GetMachineList();
            Machines = _MachineCtrl.Machine;
        }
        #region 검색 DGV
        public void SetMachine()
        {
            SetComboBox();
            dgv_machine.Rows.Clear();
            GetMachine();

            if (Machines != null)
            {
                foreach (Machine machine in Machines)
                    dgv_machine.Rows.Add(machine.MachineNo, machine.MachineName, machine.MachineType, machine.MachineManagementNo, machine.MachineCompany,
                                         machine.MachineDay, machine.MachineLocation, machine.MachineETC);
            }
        }
        public void SetMachineList()
        {
            dgv_machine_info.Rows.Clear();
            GetMachineList();

            if (Machines != null)
            {
                foreach (Machine machines in Machines)
                    dgv_machine_info.Rows.Add(machines.MachineNo, machines.MachineName, machines.MachineType, machines.MachineManagementNo, machines.MachineCompany,
                                              machines.MachineDay, machines.MachineManager, machines.MachineLocation, machines.MachineNote, machines.MachineETC);
            }
        }
        private void dgv_machine_info_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedRows.Count != 0)
            {
                DataGridViewRow dgvr = dgv.SelectedRows[0];

                if (!(dgvr.Cells[0].Value is null))
                {
                    _SelectedData.MachineNo = Convert.ToInt32(dgvr.Cells[0].Value);
                    _SelectedData.MachineName = dgvr.Cells[1].Value.ToString();
                }
            }
        }

        private void dgv_machine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridView dgv = (DataGridView)sender;

            if (dgv.SelectedRows.Count != 0)
            {
                DataGridViewRow dgvr = dgv.SelectedRows[0];

                if (!(dgvr.Cells[0].Value is null))
                {
                    _SelectedData.MachineScanner = dgvr.Cells[0].Value.ToString();
                    _SelectedData.ScannerMachineName = dgvr.Cells[1].Value.ToString();
                }
            }
        }
        #endregion
        #region 검색 Button Event
        private void btn_machine_add_Click(object sender, EventArgs e)
        {
            AddMachine machineAdditional = new AddMachine(this);
            machineAdditional.StartPosition = FormStartPosition.CenterParent;
            machineAdditional.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            machineAdditional.ShowDialog();
        }
        private void btn_machine_update_Click(object sender, EventArgs e)
        {
            UpdateMachine modifyMachine = new UpdateMachine(this);
            modifyMachine.StartPosition = FormStartPosition.CenterParent;
            modifyMachine.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            modifyMachine.ShowDialog();
        }
        private void btn_machine_delete_Click(object sender, EventArgs e)
        {
            if (_SelectedData.MachineName is null && _SelectedData.ScannerMachineName is null)
            {
                Alarm("삭제할 항목을 선택해 주십시오.");
            }
            else if (!(_SelectedData.MachineName is null))
            {
                DeleteAlarm(_SelectedData.MachineName + " 을(를) 삭제하시겠습니까?");
                _SelectedData.MachineName = null;
            }
            else //if (_SelectedData.ScannerMachineName.Length > 0)
            {
                DeleteAlarm(_SelectedData.ScannerMachineName + " 을(를) 삭제하시겠습니까?");
                _SelectedData.ScannerMachineName = null;
            }
            SetMachineList();
            SetMachine();
        }
        private void cb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cb_Type.Text == "가공기")
            {
                cb_Machine.BringToFront();
                tb_Machine.BringToFront();
            }
            else
            {
                Cb_Scanner.BringToFront();
                tb_Scanner.BringToFront();
            }
        }
        private void DeleteAlarm(String str)
        {
            DeleteMachineAlarm alarm_D = new DeleteMachineAlarm(str, _SelectedData.MachineNo.ToString(), _SelectedData.MachineScanner);
            alarm_D.StartPosition = FormStartPosition.CenterParent;
            alarm_D.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm_D.ShowDialog();
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            if (cb_Type.Text == "SF_HardWare")
            {
                dgv_machine.Rows.Clear();
                List<Machine> list = _MachineCtrl.SF_Machine;
                if (list != null)
                {
                    foreach (Machine machine in list)
                    {
                        if (machine.MachineName.IndexOf(tb_Scanner.Text) != -1)
                        {
                            if (Cb_Scanner.SelectedItem.Equals("모두") || Cb_Scanner.SelectedItem.Equals(machine.MachineType))
                                dgv_machine.Rows.Add(machine.MachineNo, machine.MachineName, machine.MachineType, machine.MachineManagementNo, machine.MachineCompany,
                                                     machine.MachineDay, machine.MachineLocation, machine.MachineETC);
                        }
                    }
                }
            }
            else if (cb_Type.Text == "가공기")
            {
                dgv_machine_info.Rows.Clear();
                List<Machine> list = _MachineCtrl.Machine;
                if (list != null)
                {
                    foreach (Machine machine in list)
                    {
                        if (machine.MachineName.IndexOf(tb_Machine.Text) != -1)
                        {
                            if (cb_Machine.SelectedItem.Equals("모두") || cb_Machine.SelectedItem.Equals(machine.MachineType))
                                dgv_machine_info.Rows.Add(machine.MachineNo, machine.MachineName, machine.MachineType, machine.MachineManagementNo, machine.MachineCompany,
                                                          machine.MachineDay, machine.MachineManager, machine.MachineLocation, machine.MachineNote, machine.MachineETC);
                        }
                    }
                }
            }
            Reset();
        }
        //ClearDGV();
        #endregion
        public void ClearDGV()
        {
            dgv_machine.ClearSelection();
            dgv_machine_info.ClearSelection();
        }
        private void MachineView_Load(object sender, EventArgs e)
        {
            ClearDGV();
        }
        private void SetComboBox()
        {
            cb_Machine.Items.Clear();
            Cb_Scanner.Items.Clear();
            cb_Machine.Items.Add("모두");
            Cb_Scanner.Items.Add("모두");

            if (_MachineCtrl.Types != null)
                foreach (string str in _MachineCtrl.Types)
                {
                    cb_Machine.Items.Add(str);
                    Cb_Scanner.Items.Add(str);
                }

            cb_Type.SelectedIndex = 0;
            cb_Machine.SelectedIndex = 0;
            Cb_Scanner.SelectedIndex = 0;
        }
    }
}