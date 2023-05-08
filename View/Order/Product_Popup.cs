using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;

namespace View
{
    public partial class Product_Popup : Form
    {
        private Point mousePoint;

        private ProductView pro;
        private bool? _Check;
        private ProcessC _ProcessC;

        string CustomerName;
        public Product_Popup(Product pro, bool? type)
        {
            _Check = type;
            _ProcessC = new ProcessC();
            _ProcessC.Product = pro;

            InitializeComponent();
            SetCombo();

            if (type == true)
                SetProductNo();
            else if (type == false)
            {
                btn_Apply.Text = "↺ 수 정";
                lbl_title.Text = "품목 수정";

                txt_no.Text = _ProcessC.Product.ProductNo.ToString();
                comboBox1.SelectedItem = _ProcessC.Product.Unit.ToString();
                txt_name.Text = _ProcessC.Product.ProductName.ToString();
                txt_price.Text = _ProcessC.Product.ProductPrice.ToString();
                textBox1.Text = _ProcessC.Product.BomDrawingNo.ToString();
                textBox2.Text = _ProcessC.Product.BomStandard.ToString();
                txt_memo.Text = _ProcessC.Product.ProductMemo.ToString();
            }

          
        }

        private void SetCombo()
        {
            List<String> strlist = _ProcessC.DefUnit();
            comboBox1.Items.Clear();
            foreach (string str in strlist)
            {
                comboBox1.Items.Add(str);
                comboBox1.SelectedIndex = 0;
            }
        }
        private void SetProductNo()
        {
            List<String> max = new List<string>();
            max = _ProcessC.MaxValue("ProductNo", "product");

            foreach (string value in max)
            {
                txt_no.Text = value;
            }
        }

        #region 검색 팝업 이동
        private void mousedown_MouseDown(object sender, MouseEventArgs e)
        {
            mousePoint = new Point(e.X, e.Y);
        }
        private void mousemove_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                int x = mousePoint.X - e.X;
                int y = mousePoint.Y - e.Y;
                Location = new Point(this.Left - x, this.Top - y);
            }
        }
        #endregion

        private void txt_price_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }

        private void txt_price_TextChanged(object sender, EventArgs e)
        {
            string lgsText;
            TextBox txtbox = (TextBox)sender;

            if (txtbox.Text != "")
            {
                lgsText = txtbox.Text.Replace(",", "");
                txtbox.Text = String.Format("{0:#,##0}", Convert.ToDouble(lgsText));
                txtbox.SelectionStart = txtbox.TextLength;
                txtbox.SelectionLength = 0;
            }
        }

        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Add_Click(object sender, EventArgs e)
        {
            if (txt_name.Text == "")
            {
                SetAlarm("품목명을 입력 해주세요.");
            }
            else if (txt_price.Text == "")
            {
                SetAlarm("품목 단가를 입력 해주세요.");
            }
            else
            {
                SaveText();

                if (_Check == true) //추가
                {
                    _ProcessC.AddProduct();
                    SetAlarm("품목 정보가 추가 되었습니다.");
                    this.Close();
                }
                else
                {
                    _ProcessC.UpdateProduct();
                    SetAlarm("품목 정보가 수정 되었습니다.");
                    this.Close();
                }
            }
        }

        private void SaveText()
        {
            _ProcessC.Product.ProductNo = Int32.Parse(txt_no.Text);
            _ProcessC.Product.Unit = comboBox1.Text;
            _ProcessC.Product.ProductName = txt_name.Text;
            _ProcessC.Product.ProductPrice = Int32.Parse(txt_price.Text.Replace(",", ""));
            _ProcessC.Product.BomDrawingNo = textBox1.Text;
            _ProcessC.Product.BomStandard = textBox2.Text;
            _ProcessC.Product.ProductMemo = txt_memo.Text;
        }

        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
    }
}
