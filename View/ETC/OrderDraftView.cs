using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
namespace View
{
	public partial class OrderDraftView : Form, IBasicForm
	{
		public Member _LoginInfo;
		private bool InsertCheck;
		private BasicForm _Mother;
		public DocumentCtrl _DocumentCtrl;
		private OrderDraft _SeletedOrderDraft;
		public OrderDraftView(Member member, BasicForm form)
		{
			InitializeComponent();

			_Mother = form;
			_LoginInfo = member;
			_DocumentCtrl = new DocumentCtrl();
			_SeletedOrderDraft = new OrderDraft();
			SetView();
		}
		public void SetView()
		{
			_DocumentCtrl.SetData();
			dgv_orderDraft.Rows.Clear();
			List<OrderDraft> list = _DocumentCtrl.OrderDrafts;
			if (list != null)
				foreach (OrderDraft od in list)
					dgv_orderDraft.Rows.Add(od.Orderdraftno, od.Orderdraftdate.Substring(0, 10), od.Orderdraftcustomer, od.OrderDraftCusMem, od.Orderdraftmemo);

			InsertCheck = false;
			button1.BackColor = Color.FromArgb(48, 103, 162);
			textBox2.Text = "";
			textBox3.Text = "";
			textBox4.Text = "";

			dataGridView1.Rows.Clear();
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
		private void button2_Click(object sender, EventArgs e)
		{
			dgv_orderDraft.Rows.Clear();
			List<OrderDraft> list = _DocumentCtrl.OrderDrafts;
			if (list != null)
				foreach (OrderDraft od in list)
					if (!dateTimePicker1.Enabled || dateTimePicker1.Value.ToString("yyyy-MM-dd").Equals(od.Orderdraftdate.Substring(0, 10)))
						if(od.Orderdraftcustomer.IndexOf(textBox1.Text) != -1)
							dgv_orderDraft.Rows.Add(od.Orderdraftno, od.Orderdraftdate.Substring(0, 10), od.Orderdraftcustomer, od.OrderDraftCusMem, od.Orderdraftmemo);

		}
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePicker1.Enabled = checkBox1.Checked;
		}
		private void button1_Click(object sender, EventArgs e)
		{
			InsertCheck = !InsertCheck;
			InsertViewSet();
		}
		private void InsertViewSet()
		{
			if (InsertCheck)
			{
				button1.BackColor = Color.FromArgb(255, 128, 0);
				textBox2.Text = "";
				textBox3.Text = "";
				textBox4.Text = DateTime.Now.ToString("yyyy-MM-dd");
				button4.Visible = true;
				dataGridView1.AllowUserToAddRows = true;
				textBox2.ReadOnly = false;
				textBox3.ReadOnly = false;
				textBox5.ReadOnly = false;
				dataGridView1.ReadOnly = false;
			}
			else
			{
				button1.BackColor = Color.FromArgb(48, 103, 162);
				button4.Visible = false;
				dataGridView1.AllowUserToAddRows = false;
				dataGridView1.Rows.Clear();
				textBox2.ReadOnly = true;
				textBox3.ReadOnly = true;
				textBox5.ReadOnly = true;
				dataGridView1.ReadOnly = true;
			}
		}
		private void button4_Click(object sender, EventArgs e)
		{
			dataGridView1.AllowUserToAddRows = false;

			OrderDraft od = new OrderDraft();
			od.Orderdraftdate = textBox4.Text;
			od.Orderdraftcustomer = textBox2.Text;
			od.Orderdraftmemo = textBox3.Text;
			od.OrderDraftCusMem = textBox5.Text;
			
			List<OrderDraftList> list = new List<OrderDraftList>();
			foreach (DataGridViewRow dgvr in dataGridView1.Rows)
			{
				OrderDraftList odl = new OrderDraftList();

				if(dgvr.Cells[0].Value != null)
				odl.Orderdraftlistname = dgvr.Cells[0].Value.ToString();
				if (dgvr.Cells[1].Value != null)
					odl.Orderdraftliststandard = dgvr.Cells[1].Value.ToString();
				if (dgvr.Cells[2].Value != null)
					odl.Orderdraftlistcount = dgvr.Cells[2].Value.ToString();
				if (dgvr.Cells[3].Value != null)
					odl.Orderdraftlistprice = dgvr.Cells[3].Value.ToString();
				if (dgvr.Cells[4].Value != null)
					odl.Orderdraftlisttax = dgvr.Cells[4].Value.ToString();

				list.Add(odl);
			}
			od.OrderDraftLists = list;

			_DocumentCtrl.InsertOrderDraft(od);
			SetView();
		}
		private void button5_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			if(btn.BackColor == Color.FromArgb(48, 103, 162))
			{
				btn.BackColor = Color.FromArgb(255, 128, 0);
				dataGridView1.AllowUserToAddRows = true;
				dataGridView1.ReadOnly = false;
				dataGridView1.AllowUserToDeleteRows = true;
				button6.Visible = true;
			}
			else
			{
				btn.BackColor = Color.FromArgb(48, 103, 162);
				dataGridView1.AllowUserToAddRows = false;
				dataGridView1.ReadOnly = true;
				dataGridView1.AllowUserToDeleteRows = false;
				button6.Visible = false;
			}
		}
		private void dgv_orderDraft_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			SetView();
			if (e.RowIndex != -1)
			{
				DataGridView senderGrid = (DataGridView)sender;

				foreach (OrderDraft od in _DocumentCtrl.OrderDrafts)
				{
					if (Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()) == od.Orderdraftno)
					{
						_SeletedOrderDraft = od;
						button6.Tag = od.Orderdraftno;
						textBox2.Text = od.Orderdraftcustomer;
						textBox3.Text = od.Orderdraftmemo;
						textBox5.Text = od.OrderDraftCusMem;
						textBox4.Text = od.Orderdraftdate.Substring(0,10);

						if(od.OrderDraftLists != null)
						foreach(OrderDraftList odl in od.OrderDraftLists)
							dataGridView1.Rows.Add(odl.Orderdraftlistname, odl.Orderdraftliststandard, odl.Orderdraftlistcount, odl.Orderdraftlistprice, odl.Orderdraftlisttax);
					}
				}
			}
		}
		private void button6_Click(object sender, EventArgs e)
		{
			dataGridView1.AllowUserToAddRows = false;

			OrderDraft od = new OrderDraft();
			od.Orderdraftdate = textBox4.Text;
			od.Orderdraftcustomer = textBox2.Text;
			od.Orderdraftmemo = textBox3.Text;
			od.Orderdraftno = (int)button6.Tag;

			List<OrderDraftList> list = new List<OrderDraftList>();
			foreach (DataGridViewRow dgvr in dataGridView1.Rows)
			{
				OrderDraftList odl = new OrderDraftList();
				odl.Orderdraftno = od.Orderdraftno;
				if (dgvr.Cells[0].Value != null)
					odl.Orderdraftlistname = dgvr.Cells[0].Value.ToString();
				if (dgvr.Cells[1].Value != null)
					odl.Orderdraftliststandard = dgvr.Cells[1].Value.ToString();
				if (dgvr.Cells[2].Value != null)
					odl.Orderdraftlistcount = dgvr.Cells[2].Value.ToString();
				if (dgvr.Cells[3].Value != null)
					odl.Orderdraftlistprice = dgvr.Cells[3].Value.ToString();
				if (dgvr.Cells[4].Value != null)
					odl.Orderdraftlisttax = dgvr.Cells[4].Value.ToString();

				list.Add(odl);
			}
			od.OrderDraftLists = list;

			_DocumentCtrl.UpdateOrderDraftList(od);
			SetView();
		}
		private void button3_Click(object sender, EventArgs e)
		{
			if (_SeletedOrderDraft != null)
			{
				textBox2.Text = _SeletedOrderDraft.Orderdraftcustomer;
				textBox3.Text = _SeletedOrderDraft.Orderdraftmemo;
				textBox4.Text = _SeletedOrderDraft.Orderdraftdate.Substring(0, 10);

				if (_SeletedOrderDraft.OrderDraftLists != null)
					foreach (OrderDraftList odl in _SeletedOrderDraft.OrderDraftLists)
						dataGridView1.Rows.Add(odl.Orderdraftlistname, odl.Orderdraftliststandard, odl.Orderdraftlistcount, odl.Orderdraftlistprice, odl.Orderdraftlisttax);

				string[] list = {   _SeletedOrderDraft.Orderdraftdate.Substring(0, 10),
									_SeletedOrderDraft.Orderdraftcustomer,
									_SeletedOrderDraft.Orderdraftmemo,
									_SeletedOrderDraft.OrderDraftCusMem};

				List<string[]> list1 = new List<string[]>();

				if (_SeletedOrderDraft.OrderDraftLists != null)
					foreach (OrderDraftList odl in _SeletedOrderDraft.OrderDraftLists)
					{
						string[] list2 = {
							odl.Orderdraftlistname,
							odl.Orderdraftliststandard,
							odl.Orderdraftlistcount,
							odl.Orderdraftlistprice,
							odl.Orderdraftlisttax};

						list1.Add(list2);
					}
				OrderRecipt print_Form = new OrderRecipt(list, list1, "발   주   서");

				print_Form.StartPosition = FormStartPosition.CenterParent;
				print_Form.Location = new Point(this.Location.X + this.Width, this.Location.Y);
				print_Form.ShowDialog();

			}
		}
		private void button7_Click(object sender, EventArgs e)
		{
			if (_SeletedOrderDraft != null)
			{

				textBox2.Text = _SeletedOrderDraft.Orderdraftcustomer;
				textBox3.Text = _SeletedOrderDraft.Orderdraftmemo;
				textBox4.Text = _SeletedOrderDraft.Orderdraftdate.Substring(0, 10);

				if (_SeletedOrderDraft.OrderDraftLists != null)
					foreach (OrderDraftList odl in _SeletedOrderDraft.OrderDraftLists)
						dataGridView1.Rows.Add(odl.Orderdraftlistname, odl.Orderdraftliststandard, odl.Orderdraftlistcount, odl.Orderdraftlistprice, odl.Orderdraftlisttax);

				string[] list = {   _SeletedOrderDraft.Orderdraftdate.Substring(0, 10),
									_SeletedOrderDraft.Orderdraftcustomer,
									_SeletedOrderDraft.Orderdraftmemo,
									_SeletedOrderDraft.OrderDraftCusMem};

				List<string[]> list1 = new List<string[]>();

				if (_SeletedOrderDraft.OrderDraftLists != null)
					foreach (OrderDraftList odl in _SeletedOrderDraft.OrderDraftLists)
					{
						string[] list2 = {
							odl.Orderdraftlistname,
							odl.Orderdraftliststandard,
							odl.Orderdraftlistcount,
							odl.Orderdraftlistprice,
							odl.Orderdraftlisttax};

						list1.Add(list2);
					}
				OrderRecipt print_Form = new OrderRecipt(list, list1, "거 래 명 세 서");

				print_Form.StartPosition = FormStartPosition.CenterParent;
				print_Form.Location = new Point(this.Location.X + this.Width, this.Location.Y);
				print_Form.ShowDialog();
			}
		}
        private void btn_Hometax_Click(object sender, EventArgs e)
        {
			Process.Start("https://www.hometax.go.kr");
		}
	}
}