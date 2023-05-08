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
	public partial class Semi_Materials : Form
	{
		private MaterialsCtrl _MaterialsCtrl;
		private SemiView _form;
		private bool _AddView;

		private MaterialsSemi _MaterialsSemi;

		public Semi_Materials(MaterialsCtrl materialsCtrl, SemiView form)
		{
			InitializeComponent();

			_MaterialsCtrl = materialsCtrl;
			_form = form;
			_AddView = false;
			_MaterialsSemi = new MaterialsSemi();

			SetView();

		}
		public void SetView()
		{

			cb_Search_Type.Items.Clear();
			cb_Search_Type.Items.Add("모두");
			if (_MaterialsCtrl.Types != null)
				foreach (string str in _MaterialsCtrl.Types)
				{
					cb_Search_Type.Items.Add(str);
				}

			cb_Search_Type.SelectedIndex = 0;
			dgv_materials.Rows.Clear();
			List<Materials> list = _MaterialsCtrl.Materials;
			if (list != null)
				foreach (Materials materials in list)
				{
					dgv_materials.Rows.Add(
					   materials.MaterialsNo,
					   materials.MaterialsType,
					   materials.MaterialsName,
					   materials.MaterialsStandard,
					   materials.MaterialsMemo);
				}

			dgv_Add.Rows.Clear();
			dgv_semi.Rows.Clear();
			List<MaterialsSemi> list2 = _MaterialsCtrl.Semis;
			if (list2 != null)
			{
				int row = 0;
				foreach (MaterialsSemi ms in list2)
				{

					//반복 횟수만큼  cell 추가
					dgv_semi.Rows.Add(ms.Materialssemino, ms.Materialsseminame);

					int ea = 2;
					//cell 2 0
					foreach (string[] str in ms.Materialssemivalue2)
					{
						dgv_semi.Rows[row].Cells[ea].Value = str[1].ToString();
						ea++;
					}
					row++;
				}
			}

		}

		#region UI
		private void button6_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			_AddView = !_AddView;
			// 1741, 716
			if (_AddView)
			{
				this.Width = 1471;
				btn.BackColor = Color.FromArgb(255, 128, 0);
				btn.Text = "☞추가 정보";
				this.Location = new Point(this.Location.X - 350, this.Location.Y);
			}
			else
			{
				this.Width = 716;
				btn.BackColor = Color.FromArgb(48, 103, 162);
				btn.Text = "☜추가 정보";
				this.Location = new Point(this.Location.X + 350, this.Location.Y);
			}

		}
		private void button2_Click(object sender, EventArgs e)
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
		private void checkBox1_CheckedChanged(object sender, EventArgs e)
		{
			if (checkBox1.Checked) textBox3.ReadOnly = false;
			else textBox3.ReadOnly = true;
		}

		private void dgv_materials_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				bool check = true;
				foreach (DataGridViewRow dgvr in dgv_Add.Rows)
				{
					if (dgvr.Cells[0].Value == dgv_materials.Rows[e.RowIndex].Cells[0].Value) check = false;
				}

				if (check)
				{
					if (dgv_Add.Rows.Count > 8) MessageBox.Show("더이상 추가할수 없습니다.");
					else
					{
						dgv_Add.Rows.Add(dgv_materials.Rows[e.RowIndex].Cells[0].Value,
												dgv_materials.Rows[e.RowIndex].Cells[2].Value,
												0);
					}
				}
			}
		}


		private void dgv_Add_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				var senderGrid = (DataGridView)sender;
				if (senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn &&
				  e.RowIndex >= 0)
				{
					if (e.ColumnIndex == 3) senderGrid.Rows[e.RowIndex].Cells[2].Value = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString()) + 1;
					if (e.ColumnIndex == 4)
					{
						if (Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString()) <= 0) MessageBox.Show("더이상 감소할수 없습니다.");
						else senderGrid.Rows[e.RowIndex].Cells[2].Value = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString()) - 1;
					}
				}
			}

		}

		private void button5_Click(object sender, EventArgs e)
		{
			if (checkBox1.Checked)
			{
				//신규 등록 : 동일한 반제품 있는지 확인해서 없으면 추가 
				if (textBox3.Text.Length != 0)
				{
					MaterialsSemi ms = new MaterialsSemi();
					ms.Materialsseminame = textBox3.Text;
					if (_MaterialsCtrl.FindSemiName(ms.Materialsseminame))
					{
						//동일한 이름 있는거 ;;
						MessageBox.Show("이미 동일한 명칭의 반제품이 있습니다.");
					}
					else
					{
						ms.Materialssemicnt = dgv_Add.Rows.Count;

						string str = "";
						foreach (DataGridViewRow dgvr in dgv_Add.Rows)
						{
							str = str + dgvr.Cells[0].Value.ToString() + "_" + dgvr.Cells[2].Value.ToString() + ",";
						}
						if (str.Length != 0) str = str.Substring(0, str.Length - 1);
						ms.Materialssemivalue = str;

						_MaterialsCtrl.InsertSemi(ms);
					}
				}
			}
			else
			{
				//존재하는 반제품 업데이트
				if (_MaterialsSemi.Materialssemino == 0) MessageBox.Show("선택된 반제품이 없습니다.");
				else
				{
					_MaterialsSemi.Materialssemicnt = dgv_Add.Rows.Count;
					string str = "";
					foreach (DataGridViewRow dgvr in dgv_Add.Rows)
					{
						str = str + dgvr.Cells[0].Value + "_" + dgvr.Cells[2].Value + ",";
					}
					if (str.Length != 0) str = str.Substring(0, str.Length - 1);
					_MaterialsSemi.Materialssemivalue = str;

					_MaterialsCtrl.UpdateSemi(_MaterialsSemi);
				}
			}
			SetView();
		}

		private void dgv_Add_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var senderGrid = (DataGridView)sender;

			if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) &&
			 e.RowIndex >= 0)
				if (e.RowIndex != -1)
				{
					_MaterialsCtrl.DeleteSemi(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
					senderGrid.Rows.RemoveAt(e.RowIndex);
				}
		}
		#endregion

		private void dgv_semi_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				var senderGrid = (DataGridView)sender;

				foreach (MaterialsSemi ms in _MaterialsCtrl.Semis)
					if ((int)senderGrid.Rows[e.RowIndex].Cells[0].Value == ms.Materialssemino) _MaterialsSemi = ms;
				textBox3.Text = _MaterialsSemi.Materialsseminame;

				dgv_Add.Rows.Clear();

				foreach (string[] str in _MaterialsSemi.Materialssemivalue2)
				{
					if (dgv_Add.Rows.Count > 8) MessageBox.Show("더이상 추가할수 없습니다.");
					else
					{
						string[] array = str[1].Split('(');
						dgv_Add.Rows.Add(str[0], array[0], array[1].Substring(0, array[1].Length - 1));
					}
				}
			}
		}
	}
}
