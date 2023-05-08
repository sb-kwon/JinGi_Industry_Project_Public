using System;
using Controller;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    public partial class DeleteMachineAlarm : Form
    {
        private MachineC _MachineCtrl;
        private String _Machine, _Scanner;
        public DeleteMachineAlarm(String contnent, String MachineNo, String Scanner)
        {
            _MachineCtrl = new MachineC();
            _Machine = MachineNo;
            _Scanner = Scanner;

            InitializeComponent();
            Content = contnent;
        }
        public string Content
        {
            get { return this.lbl_Content_1.Text; }
            set
            {
                this.lbl_Content_1.Text = value;
                SetFontSize();
            }
        }
        private void SetFontSize()
        {
            if (lbl_Content_1.Text.Length < 30)
            {
                lbl_Content_1.Font = new Font(lbl_Content_1.Font.FontFamily, 16);
            }
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void Btn_Confirm_1_Click(object sender, EventArgs e)
        {
            _MachineCtrl.MachineDelete(_Machine);
            _MachineCtrl.DeleteMachine(_Scanner);
            this.Close();
        }
    }
}
