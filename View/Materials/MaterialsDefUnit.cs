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
	public partial class MaterialsDefUnit : Form
	{
		private String DateType;
		private MaterialsCtrl _MaterialsCtrl;
		private MaterialsForm _form1;
		private IOForm _form2;
		private BaseC _BaseC;

		private string value;
		public MaterialsDefUnit(MaterialsCtrl materialsCtrl, MaterialsForm form)
		{
			InitializeComponent();

			value = "";
			_MaterialsCtrl = materialsCtrl;
			_BaseC = new BaseC();
			DataInitialize();
			_form1 = form;
			_form2 = null;
		}


		#region Initialize
	
		private void DataInitialize()
		{
			//데이터 그리드 뷰 채우기
			dgv_materials.Rows.Clear();

	
			List<string> list = _BaseC.GetUnitList();

				if (list != null)
					foreach (string ml in list)
					{
						if (!ml.Equals("(미지정)"))
							dgv_materials.Rows.Add(ml);
					}
		
		}
		#endregion

		private void label5_Click(object sender, EventArgs e)
		{
			if (textBox1.TextLength == 0) MessageBox.Show("입력된 값을 확인해 주세요!");
			else
			{
				if (_BaseC.FindDefData("def_unit", "unit", textBox1.Text))
					MessageBox.Show("이미 존재하는 " + textBox1.Text + " 값 입니다.");
				else 
				{
					Def def = new Def();
					def.TableLogical = "def_unit";
					def.ValueLogical = "unit";

					_BaseC.InsertDefData(def, textBox1.Text);
					//clear 및 추가 되었다고 알림
					MessageBox.Show(textBox1.Text + "값이 추가 되었습니다.");
					FormViewClear();

				}
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
				if (_BaseC.FindDefData("def_unit", "unit", textBox1.Text))
					MessageBox.Show(textBox5.Text + "값은 이미 존재합니다.\n" + textBox2.Text + "  변경이 취소 되었습니다.");
				else
				{
					Def def = new Def();
					def.TableLogical = "def_unit";
					def.ValueLogical = "unit";
					def.SelectValue = textBox2.Text;

					_BaseC.UpdateDefData(def, textBox5.Text);
					//clear 및 추가 되었다고 알림
					MessageBox.Show(textBox5.Text + "값이 변경 되었습니다.");
					FormViewClear();
				}
			}
		}
		private void label8_Click(object sender, EventArgs e)
		{
			if (textBox4.Text.Length != 0)
			{
				Def def = new Def();

				def.TableLogical = "def_unit";
				def.ValueLogical = "unit";
				def.SelectValue = textBox4.Text;
				_BaseC.DeleteDefData(def);
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
