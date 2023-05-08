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
    public partial class DeleteCustomer : Form
    {
        private int _No;
        private BaseC _BaseCtrl;
        private Point mousePoint;
        private CustomerView _CustomerView;

        public DeleteCustomer(int CustomerNo, String str, CustomerView CustomerView)
        {
            _BaseCtrl = new BaseC();
            _No = CustomerNo;
            _CustomerView = CustomerView;

            InitializeComponent();
            Content = str;
        }
        public string Content
        {
            get { return this.lbl_Content.Text; }
            set
            {
                this.lbl_Content.Text = value;
                SetFontSize();
            }
        }
        private void SetFontSize()
        {
            if (lbl_Content.Text.Length < 30)
            {
                lbl_Content.Font = new Font(lbl_Content.Font.FontFamily, 16);
            }
        }
        private void Btn_Confirm_Click(object sender, EventArgs e)
        {
            _BaseCtrl.DeleteCustomerData(_No);
            _CustomerView.SetDgvCompany();
            this.Close();
        }
        private void Btn_Close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void DeleteCustomer_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void DeleteCustomer_MouseMove(object sender, MouseEventArgs e)
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