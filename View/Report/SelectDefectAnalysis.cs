using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public partial class SelectDefectAnalysis : Form
    {
        private Quality _QM;
        private Point mousePoint;
        public SelectDefectAnalysis(Quality QM)
        {
            InitializeComponent();

            _QM = QM;
            SetForm();
        }
        private void SetForm()
        {
            lbl_InstructionNo.Text = _QM.InstructionNo;
            lbl_Order.Text = _QM.InnerOrder;
            lbl_Product.Text = _QM.InnerProductName;
            lbl_fiarName.Text = _QM.FairName;
            if (_QM.InnerState.Equals("양호"))
            {
                btn_good.BackColor = Color.Lime;
                btn_Discard.BackColor = SystemColors.Control;
            }
            else
            {
                btn_good.BackColor = SystemColors.Control;
                btn_Discard.BackColor = Color.Red;
            }
            lbl_Member.Text = _QM.MemberName;
            lbl_Machine.Text = _QM.Machine.MachineName;
            lbl_workProcessStartTime.Text = _QM.InnerStartTime;
            lbl_workProcessEndTime.Text = _QM.InnerEndTime;
            lbl_Manager.Text = _QM.InnerManager;
            lbl_Cause.Text = _QM.InnerCause;
            lbl_Actions.Text = _QM.InnerActions;
            lbl_Deadline.Text = _QM.InnerDeadline;
            lbl_Remark.Text = _QM.InnerRemark;
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void SelectDefectAnalysis_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }
        private void SelectDefectAnalysis_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
    }
}