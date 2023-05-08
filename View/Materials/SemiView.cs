using Model;
using Controller;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Linq;
using Model.Material;

namespace View
{
    public partial class SemiView : Form, IBasicForm
    {
        private Member _LoginInfo;
        private BasicForm _Mother;
        private ProcessC _ProcessC;
        private List<String[]> ViewList;
        private MaterialsCtrl _MaterialsCtrl;

        public SemiView(Member member, BasicForm form)
        {
            _Mother = form;
            _LoginInfo = member;
            _ProcessC = new ProcessC();

            InitializeComponent();
            ViewList = new List<string[]>();
            _MaterialsCtrl = new MaterialsCtrl();
            GetProductData();
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
                    dgv_product.Rows.Add(array[0], array[1], array[2], array[4], array[5], array[6]);
                }
        }
        #region 검색 조회 상단박스
        private void SetComboboxItemList()
        {
            /*            List<String> list2 = new List<string>();

                        cb_type.Items.Clear();

                        list2 = _ProcessC.SetProductTypeList();

                        foreach (string str in list2)
                        {
                            cb_type.Items.Add(str);
                        }*/
        }
        #endregion

        private void btn_Search_Click(object sender, EventArgs e)
        {
            dgv_materials.Rows.Clear();
            dgv_product.Rows.Clear();
            if (ViewList != null)
                foreach (string[] array in ViewList)
                {
                    if (array[1].ToString().IndexOf(cb_name.Text) != -1)
                        dgv_product.Rows.Add(array[0], array[1], array[2], array[3]);
                }
        }
        #region 검색 basicform
        public string GetText()
        {
            return this.Text;
        }

        public void RefreshForm()
        {
            ;
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
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(255, 128, 0);

            Semi_Materials sm = new Semi_Materials(_MaterialsCtrl, this);

            sm.ShowDialog();
            btn.BackColor = Color.FromArgb(48, 103, 162);
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.BackColor = Color.FromArgb(255, 128, 0);

            Semi_Product sp = new Semi_Product(_MaterialsCtrl, this);
            sp.ShowDialog();
            btn.BackColor = Color.FromArgb(48, 103, 162);
        }
        private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            dataGridView1.Rows.Clear();
            dgv_materials.Rows.Clear();
            DataGridView senderGrid = (DataGridView)sender;
            if (e.RowIndex != -1)
            {
                int _productNo = 0;
                _productNo = Int32.Parse(senderGrid.Rows[e.RowIndex].Cells[0].Value.ToString());

                List<MaterialsSemi> list2 = _MaterialsCtrl.GetProductList(_productNo);
                foreach (MaterialsSemi str in list2)
                {
                    string str2 = "";
                    foreach (string[] st in str.Materialssemivalue2) str2 = str2 + st[1];
                    dataGridView1.Rows.Add(str.Materialssemino, str.Materialsseminame, str.Materialssemicnt, str2);
                }
                List<string[]> list = _MaterialsCtrl.GetMaterialList(_productNo);
                foreach (string[] str in list)
                {
                    dgv_materials.Rows.Add(str[0], str[1], str[2], str[3]);
                }
            }
        }
    }
}
