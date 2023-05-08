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
    public partial class MaterialsRealsing : Form
    {
        private MaterialsCtrl _MaterialsCtrl;
        private IOForm _form;
        private Materials _materials;

        public MaterialsRealsing(MaterialsCtrl materialsCtrl, IOForm form)
        {
            InitializeComponent();

            _MaterialsCtrl = materialsCtrl;
            _form = form;

            SetView();

        }
        public void SetView()
        {
            _materials = null;
            textBox2.Text = "";

            cb_Search_Type.Items.Clear();

            //com1 타입
            //com2 위치
            cb_Search_Type.Items.Add("모두");
            if (_MaterialsCtrl.Types != null)
                foreach (string str in _MaterialsCtrl.Types)
                    cb_Search_Type.Items.Add(str);


            cb_Search_Type.SelectedIndex = 0;

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
                        string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsPrice)),
                        string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsCount * materials.MaterialsPrice)),
                        materials.MaterialsMemo);
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //update

            if (_materials is null) MessageBox.Show("선택된 자재가 없습니다.");
            else if (comboBox1.SelectedIndex == -1) MessageBox.Show("선택된 자재의 재고가 없습니다.");
            else
            {
                int cnt = 0;
                if (textBox5.Text.Length != 0) cnt = Convert.ToInt32(textBox5.Text);
                if (_MaterialsCtrl.WarehousingUseCheck(Convert.ToInt32(textBox2.Text), comboBox1.SelectedItem.ToString(), cnt))
                {
                    //출고 가능 확인 완료
                    _MaterialsCtrl.Realsing(Convert.ToInt32(textBox2.Text), comboBox1.SelectedItem.ToString(), cnt, textBox7.Text);

                    MessageBox.Show("출고가 완료 되었습니다.");
                    _MaterialsCtrl.SetMaterials();
                    _form.SetView();
                    SetView();
                }
                else
                {
                    MessageBox.Show(comboBox1.SelectedItem.ToString() + "위치의 " + textBox3.Text + "의 재고가 부족합니다.");
                }
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
                    if (materials.MaterialsName.IndexOf(textBox1.Text) != -1)
                    {
                        if ((cb_Search_Type.SelectedItem.Equals("모두") || cb_Search_Type.SelectedItem.Equals(materials.MaterialsType)))
                            dgv_materials.Rows.Add(
                              materials.MaterialsNo,
                              materials.MaterialsType,
                              materials.MaterialsName,
                              materials.MaterialsStandard,
                              string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsCount)),
                              string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsPrice)),
                              string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsCount * materials.MaterialsPrice)),
                              materials.MaterialsMemo);
                    }
                }
            }
        }
        private void dgv_materials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            Materials materials = new Materials();
            if (e.RowIndex != -1)
            {
                materials.MaterialsNo = Convert.ToInt32(dgv_materials.Rows[e.RowIndex].Cells[0].Value);
                materials.MaterialsType = dgv_materials.Rows[e.RowIndex].Cells[1].Value.ToString();
                materials.MaterialsName = dgv_materials.Rows[e.RowIndex].Cells[2].Value.ToString();
                materials.MaterialsStandard = dgv_materials.Rows[e.RowIndex].Cells[3].Value.ToString();
                if (!(dgv_materials.Rows[e.RowIndex].Cells[4].Value.Equals(""))) materials.MaterialsCount = Convert.ToInt32(dgv_materials.Rows[e.RowIndex].Cells[4].Value.ToString().Replace(",", ""));
                if (!(dgv_materials.Rows[e.RowIndex].Cells[5].Value.Equals(""))) materials.MaterialsPrice = Convert.ToInt32(dgv_materials.Rows[e.RowIndex].Cells[5].Value.ToString().Replace(",", ""));
                materials.MaterialsMemo = dgv_materials.Rows[e.RowIndex].Cells[7].Value.ToString();

                _materials = materials;

                SetSelectedMaterials();
            }
        }
        private void SetSelectedMaterials()
        {
            comboBox1.Items.Clear();
            dgv_materials_Location.Rows.Clear();
            List<string[]> list = _MaterialsCtrl.GetOrderByMaterialsLocation(_materials.MaterialsNo);
            if (_MaterialsCtrl.Locations != null)
                foreach (string str in _MaterialsCtrl.Locations)
                    comboBox1.Items.Add(str);
            if (list != null)
            {
                foreach (string[] str in list)
                {
                    dgv_materials_Location.Rows.Add(str[0], str[1]);
                    //comboBox1.Items.Add(str[0]);
                }
                if (list.Count != 0) comboBox1.SelectedIndex = 0;
            }
            textBox2.Text = _materials.MaterialsNo.ToString();
            textBox3.Text = _materials.MaterialsName;
            textBox5.Text = "";
            textBox7.Text = "";
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            SetView();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show(_materials.MaterialsName + "자재를 정말 삭제 하시겠습니까?",
                        "동일한 이름의 자재 추가", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                //추가 시켜
                _MaterialsCtrl.DeleteMaterial(_materials.MaterialsNo);
                MessageBox.Show(_materials.MaterialsName + " 삭제가 완료 되었습니다.");
                _MaterialsCtrl.SetMaterials();
                _form.SetView();
                SetView();
            }
            else
            {
                MessageBox.Show(_materials.MaterialsName + " 삭제가 취소 되었습니다.");
            }
        }
        private void textBox5_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
        }
    }
}
