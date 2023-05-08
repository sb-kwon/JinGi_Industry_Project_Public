using System;
using System.Drawing;
using System.Collections.Generic;
using System.Windows.Forms;
using Controller;
using Model;

namespace View
{
    public partial class AddMachine : Form
    {
        private MachineC _MachineCtrl;
        private MachineView _MachineView;
        private Boolean _NameCheck;
        private Boolean _NumCheck;
        private Point mousePoint;
        public AddMachine(MachineView Machineview)
        {
            _MachineCtrl = new MachineC();
            _MachineView = Machineview;

            InitializeComponent();
            ComboBoxSet();
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

            List<String> Type = _MachineCtrl.Types;
            cb_SF_Type.Items.Clear();
            cb_Machine_type.Items.Clear();

            foreach (String str in Type)
            {
                cb_SF_Type.Items.Add(str);
                cb_Machine_type.Items.Add(str);
            }
        }
        private void SetAlarm(String str)
        {
            Alarm alarm = new Alarm(str);
            alarm.ShowDialog();
        }
        #region 검색 Button Event
        private void Cb_Type_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Cb_Type.Text == "가공기")
            {
                pnl_Machine.BringToFront();
                pnl_SF.Visible = false;
                pnl_Machine.Visible = true;

                this.FormBorderStyle = FormBorderStyle.None;
                this.Size = new Size(766, 353);
            }
            else if (Cb_Type.Text == "SF_HardWare")
            {
                pnl_SF.BringToFront();
                pnl_SF.Visible = true;
                pnl_Machine.Visible = false;

                this.FormBorderStyle = FormBorderStyle.None;
                this.Size = new Size(766, 315);
            }
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (Cb_Type.Text == "가공기")
            {
                if (_NameCheck)
                {
                    Machine machine = new Machine();
                    machine.MachineName = tb_MachineName.Text;
                    machine.MachineType = cb_Machine_type.Text;
                    machine.MachineCompany = tb_Company.Text;
                    machine.MachineDay = DTP_Day.Text;
                    machine.MachineManagementNo = tb_No.Text;
                    machine.MachineManager = tb_Manager.Text;
                    machine.MachineLocation = tb_Location.Text;
                    machine.MachineNote = tb_Note.Text;
                    machine.MachineETC = tb_ETC.Text;

                    _MachineCtrl.AdditionalMachine(machine);
                    _MachineView.SetMachineList();
                    _MachineView.Reset();
                    SetAlarm("설비 정보 추가가 완료 되었습니다.");
                    ViewReset();
                    this.Close();
                }
                else
                {
                    SetAlarm("중복확인이 필요합니다.");
                }
            }
            else if (Cb_Type.Text == "SF_HardWare")
            {
                if (_NameCheck)
                {
                    Machine machine = new Machine();
                    machine.MachineName = tb_SF_Name.Text;
                    machine.MachineType = cb_SF_Type.Text;
                    machine.MachineManagementNo = tb_Model.Text;
                    machine.MachineCompany = tb_SF_Company.Text;
                    machine.MachineDay = DTP_SF_Buy.Text;
                    machine.MachineLocation = tb_SF_Location.Text;
                    machine.MachineETC = tb_SF_Memo.Text;

                    _MachineCtrl.AddMachine(machine);
                    _MachineView.SetMachine();
                    _MachineView.Reset();
                    SetAlarm("설비 정보 추가가 완료 되었습니다.");
                    ViewReset();
                    this.Close();
                }
                else
                {
                    SetAlarm("중복확인이 필요합니다.");
                }
                #region 스캐너
                //if (_NameCheck && _NumCheck)
                //{
                //    Machine machine = new Machine();
                //    machine.ScannerMachineName = tb_ScannerName.Text;
                //    machine.PortName = tb_PortName.Text;
                //    machine.BaudRate = (int)9600;
                //    machine.DataBits = (int)8;
                //    machine.Parity = "None";
                //    machine.StopBits = "One";
                //    machine.MachineScanner = cb_Machine.Text;
                //
                //    _MachineCtrl.AddMachine(machine);
                //    _MachineView.SetMachine();
                //    _MachineView.Reset();
                //    SetAlarm("설비 정보 추가가 완료 되었습니다.");
                //    ViewReset();
                //    this.Close();
                //}
                //else
                //{
                //    SetAlarm("중복확인이 필요합니다.");
                //}
                #endregion
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            ViewReset();
        }
        private void btn_S_Check_Click(object sender, EventArgs e)
        {
            if (Cb_Type.Text == "가공기")
            {
                if (tb_MachineName.Text.Length > 0)
                {
                    _NameCheck = _MachineCtrl.CheckMachineName("MachineName", "'" + tb_MachineName.Text + "'");
                    String str = "이미 존재하는 장비 이름 입니다.";
                    if (_NameCheck)
                    {
                        tb_MachineName.ReadOnly = true;
                        btn_M_Check.Enabled = false;
                        str = "사용가능한 장비 이름 입니다.";
                    }
                    SetAlarm(str);
                }
            }

            else if (Cb_Type.Text == "SF_HardWare")
            {
                if (tb_SF_Name.Text.Length > 0)
                {
                    _NameCheck = _MachineCtrl.CheckName("SF_Machine_Name", "'" + tb_SF_Name.Text + "'");
                    String str = "이미 존재하는 장비 이름 입니다.";
                    if (_NameCheck)
                    {
                        tb_SF_Name.ReadOnly = true;
                        btn_SF_Check.Enabled = false;
                        str = "사용가능한 장비 이름 입니다.";
                    }
                    SetAlarm(str);
                }
            }
        }
        private void btn_Port_Check_Click(object sender, EventArgs e)
        {
            if (Cb_Type.Text == "SF_HardWare")
            {
                if (tb_PortName.Text.Length > 0)
                {
                    _NumCheck = _MachineCtrl.CheckName("BcrPortName", "'" + "COM" + tb_PortName.Text + "'");
                    String str = "이미 존재하는 포트 번호 입니다.";
                    if (_NumCheck)
                    {
                        tb_PortName.ReadOnly = true;
                        btn_Port_Check.Enabled = false;
                        str = "사용가능한 포트 번호입니다.";
                    }
                    SetAlarm(str);
                }
            }
            else if (Cb_Type.Text == "가공기")
            {
                if (tb_No.Text.Length > 0)
                {
                    _NumCheck = _MachineCtrl.CheckMachineNo("MachineNo", "'" + tb_No.Text + "'");
                    String str = "이미 존재하는 관리 번호 입니다.";
                    if (_NumCheck)
                    {
                        tb_No.ReadOnly = true;
                        btn_N_Check.Enabled = false;
                        str = "사용가능한 관리 번호입니다.";
                    }
                    SetAlarm(str);
                }
            }
        }
        private void AddMachine_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void AddMachine_MouseMove(object sender, MouseEventArgs e)
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
            tb_PortName.Text = "";
            tb_ScannerName.Text = "";
            tb_Company.Text = "";
            tb_No.Text = "";
            cb_Machine.Text = null;
            cb_Machine_type.Text = null;
            DTP_Day.Text = DateTime.Now.ToString();

            tb_ScannerName.ReadOnly = false;
            tb_PortName.ReadOnly = false;
            btn_M_Check.Enabled = true;
            btn_Port_Check.Enabled = true;

            tb_MachineName.ReadOnly = false;
            tb_No.ReadOnly = false;
            btn_M_Check.Enabled = true;
            btn_N_Check.Enabled = true;
            btn_SF_Check.Enabled = true;

            tb_SF_Name.Text = null;
            tb_SF_Name.ReadOnly = false;
            tb_SF_Company.Text = null;
            tb_SF_Location.Text = null;
            tb_Model.Text = null;
            cb_SF_Type.Text = null;
            tb_SF_Memo.Text = null;
            DTP_SF_Buy.Text = DateTime.Now.ToString();
        }
    }
}
