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
    public partial class WorkInstructions_Popup_Click : Form
    {
        private ProcessC _ProcessC;
        private Point mousePoint;
        private String _Check;
        public WorkInstructions_Popup_Click(ProcessC processC)
        {
            _ProcessC = processC;
            InitializeComponent();

            _Check = "0";
            SetComboBox1();
            SetComboBox2();
            textBox1.Text = _ProcessC.WorkProcess.FairReal;
            textBox2.Text = _ProcessC.WorkProcess.FairName;
            dtp_start.Value = Convert.ToDateTime(_ProcessC.WorkProcess.WorkProcessPlanStart);
            dtp_end.Value = Convert.ToDateTime(_ProcessC.WorkProcess.WorkProcessPlanEnd);
            txt_memo.Text = _ProcessC.WorkProcess.WorkProcessMemo.ToString();
            if (_ProcessC.WorkProcess.MachineName != "")
            {
                ck_machine.Checked = true;
                cb_machine.Enabled = true;
                cb_machine.Text = _ProcessC.WorkProcess.MachineName.ToString();
            }
            if (_ProcessC.WorkProcess.MemberName != "")
            {
                ck_member.Checked = true;
                cb_member.Enabled = true;
                cb_member.Text = _ProcessC.WorkProcess.MemberName.ToString();
            }
        }
        private void SetComboBox1()
        {
            cb_machine.Items.Clear();

            List<String[]> list2 = new List<string[]>();
            list2 = _ProcessC.GetComboMachine();

            if (!(list2 is null))
            {
                foreach (string[] str in list2)
                {
                    ComboboxItem cbi = new ComboboxItem();
                    cbi.Text = str[1]; //name
                    cbi.Value = str[0];//id
                    cb_machine.Items.Add(cbi);
                }
            }
        }
        private void SetComboBox2()
        {
            cb_member.Items.Clear();

            List<String[]> list = new List<string[]>();
            list = _ProcessC.GetComboMember();

            if (!(list is null))
            {
                foreach (string[] str in list)
                {
                    ComboboxItem cbi = new ComboboxItem();
                    cbi.Text = str[1] + "(" + str[0] + ")"; //name
                    cbi.Value = str[0];//id
                    cb_member.Items.Add(cbi);
                }
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_order_save_Click(object sender, EventArgs e)
        {
            TimeCompare();
            if (_Check.Equals("0"))
            {
                if (ck_machine.Checked == true || ck_member.Checked == true)
                {
                    if (ck_member.Checked == true && !(cb_member.SelectedItem as ComboboxItem).Text.Equals(cb_member.Text))
                        SetAlarm("작업자 이름을 확인해주세요.");
                    else if (ck_machine.Checked == true && !(cb_machine.SelectedItem as ComboboxItem).Text.Equals(cb_machine.Text))
                        SetAlarm("장비명을 확인해주세요.");
                    else
                    {
                        detail_save();
                    }
                }
                else
                {
                    detail_save();
                }
            }
        }
        private void detail_save()
        {
            _ProcessC.WorkProcess.WorkProcessPlanStart = dtp_start.Value.ToString("yyyy-MM-dd");
            _ProcessC.WorkProcess.WorkProcessPlanEnd = dtp_end.Value.ToString("yyyy-MM-dd");
            _ProcessC.WorkProcess.MemberName = "";
            _ProcessC.WorkProcess.MemberId = "";
            _ProcessC.WorkProcess.MachineName = "";
            _ProcessC.WorkProcess.MachineNo = 0;

            foreach (ComboboxItem ci in cb_member.Items)
            {
                if (ci.Text.Equals(cb_member.Text))
                {
                    _ProcessC.WorkProcess.MemberName = (ci as ComboboxItem).Text;
                    _ProcessC.WorkProcess.MemberId = (ci as ComboboxItem).Value.ToString();
                }
            }
            foreach (ComboboxItem ci in cb_machine.Items)
            {
                if (ci.Text.Equals(cb_machine.Text))
                {
                    _ProcessC.WorkProcess.MachineName = (ci as ComboboxItem).Text;
                    _ProcessC.WorkProcess.MachineNo = Convert.ToInt32((ci as ComboboxItem).Value);
                }
            }
            _ProcessC.WorkProcess.WorkProcessMemo = txt_memo.Text;

            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ck_member.Checked = true;
            cb_member.Enabled = true;

            SearchBox popup = new SearchBox(_ProcessC, "작업자");
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            popup.ShowDialog();

            cb_member.Text = _ProcessC.WorkProcess.MemberName + "(" + _ProcessC.WorkProcess.MemberId + ")";
        }

        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ck_machine.Checked = true;
            cb_machine.Enabled = true;

            SearchBox popup = new SearchBox(_ProcessC, "장비명");
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            popup.ShowDialog();

            cb_machine.Text = _ProcessC.WorkProcess.MachineName;
        }

        private void ck_member_CheckedChanged(object sender, EventArgs e)
        {
            cb_member.Items.Clear();
            SetComboBox2();

            if (ck_member.Checked == true)
                cb_member.Enabled = true;
            else
                cb_member.Enabled = false;
        }

        private void ck_machine_CheckedChanged(object sender, EventArgs e)
        {
            cb_machine.Items.Clear();
            SetComboBox1();

            if (ck_machine.Checked == true)
                cb_machine.Enabled = true;
            else
                cb_machine.Enabled = false;
        }
        private void TimeCompare()
        {
            _Check = "0";
            int Timeresult = DateTime.Compare(dtp_start.Value, dtp_end.Value);
            int result = DateTime.Compare(dtp_start.Value, dtp_end.Value);

            if (Timeresult > 0 && dtp_start.Value.ToString("yyyy-MM-dd") != DateTime.Now.ToString("yyyy-MM-dd"))
            {
                SetAlarm("시작일을 다시 확인 해주세요.");
                dtp_start.Value = DateTime.Now;
                _Check = "1";
            }
            if (result > 0)
            {
                SetAlarm("종료일을 다시 확인 해주세요.");
                dtp_end.Value = DateTime.Now;
                _Check = "2";
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
