using Controller;
using Model;
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
	public partial class SignUp : Form
	{
		private bool _IdCheck;  //아이디 유무 확인
		private Point mousePoint;
		BaseC _BaseCtrl;
		public SignUp(ILoginForm loginForm)
		{
			_BaseCtrl = new BaseC(loginForm);
			InitializeComponent();

			IDCHECK = false;
			SetRankList();
		}
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		//Getter And Setter
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		public bool IDCHECK
		{
			get { return _IdCheck; }
			set
			{
				_IdCheck = value;
				if (value)
				{
					tb_ID.ReadOnly = true;
					lbl_Alarm.Text = "";
				}
			}
		}
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		//Method Function
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		private void SetSignUp()
		{
			Member member = new Member();

			member.Memberid = tb_ID.Text;
			member.Memberpw = tb_PW.Text;
			member.Membername = tb_Name.Text;
			member.Membernumber = tb_number.Text;
			member.Rankname = cb_Rank.Text;
			member.MemberAccess.Authorityname = "User";
			member.MemberAccess.Memberlastpw = tb_PW.Text;
			member.MemberAccess.Memberlpct = DateTime.Now.ToString();

			_BaseCtrl.InsertMember(member);

		}
		private void SetAlarm(String str)
		{
			Alarm alarm = new Alarm(str);

			alarm.StartPosition = FormStartPosition.Manual;
			alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
			alarm.ShowDialog();
		}
		private void SetRankList()
		{
			List<String> list = _BaseCtrl.GetRankList();
			cb_Rank.Items.Clear();

			foreach (String str in list)
				cb_Rank.Items.Add(str);
		}
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		//UI Function
		//---------------------------------------------------------------------------------------------
		//---------------------------------------------------------------------------------------------
		#region 검색 Button Event
		private void tb_ID_TextChanged(object sender, EventArgs e)
		{
			if (!IDCHECK) lbl_Alarm.Text = "아이디\n아이디 확인이 필요합니다.";
		}
		private void tb_PW_TextChanged(object sender, EventArgs e)
		{
			if (tb_PW.Text.Length < 8)
			{
				lbl_Alarm.Text = "비밀번호\n8자리 이상 입력해주세요.";
			}
			else if (tb_PW.Text.Length > 14 && tb_PW.Text.Length < 16)
			{
				lbl_Alarm.Text = "비밀번호\n14자리 이하로 입력해주세요.";
				tb_PW.Text = tb_PW.Text.Remove(tb_PW.Text.Length - 1);
				tb_PW.Select(tb_PW.Text.Length, 0);
			}
			else lbl_Alarm.Text = "";
		}
		private void tb_PW2_TextChanged(object sender, EventArgs e)
		{
			if (!(tb_PW2.Text.Equals(tb_PW.Text))) lbl_Alarm.Text = "비밀번호 확인\n비밀번호가 일치 하지 않습니다.";
			else lbl_Alarm.Text = "";
		}
		private void btn_IdCheck_Click(object sender, EventArgs e)
		{
			if (tb_ID.Text.Length > 0)
			{
				IDCHECK = !(_BaseCtrl.IdCheck(tb_ID.Text));
				String str = "이미 존재하는 아이디 입니다.";
				if (IDCHECK)
					str = "사용가능한 아이디입니다.";
				SetAlarm(str);
			}
		}
		private void btn_SignUp_Click(object sender, EventArgs e)
		{
			if (!IDCHECK) SetAlarm("아이디 중복 확인이 필요합니다.");
			else if (tb_PW.Text.Length < 8) SetAlarm("비밀번호는 8자리 이상이어야 합니다.");
			else if (!System.Text.RegularExpressions.Regex.IsMatch(tb_PW.Text, (@"(?=.*[a-zA-Z])(?=.*[0-9])(?=.*[^\w\s]).*")))
				SetAlarm("영문과 특수문자, 숫자를 포함해야 합니다.");
			else if ((!tb_PW.Text.Equals(tb_PW2.Text))) SetAlarm("비밀번호가 일치하지 않습니다.");
			else if (cb_Rank.Text.Equals("")) SetAlarm("직급을 선택해야합니다.");
			else
			{
				SetSignUp();
				SetAlarm("회원이 등록 되었습니다.");
				this.Close();
			}
		}
		private void tb_number_KeyPress(object sender, KeyPressEventArgs e)
		{
			{
				if (Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToInt32(Keys.Back))
				{ }
				else { e.Handled = true; }
			}
		}
		private void tb_number_KeyUp(object sender, KeyEventArgs e)
		{
			tb_number.Text = autoHyphen(tb_number.Text);
			tb_number.SelectionStart = tb_number.Text.Length;
		}
		#endregion
		public string autoHyphen(string tel)
		{
			string tmpTel = tel.Replace("-", "");
			string tel1 = string.Empty; string tel2 = string.Empty;
			string tel3 = string.Empty; string tel_total = string.Empty;
			if (tmpTel.Length >= 2 && tmpTel.Length < 8)
			{
				if (tmpTel.Substring(0, 2) != "02")
				{
					if (tmpTel.Length == 3)
					{
						tel_total = tmpTel + "-";
					}
					else if (tmpTel.Length > 3 && tmpTel.Length < 6)
					{
						tel1 = tmpTel.Substring(0, 3);
						tel2 = tmpTel.Substring(3, tmpTel.Length - 3);
						tel_total = tel1 + "-" + tel2;
					}
					else if (tmpTel.Length > 3 && tmpTel.Length > 6)
					{
						tel1 = tmpTel.Substring(0, 3);
						tel2 = tmpTel.Substring(3, 3);
						tel3 = tmpTel.Substring(6, tmpTel.Length - 6);
						tel_total = tel1 + "-" + tel2 + "-" + tel3;
					}
					else
					{
						tel_total = tel;
					}
				}
				else
				{
					if (tmpTel.Length == 2)
					{
						tel_total = tmpTel + "-";
					}
					else if (tmpTel.Length > 2 && tmpTel.Length < 6)
					{
						tel1 = tmpTel.Substring(0, 2);
						tel2 = tmpTel.Substring(2, tmpTel.Length - 2);
						tel_total = tel1 + "-" + tel2;
					}
					else if (tmpTel.Length > 2 && tmpTel.Length > 5)
					{
						tel1 = tmpTel.Substring(0, 2);
						tel2 = tmpTel.Substring(2, 3);
						tel3 = tmpTel.Substring(5, tmpTel.Length - 5);
						tel_total = tel1 + "-" + tel2 + "-" + tel3;
					}
				}
			}
			else if (tmpTel.Length == 8 && tmpTel.Substring(0, 2) == "02")
			{
				tel1 = tmpTel.Substring(0, 2);
				tel2 = tmpTel.Substring(2, 3);
				tel3 = tmpTel.Substring(3, 3);
				tel_total = tel1 + "-" + tel2 + "-" + tel3;
			}
			else if (tmpTel.Length == 8 && tmpTel.Substring(0, 2) != "02")
			{
				tel1 = tmpTel.Substring(0, 4);
				tel2 = tmpTel.Substring(4, 4);
				tel_total = tel1 + "-" + tel2;
			}
			else if (tmpTel.Length == 9 && tmpTel.Substring(0, 2) == "02")
			{
				tel1 = tmpTel.Substring(0, 2);
				tel2 = tmpTel.Substring(2, 3);
				tel3 = tmpTel.Substring(5, 4);
				tel_total = tel1 + "-" + tel2 + "-" + tel3;
			}
			else if (tmpTel.Length == 9 && tmpTel.Substring(0, 2) != "02")
			{
				tel1 = tmpTel.Substring(0, 3);
				tel2 = tmpTel.Substring(3, 4);
				tel3 = tmpTel.Substring(7, 2);
				tel_total = tel1 + "-" + tel2 + "-" + tel3;
			}
			else if (tmpTel.Length == 10 && tmpTel.Substring(0, 2) == "02")
			{
				tel1 = tmpTel.Substring(0, 2);
				tel2 = tmpTel.Substring(2, 4);
				tel3 = tmpTel.Substring(6, 4);
				tel_total = tel1 + "-" + tel2 + "-" + tel3;
			}
			else if (tmpTel.Length == 10 && tmpTel.Substring(0, 2) != "02")
			{
				tel1 = tmpTel.Substring(0, 3);
				tel2 = tmpTel.Substring(3, 3);
				tel3 = tmpTel.Substring(6, 4);
				tel_total = tel1 + "-" + tel2 + "-" + tel3;
			}
			else if (tmpTel.Length == 11)
			{
				tel1 = tmpTel.Substring(0, 3);
				tel2 = tmpTel.Substring(3, 4);
				tel3 = tmpTel.Substring(7, 4);
				tel_total = tel1 + "-" + tel2 + "-" + tel3;
			}
			else
			{
				tel_total = tmpTel;
			}
			return tel_total;
		}
		private void SignUp_MouseDown(object sender, MouseEventArgs e)
		{
			mousePoint = new Point(e.X, e.Y);
		}
		private void SignUp_MouseMove(object sender, MouseEventArgs e)
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
        private void lbl_View_MouseMove(object sender, MouseEventArgs e)
        {
			tb_PW.PasswordChar = default(char);
			tb_PW2.PasswordChar = default(char);
		}
        private void lbl_View_MouseLeave(object sender, EventArgs e)
        {
			tb_PW.PasswordChar = '*';
			tb_PW2.PasswordChar = '*';
		}
	}
}
