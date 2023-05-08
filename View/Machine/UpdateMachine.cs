using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class UpdateMachine : Form
    {
        private MachineC _MachineCtrl;
        private Machine _SelectedData;
        private MachineView _MachineView;
        private List<Machine> _LM;
        private Boolean _NumCheck;
        private Point mousePoint;
        public UpdateMachine(MachineView MachineView)
        {
            _MachineCtrl = new MachineC();
            _MachineView = MachineView;
            _SelectedData = new Machine();

            InitializeComponent();

            SetMachine();
            SetMachineList();
            ComboBoxSet();
        }
        private void SetAlarm(String str)
        {
            Alarm alarm = new Alarm(str);
            alarm.ShowDialog();
        }
        private void ComboBoxSet()
        {
            Cb_Type.SelectedIndex = 0;

            List<String> MName = _MachineCtrl.MachineList();
            cb_Machine.Items.Clear();

            foreach (String str in MName)
            {
                cb_Machine.Items.Add(str);
            }

            cb_Search.Items.Clear();
            cb_Search.Items.Add("모두");
            cb_SF_Type.Items.Clear();
            cb_SF_Type.Items.Add("모두");
            cb_Machine_Type.Items.Clear();
            cb_SF_Machine_Type.Items.Clear();

            if (_MachineCtrl.Types != null)
                foreach (string str in _MachineCtrl.Types)
                {
                    cb_Machine_Type.Items.Add(str);
                    cb_Search.Items.Add(str);
                    cb_SF_Type.Items.Add(str);
                    cb_SF_Machine_Type.Items.Add(str);
                }
            cb_Search.SelectedIndex = 0;
            cb_Machine_Type.SelectedIndex = 0;
            cb_SF_Type.SelectedIndex = 0;
            cb_SF_Machine_Type.SelectedIndex = 0;
        }
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
            dgv_SF.Rows.Clear();
            GetMachine();

            if (Machines != null)
            {
                foreach (Machine machine in Machines)
                    dgv_SF.Rows.Add(machine.MachineNo, machine.MachineName, machine.MachineType, machine.MachineManagementNo, machine.MachineCompany,
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
            if (Cb_Type.Text.Equals("가공기"))
            {
                DataGridView dgv = (DataGridView)sender;

                if (dgv.SelectedRows.Count != 0)
                {
                    DataGridViewRow dgvr = dgv.SelectedRows[0];

                    if (!(dgvr.Cells[0].Value is null))
                    {
                        _SelectedData.MachineNo = (int)dgvr.Cells[0].Value;
                        _SelectedData.MachineName = dgvr.Cells[1].Value.ToString();
                        _SelectedData.MachineType = dgvr.Cells[2].Value.ToString();
                        _SelectedData.MachineManagementNo = dgvr.Cells[3].Value.ToString();
                        _SelectedData.MachineCompany = dgvr.Cells[4].Value.ToString();
                        _SelectedData.MachineDay = dgvr.Cells[5].Value.ToString();
                        _SelectedData.MachineManager = dgvr.Cells[6].Value.ToString();
                        _SelectedData.MachineLocation = dgvr.Cells[7].Value.ToString();
                        _SelectedData.MachineNote = dgvr.Cells[8].Value.ToString();
                        _SelectedData.MachineETC = dgvr.Cells[9].Value.ToString();
                    }
                }
                SetSelectData();
            }
        }
        private void dgv_machine_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (Cb_Type.Text.Equals("SF_HardWare"))
            {
                DataGridView dgv = (DataGridView)sender;

                if (dgv.SelectedRows.Count != 0)
                {
                    DataGridViewRow dgvr = dgv.SelectedRows[0];

                    if (!(dgvr.Cells[0].Value is null))
                    {
                        _SelectedData.MachineNo = (int)dgvr.Cells[0].Value;
                        _SelectedData.MachineName = dgvr.Cells[1].Value.ToString();
                        _SelectedData.MachineType = dgvr.Cells[2].Value.ToString();
                        _SelectedData.MachineManagementNo = dgvr.Cells[3].Value.ToString();
                        _SelectedData.MachineCompany = dgvr.Cells[4].Value.ToString();
                        _SelectedData.MachineDay = dgvr.Cells[5].Value.ToString();
                        _SelectedData.MachineLocation = dgvr.Cells[6].Value.ToString();
                        _SelectedData.MachineETC = dgvr.Cells[7].Value.ToString();
                    }
                }
                SetSelectData();
            }
        }
        #endregion
        #region 검색 Button Event
        private void Cb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cb_Type.Text == "가공기")
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Size = new Size(1286, 629);

                pnl_Machine.BringToFront();
                pnl_SF.Visible = false;
                pnl_Machine.Visible = true;
            }
            else if (Cb_Type.Text == "SF_HardWare")
            {
                this.FormBorderStyle = FormBorderStyle.None;
                this.StartPosition = FormStartPosition.CenterScreen;
                this.Size = new Size(1286, 629);

                pnl_SF.BringToFront();
                pnl_SF.Visible = true;
                pnl_Machine.Visible = false;
            }
        }
        private void SetSelectData()
        {
            tb_MachineName.Text = _SelectedData.MachineName;
            lbl_No.Text = _SelectedData.MachineNo.ToString();
            tb_Company.Text = _SelectedData.MachineCompany;
            tb_ManagementNo.Text = _SelectedData.MachineManagementNo;
            cb_Machine_Type.Text = _SelectedData.MachineType;
            DTP_Day.Text = _SelectedData.MachineDay;
            tb_Manager.Text = _SelectedData.MachineManager;
            tb_Location.Text = _SelectedData.MachineLocation;
            tb_Note.Text = _SelectedData.MachineNote;
            tb_ETC.Text = _SelectedData.MachineETC;

            lbl_SF_No.Text = _SelectedData.MachineNo.ToString();
            tb_SF_Name.Text = _SelectedData.MachineName;
            cb_SF_Machine_Type.Text = _SelectedData.MachineType;
            tb_Model.Text = _SelectedData.MachineManagementNo;
            tb_SF_Company.Text = _SelectedData.MachineCompany;
            DTP_SF_Buy.Text = _SelectedData.MachineDay;
            tb_SF_Location.Text = _SelectedData.MachineLocation;
            tb_SF_Memo.Text = _SelectedData.MachineETC;

        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (Cb_Type.Text == "가공기")
            {
                if (_NumCheck)
                {
                    Machine machine = new Machine();
                    machine.MachineNo = Convert.ToInt32(lbl_No.Text);
                    machine.MachineName = tb_MachineName.Text;
                    machine.MachineType = cb_Machine_Type.Text;
                    machine.MachineCompany = tb_Company.Text;
                    machine.MachineDay = DTP_Day.Text;
                    machine.MachineManagementNo = tb_ManagementNo.Text;
                    machine.MachineManager = tb_Manager.Text;
                    machine.MachineLocation = tb_Location.Text;
                    machine.MachineNote = tb_Note.Text;
                    machine.MachineETC = tb_ETC.Text;

                    _MachineCtrl.ModifyMachine(machine);
                    _MachineView.SetMachineList();
                    _MachineView.Reset();
                    SetAlarm("설비 정보 수정이 완료 되었습니다.");
                    this.Close();
                }
                else
                {
                    SetAlarm("중복확인이 필요합니다.");
                }
            }
            else if (Cb_Type.Text == "SF_HardWare")
            {
                if (_NumCheck)
                {
                    Machine machine = new Machine();
                    machine.MachineName = tb_SF_Name.Text;
                    machine.MachineType = cb_SF_Machine_Type.Text;
                    machine.MachineManagementNo = tb_Model.Text;
                    machine.MachineCompany = tb_SF_Company.Text;
                    machine.MachineDay = Convert.ToDateTime(DTP_SF_Buy.Text).ToString("yyyy-MM-dd");
                    machine.MachineLocation = tb_SF_Location.Text;
                    machine.MachineETC = tb_ETC.Text;
                    machine.MachineNo = Convert.ToInt32(lbl_SF_No.Text);

                    _MachineCtrl.UpdateMachine(machine);
                    _MachineView.SetMachine();
                    _MachineView.Reset();
                    SetAlarm("설비 정보 수정이 완료 되었습니다.");
                    this.Close();
                }
                else
                {
                    SetAlarm("중복확인이 필요합니다.");
                }
            }
            //_MachineView.ClearDGV();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_N_Check_Click(object sender, EventArgs e)
        {
            if (Cb_Type.Text == "가공기")
            {
                if (tb_ManagementNo.Text.Length > 0)
                {
                    _NumCheck = _MachineCtrl.CheckMachineNo("MachineManagementNo", "'" + tb_ManagementNo.Text + "'"); //관리 번호로 바꿔야함
                    String str = "이미 존재하는 장비 이름 입니다.";
                    if (_NumCheck)
                    {
                        tb_ManagementNo.ReadOnly = true;
                        btn_N_Check.Enabled = false;
                        str = "사용가능한 장비 이름 입니다.";
                    }
                    SetAlarm(str);
                }
            }

            else if (Cb_Type.Text == "SF_HardWare")
            {
                if (tb_Model.Text.Length > 0)
                {
                    _NumCheck = _MachineCtrl.CheckName("SF_Machine_Model", "'" + tb_Model.Text + "'");
                    String str = "이미 존재하는 모델명 입니다.";
                    if (_NumCheck)
                    {
                        tb_Model.ReadOnly = true;
                        btn_SF_Check.Enabled = false;
                        str = "사용가능한 장비 이름 입니다.";
                    }
                    SetAlarm(str);
                }
            }
        }
        private void Btn_Search_Click(object sender, EventArgs e)
        {
            if (Cb_Type.Text == "SF_HardWare")
            {
                dgv_SF.Rows.Clear();
                List<Machine> list = _MachineCtrl.SF_Machine;
                if (list != null)
                {
                    foreach (Machine machine in list)
                    {
                        if (machine.MachineName.IndexOf(tb_Search_Name.Text) != -1)
                        {
                            if (cb_SF_Type.SelectedItem.Equals("모두") || cb_SF_Type.SelectedItem.Equals(machine.MachineType))
                                dgv_SF.Rows.Add(machine.MachineNo, machine.MachineName, machine.MachineType, machine.MachineManagementNo, machine.MachineCompany,
                                                machine.MachineDay, machine.MachineLocation, machine.MachineETC);
                        }
                    }
                }
                ViewReset();
            }
            #region 스캐너
            //if (!(Cb_SelectBox.SelectedIndex == -1))
            //{
            //    String Value = Cb_SelectBox.SelectedItem.ToString();
            //    string result = "";
            //    switch (Value)
            //    {
            //        case "스캐너 번호":
            //            result = "BcrPortName";
            //            break;
            //        case "스캐너 명":
            //            result = "BcrMachineName";
            //            break;
            //        case "설비 명":
            //            result = "BcrMapping";
            //            break;
            //    }
            //    dgv_machine.Rows.Clear();
            //
            //    List<Machine> machines = new List<Machine>();
            //    machines = _MachineCtrl.SearchData(result, tb_SelectData.Text);
            //
            //    if (machines is null || string.IsNullOrEmpty(tb_SelectData.Text))
            //    {
            //        SetAlarm("검색어를 입력해주세요.");
            //        SetMachine();
            //    }
            //    else
            //    {
            //        if (machines.Count != 0)
            //        {
            //            foreach (Machine machine in machines)
            //            {
            //                dgv_machine.Rows.Add(machine.PortName, machine.ScannerMachineName, machine.MachineScanner);
            //                //dgv_machine_info.Rows.Add(machine.Machinename, machine.machineType);
            //            }
            //        }
            //        else
            //        {
            //            SetAlarm("검색 된 내용이 없습니다.");
            //            SetMachine();
            //            tb_SelectData.Text = string.Empty;
            //        }
            //    }
            //}
            #endregion
            else if (Cb_Type.Text == "가공기")
            {
                dgv_machine_info.Rows.Clear();
                List<Machine> list = _MachineCtrl.Machine;
                if (list != null)
                {
                    foreach (Machine machine in list)
                    {
                        if (machine.MachineName.IndexOf(tb_Search.Text) != -1)
                        {
                            if (cb_Search.SelectedItem.Equals("모두") || cb_Search.SelectedItem.Equals(machine.MachineType))
                                dgv_machine_info.Rows.Add(machine.MachineNo, machine.MachineName, machine.MachineType, machine.MachineManagementNo, machine.MachineCompany,
                                                          machine.MachineDay, machine.MachineManager, machine.MachineLocation, machine.MachineNote, machine.MachineETC);
                        }
                    }
                }
                ViewReset();
            }
            //_MachineView.ClearDGV();
        }
        private void btn_Refresh_Click(object sender, EventArgs e)
        {
            SetMachine();
            SetMachineList();
            ViewReset();
        }
        private void UpdateMachine_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }

        private void UpdateMachine_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }
        #endregion
        private void ViewReset()
        {
            tb_MachineName.Text = "";
            tb_Company.Text = "";
            tb_ManagementNo.Text = "";
            tb_Location.Text = "";
            tb_ETC.Text = "";
            tb_Note.Text = "";
            tb_Manager.Text = "";
            cb_Machine_Type.SelectedIndex = 0;
            tb_ManagementNo.ReadOnly = false;
            btn_N_Check.Enabled = true;
            DTP_Day.Text = DateTime.Now.ToString();

            tb_PortName.Text = "";
            tb_ScannerName.Text = "";
            cb_Machine.SelectedIndex = 0;

            cb_Search.SelectedIndex = 0;
            Cb_SelectBox.SelectedIndex = 0;
            tb_Search.Text = "";
            tb_SelectData.Text = "";

            cb_SF_Type.SelectedIndex = 0;
            cb_SF_Machine_Type.SelectedIndex = 0;
            tb_SF_Name.Text = "";
            tb_Model.Text = "";
            tb_SF_Location.Text = "";
            tb_SF_Company.Text = "";
            tb_SF_Memo.Text = "";
            tb_Model.ReadOnly = false;
            btn_SF_Check.Enabled = true;
            DTP_SF_Buy.Text = DateTime.Now.ToString();
        }
    }
}
