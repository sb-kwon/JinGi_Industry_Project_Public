using Controller;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
	public partial class WorkProcessDetailView : Form
	{
        private Point mousePoint;
        public WorkProcessDetailView(int wpNo, ProcessC p)
		{
			InitializeComponent();
			string[] str = p.GetProcessDetail(wpNo);

			l00.Text = str[0];
			l01.Text = str[1];
			l02.Text = str[2].Substring(0, 10);
			l03.Text = str[3].Substring(0, 10);
			l04.Text = str[4];
			l05.Text = str[5];
			l06.Text = str[6];
			l07.Text = str[7];
			l08.Text = str[8];
			l09.Text = str[9];
			l10.Text = str[10];
			l11.Text = str[11];
			l12.Text = str[12];
			l13.Text = str[13];
			l14.Text = str[14];
			l15.Text = str[15];
			l16.Text = str[16];
			l17.Text = str[17];
			l18.Text = str[18];
			l19.Text = str[19];
			l20.Text = SetProcessState(str[20]);
			l21.Text = str[21].Substring(0, 10);
			l22.Text = str[22].Substring(0, 10);
			l23.Text = str[23];
			l24.Text = str[24];
			l25.Text = str[25];
			l26.Text = str[26];
			l.Text = str[0] + "_" + str[27] + "_" + str[28];

		}
		private String SetProcessState(string state)
		{
			string str = "";

			if (state == "0") str = "작업 전";
			if (state == "1") str = "작업 중";
			if (state == "2") str = "폐기";
			if (state == "3") str = "일시중지";
			if (state == "4") str = "중지";
			if (state == "5") str = "작업완료";

			return str;
		}
		private void btn_all_Click(object sender, EventArgs e)
		{
			this.Close();
		}
        private void WorkProcessDetailView_MouseDown(object sender, MouseEventArgs e)
        {
			mousePoint = new Point(e.X, e.Y);
		}
		private void WorkProcessDetailView_MouseMove(object sender, MouseEventArgs e)
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