using System;
using System.Drawing;
using System.Windows.Forms;


using Controller;
using Model;

namespace View
{
	public partial class LoginForm : Form, ILoginForm
	{
		//Local Value
		//---------------------------------------------
		private Point mousePoint;
		public string testlogin;
		private BaseC _BaseCtrl;
		private Member _LoginData;
		//---------------------------------------------
		//Getter And Setter
		//---------------------------------------------
		public Member LoginData
		{
			get { return _LoginData; }
			set { _LoginData = value; }
		}
		public String ID
		{
			get { return this.tb_ID.Text; }
		}
		public string PassWord
		{
			get { return this.tb_PassWord.Text; }
		}
		//---------------------------------------------
		//Init
		//---------------------------------------------
		public LoginForm()
		{
			InitializeComponent();
			_BaseCtrl = new BaseC(this);
		}
		//---------------------------------------------
		//Method Function
		//---------------------------------------------
		public void LoginAlarm(String LoingLink)
		{
			LoginAlarm alarm = new LoginAlarm(LoingLink, "나중에 변경", "지금 변경", LoginData.Memberid, this);
			alarm.ShowDialog();
		}
		public void SetAlarm(String contnent)
		{
			Alarm alarm = new Alarm(contnent);
			alarm.ShowDialog();
		}
		//---------------------------------------------
		//UI Function
		//---------------------------------------------
		public void ResultOk()
		{
			((BasicForm)(this.Owner)).LoginInfo = LoginData;
			this.DialogResult = DialogResult.OK;
		}
		private void btn_Login_Click_1(object sender, EventArgs e)
		{
			if (tb_ID.Text.Length != 0 || tb_PassWord.Text.Length != 0)
			{
				if (_BaseCtrl.TextBoxCheck(ID, PassWord))
					_BaseCtrl.LoginCheck(ID, PassWord);
			}
		}
		private void btn_Exit_Click_1(object sender, EventArgs e)
		{
			CloseForm();
		}
		private void btn_SignUp_Click(object sender, EventArgs e)
		{
			SignUp signUp = new SignUp(this);

			signUp.StartPosition = FormStartPosition.Manual;
			signUp.Location = new Point(this.Location.X + this.Width, this.Location.Y);
			signUp.Show();
		}
		private void tb_ID_Click(object sender, EventArgs e)
		{
			tb_ID.Clear();
			panel1.BackColor = Color.FromArgb(78, 184, 206);
			tb_ID.ForeColor = Color.FromArgb(78, 184, 206);
			lbl_ID.ForeColor = Color.FromArgb(78, 184, 206);

			panel2.BackColor = Color.White;
			tb_PassWord.ForeColor = Color.White;
			lbl_PW.ForeColor = Color.White;
		}
		private void tb_PassWord_Click(object sender, EventArgs e)
		{
			tb_PassWord.Clear();
			tb_PassWord.PasswordChar = '*';
			panel2.BackColor = Color.FromArgb(78, 184, 206);
			tb_PassWord.ForeColor = Color.FromArgb(78, 184, 206);
			lbl_PW.ForeColor = Color.FromArgb(78, 184, 206);

			panel1.BackColor = Color.White;
			tb_ID.ForeColor = Color.White;
			lbl_ID.ForeColor = Color.White;
		}
		void tb_PassWord_GotFocus(object sender, System.EventArgs e)
		{
			tb_PassWordMethod(sender);
		}
		void tb_PassWordMethod(object sender)
		{
			tb_PassWord.Clear();
			tb_PassWord.PasswordChar = '*';
			panel2.BackColor = Color.FromArgb(78, 184, 206);
			tb_PassWord.ForeColor = Color.FromArgb(78, 184, 206);
			lbl_PW.ForeColor = Color.FromArgb(78, 184, 206);

			panel1.BackColor = Color.White;
			tb_ID.ForeColor = Color.White;
			lbl_ID.ForeColor = Color.White;
		}
		void tb_ID_GotFocus(object sender, System.EventArgs e)
		{
			tb_IDMethod(sender);
		}
		void tb_IDMethod(object sender)
		{
			tb_ID.Clear();
			panel1.BackColor = Color.FromArgb(78, 184, 206);
			tb_ID.ForeColor = Color.FromArgb(78, 184, 206);
			lbl_ID.ForeColor = Color.FromArgb(78, 184, 206);

			panel2.BackColor = Color.White;
			tb_PassWord.ForeColor = Color.White;
			lbl_PW.ForeColor = Color.White;
		}
		private void tb_ID_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				this.btn_Login_Click_1(sender, e);
		}
		private void tb_PassWord_KeyDown(object sender, KeyEventArgs e)
		{
			if (e.KeyCode == Keys.Enter)
				this.btn_Login_Click_1(sender, e);
		}
		public void CloseForm()
		{
			this.Close();
		}
		private void LoginForm_MouseDown(object sender, MouseEventArgs e)
		{
			mousePoint = new Point(e.X, e.Y);
		}
		private void LoginForm_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int x = mousePoint.X - e.X;
				int y = mousePoint.Y - e.Y;
				Location = new Point(this.Left - x, this.Top - y);
			}
		}
        private void lbl_View_MouseMove(object sender, MouseEventArgs e)
        {
			tb_PassWord.PasswordChar = default(char);
		}
        private void lbl_View_MouseLeave(object sender, EventArgs e)
        {
			tb_PassWord.PasswordChar = '*';
		}
	}
}