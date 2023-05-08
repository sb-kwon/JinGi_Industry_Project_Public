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
    public partial class MaterialsInsert : Form
    {
        private MaterialsCtrl _MaterialsCtrl;
        private MaterialsForm _form1;
        private IOForm _form2;

        public MaterialsInsert(MaterialsCtrl materialsCtrl, MaterialsForm form)
        {
            InitializeComponent();

            _MaterialsCtrl = materialsCtrl;
            _form1 = form;
            SetView();
        }
        public MaterialsInsert(MaterialsCtrl materialsCtrl, IOForm form)
        {
            InitializeComponent();

            _MaterialsCtrl = materialsCtrl;
            _form2 = form;
            SetView();
        }

        private void btn_Update_Click(object sender, EventArgs e)
        {
            SetView();
        }

        public void SetView()
        {
            comboBox1.Items.Clear();
            //com1 타입
            if (_MaterialsCtrl.Types != null)
                foreach (string str in _MaterialsCtrl.Types)
                    comboBox1.Items.Add(str);

            if(comboBox1.Items.Count != 0)
                comboBox1.SelectedIndex = 0;


            comboBox2.Items.Clear();
            //com1 타입
            BaseC BaseC = new BaseC();
            List<string> list = BaseC.GetUnitList();
            foreach (string str in list)
                comboBox2.Items.Add(str);

            if (comboBox2.Items.Count != 0)
                comboBox2.SelectedIndex = 0;

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "0";
            textBox5.Text = "0";
        }
        private void textBox4_KeyPress(object sender, KeyPressEventArgs e)
        {
            //숫자만 입력되도록 필터링
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))    //숫자와 백스페이스를 제외한 나머지를 바로 처리
            {
                e.Handled = true;
            }
           if ((!(textBox4.Text.Equals(""))) && (!(textBox5.Text.Equals(""))))
            {
                long a = Convert.ToInt64(textBox4.Text);
                long b = Convert.ToInt64(textBox5.Text);

                textBox6.Text = (a * b).ToString();
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Materials mtr = new Materials();

            mtr.MaterialsName = textBox1.Text;
            if (!(textBox4.Text.Equals(""))) mtr.MaterialsCount = Convert.ToInt32(textBox4.Text);
            if (!(textBox5.Text.Equals(""))) mtr.MaterialsPrice = Convert.ToInt32(textBox5.Text);
            mtr.MaterialsStandard = textBox2.Text;
            mtr.MaterialsMemo = textBox3.Text;
            if (comboBox1.SelectedIndex > 0)
                mtr.MaterialsType = comboBox1.SelectedItem.ToString();
            else mtr.MaterialsType = "(미지정)";
            if (comboBox2.SelectedIndex > 0)
                mtr.Unit = comboBox2.SelectedItem.ToString();
            else mtr.Unit = "(미지정)";

            if (_MaterialsCtrl.FindMaterialName(mtr.MaterialsName))
            {
                //동일한 이름이 있으면
                if (MessageBox.Show("이미 " + mtr.MaterialsName + "명으로 자재가 존재 합니다. 동일한 이름으로 추가 하시겠습니까?",
                        "동일한 이름의 자재 추가", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //추가 시켜
                    _MaterialsCtrl.InsertMaterial(mtr, checkBox1.Checked);
                    //  if(checkBox1.Checked)
                    MessageBox.Show(mtr.MaterialsName + " 추가가 완료 되었습니다.");
                }
                else
                {
                    MessageBox.Show(mtr.MaterialsName + " 추가가 취소 되었습니다.");
                }
            }
            else
            {
                _MaterialsCtrl.InsertMaterial(mtr, checkBox1.Checked);
                MessageBox.Show(mtr.MaterialsName + " 추가가 완료 되었습니다.");
            }
            _MaterialsCtrl.SetMaterials();
            if (_form1 != null) _form1.SetView();
            if (_form2 != null) _form2.SetView();
        }
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox4.ReadOnly = textBox5.ReadOnly = false;
                textBox6.Text = textBox4.Text = textBox5.Text = "0";
            }
            else
            {
                textBox4.ReadOnly = textBox5.ReadOnly = true;
            }
        }
        private void btn_Exit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
