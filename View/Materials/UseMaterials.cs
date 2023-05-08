using Controller;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Model;
using Model.Material;

namespace View
{
	public partial class UseMaterials : Form
	{
		private int _ProductNo;
		private MaterialsCtrl _MaterialsCtrl;
		public UseMaterials(int ProductNo, bool type)
		{
			InitializeComponent();
			_ProductNo = ProductNo;
			_MaterialsCtrl = new MaterialsCtrl();
			SetView();

			 button5.Visible = type;
		}

		private void SetView()
		{
			List<string[]> list = _MaterialsCtrl.GetAssemble(_ProductNo);
			dataGridView2.Rows.Clear();

			foreach (string[] str in list)
			{
				if (str[1].Equals("1")) str[1] = "반제품";
				else str[1] = "자제";
				dataGridView2.Rows.Add(str[0], str[1], str[2], str[3]);
			}

			cb_Search_Type.Items.Clear();
			cb_Search_Type.Items.Add("모두");
			if (_MaterialsCtrl.Types != null)
				foreach (string str in _MaterialsCtrl.Types)
				{
					cb_Search_Type.Items.Add(str);
				}

			cb_Search_Type.SelectedIndex = 0;

			dataGridView1.Rows.Clear();
			if (_MaterialsCtrl.Semis != null)
			{
				foreach (MaterialsSemi ms in _MaterialsCtrl.Semis)
				{
					string str = "";
					foreach (string[] st in ms.Materialssemivalue2) str = str + st[1];
					dataGridView1.Rows.Add(ms.Materialssemino, ms.Materialsseminame, str);
				}
			}
			dgv_materials.Rows.Clear();
			foreach (Materials m in _MaterialsCtrl.Materials)
			{
				dgv_materials.Rows.Add(m.MaterialsNo, m.MaterialsType, m.MaterialsName, m.MaterialsStandard, m.MaterialsMemo);
			}
		}

		private void button4_Click(object sender, EventArgs e)
		{
			button4.BackColor = Color.FromArgb(255, 128, 0);
			button3.BackColor = Color.FromArgb(48, 103, 162);
			panel3.BringToFront();

		}

		private void button3_Click(object sender, EventArgs e)
		{
			button3.BackColor = Color.FromArgb(255, 128, 0);
			button4.BackColor = Color.FromArgb(48, 103, 162);
			panel6.BringToFront();
		}

		private void dataGridView2_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				var senderGrid = (DataGridView)sender;
				if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
				  e.RowIndex >= 0)
				{
					if (e.ColumnIndex == 4) senderGrid.Rows[e.RowIndex].Cells[3].Value = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString()) + 1;
					if (e.ColumnIndex == 5)
					{
						if (Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString()) <= 0) MessageBox.Show("더이상 감소할수 없습니다.");
						else senderGrid.Rows[e.RowIndex].Cells[3].Value = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString()) - 1;
					}
				}
			}
		}

		private void button2_Click(object sender, EventArgs e)
		{
			if(button2.BackColor == Color.FromArgb(48, 103, 162))
			{
				button2.BackColor = Color.FromArgb(255, 128, 0);
				this.Width = 1433;
			}
			else
			{
				button2.BackColor = Color.FromArgb(48, 103, 162);
				this.Width = 676;
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			dgv_materials.Rows.Clear();

			List<Materials> list = _MaterialsCtrl.Materials;
			if (list != null)
			{
				foreach (Materials materials in list)
				{
					if (materials.MaterialsName.IndexOf(textBox4.Text) != -1)
					{
						if ((cb_Search_Type.SelectedItem.Equals("모두") || cb_Search_Type.SelectedItem.Equals(materials.MaterialsType)))
						{
							dgv_materials.Rows.Add(
							   materials.MaterialsNo,
							   materials.MaterialsType,
							   materials.MaterialsName,
							   materials.MaterialsStandard,
							   materials.MaterialsMemo);
						}
					}
				}
			}
		}
		private void button9_Click(object sender, EventArgs e)
		{
			dataGridView1.Rows.Clear();

			List<MaterialsSemi> list = _MaterialsCtrl.Semis;
			if (list != null)
			{
				foreach (MaterialsSemi materials in list)
				{
					if (materials.Materialsseminame.IndexOf(textBox2.Text) != -1)
					{
						string str = "";
						foreach (string[] st in materials.Materialssemivalue2) str = str + st[1];
						dataGridView1.Rows.Add(materials.Materialssemino, materials.Materialsseminame, str);
					}
				}
			}
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				bool check = true;
				DataGridView senderGrid = (DataGridView)sender;
				if (senderGrid.Rows[e.RowIndex].Index != -1)
				{
					foreach (DataGridViewRow dgvr in dataGridView2.Rows)
					{
						if (dgvr.Cells[0].Value.ToString().Equals(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()) &&
							dgvr.Cells[2].Value.ToString().Equals(senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString())) check = false;
					}
					if (check)
						dataGridView2.Rows.Add(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), "반제품", senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString(), 0);
				}
			}
		}

		private void dgv_materials_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				bool check = true;

				DataGridView senderGrid = (DataGridView)sender;
				if (senderGrid.Rows[e.RowIndex].Index != -1)
				{
					foreach (DataGridViewRow dgvr in dataGridView2.Rows)
					{
						if (dgvr.Cells[0].Value.ToString().Equals(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString()) &&
							dgvr.Cells[2].Value.ToString().Equals(senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString())) check = false;
					}
					if (check)
						dataGridView2.Rows.Add(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString(), "부품", senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString(), 0);
				}
			}
		}

		private void button6_Click(object sender, EventArgs e)
		{
			List<Materials_Of_Product> list = new List<Materials_Of_Product>();

			foreach (DataGridViewRow dgvr in dataGridView2.Rows)
			{
				Materials_Of_Product mop = new Materials_Of_Product();

				mop.ProductNo = _ProductNo;
				bool type = false;

				if (dgvr.Cells[1].Value.ToString().Equals("반제품")) type = true;
				else type = false;
				mop.mopB = type;
				mop.mopNo = Int32.Parse(dgvr.Cells[0].Value.ToString());
				mop.mopCnt = Int32.Parse(dgvr.Cells[3].Value.ToString());

				list.Add(mop);
			}
			_MaterialsCtrl.SetMOP(list);

			MessageBox.Show("품목의 구성이 변경되었습니다.");
			button2_Click(sender, e);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			//자재 감소 -> method 있을듯
			//해당 자제 수량 분석 + 반재품 파싱 -> method 있을듯

			List<Materials_Of_Product> list = new List<Materials_Of_Product>();
			foreach(DataGridViewRow dgvr in dataGridView2.Rows)
			{
				if(dgvr.Cells[3].Value.ToString() != "0")
				{
					Materials_Of_Product mop = new Materials_Of_Product();

					mop.ProductNo = _ProductNo;
					if (dgvr.Cells[1].Value.ToString().Equals("반제품")) mop.mopB = true;
					else mop.mopB = false;
					mop.mopNo = Convert.ToInt32(dgvr.Cells[0].Value);
					mop.mopCnt = Convert.ToInt32(dgvr.Cells[3].Value);

					list.Add(mop);
				}
			}
			List<Materials> result = _MaterialsCtrl.WarehousingUseCheck(list);

			UseMaterialsUpdate umu = new UseMaterialsUpdate(result);
			umu.ShowDialog();

			this.Close();

		}


	}
}
