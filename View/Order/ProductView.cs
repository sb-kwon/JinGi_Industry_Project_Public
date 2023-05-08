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
    public partial class ProductView : Form, IBasicForm
    {
        #region 검색 gridviewUI
        private void SetDataGridView(DataGridView dgv)
        {
            //진행중인 수주
            dgv_product.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_product.Columns[0].Width = 150;
            dgv_product.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_product.Columns[1].Width = 250;
            dgv_product.Columns[2].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_product.Columns[2].Width = 150;

            dgv.Font = new Font("맑은 고딕", 11, FontStyle.Regular);


            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 72, 81);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.SeaGreen;

            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.CurrentCell = null;

            dgv.BackgroundColor = SystemColors.GradientInactiveCaption;

            dgv.ReadOnly = true;
            dgv.RowHeadersVisible = false;
            dgv.MultiSelect = false;
            dgv.Columns.Cast<DataGridViewColumn>().ToList().ForEach(f =>
            {
                f.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleLeft;
                f.HeaderCell.Style.Font = new Font("Arial", 12F, FontStyle.Bold, GraphicsUnit.Pixel);
            });
            dgv.Rows.Cast<DataGridViewRow>().Where((x, i) => i % 2 != 0).ToList().ForEach(r => r.DefaultCellStyle.BackColor = Color.AliceBlue);
            dgv.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv.AlternatingRowsDefaultCellStyle.BackColor = Color.AliceBlue;
            dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
        }
        #endregion

        #region 검색 basicform
        public string GetText()
        {
            return this.Text;
        }

        public void RefreshForm()
        {
            GetProductData();
            Reset();
        }

        public Form SetForm()
        {
            return this;
        }

        public void SetInterval(string seletedPageName, bool check)
        {
            ;
        }

        #endregion

        private Member _LoginInfo;
        private BasicForm _Mother;

        private ProcessC _ProcessC;

        private List<String[]> ViewList;
        private string SearchText, SearchName;

        public ProductView(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;

            _ProcessC = new ProcessC();
            ViewList = new List<string[]>();

            InitializeComponent();

            SetFormView();
        }
        private void SetFormView()
        {
            //SetDataGridView(dgv_product);
            GetProductData();
            SetCombo();
        }
        private void SetCombo()
        {
            List<String> strlist = _ProcessC.DefUnit();
            comboBox1.Items.Clear();
            comboBox1.Items.Add("모두");
            foreach (string str in strlist)
            {
                comboBox1.Items.Add(str);
                comboBox1.SelectedIndex = 0;
            }
        }
        private void GetProductData()
        {
            ViewList = _ProcessC.GetProductData();
            SetProductListView();
        }
        private void SetProductListView()
        {
            dgv_product.Rows.Clear();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    dgv_product.Rows.Add(array[0], array[1], String.Format("{0,0:N0}", Convert.ToInt32(array[2])), array[3], array[4], array[5], array[6]);
                }
        }
        private void cb_no_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            if (combo.Text != "")
            {
                SearchText = combo.Text.ToString();
                SearchName = combo.Name.ToString();
                ComboBox_Changed();
            }
        }
        private void cb_name_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox combo = (ComboBox)sender;

            if (combo.Text != "")
            {
                SearchText = combo.Text.ToString();
                SearchName = combo.Name.ToString();
                ComboBox_Changed();
            }
        }
        private void ComboBox_Changed()
        {
            foreach (Control p in panel3.Controls)
            {
                if (p.GetType().Name.Equals("ComboBox"))
                {
                    ComboBox com = p as ComboBox;
                    if (!(com.Name.Equals(SearchName)))
                    {
                        com.SelectedIndex = -1;
                    }
                }
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            dgv_product.Rows.Clear();
            ViewList = _ProcessC.GetProductData();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    if ((array[1].IndexOf(textBox2.Text, StringComparison.OrdinalIgnoreCase) != -1)
                        && (comboBox1.SelectedItem.Equals("모두") || comboBox1.SelectedItem.Equals(array[3]))
                        && (array[5].IndexOf(textBox3.Text, StringComparison.OrdinalIgnoreCase) != -1)
                        && (array[6].IndexOf(textBox4.Text, StringComparison.OrdinalIgnoreCase) != -1))
                    {
                        dgv_product.Rows.Add(array[0], array[1], String.Format("{0,0:N0}", Convert.ToInt32(array[2])), array[3], array[4], array[5], array[6]);
                    }
                }

        }
        private void Reset()
        {
            comboBox1.SelectedIndex = 0;
            textBox2.Text = string.Empty;
            textBox3.Text = string.Empty;
            textBox4.Text = string.Empty;
        }
        private void btn_Add_Click(object sender, EventArgs e)
        {
            Product_Popup popup = new Product_Popup(_ProcessC.Product, true);
            popup.StartPosition = FormStartPosition.CenterParent;
            popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            popup.ShowDialog();

            GetProductData();
        }
        private void btn_Update_Click(object sender, EventArgs e)
        {
            if (_ProcessC.Product.ProductNo.ToString() is null)
                SetAlarm("수주를 선택 해주세요.");
            else
            {
                Product_Popup popup = new Product_Popup(_ProcessC.Product, false);
                popup.StartPosition = FormStartPosition.CenterParent;
                popup.Location = new Point(this.Location.X + this.Width, this.Location.Y);
                popup.ShowDialog();

                GetProductData();
            }
        }
        private void btn_Delete_Click(object sender, EventArgs e)
        {
            if (_ProcessC.Product.ProductNo.ToString() == "0")
                SetAlarm("수주를 선택 해주세요.");
            else
            {
                if (MessageBox.Show("품목번호 : " + _ProcessC.Product.ProductNo + "번 품목을 삭제 하겠습니까?", "품목 삭제", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    _ProcessC.DeleteProduct();
                    SetAlarm("품목번호 " + _ProcessC.Product.ProductNo.ToString() + "가 삭제 되었습니다.");

                    GetProductData();
                }
            }
        }
        private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                DataGridView dgv = (DataGridView)sender;
                SetSelectedData(dgv.SelectedRows[0]);
            }
        }
        private void SetSelectedData(DataGridViewRow dgvr)
        {
            Product _pro = new Product();

            _pro.ProductNo = Convert.ToInt32(dgvr.Cells[0].Value);
            _pro.ProductName = dgvr.Cells[1].Value.ToString();
            _pro.ProductPrice = Convert.ToInt32(dgvr.Cells[2].Value.ToString().Replace(",", ""));
            _pro.Unit = dgvr.Cells[3].Value.ToString();
            _pro.BomStandard = dgvr.Cells[4].Value.ToString();
            _pro.BomDrawingNo = dgvr.Cells[5].Value.ToString();
            _pro.ProductMemo = dgvr.Cells[6].Value.ToString();

            _ProcessC.Product = _pro;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            int no = _ProcessC.Product.ProductNo;
            if (no.Equals(null))
                SetAlarm("수주를 선택 해주세요.");
            else
            {
                UseMaterials UseMaterials = new UseMaterials(no, false);
                UseMaterials.ShowDialog();
            }
        }
		private void btn_New_Click(object sender, EventArgs e)
		{
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelProduct ea = new ExcelProduct(folderBrowserDialog1.SelectedPath);
                string str = ea.CreatExcelFile();

                if (str.Length != 0) MessageBox.Show(str);
            }
        }
		private void btn_Call_Click(object sender, EventArgs e)
		{
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string str = openFileDialog1.FileName;      //파일 경로

                string[] arr = str.Split('.');

                if (arr[1].Equals("xlsx") || arr[1].Equals("xls"))
                {
                    ExcelProduct ea = new ExcelProduct("", str);

                    List<string[]> rtnList = ea.ReadExcel();

                    _ProcessC.InsertExcelProduct(rtnList);
                }
                else
                {
                    MessageBox.Show("EXCEL 형식이 아닙니다.");
                }
            }
            GetProductData();
        }
		private void btn_Save_Click(object sender, EventArgs e)
		{
            if (folderBrowserDialog1.ShowDialog() == DialogResult.OK)
            {
                ExcelProduct ea = new ExcelProduct(folderBrowserDialog1.SelectedPath);

                List<string[]> list = new List<string[]>();

                foreach (DataGridViewRow dgvr in dgv_product.Rows)
                {
                    string[] strArr = new string[6];
                    strArr[0] = dgvr.Cells[1].Value.ToString();
                    strArr[1] = dgvr.Cells[2].Value.ToString();
                    strArr[2] = dgvr.Cells[3].Value.ToString();
                    strArr[3] = dgvr.Cells[4].Value.ToString();
                    strArr[4] = dgvr.Cells[5].Value.ToString();
                    strArr[5] = dgvr.Cells[6].Value.ToString();

                    list.Add(strArr);
                }
                string str = ea.SaveExcelFile(list);

                if (str.Length != 0) MessageBox.Show(str);
            }
            GetProductData();
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