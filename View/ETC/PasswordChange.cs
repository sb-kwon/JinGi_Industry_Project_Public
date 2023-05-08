using System;
using System.Drawing;
using System.Windows.Forms;
using Controller;
using Model;
namespace View
{
	public partial class PasswordChange : Form
	{
		BaseC _BaseCtrl;
		ILoginForm _LoginForm;
		private string _UserID;
		private Point mousePoint;
		private LoginAlarm _LoginAlarm;
		public PasswordChange(String id, ILoginForm loginForm, LoginAlarm LoginView)
		{
			InitializeComponent();
			_UserID = id;
			_LoginForm = loginForm;
			_LoginAlarm = LoginView;
			_BaseCtrl = new BaseC(loginForm);
		}
		private void tb_PWuse_TextChanged(object sender, EventArgs e)
		{
			Member member = new Member();

			member.Memberid = _UserID;
			member.Memberpw = tb_PW.Text;

			_BaseCtrl.LastPwCheck(member);

			if (tb_PWuse.Text.Length < 8 && tb_PWuse.Text.Length < 9)
			{
				lbl_Alarm.Text = "비밀번호\n8자리 이상 입력해주세요.";
			}
			else if (tb_PWuse.Text.Length > 14 && tb_PWuse.Text.Length < 16)
			{
				lbl_Alarm.Text = "비밀번호\n14자리 이하로 입력해주세요.";
				tb_PWuse.Text = tb_PWuse.Text.Remove(tb_PWuse.Text.Length - 1);
				tb_PWuse.Select(tb_PWuse.Text.Length, 0);
			}
			else if (member.Memberpw != tb_PWuse.Text)
			{
				lbl_Alarm.Text = "현재 비밀번호와 일치하지 않습니다. \n 비밀번호를 변경해주세요.";
			}
			else if (member.Memberpw == tb_PWuse.Text)
			{
				lbl_Alarm.Text = "현재 비밀번호와 일치합니다.";
			}
			else if (tb_PWuse.Text.Length > 7 && tb_PWuse.Text.Length < 14)
			{
				lbl_Alarm.Text = "";
			}
		}
		private void tb_PW_TextChanged(object sender, EventArgs e)
		{
			Member member = new Member();

			member.Memberid = _UserID;
			member.Memberpw = tb_PW.Text;

			_BaseCtrl.LastPwCheck(member);

			if (member.Memberpw == tb_PW.Text)
			{
				lbl_Alarm.Text = "현재 비밀번호와 같습니다. \n 비밀번호를 변경해주세요.";
			}
			else lbl_Alarm.Text = "";
		}
		private void tb_PW2_TextChanged(object sender, EventArgs e)
		{
			if (tb_PW.Text != tb_PW2.Text)
			{
				lbl_Alarm.Text = "비밀번호가 일치하지 않습니다. \n 비밀번호를 다시 확인해주세요.";
			}
			else lbl_Alarm.Text = "";
		}
		private void btn_Change_Click(object sender, EventArgs e)
		{
			Member member = new Member();

			member.Memberid = _UserID;
			member.Memberpw = tb_PW.Text;

			_BaseCtrl.LastPwCheck(member);

			if (tb_PW.Text.Length < 8 && tb_PW.Text.Length < 9)
			{
				SetAlarm("비밀번호는 8자리 이상 입력해주세요.");
			}
			else if (member.Memberpw != tb_PWuse.Text)
			{
				SetAlarm("현재 비밀번호와 일치하지 않습니다. \n 다시 입력해주세요.");
			}
			else if (member.Memberpw == tb_PW.Text)
			{
				SetAlarm("사용중인 비밀번호와 같습니다. \n 변경해주세요.");
			}
			else if (tb_PW.Text != tb_PW2.Text)
			{
				SetAlarm("변경한 비밀번호와 맞지 않습니다. \n 비밀번호를 다시 확인해주세요.");
			}
			else
			{
				//마지막 비밀번호 저장 
				string lastpw = tb_PWuse.Text;
				_BaseCtrl.LastPwSave(member, lastpw);

				//비밀번호 변경
				member.Memberpw = tb_PW.Text;

				_BaseCtrl.UserPwChange(member);
				SetAlarm("비밀번호가 변경 되었습니다.");
				this.Dispose();
			}
			_LoginAlarm.Close();
		}
		private void SetAlarm(String str)
		{
			Alarm alarm = new Alarm(str);
			alarm.SetChange();
			alarm.StartPosition = FormStartPosition.Manual;
			alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
			alarm.ShowDialog();
		}
		private void PasswordChange_MouseDown(object sender, MouseEventArgs e)
		{
			mousePoint = new Point(e.X, e.Y);
		}
		private void PasswordChange_MouseMove(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				int x = mousePoint.X - e.X;
				int y = mousePoint.Y - e.Y;
				Location = new Point(this.Left - x, this.Top - y);
			}
		}
        private void btn_Exit_Click(object sender, EventArgs e)
        {
			this.Close();
        }
    }
}