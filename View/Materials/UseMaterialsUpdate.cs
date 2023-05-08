using Controller;
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
	public partial class UseMaterialsUpdate : Form
	{
		private List<Materials> _Materials;
		private MaterialsCtrl _MaterialsCtrl;
		private int _UseNo;
		public UseMaterialsUpdate(List<Materials> list)
		{
			InitializeComponent();
			_MaterialsCtrl = new MaterialsCtrl();
			_Materials = list;
			SetView();
		}

		private void SetView()
		{
			dgv_materials.Rows.Clear();
			foreach (Materials m in _Materials)
			{
				dgv_materials.Rows.Add(m.MaterialsNo, m.MaterialsType, m.MaterialsName, m.MaterialsCount, m.MaterialsStandard, m.MaterialsMemo);
			}
		}

		private void dgv_materials_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;
			DataGridViewRow dgvr = dgv.Rows[e.RowIndex];

			dataGridView1.Rows.Clear();

			_UseNo = Convert.ToInt32(dgvr.Cells[0].Value);
			List<string[]> list = _MaterialsCtrl.GetOrderByMaterialsLocation(_UseNo);

			label9.Text = "";
			label8.Text = "";
			label7.Text = "";
			textBox1.Text = "0";

			if (list != null)
			{
				foreach (string[] str in list)
				{
					if (label9.Text.Equals(""))
					{
						label9.Tag = dgvr.Cells[0].Value.ToString();
						label9.Text = dgvr.Cells[2].Value.ToString();
						label8.Text = str[0];
						label7.Text = str[1];
					}
					dataGridView1.Rows.Add(dgvr.Cells[0].Value.ToString(), dgvr.Cells[2].Value.ToString(), str[0], str[1]);
				}
			}
		}

		private void button3_Click(object sender, EventArgs e)
		{
			if (!label9.Text.Equals(""))
			{
				int MaterialTotal = CheckEnableCount();
				int LocationTotal = Convert.ToInt32(label7.Text);

				int useCnt = 0;

				foreach(DataGridViewRow dgvr in dataGridView2.Rows)
				{
					if (label9.Tag.ToString().Equals(dgvr.Cells[0].Value.ToString())
						&& dgvr.Cells[2].Value.ToString().Equals(label8.Text))
						useCnt = useCnt + Convert.ToInt32(dgvr.Cells[0].Value);
				}
				if (MaterialTotal >= LocationTotal)
				{
					if (useCnt == 0) textBox1.Text = LocationTotal.ToString();
					else
					{
						textBox1.Text = (LocationTotal - useCnt).ToString();
					}
				}
				else textBox1.Text = MaterialTotal.ToString();
			}
		}

		private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;
			DataGridViewRow dgvr = dgv.Rows[e.RowIndex];

			label9.Tag = dgvr.Cells[0].Value.ToString();
			label9.Text  = dgvr.Cells[1].Value.ToString();
			label8.Text  = dgvr.Cells[2].Value.ToString();
			label7.Text  = dgvr.Cells[3].Value.ToString();
			textBox1.Text = "0";
		}

		private void button1_Click(object sender, EventArgs e)
		{
			if (textBox1.Text.Length == 0);
			else if (GetTotalCount() < Convert.ToInt32(textBox1.Text)) MessageBox.Show("총 수량보다 많습니다.");
			else if (CheckEnableCount() < Convert.ToInt32(textBox1.Text)) MessageBox.Show("선택 수량보다 많이 선택 되었습니다.");
			else if (label9.Text.Equals("")) MessageBox.Show("불출할 위치를 선택해 주세요");
			else if (textBox1.Text.Equals("0"));
			else
			{
				dataGridView2.Rows.Add(_UseNo, label9.Text, label8.Text, textBox1.Text);
				textBox1.Text = "";
			}
		}

		private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
		{
			if (Char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToInt32(Keys.Back))
			{ }
			else { e.Handled = true; }
		}

		private int GetTotalCount()
		{
			int total = 0;
			foreach (DataGridViewRow dgvr in dgv_materials.Rows)
			{
				if (_UseNo == Convert.ToInt32( dgvr.Cells[0].Value))
				{
					total = Convert.ToInt32(dgvr.Cells[3].Value);
					break;
				}
			}
			return total;
		}
		private int CheckEnableCount()
		{
			int result = 0;
			int UseCnt = 0;
			foreach(DataGridViewRow dgvr in dataGridView2.Rows)
			{
				if(_UseNo == Convert.ToInt32( dgvr.Cells[0].Value))
					UseCnt = UseCnt + Convert.ToInt32(dgvr.Cells[3].Value);
			}

			result = GetTotalCount() - UseCnt;
			return result;
		}

		private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;
			DataGridViewRow dgvr = dgv.Rows[e.RowIndex];

			dgv.Rows.Remove(dgvr);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			// datagridview2foreach 

			List<Materials> list = new List<Materials>();
			bool UseCheck = false;

			foreach(DataGridViewRow dgvr1 in dgv_materials.Rows)
			{
				int value = Convert.ToInt32(dgvr1.Cells[3].Value);
				foreach (DataGridViewRow dgvr in dataGridView2.Rows)
				{
					if(Convert.ToInt32(dgvr1.Cells[0].Value) == Convert.ToInt32(dgvr.Cells[0].Value))
					{
						value = value - Convert.ToInt32(dgvr.Cells[3].Value);
					}
				}
				if (value != 0)
				{
					UseCheck = true;
					break;
				}
			}

			if (UseCheck) MessageBox.Show("불출값 확인필요!");
			else
			{
				foreach(DataGridViewRow dgvr in dataGridView2.Rows)
				{
					_MaterialsCtrl.Realsing(Convert.ToInt32(dgvr.Cells[0].Value),
						dgvr.Cells[2].Value.ToString(),
						Convert.ToInt32(dgvr.Cells[3].Value),
						"공정에 의한 출고");
				}

				dataGridView2.Rows.Clear();
				MessageBox.Show("불출이 완료 되었습니다.");
				this.Close();
			}
		}
	}
}
