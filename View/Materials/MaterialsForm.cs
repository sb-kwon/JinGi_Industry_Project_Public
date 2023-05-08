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
	public partial class MaterialsForm : Form, IBasicForm
	{
		private Member _LoginInfo;
		private BasicForm _Mother;
		private MaterialsCtrl _MaterialsCtrl;
		public MaterialsForm(Member member, BasicForm form)
		{
			InitializeComponent();

			_Mother = form;
			_LoginInfo = member;
			_MaterialsCtrl = new MaterialsCtrl();

			SetView();
		}
		public void SetView()
		{
			textBox1.Text = "";

			cb_Type.Items.Clear();
			//com1 타입
			//com2 위치
			cb_Type.Items.Add("모두");
			if (_MaterialsCtrl.Types != null)
				foreach (string str in _MaterialsCtrl.Types)
					cb_Type.Items.Add(str);

			cb_Type.SelectedIndex = 0;

            dgv_materials.Rows.Clear();
            List<Materials> list = _MaterialsCtrl.Materials;
            if (list != null)
                foreach (Materials materials in list)
                    dgv_materials.Rows.Add(
                        materials.MaterialsNo,
                              materials.MaterialsType,
                              materials.MaterialsName,
                              materials.MaterialsStandard,
                              string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsCount)),
                              materials.Unit,
                              string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsPrice)),
                              string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsCount * materials.MaterialsPrice)),
                              materials.MaterialsMemo);
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

			MaterialsDef md = new MaterialsDef("location", _MaterialsCtrl, this);
			md.ShowDialog();

			btn.BackColor = Color.FromArgb(48, 103, 162);
		}

		private void button5_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			MaterialsDef md = new MaterialsDef("type", _MaterialsCtrl, this);
			md.ShowDialog();

			btn.BackColor = Color.FromArgb(48, 103, 162);
		}

		private void button2_Click(object sender, EventArgs e)
		{
			dgv_materials.Rows.Clear();

			List<Materials> list = _MaterialsCtrl.Materials;
			if (list != null)
			{
				foreach (Materials materials in list)
				{
					if (materials.MaterialsName.IndexOf(textBox1.Text) != -1)
					{
						if (cb_Type.SelectedItem.Equals("모두") || cb_Type.SelectedItem.Equals(materials.MaterialsType))
							dgv_materials.Rows.Add(
							  materials.MaterialsNo,
							  materials.MaterialsType,
							  materials.MaterialsName,
							  materials.MaterialsStandard,
							  string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsCount)),
							  materials.Unit,
							  string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsPrice)),
							  string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsCount * materials.MaterialsPrice)),
							  materials.MaterialsMemo);
					}
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			//신규 자재 등록
			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			MaterialsInsert mi = new MaterialsInsert(_MaterialsCtrl, this);
			mi.ShowDialog();

			btn.BackColor = Color.FromArgb(48, 103, 162);
		}

		private void btn_Update_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			MaterialsUpdate mu = new MaterialsUpdate(_MaterialsCtrl, this);
			mu.ShowDialog();
			btn.BackColor = Color.FromArgb(48, 103, 162);
		}

		private void button4_Click(object sender, EventArgs e)
		{
			Button btn = (Button)sender;
			btn.BackColor = Color.FromArgb(255, 128, 0);

			MaterialsDefUnit md = new MaterialsDefUnit(_MaterialsCtrl, this);
			md.ShowDialog();

			btn.BackColor = Color.FromArgb(48, 103, 162);
		}
	}
}