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
    public partial class MaterialsUpdate : Form
    {
        private MaterialsCtrl _MaterialsCtrl;
        private MaterialsForm _form;
        private Materials _materials;

        public MaterialsUpdate(MaterialsCtrl materialsCtrl, MaterialsForm form)
        {
            InitializeComponent();

            _MaterialsCtrl = materialsCtrl;
            _form = form;

            SetView();

        }
        public void SetView()
        {
            _materials = null;
            textBox1.Text = "";

            cb_Search_Type.Items.Clear();
            comboBox1.Items.Clear();
            cb_Search_Type.Items.Add("모두");
            if (_MaterialsCtrl.Types != null)
                foreach (string str in _MaterialsCtrl.Types)
                {
                    cb_Search_Type.Items.Add(str);
                    comboBox1.Items.Add(str);
                }
            cb_Search_Type.SelectedIndex = 0;

            comboBox2.Items.Clear();
            //com1 타입
            BaseC BaseC = new BaseC();
            List<string> Units = BaseC.GetUnitList();
            foreach (string str in Units)
                comboBox2.Items.Add(str);

            if (comboBox2.Items.Count != 0)
                comboBox2.SelectedIndex = 0;


            dgv_materials.Rows.Clear();
            List<Materials> list = _MaterialsCtrl.Materials;
            if (list != null)
                foreach (Materials materials in list)
                {
                    string type = "";
                    if (materials.MaterialsType is null) type = "(미지정)";
                    else type = materials.MaterialsType;

                    dgv_materials.Rows.Add(
                       materials.MaterialsNo,
                       type,
                       materials.MaterialsName,
                       materials.MaterialsStandard,
                       string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsCount)),
                       materials.Unit,
                       string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsPrice)),
                       string.Format("{0:#,###}", Convert.ToInt32(materials.MaterialsCount * materials.MaterialsPrice)),
                       materials.MaterialsMemo);
                }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //update

            if (_materials is null) MessageBox.Show("선택된 자재가 없습니다.");
            else
            {
                Materials materials = new Materials();

                materials = _materials;

                materials.MaterialsName = textBox1.Text;
                materials.MaterialsStandard = textBox3.Text;
                materials.MaterialsMemo = textBox2.Text;
                if (comboBox1.SelectedItem.Equals("")) materials.MaterialsType = null;
                else materials.MaterialsType = comboBox1.SelectedItem.ToString();
                if (comboBox2.SelectedItem.Equals("")) materials.MaterialsType = null;
                else materials.Unit = comboBox2.SelectedItem.ToString();


                _MaterialsCtrl.UpdateMaterials(materials);

                MessageBox.Show("수정이 완료 되었습니다.");
                _MaterialsCtrl.SetMaterials();
                _form.SetView();
                SetView();
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
                            string type = "";
                            if (materials.MaterialsType is null) type = "(미지정)";
                            else type = materials.MaterialsType;

                            dgv_materials.Rows.Add(
                               materials.MaterialsNo,
                               type,
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
                if (dgv_materials.Rows[e.RowIndex].Cells[4].Value.ToString().Equals("")) materials.MaterialsCount = 0;
                else materials.MaterialsCount = Convert.ToInt32(dgv_materials.Rows[e.RowIndex].Cells[4].Value.ToString().Replace(",",""));
                materials.Unit = dgv_materials.Rows[e.RowIndex].Cells[5].Value.ToString();
                if (dgv_materials.Rows[e.RowIndex].Cells[6].Value.ToString().Equals("")) materials.MaterialsPrice = 0;
                else materials.MaterialsPrice = Convert.ToInt32(dgv_materials.Rows[e.RowIndex].Cells[6].Value.ToString().Replace(",",""));
                materials.MaterialsMemo = dgv_materials.Rows[e.RowIndex].Cells[8].Value.ToString();

                _materials = materials;

                SetSelectedMaterials();
            }


        }
        private void SetSelectedMaterials()
        {
            textBox0.Text = _materials.MaterialsNo.ToString();
            textBox1.Text = _materials.MaterialsName;
            textBox5.Text = String.Format("{0:#,###}", Convert.ToInt32(_materials.MaterialsCount.ToString()));
            textBox3.Text = _materials.MaterialsStandard;
            textBox2.Text = _materials.MaterialsMemo;

            comboBox1.SelectedItem = _materials.MaterialsType;
            comboBox2.SelectedItem = _materials.Unit;
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
    }
}
