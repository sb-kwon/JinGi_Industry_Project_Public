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
    public partial class ActionMove : Form
    {
        private MaterialsCtrl _MaterialsCtrl;
        private IOForm _form;
        private Materials _materials;

        public ActionMove(MaterialsCtrl materialsCtrl, IOForm form)
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
            textBox2.Text = "";
            textBox3.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
            textBox8.Text = "";
            tb_Search.Text = "";

            cb_Search_Type.Items.Clear();
            cb_Search_Location.Items.Clear();
            comboBox1.Items.Clear();
            cb_Search_Type.Items.Add("모두");
            cb_Search_Location.Items.Add("모두");
            comboBox1.Items.Add("(미지정)");
            if (_MaterialsCtrl.Types != null)
                foreach (string str in _MaterialsCtrl.Types)
                {
                    cb_Search_Type.Items.Add(str);
                }
            if (_MaterialsCtrl.Locations != null)
                foreach (string str in _MaterialsCtrl.Locations)
                {
                    cb_Search_Location.Items.Add(str);
                    comboBox1.Items.Add(str);
                }
            cb_Search_Type.SelectedIndex = 0;
            cb_Search_Location.SelectedIndex = 0;
            comboBox1.SelectedIndex = 0;

            dgv_materials.Rows.Clear();
            List<string[]> list = _MaterialsCtrl.Material_Action_Location();
            if (list != null)
                foreach (string[] array in list)
                {
                    if (!(array[5].Equals(""))) array[5] = String.Format("{0:#,###}", Convert.ToInt32(array[5]));
                    if (!(array[6].Equals(""))) array[6] = String.Format("{0:#,###}", Convert.ToInt32(array[6]));
                    if (!(array[7].Equals(""))) array[7] = String.Format("{0:#,###}", Convert.ToInt32(array[7]));
                    dgv_materials.Rows.Add(
                        array[0],
                        array[1],
                        array[2],
                        array[3],
                        array[4],
                        array[5],
                        array[6],
                        array[7]
                        );
                }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            //update

            if (textBox1.Text.Length == 0) MessageBox.Show("선택된 자재가 없습니다.");
            else if (Convert.ToInt32(textBox7.Text) < Convert.ToInt32(textBox8.Text)) MessageBox.Show("옮길 수량이 너무 많습니다.");
            else if (comboBox1.SelectedItem.ToString().Equals(textBox6.Text)) MessageBox.Show("동일한 위치로 이동 불가!");
            else
            {
                //옮길 자재 번호, 시작위치, 도착위치, 옮길 수량
                _MaterialsCtrl.SiteMove(textBox1.Text, textBox6.Text, comboBox1.SelectedItem.ToString(), Convert.ToInt32(textBox8.Text));

                MessageBox.Show("이동이 완료 되었습니다.");
                _MaterialsCtrl.SetMaterials();
                _form.SetView();
                SetView();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dgv_materials.Rows.Clear();
            List<string[]> list = _MaterialsCtrl.Material_Action_Location();
            if (list != null)

                foreach (string[] array in list)
                    if ((cb_Search_Type.SelectedItem.Equals("모두") || cb_Search_Type.SelectedItem.Equals(array[1]))
                        && (cb_Search_Location.SelectedItem.Equals("모두") || cb_Search_Location.SelectedItem.Equals(array[4]))
                        && array[2].IndexOf(tb_Search.Text) != -1)
                        dgv_materials.Rows.Add(array[0],
                        array[1],
                        array[2],
                        array[3],
                        array[4],
                        string.Format("{0:#,###}", Convert.ToInt32(array[5])),
                        string.Format("{0:#,###}", Convert.ToInt32(array[6])),
                        string.Format("{0:#,###}", Convert.ToInt32(array[7]))
                                                );
        }

        private void dgv_materials_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {

                textBox1.Text = dgv_materials.Rows[e.RowIndex].Cells[0].Value.ToString();
                textBox2.Text = dgv_materials.Rows[e.RowIndex].Cells[2].Value.ToString();
                textBox3.Text = dgv_materials.Rows[e.RowIndex].Cells[6].Value.ToString().Replace(",", "");

                SetSelectedMaterialsMove(e);
            }
        }
        private void SetSelectedMaterialsMove(DataGridViewCellEventArgs e)
        {
            if (dgv_materials.Rows[e.RowIndex].Cells[4].Value.ToString().Length == 0) textBox6.Text = "(미지정)";
            else textBox6.Text = dgv_materials.Rows[e.RowIndex].Cells[4].Value.ToString();

            textBox7.Text = dgv_materials.Rows[e.RowIndex].Cells[5].Value.ToString().Replace(",", "");
            //수량 가져오기

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

        private void Action_Move_Load(object sender, EventArgs e)
        {

        }
    }
}
