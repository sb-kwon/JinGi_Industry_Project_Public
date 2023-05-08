using Controller;
using Model;
using Model.Material;
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
	public partial class RepairCheckUpdate : Form
	{
		private RepairCtrl _RepairCtrl;
		private RepairView1 _form;
		private int dbmsType;
		private string[] _SelectValue;
		private MachineC _MachineC;
		private Repairhistory _repairhistory;

		public RepairCheckUpdate(RepairCtrl repairCtrl, RepairView1 form)
		{
			InitializeComponent();

			_RepairCtrl = repairCtrl;
			_form = form;
			_SelectValue = new string[2];
			_MachineC = new MachineC();
			SetView();

			button3_Click(button2, null);
		}
		public void SetView()
		{
			dataGridView1.Rows.Clear();
			if (_RepairCtrl.RepairhistoryList != null)
				foreach (Repairhistory rs in _RepairCtrl.RepairhistoryList)
				{
					dataGridView1.Rows.Add(
						rs.Repairhistoryno,
						rs.Repairname,
						rs.Machinename,
						_RepairCtrl.SetTimevalue(rs.Repairhistorytime),
						rs.Repairitem,
						rs.Repairhistorymemo);
				}

			_MachineC.GetMachineList();

			List<Machine> lm = _MachineC.Machine;
			comboBox2.Items.Clear();
			if (lm != null)
			{
				foreach (Machine m in lm)
				{
					comboBox2.Items.Add(m.MachineName);
				}
				comboBox1.SelectedIndex = 0;
				if (comboBox2.Items.Count != 0) comboBox2.SelectedIndex = 0;
			}


		}

		private void button5_Click(object sender, EventArgs e)
		{
			dgv_product.Rows.Clear();
			if (_RepairCtrl.DefList != null)
				foreach (string[] str in _RepairCtrl.DefList)
					if (str[1].IndexOf(textBox2.Text) != -1)
						dgv_product.Rows.Add(str[0], str[1]);
		}

		private void button2_Click(object sender, EventArgs e)
		{

			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			dbmsType = Convert.ToInt32(btn.Tag);

			dgmsTypeSet();
		}
		private void dgmsTypeSet()
		{
			switch (dbmsType)
			{
				case 1:
					tb_Memo.Text = "";
					break;
				case 2:
					break;
				case 3:
					tb_Memo.Enabled = false;
					break;
			}
		}

		private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;

			if (e.RowIndex != -1)
			{
				_SelectValue[0] = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
				_SelectValue[1] = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();

				if (dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor == SystemColors.ActiveCaption)
				{
					dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.White;
					dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = Color.White;
				}
				else
				{
					dgv.Rows[e.RowIndex].DefaultCellStyle.BackColor = SystemColors.ActiveCaption;
					dgv.Rows[e.RowIndex].DefaultCellStyle.SelectionBackColor = SystemColors.ActiveCaption;

				}

			}
		}


		private void button1_Click_1(object sender, EventArgs e)
		{
			if (dbmsType == 1)
			{
				_RepairCtrl.DeleteHistory(_repairhistory.Repairhistoryno);
			}
			else if (dbmsType == 0)//update
			{
				Repairhistory repairhistory = new Repairhistory();

				repairhistory.Repairname = tb_Name.Text;
				repairhistory.Repairhistoryno = _repairhistory.Repairhistoryno;
				repairhistory.Machinename = comboBox2.SelectedItem.ToString();
				string str = "";
				foreach (DataGridViewRow dgvr in dgv_product.Rows)
				{
					if (dgvr.DefaultCellStyle.BackColor == SystemColors.ActiveCaption)
					{
						str = str + dgvr.Cells[0].Value.ToString() + ",";
					}
				}
				str = str.Substring(0, str.Length - 1);

				repairhistory.Repairhistorytime = 0;
				switch (comboBox1.SelectedIndex)
				{
					case 0:
						repairhistory.Repairhistorytime = 1;
						break;
					case 1:
						repairhistory.Repairhistorytime = 7;
						break;
					case 2:
						repairhistory.Repairhistorytime = 30;
						break;
					case 3:
						repairhistory.Repairhistorytime = 90;
						break;
					case 4:
						repairhistory.Repairhistorytime = 180;
						break;
					case 5:
						repairhistory.Repairhistorytime = 365;
						break;
				}
				repairhistory.Repairitem = str;

				repairhistory.Repairhistorymemo = tb_Memo.Text;
				_RepairCtrl.UpdateHistory(repairhistory);
			}
			_form.SetView();
			SetView();

		}

		private void btn_Search_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();
			if (_RepairCtrl.RepairhistoryList != null)
				foreach (Repairhistory rs in _RepairCtrl.RepairhistoryList)
				{
					if (rs.Repairname.IndexOf(cb_name.Text) != -1)
						dataGridView1.Rows.Add(
							rs.Repairhistoryno,
							rs.Repairname,
							rs.Machinename,
							_RepairCtrl.SetTimevalue(rs.Repairhistorytime),
							rs.Repairitem,
							rs.Repairhistorymemo);
				}
		}
		private void SetData()
		{
			string list = _repairhistory.Repairitem;

			dgv_product.Rows.Clear();
			if (_RepairCtrl.DefList != null)
				foreach (string[] str in _RepairCtrl.DefList)
				{
					dgv_product.Rows.Add(str[0], str[1]);
				}

			if (list.Length != 0)
			{
				string[] array = list.Split(',');
				foreach (DataGridViewRow dgvr in dgv_product.Rows)//dgv_product
				{
					foreach (string value in array)
					{
						if (value.Equals(dgvr.Cells[0].Value.ToString())) dgvr.DefaultCellStyle.BackColor = SystemColors.ActiveCaption;
					}
				}
			}

			tb_Name.Text = _repairhistory.Repairname;
			tb_Memo.Text = _repairhistory.Repairhistorymemo;

			comboBox1.SelectedItem = _repairhistory.RepairhistorytimeS;
			comboBox2.SelectedItem = _repairhistory.Machinename;
		}
		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;
			if (e.RowIndex != -1)
			{
				_repairhistory = new Repairhistory();
				_repairhistory.Repairhistoryno = Int32.Parse(dgv.Rows[e.RowIndex].Cells[0].Value.ToString());
				_repairhistory.Repairname = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
				_repairhistory.Machinename = dgv.Rows[e.RowIndex].Cells[2].Value.ToString();
				_repairhistory.RepairhistorytimeS = dgv.Rows[e.RowIndex].Cells[3].Value.ToString();
				_repairhistory.Repairitem = dgv.Rows[e.RowIndex].Cells[4].Value.ToString();
				_repairhistory.Repairhistorymemo = dgv.Rows[e.RowIndex].Cells[5].Value.ToString();

			}
			SetData();


		}

		private void button3_Click(object sender, EventArgs e)
		{
			button2.BackColor = Color.FromArgb(48, 103, 162);
			button3.BackColor = Color.FromArgb(48, 103, 162);

			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			dbmsType = Convert.ToInt32(btn.Tag);  //수정 0 삭제 1
			dbmsTypeSet();
		}
		private void dbmsTypeSet()
		{
			if (dbmsType == 0)//수정
			{
				tb_Memo.Enabled = true;
				tb_Name.Enabled = true;
				comboBox1.Enabled = true;
				comboBox2.Enabled = true;
				textBox2.Enabled = true;
				dgv_product.Enabled = true;
			}
			else //삭제
			{
				tb_Memo.Enabled = false;
				tb_Name.Enabled = false;
				comboBox1.Enabled = false;
				comboBox2.Enabled = false;
				textBox2.Enabled = false;
				dgv_product.Enabled = false;
			}
		}

		private void dgv_product_CellContentClick(object sender, DataGridViewCellEventArgs e)
		{

		}
	}
}
