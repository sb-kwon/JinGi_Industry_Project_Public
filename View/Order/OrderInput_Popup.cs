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
    public partial class OrderInput_Popup : Form
    {
        #region 검색 gridviewUI
        private void SetDataGridView(DataGridView dgv)
        {
            dgv_product.Columns[0].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_product.Columns[0].Width = 40;
            dgv_product.Columns[1].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_product.Columns[1].Width = 40;
            dgv_product.Columns[7].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            dgv_product.Columns[7].Width = 200;

            dgv.Font = new Font("맑은 고딕", 11, FontStyle.Regular);


            dgv.EnableHeadersVisualStyles = false;
            dgv.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(59, 72, 81);
            dgv.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            dgv.RowHeadersDefaultCellStyle.BackColor = Color.SeaGreen;

            dgv.RowHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;
            dgv.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.Single;

            dgv.CurrentCell = null;

            dgv.BackgroundColor = SystemColors.GradientInactiveCaption;

            dgv_product.ReadOnly = true;
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
        private string msg;
        private string _Type;
        private int MinusCnt;
        string CustomerName;
        private Point mousePoint;
        private string barcodenum;
        private ProcessC _ProcessC;
        private List<String[]> ViewList;
        public OrderInput_Popup(ProcessC processC, string type)
        {
            InitializeComponent();

            _Type = type;
            _ProcessC = processC;

            //SetDataGridView(dgv_product);
            //SetDataGridView(dgv_bom);

            GetProductData();
            SetComboboxItemList();

            dtp_start.Value = DateTime.Now;
            dtp_end.Value = DateTime.Now;

            // 1 추가 2 수정 3 bom추가
            if (_Type == "2")
                SetFormView_Modify();
            else if (_Type == "3")
                SetFormView_BOM();
        }
        #region 검색 수주 수정
        private void SetFormView_Modify()
        {
            panel15.BringToFront();
            button2.Visible = true;
            cb_customer.Enabled = true;
            label_Emergency.Enabled = false;

            label3.Text = "※ 수주 수정";
            btn_order_save.Text = "수주 정보 수정";

            txt_no.Text = _ProcessC.WorkOrder.OrderNo.ToString();
            txt_name.Text = _ProcessC.WorkOrder.OrderName.ToString();
            tb_Emergency.Text = _ProcessC.WorkOrder.OrderEmergency.ToString();

            cb_customer.Text = _ProcessC.WorkOrder.CustomerName.ToString();
            cb_customer_member.Text = _ProcessC.WorkOrder.CustomerMemberName.ToString();

            dtp_start.Text = _ProcessC.WorkOrder.OrderDate.ToString();
            dtp_end.Text = _ProcessC.WorkOrder.OrderDateEnd.ToString();
            txt_memo.Text = _ProcessC.WorkOrder.OrderMemo.ToString();

            tb_OrderPrice.Text = String.Format("{0:#,###}", _ProcessC.WorkOrder.OrderPrice);
        }
        #endregion
        #region 검색 BOM 추가
        private void SetFormView_BOM()
        {
            button2.Visible = false;
            btn_order_save.Visible = false;
            txt_name.Enabled = false;
            cb_customer.Enabled = false;
            cb_customer_member.Enabled = false;
            dtp_start.Enabled = false;
            dtp_end.Enabled = false;
            txt_memo.Enabled = false;
            label_Emergency.Enabled = false;

            label3.Text = "※ BOM 추가";
            btn_order_save.Text = "BOM 추가";

            txt_no.Text = _ProcessC.WorkOrder.OrderNo.ToString();
            txt_name.Text = _ProcessC.WorkOrder.OrderName.ToString();
            tb_Emergency.Text = _ProcessC.WorkOrder.OrderEmergency;

            cb_customer.Text = _ProcessC.WorkOrder.CustomerName.ToString();
            cb_customer_member.Text = _ProcessC.WorkOrder.CustomerMemberName.ToString();

            dtp_start.Text = _ProcessC.WorkOrder.OrderDate.ToString();
            dtp_end.Text = _ProcessC.WorkOrder.OrderDateEnd.ToString();
            txt_memo.Text = _ProcessC.WorkOrder.OrderMemo.ToString();
            tb_OrderPrice.Text = String.Format("{0:#,###}", _ProcessC.WorkOrder.OrderPrice);
            GetBOMData();
        }
        private void GetBOMData()
        {
            dgv_bom.Rows.Clear();
            int cnt = 0;
            string[] str = { "2", "4", "5" };
            List<string[]> list = _ProcessC.GetBOMList();
            if (list != null)
                foreach (string[] array in list)
                {
                    if (array[0].Equals("")) MinusCnt = list.Count - 1;
                    else MinusCnt = list.Count;
                    if (array[0].ToString() != "")
                    {
                        dgv_bom.Rows.Add(array[0], array[1], null, string.Format("{0:#,###}", Convert.ToInt32(array[3])), null, null, array[6], array[7], array[8], array[9], array[10], array[11]);
                        for (int j = 0; j < 12; j++)
                            dgv_bom.Rows[cnt].Cells[j].Style.BackColor = Color.LightGray;

                        for (int i = 0; i < 3; i++)
                        {
                            DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)dgv_bom.Rows[cnt].Cells[Convert.ToInt32(str[i])];
                            combo.Items.Clear();
                            combo.Items.Add(array[Convert.ToInt32(str[i])]);
                            combo.ReadOnly = true;
                            combo.Value = combo.Items[0];
                        }
                        cnt++;
                    }
                }
        }
        #endregion
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
                    dgv_product.Rows.Add(false, array[0], array[1], string.Format("{0:#,###}", Convert.ToInt32(array[2])), array[3], array[4], array[5], array[6]);
                }
        }
        #region 검색 콤보박스
        private void SetComboboxItemList()
        {
            //수주번호
            List<String> max = new List<string>();
            max = _ProcessC.MaxValue("OrderNo", "work_order");

            foreach (string value in max)
            {
                txt_no.Text = value;
            }

            cb_customer.Items.Clear();

            List<String[]> list = new List<string[]>();
            list = _ProcessC.SetCustomerList();

            if (!(list is null))
            {
                foreach (string[] str in list)
                {
                    ComboboxItem cbi = new ComboboxItem();
                    cbi.Text = str[0]; //이름
                    cbi.Value = str[1]; //번호
                    cb_customer.Items.Add(cbi);

                    cb_customer.SelectedIndex = 0;
                }
            }
            list.Clear();
            //조회

            List<String[]> list3 = new List<string[]>();
            list3 = _ProcessC.GetProductData();

            if (!(list3 is null))
            {
                foreach (string[] str in list3)
                {
                    //cb_no.Items.Add(str[0]);
                    //cb_name.Items.Add(str[1]);
                }
                list3.Clear();
            }
        }
        private void cb_customer_TextChanged(object sender, EventArgs e)
        {
            foreach (ComboboxItem ci in cb_customer.Items)
            {
                if (ci.Text.Equals(cb_customer.Text))
                {
                    CustomerName = (ci as ComboboxItem).Value.ToString();
                }
            }
            cb_customer_member.Items.Clear();

            List<String[]> list = new List<string[]>();
            list = _ProcessC.SetCustomerMemberList(CustomerName);

            if (!(list is null))
            {
                foreach (string[] str in list)
                {
                    ComboboxItem cbi = new ComboboxItem();
                    cbi.Text = str[0]; //이름
                    cbi.Value = str[1]; //번호

                    cb_customer_member.Items.Add(cbi);
                    cb_customer_member.SelectedIndex = 0;
                }
            }
            list.Clear();
        }
        #endregion
        #region 검색 버튼
        private void SaveText()
        {
            WorkOrder wo = new WorkOrder();

            foreach (ComboboxItem ci in cb_customer.Items)
            {
                if (ci.Text.Equals(cb_customer.Text))
                {
                    wo.CustomerNo = Convert.ToInt32((ci as ComboboxItem).Value);
                }
            }
            foreach (ComboboxItem ci in cb_customer_member.Items)
            {
                if (ci.Text.Equals(cb_customer_member.Text))
                {
                    wo.CustomerMemberNo = Convert.ToInt32((ci as ComboboxItem).Value);
                }
            }
            wo.OrderNo = Int32.Parse(txt_no.Text);
            wo.OrderName = txt_name.Text;
            wo.OrderDate = dtp_start.Value.ToString("yyyy-MM-dd");
            wo.OrderDateEnd = dtp_end.Value.ToString("yyyy-MM-dd");
            wo.OrderMemo = txt_memo.Text;
            wo.OrderEmergency = tb_Emergency.Text;

            if (tb_OrderPrice.Text.Length == 0) wo.OrderPrice = 0;
            else wo.OrderPrice = Convert.ToInt64(tb_OrderPrice.Text.Replace(",",""));

            _ProcessC.WorkOrder = wo;
        }
        private void btn_order_save_Click(object sender, EventArgs e)
        {
            if (_Type == "1")
            {
                if (_ProcessC.NumberCheck("OrderNo", "work_order", txt_no.Text))
                    SetAlarm("이미 등록된 수주 입니다.");
                else if (txt_name.Text == "")
                    SetAlarm("수주명을 입력 해주세요.");
                else if (cb_customer.Text == "")
                    SetAlarm("거래처를 선택 해주세요.");
                else if (dtp_start.Value.Date > dtp_end.Value.Date)
                    SetAlarm("날짜를 다시 확인 해주세요.");
                else
                {
                    SaveText();

                    _ProcessC.InsertOrderSave();

                    SetAlarm("수주 정보가 등록 되었습니다.");
                    btn_order_save.Text = "수주 등록 완료";
                    btn_order_save.BackColor = Color.White;
                    btn_order_save.ForeColor = Color.Black;
                    btn_bom_save.BackColor = Color.FromArgb(255, 128, 0);
                    btn_bom_save.ForeColor = Color.White;
                }
            }
            else if (_Type == "2")
            {
                WorkOrder wo = new WorkOrder();

                wo.OrderNo = Convert.ToInt32(txt_no.Text);
                wo.OrderName = txt_name.Text;
                wo.CustomerName = cb_customer.Text;
                wo.CustomerMemberName = cb_customer_member.Text;
                wo.OrderDateEnd = Convert.ToDateTime(dtp_end.Text).ToString("yyyy-MM-dd");
                wo.OrderDate = Convert.ToDateTime(dtp_start.Text).ToString("yyyy-MM-dd");
                wo.OrderMemo = txt_memo.Text;
                wo.OrderEmergency = tb_Emergency.Text;
                if (tb_OrderPrice.Text.Length == 0) wo.OrderPrice = 0;
                else wo.OrderPrice = Convert.ToInt64(tb_OrderPrice.Text.Replace(",", ""));

                _ProcessC.UpdateOrder(wo);

                SetAlarm("수주 정보가 수정 되었습니다.");

                this.Close();
            }
        }
        private void btn_close_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btn_Reset_Click(object sender, EventArgs e)
        {
            dgv_bom.Rows.Clear();
            GetBOMData();
        }
        private void btn_product_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgv_product.Rows)
            {
                if (row.Cells[0].Value.Equals(true))
                {
                    dgv_bom.Rows.Add(row.Cells[1].Value, row.Cells[2].Value, null, row.Cells[3].Value, null, null, "", row.Cells[6].Value, row.Cells[5].Value, "1", row.Cells[4].Value, row.Cells[7].Value);
                }
            }
            List<String> strlist = _ProcessC.DefProductType();
            List<String> strlist2 = _ProcessC.DefUnit();
            List<String[]> strlist3 = _ProcessC.SetCustomerList();
            foreach (DataGridViewRow row in dgv_bom.Rows)
            {
                //품목타입
                DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)row.Cells[2];
                combo.Items.Clear();
                foreach (string str in strlist)
                {
                    combo.Items.Add(str);
                    combo.Selected = true;
                }
                //국내외구분
                DataGridViewComboBoxCell combo2 = (DataGridViewComboBoxCell)row.Cells[5];
                combo2.Items.Clear();
                combo2.Items.AddRange("국내", "국외");
                combo2.Selected = true;
                //거래처
                DataGridViewComboBoxCell combo4 = (DataGridViewComboBoxCell)row.Cells[4];
                combo4.Items.Clear();
                foreach (string[] str in strlist3)
                {
                    combo4.Items.Add(str[0].ToString());
                    combo4.Selected = true;
                }
                combo.Value = combo.Items[1];
                combo2.Value = combo2.Items[0];
                combo4.Value = cb_customer.Text;
            }
        }
        private void btn_bom_save_Click(object sender, EventArgs e)
        {
            if (!(_ProcessC.NumberCheck("OrderNo", "work_order", txt_no.Text)))
                SetAlarm("수주를 먼저 등록 해주세요.");
            else if(dgv_bom.Rows.Count == 0)
                SetAlarm("품목정보를 불러 와주세요.");
            else if (TypeNullCheck())
                SetAlarm(msg + "을(를) 설정 해주세요.");
            else
            {
                SaveText();
                DgvBOMSave();
                SetAlarm("수주명 : " + txt_name.Text + "의 BOM이 저장 되었습니다.");

                dgv_bom.Rows.Clear();
                GetBOMData();
            }
        }
        private bool TypeNullCheck()
        {
            bool check = false;
            foreach (DataGridViewRow row in dgv_bom.Rows)
            {
                DataGridViewComboBoxCell combo = (DataGridViewComboBoxCell)row.Cells[2];
                if (row.Cells[2].Value == null)
                {
                    check = true;
                    msg = "품목타입";
                    break;
                }
                else if (row.Cells[4].Value == null)
                {
                    check = true;
                    msg = "거래처";
                    break;
                }
                else if (row.Cells[5].Value == null)
                {
                    check = true;
                    msg = "국내외구분";
                    break;
                }
                else if (row.Cells[10].Value == null)
                {
                    check = true;
                    msg = "단위";
                    break;
                }
            }
            return check;
        }
        private void DgvBOMSave()
        {
            for (int j = MinusCnt; j < dgv_bom.Rows.Count; j++)
            {
                for (int i = 1; i <= Int32.Parse(dgv_bom.Rows[j].Cells[9].Value.ToString()); i++)
                {
                    List<string> Bomlist = new List<string>();
                    Bomlist.Add(dgv_bom.Rows[j].Cells[0].Value.ToString());
                    Bomlist.Add(dgv_bom.Rows[j].Cells[1].Value.ToString());
                    Bomlist.Add(dgv_bom.Rows[j].Cells[2].Value.ToString());
                    Bomlist.Add(dgv_bom.Rows[j].Cells[3].Value.ToString());
                    Bomlist.Add(dgv_bom.Rows[j].Cells[4].Value.ToString());
                    Bomlist.Add(dgv_bom.Rows[j].Cells[5].Value.ToString());
                    Bomlist.Add(dgv_bom.Rows[j].Cells[6].Value.ToString());
                    Bomlist.Add(dgv_bom.Rows[j].Cells[7].Value.ToString());
                    Bomlist.Add(dgv_bom.Rows[j].Cells[8].Value.ToString());
                    Bomlist.Add(dgv_bom.Rows[j].Cells[9].Value.ToString());
                    Bomlist.Add(dgv_bom.Rows[j].Cells[10].Value.ToString());
                    Bomlist.Add(dgv_bom.Rows[j].Cells[11].Value.ToString());

                    _ProcessC.Product.ProductNo = Int32.Parse(dgv_bom.Rows[j].Cells[0].Value.ToString());
                    if (dgv_bom.Rows[j].Cells[2].Value.ToString().Equals("외주 제작"))
                        barcodenum = "1";
                    else
                        barcodenum = "2";
                    barcodenum += DateTime.Now.ToString("yyMM"); //년 월
                    barcodenum += _ProcessC.WorkOrder.OrderNo.ToString("D3"); //수주번호
                    //barcodenum += _ProcessC.Product.ProductNo.ToString("D3"); //품목번호
                    //barcodenum += i.ToString("D2"); //작업지시서 번호 (개수) //최대 99
                    //
                    //while (_ProcessC.NumberCheck("WorkInstructionNo", "bom", barcodenum)) //작업지시서 번호 확인
                    //{
                    //    Int64 bar = Int64.Parse(barcodenum) + 1;
                    //    barcodenum = bar.ToString();
                    //}

                    Bomlist.Add(barcodenum);

                    _ProcessC.InsertBomSave(Bomlist); //BOM 추가
                    _ProcessC.InsertBarcodeNumber(barcodenum); //작업지시서(바코드번호) 생성
                }
            }
        }
        #endregion
        public void SetAlarm(String contnent)
        {
            Alarm alarm = new Alarm(contnent);
            alarm.StartPosition = FormStartPosition.CenterParent;
            alarm.Location = new Point(this.Location.X + this.Width, this.Location.Y);
            alarm.ShowDialog();
        }
        private void dgv_product_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex != -1)
            {
                if (dgv_product.Rows[e.RowIndex].Cells[0].Value.ToString() == "False")
                    dgv_product.Rows[e.RowIndex].Cells[0].Value = true;
                else
                    dgv_product.Rows[e.RowIndex].Cells[0].Value = false;
            }
        }
        private void btn_Search_Click_1(object sender, EventArgs e)
        {
            dgv_product.Rows.Clear();

            List<string[]> ViewList = _ProcessC.GetProductData();
            if (ViewList != null)
                foreach (string[] str in ViewList)
                {
                    if ((str[1].IndexOf(textBox1.Text, StringComparison.OrdinalIgnoreCase) != -1)
                        && (str[4].IndexOf(tb_SelectData.Text, StringComparison.OrdinalIgnoreCase) != -1)
                        && (str[6].IndexOf(textBox2.Text, StringComparison.OrdinalIgnoreCase) != -1))
                    {
                        dgv_product.Rows.Add(false, str[0], str[1], string.Format("{0:#,###}", Convert.ToInt32(str[2])), str[3], str[4], str[5], str[6]);
                    }
                }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            GetProductData();
        }
        private void tb_OrderPrice_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == Convert.ToChar(Keys.Back)))
            {
                e.Handled = true;
            }
        }
        private void tb_OrderPrice_TextChanged(object sender, EventArgs e)
        {
            long longPrice = 0;
            if (!(tb_OrderPrice.Text.Equals(""))) longPrice = Convert.ToInt64(tb_OrderPrice.Text.Replace(",", ""));
            tb_OrderPrice.Text = String.Format("{0:#,###}", longPrice);
            tb_OrderPrice.SelectionStart = tb_OrderPrice.TextLength;
            tb_OrderPrice.SelectionLength = 0;
        }
        private void label_Emergency_Click(object sender, EventArgs e)
        {
            tb_Emergency.Text = "긴급";
        }
    }    
}