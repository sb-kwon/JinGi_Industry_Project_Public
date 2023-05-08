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
	public partial class RepairItem : Form
	{
		private RepairCtrl _RepairCtrl;
		private RepairView1 _form;
		private int dbmsType;
		private string[] _SelectValue;


		public RepairItem(RepairCtrl repairCtrl, RepairView1 form)
		{
			InitializeComponent();

			_RepairCtrl = repairCtrl;
			_form = form;
			_SelectValue = new string[2];
			SetView();


		}
		public void SetView()
		{
			textBox1.Text = null;
			dgv_product.Rows.Clear();
			if (_RepairCtrl.DefList != null)
				foreach (string[] str in _RepairCtrl.DefList) dgv_product.Rows.Add(str[0], str[1]);
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
			button2.BackColor = Color.FromArgb(48, 103, 162);
			button3.BackColor = Color.FromArgb(48, 103, 162);
			button4.BackColor = Color.FromArgb(48, 103, 162);

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
					textBox1.Text = "";
					textBox1.Enabled = true;
					break;
				case 2:
					textBox1.Enabled = true;

					break;
				case 3:
					textBox1.Enabled = false;
					break;
			}
		}

		private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			DataGridView dgv = (DataGridView)sender;
			if (e.RowIndex != -1 && dbmsType != 1)
			{
				_SelectValue[0] = dgv.Rows[e.RowIndex].Cells[0].Value.ToString();
				_SelectValue[1] = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
				textBox1.Text = dgv.Rows[e.RowIndex].Cells[1].Value.ToString();
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			switch (dbmsType)
			{
				case 1:
					_RepairCtrl.InsertDef(textBox1.Text);
					break;
				case 2:
					_SelectValue[1] = textBox1.Text;
					_RepairCtrl.UpdateDef(_SelectValue);
					break;
				case 3:
					_RepairCtrl.DeleteDef(_SelectValue);
					break;
			}
			SetView();

		}
	}
}
