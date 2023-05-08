using Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using WeekPlanner;

namespace View
{
	public partial class Kiosk_Order : Form, IBasicForm
	{
		private ProcessC _ProcessC;
		private int _DayCnt;
		private int[] _DayArray;
		private int _DayArrayCnt;

		public Kiosk_Order()
		{
			_ProcessC = new ProcessC();
			_DayCnt = 0;
			_DayArray = new int[] { 1, 5, 10, 30 };
			_DayArrayCnt = 0;

			InitializeComponent();
			button5_Click(null, null);

			calendarPlanner1.DayCount = 20;
			calendarPlanner1.Columns.Add("수주명", "수주명", 100);
			calendarPlanner1.Columns.Add("상태", "상태", 50);
			calendarPlanner1.CurrentDate = DateTime.Now;

			WeekplannerOpen();
		}
		private void FormStart()
		{
			calendarPlanner1.CurrentDate = DateTime.Now;
		}
		private void SetDayArray()
		{
			_DayArrayCnt++;

			if (_DayArrayCnt >= 4)
			{
				_DayArrayCnt = 0;
			}
		}
		private string ReturnValueState(string str)
		{
			if (str.Equals("0")) return "대기";
			if (str.Equals("1")) return "등록";
			if (str.Equals("2")) return "진행중";
			if (str.Equals("3")) return "출하 대기";
			if (str.Equals("4")) return "출하 진행중";
			if (str.Equals("5")) return "완료";
			if (str.Equals("6")) return "폐기";

			return "";
		}
		private void datagridview1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				datagridview1.Rows[e.RowIndex].Cells[0].Value = !(bool)datagridview1.Rows[e.RowIndex].Cells[0].Value;
			}
		}
		private void btn_all_Click(object sender, EventArgs e)
		{
			WeekplannerOpen();
			FormStart();
		}
		private void button1_Click(object sender, EventArgs e)
		{
			foreach (DataGridViewRow dgvr in datagridview1.Rows)
				if (!(bool)dgvr.Cells[0].Value) dgvr.Visible = false;

			SetWeekPlanner();
			FormStart();
		}
		private void SetWeekPlanner()
		{
			calendarPlanner1.Rows.Clear();
			foreach (DataGridViewRow dgbr in datagridview1.Rows)
			{
				if ((bool)dgbr.Cells[0].Value)
				{
					var itemCollection = new WeekPlannerItemCollection();
					var ColumnRows = new DataColumns(calendarPlanner1.Calendar);

					ColumnRows["수주명"].Data.Add(dgbr.Cells[1].Value.ToString());
					ColumnRows["상태"].Data.Add(dgbr.Cells[2].Value.ToString());

					var item = new WeekPlannerItem();
					item.StartDate = DateTime.Parse(dgbr.Cells[3].Value.ToString()).AddDays(0);
					item.EndDate = DateTime.Parse(dgbr.Cells[4].Value.ToString()).AddDays(0);
					item.BackColor = Color.LightGreen;
					item.Subject = "계획";

					itemCollection.Add(item);

					if (dgbr.Cells[5].ToString() != null)
					{
						var item2 = new WeekPlannerItem();
						item2.StartDate = DateTime.Parse(dgbr.Cells[5].Value.ToString()).AddDays(0);


						if (dgbr.Cells[6].Value.ToString().Equals("")) dgbr.Cells[6].Value = DateTime.Now.ToString();
						item2.EndDate = DateTime.Parse(dgbr.Cells[6].Value.ToString()).AddDays(0);
						item2.BackColor = Color.LightBlue;
						item2.Subject = "작업";

						itemCollection.Add(item2);
						calendarPlanner1.Rows.Add(ColumnRows, itemCollection);
					}
				}
			}
		}
		private void WeekplannerOpen()
		{
			datagridview1.Rows.Clear();
			List<WorkOrder> orderList = _ProcessC.GetWorkOrders();
			if (orderList != null)
			{
				foreach (WorkOrder os in orderList)
				{
					if (os.OrderDate.Equals("")) os.OrderDate = DateTime.Now.ToString();
					if (os.OrderDateEnd.Equals("")) os.OrderDateEnd = DateTime.Now.ToString();
					if (os.OrderStartSchedule.Equals("")) os.OrderStartSchedule = DateTime.Now.ToString();
					if (os.OrderEndSchedule.Equals("")) os.OrderEndSchedule = DateTime.Now.ToString();

					datagridview1.Rows.Add(
						true,
						os.OrderName,
						ReturnValueState(os.OrderStateName),
						os.OrderDate.Substring(0, 10),
						os.OrderDateEnd.Substring(0, 10),
						os.OrderStartSchedule.Substring(0, 10),
						os.OrderEndSchedule.Substring(0, 10)
						);
				}
				SetWeekPlanner();
			}
		}
		#region 검색 basicform
		public string GetText()
		{
			return this.Text;
		}
		public void RefreshForm()
		{

			WeekplannerOpen();
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
		private void button4_Click(object sender, EventArgs e)
		{
			if (calendarPlanner1.Rows.Count != 0)
			{
				_DayCnt = _DayCnt - _DayArray[_DayArrayCnt];
				calendarPlanner1.CurrentDate = DateTime.Now.AddDays(_DayCnt);

				dateTimePicker1.Value = calendarPlanner1.CurrentDate;
			}
		}
		private void button2_Click(object sender, EventArgs e)
		{
			if (calendarPlanner1.Rows.Count != 0)
			{
				_DayCnt = _DayCnt + _DayArray[_DayArrayCnt];
				calendarPlanner1.CurrentDate = DateTime.Now.AddDays(_DayCnt);

				dateTimePicker1.Value = calendarPlanner1.CurrentDate;
			}
		}
		private void button5_Click(object sender, EventArgs e)
		{
			SetDayArray();
			button5.Text = _DayArray[_DayArrayCnt].ToString();
		}
		private void button6_Click(object sender, EventArgs e)
		{
			calendarPlanner1.CurrentDate = dateTimePicker1.Value;
		}
        private void button7_Click(object sender, EventArgs e)
        {
			this.Close();
        }
        private void btn_Close_Click(object sender, EventArgs e)
        {
			this.Close();
        }
    }
}