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
	public partial class Semi_Product : Form
	{
		private MaterialsCtrl _MaterialsCtrl;
		private SemiView _form;
		private List<String[]> ViewList;
		private ProcessC _ProcessC;
		private Product _Product;
		private bool b1, b2, b3;

		public Semi_Product(MaterialsCtrl materialsCtrl, SemiView form)
		{
			InitializeComponent();

			_MaterialsCtrl = materialsCtrl;
			_form = form;
			b1 = true;
			b2 = b3 = false;
			_Product = new Product();
			SetView();


		}
		public void SetView()
		{
			ViewList = new List<string[]>();
			_ProcessC = new ProcessC();
			GetProductData();
			ViewSet(true, false, false);

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
		}

		private void GetProductData()
		{
			List<string[]> list = new List<string[]>();

			list = _ProcessC.GetProductData();
			ViewList = list;
			SetProductListView();
		}
		private void SetProductListView()
		{
			dgv_product.Rows.Clear();
			if (ViewList != null)
				foreach (string[] array in ViewList)
				{
					dgv_product.Rows.Add(array[0], array[1], array[2], array[3]);
				}

			dgv_materials.Rows.Clear();
			foreach (Materials m in _MaterialsCtrl.Materials)
			{
				dgv_materials.Rows.Add(m.MaterialsNo, m.MaterialsType, m.MaterialsName, m.MaterialsStandard, m.MaterialsMemo);
			}
		}
		private void button1_Click(object sender, EventArgs e)
		{
			dgv_materials.Rows.Clear();

			dgv_product.Rows.Clear();
			if (ViewList != null)
				foreach (string[] array in ViewList)
				{
					if (array[1].ToString().IndexOf(textBox1.Text) != -1)
						dgv_product.Rows.Add(array[0], array[1], array[2], array[3]);
				}
		}


		private void SetProduct()
		{
			label14.Text = _Product.ProductName;
			label13.Text = _Product.ProductPrice.ToString();
			label12.Text = _Product.ProductMemo;

		}

		private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				DataGridView senderGrid = (DataGridView)sender;

				_Product.ProductNo = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
				_Product.ProductName = senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString();
				_Product.ProductPrice = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
				_Product.ProductMemo = senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString();

				SetProduct();

				List<string[]> list = _MaterialsCtrl.GetAssemble(_Product.ProductNo);
				dataGridView2.Rows.Clear();

				foreach (string[] str in list)
				{
					if (str[1].Equals("1")) str[1] = "반제품";
					else str[1] = "자제";
					dataGridView2.Rows.Add(str[0], str[1], str[2], str[3]);
				}
			}

		}

		private void button3_Click(object sender, EventArgs e)
		{

			if (_Product.ProductNo > 0)
			{
				b2 = !b2;
				b3 = b1 = false;
				ViewSet(b1, b2, b3);
			}
			else MessageBox.Show("품목을 먼저 선택하십시오");


		}

		private void button4_Click(object sender, EventArgs e)
		{
			if (_Product.ProductNo > 0)
			{
				b3 = !b3;
				b2 = b1 = false;
				ViewSet(b1, b2, b3);
			}
			else MessageBox.Show("품목을 먼저 선택하십시오");


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

		private void button9_Click(object sender, EventArgs e)
		{
			//text2

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

		private void dataGridView2_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
		{
			var senderGrid = (DataGridView)sender;

			if (!(senderGrid.Columns[e.ColumnIndex] is DataGridViewButtonColumn) &&
			 e.RowIndex >= 0)
				if (e.RowIndex != -1)
				{


					Materials_Of_Product mop = new Materials_Of_Product();

					mop.ProductNo = _Product.ProductNo;
					bool type = false;
					MessageBox.Show(senderGrid.Rows[e.RowIndex].Cells[2].Value.ToString());
					if (senderGrid.Rows[e.RowIndex].Cells[1].Value.ToString().Equals("반제품")) type = true;
					else type = false;
					mop.mopB = type;
					mop.mopNo = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());
					mop.mopCnt = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[3].Value.ToString());

					_MaterialsCtrl.mopDelete(mop);
					senderGrid.Rows.RemoveAt(e.RowIndex);


					List<string[]> list = _MaterialsCtrl.GetAssemble(_Product.ProductNo);
					dataGridView2.Rows.Clear();

					foreach (string[] str in list)
					{
						if (str[1].Equals("1")) str[1] = "반제품";
						else str[1] = "자제";
						dataGridView2.Rows.Add(str[0], str[1], str[2], str[3]);
					}

				}
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

		private void button5_Click(object sender, EventArgs e)
		{
			List<Materials_Of_Product> list = new List<Materials_Of_Product>();

			foreach (DataGridViewRow dgvr in dataGridView2.Rows)
			{
				Materials_Of_Product mop = new Materials_Of_Product();

				mop.ProductNo = _Product.ProductNo;
				bool type = false;

				if (dgvr.Cells[1].Value.ToString().Equals("반제품")) type = true;
				else type = false;
				mop.mopB = type;
				mop.mopNo = Int32.Parse(dgvr.Cells[0].Value.ToString());
				mop.mopCnt = Int32.Parse(dgvr.Cells[3].Value.ToString());

				list.Add(mop);
			}
			_MaterialsCtrl.SetMOP(list);
		}

		private void button6_Click(object sender, EventArgs e)
		{
			b1 = !b1;
			b2 = b3 = false;
			ViewSet(b1, b2, b3);

		}
		private void ViewSet(bool a, bool b, bool c)
		{
			button3.BackColor = Color.FromArgb(48, 103, 162);
			button4.BackColor = Color.FromArgb(48, 103, 162);
			button6.BackColor = Color.FromArgb(48, 103, 162);
			if (a)
			{
				button6.BackColor = Color.FromArgb(255, 128, 0);
				pnl_Product.BringToFront();
			}
			if (b)
			{
				button3.BackColor = Color.FromArgb(255, 128, 0);
				panel6.BringToFront();
			}
			if (c)
			{
				button4.BackColor = Color.FromArgb(255, 128, 0);
				panel3.BringToFront();
			}
		}
	}
}
