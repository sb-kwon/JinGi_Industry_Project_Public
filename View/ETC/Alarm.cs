using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
	public partial class Alarm : Form
	{
		private Point mousePoint;
		public Alarm(String contnent)
		{
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
			this.Close();
		}
        private void btn_Close_Click(object sender, EventArgs e)
        {
			this.Close();
        }
        private void Alarm_MouseDown(object sender, MouseEventArgs e)
        {
			mousePoint = new Point(e.X, e.Y);
		}
        private void Alarm_MouseMove(object sender, MouseEventArgs e)
        {
			if (e.Button == MouseButtons.Left)
			{
				int x = mousePoint.X - e.X;
				int y = mousePoint.Y - e.Y;
				Location = new Point(this.Left - x, this.Top - y);
			}
		}
		public void SetChange()
		{
			btn_Close.BackColor = Color.FromArgb(34, 36, 49);
			btn_Close.ForeColor = SystemColors.Window;
			Btn_Confirm_1.BackColor = Color.FromArgb(78, 184, 206);
			Btn_Confirm_1.ForeColor = Color.FromArgb(34, 36, 49);

			this.BackColor = Color.FromArgb(34, 36, 49);
			lbl_Content_1.ForeColor = SystemColors.Window;
		}
	}
}