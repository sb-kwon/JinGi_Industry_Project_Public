using System;
using Controller;
using Model;
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
    public partial class DeleteCM : Form
    {
        private int _No;
        private BaseC _BaseCtrl;
        private Point mousePoint;
        private CustomerView _CustomerView;

        public DeleteCM(int CustomerNo, String str, CustomerView CustomerView)
        {
            _BaseCtrl = new BaseC();
            _No = CustomerNo;
            _CustomerView = CustomerView;

            InitializeComponent();
            Content = str;
            SetForm();
        }
        private void SetForm()
        {
            if (Content.Equals("담당자를 선택해 주세요"))
            {
                Btn_Confirm.Enabled = false;
            }
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
        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            _BaseCtrl.DeleteCusMemberData(_No);
            _CustomerView.SetDgvCompany();
            this.Close();
        }
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void lbl_Content_1_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void lbl_Content_1_MouseMove(object sender, MouseEventArgs e)
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