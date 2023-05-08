using Controller;
using Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;


namespace View
{
	public partial class Non_Operation_Analysis : Form, IBasicForm
	{
		private Member _LoginInfo;
		private BasicForm _Mother;
		private Color _RandomColor;
		private MachineC _MachineCtrl;
		private Random rnd = new Random();
		private List<Operating_Rate> _Non;
		public String MachineName, BetweenStart, BetweenEnd;
		public Non_Operation_Analysis(Member member, BasicForm form)
		{
			InitializeComponent();

			_LoginInfo = member;
			_Mother = form;
			_MachineCtrl = new MachineC();
			_RandomColor = Color.FromArgb(rnd.Next(256), rnd.Next(256), rnd.Next(256));

			SetChart();
		}
		public string GetText()
		{
			return this.Text;
		}
		public void RefreshForm()
		{
			SetChart();
		}
		public Form SetForm()
		{
			return this;
		}
		public void SetInterval(string seletedPageName, bool check)
		{
			;
		}
		public List<Operating_Rate> Non
		{
			get { return _Non; }
			set { _Non = value; }
		}
		private void GetBetweenCnt(string MachineName, string StartDate, string EndDate)
		{
			_MachineCtrl.GetBetweenCnt(MachineName, StartDate, EndDate);
			Non = _MachineCtrl.Non;
		}
		private void GetStattCnt(string MachineName)
		{
			_MachineCtrl.GetStattCnt(MachineName);
			Non = _MachineCtrl.Non;
		}
		private void NonOperOpen1(string StartDate, string EndDate)
		{
			string seriesname = "MySeriesName";
			MachineName = Machine1.Text = "TruLaser-3030";
			dgv_Non.Rows.Clear();
			if (StartDate == "")
			{
				GetStattCnt(MachineName);
				if (Non.Count != 0)
				{
					foreach (Operating_Rate Rate in Non)
					{
						dgv_Non.Rows.Add(Rate.MachineValue, Rate.Count, Rate.MachineName);
					}
					int a = 0;
					if (Non != null)
					{
						foreach (Operating_Rate count in Non)
						{
							foreach (DataGridViewRow dgvr in dgv_Non.Rows)
							{
								if (dgvr.Cells[0].Value.ToString().Equals(count.MachineValue))
								{
									a = Int32.Parse(dgvr.Cells[1].Value.ToString()) + (count.Count);
									dgvr.Cells[1].Value = a;
								}
								MachineName = dgvr.Cells[2].Value.ToString();
							}
						}
					}
				}
			}
			else
			{
				GetBetweenCnt(MachineName, StartDate, EndDate);

				if (Non.Count != 0)
				{
					foreach (Operating_Rate BetweenCnt in Non)
					{
						dgv_Non.Rows.Add(BetweenCnt.MachineValue, BetweenCnt.Count, BetweenCnt.MachineName);
					}
				}
			}
			chart1.Series.Clear();
			chart1.Legends.Clear();

			chart1.Legends.Add("MyLegend");
			chart1.Legends[0].LegendStyle = LegendStyle.Table;
			chart1.Legends[0].Docking = Docking.Bottom;
			chart1.Legends[0].Alignment = StringAlignment.Center;
			chart1.Legends[0].Title = MachineName;
			chart1.Legends[0].BorderColor = Color.Black;

			chart1.Series.Add(seriesname);
			chart1.Series[seriesname].ChartType = SeriesChartType.Doughnut;

			if (dgv_Non.Rows.Count != 0)
			{
				int cnt = 0;
				foreach (DataGridViewRow dgvr in dgv_Non.Rows)
				{
					chart1.Series[seriesname].Points.AddXY(dgvr.Cells[2].Value.ToString(), dgvr.Cells[1].Value);
					chart1.Series[seriesname].Points[cnt].Label = "#PERCENT{P0}" + Environment.NewLine;
					chart1.Series[seriesname].Points[cnt].LegendText = dgvr.Cells[0].Value.ToString();
					chart1.Series[seriesname].Points[cnt].Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold);

					string pointcolor = dgvr.Cells[0].Value.ToString();

					switch (pointcolor)
					{
						case "Unoperation":
							chart1.Series[seriesname].Points[cnt].Color = Color.DarkOrange;
							break;
						case "Error":
							chart1.Series[seriesname].Points[cnt].Color = Color.Red;
							break;
						default:
							chart1.Series[seriesname].Points[cnt].Color = _RandomColor;
							break;
					}
					cnt++;
				}
			}
			StartDate = string.Empty;
		}
		private void NonOperOpen2(string StartDate, string EndDate)
		{
			string seriesname = "MySeriesName";
			MachineName = Machine2.Text = "TruLaser3030-2";
			dgv_Non.Rows.Clear();
			if (StartDate == "")
			{
				GetStattCnt(MachineName);
				if (Non.Count != 0)
				{
					foreach (Operating_Rate Rate in Non)
					{
						dgv_Non.Rows.Add(Rate.MachineValue, Rate.Count, Rate.MachineName);
					}
					int a = 0;
					if (Non != null)
					{
						foreach (Operating_Rate count in Non)
						{
							foreach (DataGridViewRow dgvr in dgv_Non.Rows)
							{
								if (dgvr.Cells[0].Value.ToString().Equals(count.MachineValue))
								{
									a = Int32.Parse(dgvr.Cells[1].Value.ToString()) + (count.Count);
									dgvr.Cells[1].Value = a;
								}
								MachineName = dgvr.Cells[2].Value.ToString();
							}
						}
					}
				}
			}
			else
			{
				GetBetweenCnt(MachineName, StartDate, EndDate);

				if (Non.Count != 0)
				{
					foreach (Operating_Rate BetweenCnt in Non)
					{
						dgv_Non.Rows.Add(BetweenCnt.MachineValue, BetweenCnt.Count, BetweenCnt.MachineName);
					}
				}
			}
			chart2.Series.Clear();
			chart2.Legends.Clear();

			chart2.Legends.Add("MyLegend");
			chart2.Legends[0].LegendStyle = LegendStyle.Table;
			chart2.Legends[0].Docking = Docking.Bottom;
			chart2.Legends[0].Alignment = StringAlignment.Center;
			chart2.Legends[0].Title = MachineName;
			chart2.Legends[0].BorderColor = Color.Black;

			chart2.Series.Add(seriesname);
			chart2.Series[seriesname].ChartType = SeriesChartType.Doughnut;

			if (dgv_Non.Rows.Count != 0)
			{
				int cnt = 0;
				foreach (DataGridViewRow dgvr in dgv_Non.Rows)
				{
					chart2.Series[seriesname].Points.AddXY(dgvr.Cells[2].Value.ToString(), dgvr.Cells[1].Value);
					chart2.Series[seriesname].Points[cnt].Label = "#PERCENT{P0}" + Environment.NewLine;
					chart2.Series[seriesname].Points[cnt].LegendText = dgvr.Cells[0].Value.ToString();
					chart2.Series[seriesname].Points[cnt].Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold);

					string pointcolor = dgvr.Cells[0].Value.ToString();

					switch (pointcolor)
					{
						case "Unoperation":
							chart2.Series[seriesname].Points[cnt].Color = Color.DarkOrange;
							break;
						case "Error":
							chart2.Series[seriesname].Points[cnt].Color = Color.Red;
							break;
						default:
							chart2.Series[seriesname].Points[cnt].Color = _RandomColor;
							break;
					}
					cnt++;
				}
			}
			StartDate = string.Empty;
		}
		private void NonOperOpen3(string StartDate, string EndDate)
		{
			string seriesname = "MySeriesName";
			MachineName = Machine3.Text = "CNC-1500";
			dgv_Non.Rows.Clear();
			if (StartDate == "")
			{
				GetStattCnt(MachineName);
				if (Non.Count != 0)
				{
					foreach (Operating_Rate Rate in Non)
					{
						dgv_Non.Rows.Add(Rate.MachineValue, Rate.Count, Rate.MachineName);
					}
					int a = 0;
					if (Non != null)
					{
						foreach (Operating_Rate count in Non)
						{
							foreach (DataGridViewRow dgvr in dgv_Non.Rows)
							{
								if (dgvr.Cells[0].Value.ToString().Equals(count.MachineValue))
								{
									a = Int32.Parse(dgvr.Cells[1].Value.ToString()) + (count.Count);
									dgvr.Cells[1].Value = a;
								}
								MachineName = dgvr.Cells[2].Value.ToString();
							}
						}
					}
				}
			}
			else
			{
				GetBetweenCnt(MachineName, StartDate, EndDate);

				if (Non.Count != 0)
				{
					foreach (Operating_Rate BetweenCnt in Non)
					{
						dgv_Non.Rows.Add(BetweenCnt.MachineValue, BetweenCnt.Count, BetweenCnt.MachineName);
					}
				}
			}
			chart3.Series.Clear();
			chart3.Legends.Clear();

			chart3.Legends.Add("MyLegend");
			chart3.Legends[0].LegendStyle = LegendStyle.Table;
			chart3.Legends[0].Docking = Docking.Bottom;
			chart3.Legends[0].Alignment = StringAlignment.Center;
			chart3.Legends[0].Title = MachineName;
			chart3.Legends[0].BorderColor = Color.Black;

			chart3.Series.Add(seriesname);
			chart3.Series[seriesname].ChartType = SeriesChartType.Doughnut;

			if (dgv_Non.Rows.Count != 0)
			{
				int cnt = 0;
				foreach (DataGridViewRow dgvr in dgv_Non.Rows)
				{
					chart3.Series[seriesname].Points.AddXY(dgvr.Cells[2].Value.ToString(), dgvr.Cells[1].Value);
					chart3.Series[seriesname].Points[cnt].Label = "#PERCENT{P0}" + Environment.NewLine;
					chart3.Series[seriesname].Points[cnt].LegendText = dgvr.Cells[0].Value.ToString();
					chart3.Series[seriesname].Points[cnt].Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold);

					string pointcolor = dgvr.Cells[0].Value.ToString();

					switch (pointcolor)
					{
						case "Unoperation":
							chart3.Series[seriesname].Points[cnt].Color = Color.DarkOrange;
							break;
						case "Error":
							chart3.Series[seriesname].Points[cnt].Color = Color.Red;
							break;
						default:
							chart3.Series[seriesname].Points[cnt].Color = _RandomColor;
							break;
					}
					cnt++;
				}
			}
			StartDate = string.Empty;
		}
		private void NonOperOpen4(string StartDate, string EndDate)
		{
			string seriesname = "MySeriesName";
			MachineName = Machine4.Text = "CNC-3000";
			dgv_Non.Rows.Clear();
			if (StartDate == "")
			{
				GetStattCnt(MachineName);
				if (Non.Count != 0)
				{
					foreach (Operating_Rate Rate in Non)
					{
						dgv_Non.Rows.Add(Rate.MachineValue, Rate.Count, Rate.MachineName);
					}
					int a = 0;
					if (Non != null)
					{
						foreach (Operating_Rate count in Non)
						{
							foreach (DataGridViewRow dgvr in dgv_Non.Rows)
							{
								if (dgvr.Cells[0].Value.ToString().Equals(count.MachineValue))
								{
									a = Int32.Parse(dgvr.Cells[1].Value.ToString()) + (count.Count);
									dgvr.Cells[1].Value = a;
								}
								MachineName = dgvr.Cells[2].Value.ToString();
							}
						}
					}
				}
			}
			else
			{
				GetBetweenCnt(MachineName, StartDate, EndDate);

				if (Non.Count != 0)
				{
					foreach (Operating_Rate BetweenCnt in Non)
					{
						dgv_Non.Rows.Add(BetweenCnt.MachineValue, BetweenCnt.Count, BetweenCnt.MachineName);
					}
				}
			}
			chart4.Series.Clear();
			chart4.Legends.Clear();

			chart4.Legends.Add("MyLegend");
			chart4.Legends[0].LegendStyle = LegendStyle.Table;
			chart4.Legends[0].Docking = Docking.Bottom;
			chart4.Legends[0].Alignment = StringAlignment.Center;
			chart4.Legends[0].Title = MachineName;
			chart4.Legends[0].BorderColor = Color.Black;

			chart4.Series.Add(seriesname);
			chart4.Series[seriesname].ChartType = SeriesChartType.Doughnut;

			if (dgv_Non.Rows.Count != 0)
			{
				int cnt = 0;
				foreach (DataGridViewRow dgvr in dgv_Non.Rows)
				{
					chart4.Series[seriesname].Points.AddXY(dgvr.Cells[2].Value.ToString(), dgvr.Cells[1].Value);
					chart4.Series[seriesname].Points[cnt].Label = "#PERCENT{P0}" + Environment.NewLine;
					chart4.Series[seriesname].Points[cnt].LegendText = dgvr.Cells[0].Value.ToString();
					chart4.Series[seriesname].Points[cnt].Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold);

					string pointcolor = dgvr.Cells[0].Value.ToString();

					switch (pointcolor)
					{
						case "Unoperation":
							chart4.Series[seriesname].Points[cnt].Color = Color.DarkOrange;
							break;
						case "Error":
							chart4.Series[seriesname].Points[cnt].Color = Color.Red;
							break;
						default:
							chart4.Series[seriesname].Points[cnt].Color = _RandomColor;
							break;
					}
					cnt++;
				}
			}
			StartDate = string.Empty;
		}
		private void NonOperOpen5(string StartDate, string EndDate)
		{
			string seriesname = "MySeriesName";
			MachineName = Machine5.Text = "CNC-5170";
			dgv_Non.Rows.Clear();
			if (StartDate == "")
			{
				List<Operating_Rate> list = _MachineCtrl.GetStattCnt(MachineName);

				if (list.Count != 0)
				{
					foreach (Operating_Rate Rate in list)
					{
						dgv_Non.Rows.Add(Rate.MachineValue, Rate.Count, Rate.MachineName);
					}
					int a = 0;
					if (list != null)
					{
						foreach (Operating_Rate count in list)
						{
							foreach (DataGridViewRow dgvr in dgv_Non.Rows)
							{
								if (dgvr.Cells[0].Value.ToString().Equals(count.MachineValue))
								{
									a = Int32.Parse(dgvr.Cells[1].Value.ToString()) + (count.Count);
									dgvr.Cells[1].Value = a;
								}
								MachineName = dgvr.Cells[2].Value.ToString();
							}
						}
					}
				}
			}
			else
			{
				GetBetweenCnt(MachineName, StartDate, EndDate);

				if (Non.Count != 0)
				{
					foreach (Operating_Rate BetweenCnt in Non)
					{
						dgv_Non.Rows.Add(BetweenCnt.MachineValue, BetweenCnt.Count, BetweenCnt.MachineName);
					}
				}
			}
			chart5.Series.Clear();
			chart5.Legends.Clear();

			chart5.Legends.Add("MyLegend");
			chart5.Legends[0].LegendStyle = LegendStyle.Table;
			chart5.Legends[0].Docking = Docking.Bottom;
			chart5.Legends[0].Alignment = StringAlignment.Center;
			chart5.Legends[0].Title = MachineName;
			chart5.Legends[0].BorderColor = Color.Black;

			chart5.Series.Add(seriesname);
			chart5.Series[seriesname].ChartType = SeriesChartType.Doughnut;

			if (dgv_Non.Rows.Count != 0)
			{
				int cnt = 0;
				foreach (DataGridViewRow dgvr in dgv_Non.Rows)
				{
					chart5.Series[seriesname].Points.AddXY(dgvr.Cells[2].Value.ToString(), dgvr.Cells[1].Value);
					chart5.Series[seriesname].Points[cnt].Label = "#PERCENT{P0}" + Environment.NewLine;
					chart5.Series[seriesname].Points[cnt].LegendText = dgvr.Cells[0].Value.ToString();
					chart5.Series[seriesname].Points[cnt].Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold);

					string pointcolor = dgvr.Cells[0].Value.ToString();

					switch (pointcolor)
					{
						case "Unoperation":
							chart5.Series[seriesname].Points[cnt].Color = Color.DarkOrange;
							break;
						case "Error":
							chart5.Series[seriesname].Points[cnt].Color = Color.Red;
							break;
						default:
							chart5.Series[seriesname].Points[cnt].Color = _RandomColor;
							break;
					}
					cnt++;
				}
			}
			StartDate = string.Empty;
		}
		private void NonOperOpen6(string StartDate, string EndDate)
		{
			string seriesname = "MySeriesName";
			MachineName = Machine6.Text = "MCT-21";
			dgv_Non.Rows.Clear();
			if (StartDate == "")
			{
				List<Operating_Rate> list = _MachineCtrl.GetStattCnt(MachineName);

				if (list.Count != 0)
				{
					foreach (Operating_Rate Rate in list)
					{
						dgv_Non.Rows.Add(Rate.MachineValue, Rate.Count, Rate.MachineName);
					}
					int a = 0;
					if (list != null)
					{
						foreach (Operating_Rate count in list)
						{
							foreach (DataGridViewRow dgvr in dgv_Non.Rows)
							{
								if (dgvr.Cells[0].Value.ToString().Equals(count.MachineValue))
								{
									a = Int32.Parse(dgvr.Cells[1].Value.ToString()) + (count.Count);
									dgvr.Cells[1].Value = a;
								}
								MachineName = dgvr.Cells[2].Value.ToString();
							}
						}
					}
				}
			}
			else
			{
				GetBetweenCnt(MachineName, StartDate, EndDate);

				if (Non.Count != 0)
				{
					foreach (Operating_Rate BetweenCnt in Non)
					{
						dgv_Non.Rows.Add(BetweenCnt.MachineValue, BetweenCnt.Count, BetweenCnt.MachineName);
					}
				}
			}
			chart6.Series.Clear();
			chart6.Legends.Clear();

			chart6.Legends.Add("MyLegend");
			chart6.Legends[0].LegendStyle = LegendStyle.Table;
			chart6.Legends[0].Docking = Docking.Bottom;
			chart6.Legends[0].Alignment = StringAlignment.Center;
			chart6.Legends[0].Title = MachineName;
			chart6.Legends[0].BorderColor = Color.Black;

			chart6.Series.Add(seriesname);
			chart6.Series[seriesname].ChartType = SeriesChartType.Doughnut;

			if (dgv_Non.Rows.Count != 0)
			{
				int cnt = 0;
				foreach (DataGridViewRow dgvr in dgv_Non.Rows)
				{
					chart6.Series[seriesname].Points.AddXY(dgvr.Cells[2].Value.ToString(), dgvr.Cells[1].Value);
					chart6.Series[seriesname].Points[cnt].Label = "#PERCENT{P0}" + Environment.NewLine;
					chart6.Series[seriesname].Points[cnt].LegendText = dgvr.Cells[0].Value.ToString();
					chart6.Series[seriesname].Points[cnt].Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold);

					string pointcolor = dgvr.Cells[0].Value.ToString();

					switch (pointcolor)
					{
						case "Unoperation":
							chart6.Series[seriesname].Points[cnt].Color = Color.DarkOrange;
							break;
						case "Error":
							chart6.Series[seriesname].Points[cnt].Color = Color.Red;
							break;
						default:
							chart6.Series[seriesname].Points[cnt].Color = _RandomColor;
							break;
					}
					cnt++;
				}
			}
			StartDate = string.Empty;
		}
		private void NonOperOpen7(string StartDate, string EndDate)
		{
			string seriesname = "MySeriesName";
			MachineName = Machine7.Text = "오면가공기";
			dgv_Non.Rows.Clear();
			if (StartDate == "")
			{
				List<Operating_Rate> list = _MachineCtrl.GetStattCnt(MachineName);

				if (list.Count != 0)
				{
					foreach (Operating_Rate Rate in list)
					{
						dgv_Non.Rows.Add(Rate.MachineValue, Rate.Count, Rate.MachineName);
					}
					int a = 0;
					if (list != null)
					{
						foreach (Operating_Rate count in list)
						{
							foreach (DataGridViewRow dgvr in dgv_Non.Rows)
							{
								if (dgvr.Cells[0].Value.ToString().Equals(count.MachineValue))
								{
									a = Int32.Parse(dgvr.Cells[1].Value.ToString()) + (count.Count);
									dgvr.Cells[1].Value = a;
								}
								MachineName = dgvr.Cells[2].Value.ToString();
							}
						}
					}
				}
			}
			else
			{
				GetBetweenCnt(MachineName, StartDate, EndDate);

				if (Non.Count != 0)
				{
					foreach (Operating_Rate BetweenCnt in Non)
					{
						dgv_Non.Rows.Add(BetweenCnt.MachineValue, BetweenCnt.Count, BetweenCnt.MachineName);
					}
				}
			}
			chart7.Series.Clear();
			chart7.Legends.Clear();

			chart7.Legends.Add("MyLegend");
			chart7.Legends[0].LegendStyle = LegendStyle.Table;
			chart7.Legends[0].Docking = Docking.Bottom;
			chart7.Legends[0].Alignment = StringAlignment.Center;
			chart7.Legends[0].Title = MachineName;
			chart7.Legends[0].BorderColor = Color.Black;

			chart7.Series.Add(seriesname);
			chart7.Series[seriesname].ChartType = SeriesChartType.Doughnut;

			if (dgv_Non.Rows.Count != 0)
			{
				int cnt = 0;
				foreach (DataGridViewRow dgvr in dgv_Non.Rows)
				{
					chart7.Series[seriesname].Points.AddXY(dgvr.Cells[2].Value.ToString(), dgvr.Cells[1].Value);
					chart7.Series[seriesname].Points[cnt].Label = "#PERCENT{P0}" + Environment.NewLine;
					chart7.Series[seriesname].Points[cnt].LegendText = dgvr.Cells[0].Value.ToString();
					chart7.Series[seriesname].Points[cnt].Font = new Font("맑은 고딕", 11.25F, FontStyle.Bold);

					string pointcolor = dgvr.Cells[0].Value.ToString();

					switch (pointcolor)
					{
						case "Unoperation":
							chart7.Series[seriesname].Points[cnt].Color = Color.DarkOrange;
							break;
						case "Error":
							chart7.Series[seriesname].Points[cnt].Color = Color.Red;
							break;
						default:
							chart7.Series[seriesname].Points[cnt].Color = _RandomColor;
							break;
					}
					cnt++;
				}
			}
			StartDate = string.Empty;
		}
		private void btn_Inquiry_Click(object sender, EventArgs e)
		{
			DateTime Start = DateTime.Parse(dtp_Start.Text);
			DateTime End = DateTime.Parse(dtp_End.Text);
			int TimeResult = DateTime.Compare(Start, End);

			if (TimeResult > 0)
			{
				Alarm("종료 날짜가 시작 날짜보다 이전일 수 없습니다.");
			}
			else
			{
				BetweenStart = dtp_Start.Value.ToString().Substring(0, 10);
				BetweenEnd = dtp_End.Value.ToString().Substring(0, 10);
				NonOperOpen1(BetweenStart, BetweenEnd);
				NonOperOpen2(BetweenStart, BetweenEnd);
				NonOperOpen3(BetweenStart, BetweenEnd);
				NonOperOpen4(BetweenStart, BetweenEnd);
				NonOperOpen5(BetweenStart, BetweenEnd);
				NonOperOpen6(BetweenStart, BetweenEnd);
				NonOperOpen7(BetweenStart, BetweenEnd);
			}
		}
		private void SetChart()
		{
			BetweenStart = string.Empty;
			BetweenEnd = string.Empty;
			NonOperOpen1(BetweenStart, BetweenEnd);
			NonOperOpen2(BetweenStart, BetweenEnd);
			NonOperOpen3(BetweenStart, BetweenEnd);
			NonOperOpen4(BetweenStart, BetweenEnd);
			NonOperOpen5(BetweenStart, BetweenEnd);
			NonOperOpen6(BetweenStart, BetweenEnd);
			NonOperOpen7(BetweenStart, BetweenEnd);
		}
		private void Alarm(String str)
		{
			Alarm Alarm = new Alarm(str);
			Alarm.ShowDialog();
		}
	}
}
