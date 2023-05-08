using Controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
	public partial class LoginAlarm : Form
	{
		private String _ID;
		private Point mousePoint;
		private ILoginForm _Login;

		public LoginAlarm(String contnent, string btnText1, string btnText2, string Data1, ILoginForm login)
		{
			InitializeComponent();

			_Login = login;
			this.btnText2 = btnText1;
			this.btnText2 = btnText2;
			_ID = Data1;
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
		public string btnText2
		{
			get { return this.button2.Text; }
			set
			{
				this.button2.Text = value;
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
		private void button1_Click(object sender, EventArgs e)
		{
			this.Close();
		}
		private void button2_Click(object sender, EventArgs e)
		{
			PasswordChange pc = new PasswordChange(_ID, _Login, this);
			pc.StartPosition = FormStartPosition.Manual;
			pc.Location = new Point(this.Location.X + this.Width, this.Location.Y);
			pc.Show();
		}

        private void LoginAlarm_MouseDown(object sender, MouseEventArgs e)
        {
			mousePoint = new Point(e.X, e.Y);
		}
        private void LoginAlarm_MouseMove(object sender, MouseEventArgs e)
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
