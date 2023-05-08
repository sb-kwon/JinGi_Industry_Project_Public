using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Model.Material;

namespace View
{
	public partial class IOForm : Form, IBasicForm
	{
		private Member _LoginInfo;
		private BasicForm _Mother;
		private MaterialsCtrl _MaterialsCtrl;
		private bool _Mode; // 모드 온시 색상 적용
		public IOForm(Member member, BasicForm form)
		{
			InitializeComponent();

			_Mother = form;
			_LoginInfo = member;
			_MaterialsCtrl = new MaterialsCtrl();
			_Mode = false;
			SetView();
		}
		public void SetView()
		{
			ModeBtnColorSet();
			textBox1.Text = "";

			comboBox3.Items.Clear();
			comboBox3.Items.Add("모두");
			if (_MaterialsCtrl.Locations != null)
				foreach (string str in _MaterialsCtrl.Locations)
				{
					comboBox3.Items.Add(str);
				}
			comboBox1.SelectedIndex = 0;
			comboBox3.SelectedIndex = 0;

			dgv_materials.Rows.Clear();
			List<string[]> list = _MaterialsCtrl.Material_Action;
			if (list != null)
				foreach (string[] ma in list)
				{
					if (!(ma[7].Equals(""))) ma[7] = String.Format("{0:#,###}", Convert.ToInt32(ma[7]));
					if (!(ma[8].Equals(""))) ma[8] = String.Format("{0:#,###}", Convert.ToInt32(ma[8]));
					if (!(ma[9].Equals(""))) ma[9] = String.Format("{0:#,###}", Convert.ToInt32(ma[9]));
					dgv_materials.Rows.Add(
						ma[0],
						ma[1],
						ma[2],
						ma[3],
						ma[4],
						ma[5],
						ma[6],
						ma[7],
						ma[8],
						ma[9],
						ma[10]);
				}
			if (_Mode)
			{
				foreach (DataGridViewRow dgvr in dgv_materials.Rows)
				{
					if (dgvr.Cells[3].Value.ToString().Equals("입고")) dgvr.DefaultCellStyle.BackColor = Color.FromArgb(235, 250, 250);
					if (dgvr.Cells[3].Value.ToString().Equals("출고")) dgvr.DefaultCellStyle.BackColor = Color.MistyRose;
				}
			}
		}
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
		private void button3_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			MaterialsRealsing mr = new MaterialsRealsing(_MaterialsCtrl, this);
			mr.ShowDialog();

			btn.BackColor = Color.FromArgb(48, 103, 162);
		}
		private void button5_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			MaterialsDef md = new MaterialsDef("location", _MaterialsCtrl, this);
			md.ShowDialog();

			btn.BackColor = Color.FromArgb(48, 103, 162);
		}
		private void button2_Click(object sender, EventArgs e)
		{
			dgv_materials.Rows.Clear();

			List<string[]> list = _MaterialsCtrl.Material_Action;
			if (list != null)
				foreach (string[] ma in list)
				{
					if (!(ma[7].Equals(""))) ma[7] = String.Format("{0:#,###}", Convert.ToInt32(ma[7]));
					if (!(ma[8].Equals(""))) ma[8] = String.Format("{0:#,###}", Convert.ToInt32(ma[8]));
					if (!(ma[9].Equals(""))) ma[9] = String.Format("{0:#,###}", Convert.ToInt32(ma[9]));

					if ((comboBox1.SelectedItem.Equals("모두") || comboBox1.SelectedItem.Equals(ma[3]))
						&& (comboBox3.SelectedItem.Equals("모두") || comboBox3.SelectedItem.Equals(ma[4]))
						&& (!dateTimePicker1.Enabled || dateTimePicker1.Value.ToString("yyyy-MM-dd").Equals(ma[1])
						&& ma[6].IndexOf(textBox1.Text) != -1))
					{
						dgv_materials.Rows.Add(
						ma[0],
						ma[1],
						ma[2],
						ma[3],
						ma[4],
						ma[5],
						ma[6],
						ma[7],
						ma[8],
						ma[9],
						ma[10]);
					}
				}
			if (_Mode)
			{
				foreach (DataGridViewRow dgvr in dgv_materials.Rows)
				{
					if (dgvr.Cells[3].Value.ToString().Equals("입고")) dgvr.DefaultCellStyle.BackColor = Color.FromArgb(235, 250, 250);
					if (dgvr.Cells[3].Value.ToString().Equals("출고")) dgvr.DefaultCellStyle.BackColor = Color.MistyRose;
				}
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			//신규 자재 등록
			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			MaterialsWearing mw = new MaterialsWearing(_MaterialsCtrl, this);
			mw.ShowDialog();

			btn.BackColor = Color.FromArgb(48, 103, 162);
		}
		private void btn_Update_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			/*			MaterialsUpdate mu = new MaterialsUpdate(_MaterialsCtrl, this);
						mu.ShowDialog();*/
			btn.BackColor = Color.FromArgb(48, 103, 162);
		}
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			dateTimePicker1.Enabled = checkBox1.Checked;
		}
		private void button6_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			ActionMove am = new ActionMove(_MaterialsCtrl, this);
			am.ShowDialog();
			btn.BackColor = Color.FromArgb(48, 103, 162);
		}
		private void button7_Click(object sender, EventArgs e)
		{
			//신규 자재 등록
			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			MaterialsInsert mi = new MaterialsInsert(_MaterialsCtrl, this);
			mi.ShowDialog();

			btn.BackColor = Color.FromArgb(48, 103, 162);
		}
		private void button4_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			_Mode = !_Mode;
			ModeBtnColorSet();
			SetView();
		}
		private void ModeBtnColorSet()
		{
			if (_Mode) button4.BackColor = Color.FromArgb(255, 128, 0);
			else button4.BackColor = Color.FromArgb(48, 103, 162);
		}
        private void lbl_test_Click(object sender, EventArgs e)
        {
			btn_test1.Text = lbl_test.Text + "+";
			btn_test2.Text = lbl_test.Text + "-";
        }
        private void btn_test1_Click(object sender, EventArgs e)
        {
			int i = Convert.ToInt32(lbl_test_count.Text);
			lbl_test_count.Text = (i + 1).ToString();
        }
        private void btn_test2_Click(object sender, EventArgs e)
        {
			int i = Convert.ToInt32(lbl_test_count.Text);
			if (!(i.Equals(0))) lbl_test_count.Text = (i - 1).ToString();
		}
	}
}