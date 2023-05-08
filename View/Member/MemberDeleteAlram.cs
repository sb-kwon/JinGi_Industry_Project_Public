using Controller;
using System;
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
	public partial class MemberDeleteAlram : Form
	{
		private Member_Ctrl _memberController;
		private String _Memberview;
        private Point mousePoint;

        public MemberDeleteAlram(String contnent, String memberId, MemberView memberview)
		{
			_memberController = new Member_Ctrl();
			_Memberview = memberId;

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
		public void Btn_Confirm_1_Click(object sender, EventArgs e)
		{
			_memberController.DeleteMembere(_Memberview);
			this.Close();
		}
		private void btn_Close_Click(object sender, EventArgs e)
		{
			this.Close();
		}
        private void MemberDeleteAlram_MouseDown(object sender, MouseEventArgs e)
        {
			mousePoint = new Point(e.X, e.Y);
		}
		private void MemberDeleteAlram_MouseMove(object sender, MouseEventArgs e)
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
