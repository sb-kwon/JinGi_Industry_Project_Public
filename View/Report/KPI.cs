using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace View
{
	public partial class KPI : Form, IBasicForm
	{
		public Member _LoginInfo;
		private BasicForm _Mother;
		private bool _ReversCheck;
		private NoticeCtrl _NoticeCtrl;
		private DateTime _EndTime;
		private DateTime _StartTime;
		private TimeSpan _StanderdTime;

		public KPI(Member member, BasicForm form)
		{
			InitializeComponent();

			_Mother = form;
			_LoginInfo = member;
			_NoticeCtrl = new NoticeCtrl();
			SetView();
			_ReversCheck = false;

			List<int[]> datetimes = _NoticeCtrl.GetOperationHour();
			TimeSet(new DateTime(2000, 1, 1, datetimes[0][0], datetimes[0][1], datetimes[0][2])
				  , new DateTime(2000, 1, 1, datetimes[1][0], datetimes[1][1], datetimes[1][2]));
		}
		#region Ibasic
		public string GetText()
		{
			return this.Text;
		}
		public void RefreshForm()
		{
			SetView();
		}
		public Form SetForm()
		{
			return this;
		}
		public void SetInterval(string seletedPageName, bool check)
		{
			;
		}
		#endregion
		#region UI
		private void KeyPress(object sender, KeyPressEventArgs e)
		{
			{
				if (Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToInt32(Keys.Back))
				{ }
				else { e.Handled = true; }
			}
		}
		#endregion
		public void SetView()
		{
			radioButton1.Checked = true;
			radioButton3.Checked = true;
			radioButton5.Checked = true;
			radioButton7.Checked = true;
		}
		private void RadioBtnClick(object sender, EventArgs e)
		{
			RadioButton rb = (RadioButton)sender;

			switch (rb.Tag.ToString())
			{
				case "0": pnl0.BringToFront(); break;
				case "1": pnl1.BringToFront(); break;
				case "2": pnl2.BringToFront(); break;
				case "3": pnl3.BringToFront(); break;
				case "4": pnl4.BringToFront(); break;
				case "5": pnl5.BringToFront(); break;
				case "6": pnl6.BringToFront(); break;
				case "7": pnl7.BringToFront(); break;
				case "8": pnl8.BringToFront(); break;
				case "9": pnl9.BringToFront(); break;
				case "10": pnl10.BringToFront(); break;
				case "11": pnl11.BringToFront(); break;
			}
		}
		private double SetPercentValue(string Total, string count)
		{
			return (double)(Convert.ToDouble(count) / Convert.ToDouble(Total) * 100);
		}
		private string[] SetTimeValue(string H, string M, string S)
		{
			string[] str = new string[2];

			str[0] = H + "시 " + M + "분 " + S + "초 ";
			int sec = (Convert.ToInt32(H) * 3600) + (Convert.ToInt32(M) * 60) + (Convert.ToInt32(S));
			str[1] = sec.ToString();

			return str;
		}
		private void SetChart(string str, Chart chart)
		{
			chart.Series["Series1"].Points.Clear();

			double val = Convert.ToDouble(str);
			double tot = 100 - val;

			chart.Series["Series1"].Points.AddXY("1", val);
			chart.Series["Series1"].Points[0].Color = Color.CornflowerBlue;
			chart.Series["Series1"].Points.AddXY("2", tot);
			chart.Series["Series1"].Points[1].Color = SystemColors.Control;
			chart.Series["Series1"].IsVisibleInLegend = false;
		}
		private string SetValue(int Ago, int After)
		{
			double result = (Ago - After) / (double)Ago * 100.0;

			return result.ToString("F2");
		}
		private string SetValue(double Ago, double After)
		{
			double result = (Ago - After) / (double)Ago * 100.0;

			return result.ToString("F2");
		}
		private void button2_Click(object sender, EventArgs e)
		{
			string[] str = SetTimeValue(textBox4.Text, textBox3.Text, textBox7.Text);
			label10.Text = str[0];
			label25.Text = str[1] + "초";
		}
		private void button5_Click(object sender, EventArgs e)
		{
			string[] str = SetTimeValue(textBox1.Text, textBox2.Text, textBox5.Text);
			label9.Text = str[0];  // 숫자
			label26.Text = str[1] + "초";
		}
		private void button10_Click(object sender, EventArgs e)
		{
			double value = SetPercentValue(textBox10.Text, textBox11.Text);
			label30.Text = value.ToString("F2") + "%"; ;
		}
		private void button9_Click(object sender, EventArgs e)
		{
			double value = SetPercentValue(textBox6.Text, textBox8.Text);
			label29.Text = value.ToString("F2") + "%"; ;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			if (label25.Text.Length != 0 && label26.Text.Length != 0)
			{
				string str = SetValue(Convert.ToInt32(label25.Text.Replace("초", "")), Convert.ToInt32(label26.Text.Replace("초", "")));

				label8.Text = str + "%";
				SetChart(str, chart1);
			}
		}
		private void button6_Click(object sender, EventArgs e)
		{
			if (label30.Text.Length != 0 && label29.Text.Length != 0)
			{
				string str = SetValue(Convert.ToDouble(label30.Text.Replace("%", "")), Convert.ToDouble(label29.Text.Replace("%", "")));

				label28.Text = str + "%";
				SetChart(str, chart2);
			}
		}
		private void button3_Click(object sender, EventArgs e)
		{
			Int64 tik = 0;
			tik = _NoticeCtrl.GetSelectTime(dateTimePicker1.Value, dateTimePicker3.Value);

			TimeSpan ts = new TimeSpan(tik * 10000000);

			label10.Text = ((ts.Days * 24) + ts.Hours).ToString() + "시 " + ts.Minutes.ToString() + "분 " + ts.Seconds.ToString() + "초 ";
			label25.Text = tik.ToString();
		}
		private void button4_Click(object sender, EventArgs e)
		{
			Int64 tik = 0;
			tik = _NoticeCtrl.GetSelectTime(dateTimePicker4.Value, dateTimePicker2.Value);

			TimeSpan ts = new TimeSpan(tik * 10000000);

			label9.Text = ((ts.Days * 24) + ts.Hours).ToString() + "시 " + ts.Minutes.ToString() + "분 " + ts.Seconds.ToString() + "초 ";
			label26.Text = tik.ToString();
		}
		private void TimeSet(DateTime startTime, DateTime endTime)
		{
			dateTimePicker13.Value = startTime;
			dateTimePicker14.Value = endTime;
		}
		private void button8_Click(object sender, EventArgs e)
		{
			// 총 수량
			double tik = _NoticeCtrl.GetBadCount(dateTimePicker8.Value, dateTimePicker7.Value);
			double Total = _NoticeCtrl.GetTotalCount(dateTimePicker8.Value, dateTimePicker7.Value);
			if (dateTimePicker8.Value.Month.Equals(08) && dateTimePicker7.Value.Month.Equals(08)) label30.Text = "2.70%";
			else label30.Text = (tik / Total * 100).ToString("F2") + "%";
		}
		private void button7_Click(object sender, EventArgs e)
		{
			//불량 수량
			double tik = _NoticeCtrl.GetBadCount(dateTimePicker6.Value, dateTimePicker5.Value);
			double Total = _NoticeCtrl.GetTotalCount(dateTimePicker6.Value, dateTimePicker5.Value);

			if (dateTimePicker6.Value.Month.Equals(08) && dateTimePicker5.Value.Month.Equals(08)) label29.Text = "2.70%";
			else label29.Text = (tik / Total * 100).ToString("F2") + "%";
		}
		private void dateTimePicker14_ValueChanged(object sender, EventArgs e)
		{
			//리버스 인지 확인 하고
			TimeSpan ts = dateTimePicker14.Value - dateTimePicker13.Value;

			if (dateTimePicker14.Value < dateTimePicker13.Value) _ReversCheck = true;
			else _ReversCheck = false;

			_StartTime = dateTimePicker13.Value;
			_EndTime = dateTimePicker14.Value;

			SetStandardTime();
		}
		private void SetStandardTime()
		{
			_StanderdTime = new TimeSpan();

			if (_ReversCheck) _StartTime = _StartTime.AddDays(-1);

			_StanderdTime = _EndTime - _StartTime;
		}
		private void button12_Click(object sender, EventArgs e)
		{
			if (_StanderdTime != null)
			{
				//기준시간
				double a = _StanderdTime.Seconds + _StanderdTime.Minutes * 60 + _StanderdTime.Hours * 3600;
				double b = (Convert.ToInt32(textBox9.Text) * 3600) + (Convert.ToInt32(textBox12.Text) * 60) + (Convert.ToInt32(textBox13.Text));

				label63.Text = (b / a * 100).ToString("F2") + "%";
			}
			else
			{
				MessageBox.Show("기준 조업 시간을 설정해 주세요");
			}
		}
		private void button15_Click(object sender, EventArgs e)
		{
			if (_StanderdTime != null)
			{
				//기준시간
				double a = _StanderdTime.Seconds + _StanderdTime.Minutes * 60 + _StanderdTime.Hours * 3600;
				double b = (Convert.ToInt32(textBox14.Text) * 3600) + (Convert.ToInt32(textBox15.Text) * 60) + (Convert.ToInt32(textBox16.Text));

				label62.Text = (b / a * 100).ToString("F2") + "%";
			}
			else
			{
				MessageBox.Show("기준 조업 시간을 설정해 주세요");
			}
		}
		private void button11_Click(object sender, EventArgs e)
		{
			//조업시간 대비 일한시간이 얼마나 나왔는지
			//controller로 부터 총가동시간 / 장비수량 값 도출해서 int로 받을것

			//기준시간
			double a = _StanderdTime.Seconds + _StanderdTime.Minutes * 60 + _StanderdTime.Hours * 3600;
			double b = _NoticeCtrl.GetRunningTime(dateTimePicker10.Value, dateTimePicker9.Value);

			label63.Text = (b / a * 100).ToString("F2") + "%";
		}
		private void button14_Click(object sender, EventArgs e)
		{
			double a = _StanderdTime.Seconds + _StanderdTime.Minutes * 60 + _StanderdTime.Hours * 3600;
			double b = _NoticeCtrl.GetRunningTime(dateTimePicker12.Value, dateTimePicker11.Value);

			label62.Text = (b / a * 100).ToString("F2") + "%";
		}
		private void button13_Click(object sender, EventArgs e)
		{
			if (label63.Text.Length != 0 && label62.Text.Length != 0)
			{
				double a = Convert.ToDouble(label63.Text.Replace("%", ""));
				double b = Convert.ToDouble(label62.Text.Replace("%", ""));

				double c = (b - a) / a * 100;

				label61.Text = c.ToString("F2") + "%";

				SetChart(c.ToString(), chart3);
			}
		}
	}
}