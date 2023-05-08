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
	public partial class MaterialsDef : Form
	{
		private String DateType;
		private MaterialsCtrl _MaterialsCtrl;
		private MaterialsForm _form1;
		private IOForm _form2;

		private string value;
		public MaterialsDef(String str, MaterialsCtrl materialsCtrl, MaterialsForm form)
		{
			InitializeComponent();

			value = "";
			_MaterialsCtrl = materialsCtrl;
			SetFormMode(str);

			DataInitialize();
			_form1 = form;
			_form2 = null;
		}
		public MaterialsDef(String str, MaterialsCtrl materialsCtrl, IOForm form)
		{
			InitializeComponent();

			value = "";
			_MaterialsCtrl = materialsCtrl;
			SetFormMode(str);

			DataInitialize();
			_form1 = null;
			_form2 = form;
		}

		#region Initialize
		private void SetFormMode(string str)
		{
			DateType = str;

			if (str.Equals("location"))
			{
				lbl_TextChange1.Text = "위치";
				lbl_TextChange2.Text = "위치";
				this.Column7.HeaderText = "자재 위치";
			}
			else if (str.Equals("type"))
			{
				lbl_TextChange1.Text = "타입";
				lbl_TextChange2.Text = "타입";
				this.Column7.HeaderText = "자재 타입";
			}

			DateType = "materials_" + str;
		}
		private void DataInitialize()
		{
			//데이터 그리드 뷰 채우기
			dgv_materials.Rows.Clear();
			if (DateType.Equals("materials_location"))
			{
				if (_MaterialsCtrl.Locations != null)
					foreach (string ml in _MaterialsCtrl.Locations)
					{
						if (!ml.Equals("(미지정)"))
							dgv_materials.Rows.Add(ml);
					}
			}
			else if (DateType.Equals("materials_type"))
			{
				if (_MaterialsCtrl.Types != null)
					foreach (string ml in _MaterialsCtrl.Types)
					{
						if (!ml.Equals("(미지정)"))
							dgv_materials.Rows.Add(ml);
					}
			}
		}
		#endregion

		private void label5_Click(object sender, EventArgs e)
		{
			if (textBox1.TextLength == 0) MessageBox.Show("입력된 값을 확인해 주세요!");
			else
			{
				if (_MaterialsCtrl.InsertData(DateType, textBox1.Text))
				{
					//clear 및 추가 되었다고 알림
					MessageBox.Show(textBox1.Text + "값이 추가 되었습니다.");
					FormViewClear();

				}
				else MessageBox.Show("이미 존재하는 " + lbl_TextChange1.Text + " 값 입니다.");
			}
		}

		private void FormViewClear()
		{
			textBox1.Text = "";
			textBox2.Text = "";
			textBox4.Text = "";
			textBox5.Text = "";

			DataInitialize();
			value = "";
		}

		private void dgv_materials_CellClick(object sender, DataGridViewCellEventArgs e)
		{
			if (e.RowIndex != -1)
			{
				value = dgv_materials.Rows[e.RowIndex].Cells[0].Value.ToString();

				textBox2.Text = value;
				textBox4.Text = value;
			}

		}

		private void label6_Click(object sender, EventArgs e)
		{
			if (textBox5.Text.Length != 0 && textBox2.Text.Length != 0)
			{
				if (_MaterialsCtrl.UpdateData(DateType, textBox5.Text, textBox2.Text))
				{
					MessageBox.Show(textBox2.Text + "값이 " + textBox5.Text + "값으로 변경 되었습니다.");
					_MaterialsCtrl.SetMaterials();

					if (_form1 != null) _form1.SetView();
					if (_form2 != null) _form2.SetView();
					FormViewClear();
				}
				else MessageBox.Show(textBox5.Text + "값은 이미 존재합니다.\n" + textBox2.Text + "  변경이 취소 되었습니다.");
			}
		}
		private void label8_Click(object sender, EventArgs e)
		{
			if (textBox4.Text.Length != 0)
			{
				_MaterialsCtrl.DeleteData(DateType, textBox4.Text);
				MessageBox.Show(textBox4.Text + "값이 삭제 되었습니다.");
				FormViewClear();
			}
		}

		private void MaterialsDef_FormClosing(object sender, FormClosingEventArgs e)
		{
			_MaterialsCtrl.SetMaterials();

			if (_form1 != null) _form1.SetView();
			if (_form2 != null) _form2.SetView();
		}
	}
}
